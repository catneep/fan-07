using System;

namespace fan_07.Models
{
    public class Subcategoria
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Categoria Categoria { get; set; }
        public string Nombre { get; set; }
    }
}