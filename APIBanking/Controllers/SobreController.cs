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
    [RoutePrefix("api/Sobre")]
    public class SobreController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            Sobre sobre = new Sobre();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoCuenta, Saldo, CodigoMoneda,FechaCreacion, Descripcion, Estado
                                                             FROM   Sobre
                                                             WHERE Codigo = @Codigo", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", id);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        sobre.Codigo = sqlDataReader.GetInt32(0);
                        sobre.CodigoCuenta = sqlDataReader.GetInt32(1);
                        sobre.Saldo = sqlDataReader.GetDecimal(2);
                        sobre.CodigoMoneda = sqlDataReader.GetInt32(3);
                        sobre.FechaCreacion = sqlDataReader.GetDateTime(4);
                        sobre.Descripcion = sqlDataReader.GetString(5);
                        sobre.Estado = sqlDataReader.GetString(6);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(sobre);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Sobre> sobres = new List<Sobre>();
            try
            {
                using (SqlConnection sqlConnection = new
                    SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo, CodigoCuenta, Saldo, CodigoMoneda,FechaCreacion, Descripcion, Estado

                                                             FROM   Sobre", sqlConnection);
                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        Sobre sobre = new Sobre();
                        sobre.Codigo = sqlDataReader.GetInt32(0);
                        sobre.CodigoCuenta = sqlDataReader.GetInt32(1);
                        sobre.Saldo = sqlDataReader.GetDecimal(2);
                        sobre.CodigoMoneda = sqlDataReader.GetInt32(3);
                        sobre.FechaCreacion = sqlDataReader.GetDateTime(4);
                        sobre.Descripcion = sqlDataReader.GetString(5);
                        sobre.Estado = sqlDataReader.GetString(6);
                        sobres.Add(sobre);
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(sobres);
        }


        [HttpPost]
        public IHttpActionResult Ingresar(Sobre sobre)
        {
            if (sobre == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand =
                        new SqlCommand(@" INSERT INTO Sobre ( CodigoCuenta, Saldo, CodigoMoneda,FechaCreacion, Descripcion, Estado
) 
                                         VALUES (@CodigoCuenta, @Saldo, @CodigoMoneda,@FechaCreacion, @Descripcion, @Estado)",
                                sqlConnection);
                                
                    sqlCommand.Parameters.AddWithValue("@CodigoCuenta", sobre.CodigoCuenta);
                    sqlCommand.Parameters.AddWithValue("@Saldo", sobre.Saldo);
                    sqlCommand.Parameters.AddWithValue("@CodigoMoneda", sobre.CodigoMoneda);
                    sqlCommand.Parameters.AddWithValue("@FechaCreacion", sobre.FechaCreacion);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", sobre.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@Estado", sobre.Estado);

                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(sobre);
        }

        [HttpPut]
        public IHttpActionResult Actualizar(Sobre sobre)
        {
            if (sobre == null)
                return BadRequest();

            try
            {
                using (SqlConnection sqlConnection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand =
                        new SqlCommand(@" UPDATE Sobre 
                                                        SET 
                                                            CodigoCuenta = @CodigoCuenta,
                                                            Saldo = @Saldo,
                                                            CodigoMoneda = @CodigoMoneda,
                                                            FechaCreacion = @FechaCreacion,
                                                            Descripcion = @Descripcion,
                                                            Estado = @Estado 
                                          WHERE Codigo = @Codigo",
                                         sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@Codigo", sobre.Codigo);
                    sqlCommand.Parameters.AddWithValue("@CodigoCuenta", sobre.CodigoCuenta);
                    sqlCommand.Parameters.AddWithValue("@Saldo", sobre.Saldo);
                    sqlCommand.Parameters.AddWithValue("@CodigoMoneda", sobre.CodigoMoneda);
                    sqlCommand.Parameters.AddWithValue("@FechaCreacion", sobre.FechaCreacion);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", sobre.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@Estado", sobre.Estado);
                    sqlConnection.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(sobre);
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
                        new SqlCommand(@" DELETE Sobre WHERE Codigo = @Codigo",
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