﻿using System;
using BioGorod.Domain.Company;
using NHibernate;
using NHibernate.Criterion;
using QSOrmProject;

namespace BioGorod.JournalFilters
{
	[System.ComponentModel.ToolboxItem(true)]
	[OrmDefaultIsFiltered(true)]
	public partial class EmployeeFilter : Gtk.Bin, IReferenceFilter
	{
		public IUnitOfWork UoW { set; get;}
		public ICriteria BaseCriteria { set; get;}
		public event EventHandler Refiltered;

		public bool IsFiltred { get; private set;}

		ICriteria filtredCriteria;
		public ICriteria FiltredCriteria {
			private set {
				filtredCriteria = value;
			}
			get {
				if (filtredCriteria == null)
					UpdateCreteria ();
				return filtredCriteria;
			}
		}

		public EmployeeFilter (IUnitOfWork uow)
		{
			this.Build ();
			UoW = uow;
			IsFiltred = false;
			enumcomboCategory.ItemsEnum = typeof(EmployeeCategory);
		}

		void UpdateCreteria()
		{
			IsFiltred = false;
			if (BaseCriteria == null)
				return;
			FiltredCriteria = (ICriteria)BaseCriteria.Clone ();

			if(!checkFired.Active)
			{
				FiltredCriteria.Add (Restrictions.Eq ("IsFired", false));
				IsFiltred = true;
			}

			if(enumcomboCategory.SelectedItem is EmployeeCategory)
			{
				FiltredCriteria.Add (Restrictions.Eq ("Category", enumcomboCategory.SelectedItem));
				IsFiltred = true;
			}

			OnRefiltered ();
		}

		void OnRefiltered()
		{
			if(Refiltered != null)
			{
				Refiltered (this, new EventArgs ());
			}
		}

		protected void OnCheckFiredToggled (object sender, EventArgs e)
		{
			UpdateCreteria ();
		}

		protected void OnEnumcomboCategoryChangedByUser(object sender, EventArgs e)
		{
			UpdateCreteria ();
		}
	}
}

