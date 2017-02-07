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
	}
}

