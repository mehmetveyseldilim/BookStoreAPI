using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastucture.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books"/*, BookStoreDbContext.SCHEMA_NAME*/);

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title).IsRequired().HasMaxLength(100);

            builder.Property(b => b.ReleaseDate).IsRequired().HasColumnType("date");

            builder.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}