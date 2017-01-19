using System;
using System.Collections.Generic;
using System.Linq;
using BioGorod.Domain.Client;
using QSBanks;
using QSContacts;
using QSOrmProject;
using QSProjectsLib;
using QSValidation;
using QSWidgetLib;

namespace BioGorod.Dialogs.Client
{
	public partial class CounterpartyDlg : OrmGtkDialogBase<Counterparty>
	{
		static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();

		public Counterparty Counterparty
		{
			get
			{
				return UoWGeneric.Root;
			}
		}

		public CounterpartyDlg ()
		{
			this.Build ();
			UoWGeneric = UnitOfWorkFactory.CreateWithNewRoot<Counterparty> ();
			ConfigureDlg ();
		}

		public CounterpartyDlg (int id)
		{
			this.Build ();
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<Counterparty> (id);
			ConfigureDlg ();
		}

		public CounterpartyDlg (Counterparty sub) : this (sub.Id)
		{
		}

		private void ConfigureDlg ()
		{
			notebook1.CurrentPage = 0;
			notebook1.ShowTabs = false;
			//Initializing null fields
			emailsView.UoW = UoWGeneric;
			phonesView.UoW = UoWGeneric;
			if (UoWGeneric.Root.Emails == null)
				UoWGeneric.Root.Emails = new List<Email> ();
			emailsView.Emails = UoWGeneric.Root.Emails;
			if (UoWGeneric.Root.Phones == null)
				UoWGeneric.Root.Phones = new List<Phone> ();
			phonesView.Phones = UoWGeneric.Root.Phones;
			if (UoWGeneric.Root.CounterpartyContracts == null) {
				UoWGeneric.Root.CounterpartyContracts = new List<CounterpartyContract> ();
			}
			//Other fields properties
			validatedINN.ValidationMode = validatedKPP.ValidationMode = validatedentryOGRN.ValidationMode = QSWidgetLib.ValidationType.numeric;
			validatedINN.Binding.AddBinding(Entity, e => e.INN, w => w.Text).InitializeFromSource();
			validatedKPP.Binding.AddBinding(Entity, e => e.KPP, w => w.Text).InitializeFromSource();
			validatedentryOGRN.Binding.AddBinding(Entity, e => e.OGRN, w => w.Text).InitializeFromSource();

			yentrySignFIO.Binding.AddBinding(Entity, e => e.SignatoryFIO, w => w.Text).InitializeFromSource();
			yentrySignPost.Binding.AddBinding(Entity, e => e.SignatoryPost, w => w.Text).InitializeFromSource();
			yentrySignBaseOf.Binding.AddBinding(Entity, e => e.SignatoryBaseOf, w => w.Text).InitializeFromSource();

			yentryName.Binding.AddBinding(Entity, e => e.Name, w => w.Text).InitializeFromSource();
			entryFullName.Binding.AddBinding(Entity, e => e.FullName, w => w.Text).InitializeFromSource();
			var parallel = new ParallelEditing (entryFullName);
			parallel.SubscribeOnChanges (yentryName);
			parallel.GetParallelTextFunc = GenerateOfficialName;

			comboDocumentsDelivery.ItemsEnum = typeof(DocumentsDelivery);
			comboDocumentsDelivery.Binding.AddBinding(Entity, e => e.DocumentsDelivery, w => w.SelectedItem).InitializeFromSource();

			referencePaymentManager.ItemsQuery = Repository.Company.EmployeeRepository.OfficeWorkersQuery ();
			referencePaymentManager.Binding.AddBinding(Entity, e => e.PaymentManager, w => w.Subject).InitializeFromSource();

			dataComment.Binding.AddBinding(Entity, e => e.Comment, w => w.Buffer.Text).InitializeFromSource();

			ycheckIsArchived.Binding.AddBinding(Entity, e => e.IsArchive, w => w.Active).InitializeFromSource();

			checkCustomer.Binding.AddBinding(Entity, e => e.CooperationCustomer, w => w.Active).InitializeFromSource();
			checkSupplier.Binding.AddBinding(Entity, e => e.CooperationSupplier, w => w.Active).InitializeFromSource();
			checkPartner.Binding.AddBinding(Entity, e => e.CooperationPartner, w => w.Active).InitializeFromSource();

			//Setting subjects
			accountsView.ParentReference = new ParentReferenceGeneric<Counterparty, Account> (UoWGeneric, c => c.Accounts);
			deliveryPointView.DeliveryPointUoW = UoWGeneric;
			counterpartyContractsView.CounterpartyUoW = UoWGeneric;
			//Setting Contacts
			contactsview1.CounterpartyUoW = UoWGeneric;
		}

