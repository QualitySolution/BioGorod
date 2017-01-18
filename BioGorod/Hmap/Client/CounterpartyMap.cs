using System;
using BioGorod.Domain.Client;
using FluentNHibernate.Mapping;

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
			Map (x => x.Code1c).Column ("code_1c");
			Map (x => x.Comment).Column ("comment");
			Map (x => x.INN).Column ("inn");
			Map (x => x.KPP).Column ("kpp");
			Map (x => x.JurAddress).Column ("jur_address");
			Map (x => x.Address).Column ("address");
			Map (x => x.CooperationCustomer).Column ("cooperation_customer");
			Map (x => x.CooperationSupplier).Column ("cooperation_supplier");
			Map (x => x.CooperationPartner).Column ("cooperation_partner");
			Map (x => x.SignatoryFIO).Column ("signatory_FIO");
			Map (x => x.SignatoryPost).Column ("signatory_post");
			Map (x => x.SignatoryBaseOf).Column ("signatory_base_of");
			Map (x => x.DocumentsDelivery).Column ("documents_delivery").CustomType<DocumentsDeliveryStringType> ();
			References (x => x.PaymentManager).Column ("payment_manager_id");
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