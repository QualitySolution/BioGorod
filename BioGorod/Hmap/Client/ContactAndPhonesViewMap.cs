using System;
using BioGorod.Domain.Client;
using FluentNHibernate.Mapping;

namespace BioGorod.Hmap.Client
{
	public class ContactAndPhonesViewMap : ClassMap<ContactAndPhonesView>
	{
		public ContactAndPhonesViewMap ()
		{
			Table ("contacts_with_phones");

			Id (x => x.Id).Column ("id").GeneratedBy.Native ();

			Map (x => x.Surname)	.Column ("surname");
			Map (x => x.Name)		.Column ("name");
			Map (x => x.Patronymic)	.Column ("patronymic");
			Map (x => x.Comment)	.Column ("comment");
			Map (x => x.IsFired)	.Column ("fired");

			Map (x => x.NameAndPhones)	.Column ("name_and_phones");
			Map (x => x.PhonesDigits)	.Column ("phons_digits");

			References (x => x.Post)		.Column ("post_id");
			References (x => x.Counterparty).Column ("counterparty_id");

			HasMany (x => x.Phones).Cascade.AllDeleteOrphan ().LazyLoad ()
				.KeyColumn ("counterparty_contact_id");

			HasMany (x => x.Emails).Cascade.AllDeleteOrphan ().LazyLoad ()
				.KeyColumn ("counterparty_contact_id");

			HasManyToMany(x => x.DeliveryPoints).Table("counterparty_delivery_point_contacts")
				.ParentKeyColumn("contact_person_id")
				.ChildKeyColumn("delivery_point_id")
				.LazyLoad();
		}
	}}

