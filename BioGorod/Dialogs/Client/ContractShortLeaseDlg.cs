using System;
using BioGorod.Domain.Client;
using QSOrmProject;
using QSValidation;
using BioGorod.Domain.Company;

namespace BioGorod.Dialogs.Client
{
	public partial class ContractShortLeaseDlg : OrmGtkDialogBase<ContractShortLease>
	{
		protected static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();

		public ContractShortLeaseDlg(Counterparty counterparty)
		{
			this.Build();
			UoWGeneric = Contract.Create<ContractShortLease> (counterparty);
			ConfigureDlg ();
		}

		public ContractShortLeaseDlg (ContractShortLease sub) : this (sub.Id){}

		public ContractShortLeaseDlg (int id)
		{
			this.Build ();
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<ContractShortLease> (id);
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
			ycheckDispenser.Binding.AddBinding(Entity, e => e.WaterDispenser, w => w.Active).InitializeFromSource();
			ycheckAdditionalWater.Binding.AddBinding(Entity, e => e.AdditionalWater, w => w.Active).InitializeFromSource();

			ydateDelivery.Binding.AddBinding(Entity, e => e.DeliveryTime, w => w.Date).InitializeFromSource();
			ydateRemoval.Binding.AddBinding(Entity, e => e.RemovalTime, w => w.Date).InitializeFromSource();

			yspinCabineCount.Binding.AddBinding(Entity, e => e.CabineCount, w => w.ValueAsInt).InitializeFromSource();
			yspinCabineCost.Binding.AddBinding(Entity, e => e.CabineCost, w => w.ValueAsDecimal).InitializeFromSource();
			yspinDeliveryCost.Binding.AddBinding(Entity, e => e.DeliveryCost, w => w.ValueAsDecimal).InitializeFromSource();

			ylabelTotalCost.Binding.AddFuncBinding(Entity, e => String.Format("{0:C}", e.TotalCost), w => w.LabelProp).InitializeFromSource();

			ytextAdditionalInfo.Binding.AddBinding(Entity, e => e.AdditionalInfo, w => w.Buffer.Text).InitializeFromSource();

			contractshortleaseadressesview1.ContractUoW = UoWGeneric;
		}

		public override bool Save ()
		{
			var valid = new QSValidator<ContractShortLease> (UoWGeneric.Root);
			if (valid.RunDlgIfNotValid ((Gtk.Window)this.Toplevel))
				return false;

			Entity.CreateContractNumber<ContractShortLease>();

			logger.Info ("Сохраняем договор...");
			UoWGeneric.Save ();
			logger.Info ("Ok");
			return true;
		}

	}
}

