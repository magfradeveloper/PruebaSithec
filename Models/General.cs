using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaSithec.Models
{
    public class General
    {
        public static Conexion Conectar()
        {
            //return new Conexion("ProductosRamiro", "LAPTOP-6VNF4VTV\\SQLEXPRESS", "Pruebas", "1234");
            return new Conexion("PruebaSithec", "LAPTOP-6VNF4VTV\\SQLEXPRESS", "Pruebas", "1234");

        }

        public static Conexion conexComer()
        {
            return new Conexion("Comercio", "207.210.232.61", "comer155_db", "0sc@r_210697");
            //return new Conexion("Comercio", "LAPTOP-6VNF4VTV\\SQLEXPRESS", "Pruebas", "1234");
        }

        public class Conexion : DarkSoft.SQL.Conexion
        {
            public Conexion(ref SqlConnection Conexion) : base(ref Conexion)
            {
            }

            public Conexion(string BD, string Servidor, string Usuario, string Clave) : base(BD, Servidor, Usuario, Clave)
            {
            }

            //public Conexion(string Instancia, string Archivo, string BD, bool Data = false) : base(Instancia, Archivo, BD, Data)
            //{
            //}

            public DataTable ConsultarDT(string Consulta, SqlParameter[] Parametros, int tiempoEspera = 1200)
            {
                try
                {
                    SqlCommand sc = new SqlCommand(Consulta, Con);
                    if (Parametros.Length > 0)
                    {
                        foreach (SqlParameter parametro in Parametros)
                        {
                            sc.Parameters.Add(parametro);
                        }
                    }

                    SqlDataAdapter da = new SqlDataAdapter(sc);
                    DataTable ds = new DataTable();
                    ds.Clear();
                    da.SelectCommand.CommandTimeout = tiempoEspera;
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            public bool ModRegEli(string Consulta, SqlParameter[] Parametros, int tiempoEspera = 1200)
            {
                bool res = false;

                if (Consulta != "")
                {
                    SqlCommand Com;
                    try
                    {
                        Com = new SqlCommand(Consulta, Con)
                        {
                            CommandTimeout = tiempoEspera
                        };
                        if (Parametros.Length > 0)
                        {
                            foreach (SqlParameter parametro in Parametros)
                            {
                                Com.Parameters.Add(parametro);
                            }
                        }
                        Con.Open();
                        Com.ExecuteNonQuery();
                        res = true;
                        Con.Close();
                    }
                    catch (Exception) { }
                    finally
                    {
                    }
                }

                return res;
            }
        }
    }
}
