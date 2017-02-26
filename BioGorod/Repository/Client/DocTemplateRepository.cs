using System;
using BioGorod.Domain.Client;
using QSOrmProject;

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
	}
}

