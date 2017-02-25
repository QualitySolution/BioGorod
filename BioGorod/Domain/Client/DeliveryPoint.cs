using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Bindings.Collections.Generic;
using System.Linq;
using Gamma.Utilities;
using QSOrmProject;
using QSOsm;
using QSOsm.DTO;

namespace BioGorod.Domain.Client
{
	[OrmSubject (Gender = QSProjectsLib.GrammaticalGender.Feminine,
		NominativePlural = "адреса объектов",
		Nominative = "адрес объекта",
		Accusative = "адрес объекта"
	)]
	public class DeliveryPoint : PropertyChangedBase, IDomainObject, IValidatableObject
	{
		#region Свойства

		public virtual int Id { get; set; }

		string letter;

		[Display (Name = "Литера")]
		[StringLength(2)]
		[PropertyChangedAlso ("CompiledAddress", "ShortAddress")]
		public virtual string Letter {
			get { return letter; }
			set { SetField (ref letter, value, () => Letter); }
		}

		string addressAddition;

		[Display (Name = "Дополнение к адресу")]
		public virtual string АddressAddition {
			get { return addressAddition; }
			set { SetField (ref addressAddition, value, () => АddressAddition); }
		}
			
		[Display (Name = "Полный адрес")]
		public virtual string CompiledAddress {
			get {
				string address = String.Empty;
				if (!String.IsNullOrWhiteSpace (City))
					address += String.Format ("{0} {1}, ", LocalityType.GetEnumShortTitle(), City);
				if (!String.IsNullOrWhiteSpace (Street))
					address += String.Format ("{0}, ", Street);
				if (!String.IsNullOrWhiteSpace (Building))
					address += String.Format ("д.{0}, ", Building);
				if (!String.IsNullOrWhiteSpace (Letter))
					address += String.Format ("лит.{0}, ", Letter);
				if (!String.IsNullOrWhiteSpace (Room))
					address += String.Format ("{0} {1}, ", RoomType.GetEnumShortTitle(), Room);
				if (!String.IsNullOrWhiteSpace (АddressAddition))
					address += String.Format ("{0}, ", АddressAddition);

				return address.TrimEnd (',', ' ');
			}
			set { ; }
		}

		[Display (Name = "Сокращенный адрес")]
		public virtual string ShortAddress {
			get {
				string address = String.Empty;
				if (!String.IsNullOrWhiteSpace (City) && City != "Санкт-Петербург")
					address += String.Format ("{0} {1}, ", LocalityType.GetEnumShortTitle(), AddressHelper.ShortenCity(City));
				if (!String.IsNullOrWhiteSpace (Street))
					address += String.Format ("{0}, ", AddressHelper.ShortenStreet(Street));
				if (!String.IsNullOrWhiteSpace (Building))
					address += String.Format ("д.{0}, ", Building);
				if (!String.IsNullOrWhiteSpace (Letter))
					address += String.Format ("лит.{0}, ", Letter);
				if (!String.IsNullOrWhiteSpace (Room))
					address += String.Format ("{0} {1}, ", RoomType.GetEnumShortTitle(), Room);

				return address.TrimEnd (',', ' ');
			}
			set { ; }
		}

		string city;

		[Display (Name = "Город")]
		[Required (ErrorMessage = "Город должен быть заполнен.")]
		[StringLength(45)]
		public virtual string City {
			get { return city; }
			set { SetField (ref city, value, () => City); }
		}

		LocalityType localityType;

		[Display (Name = "Тип населенного пункта")]
		public virtual LocalityType LocalityType {
			get { return localityType; }
			set { SetField (ref localityType, value, () => LocalityType); }
		}

		string cityDistrict;

		[Display (Name = "Район области")]
		public virtual string CityDistrict {
			get { return cityDistrict; }
			set { SetField (ref cityDistrict, value, () => CityDistrict); }
		}

		string street;

		[Display (Name = "Улица")]
		[StringLength(50)]
		public virtual string Street {
			get { return street; }
			set { SetField (ref street, value, () => Street); }
		}

		string streetDistrict;

		[Display (Name = "Район города")]
		public virtual string StreetDistrict {
			get { return streetDistrict; }
			set { SetField (ref streetDistrict, value, () => StreetDistrict); }
		}


		string building;

		[Display (Name = "Номер дома")]
		public virtual string Building {
			get { return building; }
			set { SetField (ref building, value, () => Building); }
		}

		RoomType roomType;

		[Display (Name = "Тип помещения")]
		public virtual RoomType RoomType {
			get { return roomType; }
			set { SetField (ref roomType, value, () => RoomType); }
		}

		string room;

		[Display (Name = "Офис/Квартира")]
		public virtual string Room {
			get { return room; }
			set { SetField (ref room, value, () => Room); }
		}

		string comment;

