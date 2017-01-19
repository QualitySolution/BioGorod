using System;
using System.Collections.Generic;
using BioGorod.Domain.Client;
using QSOrmProject;
using NHibernate.Criterion;

namespace BioGorod.Repository.Client
{
	public static class CounterpartyRepository
	{
		public static IList<Counterparty> GetCounterpartiesByINN(IUnitOfWork uow, string inn) 
		{
			if (string.IsNullOrWhiteSpace (inn))
				return null;
			return uow.Session.QueryOver<Counterparty>()
				.Where(c => c.INN == inn).List<Counterparty>();
		}

		public static IList<string> GetUniqueSignatoryPosts(IUnitOfWork uow)
		{
			return uow.Session.QueryOver<Counterparty>()
				.Select(Projections.Distinct(Projections.Property<Counterparty>(x => x.SignatoryPost)))
				.List<string>();
		}

		public static IList<string> GetUniqueSignatoryBaseOf(IUnitOfWork uow)
		{
			return uow.Session.QueryOver<Counterparty>()
				.Select(Projections.Distinct(Projections.Property<Counterparty>(x => x.SignatoryBaseOf)))
				.List<string>();
		}

	}
}

