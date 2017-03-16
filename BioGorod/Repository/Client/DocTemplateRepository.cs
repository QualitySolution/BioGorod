using System;
using BioGorod.Domain.Client;
using QSOrmProject;
using System.Collections.Generic;

namespace BioGorod.Repository.Client
{
	public static class DocTemplateRepository
	{
		/// <summary>
		/// Получаем первый подходящий шаболон документа по указанным критериям.
		/// </summary>
		public static DocTemplate GetTemplate (IUnitOfWork uow, ContractType type)
		{
			return uow.Session.QueryOver<DocTemplate>()
				.Where(x => x.TemplateType == type)
				.Take(1)
				.SingleOrDefault();
		}

		/// <summary>
		/// Получаем подходящие шаболоны документа по указанным критериям.
		/// </summary>
		public static IList<DocTemplate> GetTemplates (IUnitOfWork uow, ContractType type)
		{
			return uow.Session.QueryOver<DocTemplate>()
				.Where(x => x.TemplateType == type)
				.List();
		}

	}
}

