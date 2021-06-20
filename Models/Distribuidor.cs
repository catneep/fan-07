using System;
using System.ComponentModel.DataAnnotations;

namespace fan_07.Models
{
    public class Distribuidor
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(50,ErrorMessage="Ingresa un nombre de paqueteria Menor a 50 caracteres")]
        public string Nombre { get; set; }

        [MaxLength(80, ErrorMessage="Ingresa un correo menor a 80 caracteres")]
        public string Correo { get; set; }

        [MinLength(10,ErrorMessage="Ingresa un telefono de minimo 10 digitos")]
        public string Telefono { get; set; }

        public decimal Costo { get; set; }

        //Dias que tarda en entregar el pedido
        public int Dias { get; set; }

    }
}