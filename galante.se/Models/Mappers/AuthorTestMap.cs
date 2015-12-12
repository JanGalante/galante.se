using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace galante.se.Models.Mappers
{
    public class AuthorTestMap : EntityTypeConfiguration<AUTHOR_TEST>
    {
        public AuthorTestMap()
        {
            //Primary key
            this.HasKey(t => t.author_id);

            //Properties
            this.Property(t => t.author_name)
                .HasMaxLength(200);

            //Table and Column Mappings
            this.ToTable("AUTHOR_TEST");
            this.Property(t => t.author_id).HasColumnName("book_id");
            this.Property(t => t.author_name).HasColumnName("author_name");
        }

    }
}