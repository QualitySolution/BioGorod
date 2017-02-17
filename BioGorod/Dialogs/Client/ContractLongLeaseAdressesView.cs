using System;
using QSOrmProject;
using BioGorod.Domain.Client;
using Gamma.GtkWidgets;
using System.Collections.Generic;
using Gtk;

namespace BioGorod.Dialogs.Client
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ContractLongLeaseAdressesView : WidgetOnDialogBase
	{
		public ContractLongLeaseAdressesView()
		{
			this.Build();

			ytreeviewAddresses.ColumnsConfig = ColumnsConfigFactory.Create<ContractLongLeaseAddress>()
				.AddColumn("Адрес").AddTextRenderer(x => x.DeliveryPoint.CompiledAddress)
				.AddColumn("Кабинки")
				.AddColumn("Количество ТО")
					.AddNumericRenderer(x => x.MaintenanceCount).Editing()
					.Adjustment(new Adjustment(1, 1, 4, 1, 1, 1))
				.AddColumn("Стоим. кабины(Стд)")
					.AddNumericRenderer(x => x.CabineStdCost).Editing()
					.Adjustment(new Adjustment(0, 0, 1000000, 100, 1000, 1))
				.AddColumn("Стоим. кабины(Зим)")
					.AddNumericRenderer(x => x.CabineWinterCost).Editing()
					.Adjustment(new Adjustment(0, 0, 1000000, 100, 1000, 1))
				.AddColumn("Стоим. доп. ТО(Стд)")
					.AddNumericRenderer(x => x.AdditionalServiceStdCost).Editing()
					.Adjustment(new Adjustment(0, 0, 1000000, 100, 1000, 1))
				.AddColumn("Стоим. доп. ТО(Зим)")
					.AddNumericRenderer(x => x.AdditionalServiceWinterCost).Editing()
					.Adjustment(new Adjustment(0, 0, 1000000, 100, 1000, 1))

				.Finish();

			ytreeviewAddresses.Selection.Changed += YtreeviewAddresses_Selection_Changed;

		}

		void YtreeviewAddresses_Selection_Changed (object sender, EventArgs e)
		{
			var selected = ytreeviewAddresses.GetSelectedObject<ContractShortLeaseAddress>();
			buttonDelete.Sensitive = selected != null;
		}

		private IUnitOfWorkGeneric<ContractLongLease> contractUoW;

		public IUnitOfWorkGeneric<ContractLongLease> ContractUoW {
			get { return contractUoW; }
			set {
				if (contractUoW == value)
					return;
				contractUoW = value;
				if (ContractUoW.Root.Addresses == null)
					ContractUoW.Root.Addresses = new List<ContractLongLeaseAddress> ();

				ytreeviewAddresses.ItemsDataSource = ContractUoW.Root.ObservableAddresses;
			}
		}

		protected void OnButtonDeleteClicked(object sender, EventArgs e)
		{
			ContractUoW.Root.ObservableAddresses.Remove (ytreeviewAddresses.GetSelectedObject<ContractLongLeaseAddress>());
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

