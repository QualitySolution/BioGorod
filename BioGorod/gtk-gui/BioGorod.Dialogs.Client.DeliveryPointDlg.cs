
// This file has been generated by the GUI designer. Do not modify.
namespace BioGorod.Dialogs.Client
{
	public partial class DeliveryPointDlg
	{
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Button buttonSave;
		
		private global::Gtk.Button buttonCancel;
		
		private global::QSWidgetLib.MenuButton menuActions;
		
		private global::Gtk.HBox hbox13;
		
		private global::Gtk.RadioButton radioInformation;
		
		private global::Gtk.RadioButton radioContacts;
		
		private global::Gtk.Notebook notebook1;
		
		private global::Gtk.HBox hbox12;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.Table datatable1;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		
		private global::Gamma.GtkWidgets.yTextView textComment;
		
		private global::Gtk.HBox hbox10;
		
		private global::Gamma.GtkWidgets.yEntry yentryAddition;
		
		private global::Gtk.Label labelHouseName;
		
		private global::Gtk.HBox hbox11;
		
		private global::Gtk.Label label20;
		
		private global::Gamma.GtkWidgets.yLabel ylabelDistrictOfCity;
		
		private global::Gtk.HBox hbox6;
		
		private global::Gamma.GtkWidgets.yLabel labelCompiledAddress;
		
		private global::Gamma.GtkWidgets.yCheckButton ycheckOsmFixed;
		
		private global::Gamma.GtkWidgets.yCheckButton checkIsActive;
		
		private global::Gtk.HBox hbox7;
		
		private global::QSOsm.CityEntry entryCity;
		
		private global::Gamma.GtkWidgets.yLabel ylabelFoundOnOsm;
		
		private global::Gtk.Button buttonInsertFromBuffer;
		
		private global::Gtk.HBox hbox8;
		
		private global::QSOsm.StreetEntry entryStreet;
		
		private global::Gtk.Label label7;
		
		private global::QSOsm.HouseEntry entryBuilding;
		
		private global::Gtk.Label label3;
		
		private global::Gamma.GtkWidgets.yEntry yentryLitter;
		
		private global::Gtk.Label label1;
		
		private global::Gtk.Label label11;
		
		private global::Gtk.Label label4;
		
		private global::Gtk.Label label6;
		
		private global::Gtk.Label label8;
		
		private global::QSWidgetLib.RightSidePanel rightsidepanel1;
		
		private global::Gtk.Label label12;
		
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.Label label16;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow2;
		
		private global::Gamma.GtkWidgets.yTreeView ytreeviewResponsiblePersons;
		
		private global::Gtk.HBox hbox14;
		
		private global::Gtk.Button buttonAddResponsiblePerson;
		
		private global::Gtk.Button buttonDeleteResponsiblePerson;
		
