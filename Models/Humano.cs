using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaSithec.Models
{
    public class Humano
    {
        public int id { get; set; } = 0;
        public string nombre { get; set; } = "";
        public char sexo { get; set; } = 'M'; //Masculino - M; Femenino - F; Otro - O
        public int edad { get; set; } = 0;
        public decimal altura { get; set; } = 0;
        public decimal peso { get; set; } = 0;
    }

    //Id, Nombre, Sexo, Edad, Altura y Peso
}
