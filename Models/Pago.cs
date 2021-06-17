using System;

namespace fan_07.Models
{
    public class Pago
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public ApplicationUser Usuario { get; set; }
        public string Numero { get; set; }
        public string Fecha { get; set; }
    }
}