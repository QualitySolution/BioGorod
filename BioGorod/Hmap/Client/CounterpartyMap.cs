using System;
using BioGorod.Domain.Client;
using FluentNHibernate.Mapping;
using QSOsm.Data;
using NHibernate.JsonColumn;

namespace BioGorod.Hmap.Client
{
	public class CounterpartyMap : ClassMap<Counterparty>
	{
		public CounterpartyMap ()
		{
			Table ("counterparty");

			Id (x => x.Id).Column ("id").GeneratedBy.Native ();
			Map (x => x.IsArchive).Column ("is_archive");
			Map (x => x.Name).Column ("name");
			Map (x => x.FullName).Column ("full_name");
			Map (x => x.InternalName).Column ("internal_name");
			Map (x => x.HaveArbitration).Column ("have_arbitration");
			Map (x => x.RequirePrepayment).Column ("require_prepayment");
			Map (x => x.ContourFocus).Column ("сontour_focus");
			Map (x => x.MassRegistration).Column ("mass_registration");
			Map (x => x.CannotFindSince).Column ("cannot_find");
			Map (x => x.Code1c).Column ("code_1c");
			Map (x => x.Comment).Column ("comment");
			Map (x => x.INN).Column ("inn");
			Map (x => x.KPP).Column ("kpp");
			Map (x => x.LegalAddress).Column ("legal_address").CustomType<JsonMappableType<JsonAddress>>();
			Map (x => x.ActualAddress).Column ("actual_address").CustomType<JsonMappableType<JsonAddress>>();
			Map (x => x.DocDeliveryAddress).Column ("doc_delivery_address").CustomType<JsonMappableType<JsonAddress>>();
			Map (x => x.CooperationCustomer).Column ("cooperation_customer");
			Map (x => x.CooperationSupplier).Column ("cooperation_supplier");
			Map (x => x.CooperationPartner).Column ("cooperation_partner");
			Map (x => x.SignatoryFIO).Column ("signatory_FIO");
			Map (x => x.SignatoryFIOGenetivus).Column ("signatory_FIO_genetivus");
			Map (x => x.SignatoryPost).Column ("signatory_post");
			Map (x => x.SignatoryBaseOf).Column ("signatory_base_of");
			Map (x => x.DocumentsDelivery).Column ("documents_delivery").CustomType<DocumentsDeliveryStringType> ();
			References (x => x.PaymentManager).Column ("payment_manager_id");
			References (x => x.DefaultAccount).Column ("default_account_id");
			HasMany (x => x.Phones).Cascade.AllDeleteOrphan ().LazyLoad ()
				.KeyColumn ("counterparty_id");
			HasMany (x => x.Accounts).Cascade.AllDeleteOrphan ().LazyLoad ()
				.KeyColumn ("counterparty_id");
			HasMany (x => x.DeliveryPoints).Inverse().Cascade.AllDeleteOrphan ().LazyLoad ()
				.KeyColumn ("counterparty_id");
			HasMany (x => x.Emails).Cascade.AllDeleteOrphan ().LazyLoad ()
				.KeyColumn ("counterparty_id");
			HasMany (x => x.Contacts).Cascade.AllDeleteOrphan ().LazyLoad ().Inverse ()
				.KeyColumn ("counterparty_id");
//			HasMany (x => x.CounterpartyContracts).Cascade.None ().LazyLoad ().Inverse ()
//				.KeyColumn ("counterparty_id");
		}
	}
}