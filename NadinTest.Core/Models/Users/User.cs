﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinTest.Core.Models.Users
{
    public class User
    {
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
