using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastucture.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres"/*, BookStoreDbContext.SCHEMA_NAME*/);

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(g => g.Books)
                .WithOne(b => b.Genre)
                .HasForeignKey(b => b.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}