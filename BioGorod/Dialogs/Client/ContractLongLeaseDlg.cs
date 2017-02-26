using System;
using System.Linq;
using BioGorod.Domain.Client;
using BioGorod.Domain.Company;
using QSOrmProject;
using QSValidation;

namespace BioGorod.Dialogs.Client
{
	public partial class ContractLongLeaseDlg : OrmGtkDialogBase<ContractLongLease>
	{
		protected static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();

		public ContractLongLeaseDlg(Counterparty counterparty)
		{
			this.Build();
			UoWGeneric = Contract.Create<ContractLongLease> (counterparty);
			ConfigureDlg ();
		}

		public ContractLongLeaseDlg (ContractShortLease sub) : this (sub.Id){}

		public ContractLongLeaseDlg (int id)
		{
			this.Build ();
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<ContractLongLease> (id);
			ConfigureDlg ();
		}

		void ConfigureDlg ()
		{
			ydateIssue.Binding.AddBinding(Entity, e => e.IssueDate, w => w.Date).InitializeFromSource();

			ylabelNumber.Binding.AddBinding(Entity, e => e.Number, w => w.LabelProp, new IdToStringConverter()).InitializeFromSource();

			yentryreferenceCounterparty.RepresentationModel = new ViewModel.CounterpartyVM(UoW);
			yentryreferenceCounterparty.IsEditable = false;
			yentryreferenceCounterparty.Binding.AddBinding(Entity, e => e.Counterparty, w => w.Subject).InitializeFromSource();
			yentryreferenceOrg.SubjectType = typeof(Organization);
			yentryreferenceOrg.Binding.AddBinding(Entity, e => e.Organization, w => w.Subject).InitializeFromSource();

			ycheckArchive.Binding.AddBinding(Entity, e => e.IsArchive, w => w.Active).InitializeFromSource();
			ycheckOrigin.Binding.AddBinding(Entity, e => e.HaveOriginal, w => w.Active).InitializeFromSource();
			ycheckScanned.Binding.AddBinding(Entity, e => e.HaveScanned, w => w.Active).InitializeFromSource();

			//Настраиваем виджет шаблона
			if (Entity.ContractTemplate == null)
				Entity.UpdateContractTemplate(UoW);

			if (Entity.ContractTemplate != null)
				(Entity.ContractTemplate.DocParser as DocTemplates.LongLeaseParser).RootObject = Entity;
			templatewidget1.Binding.AddBinding(Entity, e => e.ContractTemplate, w => w.Template).InitializeFromSource();
			templatewidget1.Binding.AddBinding(Entity, e => e.ChangedTemplateFile, w => w.ChangedDoc).InitializeFromSource();

			FillAddressTabs();
		}

		void FillAddressTabs()
		{
			//Очищаем все вкладки если они есть.
			while (notebookAddresses.NPages > 0)
			{
				notebookAddresses.RemovePage(0);
			}
			AddNewAddressTab(null);
			foreach(var date in UoWGeneric.Root.ChangesDates.OrderBy(x => x))
			{
				AddNewAddressTab(date);
			}
			notebookAddresses.CurrentPage = notebookAddresses.NPages - 1;
		}

		private void AddNewAddressTab(DateTime? date)
		{
			var tab = new ContractLongLeaseAdressesView(UoWGeneric, date);
			var label = new Gtk.Label(date.HasValue ? String.Format("С {0:d}", date) : "Условия договора");
			notebookAddresses.AppendPage(tab, label);
			tab.ShowAll();
		}

		public override bool Save ()
		{
			var valid = new QSValidator<ContractLongLease> (UoWGeneric.Root);
			if (valid.RunDlgIfNotValid ((Gtk.Window)this.Toplevel))
				return false;

			Contract.CreateContractNumber(Entity);

			logger.Info ("Сохраняем договор...");
			UoWGeneric.Save ();
			logger.Info ("Ok");
			return true;
		}

		public void NewAddressesDate()
		{
			var newDate = DateTime.Today;
			while(Entity.ChangesDates.Contains(newDate))
			{
				newDate = newDate.AddDays(1);
			}

			Entity.CopyAddressesToNewDate(newDate);
			AddNewAddressTab(newDate);
			notebookAddresses.CurrentPage = notebookAddresses.NPages - 1;
		}

		public void UpdateTabLabel(Gtk.Widget tab, DateTime date)
		{
			var label = (Gtk.Label)notebookAddresses.GetTabLabel(tab);
			label.LabelProp = String.Format("С {0:d}", date);
		}

		public void RemoveTab(Gtk.Widget tab)
		{
			var num = notebookAddresses.PageNum(tab);
			notebookAddresses.RemovePage(num);
			if(notebookAddresses.NPages == num)
			{
				var lastTab = notebookAddresses.GetNthPage(num - 1) as ContractLongLeaseAdressesView;
				lastTab.CanEdit = true;
			}
		}
	}
}

