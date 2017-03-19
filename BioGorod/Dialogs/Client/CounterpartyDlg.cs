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
				UoWGeneric.Root.CounterpartyContracts = new List<Contract> ();
			}
			//Other fields properties
			validatedINN.ValidationMode = validatedKPP.ValidationMode = validatedentryOGRN.ValidationMode = QSWidgetLib.ValidationType.numeric;
			validatedINN.Binding.AddBinding(Entity, e => e.INN, w => w.Text).InitializeFromSource();
			validatedKPP.Binding.AddBinding(Entity, e => e.KPP, w => w.Text).InitializeFromSource();
			validatedentryOGRN.Binding.AddBinding(Entity, e => e.OGRN, w => w.Text).InitializeFromSource();

			yentrySignFIO.Binding.AddBinding(Entity, e => e.SignatoryFIO, w => w.Text).InitializeFromSource();
			yentrySignFIOGenetivus.Binding.AddBinding(Entity, e => e.SignatoryFIOGenetivus, w => w.Text).InitializeFromSource();
			yentrySignPost.Binding.AddBinding(Entity, e => e.SignatoryPost, w => w.Text).InitializeFromSource();
			yentrySignBaseOf.Binding.AddBinding(Entity, e => e.SignatoryBaseOf, w => w.Text).InitializeFromSource();

			//Нужно что бы подстраховаться, если в базе будет NULL адрес не добавится вообще.
			if (Entity.ActualAddress == null)
				Entity.ActualAddress = new QSOsm.Data.JsonAddress();
			if (Entity.LegalAddress == null)
				Entity.LegalAddress = new QSOsm.Data.JsonAddress();
			if (Entity.DocDeliveryAddress == null)
				Entity.DocDeliveryAddress = new QSOsm.Data.JsonAddress();
			
			jsonaddressLegal.Binding.AddBinding(Entity, e => e.LegalAddress, w => w.Address).InitializeFromSource();
			jsonaddressActual.Binding.AddBinding(Entity, e => e.ActualAddress, w => w.Address).InitializeFromSource();
			jsonaddressDocDelivery.Binding.AddBinding(Entity, e => e.DocDeliveryAddress, w => w.Address).InitializeFromSource();

			yentryName.Binding.AddBinding(Entity, e => e.Name, w => w.Text).InitializeFromSource();
			entryFullName.Binding.AddBinding(Entity, e => e.FullName, w => w.Text).InitializeFromSource();
			var parallel = new ParallelEditing (entryFullName);
			parallel.SubscribeOnChanges (yentryName);
			parallel.GetParallelTextFunc = GenerateOfficialName;
			yentryInternalName.Binding.AddBinding(Entity, e => e.InternalName, w => w.Text).InitializeFromSource();

			comboDocumentsDelivery.ItemsEnum = typeof(DocumentsDelivery);
			comboDocumentsDelivery.Binding.AddBinding(Entity, e => e.DocumentsDelivery, w => w.SelectedItem).InitializeFromSource();

			referencePaymentManager.ItemsQuery = Repository.Company.EmployeeRepository.OfficeWorkersQuery ();
			referencePaymentManager.Binding.AddBinding(Entity, e => e.PaymentManager, w => w.Subject).InitializeFromSource();

			dataComment.Binding.AddBinding(Entity, e => e.Comment, w => w.Buffer.Text).InitializeFromSource();

			ycheckIsArchived.Binding.AddBinding(Entity, e => e.IsArchive, w => w.Active).InitializeFromSource();
			checkHaveArbitration.Binding.AddBinding(Entity, e => e.HaveArbitration, w => w.Active).InitializeFromSource();
			checkRequirePrepayment.Binding.AddBinding(Entity, e => e.RequirePrepayment, w => w.Active).InitializeFromSource();
			ycheckContourFocus.Binding.AddBinding(Entity, e => e.ContourFocus, w => w.Active).InitializeFromSource();
			ycheckMassRegistration.Binding.AddBinding(Entity, e => e.MassRegistration, w => w.Active).InitializeFromSource();
			ydateCannotFind.Binding.AddBinding(Entity, e => e.CannotFindSince, w => w.DateOrNull).InitializeFromSource();

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

		protected void OnRadioContactPersonsToggled (object sender, EventArgs e)
		{
			if (radioContactAndAddresses.Active)
				notebook1.CurrentPage = 1;
		}

		protected void OnRadioContractsToggled (object sender, EventArgs e)
		{
			if (radioContracts.Active)
				notebook1.CurrentPage = 2;
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

		protected void OnButtonActualFromLegalClicked(object sender, EventArgs e)
		{
			Entity.ActualAddress.CopyFrom(Entity.LegalAddress);
		}

		protected void OnButtonDocFromLegalClicked(object sender, EventArgs e)
		{
			Entity.DocDeliveryAddress.CopyFrom(Entity.LegalAddress);
		}

		protected void OnButtonDocFromActualClicked(object sender, EventArgs e)
		{
			Entity.DocDeliveryAddress.CopyFrom(Entity.ActualAddress);
		}

		protected void OnGetorginfo1FillButtonCliked(object sender, EventArgs e)
		{
			if(getorginfo1.SelectedParty != null)
			{
				var party = getorginfo1.SelectedParty;
				Entity.FullName = party.name.full_with_opf;
				Entity.Name = party.name.short_with_opf;
				Entity.INN = party.inn;
				Entity.KPP = party.kpp;
				Entity.OGRN = party.ogrn;
				Entity.SignatoryFIO = party.management.name;
				Entity.SignatoryPost = party.management.post;
				Entity.LegalAddress = new QSOsm.Data.JsonAddress();
				if(party.address.data != null)
					Entity.LegalAddress.CopyFrom(party.address.data);
				else
					Entity.LegalAddress.FillFromText(party.address.value);
			}
		}

		protected void OnButtonNameToInternalNameClicked(object sender, EventArgs e)
		{
			Entity.InternalName = Entity.Name;
		}
	}
}

