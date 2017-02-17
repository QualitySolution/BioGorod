using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Bindings.Collections.Generic;
using System.Linq;
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
		protected static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();

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
			if(Addresses.Any(x => x.DeliveryPoint.Id == point.Id))
			{
				logger.Warn("Адрес '{0}' уже добавлен, пропускаем.", point.CompiledAddress);
				return;
			}

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

