using System;
using System.Collections;
using System.Collections.Generic;

namespace fan_07.Models
{
    public class Categoria
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [MaxLength(50, ErrorMessage="Nombre no puede ser mayor a 50 caracteres")]
        public string Nombre { get; set; }

        public ICollection<Subcategoria> Subcategorias { get; set; }
    }
}