		[Display (Name = "Комментарий")]
		public virtual string Comment {
			get { return comment; }
			set { SetField (ref comment, value, () => Comment); }
		}

		decimal? latitude;

		[Display (Name = "Широта")]
		[PropertyChangedAlso ("СoordinatesText")]
		public virtual decimal? Latitude {
			get { return latitude; }
			set { SetField (ref latitude, value, () => Latitude); }
		}

		decimal? longitude;

		[Display (Name = "Долгота")]
		[PropertyChangedAlso ("СoordinatesText")]
		public virtual decimal? Longitude {
			get { return longitude; }
			set { SetField (ref longitude, value, () => Longitude); }
		}

		bool isActive = true;

		[Display (Name = "Активный")]
		public virtual bool IsActive {
			get { return isActive; }
			set { SetField (ref isActive, value, () => IsActive); }
		}

		private IList<Contact> contacts = new List<Contact>();

		[Display(Name = "Ответственные лица")]
		public virtual IList<Contact> Contacts
		{
			get { return contacts; }
			set { SetField(ref contacts, value, () => Contacts); }
		}

		private IList<ContactAndPhonesView> contactAndPhones = new List<ContactAndPhonesView>();

		[Display(Name = "Ответственные лица")]
		public virtual IList<ContactAndPhonesView> ContactAndPhones
		{
			get { return contactAndPhones; }
			set { SetField(ref contactAndPhones, value, () => ContactAndPhones); }
		}

		GenericObservableList<Contact> observableContacts;
		//FIXME Кослыль пока не разберемся как научить hibernate работать с обновляемыми списками.
		public virtual GenericObservableList<Contact> ObservableContacts {
			get {
				if (observableContacts == null)
					observableContacts = new GenericObservableList<Contact> (Contacts);
				return observableContacts;
			}
		}

		bool foundOnOsm;

		[Display (Name = "Адрес найден на карте OSM")]
		public virtual bool FoundOnOsm {
			get { return foundOnOsm; }
			set { SetField (ref foundOnOsm, value, () => FoundOnOsm); }
		}

		bool manualCoordinates;

		[Display (Name = "Ручные координаты")]
		public virtual bool ManualCoordinates {
			get { return manualCoordinates; }
			set { SetField (ref manualCoordinates, value, () => ManualCoordinates); }
		}

		bool isFixedInOsm;

		[Display (Name = "Исправлен в OSM")]
		public virtual bool IsFixedInOsm {
			get { return isFixedInOsm; }
			set { SetField (ref isFixedInOsm, value, () => IsFixedInOsm); }
		}

		Counterparty counterparty;

		[Required]
		[Display (Name = "Контрагент")]
		public virtual Counterparty Counterparty {
			get { return counterparty; }
			protected set { SetField (ref counterparty, value, () => Counterparty); }
		}

		#endregion

		#region Расчетные

		public virtual string СoordinatesText{
			get{
				if (Latitude == null || Longitude == null)
					return String.Empty;
				return String.Format("(ш. {0:F5}, д. {1:F5})", Latitude, Longitude);
			}
		}

		public virtual bool СoordinatesExist{
			get{
				return (Latitude != null && Longitude != null);
			}
		}

		public virtual string Title { 
			get { return String.IsNullOrWhiteSpace(CompiledAddress) ? "АДРЕС ПУСТОЙ" : CompiledAddress; }
		}

		#endregion

		public DeliveryPoint ()
		{
			City = String.Empty;
			Street = String.Empty;
			Building = String.Empty;
			Room = String.Empty;
			Comment = String.Empty;
		}

		#region IValidatableObject implementation

		public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if(String.IsNullOrWhiteSpace(АddressAddition) && (String.IsNullOrWhiteSpace(Street) || String.IsNullOrWhiteSpace(Building)))
			{
				yield return new ValidationResult (
					"У адреса должны быть заполены: поля улица и дом или поле с дополнительной информацией.",
					new[] { this.GetPropertyName (o => o.АddressAddition), this.GetPropertyName (o => o.Street), this.GetPropertyName (o => o.Building) });
			}
		}

		#endregion

		public virtual void AddContact(Contact contact)
		{
			if (Contacts.Any(x => x.Id == contact.Id))
				return;
			ObservableContacts.Add(contact);
		}

		public static IUnitOfWorkGeneric<DeliveryPoint> CreateUowForNew (Counterparty counterparty)
		{
			var uow = UnitOfWorkFactory.CreateWithNewRoot<DeliveryPoint> ();
			uow.Root.Counterparty = counterparty;
			return uow;
		}

		public static DeliveryPoint Create (Counterparty counterparty)
		{
			var point = new DeliveryPoint ();
			point.Counterparty = counterparty;
			counterparty.DeliveryPoints.Add(point);
			return point;
		}

	}

}