		public override bool Save ()
		{
			bool hasDuplicate = CheckDuplicate();
			bool userAnswer = true;

			if (hasDuplicate)
			{
				userAnswer = MessageDialogWorks.RunQuestionDialog(
					"Контрагент с данным ИНН уже существует. Сохранить?");
			}

			if (userAnswer)
			{
				Entity.UoW = UoW;
				var valid = new QSValidator<Counterparty>(UoWGeneric.Root);
				if (valid.RunDlgIfNotValid((Gtk.Window)this.Toplevel))
					return false;

				logger.Info("Сохраняем контрагента...");
				phonesView.SaveChanges();
				emailsView.SaveChanges();
				UoWGeneric.Save();
				logger.Info("Ok.");
				return true;
			}
			return false;
		}

		string GenerateOfficialName (object arg)
		{
			var widget = arg as Gtk.Entry;
			return widget.Text;
		}

		private bool CheckDuplicate()
		{
			string INN = UoWGeneric.Root.INN;
			IList<Counterparty> counterarties = Repository.Client.CounterpartyRepository.GetCounterpartiesByINN(UoW, INN);
			if (counterarties == null)
				return false;
			if (counterarties.Count(x => x.Id != UoWGeneric.Root.Id) > 0)
				return true;
			return false;
		}

		protected void OnRadioInfoToggled (object sender, EventArgs e)
		{
			if (radioInfo.Active)
				notebook1.CurrentPage = 0;
		}

		protected void OnRadioContactsToggled (object sender, EventArgs e)
		{
			if (radioContacts.Active)
				notebook1.CurrentPage = 1;
		}

		protected void OnRadioDetailsToggled (object sender, EventArgs e)
		{
			if (radioDetails.Active)
				notebook1.CurrentPage = 2;
		}

		protected void OnRadioContactPersonsToggled (object sender, EventArgs e)
		{
			if (radioContactPersons.Active)
				notebook1.CurrentPage = 3;
		}

		protected void OnRadioContractsToggled (object sender, EventArgs e)
		{
			if (radioContracts.Active)
				notebook1.CurrentPage = 4;
		}

		protected void OnRadioDeliveryPointToggled (object sender, EventArgs e)
		{
			if (radioDeliveryPoint.Active)
				notebook1.CurrentPage = 5;
		}

		protected void OnYentrySignPostFocusInEvent(object o, Gtk.FocusInEventArgs args)
		{
			if(yentrySignPost.Completion == null)
			{
				yentrySignPost.Completion = new Gtk.EntryCompletion();
				var list = Repository.Client.CounterpartyRepository.GetUniqueSignatoryPosts(UoW);
				yentrySignPost.Completion.Model = ListStoreWorks.CreateFromEnumerable(list);
				yentrySignPost.Completion.TextColumn = 0;
				yentrySignPost.Completion.Complete();
			}
		}

		protected void OnYentrySignBaseOfFocusInEvent(object o, Gtk.FocusInEventArgs args)
		{
			if(yentrySignBaseOf.Completion == null)
			{
				yentrySignBaseOf.Completion = new Gtk.EntryCompletion();
				var list = Repository.Client.CounterpartyRepository.GetUniqueSignatoryBaseOf(UoW);
				yentrySignBaseOf.Completion.Model = ListStoreWorks.CreateFromEnumerable(list);
				yentrySignBaseOf.Completion.TextColumn = 0;
				yentrySignBaseOf.Completion.Complete();
			}
		}

	}
}

