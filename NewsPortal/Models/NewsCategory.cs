﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsPortal.Models
{
    public class NewsCategory
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}