using FluentNHibernate.Mapping;
using BioGorod.Domain.Company;

namespace BioGorod.Hmap.Company
{
	public class CabineMap : ClassMap<Cabine>
	{
		public CabineMap ()
		{
			Table ("cabines");

			Id (x => x.Id).Column ("id").GeneratedBy.Native ();

			Map (x => x.Name).Column ("name");
			Map (x => x.Number).Column ("number");

			References (x => x.Color).Column ("color_id").Not.LazyLoad();
		}
	}
}