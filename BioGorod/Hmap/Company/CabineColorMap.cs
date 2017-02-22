using FluentNHibernate.Mapping;
using BioGorod.Domain.Company;

namespace BioGorod.Hmap.Company
{
	public class CabineColorMap : ClassMap<CabineColor>
	{
		public CabineColorMap ()
		{
			Table ("cabine_colors");

			Id (x => x.Id).Column ("id").GeneratedBy.Native ();

			Map (x => x.Name).Column ("name");
		}
	}
}