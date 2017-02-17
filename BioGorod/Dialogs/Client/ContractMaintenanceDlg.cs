using System;
using BioGorod.Domain.Client;
using QSOrmProject;
using QSValidation;
using BioGorod.Domain.Company;

namespace BioGorod.Dialogs.Client
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ContractMaintenanceDlg : OrmGtkDialogBase<ContractMaintenance>
	{
		protected static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();

		public ContractMaintenanceDlg(Counterparty counterparty)
		{
			this.Build();
			UoWGeneric = Contract.Create<ContractMaintenance> (counterparty);
			ConfigureDlg ();
		}

		public ContractMaintenanceDlg (ContractShortLease sub) : this (sub.Id){}

		public ContractMaintenanceDlg (int id)
		{
			this.Build ();
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<ContractMaintenance> (id);
			ConfigureDlg ();
		}


		void ConfigureDlg ()
		{
			ydateIssue.Binding.AddBinding(Entity, e => e.IssueDate, w => w.Date).InitializeFromSource();

			ylabelNumber.Binding.AddBinding(Entity, e => e.Number, w => w.LabelProp, new IdToStringConverter()).InitializeFromSource();

			yentryreferenceCounterparty.RepresentationModel = new ViewModel.CounterpartyVM(UoW);
			yentryreferenceCounterparty.IsEditable = false;
			yentryreferenceCounterparty.Binding.AddBinding(Entity, e => e.Counterparty, w => w.Subject).InitializeFromSource();
			yentryreferenceOrg.SubjectType = typeof(Organization);
			yentryreferenceOrg.Binding.AddBinding(Entity, e => e.Organization, w => w.Subject).InitializeFromSource();

			ycheckArchive.Binding.AddBinding(Entity, e => e.IsArchive, w => w.Active).InitializeFromSource();
			ycheckOrigin.Binding.AddBinding(Entity, e => e.HaveOriginal, w => w.Active).InitializeFromSource();
			ycheckScanned.Binding.AddBinding(Entity, e => e.HaveScanned, w => w.Active).InitializeFromSource();

			contractmaintenanceaddressesview1.ContractUoW = UoWGeneric;
		}

		public override bool Save ()
		{
			var valid = new QSValidator<ContractMaintenance> (UoWGeneric.Root);
			if (valid.RunDlgIfNotValid ((Gtk.Window)this.Toplevel))
				return false;

			Entity.CreateContractNumber<ContractMaintenance>();

			logger.Info ("Сохраняем договор...");
			UoWGeneric.Save ();
			logger.Info ("Ok");
			return true;
		}
	}
}

