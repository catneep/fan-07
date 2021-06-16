using System;

namespace fan_07.Models
{
    public class Direccion
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Domicilio { get; set; }
        public ApplicationUser Usuario { get; set; }
    }
}