using System;
using Gtk;
using QSProjectsLib;

namespace BioGorod
{
	partial class MainClass
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();
		public static MainWindow MainWin;

		public static void Main(string[] args)
		{
			Application.Init();
			QSMain.SubscribeToUnhadledExceptions ();
			QSMain.GuiThread = System.Threading.Thread.CurrentThread;
			QSSupportLib.MainSupport.Init();
			CreateProjectParam ();
			// Создаем окно входа
			Login LoginDialog = new Login ();
			LoginDialog.Logo = Gdk.Pixbuf.LoadFromResource ("BioGorod.Icons.logo.png");
			LoginDialog.SetDefaultNames ("BioGorod");
			LoginDialog.DefaultLogin = "user";
			LoginDialog.DefaultServer = "localhost";
			LoginDialog.UpdateFromGConf ();

			ResponseType LoginResult;
			LoginResult = (ResponseType)LoginDialog.Run ();
			if (LoginResult == ResponseType.DeleteEvent || LoginResult == ResponseType.Cancel)
				return;

			LoginDialog.Destroy ();

			//Настройка базы
			CreateBaseConfig ();

			//Настрока удаления
			ConfigureDeletion ();

			//Настройка карты
			GMap.NET.MapProviders.GMapProvider.UserAgent = String.Format("{0}/{1} used GMap.Net/{2} ({3})",
				QSSupportLib.MainSupport.ProjectVerion.Product,
				StringWorks.VersionToShortString(QSSupportLib.MainSupport.ProjectVerion.Version),
				StringWorks.VersionToShortString(System.Reflection.Assembly.GetAssembly(typeof(GMap.NET.MapProviders.GMapProvider)).GetName().Version),
				Environment.OSVersion.VersionString
			);
			GMap.NET.MapProviders.GMapProvider.Language = GMap.NET.LanguageType.Russian;

			//Запускаем программу
			MainWin = new MainWindow ();
			QSMain.ErrorDlgParrent = MainWin;
			if (QSMain.User.Login == "root")
				return;
			MainWin.Show ();
			Application.Run ();
		}
	}
}
