using System;
using System.Collections.Generic;
using BioGorod.Domain.Company;
using QSOrmProject;

namespace BioGorod.Repository.Company
{
	public static class EmployeeRepository
	{
		public static IList<Employee> GetEmployeesForUser (IUnitOfWork uow, int userId)
		{
			User userAlias = null;

			return uow.Session.QueryOver<Employee> ()
				.JoinAlias (e => e.User, () => userAlias)
				.Where (() => userAlias.Id == userId)
				.List ();
		}
	}
}

