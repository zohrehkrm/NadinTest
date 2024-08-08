using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinTest.Core.Models.Base
{
    public class Product
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime ProduceDate { get; set; }
        [MaxLength(50)]
        public string ManufacturePhone { get; set; }
        public string ManufactureEmail { get; set; }
        public bool IsAvailable { get; set; }

        public class ProductConfiguration : IEntityTypeConfiguration<Product>
        {
            public void Configure(EntityTypeBuilder<Product> builder)
            {
                builder.HasIndex(i => new { i.ProduceDate , i.ManufacturePhone }).IsUnique();
            }
        }



    }
}
