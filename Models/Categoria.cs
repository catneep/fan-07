using System;
using System.Collections;
using System.Collections.Generic;

namespace fan_07.Models
{
    public class Categoria
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; }
        public ICollection<Subcategoria> Subcategorias { get; set; }
    }
}