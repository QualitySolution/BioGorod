
// This file has been generated by the GUI designer. Do not modify.
namespace BioGorod.Dialogs.Client
{
	public partial class ContractLongLeaseAdressesView
	{
		private global::Gtk.VBox vbox3;
		
		private global::Gtk.HBox hbox2;
		
		private global::Gtk.Label label3;
		
		private global::Gamma.Widgets.yDatePicker ydateSinceDate;
		
		private global::Gtk.Button buttonDeleteDate;
		
		private global::Gtk.Button buttonNewDate;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gamma.GtkWidgets.yTreeView ytreeviewAddresses;
		
		private global::Gtk.HBox hbox3;
		
		private global::Gtk.Button buttonAddAddress;
		
		private global::Gtk.Button buttonDeleteAddress;
		
		private global::Gtk.VSeparator vseparator1;
		
		private global::Gtk.Button buttonAddCabine;
		
		private global::Gtk.Button buttonDeleteCabine;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget BioGorod.Dialogs.Client.ContractLongLeaseAdressesView
			global::Stetic.BinContainer.Attach (this);
			this.Name = "BioGorod.Dialogs.Client.ContractLongLeaseAdressesView";
			// Container child BioGorod.Dialogs.Client.ContractLongLeaseAdressesView.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Условия действуют с:");
			this.hbox2.Add (this.label3);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label3]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.ydateSinceDate = new global::Gamma.Widgets.yDatePicker ();
			this.ydateSinceDate.Events = ((global::Gdk.EventMask)(256));
			this.ydateSinceDate.Name = "ydateSinceDate";
			this.ydateSinceDate.WithTime = false;
			this.ydateSinceDate.Date = new global::System.DateTime (0);
			this.ydateSinceDate.IsEditable = false;
			this.ydateSinceDate.AutoSeparation = true;
			this.hbox2.Add (this.ydateSinceDate);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.ydateSinceDate]));
			w2.Position = 1;
			// Container child hbox2.Gtk.Box+BoxChild
			this.buttonDeleteDate = new global::Gtk.Button ();
			this.buttonDeleteDate.CanFocus = true;
			this.buttonDeleteDate.Name = "buttonDeleteDate";
			this.buttonDeleteDate.UseUnderline = true;
			this.buttonDeleteDate.Label = global::Mono.Unix.Catalog.GetString ("Удалить дату");
			global::Gtk.Image w3 = new global::Gtk.Image ();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-remove", global::Gtk.IconSize.Menu);
			this.buttonDeleteDate.Image = w3;
			this.hbox2.Add (this.buttonDeleteDate);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.buttonDeleteDate]));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.buttonNewDate = new global::Gtk.Button ();
			this.buttonNewDate.CanFocus = true;
			this.buttonNewDate.Name = "buttonNewDate";
			this.buttonNewDate.UseUnderline = true;
			this.buttonNewDate.Label = global::Mono.Unix.Catalog.GetString ("Новые условия");
			global::Gtk.Image w5 = new global::Gtk.Image ();
			w5.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-add", global::Gtk.IconSize.Menu);
			this.buttonNewDate.Image = w5;
			this.hbox2.Add (this.buttonNewDate);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.buttonNewDate]));
			w6.Position = 3;
			w6.Expand = false;
			w6.Fill = false;
			this.vbox3.Add (this.hbox2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox2]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytreeviewAddresses = new global::Gamma.GtkWidgets.yTreeView ();
			this.ytreeviewAddresses.CanFocus = true;
			this.ytreeviewAddresses.Name = "ytreeviewAddresses";
			this.GtkScrolledWindow.Add (this.ytreeviewAddresses);
			this.vbox3.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.GtkScrolledWindow]));
			w9.Position = 1;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.buttonAddAddress = new global::Gtk.Button ();
			this.buttonAddAddress.CanFocus = true;
			this.buttonAddAddress.Name = "buttonAddAddress";
			this.buttonAddAddress.UseUnderline = true;
			this.buttonAddAddress.Label = global::Mono.Unix.Catalog.GetString ("Добавить адрес");
			global::Gtk.Image w10 = new global::Gtk.Image ();
			w10.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-add", global::Gtk.IconSize.Menu);
			this.buttonAddAddress.Image = w10;
			this.hbox3.Add (this.buttonAddAddress);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.buttonAddAddress]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.buttonDeleteAddress = new global::Gtk.Button ();
			this.buttonDeleteAddress.CanFocus = true;
			this.buttonDeleteAddress.Name = "buttonDeleteAddress";
			this.buttonDeleteAddress.UseUnderline = true;
			this.buttonDeleteAddress.Label = global::Mono.Unix.Catalog.GetString ("Удалить адрес");
			global::Gtk.Image w12 = new global::Gtk.Image ();
			w12.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-delete", global::Gtk.IconSize.Menu);
			this.buttonDeleteAddress.Image = w12;
			this.hbox3.Add (this.buttonDeleteAddress);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.buttonDeleteAddress]));
			w13.Position = 1;
			w13.Expand = false;
			w13.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.vseparator1 = new global::Gtk.VSeparator ();
			this.vseparator1.Name = "vseparator1";
			this.hbox3.Add (this.vseparator1);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.vseparator1]));
			w14.Position = 2;
			w14.Expand = false;
			w14.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.buttonAddCabine = new global::Gtk.Button ();
			this.buttonAddCabine.CanFocus = true;
			this.buttonAddCabine.Name = "buttonAddCabine";
			this.buttonAddCabine.UseUnderline = true;
			this.buttonAddCabine.Label = global::Mono.Unix.Catalog.GetString ("Добавить кабинки");
			global::Gtk.Image w15 = new global::Gtk.Image ();
			w15.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-add", global::Gtk.IconSize.Menu);
			this.buttonAddCabine.Image = w15;
			this.hbox3.Add (this.buttonAddCabine);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.buttonAddCabine]));
			w16.Position = 3;
			w16.Expand = false;
			w16.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.buttonDeleteCabine = new global::Gtk.Button ();
			this.buttonDeleteCabine.CanFocus = true;
			this.buttonDeleteCabine.Name = "buttonDeleteCabine";
			this.buttonDeleteCabine.UseUnderline = true;
			this.buttonDeleteCabine.Label = global::Mono.Unix.Catalog.GetString ("Убрать кабинки");
			global::Gtk.Image w17 = new global::Gtk.Image ();
			w17.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-delete", global::Gtk.IconSize.Menu);
			this.buttonDeleteCabine.Image = w17;
			this.hbox3.Add (this.buttonDeleteCabine);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.buttonDeleteCabine]));
			w18.Position = 4;
			w18.Expand = false;
			w18.Fill = false;
			this.vbox3.Add (this.hbox3);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox3]));
			w19.Position = 2;
			w19.Expand = false;
			w19.Fill = false;
			this.Add (this.vbox3);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.ydateSinceDate.DateChanged += new global::System.EventHandler (this.OnYdateSinceDateDateChanged);
			this.buttonDeleteDate.Clicked += new global::System.EventHandler (this.OnButtonDeleteDateClicked);
			this.buttonNewDate.Clicked += new global::System.EventHandler (this.OnButtonNewDateClicked);
			this.buttonAddAddress.Clicked += new global::System.EventHandler (this.OnButtonAddClicked);
			this.buttonDeleteAddress.Clicked += new global::System.EventHandler (this.OnButtonDeleteClicked);
			this.buttonAddCabine.Clicked += new global::System.EventHandler (this.OnButtonAddCabineClicked);
			this.buttonDeleteCabine.Clicked += new global::System.EventHandler (this.OnButtonDeleteCabineClicked);
		}
	}
}
