
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	
	private global::Gtk.Action Action;
	
	private global::Gtk.Action ActionPassword;
	
	private global::Gtk.Action ActionUsers;
	
	private global::Gtk.Action quitAction;
	
	private global::Gtk.Action Action12;
	
	private global::Gtk.Action Action3;
	
	private global::Gtk.Action ActionHistory;
	
	private global::Gtk.Action ActionCheckUpdate;
	
	private global::Gtk.Action aboutAction;
	
	private global::Gtk.Action Action7;
	
	private global::Gtk.Action Action11;
	
	private global::Gtk.Action Action6;
	
	private global::Gtk.Action ActionBanks;
	
	private global::Gtk.Action ActionBankUpdate;
	
	private global::Gtk.Action ActionOrganization;
	
	private global::Gtk.Action ActionEmployee;
	
	private global::Gtk.Action ActionCars;
	
	private global::Gtk.Action ActionCounterparty;
	
	private global::Gtk.Action ActionAddress;
	
	private global::Gtk.Action ActionPhoneType;
	
	private global::Gtk.Action ActionEMail;
	
	private global::Gtk.Action ActionPost;
	
	private global::Gtk.VBox vbox1;
	
	private global::Gtk.MenuBar menubar1;
	
	private global::QSTDI.TdiNotebook tdiMain;
	
	private global::Gtk.Statusbar statusbar1;
	
	private global::Gtk.Label labelStatus;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.Action = new global::Gtk.Action ("Action", global::Mono.Unix.Catalog.GetString ("База"), null, null);
		this.Action.ShortLabel = global::Mono.Unix.Catalog.GetString ("База");
		w1.Add (this.Action, null);
		this.ActionPassword = new global::Gtk.Action ("ActionPassword", global::Mono.Unix.Catalog.GetString ("Изменить пароль"), null, null);
		this.ActionPassword.ShortLabel = global::Mono.Unix.Catalog.GetString ("Изменить пароль");
		w1.Add (this.ActionPassword, null);
		this.ActionUsers = new global::Gtk.Action ("ActionUsers", global::Mono.Unix.Catalog.GetString ("Пользователи"), null, "gtk-preferences");
		this.ActionUsers.ShortLabel = global::Mono.Unix.Catalog.GetString ("Пользователи");
		w1.Add (this.ActionUsers, null);
		this.quitAction = new global::Gtk.Action ("quitAction", global::Mono.Unix.Catalog.GetString ("В_ыход"), null, "gtk-quit");
		this.quitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("В_ыход");
		w1.Add (this.quitAction, null);
		this.Action12 = new global::Gtk.Action ("Action12", global::Mono.Unix.Catalog.GetString ("Справочники"), null, null);
		this.Action12.ShortLabel = global::Mono.Unix.Catalog.GetString ("Справочники");
		w1.Add (this.Action12, null);
		this.Action3 = new global::Gtk.Action ("Action3", global::Mono.Unix.Catalog.GetString ("Справка"), null, null);
		this.Action3.ShortLabel = global::Mono.Unix.Catalog.GetString ("Справка");
		w1.Add (this.Action3, null);
		this.ActionHistory = new global::Gtk.Action ("ActionHistory", global::Mono.Unix.Catalog.GetString ("История версий"), null, null);
		this.ActionHistory.Sensitive = false;
		this.ActionHistory.ShortLabel = global::Mono.Unix.Catalog.GetString ("История версий");
		w1.Add (this.ActionHistory, null);
		this.ActionCheckUpdate = new global::Gtk.Action ("ActionCheckUpdate", global::Mono.Unix.Catalog.GetString ("Проверить обновление..."), null, "gtk-go-down");
		this.ActionCheckUpdate.ShortLabel = global::Mono.Unix.Catalog.GetString ("Проверить обновление...");
		w1.Add (this.ActionCheckUpdate, null);
		this.aboutAction = new global::Gtk.Action ("aboutAction", global::Mono.Unix.Catalog.GetString ("_О программе"), null, "gtk-about");
		this.aboutAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_О программе");
		w1.Add (this.aboutAction, null);
		this.Action7 = new global::Gtk.Action ("Action7", global::Mono.Unix.Catalog.GetString ("Наша организация"), null, null);
		this.Action7.ShortLabel = global::Mono.Unix.Catalog.GetString ("Наша организация");
		w1.Add (this.Action7, null);
		this.Action11 = new global::Gtk.Action ("Action11", global::Mono.Unix.Catalog.GetString ("Клиенты"), null, null);
		this.Action11.ShortLabel = global::Mono.Unix.Catalog.GetString ("Клиенты");
		w1.Add (this.Action11, null);
		this.Action6 = new global::Gtk.Action ("Action6", global::Mono.Unix.Catalog.GetString ("Банки"), null, null);
		this.Action6.ShortLabel = global::Mono.Unix.Catalog.GetString ("Банки");
		w1.Add (this.Action6, null);
		this.ActionBanks = new global::Gtk.Action ("ActionBanks", global::Mono.Unix.Catalog.GetString ("Банки РФ"), null, null);
		this.ActionBanks.ShortLabel = global::Mono.Unix.Catalog.GetString ("Банки РФ");
		w1.Add (this.ActionBanks, null);
		this.ActionBankUpdate = new global::Gtk.Action ("ActionBankUpdate", global::Mono.Unix.Catalog.GetString ("Обновить банки с сайта РБК"), null, null);
		this.ActionBankUpdate.ShortLabel = global::Mono.Unix.Catalog.GetString ("Обновить банки с сайта РБК");
		w1.Add (this.ActionBankUpdate, null);
		this.ActionOrganization = new global::Gtk.Action ("ActionOrganization", global::Mono.Unix.Catalog.GetString ("Организации"), null, null);
		this.ActionOrganization.ShortLabel = global::Mono.Unix.Catalog.GetString ("Организации");
		w1.Add (this.ActionOrganization, null);
		this.ActionEmployee = new global::Gtk.Action ("ActionEmployee", global::Mono.Unix.Catalog.GetString ("Сотрудники"), null, null);
		this.ActionEmployee.ShortLabel = global::Mono.Unix.Catalog.GetString ("Сотрудники");
		w1.Add (this.ActionEmployee, null);
		this.ActionCars = new global::Gtk.Action ("ActionCars", global::Mono.Unix.Catalog.GetString ("Автомобили"), null, null);
		this.ActionCars.ShortLabel = global::Mono.Unix.Catalog.GetString ("Автомобили");
		w1.Add (this.ActionCars, null);
		this.ActionCounterparty = new global::Gtk.Action ("ActionCounterparty", global::Mono.Unix.Catalog.GetString ("Контрагенты"), null, null);
		this.ActionCounterparty.ShortLabel = global::Mono.Unix.Catalog.GetString ("Контрагенты");
		w1.Add (this.ActionCounterparty, null);
		this.ActionAddress = new global::Gtk.Action ("ActionAddress", global::Mono.Unix.Catalog.GetString ("Адреса объектов"), null, null);
		this.ActionAddress.ShortLabel = global::Mono.Unix.Catalog.GetString ("Адреса объектов");
		w1.Add (this.ActionAddress, null);
		this.ActionPhoneType = new global::Gtk.Action ("ActionPhoneType", global::Mono.Unix.Catalog.GetString ("Типы телефонов"), null, null);
		this.ActionPhoneType.ShortLabel = global::Mono.Unix.Catalog.GetString ("Типы телефонов");
		w1.Add (this.ActionPhoneType, null);
		this.ActionEMail = new global::Gtk.Action ("ActionEMail", global::Mono.Unix.Catalog.GetString ("Типы E-mail-ов"), null, null);
		this.ActionEMail.ShortLabel = global::Mono.Unix.Catalog.GetString ("Типы E-mail-ов");
		w1.Add (this.ActionEMail, null);
		this.ActionPost = new global::Gtk.Action ("ActionPost", global::Mono.Unix.Catalog.GetString ("Должности"), null, null);
		this.ActionPost.ShortLabel = global::Mono.Unix.Catalog.GetString ("Должности");
		w1.Add (this.ActionPost, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><menubar name='menubar1'><menu name='Action' action='Action'><menuitem name='ActionPassword' action='ActionPassword'/><menuitem name='ActionUsers' action='ActionUsers'/><separator/><menuitem name='quitAction' action='quitAction'/></menu><menu name='Action12' action='Action12'><menu name='Action7' action='Action7'><menuitem name='ActionOrganization' action='ActionOrganization'/><menuitem name='ActionEmployee' action='ActionEmployee'/><menuitem name='ActionCars' action='ActionCars'/></menu><menu name='Action11' action='Action11'><menuitem name='ActionCounterparty' action='ActionCounterparty'/><menuitem name='ActionAddress' action='ActionAddress'/><separator/><menuitem name='ActionPost' action='ActionPost'/><separator/><menuitem name='ActionPhoneType' action='ActionPhoneType'/><menuitem name='ActionEMail' action='ActionEMail'/></menu><menu name='Action6' action='Action6'><menuitem name='ActionBanks' action='ActionBanks'/><menuitem name='ActionBankUpdate' action='ActionBankUpdate'/></menu></menu><menu name='Action3' action='Action3'><menuitem name='ActionHistory' action='ActionHistory'/><menuitem name='ActionCheckUpdate' action='ActionCheckUpdate'/><separator/><menuitem name='aboutAction' action='aboutAction'/></menu></menubar></ui>");
		this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar1")));
		this.menubar1.Name = "menubar1";
		this.vbox1.Add (this.menubar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.menubar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.tdiMain = new global::QSTDI.TdiNotebook ();
		this.tdiMain.Name = "tdiMain";
		this.tdiMain.CurrentPage = 0;
		this.tdiMain.ShowTabs = false;
		this.vbox1.Add (this.tdiMain);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.tdiMain]));
		w3.Position = 1;
		// Container child vbox1.Gtk.Box+BoxChild
		this.statusbar1 = new global::Gtk.Statusbar ();
		this.statusbar1.Name = "statusbar1";
		this.statusbar1.Spacing = 6;
		// Container child statusbar1.Gtk.Box+BoxChild
		this.labelStatus = new global::Gtk.Label ();
		this.labelStatus.Name = "labelStatus";
		this.labelStatus.LabelProp = global::Mono.Unix.Catalog.GetString ("label1");
		this.statusbar1.Add (this.labelStatus);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.statusbar1 [this.labelStatus]));
		w4.Position = 2;
		w4.Expand = false;
		w4.Fill = false;
		this.vbox1.Add (this.statusbar1);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.statusbar1]));
		w5.Position = 2;
		w5.Expand = false;
		w5.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 568;
		this.DefaultHeight = 300;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.ActionPassword.Activated += new global::System.EventHandler (this.OnActionPasswordActivated);
		this.ActionUsers.Activated += new global::System.EventHandler (this.OnActionUsersActivated);
		this.quitAction.Activated += new global::System.EventHandler (this.OnQuitActionActivated);
		this.ActionHistory.Activated += new global::System.EventHandler (this.OnActionHistoryActivated);
		this.ActionCheckUpdate.Activated += new global::System.EventHandler (this.OnActionCheckUpdateActivated);
		this.aboutAction.Activated += new global::System.EventHandler (this.OnAboutActionActivated);
		this.ActionBanks.Activated += new global::System.EventHandler (this.OnActionBanksActivated);
		this.ActionBankUpdate.Activated += new global::System.EventHandler (this.OnActionBankUpdateActivated);
		this.ActionOrganization.Activated += new global::System.EventHandler (this.OnActionOrganizationActivated);
		this.ActionEmployee.Activated += new global::System.EventHandler (this.OnActionEmployeeActivated);
		this.ActionPhoneType.Activated += new global::System.EventHandler (this.OnActionPhoneTypeActivated);
		this.ActionEMail.Activated += new global::System.EventHandler (this.OnEMailActionActivated);
		this.ActionPost.Activated += new global::System.EventHandler (this.OnActionPostActivated);
	}
}
