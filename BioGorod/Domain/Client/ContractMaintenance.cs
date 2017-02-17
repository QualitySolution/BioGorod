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
		Nominative = "договор обслуживания",
		Genitive = " договора обслуживания",
		Accusative = "договор обслуживания"
	)]
	public class ContractMaintenance : Contract
	{
		private IList<ContractMaintenanceAddress> addresses;

		[Display (Name = "Адреса")]
		public virtual IList<ContractMaintenanceAddress> Addresses {
		    get { return addresses; }
		    set { SetField (ref addresses, value, () => Addresses); }
		}

		GenericObservableList<ContractMaintenanceAddress> observableAddresses;
		//FIXME Кослыль пока не разберемся как научить hibernate работать с обновляемыми списками.
		public virtual GenericObservableList<ContractMaintenanceAddress> ObservableAddresses {
			get {
				if (observableAddresses == null)
					observableAddresses = new GenericObservableList<ContractMaintenanceAddress> (Addresses);
				return observableAddresses;
			}
		}

		#region Функции

		public virtual void AddAddress(DeliveryPoint point)
		{
			var address = new ContractMaintenanceAddress()
				{
					Contract = this,
					DeliveryPoint = point
				};
			ObservableAddresses.Add(address);
		}

		#endregion

	}
}

