using System;
using BioGorod.Domain.Client;
using FluentNHibernate.Mapping;

namespace BioGorod.Hmap.Client
{
	public class ContractLongLeaseAddressMap : ClassMap<ContractLongLeaseAddress>
	{
		public ContractLongLeaseAddressMap ()
		{
			Table ("contracts_long_addresses");

			Id (x => x.Id).Column ("id").GeneratedBy.Native ();

			Map (x => x.StartAt).Column ("start_at");
			Map (x => x.CabineStdCost).Column ("cabine_std_cost");
			Map (x => x.CabineWinterCost).Column ("cabine_winter_cost");
			Map (x => x.AdditionalServiceStdCost).Column ("additional_maintenance_std_cost");
			Map (x => x.AdditionalServiceWinterCost).Column ("additional_maintenance_winter_cost");
			Map (x => x.MaintenanceCount).Column ("maintenance_count");

			References (x => x.Contract).Column ("contract_id");
			References (x => x.DeliveryPoint).Column ("delivery_point_id");

			HasManyToMany(x => x.Cabines).Table ("contracts_long_cabines")
				.ParentKeyColumn ("contract_long_address_id")
				.ChildKeyColumn ("cabine_id")
				.Not.LazyLoad ();
		}
	}}

