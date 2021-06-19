using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fan_07.Models
{
    public class Pedido
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [MinLength(1,ErrorMessage="Ingrese un total mayor a 1 digito")]
        public decimal Total { get; set; }
        [MinLength(10,ErrorMessage="Ingresa una fecha en formato DD/MM/AAAA")]
        public DateTime Fecha { get; set; } = DateTime.Now;
        public ApplicationUser Usuario { get; set; }
        
        public Envio Envio { get; set; } = null;
        [MinLength(25,ErrorMessage="Ingresa un domicilio mayor a 25 caracteres y menor a 500"),MaxLength(500)]
        public string Direccion { get; set; }
        public List<Producto> Productos { get; set; }
    }
}