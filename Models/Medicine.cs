using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SmartMedicinesTestAPi.Models;

    public class Medicine
    {
    public Medicine()
    {
    }

    public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        public double Quantity { get; set; } = 1;

        public DateTime CreationDate { get; set; }
    }