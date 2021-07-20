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
    [AllowAnonymous]
    [RoutePrefix("api/seguridad")]
    public class SeguridadController : ApiController
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
                Seguridad seguridad = new Seguridad();
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo,CodigoUsuario,Llamada,Token,OTP from Seguridad where Codigo=@Codigo", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", id);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        seguridad = new Seguridad
                        {
                            Codigo = reader.GetInt32(0),
                            CodigoUsuario = reader.GetInt32(1),
                            Llamada = reader.GetString(2),
                            Token = reader.GetString(3),
                            OTP = reader.GetString(3)
                        };

                    }
                    sqlConnection.Close();

                    if (seguridad.Codigo == 0)
                    {
                        return NotFound();
                    }
                }
                return Ok(seguridad);
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
                List<Seguridad> list = new List<Seguridad>();
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo,CodigoUsuario,Llamada,Token,OTP from Seguridad", sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new Seguridad { Codigo = reader.GetInt32(0), CodigoUsuario = reader.GetInt32(1), Llamada = reader.GetString(2), Token = reader.GetString(3), OTP = reader.GetString(4) });
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
        public IHttpActionResult insert(Seguridad seguridad)
        {
            if (seguridad == null)
            {
                return BadRequest();
            }
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"insert into Seguridad(CodigoUsuario,Llamada,Token,OTP) output inserted.Codigo values(@CodigoUsuario,@Llamada,@Token,@OTP)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@CodigoUsuario", seguridad.CodigoUsuario);
                    sqlCommand.Parameters.AddWithValue("@Llamada", seguridad.Llamada);
                    sqlCommand.Parameters.AddWithValue("@Token", seguridad.Token);
                    sqlCommand.Parameters.AddWithValue("@OTP", seguridad.OTP);

                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        seguridad.Codigo = reader.GetInt32(0);
                    }
                    sqlConnection.Close();

                    return Ok(seguridad);
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
                    SqlCommand sqlCommand = new SqlCommand(@"delete Seguridad  where Codigo=@Codigo", sqlConnection);
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
        public IHttpActionResult Actualizar(Seguridad seguridad)
        {
            if (seguridad == null)
            {
                return BadRequest();
            }
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand(@"update Seguridad set CodigoUsuario=@CodigoUsuario,Llamada=@Llamada,Token=@Token,OTP=@OTP where Codigo=@Codigo", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", seguridad.Codigo);
                    sqlCommand.Parameters.AddWithValue("@CodigoUsuario", seguridad.CodigoUsuario);
                    sqlCommand.Parameters.AddWithValue("@Llamada ", seguridad.Llamada);
                    sqlCommand.Parameters.AddWithValue("@Token ", seguridad.Token);
                    sqlCommand.Parameters.AddWithValue("@OTP ", seguridad.OTP);

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
