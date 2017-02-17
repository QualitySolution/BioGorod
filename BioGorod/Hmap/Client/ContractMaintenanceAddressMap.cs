using System;
using BioGorod.Domain.Client;
using FluentNHibernate.Mapping;

namespace BioGorod.Hmap.Client
{
	public class ContractMaintenanceAddressMap : ClassMap<ContractMaintenanceAddress>
	{
		public ContractMaintenanceAddressMap ()
		{
			Table ("contracts_maintenance_addresses");

			Id (x => x.Id).Column ("id").GeneratedBy.Native ();

			Map (x => x.StartAt).Column ("start_at");
			Map (x => x.MaintenanceStdCost).Column ("maintenance_std_cost");
			Map (x => x.MaintenanceWinterCost).Column ("maintenance_winter_cost");
			Map (x => x.AdditionalMaintenanceStdCost).Column ("additional_maintenance_std_cost");
			Map (x => x.AdditionalMaintenanceWinterCost).Column ("additional_maintenance_winter_cost");
			Map (x => x.MaintenanceCount).Column ("maintenance_count");
			Map (x => x.Info).Column ("info");
			Map (x => x.CabineCount).Column ("cabine_count");

			References (x => x.Contract).Column ("contract_id");
			References (x => x.DeliveryPoint).Column ("delivery_point_id");
		}
	}}

