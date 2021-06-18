using System;

namespace fan_07.Models
{
    public class Distribuidor
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(50,ErrorMessage="Ingresa un nombre de paqueteria Menor a 50 caracteres")]
        public string NombrePaqueteria { get; set; }

        [MinLength(12,ErrorMessage="El RFC es de 12 caracteres" ),MaxLength(12)]
        public string RFC { get; set; }

        public string URL { get; set; }

        [MaxLength(50,ErrorMessage="Ingresa un nombre de responsable Menor a 50 caracteres")]
        public string NombreResponsable { get; set; }

        [MaxLength(80, ErrorMessage="Ingresa un correo menor a 80 caracteres")]
        public string Correo { get; set; }

        [MinLength(10,ErrorMessage="Ingresa un telefono de minimo 10 digitos")]
        public string Telefono { get; set; }

        [MinLength(1,ErrorMessage="Ingresa un costo mayor a $1")]
        public decimal Costo { get; set; }

        //Dias que tarda en entregar el pedido
        [MinLength(1,ErrorMessage="Ingresa minimo 1 dia")]
        public int Dias { get; set; }

    }
}