using System;
using BioGorod.Domain.Client;
using BioGorod.JournalFilters;
using Gamma.ColumnConfig;
using Gtk;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Dialect.Function;
using NHibernate.Transform;
using QSOrmProject;
using QSOrmProject.RepresentationModel;

namespace BioGorod.ViewModel
{
	public class DeliveryPointsVM : RepresentationModelEntityBase<DeliveryPoint, DeliveryPointVMNode>
	{
		public DeliveryPointFilter Filter {
			get {
				return RepresentationFilter as DeliveryPointFilter;
			}
			set {
				RepresentationFilter = value as IRepresentationFilter;
			}
		}

		#region IRepresentationModel implementation

		public override void UpdateNodes ()
		{
			DeliveryPoint deliveryPointAlias = null;
			Counterparty counterpartyAlias = null;
			DeliveryPointVMNode resultAlias = null;
			ContactAndPhonesView contactAlias = null;

			var pointsQuery = UoW.Session.QueryOver<DeliveryPoint>(() => deliveryPointAlias);
			if (Filter.RestrictOnlyNotFoundOsm)
				pointsQuery.Where(x => x.FoundOnOsm == false);

			var deliveryPointslist = pointsQuery
				.JoinAlias (c => c.Counterparty, () => counterpartyAlias, NHibernate.SqlCommand.JoinType.LeftOuterJoin)
				.JoinAlias(c => c.ContactAndPhones, () => contactAlias, NHibernate.SqlCommand.JoinType.LeftOuterJoin)
				.SelectList (list => list
					.SelectGroup (() => deliveryPointAlias.Id).WithAlias (() => resultAlias.Id)
					.Select (() => deliveryPointAlias.CompiledAddress).WithAlias (() => resultAlias.CompiledAddress)
					.Select (() => deliveryPointAlias.FoundOnOsm).WithAlias (() => resultAlias.FoundOnOsm)
					.Select (() => deliveryPointAlias.IsFixedInOsm).WithAlias (() => resultAlias.FixedInOsm)
					.Select (() => deliveryPointAlias.IsActive).WithAlias (() => resultAlias.IsActive)
					.Select (() => counterpartyAlias.FullName).WithAlias (() => resultAlias.Client)
					.Select (Projections.SqlFunction (
						new SQLFunctionTemplate (NHibernateUtil.String, "GROUP_CONCAT( ?1 SEPARATOR ?2)"),
						NHibernateUtil.String,
						Projections.Property(() => contactAlias.NameAndPhones),
						Projections.Constant ("\n"))
					).WithAlias (() => resultAlias.Contacts)
				)
				.TransformUsing (Transformers.AliasToBean<DeliveryPointVMNode> ())
				.List<DeliveryPointVMNode> ();

			SetItemsSource (deliveryPointslist);
		}

		IColumnsConfig columnsConfig = FluentColumnsConfig<DeliveryPointVMNode>.Create ()
			.AddColumn("OSM").AddTextRenderer(x => x.FoundOnOsm ? "Да": "")
			//.AddColumn("Испр.").AddTextRenderer(x => x.FixedInOsm ? "Да": "")
			.AddColumn ("Адрес").SetDataProperty (node => node.CompiledAddress)
			.AddColumn("Клиент").AddTextRenderer(x => x.Client)
			.AddColumn("Контакты").AddTextRenderer(x => x.Contacts)
			.RowCells ().AddSetter<CellRendererText> ((c, n) => c.Foreground = n.RowColor)
			.Finish ();

		public override IColumnsConfig ColumnsConfig {
			get { return columnsConfig; }
		}

		#endregion

		#region implemented abstract members of RepresentationModelBase

		protected override bool NeedUpdateFunc (DeliveryPoint updatedSubject)
		{
			return true;
		}

		#endregion

		public DeliveryPointsVM () : this(UnitOfWorkFactory.CreateWithoutRoot ()){
			CreateRepresentationFilter = () => new DeliveryPointFilter ();
		}

		public DeliveryPointsVM (IUnitOfWork uow)
		{
			this.UoW = uow;
		}

		public DeliveryPointsVM(DeliveryPointFilter filter) : this (filter.UoW)
		{
			Filter = filter;
		}
	}

	public class DeliveryPointVMNode
	{

		public int Id { get; set; }

		[UseForSearch]
		[SearchHighlight]
		public string CompiledAddress { get; set; }

		[UseForSearch]
		[SearchHighlight]
		public string Client { get; set; }

		[SearchHighlight]
		[UseForSearch]
		public string Contacts { get; set; }

		public bool IsActive { get; set; }

		public bool FoundOnOsm { get; set; }

		public bool FixedInOsm { get; set; }

		public string RowColor { get { return IsActive ? "black" : "grey"; } }
	}
}

