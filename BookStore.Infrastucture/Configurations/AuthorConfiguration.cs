using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastucture.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");

            builder.HasKey(a => a.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Birth).IsRequired().HasColumnType("date");

            //* Adding Navigation Properties

            builder
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}