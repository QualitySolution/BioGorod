using System.Collections.Generic;
using BioGorod.Domain.Client;
using BioGorod.Domain.Company;
using QSBanks;
using QSContacts;
using QSOrmProject.Deletion;

namespace BioGorod
{
	partial class MainClass
	{
		public static void ConfigureDeletion ()
		{
			logger.Info ("Настройка параметров удаления...");

			QSContactsMain.ConfigureDeletion ();
			QSBanksMain.ConfigureDeletion ();

			DeleteConfig.AddClearDependence<Post> (ClearDependenceInfo.Create<Contact> (item => item.Post));
			DeleteConfig.AddClearDependence<Account> (ClearDependenceInfo.Create<Organization> (item => item.DefaultAccount));
			DeleteConfig.AddClearDependence<Account> (ClearDependenceInfo.Create<Counterparty> (item => item.DefaultAccount));

			#region Client

			DeleteConfig.AddHibernateDeleteInfo<Contact>()
				.AddDeleteDependenceFromBag(item => item.Emails)
				.AddDeleteDependenceFromBag(item => item.Phones)
				.AddRemoveFromDependence<DeliveryPoint>(x => x.Contacts);

			DeleteConfig.AddHibernateDeleteInfo<Contract>().HasSubclasses()
				;
			DeleteConfig.AddHibernateDeleteInfo<ContractLongLease>()
				.AddDeleteDependence<ContractLongLeaseAddress>(x => x.Contract);
			
			DeleteConfig.AddHibernateDeleteInfo<ContractLongLeaseAddress>();

			DeleteConfig.AddHibernateDeleteInfo<ContractMaintenance>()
				.AddDeleteDependence<ContractMaintenanceAddress>(x => x.Contract);

			DeleteConfig.AddHibernateDeleteInfo<ContractMaintenanceAddress>();

			DeleteConfig.AddHibernateDeleteInfo<ContractShortLease>()
				.AddDeleteDependence<ContractShortLeaseAddress>(x => x.Contract);
			
			DeleteConfig.AddHibernateDeleteInfo<ContractShortLeaseAddress>()
				;
			
			DeleteConfig.AddHibernateDeleteInfo<Counterparty>()
				.AddDeleteDependence<Contact>(x => x.Counterparty)
				.AddDeleteDependence<Contract>(x => x.Counterparty)
				.AddDeleteDependence<DeliveryPoint>(x => x.Counterparty)
				.AddDeleteDependenceFromBag(item => item.Emails)
				.AddDeleteDependenceFromBag(item => item.Phones)
				.AddDeleteDependenceFromBag(item => item.Accounts);
			
			DeleteConfig.AddHibernateDeleteInfo<DeliveryPoint>()
				.AddDeleteDependence<ContractLongLeaseAddress>(x => x.DeliveryPoint)
				.AddDeleteDependence<ContractShortLeaseAddress>(x => x.DeliveryPoint)
				.AddDeleteDependence<ContractMaintenanceAddress>(x => x.DeliveryPoint)
				//.AddDeleteDependenceFromBag(x => x.Contacts) FIXME сделать чтобы работало.
				;

			DeleteConfig.AddHibernateDeleteInfo<DocTemplate>()
				.AddClearDependence<Contract>(x => x.ContractTemplate);

			#endregion
			#region Company

			DeleteConfig.AddHibernateDeleteInfo<CabineColor>()
				.AddClearDependence<Cabine>(x => x.Color);

			DeleteConfig.AddHibernateDeleteInfo<Cabine>()
				.AddRemoveFromDependence<ContractLongLeaseAddress>(x => x.Cabines);

			DeleteConfig.AddHibernateDeleteInfo<Employee>()
				.AddClearDependence<Counterparty>(x => x.PaymentManager)
				.AddClearDependence<Organization>(x => x.Buhgalter)
				.AddClearDependence<Organization>(x => x.Leader)
				.AddDeleteDependenceFromBag(x => x.Phones);

			DeleteConfig.AddHibernateDeleteInfo<Organization>()
				.AddDeleteDependence<Contract>(x => x.Organization)
				.AddDeleteDependenceFromBag(x => x.Phones)
				.AddDeleteDependenceFromBag(x => x.Accounts);
			
			DeleteConfig.AddHibernateDeleteInfo<User>()
				.AddClearDependence<Employee>(x => x.User);

			#endregion

			//Для тетирования
			#if DEBUG
			DeleteConfig.IgnoreMissingClass.Add(typeof(ContactAndPhonesView));

			DeleteConfig.DeletionCheck ();
			#endif

			logger.Info ("Ок");
		}
	}
}
