﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinTest.Core.Models.Users
{
    public class Role
    {
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public string Name { get; set; }


        public class RoleConfiguration : IEntityTypeConfiguration<Role>
        {
            public void Configure(EntityTypeBuilder<Role> builder)
            {
                builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            }
        }
    }
}
