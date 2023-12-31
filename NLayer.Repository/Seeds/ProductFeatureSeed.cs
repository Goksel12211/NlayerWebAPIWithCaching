﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    internal class ProductFeatureSeed : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasData(new ProductFeature
            {
                Id=1,
                Color="Kırımızı",
                Height=199,
                Width=100,
                ProductId=1
            },
            new ProductFeature{
                Id = 2,
                Color = "Sarı",
                Height = 1992,
                Width = 10,
                ProductId = 2
            });
        }
    }
}
