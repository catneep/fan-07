using System;

namespace fan_07.Models
{
    public class Pedido
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public ApplicationUser Usuario { get; set; }
        public Envio Envio { get; set; } = null;
        public string Direccion { get; set; }
    }
}