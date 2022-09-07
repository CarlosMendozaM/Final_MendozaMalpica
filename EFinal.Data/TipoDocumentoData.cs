using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using EFinal.Dominio;

namespace EFinal.Data
{
    public class TipoDocumentoData
    {
        string cadenaconexion = "Server=localhost; DataBase=Final; Integrated security=true";
        public List<TipoDocumento> Listar()
        {
            var listado = new List<TipoDocumento>();
            using (var conexion = new SqlConnection(cadenaconexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT * FROM TipoDocumento", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            TipoDocumento tipo;
                            while (lector.Read())
                            {
                                tipo = new TipoDocumento();
                                tipo.ID = int.Parse(lector[0].ToString());
                                tipo.Nombre = lector[1].ToString();
                                listado.Add(tipo);
                            }
                        }
                    }
                }
            }
            return listado;
        }
    }
}
