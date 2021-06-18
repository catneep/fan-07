using System;
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

        [MinLength(3,ErrorMessage="Nombre de usuario debe ser mayor a 5 caracteres")]
        public ApplicationUser Usuario { get; set; }

        [MinLength(2,ErrorMessage="Ingresa un envio mayor a 2 caracteres")]
        public Envio Envio { get; set; } = null;

        [MinLength(25,ErrorMessage="Ingresa un domicilio mayor a 25 caracteres y menor a 500"),MaxLength(500)]
        public string Direccion { get; set; }
    }
}