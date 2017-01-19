
// This file has been generated by the GUI designer. Do not modify.
namespace BioGorod.Dialogs.Client
{
	public partial class CounterpartyDlg
	{
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Button buttonSave;
		
		private global::Gtk.Button buttonCancel;
		
		private global::Gtk.HSeparator hseparator1;
		
		private global::Gtk.HBox hbox19;
		
		private global::Gtk.RadioButton radioInfo;
		
		private global::Gtk.RadioButton radioContacts;
		
		private global::Gtk.RadioButton radioDetails;
		
		private global::Gtk.RadioButton radioContactPersons;
		
		private global::Gtk.RadioButton radioContracts;
		
		private global::Gtk.RadioButton radioDeliveryPoint;
		
		private global::Gtk.Notebook notebook1;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow4;
		
		private global::Gtk.Table table1;
		
		private global::Gamma.Widgets.yEnumComboBox comboDocumentsDelivery;
		
		private global::Gamma.GtkWidgets.yEntry entryFullName;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow6;
		
		private global::Gamma.GtkWidgets.yTextView dataComment;
		
		private global::Gtk.Label label3;
		
		private global::Gtk.Label label31;
		
		private global::Gtk.Label label4;
		
		private global::Gtk.Label label9;
		
		private global::Gtk.Label labelFullName;
		
		private global::Gtk.Label labelShort;
		
		private global::Gamma.Widgets.yEntryReference referencePaymentManager;
		
		private global::Gtk.VBox vboxCooperation;
		
		private global::Gamma.GtkWidgets.yCheckButton checkCustomer;
		
		private global::Gamma.GtkWidgets.yCheckButton checkSupplier;
		
		private global::Gamma.GtkWidgets.yCheckButton checkPartner;
		
		private global::Gamma.GtkWidgets.yCheckButton ycheckIsArchived;
		
		private global::Gamma.GtkWidgets.yEntry yentryName;
		
		private global::Gtk.Label label1;
		
		private global::Gtk.Table datatable2;
		
		private global::QSContacts.EmailsView emailsView;
		
		private global::Gtk.Label label11;
		
		private global::Gtk.Label label18;
		
		private global::QSContacts.PhonesView phonesView;
		
		private global::Gtk.Label label20;
		
		private global::Gtk.VBox vbox6;
		
		private global::Gtk.Table datatable4;
		
		private global::Gtk.Label label17;
		
		private global::Gtk.Label label27;
		
		private global::Gtk.Label label28;
		
		private global::Gtk.Label label29;
		
		private global::Gtk.Label label32;
		
		private global::Gtk.Label label7;
		
		private global::Gamma.Widgets.yValidatedEntry validatedentryOGRN;
		
		private global::Gamma.Widgets.yValidatedEntry validatedINN;
		
		private global::Gamma.Widgets.yValidatedEntry validatedKPP;
		
		private global::Gamma.GtkWidgets.yEntry yentrySignBaseOf;
		
		private global::Gamma.GtkWidgets.yEntry yentrySignFIO;
		
		private global::Gamma.GtkWidgets.yEntry yentrySignPost;
		
		private global::QSBanks.AccountsView accountsView;
		
		private global::Gtk.Label label21;
		
		private global::BioGorod.Dialogs.Client.CounterpartyContactsView contactsview1;
		
		private global::Gtk.Label label24;
		
		private global::BioGorod.Dialogs.Client.CounterpartyContractsView counterpartyContractsView;
		
		private global::Gtk.Label label34;
		
		private global::Gtk.VBox vbox9;
		
		private global::BioGorod.Dialogs.Client.CounterpartyAddressesView deliveryPointView;
		
