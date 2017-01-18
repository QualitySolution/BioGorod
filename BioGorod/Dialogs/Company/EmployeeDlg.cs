using System;
using System.Collections.Generic;
using System.Linq;
using BioGorod.Domain.Company;
using QSContacts;
using QSOrmProject;
using QSProjectsLib;
using QSValidation;

namespace BioGorod.Dialogs.Company
{
	public partial class EmployeeDlg : OrmGtkDialogBase<Employee>
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();

		public EmployeeDlg ()
		{
			this.Build ();
			UoWGeneric = UnitOfWorkFactory.CreateWithNewRoot<Employee> ();
			ConfigureDlg ();
		}

		public EmployeeDlg (int id)
		{
			this.Build ();
			logger.Info ("Загрузка информации о сотруднике...");
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<Employee> (id);
			ConfigureDlg ();
		}

		public EmployeeDlg (Employee sub) : this (sub.Id)
		{
		}

		private void ConfigureDlg ()
		{
			dataentryPassportSeria.MaxLength = 5;
			dataentryPassportSeria.Binding.AddBinding(Entity, e => e.PassportSeria, w => w.Text).InitializeFromSource();
			dataentryPassportNumber.MaxLength = 6;
			dataentryPassportNumber.Binding.AddBinding(Entity, e => e.PassportNumber, w => w.Text).InitializeFromSource();
			dataentryDrivingNumber.MaxLength = 10;
			dataentryDrivingNumber.Binding.AddBinding(Entity, e => e.DrivingNumber, w => w.Text).InitializeFromSource();
			UoWGeneric.Root.PropertyChanged += OnPropertyChanged;
			notebookMain.Page = 0;
			notebookMain.ShowTabs = false;

			checkIsFired.Binding.AddBinding(Entity, e => e.IsFired, w => w.Active).InitializeFromSource();

			dataentryLastName.Binding.AddBinding(Entity, e => e.LastName, w => w.Text).InitializeFromSource();
			dataentryName.Binding.AddBinding(Entity, e => e.Name, w => w.Text).InitializeFromSource();
			dataentryPatronymic.Binding.AddBinding(Entity, e => e.Patronymic, w => w.Text).InitializeFromSource();

			dataentryPassportSeria.Binding.AddBinding(Entity, e => e.PassportSeria, w => w.Text).InitializeFromSource();
			dataentryPassportNumber.Binding.AddBinding(Entity, e => e.PassportNumber, w => w.Text).InitializeFromSource();
			entryAddressCurrent.Binding.AddBinding(Entity, e => e.AddressCurrent, w => w.Text).InitializeFromSource();
			entryAddressRegistration.Binding.AddBinding(Entity, e => e.AddressRegistration, w => w.Text).InitializeFromSource();

			referenceUser.SubjectType = typeof(User);
			referenceUser.CanEditReference = false;
			referenceUser.Binding.AddBinding(Entity, e => e.User, w => w.Subject).InitializeFromSource();

			comboCategory.ItemsEnum = typeof(EmployeeCategory);
			comboCategory.Binding.AddBinding(Entity, e => e.Category, w => w.SelectedItem).InitializeFromSource();

			photoviewEmployee.Binding.AddBinding(Entity, e => e.Photo, w => w.ImageFile).InitializeFromSource();
			photoviewEmployee.GetSaveFileName = () => Entity.FullName;

			phonesView.UoW = UoWGeneric;
			if (UoWGeneric.Root.Phones == null)
				UoWGeneric.Root.Phones = new List<Phone> ();
			phonesView.Phones = UoWGeneric.Root.Phones;

			logger.Info ("Ok");
		}

		void OnPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			logger.Debug ("Property {0} changed", e.PropertyName);
		}

		public override bool Save ()
		{
			var valid = new QSValidator<Employee> (UoWGeneric.Root);
			if (valid.RunDlgIfNotValid ((Gtk.Window)this.Toplevel))
				return false;

			if (Entity.User != null) {
				var associatedEmployees = Repository.Company.EmployeeRepository.GetEmployeesForUser (UoW, Entity.User.Id);
				if (associatedEmployees.Any (e => e.Id != Entity.Id)) {
					string mes = String.Format ("Пользователь {0} уже связан с сотрудником {1}, при привязке этого сотрудника к пользователю, старая связь будет удалена. Продолжить?",
						Entity.User.Name,
						String.Join (", ", associatedEmployees.Select (e => e.ShortName))
					);
					if (MessageDialogWorks.RunQuestionDialog (mes)) {
						foreach (var ae in associatedEmployees.Where (e => e.Id != Entity.Id)) {
							ae.User = null;
							UoWGeneric.Save (ae);
						}
					} else
						return false;
				}
			}

			phonesView.SaveChanges ();	
			logger.Info ("Сохраняем сотрудника...");
			try {
				UoWGeneric.Save ();
			} catch (Exception ex) {
				logger.Error (ex, "Не удалось записать сотрудника.");
				QSProjectsLib.QSMain.ErrorMessage ((Gtk.Window)this.Toplevel, ex);
				return false;
			}
			logger.Info ("Ok");
			return true;
		}
	}
}

