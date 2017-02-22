using System;
using QSOrmProject;
using BioGorod.Domain.Company;
using QSValidation;

namespace BioGorod.Dialogs.Company
{
	public partial class CabineDlg : OrmGtkDialogBase<Cabine>
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();

		public CabineDlg()
		{
			this.Build();
			UoWGeneric = UnitOfWorkFactory.CreateWithNewRoot<Cabine> ();
			ConfigureDlg ();
		}

		public CabineDlg (Cabine sub) : this (sub.Id){}

		public CabineDlg (int id)
		{
			this.Build ();
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<Cabine> (id);
			ConfigureDlg ();
		}


		void ConfigureDlg ()
		{
			yentryNumber.Binding.AddBinding(Entity, e => e.Number, w => w.Text).InitializeFromSource();
			yentryName.Binding.AddBinding(Entity, e => e.Name, w => w.Text).InitializeFromSource();

			yentryreferenceColor.SubjectType = typeof(CabineColor);
			yentryreferenceColor.Binding.AddBinding(Entity, e => e.Color, w => w.Subject).InitializeFromSource();
		}

		public override bool Save ()
		{
			var valid = new QSValidator<Cabine> (UoWGeneric.Root);
			if (valid.RunDlgIfNotValid ((Gtk.Window)this.Toplevel))
				return false;

			logger.Info ("Сохраняем кабинку...");
			UoWGeneric.Save ();
			logger.Info ("Ok");
			return true;
		}

	}
}

