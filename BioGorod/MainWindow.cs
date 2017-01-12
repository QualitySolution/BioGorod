using System;
using Gtk;
using QSProjectsLib;
using QSTDI;
using QSSupportLib;
using QSUpdater;
using QSBanks;
using QSOrmProject;
using QSContacts;

public partial class MainWindow: Gtk.Window
{
	public MainWindow()
		: base(Gtk.WindowType.Toplevel)
	{
		Build();
		this.KeyReleaseEvent += ClipboardWorkaround.HandleKeyReleaseEvent;
		TDIMain.MainNotebook = tdiMain;
		this.KeyReleaseEvent += TDIMain.TDIHandleKeyReleaseEvent;
		//Передаем лебл
		QSMain.StatusBarLabel = labelStatus;
		this.Title = MainSupport.GetTitle ();
		QSMain.MakeNewStatusTargetForNlog ();

		MainSupport.LoadBaseParameters ();

		MainUpdater.RunCheckVersion (true, true, true);
		QSMain.CheckServer (this); // Проверяем настройки сервера

		if (QSMain.User.Login == "root") {
			string Message = "Вы зашли в программу под администратором базы данных. У вас есть только возможность создавать других пользователей.";
			MessageDialog md = new MessageDialog (this, DialogFlags.DestroyWithParent,
				MessageType.Info, 
				ButtonsType.Ok,
				Message);
			md.Run ();
			md.Destroy ();
			Users WinUser = new Users ();
			WinUser.Show ();
			WinUser.Run ();
			WinUser.Destroy ();
			return;
		}

		ActionUsers.Sensitive = QSMain.User.Admin;

		BanksUpdater.Update (false);
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		if (tdiMain.CloseAllTabs ()) {
			a.RetVal = false;
			Application.Quit ();
		} else {
			a.RetVal = true;
		}
	}

	protected void OnActionPasswordActivated(object sender, EventArgs e)
	{
		QSMain.User.ChangeUserPassword (this);
	}
		
	protected void OnActionUsersActivated(object sender, EventArgs e)
	{
		Users winUsers = new Users ();
		winUsers.Show ();
		winUsers.Run ();
		winUsers.Destroy ();
	}

	protected void OnQuitActionActivated(object sender, EventArgs e)
	{
		if (tdiMain.CloseAllTabs ()) {
			Application.Quit ();
		}
	}

	protected void OnAboutActionActivated(object sender, EventArgs e)
	{
		QSMain.RunAboutDialog ();
	}

	protected void OnActionCheckUpdateActivated(object sender, EventArgs e)
	{
		CheckUpdate.StartCheckUpdateThread (UpdaterFlags.ShowAnyway);
	}

	protected void OnActionHistoryActivated(object sender, EventArgs e)
	{
		QSMain.RunChangeLogDlg (this);
	}

	protected void OnActionBanksActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<Bank>(),
			() => new OrmReference(typeof(Bank))
		);
	}

	protected void OnActionBankUpdateActivated(object sender, EventArgs e)
	{
		BanksUpdater.Update (true);
	}

	protected void OnActionPostActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<Post>(),
			() => new OrmReference(typeof(Post))
		);
	}
	protected void OnEMailActionActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<EmailType>(),
			() => new OrmReference(typeof(EmailType))
		);
	}

	protected void OnActionPhoneTypeActivated(object sender, EventArgs e)
	{
		tdiMain.OpenTab(
			OrmReference.GenerateHashName<PhoneType>(),
			() => new OrmReference(typeof(PhoneType))
		);
	}
}
