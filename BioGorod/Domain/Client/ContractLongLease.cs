using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
		protected static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();

		public virtual event EventHandler<AddressesChangedEventArgs> AddressesChanged;

		private IList<ContractLongLeaseAddress> addresses;

		[Display (Name = "Адреса")]
		public virtual IList<ContractLongLeaseAddress> Addresses {
		    get { return addresses; }
		    set { SetField (ref addresses, value, () => Addresses); }
		}

		#region Расчетные

		public virtual IEnumerable<DateTime> ChangesDates
		{
			get{
				return Addresses.Where(x => x.StartAt.HasValue).Select(x => x.StartAt.Value).Distinct();
			}
		}

		public virtual DateTime? LastAddressesChanges{
			get{
				if (ChangesDates.Any())
					return ChangesDates.Max();
				else
					return null;
			}
		}

		#endregion

		#region Функции

		public virtual void AddAddress(DeliveryPoint point)
		{
			var last = LastAddressesChanges;
			if(Addresses.Any(x => x.DeliveryPoint.Id == point.Id && x.StartAt == last))
			{
				logger.Warn("Адрес '{0}' уже добавлен, пропускаем.", point.CompiledAddress);
				return;
			}

			var address = new ContractLongLeaseAddress()
				{
					Contract = this,
					DeliveryPoint = point,
					StartAt = last
				};
			Addresses.Add(address);
			OnAddressesChanged(last);
		}

		public virtual void RemoveAddress(ContractLongLeaseAddress address)
		{
			Addresses.Remove(address);
			OnAddressesChanged(address.StartAt);
		}

		public virtual void CopyAddressesToNewDate(DateTime date)
		{
			DateTime? lastDate = null;
			if (ChangesDates.Any())
				lastDate = ChangesDates.Max();
			var list = GetAddressesAtDate(lastDate);
			foreach(var old in list)
			{
				Addresses.Add(old.Copy(date));
			}
		}

		public virtual List<ContractLongLeaseAddress> GetAddressesAtDate(DateTime? since)
		{
			return Addresses.Where(x => x.StartAt == since).ToList();
		}

		private void OnAddressesChanged(DateTime? date)
		{
			if(AddressesChanged != null)
			{
				AddressesChanged(this, new AddressesChangedEventArgs
					{
						AtDate = date
					});
			}
		}

		#endregion
	}

	public class AddressesChangedEventArgs : EventArgs{
		public DateTime? AtDate { get; set;}
	}
}

