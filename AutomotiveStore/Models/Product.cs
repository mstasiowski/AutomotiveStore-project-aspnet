﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AutomotiveStore.Models
{
    public class Product
    {
        
        public int ProductID { get; set; }

            [Required(ErrorMessage = "Proszę podać nazwę produktu.")]
            [Display(Name = "Nazwa")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Proszę podać opis produktu.")]
            [Display(Name = "Opis")]
            public string Description { get; set; }

            [Required]
            [Range(0.01, double.MaxValue, ErrorMessage = "Proszę podać cenę.")]
            [Display(Name = "Cena")]
            [Column(TypeName = "decimal(8, 2)")]
            public decimal Price { get; set; }

            [Required(ErrorMessage = "Proszę podać kategorię.")]
            [Display(Name = "Kategoria")]
            public string Category { get; set; }
    }
}
