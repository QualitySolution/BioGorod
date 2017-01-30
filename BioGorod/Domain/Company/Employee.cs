﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QSBanks;
using QSOrmProject;
using QSProjectsLib;

namespace BioGorod.Domain.Company
{
	[OrmSubject (Gender = QSProjectsLib.GrammaticalGender.Masculine,
		NominativePlural = "сотрудники",
		Nominative = "сотрудник")]
	public class Employee : AccountOwnerBase, IDomainObject, IValidatableObject, ISpecialRowsRender, IBusinessObject
	{
		#region Свойства

		public virtual IUnitOfWork UoW { set; get;}

		public virtual int Id { get; set; }

		string name;

		[Display (Name = "Имя")]
		public virtual string Name {
			get { return name; }
			set { SetField (ref name, value.Trim(), () => Name); }
		}

		string lastName;

		[Display (Name = "Фамилия")]
		public virtual string LastName {
			get { return lastName; }
			set { SetField (ref lastName, value.Trim(), () => LastName); }
		}

		string patronymic;

		[Display (Name = "Отчество")]
		public virtual string Patronymic {
			get { return patronymic; }
			set { SetField (ref patronymic, value.Trim(), () => Patronymic); }
		}

		EmployeeCategory category;

		[Display (Name = "Категория")]
		public virtual EmployeeCategory Category {
			get { return category; }
			set { SetField (ref category, value, () => Category); }
		}

		string passportSeria;

		[Display (Name = "Серия паспорта")]
		public virtual string PassportSeria {
			get { return passportSeria; }
			set { SetField (ref passportSeria, value, () => PassportSeria); }
		}

		string passportNumber;

		[Display (Name = "Номер паспорта")]
		public virtual string PassportNumber {
			get { return passportNumber; }
			set { SetField (ref passportNumber, value, () => PassportNumber); }
		}

		private string passportIssuedBy;

		[Display (Name = "Кем выдан паспорт")]
		public virtual string PassportIssuedBy {
		    get { return passportIssuedBy; }
		    set { SetField (ref passportIssuedBy, value, () => PassportIssuedBy); }
		}

		private DateTime? passportIssuedDate;

		[Display (Name = "Когда выдан паспорт")]
		public virtual DateTime? PassportIssuedDate {
		    get { return passportIssuedDate; }
		    set { SetField (ref passportIssuedDate, value, () => PassportIssuedDate); }
		}

		string drivingNumber;

		[Display (Name = "Водительское удостоверение")]
		public virtual string DrivingNumber {
			get { return drivingNumber; }
			set { SetField (ref drivingNumber, value, () => DrivingNumber); }
		}

		string addressRegistration;

		[Display (Name = "Адрес регистрации")]
		public virtual string AddressRegistration {
			get { return addressRegistration; }
			set { SetField (ref addressRegistration, value, () => AddressRegistration); }
		}

		string addressCurrent;

		[Display (Name = "Фактический адрес")]
		public virtual string AddressCurrent {
			get { return addressCurrent; }
			set { SetField (ref addressCurrent, value, () => AddressCurrent); }
		}

		bool isFired;

		[Display (Name = "Сотрудник уволен")]
		public virtual bool IsFired {
			get { return isFired; }
			set { SetField (ref isFired, value, () => IsFired); }
		}

		IList<QSContacts.Phone> phones;

		[Display (Name = "Телефоны")]
		public virtual IList<QSContacts.Phone> Phones {
			get { return phones; }
			set { SetField (ref phones, value, () => Phones); }
		}

		User user;

		[Display (Name = "Пользователь")]
		public virtual User User {
			get { return user; }
			set { SetField (ref user, value, () => User); }
		}

		byte[] photo;

		[Display (Name = "Фотография")]
		public virtual byte[] Photo {
			get { return photo; }
			set { SetField (ref photo, value, () => Photo); }
		}

		private DateTime dateOfCreate;

		[Display (Name = "Дата создания")]
		public virtual DateTime DateOfCreate
		{
			get { return dateOfCreate; }
			set { SetField (ref dateOfCreate, value, () => DateOfCreate); }
		}

		#endregion

		public Employee ()
		{
			Name = String.Empty;
			LastName = String.Empty;
			Patronymic = String.Empty;
			PassportSeria = String.Empty;
			PassportNumber = String.Empty;
			DrivingNumber = String.Empty;
			Category = EmployeeCategory.office;
			AddressRegistration = String.Empty;
			AddressCurrent = String.Empty;
			DateOfCreate = DateTime.Now;
		}

		[Display (Name = "ФИО")]
		public virtual string FullName {
			get { return String.Format ("{0} {1} {2}", LastName, Name, Patronymic); }
		}

		[Display (Name = "Фамилия и инициалы")]
		public virtual string ShortName {
			get { return StringWorks.PersonNameWithInitials (LastName, Name, Patronymic); }
		}

		public virtual string Title {
			get { return ShortName;}
		}

		#region IValidatableObject implementation

		public virtual IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
		{
			if (String.IsNullOrEmpty (Name) && String.IsNullOrEmpty (LastName) && String.IsNullOrEmpty (Patronymic))
				yield return new ValidationResult ("Должно быть заполнено хотя бы одно из следующих полей: " +
				"Фамилия, Имя, Отчество)", new[] { "Name", "LastName", "Patronymic" });
		}

		#endregion

		#region ISpecialRowsRender implementation

		public virtual string TextColor { get { return IsFired ? "grey" : "black"; } }

		#endregion
	}

	public enum EmployeeCategory
	{
		[Display (Name = "Офисный работник")]
		office,
		[Display (Name = "Водитель")]
		driver
	}

	public class EmployeeCategoryStringType : NHibernate.Type.EnumStringType
	{
		public EmployeeCategoryStringType () : base (typeof(EmployeeCategory))
		{
		}
	}
}

