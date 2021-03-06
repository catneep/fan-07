using System;
using System.ComponentModel.DataAnnotations;

namespace fan_07.Models
{
    public class ImagenProducto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [MinLength(5,ErrorMessage="El nombre del producto debe ser mayor a 5 letras")]
        public Producto Producto { get; set; }
        public string Imagen { get; set; } //Base64
    }
}