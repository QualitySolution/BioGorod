using System;
using System.Collections.Generic;
using QSOrmProject;
using QSProjectsLib;
using QSContacts;
using QSOrmProject.DomainMapping;
using BioGorod.Domain.Company;
using BioGorod.Dialogs.Company;
using BioGorod.JournalFilters;
using Gamma.Utilities;

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
			};
			OrmMain.ClassMappingList.AddRange (QSBanks.QSBanksMain.GetModuleMaping ());
			OrmMain.ClassMappingList.AddRange (QSContactsMain.GetModuleMaping ());
		}
	}
}
