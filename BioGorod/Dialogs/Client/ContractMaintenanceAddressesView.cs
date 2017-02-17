using System;
using QSOrmProject;
using Gamma.GtkWidgets;
using BioGorod.Domain.Client;
using Gtk;
using System.Collections.Generic;

namespace BioGorod.Dialogs.Client
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ContractMaintenanceAddressesView : WidgetOnDialogBase
	{
		public ContractMaintenanceAddressesView()
		{
			this.Build();

			ytreeviewAddresses.ColumnsConfig = ColumnsConfigFactory.Create<ContractMaintenanceAddress>()
				.AddColumn("Адрес").AddTextRenderer(x => x.DeliveryPoint.CompiledAddress)
				.AddColumn("Кол. кабин")
				.AddNumericRenderer(x => x.CabineCount).Editing()
				.Adjustment(new Adjustment(1, 1, 100, 1, 1, 1))
				.AddColumn("Количество ТО")
				.AddNumericRenderer(x => x.MaintenanceCount).Editing()
				.Adjustment(new Adjustment(1, 1, 4, 1, 1, 1))
				.AddColumn("Стоим. план. ТО(Стд)")
				.AddNumericRenderer(x => x.MaintenanceStdCost).Editing()
				.Adjustment(new Adjustment(0, 0, 1000000, 100, 1000, 1))
				.AddColumn("Стоим. план. ТО(Зим)")
				.AddNumericRenderer(x => x.MaintenanceWinterCost).Editing()
				.Adjustment(new Adjustment(0, 0, 1000000, 100, 1000, 1))
				.AddColumn("Стоим. доп. ТО(Стд)")
				.AddNumericRenderer(x => x.AdditionalMaintenanceStdCost).Editing()
				.Adjustment(new Adjustment(0, 0, 1000000, 100, 1000, 1))
				.AddColumn("Стоим. доп. ТО(Зим)")
				.AddNumericRenderer(x => x.AdditionalMaintenanceWinterCost).Editing()
				.Adjustment(new Adjustment(0, 0, 1000000, 100, 1000, 1))
				.AddColumn("Информация о кабинах")
				.AddTextRenderer(x => x.Info).Editable()
				.Finish();

			ytreeviewAddresses.Selection.Changed += YtreeviewAddresses_Selection_Changed;

		}

		void YtreeviewAddresses_Selection_Changed (object sender, EventArgs e)
		{
			var selected = ytreeviewAddresses.GetSelectedObject<ContractMaintenanceAddress>();
			buttonDelete.Sensitive = selected != null;
		}

		private IUnitOfWorkGeneric<ContractMaintenance> contractUoW;

		public IUnitOfWorkGeneric<ContractMaintenance> ContractUoW {
			get { return contractUoW; }
			set {
				if (contractUoW == value)
					return;
				contractUoW = value;
				if (ContractUoW.Root.Addresses == null)
					ContractUoW.Root.Addresses = new List<ContractMaintenanceAddress> ();

				ytreeviewAddresses.ItemsDataSource = ContractUoW.Root.ObservableAddresses;
			}
		}

		protected void OnButtonDeleteClicked(object sender, EventArgs e)
		{
			ContractUoW.Root.ObservableAddresses.Remove (ytreeviewAddresses.GetSelectedObject<ContractMaintenanceAddress>());
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

