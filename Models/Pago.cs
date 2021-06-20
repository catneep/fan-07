using System;
using System.ComponentModel.DataAnnotations;

namespace fan_07.Models
{
    public class Pago
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public ApplicationUser Usuario { get; set; }

        [MaxLength(3,ErrorMessage="Numero debe ser menor a 4 digitos")]
        public string Numero { get; set; }

        [MinLength(10,ErrorMessage="Ingresa una fecha en formato DD/MM/AAAA")]
        public string Fecha { get; set; }
    }
}