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
    [RoutePrefix("api/tipo")]
    [Authorize]
    public class TipoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult getByID(int id) {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString)) {
                Tipo tipo = new Tipo();
                SqlCommand sqlCommand = new SqlCommand(@"Select Nombre,Descripcion from TIPO where Codigo=@Codigo", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Codigo", id);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read()) {
                    tipo.Descripcion = reader.GetString(1);
                    tipo.Nombre = reader.GetString(0);
                    tipo.Codigo = id;
                }
                sqlConnection.Close();
                return Ok(tipo);
            }
        }
        [HttpPost]
        public IHttpActionResult Insertar(Tipo tipo) {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString)) {
                SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO TIPO VALUES(@NOMBRE,@DESCRIPCION)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@NOMBRE", tipo.Nombre);
                sqlCommand.Parameters.AddWithValue("@DESCRIPCION", tipo.Descripcion);
                sqlConnection.Open();
                int rowsAffected = sqlCommand.ExecuteNonQuery();
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

        [HttpGet]
        public IHttpActionResult GetAll() {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
            {
                List<Tipo> list = new List<Tipo>();
                SqlCommand sqlCommand = new SqlCommand(@"Select Codigo,Nombre,Descripcion from TIPO", sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Tipo tipo = new Tipo();
                    tipo.Descripcion = reader.GetString(1);
                    tipo.Nombre = reader.GetString(2);
                    tipo.Codigo = reader.GetInt32(0);
                    list.Add(tipo);
                }
                sqlConnection.Close();
                return Ok(list);
            }
        }
        [HttpPut]
        public IHttpActionResult Actualizar(Tipo tipo)
        {
            if (tipo == null)
            {
                return BadRequest();
            }
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"update Tipo set Nombre=@Nombre,Descripcion=@Descripcion where Codigo=@Codigo", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", tipo.Codigo);
                    sqlCommand.Parameters.AddWithValue("@Nombre", tipo.Nombre);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", tipo.Descripcion);
                    sqlConnection.Open();
                    int filasAfectadas = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (filasAfectadas > 0)
                    {
                        return Ok();
                    }
                    return InternalServerError();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpDelete]
        public IHttpActionResult delete(int id) {
            if (id == 0)
                return BadRequest();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"delete Tipo  where Codigo=@Codigo", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", id);
                    sqlConnection.Open();
                    int filasAfectadas = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (filasAfectadas > 0)
                    {
                        return Ok();
                    }
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

    }
}
