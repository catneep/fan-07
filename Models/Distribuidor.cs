using System;

namespace fan_07.Models
{
    public class Distribuidor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public decimal Costo { get; set; }

        //Dias que tarda en entregar el pedido
        public int Dias { get; set; }

    }
}