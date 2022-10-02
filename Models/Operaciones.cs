using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaSithec.Models
{
    public class Operaciones
    {
        public int op1 { get; set; } = 0;
        public int op2 { get; set; } = 0;
        public int tipoOperacion { get; set; } = 1; //1 - Suma; 2 - Resta; 3 - Multiplicacion; 4 - Division
    }

    public class Resultado {
        public string operacion { get; set; } = "";
        public decimal resultado { get; set; } = 0;
    }
}
