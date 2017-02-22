using System;
using System.ComponentModel.DataAnnotations;
using QSOrmProject;

namespace BioGorod.Domain.Company
{
	[OrmSubject (Gender = QSProjectsLib.GrammaticalGender.Masculine,
		NominativePlural = "цвета кабин",
		Nominative = "цвет кабины")]
	public class CabineColor : PropertyChangedBase, IDomainObject
	{
		#region Свойства

		public virtual int Id { get; set; }

		string name;

		[Display (Name = "Имя")]
		public virtual string Name {
			get { return name; }
			set { SetField (ref name, value.Trim(), () => Name); }
		}

		#endregion

	}
}

