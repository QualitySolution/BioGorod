using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QSOrmProject;
using QSProjectsLib;

namespace BioGorod.Domain.Client
{
	[OrmSubject (
		Gender = GrammaticalGender.Masculine,
		NominativePlural = "договоры контрагента",
		Nominative = "договор короткосрочной аренды",
		Genitive = " договора короткосрочной аренды",
		Accusative = "договор короткосрочной аренды"
	)]
	public class ContractShortLease : Contract
	{
		private int cabineCount;

		[Display (Name = "Количество кабин")]
		public virtual int CabineCount {
		    get { return cabineCount; }
		    set { SetField (ref cabineCount, value, () => CabineCount); }
		}

		private bool waterDispenser;

		[Display (Name = "Наличие рукомойника")]
		public virtual bool WaterDispenser {
		    get { return waterDispenser; }
		    set { SetField (ref waterDispenser, value, () => WaterDispenser); }
		}

		private bool additionalWater;

		[Display (Name = "Дополнительная вода")]
		public virtual bool AdditionalWater {
		    get { return additionalWater; }
		    set { SetField (ref additionalWater, value, () => AdditionalWater); }
		}

		private string additionalInfo;

		[Display (Name = "Дополнительная информация")]
		public virtual string AdditionalInfo {
		    get { return additionalInfo; }
		    set { SetField (ref additionalInfo, value, () => AdditionalInfo); }
		}

		private DateTime deliveryTime;

		[Display (Name = "Время доставки")]
		public virtual DateTime DeliveryTime {
		    get { return deliveryTime; }
		    set { SetField (ref deliveryTime, value, () => DeliveryTime); }
		}

		private DateTime removalTime;

		[Display (Name = "Время вывоза")]
		public virtual DateTime RemovalTime {
		    get { return removalTime; }
		    set { SetField (ref removalTime, value, () => RemovalTime); }
		}

		private decimal cabineCost;

		[Display (Name = "Стоимость кабины")]
		public virtual decimal CabineCost {
		    get { return cabineCost; }
		    set { SetField (ref cabineCost, value, () => CabineCost); }
		}

		private decimal deliveryCost;

		[Display (Name = "Стоимость доставки")]
		public virtual decimal DeliveryCost {
		    get { return deliveryCost; }
		    set { SetField (ref deliveryCost, value, () => DeliveryCost); }
		}

		 private decimal totalCost;

		 [Display (Name = "Общая стоимость")]
		 public virtual decimal TotalCost {
		     get { return totalCost; }
		     set { SetField (ref totalCost, value, () => TotalCost); }
		}

		private IList<ContractShortLeaseAddress> addresses;

		[Display (Name = "Адреса")]
		public virtual IList<ContractShortLeaseAddress> Addresses {
			get { return addresses; }
			set { SetField (ref addresses, value, () => Addresses); }
		}
	}
}

