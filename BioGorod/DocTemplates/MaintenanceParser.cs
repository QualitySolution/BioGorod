using System;
using QSDocTemplates;
using BioGorod.Domain.Client;

namespace BioGorod.DocTemplates
{
	public class MaintenanceParser : DocParserBase<ContractMaintenance>
	{
		public MaintenanceParser()
		{
		}

		public override void UpdateFields()
		{
			fieldsList.Clear();

			//Сам договор
			AddField(x => x.Number, PatternFieldType.FString);
			AddField(x => x.IssueDate, PatternFieldType.FDate);

			//Организаци
			AddField(x => x.Organization.FullName, PatternFieldType.FString);
			AddField(x => x.Organization.Address, PatternFieldType.FString);
			AddField(x => x.Organization.INN, PatternFieldType.FString);
			AddField(x => x.Organization.KPP, PatternFieldType.FString);
			AddField(x => x.Organization.JurAddress, PatternFieldType.FString);
			AddField(x => x.Organization.OGRN, PatternFieldType.FString);
			//Расчетный счет
			AddField(x => x.Organization.DefaultAccount.Number, PatternFieldType.FString);
			AddField(x => x.Organization.DefaultAccount.InBank.Bik, PatternFieldType.FString);
			AddField(x => x.Organization.DefaultAccount.InBank.CorAccount, PatternFieldType.FString);
			AddField(x => x.Organization.DefaultAccount.InBank.Name, PatternFieldType.FString);
			//Директор организации
			AddField(x => x.Organization.Leader.FullName, PatternFieldType.FString);
			AddField(x => x.Organization.Leader.ShortName, PatternFieldType.FString);

			//Клиент
			AddField(x => x.Counterparty.Name, PatternFieldType.FString);
			AddField(x => x.Counterparty.FullName, PatternFieldType.FString);
			AddField(x => x.Counterparty.ActualAddress.PrintAddress, x => x.Counterparty.ActualAddress, PatternFieldType.FString);
			AddField(x => x.Counterparty.LegalAddress.PrintAddress, x => x.Counterparty.LegalAddress, PatternFieldType.FString);
			AddField(x => x.Counterparty.DocDeliveryAddress.PrintAddress, x => x.Counterparty.DocDeliveryAddress, PatternFieldType.FString);
			AddField(x => x.Counterparty.INN, PatternFieldType.FString);
			AddField(x => x.Counterparty.KPP, PatternFieldType.FString);
			//Расчетный счет
			AddField(x => x.Counterparty.DefaultAccount.Number, PatternFieldType.FString);
			AddField(x => x.Counterparty.DefaultAccount.InBank.Bik, PatternFieldType.FString);
			AddField(x => x.Counterparty.DefaultAccount.InBank.CorAccount, PatternFieldType.FString);
			AddField(x => x.Counterparty.DefaultAccount.InBank.Name, PatternFieldType.FString);
			//Директор клиента
			AddField(x => x.Counterparty.SignatoryFIO, PatternFieldType.FString);
			AddField(x => x.Counterparty.SignatoryPost, PatternFieldType.FString);
			AddField(x => x.Counterparty.SignatoryBaseOf, PatternFieldType.FString);

			AddTable("Адреса", x => x.Addresses)
				.AddColumn(x => x.DeliveryPoint, PatternFieldType.FString)
				.AddColumn(x => x.CabineCount, PatternFieldType.FNumber)
				.AddColumn(x => x.Info, PatternFieldType.FString)
				.AddColumn(x => x.AdditionalMaintenanceStdCost, PatternFieldType.FCurrency)
				.AddColumn(x => x.AdditionalMaintenanceWinterCost, PatternFieldType.FCurrency)
				.AddColumn(x => x.MaintenanceStdCost, PatternFieldType.FCurrency)
				.AddColumn(x => x.MaintenanceWinterCost, PatternFieldType.FCurrency)
				.AddColumn(x => x.MaintenanceCount, PatternFieldType.FNumber);

			SortFields();
		}

	}
}

