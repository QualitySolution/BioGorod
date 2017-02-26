
// This file has been generated by the GUI designer. Do not modify.
namespace BioGorod.Dialogs.Client
{
	public partial class ContractShortLeaseDlg
	{
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Button buttonSave;
		
		private global::Gtk.Button buttonCancel;
		
		private global::Gtk.VSeparator vseparator1;
		
		private global::Gtk.Table table1;
		
		private global::Gtk.Label label1;
		
		private global::Gtk.Label label2;
		
		private global::Gtk.Label label3;
		
		private global::Gtk.Label label4;
		
		private global::Gtk.Label label5;
		
		private global::Gtk.Label label6;
		
		private global::QSDocTemplates.TemplateWidget templatewidget1;
		
		private global::Gtk.VBox vbox2;
		
		private global::Gamma.GtkWidgets.yCheckButton ycheckOrigin;
		
		private global::Gamma.GtkWidgets.yCheckButton ycheckScanned;
		
		private global::Gamma.GtkWidgets.yCheckButton ycheckArchive;
		
		private global::Gamma.Widgets.yDatePicker ydateIssue;
		
		private global::Gamma.Widgets.yEntryReferenceVM yentryreferenceCounterparty;
		
		private global::Gamma.Widgets.yEntryReference yentryreferenceOrg;
		
		private global::Gamma.GtkWidgets.yLabel ylabelNumber;
		
		private global::Gtk.Table table2;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gamma.GtkWidgets.yTextView ytextAdditionalInfo;
		
		private global::Gtk.Label label10;
		
		private global::Gtk.Label label11;
		
		private global::Gtk.Label label12;
		
		private global::Gtk.Label label13;
		
		private global::Gtk.Label label7;
		
		private global::Gtk.Label label8;
		
		private global::Gtk.Label label9;
		
		private global::Gtk.VBox vbox3;
		
		private global::Gamma.GtkWidgets.yCheckButton ycheckDispenser;
		
		private global::Gamma.GtkWidgets.yCheckButton ycheckAdditionalWater;
		
		private global::Gamma.Widgets.yDatePicker ydateDelivery;
		
		private global::Gamma.Widgets.yDatePicker ydateRemoval;
		
		private global::Gamma.GtkWidgets.yLabel ylabel2;
		
		private global::Gamma.GtkWidgets.yLabel ylabelTotalCost;
		
		private global::Gamma.GtkWidgets.ySpinButton yspinCabineCost;
		
		private global::Gamma.GtkWidgets.ySpinButton yspinCabineCount;
		
		private global::Gamma.GtkWidgets.ySpinButton yspinDeliveryCost;
		
