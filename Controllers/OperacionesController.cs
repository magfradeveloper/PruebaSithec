using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaSithec.Models;

namespace PruebaSithec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesController : ControllerBase
    {
        [HttpPost]
        [Route("operacion")]

        public Resultado operacion(Operaciones op) {
            Resultado res = new Resultado();
            switch (op.tipoOperacion) {
                case 1:
                    res.operacion = "Suma";
                    res.resultado = op.op1 + op.op2;
                    break;

                case 2:
                    res.operacion = "Resta";
                    res.resultado = op.op1 - op.op2;
                    break;

                case 3:
                    res.operacion = "Multiplicacion";
                    res.resultado = op.op1 * op.op2;
                    break;

                case 4:
                    res.operacion = "División";
                    res.resultado = op.op1 / op.op2;
                    break;
            }
            return res;
        }
    }
}