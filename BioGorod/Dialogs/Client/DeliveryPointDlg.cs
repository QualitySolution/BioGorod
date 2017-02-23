﻿using System;
using System.Collections.Generic;
using System.Linq;
using BioGorod.Domain.Client;
using Gamma.ColumnConfig;
using Gamma.Utilities;
using GMap.NET;
using GMap.NET.GtkSharp;
using GMap.NET.GtkSharp.Markers;
using GMap.NET.MapProviders;
using QSOrmProject;
using QSOsm.DTO;
using QSProjectsLib;
using QSValidation;

namespace BioGorod.Dialogs.Client
{
	public partial class DeliveryPointDlg : OrmGtkDialogBase<DeliveryPoint>
	{
		protected static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();
		private Gtk.Clipboard clipboard = Gtk.Clipboard.Get (Gdk.Atom.Intern ("CLIPBOARD", false));

		GMapControl MapWidget;
		readonly GMapOverlay addressOverlay = new GMapOverlay();
		GMapMarker addressMarker;

		public DeliveryPointDlg (Counterparty counterparty)
		{
			this.Build ();
			UoWGeneric = DeliveryPoint.CreateUowForNew (counterparty);
			ConfigureDlg ();
		}

		public DeliveryPointDlg (int id)
		{
			this.Build ();
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<DeliveryPoint> (id);
			ConfigureDlg ();
		}

		public DeliveryPointDlg (DeliveryPoint sub) : this (sub.Id)
		{
		}

		private void ConfigureDlg ()
		{
			notebook1.CurrentPage = 0;
			notebook1.ShowTabs = false;

			buttonDeleteResponsiblePerson.Sensitive = false;
			ytreeviewResponsiblePersons.ColumnsConfig = FluentColumnsConfig<Contact>.Create()
				.AddColumn("Ответственные лица").AddTextRenderer(x => x.FullName)
				.AddColumn("Телефоны").AddTextRenderer(x => String.Join("\n", x.Phones))
				.Finish();
			ytreeviewResponsiblePersons.Selection.Mode = Gtk.SelectionMode.Multiple;
			ytreeviewResponsiblePersons.ItemsDataSource = Entity.ObservableContacts;
			ytreeviewResponsiblePersons.Selection.Changed += YtreeviewResponsiblePersons_Selection_Changed;

			textComment.Binding.AddBinding(Entity, e => e.Comment, w => w.Buffer.Text).InitializeFromSource();
			labelCompiledAddress.Binding.AddBinding(Entity, e => e.CompiledAddress, w => w.LabelProp).InitializeFromSource();
			checkIsActive.Binding.AddBinding(Entity, e => e.IsActive, w => w.Active).InitializeFromSource();

			ylabelDistrictOfCity.Binding.AddFuncBinding (Entity, entity => entity.StreetDistrict != null ? entity.StreetDistrict.Replace(",", "\n") : null, widget => widget.LabelProp)
				.InitializeFromSource ();

			yentryAddition.Binding.AddBinding(Entity, e => e.АddressAddition, w => w.Text).InitializeFromSource();

			ylabelFoundOnOsm.Binding.AddFuncBinding (Entity, 
				entity => entity.СoordinatesExist 
				? String.Format("<span foreground='{1}'>{0}</span>", entity.СoordinatesText,
					(entity.FoundOnOsm ? "green" : "blue")) 
				: "<span foreground='red'>Не найден на карте.</span>",
				widget => widget.LabelProp)
				.InitializeFromSource ();
			ycheckOsmFixed.Binding.AddBinding(Entity, e => e.IsFixedInOsm, w => w.Active).InitializeFromSource();
			ycheckOsmFixed.Visible = QSMain.User.Admin;

			entryCity.CitySelected += (sender, e) => {
				entryStreet.CityId = entryCity.OsmId;
				entryStreet.Street=string.Empty;
				entryStreet.StreetDistrict=string.Empty;
			};

			entryStreet.StreetSelected += (sender, e) => {
				entryBuilding.Street = new OsmStreet (-1, entryStreet.CityId, entryStreet.Street, entryStreet.StreetDistrict);
			};

			entryBuilding.CompletionLoaded += EntryBuilding_Changed;
			entryBuilding.Changed += EntryBuilding_Changed;

			entryCity.Binding
				.AddSource (Entity)
				.AddBinding (entity => entity.CityDistrict, widget => widget.CityDistrict)
				.AddBinding (entity => entity.City, widget => widget.City)
				.AddBinding (entity => entity.LocalityType, widget => widget.Locality) 
				.InitializeFromSource ();
			entryStreet.Binding
				.AddSource (Entity)
				.AddBinding (entity => entity.StreetDistrict, widget => widget.StreetDistrict)
				.AddBinding (entity => entity.Street, widget => widget.Street)
				.InitializeFromSource ();
			entryBuilding.Binding
				.AddSource (Entity)
				.AddBinding (entity => entity.Building, widget => widget.House)
				.InitializeFromSource ();
			
			yentryLitter.Binding.AddBinding(Entity, e => e.Letter, w => w.Text).InitializeFromSource ();

			//make actions menu
			var menu = new Gtk.Menu ();
			var menuItem = new Gtk.MenuItem ("Открыть контрагента");
			menuItem.Activated += OpenCounterparty;
			menu.Add (menuItem);
			menuActions.Menu = menu;
			menu.ShowAll ();

			//Configure map
			MapWidget = new GMap.NET.GtkSharp.GMapControl();
			MapWidget.MapProvider = GMapProviders.YandexMap;
			MapWidget.Position = new PointLatLng(59.93900, 30.31646);
			MapWidget.MinZoom = 0;
			MapWidget.MaxZoom = 24;
			MapWidget.Zoom = 9;
			MapWidget.WidthRequest = 450;
			MapWidget.HasFrame = true;
			MapWidget.Overlays.Add(addressOverlay);
			MapWidget.ButtonPressEvent += MapWidget_ButtonPressEvent;
			MapWidget.ButtonReleaseEvent += MapWidget_ButtonReleaseEvent;
			MapWidget.MotionNotifyEvent += MapWidget_MotionNotifyEvent;
			rightsidepanel1.Panel = MapWidget;
			rightsidepanel1.PanelOpened += Rightsidepanel1_PanelOpened;
			rightsidepanel1.PanelHided += Rightsidepanel1_PanelHided;
			Entity.PropertyChanged += Entity_PropertyChanged;
			UpdateAddressOnMap();
		}

