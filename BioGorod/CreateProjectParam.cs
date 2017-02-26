using System;
using System.Collections.Generic;
using BioGorod.Dialogs.Client;
using BioGorod.Dialogs.Company;
using BioGorod.Domain.Client;
using BioGorod.Domain.Company;
using BioGorod.JournalFilters;
using Gamma.Utilities;
using QSContacts;
using QSOrmProject;
using QSOrmProject.DomainMapping;
using QSProjectsLib;

namespace BioGorod
{
	partial class MainClass
	{
		static void CreateProjectParam ()
		{
			QSMain.ProjectPermission = new Dictionary<string, UserPermission> ();

			//Скрипты создания базы
/*			DBCreator.AddBaseScript (
				new Version(0, 1),
				"База с первоначальным заполением",
				"Fittings.SqlScripts.new-0.1.sql"
			);
*/		}

		static void CreateBaseConfig ()
		{
			logger.Info ("Настройка параметров базы...");

			// Настройка ORM
			var db = FluentNHibernate.Cfg.Db.MySQLConfiguration.Standard
				.ConnectionString (QSMain.ConnectionString)
				.ShowSql ()
				.FormatSql ();

			OrmMain.ConfigureOrm (db, new System.Reflection.Assembly[] {
				System.Reflection.Assembly.GetAssembly (typeof(MainClass)),
				System.Reflection.Assembly.GetAssembly (typeof(QSBanks.QSBanksMain)),
				System.Reflection.Assembly.GetAssembly (typeof(QSContactsMain)),
			});
			OrmMain.ClassMappingList = new List<IOrmObjectMapping> {
				//Компания
				OrmObjectMapping<User>.Create().DefaultTableView().SearchColumn("Название", x => x.Name).End(),
				OrmObjectMapping<Employee>.Create().Dialog<EmployeeDlg>().JournalFilter<EmployeeFilter>()
					.DefaultTableView().Column("Код", x => x.Id.ToString()).SearchColumn("Ф.И.О.", x => x.FullName).Column("Категория", x => x.Category.GetEnumTitle()).OrderAsc(x => x.LastName).OrderAsc(x => x.Name).OrderAsc(x => x.Patronymic).End(),
				OrmObjectMapping<Organization>.Create().Dialog<OrganizationDlg>().DefaultTableView().Column("Код", x => x.Id.ToString()).SearchColumn("Название", x => x.Name).End(),
				OrmObjectMapping<Cabine>.Create().Dialog<CabineDlg>()
					.DefaultTableView().SearchColumn("Номер", x => x.Number).SearchColumn("Название", x => x.Name).Column("Цвет", x => x.Color.Name).End(),
					OrmObjectMapping<CabineColor>.Create().DefaultTableView().Column("Код", x => x.Id.ToString()).SearchColumn("Название", x => x.Name).End(),
					//Клиент
				OrmObjectMapping<Contact>.Create().Dialog <ContactDlg>()
					.DefaultTableView().SearchColumn("Фамилия", x => x.Surname).SearchColumn("Имя", x => x.Name).SearchColumn("Отчество", x => x.Patronymic).End(),
				OrmObjectMapping<DeliveryPoint>.Create().Dialog<DeliveryPointDlg>(),
				OrmObjectMapping<DocTemplate>.Create().Dialog<DocTemplateDlg>().DefaultTableView().SearchColumn("Название", x => x.Name).Column("Тип", x => x.TemplateType.GetEnumTitle()).End(),
				OrmObjectMapping<Counterparty>.Create().Dialog<CounterpartyDlg>().DefaultTableView().SearchColumn("Название", x => x.FullName).End(),
					OrmObjectMapping<ContractLongLease>.Create().Dialog<ContractLongLeaseDlg>(),
					OrmObjectMapping<ContractShortLease>.Create().Dialog<ContractShortLeaseDlg>(),
					OrmObjectMapping<ContractMaintenance>.Create().Dialog<ContractMaintenanceDlg>(),
			};
			OrmMain.ClassMappingList.AddRange (QSBanks.QSBanksMain.GetModuleMaping ());
			OrmMain.ClassMappingList.AddRange (QSContactsMain.GetModuleMaping ());

			//Настройка ParentReference
			ParentReferenceConfig.AddActions (new ParentReferenceActions<Organization, QSBanks.Account> {
				AddNewChild = (o, a) => o.AddAccount (a)
			});
			ParentReferenceConfig.AddActions (new ParentReferenceActions<Counterparty, QSBanks.Account> {
				AddNewChild = (c, a) => c.AddAccount (a)
			});

		}
	}
}
