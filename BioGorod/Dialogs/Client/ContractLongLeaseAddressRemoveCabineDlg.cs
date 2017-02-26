using System;
using BioGorod.Domain.Company;
using System.Collections.Generic;
using System.Linq;

namespace BioGorod.Dialogs.Client
{
	public partial class ContractLongLeaseAddressRemoveCabineDlg : Gtk.Dialog
	{
		Dictionary<Cabine, Gtk.CheckButton> Widgets = new Dictionary<Cabine, Gtk.CheckButton>();

		public IEnumerable<Cabine> SelectedCabines{
			get{
				return Widgets.Where(x => x.Value.Active).Select(x => x.Key);
			}
		}

		public ContractLongLeaseAddressRemoveCabineDlg(Cabine[] cabines)
		{
			this.Build();

			foreach(var cabine in cabines)
			{
				var check = new Gtk.CheckButton(String.Format("({0}) {1}", cabine.Number, cabine.Name));
				check.Toggled += Check_Toggled;
				vboxCabines.PackStart(check);
				Widgets.Add(cabine, check);
				check.Show();
			}
		}

		void Check_Toggled (object sender, EventArgs e)
		{
			buttonOk.Sensitive = SelectedCabines.Any();
		}
	}
}

