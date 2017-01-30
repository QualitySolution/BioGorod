﻿using System;
using QSOrmProject;
using QSBanks;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BioGorod.Domain.Company
{
	[OrmSubject (Gender = QSProjectsLib.GrammaticalGender.Feminine,
		NominativePlural = "организации",
		Nominative = "организация")]
	public class Organization : AccountOwnerBase, IDomainObject
	{

		#region Свойства

		public virtual int Id { get; set; }

		string name;

		[Display (Name = "Название")]
		[Required (ErrorMessage = "Название организации должно быть заполнено.")]
		public virtual string Name {
			get { return name; }
			set { SetField (ref name, value, () => Name); }
		}

		string fullName;

		[Display (Name = "Полное название")]
		public virtual string FullName {
			get { return fullName; }
			set { SetField (ref fullName, value, () => FullName); }
		}

		string iNN;

		[Display (Name = "ИНН")]
		[StringLength (12, MinimumLength = 0, ErrorMessage = "Номер ИНН не должен превышать 12.")]
		public virtual string INN {
			get { return iNN; }
			set { SetField (ref iNN, value, () => INN); }
		}

		string kPP;

		[Display (Name = "КПП")]
		[StringLength (9, MinimumLength = 0, ErrorMessage = "Номер КПП не должен превышать 9 цифр.")]
		public virtual string KPP {
			get { return kPP; }
			set { SetField (ref kPP, value, () => KPP); }
		}

		string oGRN;

		[Display (Name = "ОГРН")]
		[StringLength (13, MinimumLength = 0, ErrorMessage = "Номер ОГРН не должен превышать 13 цифр.")]
		public virtual string OGRN {
			get { return oGRN; }
			set { SetField (ref oGRN, value, () => OGRN); }
		}

		IList<QSContacts.Phone> phones;

		[Display (Name = "Телефоны")]
		public virtual IList<QSContacts.Phone> Phones {
			get { return phones; }
			set { SetField (ref phones, value, () => Phones); }
		}

		string email;

		[Display (Name = "E-mail адреса")]
		public virtual string Email {
			get { return email; }
			set { SetField (ref email, value, () => Email); }
		}

		string address;

		[Display (Name = "Фактический адрес")]
		public virtual string Address {
			get { return address; }
			set { SetField (ref address, value, () => Address); }
		}

		string jurAddress;

		[Display (Name = "Юридический адрес")]
		public virtual string JurAddress {
			get { return jurAddress; }
			set { SetField (ref jurAddress, value, () => JurAddress); }
		}

		private string postAddress;

		[Display (Name = "Почтовый адрес")]
		public virtual string PostAddress {
		    get { return postAddress; }
		    set { SetField (ref postAddress, value, () => PostAddress); }
		}

		Employee leader;

		[Display (Name = "Руководитель")]
		public virtual Employee Leader {
			get { return leader; }
			set { SetField (ref leader, value, () => Leader); }
		}

		Employee buhgalter;

		[Display (Name = "Бухгалтер")]
		public virtual Employee Buhgalter {
			get { return buhgalter; }
			set { SetField (ref buhgalter, value, () => Buhgalter); }
		}

		#endregion

		public Organization ()
		{
			Name = "Новая организация";
			FullName = String.Empty;
			INN = String.Empty;
			KPP = String.Empty;
			OGRN = String.Empty;
			Email = String.Empty;
			Address = String.Empty;
			JurAddress = String.Empty;
		}
	}
}

