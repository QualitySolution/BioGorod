﻿using System;
using BioGorod.Domain.Client;
using Gamma.ColumnConfig;
using NHibernate.Transform;
using QSContacts;
using QSOrmProject;
using QSOrmProject.RepresentationModel;

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
			DeliveryPoint deliveryPointAlias = null;
			Post postAlias = null;
			Phone phoneAlias = null;

			var contactslist = UoW.Session.QueryOver<Contact> (() => contactAlias)
				.JoinAlias (c => c.Counterparty, () => counterpartyAlias)
				.JoinAlias (c => c.DeliveryPoints, () => deliveryPointAlias, NHibernate.SqlCommand.JoinType.LeftOuterJoin)
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
					.Select (() => deliveryPointAlias.CompiledAddress).WithAlias (() => resultAlias.DeliveryPoint)
					.SelectCount (() => deliveryPointAlias.Id).WithAlias (() => resultAlias.DeliveryPointsCount)
					.Select (() => phoneAlias.Number).WithAlias (() => resultAlias.Number)
					.Select (() => phoneAlias.NumberType).WithAlias (() => resultAlias.NumberType)
				)
				.TransformUsing (Transformers.AliasToBean<ContactsVMNode> ())
				.List<ContactsVMNode> ();

			SetItemsSource (contactslist);
		}

		IColumnsConfig columnsConfig = FluentColumnsConfig<ContactsVMNode>.Create ()
			.AddColumn ("Имя").SetDataProperty (node => node.FullName)
			.AddColumn ("Должность").SetDataProperty (node => node.Post)
			.AddColumn ("Курируемые точки").SetDataProperty (node => node.PointCurator)
			.AddColumn ("Телефон").SetDataProperty (node => node.MainPhone)
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

		public string DeliveryPoint { get; set; }

		public int DeliveryPointsCount { get; set; }

		public string PointCurator {
			get {
				if (DeliveryPointsCount <= 0)
					return String.Empty;
				if (DeliveryPointsCount == 1)
					return DeliveryPoint;
				return String.Format ("{0} и еще {1}", DeliveryPoint, DeliveryPointsCount);
			}
		}

		public string Number { get; set; }

		public PhoneType NumberType { get; set; }

		public string MainPhone { 
			get { 
				if (Number != String.Empty)
					return String.Format ("{0} {1}", NumberType != null ? NumberType.Name + " " : String.Empty, Number);
				else
					return String.Empty; 
			} 
		}

		public string Comment { get; set; }
	}}

