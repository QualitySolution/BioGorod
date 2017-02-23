using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Bindings.Collections.Generic;
using System.Text.RegularExpressions;
using BioGorod.Domain.Company;
using Gamma.Utilities;
using QSContacts;
using QSOrmProject;
using QSProjectsLib;
using QSOsm.Data;

namespace BioGorod.Domain.Client
{
	[OrmSubject (Gender = GrammaticalGender.Masculine,
		NominativePlural = "контрагенты",
		Nominative = "контрагент",
		Accusative = "контрагента",
		Genitive = "контрагента"
	)]
	public class Counterparty : QSBanks.AccountOwnerBase, IDomainObject, IValidatableObject
	{
		//Используется для валидации, не получается истолльзовать бизнес объект так как наследуемся от AccountOwnerBase
		public virtual IUnitOfWork UoW { get; set;}

		#region Свойства

		private IList<Contract> counterpartyContracts;

		[Display (Name = "Договоры")]
		public virtual IList<Contract> CounterpartyContracts {
			get { return counterpartyContracts; }
			set { SetField (ref counterpartyContracts, value, () => CounterpartyContracts); }
		}

		private IList<DeliveryPoint> deliveryPoints = new List<DeliveryPoint>();

		[Display (Name = "Точки доставки")]
		public virtual IList<DeliveryPoint> DeliveryPoints {
			get { return deliveryPoints; }
			set { SetField (ref deliveryPoints, value, () => DeliveryPoints); }
		}

		GenericObservableList<DeliveryPoint> observableDeliveryPoints;
		//FIXME Кослыль пока не разберемся как научить hibernate работать с обновляемыми списками.
		public virtual GenericObservableList<DeliveryPoint> ObservableDeliveryPoints {
			get {
				if (observableDeliveryPoints == null)
					observableDeliveryPoints = new GenericObservableList<DeliveryPoint> (DeliveryPoints);
				return observableDeliveryPoints;
			}
		}

		private IList<Contact> contact = new List<Contact> ();

		[Display (Name = "Контактные лица")]
		public virtual IList<Contact> Contacts {
			get { return contact; }
			set { SetField (ref contact, value, () => Contacts); }
		}

		public virtual int Id { get; set; }

		string name;

		[Required (ErrorMessage = "Название контрагента должно быть заполнено.")]
		[Display (Name = "Название")]
		public virtual string Name {
			get { return name; }
			set { 
				SetField(ref name, value, () => Name);
			}
		}

		string fullName;

		[Display (Name = "Полное название")]
		public virtual string FullName {
			get { return fullName; }
			set { SetField (ref fullName, value, () => FullName); }
		}

		string code1c;

		public virtual string Code1c {
			get { return code1c; }
			set { SetField (ref code1c, value, () => Code1c); }
		}

		string comment;

		[Display (Name = "Комментарий")]
		public virtual string Comment {
			get { return comment; }
			set { SetField (ref comment, value, () => Comment); }
		}

		string iNN;

		[Display (Name = "ИНН")]
		public virtual string INN {
			get { return iNN; }
			set { SetField (ref iNN, value, () => INN); }
		}

		string kPP;

		[Display (Name = "КПП")]
		public virtual string KPP {
			get { return kPP; }
			set { SetField (ref kPP, value, () => KPP); }
		}

		string ogrn;

		[Display (Name = "ОГРН")]
		public virtual string OGRN {
			get { return ogrn; }
			set { SetField (ref ogrn, value, () => OGRN); }
		}

		JsonAddress legalAddress = new JsonAddress();

		[Display (Name = "Юридический адрес")]
		public virtual JsonAddress LegalAddress {
			get { return legalAddress; }
			set { SetField (ref legalAddress, value, () => LegalAddress); }
		}

		JsonAddress actualAddress = new JsonAddress();

		[Display (Name = "Фактический адрес")]
		public virtual JsonAddress ActualAddress {
			get { return actualAddress; }
			set { SetField (ref actualAddress, value, () => ActualAddress); }
		}

		JsonAddress docDeliveryAddress = new JsonAddress();

		[Display (Name = "Адрес доставки документов")]
		public virtual JsonAddress DocDeliveryAddress {
			get { return docDeliveryAddress; }
			set { SetField (ref docDeliveryAddress, value, () => DocDeliveryAddress); }
		}

		DocumentsDelivery documentsDelivery;

		[Display (Name = "Отправка документов")]
		public virtual DocumentsDelivery DocumentsDelivery {
			get { return documentsDelivery; }
			set { SetField (ref documentsDelivery, value, () => DocumentsDelivery); }
		}

		bool cooperationCustomer = true;

		[Display (Name = "Это покупатель")]
		public virtual bool CooperationCustomer {
			get { return cooperationCustomer; }
			set { SetField (ref cooperationCustomer, value, () => CooperationCustomer); }
		}

		bool cooperationSupplier;

		[Display (Name = "Это поставщик")]
		public virtual bool CooperationSupplier {
			get { return cooperationSupplier; }
			set { SetField (ref cooperationSupplier, value, () => CooperationSupplier); }
		}

		bool cooperationPartner;

