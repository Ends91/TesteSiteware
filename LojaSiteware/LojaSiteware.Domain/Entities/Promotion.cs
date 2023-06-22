﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LojaSiteware.Domain.Entities
{
    public class Promotion
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
