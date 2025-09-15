using E_Commerce.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Data.Config
{
    public class PhotoConfigurtion : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            // builder.HasData(new Photo { Id = 1, IamgName = "Test", ProductId = 1 });
            builder.HasKey(p => p.Id);

            builder.Property(p => p.IamgName)
                   .IsRequired()
                   .HasMaxLength(500);


        }
    }
}
