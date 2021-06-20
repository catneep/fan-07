using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fan_07.Models
{
    public class Pedido
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public ApplicationUser Usuario { get; set; }
        public Envio Envio { get; set; } = null;
        [MinLength(25,ErrorMessage="Ingresa un domicilio mayor a 25 caracteres y menor a 500"),MaxLength(500)]
        public string Direccion { get; set; }
        public List<Producto> Productos { get; set; }
    }
}