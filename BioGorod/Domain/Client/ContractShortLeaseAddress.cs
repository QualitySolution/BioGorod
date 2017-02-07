using System;
using QSOrmProject;
using System.ComponentModel.DataAnnotations;

namespace BioGorod.Domain.Client
{
	public class ContractShortLeaseAddress : PropertyChangedBase, IDomainObject
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

		public ContractShortLeaseAddress()
		{
		}
	}
}

