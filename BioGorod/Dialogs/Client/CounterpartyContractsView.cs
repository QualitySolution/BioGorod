﻿using System;
using QSOrmProject;
using BioGorod.Domain.Client;
using QSTDI;

namespace BioGorod.Dialogs.Client
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class CounterpartyContractsView : Gtk.Bin
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
			//	treeCounterpartyContracts.RepresentationModel = new ViewModel.ContractsVM (value);
				treeCounterpartyContracts.RepresentationModel.UpdateNodes ();
			}
		}

		public CounterpartyContractsView ()
		{
			this.Build ();
			treeCounterpartyContracts.Selection.Changed += OnSelectionChanged;
		}

		void OnSelectionChanged (object sender, EventArgs e)
		{
			bool selected = treeCounterpartyContracts.Selection.CountSelectedRows () > 0;
			buttonEdit.Sensitive = buttonDelete.Sensitive = selected;
		}

		void OnButtonAddClicked (object sender, EventArgs e)
		{
			ITdiTab mytab = TdiHelper.FindMyTab (this);
			if (mytab == null)
				return;

			var parentDlg = OrmMain.FindMyDialog (this);
			if (parentDlg == null)
				return;

			if (parentDlg.UoW.IsNew) {
				if (CommonDialogs.SaveBeforeCreateSlaveEntity (parentDlg.EntityObject.GetType (), typeof(CounterpartyContract))) {
					parentDlg.UoW.Save ();
				} else
					return;
			}

//			ITdiDialog dlg = new CounterpartyContractDlg (CounterpartyUoW.Root);
//			mytab.TabParent.AddTab (dlg, mytab);
		}

		protected void OnButtonEditClicked (object sender, EventArgs e)
		{
			ITdiTab mytab = TdiHelper.FindMyTab (this);
			if (mytab == null)
				return;

//			ITdiDialog dlg = new CounterpartyContractDlg (treeCounterpartyContracts.GetSelectedId ());
//			mytab.TabParent.AddTab (dlg, mytab);
		}

		protected void OnTreeCounterpartyContractsRowActivated (object o, Gtk.RowActivatedArgs args)
		{
			buttonEdit.Click ();
		}

		protected void OnButtonDeleteClicked (object sender, EventArgs e)
		{
			if (OrmMain.DeleteObject (typeof(CounterpartyContract),
				treeCounterpartyContracts.GetSelectedId ())) {
				treeCounterpartyContracts.RepresentationModel.UpdateNodes ();
			}
		}
	}
}

