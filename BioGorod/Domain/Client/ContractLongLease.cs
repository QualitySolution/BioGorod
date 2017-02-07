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
	}
}

