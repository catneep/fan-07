using System;
using System.Collections;
using System.Collections.Generic;

namespace fan_07.Models
{
    public class Producto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        public Subcategoria Subcategoria { get; set; }
        public ICollection<ImagenProducto> Imagenes { get; set; }
    }
}