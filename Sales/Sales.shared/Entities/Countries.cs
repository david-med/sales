﻿using System.ComponentModel.DataAnnotations;

namespace Sales.shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "País")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

    }
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;   
        public int CountryId { get; set; } 

    } 

}
