using System;
using QSDocTemplates;
using BioGorod.Domain.Client;

namespace BioGorod.DocTemplates
{
	public class ShortLeaseParser : DocParserBase<ContractShortLease>
	{
		public ShortLeaseParser()
		{
		}

		public override void UpdateFields()
		{
			fieldsList.Clear();

			//Сам договор
			AddField(x => x.Number, PatternFieldType.FString);
			AddField(x => x.IssueDate, PatternFieldType.FDate);
			//Условия короткой аренды
			AddField(x => x.AdditionalWater, PatternFieldType.FString);
			AddField(x => x.WaterDispenser, PatternFieldType.FString);
			AddField(x => x.CabineCost, PatternFieldType.FCurrency);
			AddField(x => x.DeliveryCost, PatternFieldType.FCurrency);
			AddField(x => x.TotalCost, PatternFieldType.FCurrency);
			AddField(x => x.CabineCount, PatternFieldType.FNumber);
			AddField(x => x.DeliveryTime, PatternFieldType.FDate);
			AddField(x => x.RemovalTime, PatternFieldType.FDate);
			AddField(x => x.AdditionalInfo, PatternFieldType.FString);

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
			AddField(x => x.Counterparty.ActualAddress, PatternFieldType.FString);
			AddField(x => x.Counterparty.LegalAddress, PatternFieldType.FString);
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
				.AddColumn(x => x.DeliveryPoint, PatternFieldType.FString);
			SortFields();
		}

	}
}

