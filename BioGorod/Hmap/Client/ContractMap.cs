using System;
using BioGorod.Domain.Client;
using FluentNHibernate.Mapping;

namespace BioGorod.Hmap.Client
{
	public class ContractMap : ClassMap<Contract>
	{
		public ContractMap ()
		{
			Table ("contracts");

			Id (x => x.Id).Column ("id").GeneratedBy.Native ();
			DiscriminateSubClassesOnColumn ("type");

			Map (x => x.Number).Column ("number");
			Map (x => x.IssueDate).Column ("sign_date");
			Map (x => x.HaveOriginal).Column ("have_original");
			Map (x => x.HaveScanned).Column ("have_scanned");
			Map (x => x.IsArchive).Column ("is_archive");
			Map(x => x.ChangedTemplateFile).Column("doc_changed_template").LazyLoad();
			References(x => x.ContractTemplate).Column("doc_template_id");
			References (x => x.Organization).Column ("org_id");
			References (x => x.Counterparty).Column ("counterparty_id");
		}
	}}