		private global::BioGorod.Dialogs.Client.ContractShortLeaseAdressesView contractshortleaseadressesview1;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget BioGorod.Dialogs.Client.ContractShortLeaseDlg
			global::Stetic.BinContainer.Attach (this);
			this.Name = "BioGorod.Dialogs.Client.ContractShortLeaseDlg";
			// Container child BioGorod.Dialogs.Client.ContractShortLeaseDlg.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
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
			this.vseparator1 = new global::Gtk.VSeparator ();
			this.vseparator1.Name = "vseparator1";
			this.hbox1.Add (this.vseparator1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vseparator1]));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table (((uint)(3)), ((uint)(5)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Номер:");
			this.table1.Add (this.label1);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1 [this.label1]));
			w7.LeftAttach = ((uint)(2));
			w7.RightAttach = ((uint)(3));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Организация:");
			this.table1.Add (this.label2);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1 [this.label2]));
			w8.TopAttach = ((uint)(1));
			w8.BottomAttach = ((uint)(2));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Контрагент:");
			this.table1.Add (this.label3);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1 [this.label3]));
			w9.TopAttach = ((uint)(2));
			w9.BottomAttach = ((uint)(3));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Дата подписания:");
			this.table1.Add (this.label4);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1 [this.label4]));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Архивный:");
			this.table1.Add (this.label5);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1 [this.label5]));
			w11.TopAttach = ((uint)(1));
			w11.BottomAttach = ((uint)(2));
			w11.LeftAttach = ((uint)(2));
			w11.RightAttach = ((uint)(3));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("В наличии:");
			this.table1.Add (this.label6);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table1 [this.label6]));
			w12.TopAttach = ((uint)(2));
			w12.BottomAttach = ((uint)(3));
			w12.LeftAttach = ((uint)(2));
			w12.RightAttach = ((uint)(3));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.templatewidget1 = new global::QSDocTemplates.TemplateWidget ();
			this.templatewidget1.Events = ((global::Gdk.EventMask)(256));
			this.templatewidget1.Name = "templatewidget1";
			this.table1.Add (this.templatewidget1);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1 [this.templatewidget1]));
			w13.BottomAttach = ((uint)(3));
			w13.LeftAttach = ((uint)(4));
			w13.RightAttach = ((uint)(5));
			w13.XOptions = ((global::Gtk.AttachOptions)(0));
			w13.YOptions = ((global::Gtk.AttachOptions)(0));
			// Container child table1.Gtk.Table+TableChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.ycheckOrigin = new global::Gamma.GtkWidgets.yCheckButton ();
			this.ycheckOrigin.CanFocus = true;
			this.ycheckOrigin.Name = "ycheckOrigin";
			this.ycheckOrigin.Label = global::Mono.Unix.Catalog.GetString ("Оригинал");
			this.ycheckOrigin.DrawIndicator = true;
			this.ycheckOrigin.UseUnderline = true;
			this.vbox2.Add (this.ycheckOrigin);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.ycheckOrigin]));
			w14.Position = 0;
			w14.Expand = false;
			w14.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.ycheckScanned = new global::Gamma.GtkWidgets.yCheckButton ();
			this.ycheckScanned.CanFocus = true;
			this.ycheckScanned.Name = "ycheckScanned";
			this.ycheckScanned.Label = global::Mono.Unix.Catalog.GetString ("Скан");
			this.ycheckScanned.DrawIndicator = true;
			this.ycheckScanned.UseUnderline = true;
			this.vbox2.Add (this.ycheckScanned);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.ycheckScanned]));
			w15.Position = 1;
			w15.Expand = false;
			w15.Fill = false;
			this.table1.Add (this.vbox2);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.table1 [this.vbox2]));
			w16.TopAttach = ((uint)(2));
			w16.BottomAttach = ((uint)(3));
			w16.LeftAttach = ((uint)(3));
			w16.RightAttach = ((uint)(4));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ycheckArchive = new global::Gamma.GtkWidgets.yCheckButton ();
			this.ycheckArchive.CanFocus = true;
			this.ycheckArchive.Name = "ycheckArchive";
			this.ycheckArchive.Label = global::Mono.Unix.Catalog.GetString ("Да");
			this.ycheckArchive.DrawIndicator = true;
			this.ycheckArchive.UseUnderline = true;
			this.table1.Add (this.ycheckArchive);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.table1 [this.ycheckArchive]));
			w17.TopAttach = ((uint)(1));
			w17.BottomAttach = ((uint)(2));
			w17.LeftAttach = ((uint)(3));
			w17.RightAttach = ((uint)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ydateIssue = new global::Gamma.Widgets.yDatePicker ();
			this.ydateIssue.Events = ((global::Gdk.EventMask)(256));
			this.ydateIssue.Name = "ydateIssue";
			this.ydateIssue.WithTime = false;
			this.ydateIssue.Date = new global::System.DateTime (0);
			this.ydateIssue.IsEditable = true;
			this.ydateIssue.AutoSeparation = true;
			this.table1.Add (this.ydateIssue);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.table1 [this.ydateIssue]));
			w18.LeftAttach = ((uint)(1));
			w18.RightAttach = ((uint)(2));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yentryreferenceCounterparty = new global::Gamma.Widgets.yEntryReferenceVM ();
			this.yentryreferenceCounterparty.Events = ((global::Gdk.EventMask)(256));
			this.yentryreferenceCounterparty.Name = "yentryreferenceCounterparty";
			this.table1.Add (this.yentryreferenceCounterparty);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.table1 [this.yentryreferenceCounterparty]));
			w19.TopAttach = ((uint)(2));
			w19.BottomAttach = ((uint)(3));
			w19.LeftAttach = ((uint)(1));
			w19.RightAttach = ((uint)(2));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(0));
			// Container child table1.Gtk.Table+TableChild
			this.yentryreferenceOrg = new global::Gamma.Widgets.yEntryReference ();
			this.yentryreferenceOrg.Events = ((global::Gdk.EventMask)(256));
			this.yentryreferenceOrg.Name = "yentryreferenceOrg";
			this.table1.Add (this.yentryreferenceOrg);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.table1 [this.yentryreferenceOrg]));
			w20.TopAttach = ((uint)(1));
			w20.BottomAttach = ((uint)(2));
			w20.LeftAttach = ((uint)(1));
			w20.RightAttach = ((uint)(2));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylabelNumber = new global::Gamma.GtkWidgets.yLabel ();
			this.ylabelNumber.Name = "ylabelNumber";
			this.ylabelNumber.Xalign = 0F;
			this.ylabelNumber.LabelProp = global::Mono.Unix.Catalog.GetString ("ylabel1");
			this.table1.Add (this.ylabelNumber);
			global::Gtk.Table.TableChild w21 = ((global::Gtk.Table.TableChild)(this.table1 [this.ylabelNumber]));
			w21.LeftAttach = ((uint)(3));
			w21.RightAttach = ((uint)(4));
			w21.XOptions = ((global::Gtk.AttachOptions)(4));
			w21.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox1.Add (this.table1);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.table1]));
			w22.Position = 1;
			w22.Expand = false;
			w22.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.table2 = new global::Gtk.Table (((uint)(5)), ((uint)(4)), false);
			this.table2.Name = "table2";
			this.table2.RowSpacing = ((uint)(6));
			this.table2.ColumnSpacing = ((uint)(6));
			// Container child table2.Gtk.Table+TableChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytextAdditionalInfo = new global::Gamma.GtkWidgets.yTextView ();
			this.ytextAdditionalInfo.CanFocus = true;
			this.ytextAdditionalInfo.Name = "ytextAdditionalInfo";
			this.GtkScrolledWindow.Add (this.ytextAdditionalInfo);
			this.table2.Add (this.GtkScrolledWindow);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.table2 [this.GtkScrolledWindow]));
			w24.TopAttach = ((uint)(4));
			w24.BottomAttach = ((uint)(5));
			w24.LeftAttach = ((uint)(1));
			w24.RightAttach = ((uint)(3));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.label10 = new global::Gtk.Label ();
			this.label10.Name = "label10";
			this.label10.Xalign = 1F;
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString ("Дата и время доставки:");
			this.table2.Add (this.label10);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.table2 [this.label10]));
			w25.TopAttach = ((uint)(1));
			w25.BottomAttach = ((uint)(2));
			w25.XOptions = ((global::Gtk.AttachOptions)(4));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.label11 = new global::Gtk.Label ();
			this.label11.Name = "label11";
			this.label11.Xalign = 1F;
			this.label11.LabelProp = global::Mono.Unix.Catalog.GetString ("Дата и время вывоза:");
			this.table2.Add (this.label11);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.table2 [this.label11]));
			w26.TopAttach = ((uint)(2));
			w26.BottomAttach = ((uint)(3));
			w26.XOptions = ((global::Gtk.AttachOptions)(4));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.label12 = new global::Gtk.Label ();
			this.label12.Name = "label12";
			this.label12.Xalign = 1F;
			this.label12.LabelProp = global::Mono.Unix.Catalog.GetString ("Стоимость за кабину:");
			this.table2.Add (this.label12);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.table2 [this.label12]));
			w27.TopAttach = ((uint)(2));
			w27.BottomAttach = ((uint)(3));
			w27.LeftAttach = ((uint)(2));
			w27.RightAttach = ((uint)(3));
			w27.XOptions = ((global::Gtk.AttachOptions)(4));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.label13 = new global::Gtk.Label ();
			this.label13.Name = "label13";
			this.label13.Xalign = 1F;
			this.label13.LabelProp = global::Mono.Unix.Catalog.GetString ("Общая стоимость договора:");
			this.table2.Add (this.label13);
			global::Gtk.Table.TableChild w28 = ((global::Gtk.Table.TableChild)(this.table2 [this.label13]));
			w28.TopAttach = ((uint)(3));
			w28.BottomAttach = ((uint)(4));
			w28.LeftAttach = ((uint)(2));
			w28.RightAttach = ((uint)(3));
			w28.XOptions = ((global::Gtk.AttachOptions)(4));
			w28.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Условия краткосрочной аренды</b>");
			this.label7.UseMarkup = true;
			this.table2.Add (this.label7);
			global::Gtk.Table.TableChild w29 = ((global::Gtk.Table.TableChild)(this.table2 [this.label7]));
			w29.RightAttach = ((uint)(4));
			w29.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.label8 = new global::Gtk.Label ();
			this.label8.Name = "label8";
			this.label8.Xalign = 1F;
			this.label8.Yalign = 0F;
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString ("Дополнительная информация:");
			this.table2.Add (this.label8);
			global::Gtk.Table.TableChild w30 = ((global::Gtk.Table.TableChild)(this.table2 [this.label8]));
			w30.TopAttach = ((uint)(4));
			w30.BottomAttach = ((uint)(5));
			w30.XOptions = ((global::Gtk.AttachOptions)(4));
			w30.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.label9 = new global::Gtk.Label ();
			this.label9.Name = "label9";
			this.label9.Xalign = 1F;
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString ("Количество кабин:");
			this.table2.Add (this.label9);
			global::Gtk.Table.TableChild w31 = ((global::Gtk.Table.TableChild)(this.table2 [this.label9]));
			w31.TopAttach = ((uint)(1));
			w31.BottomAttach = ((uint)(2));
			w31.LeftAttach = ((uint)(2));
			w31.RightAttach = ((uint)(3));
			w31.XOptions = ((global::Gtk.AttachOptions)(4));
			w31.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.ycheckDispenser = new global::Gamma.GtkWidgets.yCheckButton ();
			this.ycheckDispenser.CanFocus = true;
			this.ycheckDispenser.Name = "ycheckDispenser";
			this.ycheckDispenser.Label = global::Mono.Unix.Catalog.GetString ("Наличие рукомойника");
			this.ycheckDispenser.DrawIndicator = true;
			this.ycheckDispenser.UseUnderline = true;
			this.vbox3.Add (this.ycheckDispenser);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.ycheckDispenser]));
			w32.Position = 0;
			w32.Expand = false;
			w32.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.ycheckAdditionalWater = new global::Gamma.GtkWidgets.yCheckButton ();
			this.ycheckAdditionalWater.CanFocus = true;
			this.ycheckAdditionalWater.Name = "ycheckAdditionalWater";
			this.ycheckAdditionalWater.Label = global::Mono.Unix.Catalog.GetString ("Дополнительная вода");
			this.ycheckAdditionalWater.DrawIndicator = true;
			this.ycheckAdditionalWater.UseUnderline = true;
			this.vbox3.Add (this.ycheckAdditionalWater);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.ycheckAdditionalWater]));
			w33.Position = 1;
			w33.Expand = false;
			w33.Fill = false;
			this.table2.Add (this.vbox3);
			global::Gtk.Table.TableChild w34 = ((global::Gtk.Table.TableChild)(this.table2 [this.vbox3]));
			w34.TopAttach = ((uint)(4));
			w34.BottomAttach = ((uint)(5));
			w34.LeftAttach = ((uint)(3));
			w34.RightAttach = ((uint)(4));
			w34.XOptions = ((global::Gtk.AttachOptions)(4));
			w34.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.ydateDelivery = new global::Gamma.Widgets.yDatePicker ();
			this.ydateDelivery.Events = ((global::Gdk.EventMask)(256));
			this.ydateDelivery.Name = "ydateDelivery";
			this.ydateDelivery.WithTime = true;
			this.ydateDelivery.Date = new global::System.DateTime (0);
			this.ydateDelivery.IsEditable = true;
			this.ydateDelivery.AutoSeparation = true;
			this.table2.Add (this.ydateDelivery);
			global::Gtk.Table.TableChild w35 = ((global::Gtk.Table.TableChild)(this.table2 [this.ydateDelivery]));
			w35.TopAttach = ((uint)(1));
			w35.BottomAttach = ((uint)(2));
			w35.LeftAttach = ((uint)(1));
			w35.RightAttach = ((uint)(2));
			w35.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.ydateRemoval = new global::Gamma.Widgets.yDatePicker ();
			this.ydateRemoval.Events = ((global::Gdk.EventMask)(256));
			this.ydateRemoval.Name = "ydateRemoval";
			this.ydateRemoval.WithTime = true;
			this.ydateRemoval.Date = new global::System.DateTime (0);
			this.ydateRemoval.IsEditable = true;
			this.ydateRemoval.AutoSeparation = true;
			this.table2.Add (this.ydateRemoval);
			global::Gtk.Table.TableChild w36 = ((global::Gtk.Table.TableChild)(this.table2 [this.ydateRemoval]));
			w36.TopAttach = ((uint)(2));
			w36.BottomAttach = ((uint)(3));
			w36.LeftAttach = ((uint)(1));
			w36.RightAttach = ((uint)(2));
			w36.XOptions = ((global::Gtk.AttachOptions)(4));
			w36.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.ylabel2 = new global::Gamma.GtkWidgets.yLabel ();
			this.ylabel2.Name = "ylabel2";
			this.ylabel2.Xalign = 1F;
			this.ylabel2.LabelProp = global::Mono.Unix.Catalog.GetString ("Стоимость за доставку:");
			this.table2.Add (this.ylabel2);
			global::Gtk.Table.TableChild w37 = ((global::Gtk.Table.TableChild)(this.table2 [this.ylabel2]));
			w37.TopAttach = ((uint)(3));
			w37.BottomAttach = ((uint)(4));
			w37.XOptions = ((global::Gtk.AttachOptions)(4));
			w37.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.ylabelTotalCost = new global::Gamma.GtkWidgets.yLabel ();
			this.ylabelTotalCost.Name = "ylabelTotalCost";
			this.ylabelTotalCost.Xalign = 0F;
			this.ylabelTotalCost.LabelProp = global::Mono.Unix.Catalog.GetString ("ylabel3");
			this.table2.Add (this.ylabelTotalCost);
			global::Gtk.Table.TableChild w38 = ((global::Gtk.Table.TableChild)(this.table2 [this.ylabelTotalCost]));
			w38.TopAttach = ((uint)(3));
			w38.BottomAttach = ((uint)(4));
			w38.LeftAttach = ((uint)(3));
			w38.RightAttach = ((uint)(4));
			w38.XOptions = ((global::Gtk.AttachOptions)(4));
			w38.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.yspinCabineCost = new global::Gamma.GtkWidgets.ySpinButton (0, 1000000, 100);
			this.yspinCabineCost.CanFocus = true;
			this.yspinCabineCost.Name = "yspinCabineCost";
			this.yspinCabineCost.Adjustment.PageIncrement = 1000;
			this.yspinCabineCost.ClimbRate = 1;
			this.yspinCabineCost.Digits = ((uint)(2));
			this.yspinCabineCost.Numeric = true;
			this.yspinCabineCost.ValueAsDecimal = 0m;
			this.yspinCabineCost.ValueAsInt = 0;
			this.table2.Add (this.yspinCabineCost);
			global::Gtk.Table.TableChild w39 = ((global::Gtk.Table.TableChild)(this.table2 [this.yspinCabineCost]));
			w39.TopAttach = ((uint)(2));
			w39.BottomAttach = ((uint)(3));
			w39.LeftAttach = ((uint)(3));
			w39.RightAttach = ((uint)(4));
			w39.XOptions = ((global::Gtk.AttachOptions)(4));
			w39.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.yspinCabineCount = new global::Gamma.GtkWidgets.ySpinButton (0, 100, 1);
			this.yspinCabineCount.CanFocus = true;
			this.yspinCabineCount.Name = "yspinCabineCount";
			this.yspinCabineCount.Adjustment.PageIncrement = 10;
			this.yspinCabineCount.ClimbRate = 1;
			this.yspinCabineCount.Numeric = true;
			this.yspinCabineCount.ValueAsDecimal = 0m;
			this.yspinCabineCount.ValueAsInt = 0;
			this.table2.Add (this.yspinCabineCount);
			global::Gtk.Table.TableChild w40 = ((global::Gtk.Table.TableChild)(this.table2 [this.yspinCabineCount]));
			w40.TopAttach = ((uint)(1));
			w40.BottomAttach = ((uint)(2));
			w40.LeftAttach = ((uint)(3));
			w40.RightAttach = ((uint)(4));
			w40.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.yspinDeliveryCost = new global::Gamma.GtkWidgets.ySpinButton (0, 1000000, 100);
			this.yspinDeliveryCost.CanFocus = true;
			this.yspinDeliveryCost.Name = "yspinDeliveryCost";
			this.yspinDeliveryCost.Adjustment.PageIncrement = 1000;
			this.yspinDeliveryCost.ClimbRate = 1;
			this.yspinDeliveryCost.Digits = ((uint)(2));
			this.yspinDeliveryCost.Numeric = true;
			this.yspinDeliveryCost.ValueAsDecimal = 0m;
			this.yspinDeliveryCost.ValueAsInt = 0;
			this.table2.Add (this.yspinDeliveryCost);
			global::Gtk.Table.TableChild w41 = ((global::Gtk.Table.TableChild)(this.table2 [this.yspinDeliveryCost]));
			w41.TopAttach = ((uint)(3));
			w41.BottomAttach = ((uint)(4));
			w41.LeftAttach = ((uint)(1));
			w41.RightAttach = ((uint)(2));
			w41.XOptions = ((global::Gtk.AttachOptions)(4));
			w41.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox1.Add (this.table2);
			global::Gtk.Box.BoxChild w42 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.table2]));
			w42.Position = 2;
			w42.Expand = false;
			w42.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.contractshortleaseadressesview1 = new global::BioGorod.Dialogs.Client.ContractShortLeaseAdressesView ();
			this.contractshortleaseadressesview1.Events = ((global::Gdk.EventMask)(256));
			this.contractshortleaseadressesview1.Name = "contractshortleaseadressesview1";
			this.vbox1.Add (this.contractshortleaseadressesview1);
			global::Gtk.Box.BoxChild w43 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.contractshortleaseadressesview1]));
			w43.Position = 3;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.buttonSave.Clicked += new global::System.EventHandler (this.OnButtonSaveClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler (this.OnButtonCancelClicked);
		}
	}
}
