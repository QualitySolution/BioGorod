using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Bindings.Collections.Generic;
using QSOrmProject;
using QSProjectsLib;

namespace BioGorod.Domain.Client
{
	[OrmSubject (
		Gender = GrammaticalGender.Masculine,
		NominativePlural = "договоры контрагента",
		Nominative = "договор долгосрочной аренды",
		Genitive = " договора долгосрочной аренды",
		Accusative = "договор долгосрочной аренды"
	)]
	public class ContractLongLease : Contract
	{
		private IList<ContractLongLeaseAddress> addresses;

		[Display (Name = "Адреса")]
		public virtual IList<ContractLongLeaseAddress> Addresses {
		    get { return addresses; }
		    set { SetField (ref addresses, value, () => Addresses); }
		}

		GenericObservableList<ContractLongLeaseAddress> observableAddresses;
		//FIXME Кослыль пока не разберемся как научить hibernate работать с обновляемыми списками.
		public virtual GenericObservableList<ContractLongLeaseAddress> ObservableAddresses {
			get {
				if (observableAddresses == null)
					observableAddresses = new GenericObservableList<ContractLongLeaseAddress> (Addresses);
				return observableAddresses;
			}
		}

		#region Функции

		public virtual void AddAddress(DeliveryPoint point)
		{
			var address = new ContractLongLeaseAddress()
				{
					Contract = this,
					DeliveryPoint = point
				};
			ObservableAddresses.Add(address);
		}

		#endregion
	}
}

