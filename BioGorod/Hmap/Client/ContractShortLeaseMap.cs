using System;
using BioGorod.Domain.Client;
using FluentNHibernate.Mapping;

namespace BioGorod.Hmap.Client
{
	public class ContractShortLeaseMap : SubclassMap<ContractShortLease>
	{
		public ContractShortLeaseMap ()
		{
			DiscriminatorValue ("ShortLease");

			Map(x => x.CabineCount).Column("short_cabine_count");
			Map(x => x.WaterDispenser).Column("short_water_dispenser");
			Map(x => x.AdditionalWater).Column("short_additional_water");
			Map(x => x.AdditionalInfo).Column("short_additional_info");
			Map(x => x.DeliveryTime).Column("short_delivery");
			Map(x => x.RemovalTime).Column("short_removal");
			Map(x => x.CabineCost).Column("short_cabine_cost");
			Map(x => x.DeliveryCost).Column("short_delivery_cost");
			Map(x => x.TotalCost).Column("short_total_cost");

			HasMany (x => x.Addresses).Inverse().Cascade.AllDeleteOrphan ().LazyLoad ()
				.KeyColumn ("contract_id");
			
		}
	}}

