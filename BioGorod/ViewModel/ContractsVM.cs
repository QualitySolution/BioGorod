using System;
using QSOrmProject.RepresentationModel;
using BioGorod.Domain.Client;
using QSOrmProject;
using BioGorod.Domain.Company;
using Gamma.Utilities;
using NHibernate.Transform;
using Gamma.ColumnConfig;
using Gtk;

namespace BioGorod.ViewModel
{
	public class ContractsVM : RepresentationModelEntitySubscribingBase<Contract, ContractsVMNode>, IRepresentationModelWithParent
	{
		public IUnitOfWorkGeneric<Counterparty> CounterpartyUoW {
			get {
				return UoW as IUnitOfWorkGeneric<Counterparty>;
			}
		}

		Counterparty counterparty;

		public Counterparty Counterparty {
			get {
				if (CounterpartyUoW != null)
					return CounterpartyUoW.Root;
				else
					return counterparty;
			}
			private set {
				counterparty = value;
			}
		}

		#region IRepresentationModelWithParent implementation

		public object GetParent
		{
			get
			{
				return Counterparty;
			}
		}

		#endregion

		#region IRepresentationModel implementation

		public override void UpdateNodes ()
		{

			Contract contractAlias = null;
			Counterparty counterpartyAlias = null;
			Organization organizationAlias = null;
			ContractsVMNode resultAlias = null;

//			var subquery = NHibernate.Criterion.QueryOver.Of<AdditionalAgreement>(() => agreementAlias)
//				.Where(() => agreementAlias.Contract.Id == contractAlias.Id)
//				.ToRowCountQuery();

			var contractslist = UoW.Session.QueryOver<Contract> (() => contractAlias)
				.JoinAlias (c => c.Counterparty, () => counterpartyAlias)
				.JoinAlias (c => c.Organization, () => organizationAlias)
				.Where (() => counterpartyAlias.Id == Counterparty.Id)
				.SelectList(list => list
					.Select(() => contractAlias.Id).WithAlias(() => resultAlias.Id)
					.Select(() => contractAlias.Number).WithAlias(() => resultAlias.Number)
					.Select(() => contractAlias.IssueDate).WithAlias(() => resultAlias.IssueDate)
					.Select(() => contractAlias.IsArchive).WithAlias(() => resultAlias.IsArchive)
					.Select(() => organizationAlias.Name).WithAlias(() => resultAlias.Organization)
					.Select(() => contractAlias.GetType()).WithAlias(() => resultAlias.TypeString)
				)
				.TransformUsing(Transformers.AliasToBean<ContractsVMNode>())
				.List<ContractsVMNode>();

			SetItemsSource (contractslist);
		}

		IColumnsConfig columnsConfig = FluentColumnsConfig <ContractsVMNode>.Create ()
			.AddColumn("Номер").SetDataProperty (node => node.Title)
			.AddColumn("Тип договора").AddTextRenderer(x => x.TypeTitle)
			.AddColumn ("Организация").SetDataProperty (node => node.Organization)
			//.AddColumn ("Кол-во доп. соглашений").SetDataProperty (node => node.AdditionalAgreements)
			.RowCells ().AddSetter<CellRendererText> ((c, n) => c.Foreground = n.RowColor)
			.Finish ();

		public override IColumnsConfig ColumnsConfig {
			get { return columnsConfig; }
		}

		#endregion

		#region implemented abstract members of RepresentationModelBase

		protected override bool NeedUpdateFunc (Contract updatedSubject)
		{
			return Counterparty.Id == updatedSubject.Counterparty.Id;
		}

		#endregion

		#region implemented abstract members of RepresentationModelEntitySubscribingBase

		protected override bool NeedUpdateFunc(object updatedSubject)
		{
			var contract = updatedSubject as Contract;
			return Counterparty.Id == contract.Counterparty.Id;
		}

		#endregion

		public ContractsVM (IUnitOfWorkGeneric<Counterparty> uow) : base(
			typeof(ContractLongLease), 
			typeof(ContractShortLease), 
			typeof(ContractMaintenance))
		{
			this.UoW = uow;
		}

		public ContractsVM (IUnitOfWork uow, Counterparty counterparty) : base(
				typeof(ContractLongLease), 
				typeof(ContractShortLease), 
				typeof(ContractMaintenance))
		{
			UoW = uow;
			Counterparty = counterparty;
		}
	}

	public class ContractsVMNode
	{

		public int Id{ get; set;}

		public DateTime IssueDate{ get; set;}

		public int Number{ get; set;}

		public bool IsArchive{ get; set;}

		public string Title {
			get { return String.Format ("{0} от {1:d}", Number, IssueDate); }
		}

		public string Organization { get; set;}

		public string RowColor {
			get {
				if (IsArchive)
					return "grey";
				return "black";

			}
		}

		public ContractType ContractType
		{
			get
			{
				ContractType type;
				Enum.TryParse(TypeString, out type);
				return type;
			}
		}

		public string TypeString { get; set; }

		public string TypeTitle {
			get {
				return ContractType.GetEnumTitle();
			}
		}

	}
}

