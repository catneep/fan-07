using System;
using System.Collections;
using System.Collections.Generic;

namespace fan_07.Models
{
    public class Producto
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MinLength(1;ErrorMessage="Ingrese el genero M o F")]
        public string Genero { get; set; } = "N/A";

        [MinLength(3,ErrorMessage="Nombre de producto debe ser mayor a 5 caracteres")]
        public string Nombre { get; set; }

        [MinLength(10, ErrorMessage="Ingresa una descripcion mayor a 10 caracteres")]
        public string Descripcion { get; set; }

        [MinLength(1,ErrorMessage="Ingresa un precio mayor a $1")]
        public decimal Precio { get; set; }

        [MaxLength(3,ErrorMessage="Las existencias deben ser menores a 999")]
        public int Existencia { get; set; }

        [MinLength(3,ErrorMessage="Nombre de subcategoria debe ser mayor a 3 caracteres")]
        public Subcategoria Subcategoria { get; set; }


        public ICollection<ImagenProducto> Imagenes { get; set; }
    }
}