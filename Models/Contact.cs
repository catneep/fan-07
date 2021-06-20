using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fan_07.Models{
    public class Contact{

        [Required]
        public string Nombre {get; set;}

        [Required]
        public string ApellidoPaterno {get; set;}

        [Required]
        [EmailAddress]
        public string Correo {get; set;}

        [Required]
        public string Mensaje {get; set;}

    }
}