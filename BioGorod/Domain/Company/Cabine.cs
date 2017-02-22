using System;
using QSOrmProject;
using System.ComponentModel.DataAnnotations;

namespace BioGorod.Domain.Company
{
	[OrmSubject (Gender = QSProjectsLib.GrammaticalGender.Feminine,
		NominativePlural = "кабины",
		Nominative = "кабина")]
	public class Cabine : PropertyChangedBase, IDomainObject
	{
		#region Свойства

		public virtual int Id { get; set; }

		private string number;

		[Display (Name = "Номер")]
		public virtual string Number {
		    get { return number; }
		    set { SetField (ref number, value, () => Number); }
		}

		string name;

		[Display (Name = "Имя")]
		public virtual string Name {
			get { return name; }
			set { SetField (ref name, value.Trim(), () => Name); }
		}

		private CabineColor color;

		[Display (Name = "Цвет")]
		public virtual CabineColor Color {
		    get { return color; }
		    set { SetField (ref color, value, () => Color); }
		}

		#endregion
	}
}

