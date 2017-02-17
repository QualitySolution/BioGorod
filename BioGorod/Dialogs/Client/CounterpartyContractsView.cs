using System;
using QSOrmProject;
using BioGorod.Domain.Client;
using QSTDI;
using BioGorod.ViewModel;

namespace BioGorod.Dialogs.Client
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class CounterpartyContractsView : WidgetOnDialogBase
	{
		private IUnitOfWorkGeneric<Counterparty> counterpartyUoW;

		public IUnitOfWorkGeneric<Counterparty> CounterpartyUoW {
			get {
				return counterpartyUoW;
			}
			set {
				if (counterpartyUoW == value)
					return;
				counterpartyUoW = value;
				treeCounterpartyContracts.RepresentationModel = new ViewModel.ContractsVM (value);
				treeCounterpartyContracts.RepresentationModel.UpdateNodes ();
			}
		}

		public CounterpartyContractsView ()
		{
			this.Build ();
			treeCounterpartyContracts.Selection.Changed += OnSelectionChanged;
			buttonAdd.ItemsEnum = typeof(ContractType);
		}

		void OnSelectionChanged (object sender, EventArgs e)
		{
			bool selected = treeCounterpartyContracts.Selection.CountSelectedRows () > 0;
			buttonEdit.Sensitive = buttonDelete.Sensitive = selected;
		}

		protected void OnButtonEditClicked (object sender, EventArgs e)
		{
			var selected = treeCounterpartyContracts.GetSelectedObject<ContractsVMNode>();
			ITdiDialog dlg = null;
			switch (selected.ContractType)
			{
				case ContractType.ShortLease:
					dlg = new ContractShortLeaseDlg (selected.Id);
					break;
				case ContractType.LongLease:
					dlg = new ContractLongLeaseDlg (selected.Id);
					break;

			}

			MyTab.TabParent.AddTab (dlg, MyTab);
		}

		protected void OnTreeCounterpartyContractsRowActivated (object o, Gtk.RowActivatedArgs args)
		{
			buttonEdit.Click ();
		}

		protected void OnButtonDeleteClicked (object sender, EventArgs e)
		{
			if (OrmMain.DeleteObject (typeof(Contract),
				treeCounterpartyContracts.GetSelectedId ())) {
				treeCounterpartyContracts.RepresentationModel.UpdateNodes ();
			}
		}

		protected void OnButtonAddEnumItemClicked(object sender, EnumItemClickedEventArgs e)
		{
			if (MyOrmDialog.UoW.IsNew) {
				if (CommonDialogs.SaveBeforeCreateSlaveEntity (MyOrmDialog.EntityObject.GetType (), typeof(Contract))) {
					MyOrmDialog.UoW.Save ();
				} else
					return;
			}
			ITdiDialog dlg = null;

			switch ((ContractType)e.ItemEnum)
			{
				case ContractType.ShortLease:
					dlg = new ContractShortLeaseDlg (CounterpartyUoW.Root);
					break;
				case ContractType.LongLease:
					dlg = new ContractLongLeaseDlg (CounterpartyUoW.Root);
					break;

			}

			MyTab.TabParent.AddTab (dlg, MyTab);
		}
	}
}

