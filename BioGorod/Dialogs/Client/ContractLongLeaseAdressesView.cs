using System;
using System.Collections.Generic;
using System.Data.Bindings.Collections.Generic;
using System.Linq;
using BioGorod.Domain.Client;
using Gamma.GtkWidgets;
using Gtk;
using QSOrmProject;
using QSProjectsLib;

namespace BioGorod.Dialogs.Client
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ContractLongLeaseAdressesView : WidgetOnDialogBase
	{
		public DateTime? SinceDate { get; private set;}
		private bool userChangeDate = false;
		private List<ContractLongLeaseAddress> addresses;

		bool canEdit;

		public bool CanEdit
		{
			get
			{
				return canEdit;
			}
			set
			{
				canEdit = value;
				buttonAdd.Sensitive = buttonDelete.Sensitive = buttonNewDate.Sensitive = CanEdit;
			}
		}

		public ContractLongLeaseAdressesView(IUnitOfWorkGeneric<ContractLongLease> contractUow, DateTime? sinceDate)
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

			SinceDate = sinceDate;
			ContractUoW = contractUow;

			ydateSinceDate.IsEditable = buttonDeleteDate.Sensitive = SinceDate.HasValue;
			ydateSinceDate.Date = SinceDate.HasValue ? SinceDate.Value : ContractUoW.Root.IssueDate;
			userChangeDate = true;
		}

		void YtreeviewAddresses_Selection_Changed (object sender, EventArgs e)
		{
			var selected = ytreeviewAddresses.GetSelectedObject<ContractLongLeaseAddress>();
			buttonDelete.Sensitive = selected != null && CanEdit;
		}

		private IUnitOfWorkGeneric<ContractLongLease> contractUoW;

		public IUnitOfWorkGeneric<ContractLongLease> ContractUoW {
			get { return contractUoW; }
			private set {
				if (contractUoW == value)
					return;
				contractUoW = value;
				addresses = ContractUoW.Root.GetAddressesAtDate(SinceDate);
				ytreeviewAddresses.ItemsDataSource = new GenericObservableList<ContractLongLeaseAddress> (addresses);
				if (ContractUoW.Root.ChangesDates.Any())
					CanEdit = ContractUoW.Root.ChangesDates.Max() == SinceDate;
				else
					CanEdit = true;
				Contract.AddressesChanged += Contract_AddressesChanged;
			}
		}

		void Contract_AddressesChanged (object sender, AddressesChangedEventArgs e)
		{
			if(e.AtDate == SinceDate)
			{
				addresses = ContractUoW.Root.GetAddressesAtDate(SinceDate);
				ytreeviewAddresses.ItemsDataSource = new GenericObservableList<ContractLongLeaseAddress> (addresses);
			}
		}

		public ContractLongLease Contract{
			get{ return ContractUoW.Root;}
		}

		protected void OnButtonDeleteClicked(object sender, EventArgs e)
		{
			Contract.RemoveAddress (ytreeviewAddresses.GetSelectedObject<ContractLongLeaseAddress>());
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

		protected void OnButtonNewDateClicked(object sender, EventArgs e)
		{
			var dlg = MyOrmDialog as ContractLongLeaseDlg;
			dlg.NewAddressesDate();
			CanEdit = false;
		}

		protected void OnYdateSinceDateDateChanged(object sender, EventArgs e)
		{
			if (!userChangeDate)
				return;
			if(ContractUoW.Root.ChangesDates.Contains(ydateSinceDate.Date))
			{
				MessageDialogWorks.RunErrorDialog("На {0:d} уже имеются условия. Перенос текущих условий на эту дату невозможен.", ydateSinceDate.Date);
				ydateSinceDate.Date = SinceDate.Value;
				return;
			}

			SinceDate = ydateSinceDate.Date;
			addresses.ForEach(x => x.StartAt = SinceDate);
			var dlg = MyOrmDialog as ContractLongLeaseDlg;
			dlg.UpdateTabLabel(this, SinceDate.Value);
		}

		protected void OnButtonDeleteDateClicked(object sender, EventArgs e)
		{
			addresses.ForEach(x => Contract.Addresses.Remove(x));
			var dlg = MyOrmDialog as ContractLongLeaseDlg;
			dlg.RemoveTab(this);
		}
	}
}

