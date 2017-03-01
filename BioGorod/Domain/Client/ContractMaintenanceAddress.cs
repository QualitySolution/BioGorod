using System;
using System.ComponentModel.DataAnnotations;
using QSOrmProject;

namespace BioGorod.Domain.Client
{
	public class ContractMaintenanceAddress : PropertyChangedBase, IDomainObject
	{
		public virtual int Id { get; set; }

		private ContractMaintenance contract;

		[Display (Name = "Договор")]
		public virtual ContractMaintenance Contract {
			get { return contract; }
			set { SetField (ref contract, value, () => Contract); }
		}

		private DeliveryPoint deliveryPoint;

		[Display (Name = "Адрес объекта")]
		public virtual DeliveryPoint DeliveryPoint {
			get { return deliveryPoint; }
			set { SetField (ref deliveryPoint, value, () => DeliveryPoint); }
		}

		private DateTime? startAt;

		[Display (Name = "Действует с")]
		public virtual DateTime? StartAt {
		    get { return startAt; }
		    set { SetField (ref startAt, value, () => StartAt); }
		}

		private decimal maintenanceStdCost;

		[Display (Name = "Стоимость планового ТО(стандарт)")]
		public virtual decimal MaintenanceStdCost {
		    get { return maintenanceStdCost; }
		    set { SetField (ref maintenanceStdCost, value, () => MaintenanceStdCost); }
		}

		private decimal maintenanceWinterCost;

		[Display (Name = "Стоимость планового ТО(зимний)")]
		public virtual decimal MaintenanceWinterCost {
		    get { return maintenanceWinterCost; }
		    set { SetField (ref maintenanceWinterCost, value, () => MaintenanceWinterCost); }
		}

		private decimal additionalMaintenanceStdCost;

		[Display (Name = "Стоимость доп. ТО(стандарт)")]
		public virtual decimal AdditionalMaintenanceStdCost {
		    get { return additionalMaintenanceStdCost; }
		    set { SetField (ref additionalMaintenanceStdCost, value, () => AdditionalMaintenanceStdCost); }
		}

		private decimal additionalMaintenanceWinterCost;

		[Display (Name = "Стоимость доп. ТО(зимний)")]
		public virtual decimal AdditionalMaintenanceWinterCost {
		    get { return additionalMaintenanceWinterCost; }
		    set { SetField (ref additionalMaintenanceWinterCost, value, () => AdditionalMaintenanceWinterCost); }
		}

		private int maintenanceCount;

		[Display (Name = "Количество ТО в месяц")]
		public virtual int MaintenanceCount {
		    get { return maintenanceCount; }
		    set { SetField (ref maintenanceCount, value, () => MaintenanceCount); }
		}

		private int cabineCount;

		[Display (Name = "Количество кабинок")]
		public virtual int CabineCount {
		    get { return cabineCount; }
		    set { SetField (ref cabineCount, value, () => CabineCount); }
		}

		private string info;

		[Display (Name = "Информация о кабинках")]
		public virtual string Info {
		    get { return info; }
		    set { SetField (ref info, value, () => Info); }
		}

		public ContractMaintenanceAddress()
		{
			
		}
	}
}

