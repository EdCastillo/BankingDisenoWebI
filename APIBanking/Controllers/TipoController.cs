using APIBanking.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIBanking.Controllers
{
    public class TipoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult getByID(int id) {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString)) {
                Tipo tipo = new Tipo();
                SqlCommand sqlCommand = new SqlCommand(@"Select Nombre,Descripcion from TIPO where Codigo=@Codigo",sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Codigo",id);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read()) {
                    tipo.Descripcion=reader.GetString(1);
                    tipo.Nombre = reader.GetString(0);
                    tipo.Codigo = id;
                }
                return Ok(tipo);
            }
        }
        [HttpPost]
        public IHttpActionResult Insertar(Tipo tipo) {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString)) {
                SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO TIPO VALUES(@NOMBRE,@DESCRIPCION)",sqlConnection);
                sqlCommand.Parameters.AddWithValue("@NOMBRE",tipo.Nombre);
                sqlCommand.Parameters.AddWithValue("@DESCRIPCION", tipo.Descripcion);
                sqlConnection.Open();
                int rowsAffected=sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                if (rowsAffected > 0)
                {
                    return Ok();
                }
                else {
                    return InternalServerError();
                }
            }
        }


    }
}
