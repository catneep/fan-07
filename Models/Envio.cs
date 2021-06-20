using System;
using System.ComponentModel.DataAnnotations;

namespace fan_07.Models
{
    public class Envio
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Distribuidor Distribuidor { get; set; }

        public DateTime FechaEstimada { get; set; }
        public int Estado { get; set; } = 0;
    }
}