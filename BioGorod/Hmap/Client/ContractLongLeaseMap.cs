using System;
using BioGorod.Domain.Client;
using FluentNHibernate.Mapping;

namespace BioGorod.Hmap.Client
{
	public class ContractLongLeaseMap : SubclassMap<ContractLongLease>
	{
		public ContractLongLeaseMap ()
		{
			DiscriminatorValue ("LongLease");

			HasMany (x => x.Addresses).Inverse().Cascade.AllDeleteOrphan ().LazyLoad ()
				.KeyColumn ("contract_id");
			
		}
	}}