		[Display (Name = "Это партнер")]
		public virtual bool CooperationPartner {
			get { return cooperationPartner; }
			set { SetField (ref cooperationPartner, value, () => CooperationPartner); }
		}

		bool isArchive;

		[Display (Name = "Архивный")]
		public virtual bool IsArchive {
			get { return isArchive; }
			set { SetField (ref isArchive, value, () => IsArchive); }
		}

		private bool haveArbitration;

		[Display (Name = "Есть арбитражные дела")]
		public virtual bool HaveArbitration {
		    get { return haveArbitration; }
		    set { SetField (ref haveArbitration, value, () => HaveArbitration); }
		}

		private bool requirePrepayment;

		[Display (Name = "Предоплата обязательна")]
		public virtual bool RequirePrepayment {
		    get { return requirePrepayment; }
		    set { SetField (ref requirePrepayment, value, () => RequirePrepayment); }
		}

		IList<Phone> phones;

		[Display (Name = "Телефоны")]
		public virtual IList<Phone> Phones {
			get { return phones; }
			set { SetField (ref phones, value, () => Phones); }
		}

		IList<Email> emails;

		[Display (Name = "E-mail адреса")]
		public virtual IList<Email> Emails {
			get { return emails; }
			set { SetField (ref emails, value, () => Emails); }
		}

		Employee paymentManager;

		[Display (Name = "Менеджер по контролю оплаты")]
		public virtual Employee PaymentManager {
			get { return paymentManager; }
			set { SetField (ref paymentManager, value, () => PaymentManager); }
		}

		string signatoryFIO;

		[Display (Name = "ФИО подписанта")]
		public virtual string SignatoryFIO {
			get { return signatoryFIO; }
			set { SetField (ref signatoryFIO, value, () => SignatoryFIO); }
		}

		string signatoryPost;

		[Display (Name = "Должность подписанта")]
		public virtual string SignatoryPost {
			get { return signatoryPost; }
			set { SetField (ref signatoryPost, value, () => SignatoryPost); }
		}

		string signatoryBaseOf;

		[Display (Name = "На основании")]
		public virtual string SignatoryBaseOf {
			get { return signatoryBaseOf; }
			set { SetField (ref signatoryBaseOf, value, () => SignatoryBaseOf); }
		}

		#endregion

		public Counterparty ()
		{
			
		}

		#region IValidatableObject implementation

		public virtual IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
		{
			if (!String.IsNullOrWhiteSpace(KPP))
			{
				if(KPP.Length != 9)
					yield return new ValidationResult ("Длина КПП должна равнятся 9-ти.",
						new[] { this.GetPropertyName (o => o.KPP) });
				if (!Regex.IsMatch (KPP, "^[0-9]*$"))
					yield return new ValidationResult ("КПП может содержать только цифры.",
						new[] { this.GetPropertyName (o => o.KPP) });
			}
			if (!String.IsNullOrWhiteSpace(INN))
			{
				if(INN.Length != 10)
					yield return new ValidationResult ("Длина ИНН должна равнятся 10-ти.",
						new[] { this.GetPropertyName (o => o.INN) });
				if (!Regex.IsMatch (INN, "^[0-9]*$"))
					yield return new ValidationResult ("ИНН может содержать только цифры.",
						new[] { this.GetPropertyName (o => o.INN) });
			}
			if (!String.IsNullOrWhiteSpace(OGRN))
			{
				if(OGRN.Length != 13)
					yield return new ValidationResult ("Длина ОГРН должна равнятся 13-ти.",
						new[] { this.GetPropertyName (o => o.OGRN) });
				if (!Regex.IsMatch (OGRN, "^[0-9]*$"))
					yield return new ValidationResult ("ОГРН может содержать только цифры.",
								new[] { this.GetPropertyName (o => o.OGRN) });
			}

/*				if (String.IsNullOrWhiteSpace (KPP))
					yield return new ValidationResult ("Для организации необходимо заполнить КПП.",
						new[] { this.GetPropertyName (o => o.KPP) });
				if (String.IsNullOrWhiteSpace (INN))
					yield return new ValidationResult ("Для организации необходимо заполнить ИНН.",
						new[] { this.GetPropertyName (o => o.INN) });
*/				

			if(IsArchive)
			{
/*				var unclosedContracts = CounterpartyContracts.Where(c => !c.IsArchive)
					.Select(c => c.Id.ToString()).ToList();
				if(unclosedContracts.Count > 0)
					yield return new ValidationResult (
						String.Format("Вы не можете сдать контрагента в архив с открытыми договорами: {0}", String.Join(", ", unclosedContracts)),
						new[] { this.GetPropertyName (o => o.CounterpartyContracts) });
*/
			}
		}

		#endregion
	}

	public enum DocumentsDelivery
	{
		[Display 	 (Name = "По почте")]
		ByPost,
		[Display 	 (Name = "Курьером")]
		ByCourier,
		[Display 	 (Name = "Сами заберут")]
		SelfDelivery,
	}

	public class DocumentsDeliveryStringType : NHibernate.Type.EnumStringType
	{
		public DocumentsDeliveryStringType () : base (typeof(DocumentsDelivery))
		{
		}
	}
}

