using FluentNHibernate.Mapping;
using BioGorod.Domain.Company;

namespace BioGorod
{
	public class EmployeeMap : ClassMap<Employee>
	{
		public EmployeeMap ()
		{
			Table ("employees");

			Id (x => x.Id).Column ("id").GeneratedBy.Native ();

			Map (x => x.Name).Column ("name");
			Map (x => x.LastName).Column ("last_name");
			Map (x => x.Patronymic).Column ("patronymic");
			Map (x => x.Category).Column ("category").CustomType<EmployeeCategoryStringType> ();
			Map (x => x.PassportSeria).Column ("passport_seria");
			Map (x => x.PassportNumber).Column ("passport_number");
			Map (x => x.PassportIssuedBy).Column ("passport_issued_by");
			Map (x => x.PassportIssuedDate).Column ("passport_issued_date");
			Map (x => x.DrivingNumber).Column ("driving_number");
			Map (x => x.Photo).Column ("photo").CustomSqlType ("BinaryBlob").LazyLoad ();
			Map (x => x.AddressRegistration).Column ("address_registration");
			Map (x => x.AddressCurrent).Column ("address_current");
			Map (x => x.IsFired).Column ("is_fired");
			Map (x => x.DateOfCreate).Column ("date_of_create");

			References (x => x.User).Column ("user_id");

			HasMany (x => x.Phones).Cascade.AllDeleteOrphan ().LazyLoad ().KeyColumn ("employee_id");
		}
	}
}