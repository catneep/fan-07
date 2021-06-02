using System;

namespace fan_07.Models
{
    public class Envio
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Distribuidor Distribuidor { get; set; }
        public Pedido Pedido { get; set; }
        public DateTime FechaEstimada { get; set; }
        public int Estado { get; set; } = 0;
    }
}