		private global::Gtk.Label label40;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget BioGorod.Dialogs.Client.CounterpartyDlg
			global::Stetic.BinContainer.Attach (this);
			this.Name = "BioGorod.Dialogs.Client.CounterpartyDlg";
			// Container child BioGorod.Dialogs.Client.CounterpartyDlg.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.HeightRequest = 400;
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			this.vbox2.BorderWidth = ((uint)(6));
			// Container child vbox2.Gtk.Box+BoxChild
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
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-floppy", global::Gtk.IconSize.Menu);
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
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString ("Отмена");
			global::Gtk.Image w3 = new global::Gtk.Image ();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox1.Add (this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox2.Add (this.hbox1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox1]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hseparator1 = new global::Gtk.HSeparator ();
			this.hseparator1.Name = "hseparator1";
			this.vbox2.Add (this.hseparator1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hseparator1]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox19 = new global::Gtk.HBox ();
			this.hbox19.Name = "hbox19";
			this.hbox19.Spacing = 6;
			// Container child hbox19.Gtk.Box+BoxChild
			this.radioInfo = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Информация"));
			this.radioInfo.CanFocus = true;
			this.radioInfo.Name = "radioInfo";
			this.radioInfo.DrawIndicator = false;
			this.radioInfo.UseUnderline = true;
			this.radioInfo.Group = new global::GLib.SList (global::System.IntPtr.Zero);
			this.hbox19.Add (this.radioInfo);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox19 [this.radioInfo]));
			w7.Position = 0;
			// Container child hbox19.Gtk.Box+BoxChild
			this.radioContacts = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Контакты"));
			this.radioContacts.CanFocus = true;
			this.radioContacts.Name = "radioContacts";
			this.radioContacts.DrawIndicator = false;
			this.radioContacts.UseUnderline = true;
			this.radioContacts.Group = this.radioInfo.Group;
			this.hbox19.Add (this.radioContacts);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox19 [this.radioContacts]));
			w8.Position = 1;
			// Container child hbox19.Gtk.Box+BoxChild
			this.radioDetails = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Реквизиты"));
			this.radioDetails.CanFocus = true;
			this.radioDetails.Name = "radioDetails";
			this.radioDetails.DrawIndicator = false;
			this.radioDetails.UseUnderline = true;
			this.radioDetails.Group = this.radioInfo.Group;
			this.hbox19.Add (this.radioDetails);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox19 [this.radioDetails]));
			w9.Position = 2;
			// Container child hbox19.Gtk.Box+BoxChild
			this.radioContactPersons = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Контактные лица"));
			this.radioContactPersons.CanFocus = true;
			this.radioContactPersons.Name = "radioContactPersons";
			this.radioContactPersons.DrawIndicator = false;
			this.radioContactPersons.UseUnderline = true;
			this.radioContactPersons.Group = this.radioInfo.Group;
			this.hbox19.Add (this.radioContactPersons);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox19 [this.radioContactPersons]));
			w10.Position = 3;
			// Container child hbox19.Gtk.Box+BoxChild
			this.radioContracts = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Договора"));
			this.radioContracts.CanFocus = true;
			this.radioContracts.Name = "radioContracts";
			this.radioContracts.DrawIndicator = false;
			this.radioContracts.UseUnderline = true;
			this.radioContracts.Group = this.radioInfo.Group;
			this.hbox19.Add (this.radioContracts);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox19 [this.radioContracts]));
			w11.Position = 4;
			// Container child hbox19.Gtk.Box+BoxChild
			this.radioDeliveryPoint = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Адреса объектов"));
			this.radioDeliveryPoint.CanFocus = true;
			this.radioDeliveryPoint.Name = "radioDeliveryPoint";
			this.radioDeliveryPoint.DrawIndicator = false;
			this.radioDeliveryPoint.UseUnderline = true;
			this.radioDeliveryPoint.Group = this.radioInfo.Group;
			this.hbox19.Add (this.radioDeliveryPoint);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox19 [this.radioDeliveryPoint]));
			w12.Position = 5;
			this.vbox2.Add (this.hbox19);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox19]));
			w13.Position = 2;
			w13.Expand = false;
			w13.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.notebook1 = new global::Gtk.Notebook ();
			this.notebook1.CanFocus = true;
			this.notebook1.Name = "notebook1";
			this.notebook1.CurrentPage = 0;
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.GtkScrolledWindow4 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow4.Name = "GtkScrolledWindow4";
			this.GtkScrolledWindow4.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow4.Gtk.Container+ContainerChild
			global::Gtk.Viewport w14 = new global::Gtk.Viewport ();
			w14.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table (((uint)(5)), ((uint)(4)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			this.table1.BorderWidth = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.comboDocumentsDelivery = new global::Gamma.Widgets.yEnumComboBox ();
			this.comboDocumentsDelivery.Name = "comboDocumentsDelivery";
			this.comboDocumentsDelivery.ShowSpecialStateAll = false;
			this.comboDocumentsDelivery.ShowSpecialStateNot = false;
			this.comboDocumentsDelivery.UseShortTitle = false;
			this.comboDocumentsDelivery.DefaultFirst = true;
			this.table1.Add (this.comboDocumentsDelivery);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table1 [this.comboDocumentsDelivery]));
			w15.TopAttach = ((uint)(2));
			w15.BottomAttach = ((uint)(3));
			w15.LeftAttach = ((uint)(1));
			w15.RightAttach = ((uint)(2));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.entryFullName = new global::Gamma.GtkWidgets.yEntry ();
			this.entryFullName.CanFocus = true;
			this.entryFullName.Name = "entryFullName";
			this.entryFullName.IsEditable = true;
			this.entryFullName.MaxLength = 300;
			this.entryFullName.InvisibleChar = '●';
			this.table1.Add (this.entryFullName);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.table1 [this.entryFullName]));
			w16.TopAttach = ((uint)(1));
			w16.BottomAttach = ((uint)(2));
			w16.LeftAttach = ((uint)(1));
			w16.RightAttach = ((uint)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.GtkScrolledWindow6 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow6.Name = "GtkScrolledWindow6";
			this.GtkScrolledWindow6.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow6.Gtk.Container+ContainerChild
			this.dataComment = new global::Gamma.GtkWidgets.yTextView ();
			this.dataComment.CanFocus = true;
			this.dataComment.Name = "dataComment";
			this.GtkScrolledWindow6.Add (this.dataComment);
			this.table1.Add (this.GtkScrolledWindow6);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.table1 [this.GtkScrolledWindow6]));
			w18.TopAttach = ((uint)(4));
			w18.BottomAttach = ((uint)(5));
			w18.LeftAttach = ((uint)(1));
			w18.RightAttach = ((uint)(4));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Как отправляем документы:");
			this.table1.Add (this.label3);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.table1 [this.label3]));
			w19.TopAttach = ((uint)(2));
			w19.BottomAttach = ((uint)(3));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label31 = new global::Gtk.Label ();
			this.label31.Name = "label31";
			this.label31.Xalign = 1F;
			this.label31.Yalign = 0F;
			this.label31.LabelProp = global::Mono.Unix.Catalog.GetString ("Комментарий:");
			this.label31.Justify = ((global::Gtk.Justification)(1));
			this.table1.Add (this.label31);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.table1 [this.label31]));
			w20.TopAttach = ((uint)(4));
			w20.BottomAttach = ((uint)(5));
			w20.XOptions = ((global::Gtk.AttachOptions)(4));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Ответственный за контроль оплаты:");
			this.table1.Add (this.label4);
			global::Gtk.Table.TableChild w21 = ((global::Gtk.Table.TableChild)(this.table1 [this.label4]));
			w21.TopAttach = ((uint)(3));
			w21.BottomAttach = ((uint)(4));
			w21.XOptions = ((global::Gtk.AttachOptions)(4));
			w21.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label9 = new global::Gtk.Label ();
			this.label9.Name = "label9";
			this.label9.Xalign = 1F;
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString ("Тип контрагента:");
			this.table1.Add (this.label9);
			global::Gtk.Table.TableChild w22 = ((global::Gtk.Table.TableChild)(this.table1 [this.label9]));
			w22.TopAttach = ((uint)(2));
			w22.BottomAttach = ((uint)(3));
			w22.LeftAttach = ((uint)(2));
			w22.RightAttach = ((uint)(3));
			w22.XOptions = ((global::Gtk.AttachOptions)(4));
			w22.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelFullName = new global::Gtk.Label ();
			this.labelFullName.Name = "labelFullName";
			this.labelFullName.Xalign = 1F;
			this.labelFullName.LabelProp = global::Mono.Unix.Catalog.GetString ("Полное наименование:");
			this.table1.Add (this.labelFullName);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.table1 [this.labelFullName]));
			w23.TopAttach = ((uint)(1));
			w23.BottomAttach = ((uint)(2));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelShort = new global::Gtk.Label ();
			this.labelShort.Name = "labelShort";
			this.labelShort.Xalign = 1F;
			this.labelShort.LabelProp = global::Mono.Unix.Catalog.GetString ("Наименование:");
			this.table1.Add (this.labelShort);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.table1 [this.labelShort]));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.referencePaymentManager = new global::Gamma.Widgets.yEntryReference ();
			this.referencePaymentManager.Events = ((global::Gdk.EventMask)(256));
			this.referencePaymentManager.Name = "referencePaymentManager";
			this.table1.Add (this.referencePaymentManager);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.table1 [this.referencePaymentManager]));
			w25.TopAttach = ((uint)(3));
			w25.BottomAttach = ((uint)(4));
			w25.LeftAttach = ((uint)(1));
			w25.RightAttach = ((uint)(2));
			w25.XOptions = ((global::Gtk.AttachOptions)(4));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.vboxCooperation = new global::Gtk.VBox ();
			this.vboxCooperation.Name = "vboxCooperation";
			this.vboxCooperation.Spacing = 1;
			// Container child vboxCooperation.Gtk.Box+BoxChild
			this.checkCustomer = new global::Gamma.GtkWidgets.yCheckButton ();
			this.checkCustomer.CanFocus = true;
			this.checkCustomer.Name = "checkCustomer";
			this.checkCustomer.Label = global::Mono.Unix.Catalog.GetString ("Покупатель");
			this.checkCustomer.DrawIndicator = true;
			this.checkCustomer.UseUnderline = true;
			this.vboxCooperation.Add (this.checkCustomer);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.vboxCooperation [this.checkCustomer]));
			w26.Position = 0;
			w26.Expand = false;
			w26.Fill = false;
			// Container child vboxCooperation.Gtk.Box+BoxChild
			this.checkSupplier = new global::Gamma.GtkWidgets.yCheckButton ();
			this.checkSupplier.CanFocus = true;
			this.checkSupplier.Name = "checkSupplier";
			this.checkSupplier.Label = global::Mono.Unix.Catalog.GetString ("Поставщик");
			this.checkSupplier.DrawIndicator = true;
			this.checkSupplier.UseUnderline = true;
			this.vboxCooperation.Add (this.checkSupplier);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.vboxCooperation [this.checkSupplier]));
			w27.Position = 1;
			w27.Expand = false;
			w27.Fill = false;
			// Container child vboxCooperation.Gtk.Box+BoxChild
			this.checkPartner = new global::Gamma.GtkWidgets.yCheckButton ();
			this.checkPartner.CanFocus = true;
			this.checkPartner.Name = "checkPartner";
			this.checkPartner.Label = global::Mono.Unix.Catalog.GetString ("Партнер");
			this.checkPartner.DrawIndicator = true;
			this.checkPartner.UseUnderline = true;
			this.vboxCooperation.Add (this.checkPartner);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.vboxCooperation [this.checkPartner]));
			w28.Position = 2;
			w28.Expand = false;
			w28.Fill = false;
			this.table1.Add (this.vboxCooperation);
			global::Gtk.Table.TableChild w29 = ((global::Gtk.Table.TableChild)(this.table1 [this.vboxCooperation]));
			w29.TopAttach = ((uint)(2));
			w29.BottomAttach = ((uint)(4));
			w29.LeftAttach = ((uint)(3));
			w29.RightAttach = ((uint)(4));
			w29.XOptions = ((global::Gtk.AttachOptions)(4));
			w29.YOptions = ((global::Gtk.AttachOptions)(0));
			// Container child table1.Gtk.Table+TableChild
			this.ycheckIsArchived = new global::Gamma.GtkWidgets.yCheckButton ();
			global::Gtk.Tooltips w30 = new Gtk.Tooltips ();
			w30.SetTip (this.ycheckIsArchived, "Больше не работаем с этим клиентом", "Больше не работаем с этим клиентом");
			this.ycheckIsArchived.CanFocus = true;
			this.ycheckIsArchived.Name = "ycheckIsArchived";
			this.ycheckIsArchived.Label = global::Mono.Unix.Catalog.GetString ("Архивный");
			this.ycheckIsArchived.DrawIndicator = true;
			this.ycheckIsArchived.UseUnderline = true;
			this.table1.Add (this.ycheckIsArchived);
			global::Gtk.Table.TableChild w31 = ((global::Gtk.Table.TableChild)(this.table1 [this.ycheckIsArchived]));
			w31.TopAttach = ((uint)(3));
			w31.BottomAttach = ((uint)(4));
			w31.LeftAttach = ((uint)(2));
			w31.RightAttach = ((uint)(3));
			w31.XOptions = ((global::Gtk.AttachOptions)(4));
			w31.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yentryName = new global::Gamma.GtkWidgets.yEntry ();
			this.yentryName.CanFocus = true;
			this.yentryName.Name = "yentryName";
			this.yentryName.IsEditable = true;
			this.yentryName.InvisibleChar = '●';
			this.table1.Add (this.yentryName);
			global::Gtk.Table.TableChild w32 = ((global::Gtk.Table.TableChild)(this.table1 [this.yentryName]));
			w32.LeftAttach = ((uint)(1));
			w32.RightAttach = ((uint)(4));
			w32.XOptions = ((global::Gtk.AttachOptions)(4));
			w32.YOptions = ((global::Gtk.AttachOptions)(4));
			w14.Add (this.table1);
			this.GtkScrolledWindow4.Add (w14);
			this.notebook1.Add (this.GtkScrolledWindow4);
			// Notebook tab
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Информация");
			this.notebook1.SetTabLabel (this.GtkScrolledWindow4, this.label1);
			this.label1.ShowAll ();
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.datatable2 = new global::Gtk.Table (((uint)(2)), ((uint)(2)), false);
			this.datatable2.Name = "datatable2";
			this.datatable2.RowSpacing = ((uint)(6));
			this.datatable2.ColumnSpacing = ((uint)(6));
			this.datatable2.BorderWidth = ((uint)(6));
			// Container child datatable2.Gtk.Table+TableChild
			this.emailsView = new global::QSContacts.EmailsView ();
			this.emailsView.Events = ((global::Gdk.EventMask)(256));
			this.emailsView.Name = "emailsView";
			this.datatable2.Add (this.emailsView);
			global::Gtk.Table.TableChild w36 = ((global::Gtk.Table.TableChild)(this.datatable2 [this.emailsView]));
			w36.TopAttach = ((uint)(1));
			w36.BottomAttach = ((uint)(2));
			w36.LeftAttach = ((uint)(1));
			w36.RightAttach = ((uint)(2));
			w36.XOptions = ((global::Gtk.AttachOptions)(4));
			w36.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable2.Gtk.Table+TableChild
			this.label11 = new global::Gtk.Label ();
			this.label11.Name = "label11";
			this.label11.Xalign = 1F;
			this.label11.LabelProp = global::Mono.Unix.Catalog.GetString ("Общий e-mail:");
			this.datatable2.Add (this.label11);
			global::Gtk.Table.TableChild w37 = ((global::Gtk.Table.TableChild)(this.datatable2 [this.label11]));
			w37.TopAttach = ((uint)(1));
			w37.BottomAttach = ((uint)(2));
			w37.XOptions = ((global::Gtk.AttachOptions)(4));
			w37.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable2.Gtk.Table+TableChild
			this.label18 = new global::Gtk.Label ();
			this.label18.Name = "label18";
			this.label18.Xalign = 1F;
			this.label18.LabelProp = global::Mono.Unix.Catalog.GetString ("Общие телефоны:");
			this.datatable2.Add (this.label18);
			global::Gtk.Table.TableChild w38 = ((global::Gtk.Table.TableChild)(this.datatable2 [this.label18]));
			w38.XOptions = ((global::Gtk.AttachOptions)(4));
			w38.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable2.Gtk.Table+TableChild
			this.phonesView = new global::QSContacts.PhonesView ();
			this.phonesView.Events = ((global::Gdk.EventMask)(256));
			this.phonesView.Name = "phonesView";
			this.datatable2.Add (this.phonesView);
			global::Gtk.Table.TableChild w39 = ((global::Gtk.Table.TableChild)(this.datatable2 [this.phonesView]));
			w39.LeftAttach = ((uint)(1));
			w39.RightAttach = ((uint)(2));
			w39.XOptions = ((global::Gtk.AttachOptions)(4));
			w39.YOptions = ((global::Gtk.AttachOptions)(4));
			this.notebook1.Add (this.datatable2);
			global::Gtk.Notebook.NotebookChild w40 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.datatable2]));
			w40.Position = 1;
			// Notebook tab
			this.label20 = new global::Gtk.Label ();
			this.label20.Name = "label20";
			this.label20.LabelProp = global::Mono.Unix.Catalog.GetString ("Контакты");
			this.notebook1.SetTabLabel (this.datatable2, this.label20);
			this.label20.ShowAll ();
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.vbox6 = new global::Gtk.VBox ();
			this.vbox6.Name = "vbox6";
			this.vbox6.Spacing = 6;
			this.vbox6.BorderWidth = ((uint)(6));
			// Container child vbox6.Gtk.Box+BoxChild
			this.datatable4 = new global::Gtk.Table (((uint)(3)), ((uint)(4)), false);
			this.datatable4.Name = "datatable4";
			this.datatable4.RowSpacing = ((uint)(6));
			this.datatable4.ColumnSpacing = ((uint)(6));
			// Container child datatable4.Gtk.Table+TableChild
			this.label17 = new global::Gtk.Label ();
			this.label17.Name = "label17";
			this.label17.Xalign = 1F;
			this.label17.LabelProp = global::Mono.Unix.Catalog.GetString ("В лице:");
			this.datatable4.Add (this.label17);
			global::Gtk.Table.TableChild w41 = ((global::Gtk.Table.TableChild)(this.datatable4 [this.label17]));
			w41.TopAttach = ((uint)(1));
			w41.BottomAttach = ((uint)(2));
			w41.LeftAttach = ((uint)(2));
			w41.RightAttach = ((uint)(3));
			w41.XOptions = ((global::Gtk.AttachOptions)(4));
			w41.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable4.Gtk.Table+TableChild
			this.label27 = new global::Gtk.Label ();
			this.label27.Name = "label27";
			this.label27.Xalign = 1F;
			this.label27.LabelProp = global::Mono.Unix.Catalog.GetString ("ИНН:");
			this.datatable4.Add (this.label27);
			global::Gtk.Table.TableChild w42 = ((global::Gtk.Table.TableChild)(this.datatable4 [this.label27]));
			w42.XOptions = ((global::Gtk.AttachOptions)(4));
			w42.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable4.Gtk.Table+TableChild
			this.label28 = new global::Gtk.Label ();
			this.label28.Name = "label28";
			this.label28.Xalign = 1F;
			this.label28.LabelProp = global::Mono.Unix.Catalog.GetString ("КПП:");
			this.datatable4.Add (this.label28);
			global::Gtk.Table.TableChild w43 = ((global::Gtk.Table.TableChild)(this.datatable4 [this.label28]));
			w43.TopAttach = ((uint)(1));
			w43.BottomAttach = ((uint)(2));
			w43.XOptions = ((global::Gtk.AttachOptions)(4));
			w43.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable4.Gtk.Table+TableChild
			this.label29 = new global::Gtk.Label ();
			this.label29.Name = "label29";
			this.label29.Xalign = 1F;
			this.label29.LabelProp = global::Mono.Unix.Catalog.GetString ("ОГРН:");
			this.datatable4.Add (this.label29);
			global::Gtk.Table.TableChild w44 = ((global::Gtk.Table.TableChild)(this.datatable4 [this.label29]));
			w44.TopAttach = ((uint)(2));
			w44.BottomAttach = ((uint)(3));
			w44.XOptions = ((global::Gtk.AttachOptions)(4));
			w44.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable4.Gtk.Table+TableChild
			this.label32 = new global::Gtk.Label ();
			this.label32.Name = "label32";
			this.label32.Xalign = 1F;
			this.label32.LabelProp = global::Mono.Unix.Catalog.GetString ("На основании:");
			this.datatable4.Add (this.label32);
			global::Gtk.Table.TableChild w45 = ((global::Gtk.Table.TableChild)(this.datatable4 [this.label32]));
			w45.TopAttach = ((uint)(2));
			w45.BottomAttach = ((uint)(3));
			w45.LeftAttach = ((uint)(2));
			w45.RightAttach = ((uint)(3));
			w45.XOptions = ((global::Gtk.AttachOptions)(4));
			w45.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable4.Gtk.Table+TableChild
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.Xalign = 1F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("ФИО для договора:");
			this.datatable4.Add (this.label7);
			global::Gtk.Table.TableChild w46 = ((global::Gtk.Table.TableChild)(this.datatable4 [this.label7]));
			w46.LeftAttach = ((uint)(2));
			w46.RightAttach = ((uint)(3));
			w46.XOptions = ((global::Gtk.AttachOptions)(4));
			w46.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable4.Gtk.Table+TableChild
			this.validatedentryOGRN = new global::Gamma.Widgets.yValidatedEntry ();
			this.validatedentryOGRN.CanFocus = true;
			this.validatedentryOGRN.Name = "validatedentryOGRN";
			this.validatedentryOGRN.IsEditable = true;
			this.validatedentryOGRN.MaxLength = 13;
			this.validatedentryOGRN.InvisibleChar = '●';
			this.datatable4.Add (this.validatedentryOGRN);
			global::Gtk.Table.TableChild w47 = ((global::Gtk.Table.TableChild)(this.datatable4 [this.validatedentryOGRN]));
			w47.TopAttach = ((uint)(2));
			w47.BottomAttach = ((uint)(3));
			w47.LeftAttach = ((uint)(1));
			w47.RightAttach = ((uint)(2));
			w47.XOptions = ((global::Gtk.AttachOptions)(4));
			w47.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable4.Gtk.Table+TableChild
			this.validatedINN = new global::Gamma.Widgets.yValidatedEntry ();
			this.validatedINN.CanFocus = true;
			this.validatedINN.Name = "validatedINN";
			this.validatedINN.IsEditable = true;
			this.validatedINN.MaxLength = 12;
			this.validatedINN.InvisibleChar = '●';
			this.datatable4.Add (this.validatedINN);
			global::Gtk.Table.TableChild w48 = ((global::Gtk.Table.TableChild)(this.datatable4 [this.validatedINN]));
			w48.LeftAttach = ((uint)(1));
			w48.RightAttach = ((uint)(2));
			w48.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable4.Gtk.Table+TableChild
			this.validatedKPP = new global::Gamma.Widgets.yValidatedEntry ();
			this.validatedKPP.CanFocus = true;
			this.validatedKPP.Name = "validatedKPP";
			this.validatedKPP.IsEditable = true;
			this.validatedKPP.MaxLength = 9;
			this.validatedKPP.InvisibleChar = '●';
			this.datatable4.Add (this.validatedKPP);
			global::Gtk.Table.TableChild w49 = ((global::Gtk.Table.TableChild)(this.datatable4 [this.validatedKPP]));
			w49.TopAttach = ((uint)(1));
			w49.BottomAttach = ((uint)(2));
			w49.LeftAttach = ((uint)(1));
			w49.RightAttach = ((uint)(2));
			w49.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable4.Gtk.Table+TableChild
			this.yentrySignBaseOf = new global::Gamma.GtkWidgets.yEntry ();
			this.yentrySignBaseOf.CanFocus = true;
			this.yentrySignBaseOf.Name = "yentrySignBaseOf";
			this.yentrySignBaseOf.IsEditable = true;
			this.yentrySignBaseOf.InvisibleChar = '●';
			this.datatable4.Add (this.yentrySignBaseOf);
			global::Gtk.Table.TableChild w50 = ((global::Gtk.Table.TableChild)(this.datatable4 [this.yentrySignBaseOf]));
			w50.TopAttach = ((uint)(2));
			w50.BottomAttach = ((uint)(3));
			w50.LeftAttach = ((uint)(3));
			w50.RightAttach = ((uint)(4));
			w50.XOptions = ((global::Gtk.AttachOptions)(4));
			w50.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable4.Gtk.Table+TableChild
			this.yentrySignFIO = new global::Gamma.GtkWidgets.yEntry ();
			this.yentrySignFIO.CanFocus = true;
			this.yentrySignFIO.Name = "yentrySignFIO";
			this.yentrySignFIO.IsEditable = true;
			this.yentrySignFIO.InvisibleChar = '●';
			this.datatable4.Add (this.yentrySignFIO);
			global::Gtk.Table.TableChild w51 = ((global::Gtk.Table.TableChild)(this.datatable4 [this.yentrySignFIO]));
			w51.LeftAttach = ((uint)(3));
			w51.RightAttach = ((uint)(4));
			w51.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable4.Gtk.Table+TableChild
			this.yentrySignPost = new global::Gamma.GtkWidgets.yEntry ();
			this.yentrySignPost.CanFocus = true;
			this.yentrySignPost.Name = "yentrySignPost";
			this.yentrySignPost.IsEditable = true;
			this.yentrySignPost.InvisibleChar = '●';
			this.datatable4.Add (this.yentrySignPost);
			global::Gtk.Table.TableChild w52 = ((global::Gtk.Table.TableChild)(this.datatable4 [this.yentrySignPost]));
			w52.TopAttach = ((uint)(1));
			w52.BottomAttach = ((uint)(2));
			w52.LeftAttach = ((uint)(3));
			w52.RightAttach = ((uint)(4));
			w52.XOptions = ((global::Gtk.AttachOptions)(4));
			w52.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox6.Add (this.datatable4);
			global::Gtk.Box.BoxChild w53 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.datatable4]));
			w53.Position = 0;
			w53.Expand = false;
			w53.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.accountsView = new global::QSBanks.AccountsView ();
			this.accountsView.Events = ((global::Gdk.EventMask)(256));
			this.accountsView.Name = "accountsView";
			this.vbox6.Add (this.accountsView);
			global::Gtk.Box.BoxChild w54 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.accountsView]));
			w54.Position = 1;
			this.notebook1.Add (this.vbox6);
			global::Gtk.Notebook.NotebookChild w55 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.vbox6]));
			w55.Position = 2;
			// Notebook tab
			this.label21 = new global::Gtk.Label ();
			this.label21.Name = "label21";
			this.label21.LabelProp = global::Mono.Unix.Catalog.GetString ("Реквизиты");
			this.notebook1.SetTabLabel (this.vbox6, this.label21);
			this.label21.ShowAll ();
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.contactsview1 = new global::BioGorod.Dialogs.Client.CounterpartyContactsView ();
			this.contactsview1.Events = ((global::Gdk.EventMask)(256));
			this.contactsview1.Name = "contactsview1";
			this.notebook1.Add (this.contactsview1);
			global::Gtk.Notebook.NotebookChild w56 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.contactsview1]));
			w56.Position = 3;
			// Notebook tab
			this.label24 = new global::Gtk.Label ();
			this.label24.Name = "label24";
			this.label24.LabelProp = global::Mono.Unix.Catalog.GetString ("Контактные лица");
			this.notebook1.SetTabLabel (this.contactsview1, this.label24);
			this.label24.ShowAll ();
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.counterpartyContractsView = new global::BioGorod.Dialogs.Client.CounterpartyContractsView ();
			this.counterpartyContractsView.Events = ((global::Gdk.EventMask)(256));
			this.counterpartyContractsView.Name = "counterpartyContractsView";
			this.notebook1.Add (this.counterpartyContractsView);
			global::Gtk.Notebook.NotebookChild w57 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.counterpartyContractsView]));
			w57.Position = 4;
			// Notebook tab
			this.label34 = new global::Gtk.Label ();
			this.label34.Name = "label34";
			this.label34.LabelProp = global::Mono.Unix.Catalog.GetString ("Договор");
			this.notebook1.SetTabLabel (this.counterpartyContractsView, this.label34);
			this.label34.ShowAll ();
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.vbox9 = new global::Gtk.VBox ();
			this.vbox9.Name = "vbox9";
			this.vbox9.Spacing = 6;
			this.vbox9.BorderWidth = ((uint)(6));
			// Container child vbox9.Gtk.Box+BoxChild
			this.deliveryPointView = new global::BioGorod.Dialogs.Client.CounterpartyAddressesView ();
			this.deliveryPointView.Events = ((global::Gdk.EventMask)(256));
			this.deliveryPointView.Name = "deliveryPointView";
			this.vbox9.Add (this.deliveryPointView);
			global::Gtk.Box.BoxChild w58 = ((global::Gtk.Box.BoxChild)(this.vbox9 [this.deliveryPointView]));
			w58.Position = 0;
			this.notebook1.Add (this.vbox9);
			global::Gtk.Notebook.NotebookChild w59 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.vbox9]));
			w59.Position = 5;
			// Notebook tab
			this.label40 = new global::Gtk.Label ();
			this.label40.Name = "label40";
			this.label40.LabelProp = global::Mono.Unix.Catalog.GetString ("Точки доставки");
			this.notebook1.SetTabLabel (this.vbox9, this.label40);
			this.label40.ShowAll ();
			this.vbox2.Add (this.notebook1);
			global::Gtk.Box.BoxChild w60 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.notebook1]));
			w60.Position = 3;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.buttonSave.Clicked += new global::System.EventHandler (this.OnButtonSaveClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler (this.OnButtonCancelClicked);
			this.radioInfo.Toggled += new global::System.EventHandler (this.OnRadioInfoToggled);
			this.radioContacts.Toggled += new global::System.EventHandler (this.OnRadioContactsToggled);
			this.radioDetails.Toggled += new global::System.EventHandler (this.OnRadioDetailsToggled);
			this.radioContactPersons.Toggled += new global::System.EventHandler (this.OnRadioContactPersonsToggled);
			this.radioContracts.Toggled += new global::System.EventHandler (this.OnRadioContractsToggled);
			this.radioDeliveryPoint.Toggled += new global::System.EventHandler (this.OnRadioDeliveryPointToggled);
			this.yentrySignPost.FocusInEvent += new global::Gtk.FocusInEventHandler (this.OnYentrySignPostFocusInEvent);
			this.yentrySignBaseOf.FocusInEvent += new global::Gtk.FocusInEventHandler (this.OnYentrySignBaseOfFocusInEvent);
		}
	}
}
