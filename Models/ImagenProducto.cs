using System;

namespace fan_07.Models
{
    public class ImagenProducto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Producto Producto { get; set; }
        public string Imagen { get; set; }
    }
}