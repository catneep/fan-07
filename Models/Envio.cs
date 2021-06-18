using System;
using System.ComponentModel.DataAnnotations;

namespace fan_07.Models
{
    public class Envio
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(25, ErrorMessage="Ingresa un distribuidor menor a 25 caracteres")]
        public Distribuidor Distribuidor { get; set; }

        public DateTime FechaEstimada { get; set; }

        [MinLength(5, ErrorMessage="Ingresa el nombre del estado mayor a 5 letras")]
        public int Estado { get; set; } = 0;
    }
}