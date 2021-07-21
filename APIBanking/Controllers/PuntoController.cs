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
    [Authorize]
    [RoutePrefix("api/error")]
    public class PuntoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult getById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                Punto punto = new Punto();
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo,CodigoCuenta,CantidadPuntos,Estado,UltimoIngreso from Punto where Codigo=@Codigo", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", id);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        punto = new Punto { 
                            Codigo = reader.GetInt32(0), 
                            CodigoCuenta = reader.GetInt32(1), 
                            CantidadPuntos = reader.GetInt32(2), 
                            Estado = reader.GetString(3), 
                            UltimoIngreso = reader.GetDateTime(4)
                        };
                    }
                    sqlConnection.Close();

                    if (punto.Codigo == 0)
                    {
                        return NotFound();
                    }
                }
                return Ok(punto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        public IHttpActionResult getAll()
        {
            try
            {
                List<Punto> list = new List<Punto>();
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo,CodigoCuenta,CantidadPuntos,Estado,UltimoIngreso from Punto", sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new Punto {
                            Codigo = reader.GetInt32(0),
                            CodigoCuenta = reader.GetInt32(1),
                            CantidadPuntos = reader.GetInt32(2),
                            Estado = reader.GetString(3),
                            UltimoIngreso = reader.GetDateTime(4)
                        });
                    }
                    sqlConnection.Close();
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult insert(Punto punto)
        {
            if (punto == null)
            {
                return BadRequest();
            }
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"insert into Punto(CodigoCuenta,CantidadPuntos,Estado,UltimoIngreso) output inserted.Codigo values(@CodigoCuenta,@CantidadPuntos,@Estado,@UltimoIngreso)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@CodigoCuenta", punto.CodigoCuenta);
                    sqlCommand.Parameters.AddWithValue("@CantidadPuntos", punto.CantidadPuntos);
                    sqlCommand.Parameters.AddWithValue("@Estado", punto.Estado);
                    sqlCommand.Parameters.AddWithValue("@UltimoIngreso", DateTime.Now);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        punto.Codigo = reader.GetInt32(0);
                    }
                    sqlConnection.Close();

                    return Ok(punto);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        [HttpDelete]
        public IHttpActionResult borrar(int id)
        {
            if (id == 0)
                return BadRequest();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"delete Punto  where Codigo=@Codigo", sqlConnection);
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



        [HttpPut]
        public IHttpActionResult Actualizar(Punto punto)
        {
            if (punto == null)
            {
                return BadRequest();
            }
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    //Se salta la actualizacion de la fecha 
                    SqlCommand sqlCommand = new SqlCommand(@"update Punto set CodigoCuenta=@CodigoCuenta,CantidadPuntos=@CantidadPuntos,Estado=@Estado,UltimoIngreso=@UltimoIngreso where Codigo=@Codigo", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", punto.Codigo);
                    sqlCommand.Parameters.AddWithValue("@CodigoCuenta", punto.CodigoCuenta);
                    sqlCommand.Parameters.AddWithValue("@CantidadPuntos", punto.CantidadPuntos);
                    sqlCommand.Parameters.AddWithValue("@Estado", punto.Estado);
                    sqlCommand.Parameters.AddWithValue("@UltimoIngreso", punto.UltimoIngreso);
                    sqlConnection.Open();
                    int filasAfectadas = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (filasAfectadas > 0)
                    {
                        return Ok();
                    }
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


    }
}
