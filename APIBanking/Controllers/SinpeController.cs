using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIBanking.Models;

namespace APIBanking.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Sinpe")]
    public class SinpeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            Sinpe sinpe = new Sinpe();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, TelefonoSinpe, FechaRegistro, Estado, CodigoCuenta
                                                             FROM   Sinpe
                                                             WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", id);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        sinpe.Codigo = sqlDataReader.GetInt32(0);
                        sinpe.TelefonoSinpe = sqlDataReader.GetString(1);
                        sinpe.FechaRegistro = sqlDataReader.GetDateTime(2);
                        sinpe.Estado = sqlDataReader.GetString(3);
                        sinpe.CodigoCuenta = sqlDataReader.GetInt32(4);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(sinpe);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Sinpe> sinpes = new List<Sinpe>();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, TelefonoSinpe, FechaRegistro, Estado, CodigoCuenta
                                                             FROM   Sinpe", sqlConnection);
                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        Sinpe sinpe = new Sinpe();
                        sinpe.Codigo = sqlDataReader.GetInt32(0);
                        sinpe.TelefonoSinpe = sqlDataReader.GetString(1);
                        sinpe.FechaRegistro = sqlDataReader.GetDateTime(2);
                        sinpe.Estado = sqlDataReader.GetString(3);
                        sinpe.CodigoCuenta = sqlDataReader.GetInt32(4);
                        sinpes.Add(sinpe);
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(sinpes);
        }


        [HttpPost]
        public IHttpActionResult Ingresar(Sinpe sinpe)
        {
            if (sinpe == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand =
                        new SqlCommand(@" INSERT INTO Sinpe (TelefonoSinpe, FechaRegistro, Estado, CodigoCuenta) 
                                         VALUES (@TelefonoSinpe, @FechaRegistro, @Estado,@CodigoCuenta)",
                                sqlConnection);
                                
                    sqlCommand.Parameters.AddWithValue("@TelefonoSinpe", sinpe.TelefonoSinpe);
                    sqlCommand.Parameters.AddWithValue("@FechaRegistro", sinpe.FechaRegistro);
                    sqlCommand.Parameters.AddWithValue("@Estado", sinpe.Estado);
                    sqlCommand.Parameters.AddWithValue("@CodigoCuenta", sinpe.CodigoCuenta);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(sinpe);
        }

        [HttpPut]
        public IHttpActionResult Actualizar(Sinpe sinpe)
        {
            if (sinpe == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand =
                        new SqlCommand(@" UPDATE Sinpe 
                                                        SET 
                                                            TelefonoSinpe = @TelefonoSinpe,
                                                            FechaRegistro = @FechaRegistro,
                                                            CodigoCuenta = @CodigoCuenta
                                                            Estado = @Estado 
                                          WHERE Codigo = @Codigo",
                                         sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", sinpe.Codigo);
                    sqlCommand.Parameters.AddWithValue("@TelefonoSinpe", sinpe.TelefonoSinpe);
                    sqlCommand.Parameters.AddWithValue("@FechaRegistro", sinpe.FechaRegistro);
                    sqlCommand.Parameters.AddWithValue("@CodigoCuenta", sinpe.CodigoCuenta);
                    sqlCommand.Parameters.AddWithValue("@Estado", sinpe.Estado);
                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(sinpe);
        }

        [HttpDelete]
        public IHttpActionResult Eliminar(int id)
        {
            if (id < 1)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand =
                        new SqlCommand(@" DELETE Sinpe WHERE Codigo = @Codigo",
                                         sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", id);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(id);
        }
    }
}