		void YtreeviewResponsiblePersons_Selection_Changed (object sender, EventArgs e)
		{
			buttonDeleteResponsiblePerson.Sensitive = ytreeviewResponsiblePersons.GetSelectedObjects().Length > 0;
		}

		void MapWidget_MotionNotifyEvent (object o, Gtk.MotionNotifyEventArgs args)
		{
			if(addressMoving)
			{
				addressMarker.Position = MapWidget.FromLocalToLatLng((int)args.Event.X, (int)args.Event.Y);
			}
		}

		void MapWidget_ButtonReleaseEvent (object o, Gtk.ButtonReleaseEventArgs args)
		{
			if(args.Event.Button == 1)
			{
				addressMoving = false;
				var newPoint = MapWidget.FromLocalToLatLng((int)args.Event.X, (int)args.Event.Y);
				if(!Entity.ManualCoordinates && Entity.FoundOnOsm)
				{
					if (!MessageDialogWorks.RunQuestionDialog("Координаты сейчас установлены по адресу. Вы уверены что хотите установить новые координаты?"))
					{
						UpdateAddressOnMap();
						return;
					}
				}

				Entity.ManualCoordinates = true;
				Entity.Latitude = (decimal)newPoint.Lat;
				Entity.Longitude = (decimal)newPoint.Lng;
			}
		}

		private bool addressMoving;

		void MapWidget_ButtonPressEvent (object o, Gtk.ButtonPressEventArgs args)
		{
			if (args.Event.Button == 1)
			{
				var newPoint = MapWidget.FromLocalToLatLng((int)args.Event.X, (int)args.Event.Y);
				if (addressMarker == null)
				{
					addressMarker = new GMarkerGoogle(newPoint,	GMarkerGoogleType.arrow);
					addressMarker.ToolTipText = Entity.ShortAddress;
					addressOverlay.Markers.Add(addressMarker);
				}
				else
					addressMarker.Position = newPoint;
				addressMoving = true;
			}
		}

		void Entity_PropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if(e.PropertyName == Entity.GetPropertyName(x => x.Latitude)
				|| e.PropertyName == Entity.GetPropertyName(x => x.Longitude))
			{
				UpdateMapPosition();
				UpdateAddressOnMap();
			}
		}

		void Rightsidepanel1_PanelHided (object sender, EventArgs e)
		{
			var slider = TabParent as QSTDI.TdiSliderTab;
			if(slider != null)
			{
				slider.IsHideJournal = false;
			}
		}

		void Rightsidepanel1_PanelOpened (object sender, EventArgs e)
		{
			var slider = TabParent as QSTDI.TdiSliderTab;
			if(slider != null)
			{
				slider.IsHideJournal = true;
			}
		}

		void OpenCounterparty (object sender, EventArgs e)
		{
			TabParent.OpenTab(
				OrmMain.GenerateDialogHashName<Counterparty>(Entity.Counterparty.Id),
				() => new CounterpartyDlg(Entity.Counterparty.Id)
			);
		}

