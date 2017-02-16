using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BioGorod.Domain.Company;
using QSOrmProject;
using QSProjectsLib;
using NHibernate.Criterion;

namespace BioGorod.Domain.Client
{
	[OrmSubject (
		Gender = GrammaticalGender.Masculine,
		NominativePlural = "договоры контрагента",
		Nominative = "договор",
		Genitive = " договора",
		Accusative = "договор"
	)]
	public class Contract : BusinessObjectBase<Contract>, IDomainObject//, IValidatableObject
	{
		#region Сохраняемые поля

		public virtual int Id { get; set; }

		bool isArchive;

		[Display (Name = "Архивный")]
		public virtual bool IsArchive {
			get { return isArchive; }
			set { SetField (ref isArchive, value, () => IsArchive); }
		}

		private int number;

		[Display (Name = "Номер")]
		public virtual int Number {
		    get { return number; }
		    set { SetField (ref number, value, () => Number); }
		}

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

		private bool haveOriginal;

		[Display (Name = "Есть оригиналы")]
		public virtual bool HaveOriginal {
		    get { return haveOriginal; }
		    set { SetField (ref haveOriginal, value, () => HaveOriginal); }
		}

		private bool haveScanned;

		[Display (Name = "Есть сканы")]
		public virtual bool HaveScanned {
		    get { return haveScanned; }
		    set { SetField (ref haveScanned, value, () => HaveScanned); }
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
			get { 
				var att = this.GetType().GetCustomAttributes(typeof(OrmSubjectAttribute), false);
				var name = StringWorks.StringToTitleCase((att[0] as OrmSubjectAttribute).Nominative);
				return String.Format ("{0} №{1} от {2:d}", name, Number, IssueDate); }
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
		public static IUnitOfWorkGeneric<TContract> Create<TContract> (Counterparty counterparty) where TContract : Contract, new()
		{
			var uow = UnitOfWorkFactory.CreateWithNewRoot<TContract> ();
			uow.Root.Counterparty = counterparty;
			uow.Root.Organization = uow.Session.QueryOver<Organization>().Take(1).SingleOrDefault();
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

		public virtual void CreateContractNumber<TContract>() where TContract : Contract
		{
			if (Number > 0)
				return;

			int lastNumber = UoW.Session.QueryOver<TContract>()
				.Select(Projections.Max<TContract>(c => c.Number))
				.SingleOrDefault<int>();
			Number = lastNumber + 1;
		}

		#endregion
	}

	public enum ContractType{
		[Display(Name="Долгосрочная аренда")]
		LongLease,
		[Display(Name="Короткосрочная аренда")]
		ShortLease,
		[Display(Name="Обслуживание")]
		Maintenance,
	}
}

