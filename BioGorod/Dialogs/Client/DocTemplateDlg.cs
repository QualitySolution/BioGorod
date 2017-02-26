using System;
using QSOrmProject;
using QSDocTemplates;
using QSValidation;
using BioGorod.Domain.Client;
using QSProjectsLib;
using Gamma.Utilities;

namespace BioGorod.Dialogs.Client
{
	public partial class DocTemplateDlg : OrmGtkDialogBase<DocTemplate>
	{
		static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();
		private FileWorker worker = new FileWorker();

		public DocTemplateDlg()
		{
			this.Build();
			UoWGeneric = UnitOfWorkFactory.CreateWithNewRoot<DocTemplate> ();
			ConfigureDlg ();
		}

		public DocTemplateDlg (int id)
		{
			this.Build ();
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<DocTemplate> (id);
			ConfigureDlg ();
		}

		public DocTemplateDlg (DocTemplate sub) : this (sub.Id)
		{
		}

		void ConfigureDlg ()
		{
			yentryName.Binding.AddBinding(Entity, e => e.Name, w => w.Text).InitializeFromSource();
			ylabelSize.Binding.AddFuncBinding(Entity, e => StringWorks.BytesToIECUnitsString((ulong)e.FileSize), w => w.LabelProp).InitializeFromSource();
			ycomboType.ItemsEnum = typeof(ContractType);
			ycomboType.Binding.AddBinding(Entity, e => e.TemplateType, w => w.SelectedItem).InitializeFromSource();

			Entity.PropertyChanged += Entity_PropertyChanged;
		}

		void Entity_PropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if(e.PropertyName == Entity.GetPropertyName(x => x.TempalteFile))
			{
				labelFileChanged.Markup = "<span foreground=\"green\">(файл изменён)</span>";
			}
		}

		public override bool Save ()
		{
			var valid = new QSValidator<DocTemplate> (UoWGeneric.Root);
			if (valid.RunDlgIfNotValid ((Gtk.Window)this.Toplevel))
				return false;

			logger.Info ("Сохраняем шаблон документа...");
			UoWGeneric.Save ();
			logger.Info ("Ok.");
			labelFileChanged.LabelProp = String.Empty;
			return true;
		}

		protected void OnButtonNewClicked(object sender, EventArgs e)
		{
			Entity.TempalteFile = TemplatesMain.GetEmptyTemplate();
		}

		protected void OnButtonFromFileClicked(object sender, EventArgs e)
		{
			byte[] tempTempalte = TemplatesMain.GetTemplateFromDisk();
			if (tempTempalte != null)
				Entity.TempalteFile = tempTempalte;
		}

		protected void OnButtonEditClicked(object sender, EventArgs e)
		{
			worker.OpenInOffice(Entity, false, FileEditMode.Template);
		}
	}
}

