﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entites
{
    public class Photo : BaseEntity<int>
    {
        public string IamgName { get; set; } 
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
