using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjChoc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjChoc.Infra.Data.EntityConficuration
{
	public class CategorieConfiguration : IEntityTypeConfiguration<Categorie>
	{
		public void Configure(EntityTypeBuilder<Categorie> builder)
		{
			builder.HasKey(_ => _.Id);
			builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
		}
	}
}
