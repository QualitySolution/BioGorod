using System;
using QSOrmProject;
using QSProjectsLib;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using BioGorod.Domain.Company;

namespace BioGorod.Domain.Client
{
	[OrmSubject (
		Gender = GrammaticalGender.Masculine,
		NominativePlural = "договоры контрагента",
		Nominative = "договор",
		Genitive = " договора",
		Accusative = "договор"
	)]
	public class CounterpartyContract : BusinessObjectBase<CounterpartyContract>, IDomainObject, IValidatableObject
	{
		#region Сохраняемые поля

		public virtual int Id { get; set; }

		int maxDelay;

		[Display (Name = "Максимальный срок отсрочки")]
		public virtual int MaxDelay {
			get { return maxDelay; }
			set { SetField (ref maxDelay, value, () => MaxDelay); }
		}

		bool isArchive;

		[Display (Name = "Архивный")]
		public virtual bool IsArchive {
			get { return isArchive; }
			set { SetField (ref isArchive, value, () => IsArchive); }
		}

		bool onCancellation;

		[Display (Name = "На расторжении")]
		public virtual bool OnCancellation {
			get { return onCancellation; }
			set { SetField (ref onCancellation, value, () => OnCancellation); }
		}

		[Display (Name = "Номер")]
		public virtual string Number { get { return Id > 0 ? Id.ToString () : "Не определен"; } set { } }

		DateTime issueDate;

		[Display (Name = "Дата подписания")]
		public virtual DateTime IssueDate {
			get { return issueDate; }
			set { SetField (ref issueDate, value, () => IssueDate); }
		}

		Organization organization;

		[Required(ErrorMessage = "Организация должна быть заполнена.")]
		[Display (Name = "Организация")]
		public virtual Organization Organization {
			get { return organization; }
			set { SetField (ref organization, value, () => Organization); }
		}

		Counterparty counterparty;

		[Required(ErrorMessage = "Контрагент должен быть указан.")]
		[Display (Name = "Контрагент")]
		public virtual Counterparty Counterparty {
			get { return counterparty; }
			protected set { SetField (ref counterparty, value, () => Counterparty); }
		}

/*		DocTemplate contractTemplate;

		[Display (Name = "Шаблон договора")]
		public virtual DocTemplate ContractTemplate {
			get { return contractTemplate; }
			protected set { SetField (ref contractTemplate, value, () => ContractTemplate); }
		}
*/
		byte[] changedTemplateFile;

		[Display (Name = "Измененный договор")]
		//[PropertyChangedAlso("FileSize")]
		public virtual byte[] ChangedTemplateFile {
			get { return changedTemplateFile; }
			set { SetField (ref changedTemplateFile, value, () => ChangedTemplateFile); }
		}

		#endregion

		public virtual string Title { 
			get { return String.Format ("Договор №{0} от {1:d}", Id, IssueDate); }
		}

		#region IValidatableObject implementation

		public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
/*			if (!IsArchive && !OnCancellation)
			{
				var contracts = Repository.CounterpartyContractRepository.GetActiveContractsWithOrganization(UoW, Counterparty, Organization);
				if (contracts.Any(c => c.Id != Id))
					yield return new ValidationResult(
						String.Format("У контрагента '{0}' уже есть активный договор с организацией '{1}'", Counterparty.Name, Organization.Name),
						new[] { this.GetPropertyName(o => o.Organization) });
			}
*/		return null;
		}

		#endregion

		//Конструкторы
		public static IUnitOfWorkGeneric<CounterpartyContract> Create (Counterparty counterparty)
		{
			var uow = UnitOfWorkFactory.CreateWithNewRoot<CounterpartyContract> ();
			uow.Root.Counterparty = counterparty;
			return uow;
		}

		#region Функции

		public virtual void UpdateContractTemplate(IUnitOfWork uow)
		{
/*			if (Organization == null)
			{
				ContractTemplate = null;
				ChangedTemplateFile = null;
			}
			else
			{
				var newTemplate = Repository.Client.DocTemplateRepository.GetTemplate(uow, TemplateType.Contract, Organization);
				if(!DomainHelper.EqualDomainObjects(newTemplate, ContractTemplate))
				{
					ContractTemplate = newTemplate;
					ChangedTemplateFile = null;
				}
			}
*/		}

		#endregion
	}

	public interface IContractSaved
	{
		event EventHandler<ContractSavedEventArgs> ContractSaved;
	}

	public class ContractSavedEventArgs : EventArgs
	{
		public CounterpartyContract Contract { get; private set; }

		public ContractSavedEventArgs (CounterpartyContract contract)
		{
			Contract = contract;
		}
	}
}

