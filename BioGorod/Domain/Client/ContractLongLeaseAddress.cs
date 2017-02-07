using System;
using System.ComponentModel.DataAnnotations;
using QSOrmProject;

namespace BioGorod.Domain.Client
{
	public class ContractLongLeaseAddress : PropertyChangedBase, IDomainObject
	{
		public virtual int Id { get; set; }

		private Contract contract;

		[Display (Name = "Договор")]
		public virtual Contract Contract {
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

		private decimal cabineStdCost;

		[Display (Name = "Стоимость кабины(стандарт)")]
		public virtual decimal CabineStdCost {
		    get { return cabineStdCost; }
		    set { SetField (ref cabineStdCost, value, () => CabineStdCost); }
		}

		private decimal cabineWinterCost;

		[Display (Name = "Стоимость кабины(зимний)")]
		public virtual decimal CabineWinterCost {
		    get { return cabineWinterCost; }
		    set { SetField (ref cabineWinterCost, value, () => CabineWinterCost); }
		}

		private decimal additionalServiceStdCost;

		[Display (Name = "Стоимость доп. ТО(стандарт)")]
		public virtual decimal AdditionalServiceStdCost {
		    get { return additionalServiceStdCost; }
		    set { SetField (ref additionalServiceStdCost, value, () => AdditionalServiceStdCost); }
		}

		private decimal additionalServiceWinterCost;

		[Display (Name = "Стоимость доп. ТО(зимний)")]
		public virtual decimal AdditionalServiceWinterCost {
		    get { return additionalServiceWinterCost; }
		    set { SetField (ref additionalServiceWinterCost, value, () => AdditionalServiceWinterCost); }
		}

		private int maintenanceCount;

		[Display (Name = "Количество ТО в месяц")]
		public virtual int MaintenanceCount {
		    get { return maintenanceCount; }
		    set { SetField (ref maintenanceCount, value, () => MaintenanceCount); }
		}

		public ContractLongLeaseAddress()
		{
			
		}
	}
}

