using System;

namespace fan_07.Models
{
    public class Direccion
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [MinLength(25,ErrorMessage="Ingresa un domicilio mayor a 25 caracteres y menor a 500"),MaxLength(500)]
        public string Domicilio { get; set; }

        
        public ApplicationUser Usuario { get; set; }
    }
}