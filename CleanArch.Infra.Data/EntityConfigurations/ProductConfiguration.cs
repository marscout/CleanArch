﻿using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Price).HasPrecision(10, 2);

            builder.HasData(new Product
            {
                Id = 1,
                Name = "Caderno",
                Description = "Caderno espiral 100 folhas",
                Price = 9.45m
            }, new Product
            {
                Id = 2,
                Name = "Borracha",
                Description = "Pequena Branca",
                Price = 3.75m
            }, new Product
            {
                Id = 3,
                Name = "Estojo",
                Description = "Plastico pequeno",
                Price = 5.25m
            });
        }
    }
}
