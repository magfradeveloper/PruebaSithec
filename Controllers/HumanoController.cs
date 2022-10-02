using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaSithec.Models;

namespace PruebaSithec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanoController : ControllerBase
    {
        [HttpPost]
        [Route("nuevoHumano")]

        public IActionResult nuevoHumano(Humano humano) {
            string sql = $"insert into Humano(nombre, sexo, edad, altura, peso) values('{humano.nombre}', '{humano.sexo}', {humano.edad}, {humano.altura}, {humano.peso})";
            if (General.Conectar().ModRegEli(sql))
                return StatusCode(200);
            else
                return StatusCode(400);
        }

        [HttpPut]
        [Route("actualizarHumano")]

        public IActionResult actualizarHumano(Humano humano) {
            string sql = $"update Humano set nombre='{humano.nombre}', sexo='{humano.sexo}', edad={humano.edad}, altura={humano.altura}, peso={humano.peso} where id={humano.id}";
            if (General.Conectar().ModRegEli(sql))
                return StatusCode(200);
            else
                return StatusCode(400);
        }

        [HttpGet]
        [Route("consultarHumanos")]

        public List<Humano> consultarHumanos() {
            List<Humano> humanos = new List<Humano>();
            string sql = "select * from Humano";
            DataTable dthum = General.Conectar().ConsultarDT(sql);
            if (dthum != null && dthum.Rows.Count > 0) {
                for(var i=0; i<dthum.Rows.Count; i++)
                    humanos.Add(new Humano { id = int.Parse(dthum.Rows[i]["id"].ToString()), nombre = dthum.Rows[i]["nombre"].ToString(), sexo=char.Parse(dthum.Rows[i]["sexo"].ToString()), edad=int.Parse(dthum.Rows[i]["edad"].ToString()), altura=decimal.Parse(dthum.Rows[i]["altura"].ToString()), peso=decimal.Parse(dthum.Rows[i]["peso"].ToString()) });
            }
            return humanos;
        }

        [HttpGet]
        [Route("consultarHumano")]

        public Humano consultarHumano(int id)
        {
            Humano hum = new Humano();
            string sql = $"select * from Humano where id={id}";
            DataTable dthum = General.Conectar().ConsultarDT(sql);
            if (dthum != null && dthum.Rows.Count > 0){
                hum.id = int.Parse(dthum.Rows[0]["id"].ToString());
                hum.nombre = dthum.Rows[0]["nombre"].ToString();
                hum.sexo = char.Parse(dthum.Rows[0]["sexo"].ToString());
                hum.edad = int.Parse(dthum.Rows[0]["edad"].ToString());
                hum.altura = decimal.Parse(dthum.Rows[0]["altura"].ToString());
                hum.peso = decimal.Parse(dthum.Rows[0]["peso"].ToString());
            }
            return hum;
        }
    }
}