		void EntryBuilding_Changed (object sender, EventArgs e)
		{
			if (entryBuilding.OsmCompletion.HasValue)
			{
				Entity.FoundOnOsm = entryBuilding.OsmCompletion.Value;
				decimal? latitude, longitude;
				entryBuilding.GetCoordinates(out longitude, out latitude);

				if (!Entity.ManualCoordinates || (Entity.ManualCoordinates && MessageDialogWorks.RunQuestionDialog("Координаты были установлены вручную, заменить их на коордитаты адреса?")))
				{
					Entity.Latitude = latitude;
					Entity.Longitude = longitude;
					Entity.ManualCoordinates = false;
				}
			}
			if(entryBuilding.OsmHouse != null && !String.IsNullOrWhiteSpace(entryBuilding.OsmHouse.Name))
			{
				labelHouseName.Visible = true;
				labelHouseName.LabelProp = entryBuilding.OsmHouse.Name;
			}
			else
			{
				labelHouseName.Visible = false;
			}
		}

		private void UpdateMapPosition()
		{
			if(Entity.Latitude.HasValue && Entity.Longitude.HasValue)
			{
				var position = new PointLatLng((double)Entity.Latitude.Value, (double)Entity.Longitude.Value);
				if(!MapWidget.ViewArea.Contains(position))
				{
					MapWidget.Position = position;
					MapWidget.Zoom = 15;
				}
			}
			else
			{
				MapWidget.Position = new PointLatLng(59.93900, 30.31646);
				MapWidget.Zoom = 9;
			}
		}

		private void UpdateAddressOnMap()
		{
			if(addressMarker != null)
			{
				addressOverlay.Markers.Clear();
				addressMarker = null;
			}

			if(Entity.Latitude.HasValue && Entity.Longitude.HasValue)
			{
				addressMarker = new GMarkerGoogle(new PointLatLng((double)Entity.Latitude.Value, (double)Entity.Longitude.Value),
					GMarkerGoogleType.arrow);
				addressMarker.ToolTipText = Entity.ShortAddress;
				addressOverlay.Markers.Add(addressMarker);
			}
		}

		public override bool Save ()
		{
			if(!Entity.СoordinatesExist)
			{
				if(!MessageDialogWorks.RunQuestionDialog ("Адрес не найден на карте, вы точно хотите его сохранить?"))
					return false;
			}

			var valid = new QSValidator<DeliveryPoint> (UoWGeneric.Root);
			if (valid.RunDlgIfNotValid ((Gtk.Window)this.Toplevel))
				return false;

			UoWGeneric.Save ();
			return true;
		}

		protected void OnRadoiInformationToggled (object sender, EventArgs e)
		{
			if (radioInformation.Active)
			{
				notebook1.CurrentPage = 0;
			}
		}

		protected void OnRadioContactsToggled (object sender, EventArgs e)
		{
			if (radioContacts.Active)
			{
				notebook1.CurrentPage = 1;
			}
		}

		protected void OnButtonAddResponsiblePersonClicked (object sender, EventArgs e)
		{
			var dlg = new ReferenceRepresentation(new ViewModel.ContactsVM(UoW, Entity.Counterparty));
			dlg.Mode = OrmReferenceMode.MultiSelect;
			dlg.ObjectSelected += Dlg_ObjectSelected;
			TabParent.AddSlaveTab (this, dlg);
		}

		void Dlg_ObjectSelected (object sender, ReferenceRepresentationSelectedEventArgs e)
		{
			var contacts = UoW.GetById<Contact>(e.GetSelectedIds()).ToList();
			contacts.ForEach(Entity.AddContact);
		}

		protected void OnButtonDeleteResponsiblePersonClicked (object sender, EventArgs e)
		{
			var selected = ytreeviewResponsiblePersons.GetSelectedObjects<Contact>();
			foreach (var toDelete in selected)
			{
				Entity.ObservableContacts.Remove(toDelete);
			}
		}

		protected void OnButtonInsertFromBufferClicked (object sender, EventArgs e)
		{
			bool error = true;

			string booferCoordinates = clipboard.WaitForText();

			string[] coordinates = booferCoordinates?.Split(',');
			if (coordinates?.Length == 2)
			{
				coordinates[0] = coordinates[0].Replace('.', ',');
				coordinates[1] = coordinates[1].Replace('.', ',');

				decimal latitude, longitude;
				bool goodLat = decimal.TryParse(coordinates[0].Trim(), out latitude);
				bool goodLon = decimal.TryParse(coordinates[1].Trim(), out longitude);

				if (goodLat && goodLon)
				{
					Entity.Latitude  = latitude;
					Entity.Longitude = longitude;
					error = false;
				}
			}
			if (error)
				MessageDialogWorks.RunErrorDialog(
					"Буфер обмена не содержит координат или содержит неправильные координаты");
		}
	}
}

