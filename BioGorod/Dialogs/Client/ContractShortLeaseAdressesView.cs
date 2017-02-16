using System;
using System.Collections.Generic;
using BioGorod.Domain.Client;
using Gamma.GtkWidgets;
using QSOrmProject;

namespace BioGorod.Dialogs.Client
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ContractShortLeaseAdressesView : WidgetOnDialogBase
	{
		public ContractShortLeaseAdressesView()
		{
			this.Build();

			ytreeviewAddresses.ColumnsConfig = ColumnsConfigFactory.Create<ContractShortLeaseAddress>()
				.AddColumn("Адрес").AddTextRenderer(x => x.DeliveryPoint.CompiledAddress)
				.Finish();

			ytreeviewAddresses.Selection.Changed += YtreeviewAddresses_Selection_Changed;

		}

		void YtreeviewAddresses_Selection_Changed (object sender, EventArgs e)
		{
			var selected = ytreeviewAddresses.GetSelectedObject<ContractShortLeaseAddress>();
			buttonDelete.Sensitive = selected != null;
		}

		private IUnitOfWorkGeneric<ContractShortLease> contractUoW;

		public IUnitOfWorkGeneric<ContractShortLease> ContractUoW {
			get { return contractUoW; }
			set {
				if (contractUoW == value)
					return;
				contractUoW = value;
				if (ContractUoW.Root.Addresses == null)
					ContractUoW.Root.Addresses = new List<ContractShortLeaseAddress> ();

				ytreeviewAddresses.ItemsDataSource = ContractUoW.Root.ObservableAddresses;
			}
		}

		protected void OnButtonDeleteClicked(object sender, EventArgs e)
		{
			ContractUoW.Root.ObservableAddresses.Remove (ytreeviewAddresses.GetSelectedObject<ContractShortLeaseAddress>());
		}

		protected void OnButtonAddClicked(object sender, EventArgs e)
		{
			var view = new ViewModel.ClientDeliveryPointsVM (ContractUoW, ContractUoW.Root.Counterparty);
			var dlg = new ReferenceRepresentation(view);
			dlg.ObjectSelected += Dlg_ObjectSelected;
			dlg.Mode = OrmReferenceMode.Select;
			MyTab.TabParent.AddSlaveTab(MyTab, dlg);
		}

		void Dlg_ObjectSelected (object sender, ReferenceRepresentationSelectedEventArgs e)
		{
			var point = ContractUoW.GetById<DeliveryPoint>(e.ObjectId);
			ContractUoW.Root.AddAddress(point);
		}
	}
}