		private global::Gtk.Label label2;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget BioGorod.Dialogs.Client.DeliveryPointDlg
			global::Stetic.BinContainer.Attach (this);
			this.Name = "BioGorod.Dialogs.Client.DeliveryPointDlg";
			// Container child BioGorod.Dialogs.Client.DeliveryPointDlg.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			this.vbox1.BorderWidth = ((uint)(6));
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button ();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString ("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image ();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hbox1.Add (this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString ("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image ();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox1.Add (this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.menuActions = new global::QSWidgetLib.MenuButton ();
			this.menuActions.CanFocus = true;
			this.menuActions.Name = "menuActions";
			this.menuActions.UseUnderline = true;
			this.menuActions.UseMarkup = false;
			global::Gtk.Image w5 = new global::Gtk.Image ();
			w5.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("BioGorod.Icons.Buttons.menu.png");
			this.menuActions.Image = w5;
			this.hbox1.Add (this.menuActions);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.menuActions]));
			w6.Position = 2;
			w6.Expand = false;
			w6.Fill = false;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox13 = new global::Gtk.HBox ();
			this.hbox13.Name = "hbox13";
			this.hbox13.Spacing = 6;
			// Container child hbox13.Gtk.Box+BoxChild
			this.radioInformation = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Информация"));
			this.radioInformation.CanFocus = true;
			this.radioInformation.Name = "radioInformation";
			this.radioInformation.DrawIndicator = false;
			this.radioInformation.UseUnderline = true;
			this.radioInformation.Group = new global::GLib.SList (global::System.IntPtr.Zero);
			this.hbox13.Add (this.radioInformation);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox13 [this.radioInformation]));
			w8.Position = 0;
			// Container child hbox13.Gtk.Box+BoxChild
			this.radioContacts = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Контактные лица"));
			this.radioContacts.CanFocus = true;
			this.radioContacts.Name = "radioContacts";
			this.radioContacts.DrawIndicator = false;
			this.radioContacts.UseUnderline = true;
			this.radioContacts.Group = this.radioInformation.Group;
			this.hbox13.Add (this.radioContacts);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox13 [this.radioContacts]));
			w9.Position = 1;
			this.vbox1.Add (this.hbox13);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox13]));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.notebook1 = new global::Gtk.Notebook ();
			this.notebook1.CanFocus = true;
			this.notebook1.Name = "notebook1";
			this.notebook1.CurrentPage = 0;
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.hbox12 = new global::Gtk.HBox ();
			this.hbox12.Name = "hbox12";
			this.hbox12.Spacing = 6;
			// Container child hbox12.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			global::Gtk.Viewport w11 = new global::Gtk.Viewport ();
			w11.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.datatable1 = new global::Gtk.Table (((uint)(6)), ((uint)(2)), false);
			this.datatable1.Name = "datatable1";
			this.datatable1.RowSpacing = ((uint)(6));
			this.datatable1.ColumnSpacing = ((uint)(6));
			this.datatable1.BorderWidth = ((uint)(6));
			// Container child datatable1.Gtk.Table+TableChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.textComment = new global::Gamma.GtkWidgets.yTextView ();
			this.textComment.CanFocus = true;
			this.textComment.Name = "textComment";
			this.GtkScrolledWindow1.Add (this.textComment);
			this.datatable1.Add (this.GtkScrolledWindow1);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.GtkScrolledWindow1]));
			w13.TopAttach = ((uint)(5));
			w13.BottomAttach = ((uint)(6));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.hbox10 = new global::Gtk.HBox ();
			this.hbox10.Name = "hbox10";
			this.hbox10.Spacing = 6;
			// Container child hbox10.Gtk.Box+BoxChild
			this.yentryAddition = new global::Gamma.GtkWidgets.yEntry ();
			this.yentryAddition.CanFocus = true;
			this.yentryAddition.Name = "yentryAddition";
			this.yentryAddition.IsEditable = true;
			this.yentryAddition.MaxLength = 100;
			this.yentryAddition.InvisibleChar = '●';
			this.hbox10.Add (this.yentryAddition);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox10 [this.yentryAddition]));
			w14.Position = 0;
			// Container child hbox10.Gtk.Box+BoxChild
			this.labelHouseName = new global::Gtk.Label ();
			this.labelHouseName.Name = "labelHouseName";
			this.labelHouseName.Xalign = 1F;
			this.labelHouseName.Justify = ((global::Gtk.Justification)(1));
			this.labelHouseName.Selectable = true;
			this.hbox10.Add (this.labelHouseName);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox10 [this.labelHouseName]));
			w15.Position = 1;
			w15.Expand = false;
			w15.Fill = false;
			this.datatable1.Add (this.hbox10);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.hbox10]));
			w16.TopAttach = ((uint)(3));
			w16.BottomAttach = ((uint)(4));
			w16.LeftAttach = ((uint)(1));
			w16.RightAttach = ((uint)(2));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.hbox11 = new global::Gtk.HBox ();
			this.hbox11.Name = "hbox11";
			this.hbox11.Spacing = 6;
			// Container child hbox11.Gtk.Box+BoxChild
			this.label20 = new global::Gtk.Label ();
			this.label20.Name = "label20";
			this.label20.LabelProp = global::Mono.Unix.Catalog.GetString ("Район города:");
			this.hbox11.Add (this.label20);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox11 [this.label20]));
			w17.Position = 1;
			w17.Expand = false;
			w17.Fill = false;
			// Container child hbox11.Gtk.Box+BoxChild
			this.ylabelDistrictOfCity = new global::Gamma.GtkWidgets.yLabel ();
			this.ylabelDistrictOfCity.Name = "ylabelDistrictOfCity";
			this.ylabelDistrictOfCity.LabelProp = global::Mono.Unix.Catalog.GetString ("отсутствует");
			this.hbox11.Add (this.ylabelDistrictOfCity);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox11 [this.ylabelDistrictOfCity]));
			w18.Position = 2;
			w18.Expand = false;
			w18.Fill = false;
			this.datatable1.Add (this.hbox11);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.hbox11]));
			w19.TopAttach = ((uint)(4));
			w19.BottomAttach = ((uint)(5));
			w19.LeftAttach = ((uint)(1));
			w19.RightAttach = ((uint)(2));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.hbox6 = new global::Gtk.HBox ();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.labelCompiledAddress = new global::Gamma.GtkWidgets.yLabel ();
			this.labelCompiledAddress.Name = "labelCompiledAddress";
			this.labelCompiledAddress.Xalign = 0F;
			this.labelCompiledAddress.Wrap = true;
			this.labelCompiledAddress.Selectable = true;
			this.hbox6.Add (this.labelCompiledAddress);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.labelCompiledAddress]));
			w20.Position = 0;
			// Container child hbox6.Gtk.Box+BoxChild
			this.ycheckOsmFixed = new global::Gamma.GtkWidgets.yCheckButton ();
			this.ycheckOsmFixed.CanFocus = true;
			this.ycheckOsmFixed.Name = "ycheckOsmFixed";
			this.ycheckOsmFixed.Label = global::Mono.Unix.Catalog.GetString ("Исправлено");
			this.ycheckOsmFixed.DrawIndicator = true;
			this.ycheckOsmFixed.UseUnderline = true;
			this.hbox6.Add (this.ycheckOsmFixed);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.ycheckOsmFixed]));
			w21.Position = 2;
			w21.Expand = false;
			w21.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.checkIsActive = new global::Gamma.GtkWidgets.yCheckButton ();
			this.checkIsActive.CanFocus = true;
			this.checkIsActive.Name = "checkIsActive";
			this.checkIsActive.Label = global::Mono.Unix.Catalog.GetString ("Активный");
			this.checkIsActive.DrawIndicator = true;
			this.checkIsActive.UseUnderline = true;
			this.hbox6.Add (this.checkIsActive);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.checkIsActive]));
			w22.Position = 3;
			w22.Expand = false;
			w22.Fill = false;
			this.datatable1.Add (this.hbox6);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.hbox6]));
			w23.LeftAttach = ((uint)(1));
			w23.RightAttach = ((uint)(2));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.hbox7 = new global::Gtk.HBox ();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.entryCity = new global::QSOsm.CityEntry ();
			this.entryCity.CanFocus = true;
			this.entryCity.Name = "entryCity";
			this.entryCity.IsEditable = true;
			this.entryCity.InvisibleChar = '●';
			this.hbox7.Add (this.entryCity);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.entryCity]));
			w24.Position = 0;
			// Container child hbox7.Gtk.Box+BoxChild
			this.ylabelFoundOnOsm = new global::Gamma.GtkWidgets.yLabel ();
			this.ylabelFoundOnOsm.Name = "ylabelFoundOnOsm";
			this.ylabelFoundOnOsm.LabelProp = global::Mono.Unix.Catalog.GetString ("FoundOnOsm");
			this.ylabelFoundOnOsm.UseMarkup = true;
			this.ylabelFoundOnOsm.Selectable = true;
			this.hbox7.Add (this.ylabelFoundOnOsm);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.ylabelFoundOnOsm]));
			w25.Position = 1;
			w25.Expand = false;
			w25.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.buttonInsertFromBuffer = new global::Gtk.Button ();
			this.buttonInsertFromBuffer.CanFocus = true;
			this.buttonInsertFromBuffer.Name = "buttonInsertFromBuffer";
			this.buttonInsertFromBuffer.UseUnderline = true;
			this.buttonInsertFromBuffer.Label = global::Mono.Unix.Catalog.GetString ("Вставить из буфера обмена");
			this.hbox7.Add (this.buttonInsertFromBuffer);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.buttonInsertFromBuffer]));
			w26.Position = 2;
			w26.Expand = false;
			w26.Fill = false;
			this.datatable1.Add (this.hbox7);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.hbox7]));
			w27.TopAttach = ((uint)(1));
			w27.BottomAttach = ((uint)(2));
			w27.LeftAttach = ((uint)(1));
			w27.RightAttach = ((uint)(2));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.hbox8 = new global::Gtk.HBox ();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 6;
			// Container child hbox8.Gtk.Box+BoxChild
			this.entryStreet = new global::QSOsm.StreetEntry ();
			this.entryStreet.CanFocus = true;
			this.entryStreet.Name = "entryStreet";
			this.entryStreet.IsEditable = true;
			this.entryStreet.InvisibleChar = '●';
			this.entryStreet.CityId = 0;
			this.hbox8.Add (this.entryStreet);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.entryStreet]));
			w28.Position = 0;
			// Container child hbox8.Gtk.Box+BoxChild
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.Xalign = 1F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("Дом:");
			this.hbox8.Add (this.label7);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.label7]));
			w29.Position = 1;
			w29.Expand = false;
			w29.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.entryBuilding = new global::QSOsm.HouseEntry ();
			this.entryBuilding.CanFocus = true;
			this.entryBuilding.Name = "entryBuilding";
			this.entryBuilding.IsEditable = true;
			this.entryBuilding.WidthChars = 20;
			this.entryBuilding.MaxLength = 20;
			this.entryBuilding.InvisibleChar = '●';
			this.hbox8.Add (this.entryBuilding);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.entryBuilding]));
			w30.Position = 2;
			w30.Expand = false;
			w30.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Литера:");
			this.hbox8.Add (this.label3);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.label3]));
			w31.Position = 3;
			w31.Expand = false;
			w31.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.yentryLitter = new global::Gamma.GtkWidgets.yEntry ();
			this.yentryLitter.CanFocus = true;
			this.yentryLitter.Name = "yentryLitter";
			this.yentryLitter.IsEditable = true;
			this.yentryLitter.WidthChars = 3;
			this.yentryLitter.MaxLength = 2;
			this.yentryLitter.InvisibleChar = '●';
			this.hbox8.Add (this.yentryLitter);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.yentryLitter]));
			w32.Position = 4;
			w32.Expand = false;
			w32.Fill = false;
			this.datatable1.Add (this.hbox8);
			global::Gtk.Table.TableChild w33 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.hbox8]));
			w33.TopAttach = ((uint)(2));
			w33.BottomAttach = ((uint)(3));
			w33.LeftAttach = ((uint)(1));
			w33.RightAttach = ((uint)(2));
			w33.XOptions = ((global::Gtk.AttachOptions)(4));
			w33.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Название:");
			this.datatable1.Add (this.label1);
			global::Gtk.Table.TableChild w34 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.label1]));
			w34.XOptions = ((global::Gtk.AttachOptions)(4));
			w34.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label11 = new global::Gtk.Label ();
			this.label11.Name = "label11";
			this.label11.Xalign = 1F;
			this.label11.Yalign = 0F;
			this.label11.LabelProp = global::Mono.Unix.Catalog.GetString ("Комментарий к\nадресу объекта:");
			this.datatable1.Add (this.label11);
			global::Gtk.Table.TableChild w35 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.label11]));
			w35.TopAttach = ((uint)(5));
			w35.BottomAttach = ((uint)(6));
			w35.XOptions = ((global::Gtk.AttachOptions)(4));
			w35.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Город:");
			this.datatable1.Add (this.label4);
			global::Gtk.Table.TableChild w36 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.label4]));
			w36.TopAttach = ((uint)(1));
			w36.BottomAttach = ((uint)(2));
			w36.XOptions = ((global::Gtk.AttachOptions)(4));
			w36.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Улица:");
			this.datatable1.Add (this.label6);
			global::Gtk.Table.TableChild w37 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.label6]));
			w37.TopAttach = ((uint)(2));
			w37.BottomAttach = ((uint)(3));
			w37.XOptions = ((global::Gtk.AttachOptions)(4));
			w37.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label8 = new global::Gtk.Label ();
			this.label8.Name = "label8";
			this.label8.Xalign = 1F;
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString ("Дополнение к адресу:");
			this.datatable1.Add (this.label8);
			global::Gtk.Table.TableChild w38 = ((global::Gtk.Table.TableChild)(this.datatable1 [this.label8]));
			w38.TopAttach = ((uint)(3));
			w38.BottomAttach = ((uint)(4));
			w38.XOptions = ((global::Gtk.AttachOptions)(4));
			w38.YOptions = ((global::Gtk.AttachOptions)(4));
			w11.Add (this.datatable1);
			this.GtkScrolledWindow.Add (w11);
			this.hbox12.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.hbox12 [this.GtkScrolledWindow]));
			w41.Position = 0;
			// Container child hbox12.Gtk.Box+BoxChild
			this.rightsidepanel1 = new global::QSWidgetLib.RightSidePanel ();
			this.rightsidepanel1.Events = ((global::Gdk.EventMask)(256));
			this.rightsidepanel1.Name = "rightsidepanel1";
			this.rightsidepanel1.Title = "Карта";
			this.rightsidepanel1.IsHided = true;
			this.hbox12.Add (this.rightsidepanel1);
			global::Gtk.Box.BoxChild w42 = ((global::Gtk.Box.BoxChild)(this.hbox12 [this.rightsidepanel1]));
			w42.Position = 1;
			w42.Expand = false;
			this.notebook1.Add (this.hbox12);
			// Notebook tab
			this.label12 = new global::Gtk.Label ();
			this.label12.Name = "label12";
			this.label12.LabelProp = global::Mono.Unix.Catalog.GetString ("Информация");
			this.notebook1.SetTabLabel (this.hbox12, this.label12);
			this.label12.ShowAll ();
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.label16 = new global::Gtk.Label ();
			this.label16.Name = "label16";
			this.label16.Xalign = 0F;
			this.label16.LabelProp = global::Mono.Unix.Catalog.GetString ("Список контактных лиц");
			this.vbox2.Add (this.label16);
			global::Gtk.Box.BoxChild w44 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.label16]));
			w44.Position = 0;
			w44.Expand = false;
			w44.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow2 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow2.Name = "GtkScrolledWindow2";
			this.GtkScrolledWindow2.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow2.Gtk.Container+ContainerChild
			this.ytreeviewResponsiblePersons = new global::Gamma.GtkWidgets.yTreeView ();
			this.ytreeviewResponsiblePersons.CanFocus = true;
			this.ytreeviewResponsiblePersons.Name = "ytreeviewResponsiblePersons";
			this.GtkScrolledWindow2.Add (this.ytreeviewResponsiblePersons);
			this.vbox2.Add (this.GtkScrolledWindow2);
			global::Gtk.Box.BoxChild w46 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.GtkScrolledWindow2]));
			w46.Position = 1;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox14 = new global::Gtk.HBox ();
			this.hbox14.Name = "hbox14";
			this.hbox14.Spacing = 6;
			// Container child hbox14.Gtk.Box+BoxChild
			this.buttonAddResponsiblePerson = new global::Gtk.Button ();
			this.buttonAddResponsiblePerson.CanFocus = true;
			this.buttonAddResponsiblePerson.Name = "buttonAddResponsiblePerson";
			this.buttonAddResponsiblePerson.UseUnderline = true;
			this.buttonAddResponsiblePerson.Label = global::Mono.Unix.Catalog.GetString ("Добавить");
			this.hbox14.Add (this.buttonAddResponsiblePerson);
			global::Gtk.Box.BoxChild w47 = ((global::Gtk.Box.BoxChild)(this.hbox14 [this.buttonAddResponsiblePerson]));
			w47.Position = 0;
			w47.Expand = false;
			w47.Fill = false;
			// Container child hbox14.Gtk.Box+BoxChild
			this.buttonDeleteResponsiblePerson = new global::Gtk.Button ();
			this.buttonDeleteResponsiblePerson.CanFocus = true;
			this.buttonDeleteResponsiblePerson.Name = "buttonDeleteResponsiblePerson";
			this.buttonDeleteResponsiblePerson.UseUnderline = true;
			this.buttonDeleteResponsiblePerson.Label = global::Mono.Unix.Catalog.GetString ("Удалить");
			this.hbox14.Add (this.buttonDeleteResponsiblePerson);
			global::Gtk.Box.BoxChild w48 = ((global::Gtk.Box.BoxChild)(this.hbox14 [this.buttonDeleteResponsiblePerson]));
			w48.Position = 1;
			w48.Expand = false;
			w48.Fill = false;
			this.vbox2.Add (this.hbox14);
			global::Gtk.Box.BoxChild w49 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox14]));
			w49.Position = 2;
			w49.Expand = false;
			w49.Fill = false;
			this.notebook1.Add (this.vbox2);
			global::Gtk.Notebook.NotebookChild w50 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.vbox2]));
			w50.Position = 1;
			// Notebook tab
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Ответственные лица");
			this.notebook1.SetTabLabel (this.vbox2, this.label2);
			this.label2.ShowAll ();
			this.vbox1.Add (this.notebook1);
			global::Gtk.Box.BoxChild w51 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.notebook1]));
			w51.Position = 2;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.labelHouseName.Hide ();
			this.Hide ();
			this.buttonSave.Clicked += new global::System.EventHandler (this.OnButtonSaveClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler (this.OnButtonCancelClicked);
			this.radioInformation.Toggled += new global::System.EventHandler (this.OnRadoiInformationToggled);
			this.radioContacts.Toggled += new global::System.EventHandler (this.OnRadioContactsToggled);
			this.buttonInsertFromBuffer.Clicked += new global::System.EventHandler (this.OnButtonInsertFromBufferClicked);
			this.buttonAddResponsiblePerson.Clicked += new global::System.EventHandler (this.OnButtonAddResponsiblePersonClicked);
			this.buttonDeleteResponsiblePerson.Clicked += new global::System.EventHandler (this.OnButtonDeleteResponsiblePersonClicked);
		}
	}
}
