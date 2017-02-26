﻿using System;
using System.ComponentModel.DataAnnotations;
using BioGorod.Domain.Company;
using Gamma.Utilities;
using QSDocTemplates;
using QSOrmProject;
using BioGorod.DocTemplates;

namespace BioGorod.Domain.Client
{
	[OrmSubject (Gender = QSProjectsLib.GrammaticalGender.Masculine,
		NominativePlural = "шаблоны документов",
		Nominative = "шаблон документа")]
	public class DocTemplate : PropertyChangedBase, IDomainObject, IDocTemplate
	{
		#region Свойства

		public virtual int Id { get; set; }

		string name;

		[Display (Name = "Название")]
		[StringLength(45)]
		public virtual string Name {
			get { return name; }
			set { SetField (ref name, value, () => Name); }
		}

		ContractType templateType;

		[Display (Name = "Тип шаблона")]
		public virtual ContractType TemplateType {
			get { return templateType; }
			set { 
				bool needUpdateName = String.IsNullOrWhiteSpace(Name) || Name == templateType.GetEnumTitle();
				if (SetField(ref templateType, value, () => TemplateType))
				{
					docParser = null;
					if(needUpdateName)
						Name = templateType.GetEnumTitle();
				}					
			}
		}

/*		Organization organization;

		[Display (Name = "Организация")]
		public virtual Organization Organization {
			get { return organization; }
			set { SetField (ref organization, value, () => Organization); }
		}
*/
		byte[] templateFile;

		[Display (Name = "Файл шаблона")]
		[PropertyChangedAlso("FileSize")]
		[Required]
		public virtual byte[] TempalteFile {
			get { return templateFile; }
			set { SetField (ref templateFile, value, () => TempalteFile); }
		}

		#endregion

		#region Вычисляемые

		public virtual long FileSize{
			get{
				return TempalteFile != null ? TempalteFile.LongLength : 0;
			}
		}

		public virtual byte[] File{
			get{
				return ChangedDocFile ?? TempalteFile;
			}
		}

		#endregion

		#region Не сохраняемые

		byte[] changedDocFile;

		[Display (Name = "Измененный Файл шаблона")]
		[PropertyChangedAlso("FileSize")]
		public virtual byte[] ChangedDocFile {
			get { return changedDocFile; }
			set { SetField (ref changedDocFile, value, () => ChangedDocFile); }
		}

		IDocParser docParser;

		public virtual IDocParser DocParser
		{
			get
			{
				if (docParser == null)
					docParser = CreateParser(TemplateType);
				return docParser;
			}
		}

		#endregion

		public DocTemplate()
		{
			Name = templateType.GetEnumTitle();
		}

		#region Функции


		#endregion

		#region Статические

		public static IDocParser CreateParser(ContractType type)
		{
			switch (type)
			{
				case ContractType.ShortLease:
					return new ShortLeaseParser();
				case ContractType.LongLease:
					return new LongLeaseParser();
				case ContractType.Maintenance:
					return new MaintenanceParser();
				default:
					throw new NotImplementedException(String.Format("Тип шаблона {0}, не реализован.", type));
			}
		}

		#endregion
	}


}

