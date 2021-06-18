using System;
using System.ComponentModel.DataAnnotations;

namespace fan_07.Models
{
    public class Subcategoria
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MinLength(3,ErrorMessage="Nombre de categoria debe ser mayor a 3 caracteres")]
        public Categoria Categoria { get; set; }

        [MinLength(3,ErrorMessage="Nombre de subcategoria debe ser mayor a 3 caracteres")]
        public string Nombre { get; set; }
    }
}