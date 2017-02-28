using System;
using BioGorod.Domain.Client;
using Gamma.ColumnConfig;
using NHibernate.Transform;
using QSContacts;
using QSOrmProject;
using QSOrmProject.RepresentationModel;
using NHibernate.Criterion;
using NHibernate.Dialect.Function;
using NHibernate;

namespace BioGorod.ViewModel
{
	public class ContactsVM : RepresentationModelEntityBase<Contact, ContactsVMNode>, IRepresentationModelWithParent
	{
		public IUnitOfWorkGeneric<Counterparty> CounterpartyUoW {
			get {
				return UoW as IUnitOfWorkGeneric<Counterparty>;
			}
		}

		Counterparty counterparty;

		public Counterparty Counterparty {
			get {
				if (CounterpartyUoW != null)
					return CounterpartyUoW.Root;
				else
					return counterparty;
			}
			private set {
				counterparty = value;
			}
		}

		#region IRepresentationModelWithParent implementation

		public object GetParent {
			get {
				return Counterparty;
			}
		}

		#endregion


		#region IRepresentationModel implementation

		public override void UpdateNodes ()
		{

			Counterparty counterpartyAlias = null;
			Contact contactAlias = null;
			ContactsVMNode resultAlias = null;
			Post postAlias = null;
			Phone phoneAlias = null;

			var contactslist = UoW.Session.QueryOver<Contact> (() => contactAlias)
				.JoinAlias (c => c.Counterparty, () => counterpartyAlias)
				.JoinAlias (c => c.Post, () => postAlias, NHibernate.SqlCommand.JoinType.LeftOuterJoin)
				.JoinAlias (c => c.Phones, () => phoneAlias, NHibernate.SqlCommand.JoinType.LeftOuterJoin)
				.Where (() => counterpartyAlias.Id == Counterparty.Id)
				.SelectList (list => list
					.SelectGroup (() => contactAlias.Id).WithAlias (() => resultAlias.Id)
					.Select (() => contactAlias.Name).WithAlias (() => resultAlias.Name)
					.Select (() => contactAlias.Patronymic).WithAlias (() => resultAlias.Lastname)
					.Select (() => contactAlias.Surname).WithAlias (() => resultAlias.Surname)
					.Select (() => contactAlias.Comment).WithAlias (() => resultAlias.Comment)
					.Select (() => postAlias.Name).WithAlias (() => resultAlias.Post)
					.Select (Projections.SqlFunction (
						new SQLFunctionTemplate (NHibernateUtil.String, "GROUP_CONCAT( ?1 SEPARATOR ?2)"),
						NHibernateUtil.String,
						Projections.Property(() => phoneAlias.Number),
						Projections.Constant ("\n"))).WithAlias (() => resultAlias.Phones)
				)
				.TransformUsing (Transformers.AliasToBean<ContactsVMNode> ())
				.List<ContactsVMNode> ();

			SetItemsSource (contactslist);
		}

		IColumnsConfig columnsConfig = FluentColumnsConfig<ContactsVMNode>.Create ()
			.AddColumn ("Должность").SetDataProperty (node => node.Post)
			.AddColumn ("Имя").SetDataProperty (node => node.FullName)
			.AddColumn ("Телефоны").SetDataProperty (node => node.Phones)
			.AddColumn ("Комментарий").SetDataProperty (node => node.Comment)
			.Finish ();

		public override IColumnsConfig ColumnsConfig {
			get { return columnsConfig; }
		}

		#endregion

		#region implemented abstract members of RepresentationModelBase

		protected override bool NeedUpdateFunc (Contact updatedSubject)
		{
			return Counterparty.Id == updatedSubject.Counterparty.Id;
		}

		#endregion

		public ContactsVM (IUnitOfWorkGeneric<Counterparty> uow)
		{
			this.UoW = uow;
		}

		public ContactsVM(IUnitOfWork uow, Counterparty counterparty)
		{
			this.UoW = uow;
			Counterparty = counterparty;
		}
	}

	public class ContactsVMNode
	{
		public int Id { get; set; }

		public string Surname { get; set; }

		public string Name { get; set; }

		public string Lastname { get; set; }

		public string FullName { get { return String.Format ("{0} {1} {2}", Surname, Name, Lastname); } }

		public string Post { get; set; }

		public string Phones { get; set; }

		public string Comment { get; set; }
	}}

