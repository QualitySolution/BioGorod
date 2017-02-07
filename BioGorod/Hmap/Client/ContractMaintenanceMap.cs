using System;
using BioGorod.Domain.Client;
using FluentNHibernate.Mapping;

namespace BioGorod.Hmap.Client
{
	public class ContractMaintenanceMap : SubclassMap<ContractMaintenance>
	{
		public ContractMaintenanceMap ()
		{
			DiscriminatorValue ("Maintenance");

			HasMany (x => x.Addresses).Inverse().Cascade.AllDeleteOrphan ().LazyLoad ()
				.KeyColumn ("contract_id");
			
		}
	}}

