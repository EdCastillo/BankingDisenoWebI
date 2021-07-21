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
    [RoutePrefix("api/Prestamo")]
    public class PrestamoController : ApiController
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
                Prestamo prestamo = new Prestamo();
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo,CodigoMoneda,CodigoUsuario,MontoTotal,TasaInteres ,NumeroCuotas,FechaEmision,CodigoTipo  from Prestamo where Codigo=@Codigo", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", id);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        prestamo = new Prestamo
                        {
                            Codigo = reader.GetInt32(0),
                            CodigoMoneda = reader.GetInt32(1),
                            CodigoUsuario = reader.GetInt32(2),
                            MontoTotal = reader.GetDecimal(3),
                            TasaInteres = reader.GetDecimal(4),
                            NumeroCuotas = reader.GetInt32(5),
                            FechaEmision = reader.GetDateTime(6),
                            CodigoTipo = reader.GetInt32(7)
                        };
                    }
                    sqlConnection.Close();

                    if (prestamo.Codigo == 0)
                    {
                        return NotFound();
                    }
                }
                return Ok(prestamo);
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
                List<Prestamo> list = new List<Prestamo>();
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo,CodigoMoneda,CodigoUsuario,MontoTotal ,TasaInteres ,NumeroCuotas ,FechaEmision,CodigoTipo from Prestamo", sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new Prestamo
                        {
                            Codigo = reader.GetInt32(0),
                            CodigoMoneda = reader.GetInt32(1),
                            CodigoUsuario = reader.GetInt32(2),
                            MontoTotal = reader.GetDecimal(3),
                            TasaInteres = reader.GetDecimal(4),
                            NumeroCuotas = reader.GetInt32(5),
                            FechaEmision = reader.GetDateTime(6),
                            CodigoTipo = reader.GetInt32(7)
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
        public IHttpActionResult insert(Prestamo prestamo)
        {
            if (prestamo == null)
            {
                return BadRequest();
            }
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"insert into Prestamo(CodigoMoneda ,CodigoUsuario ,MontoTotal ,TasaInteres ,NumeroCuotas ,FechaEmision,CodigoTipo  ) output inserted.Codigo values(@CodigoMoneda,@CodigoUsuario,@MontoTotal,@TasaInteres,@NumeroCuotas,@FechaEmision,@CodigoTipo)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@CodigoMoneda", prestamo.CodigoMoneda);
                    sqlCommand.Parameters.AddWithValue("@CodigoUsuario", prestamo.CodigoUsuario);
                    sqlCommand.Parameters.AddWithValue("@MontoTotal", prestamo.MontoTotal);
                    sqlCommand.Parameters.AddWithValue("@TasaInteres", prestamo.TasaInteres);
                    sqlCommand.Parameters.AddWithValue("@NumeroCuotas", prestamo.NumeroCuotas);
                    sqlCommand.Parameters.AddWithValue("@FechaEmision", DateTime.Now);
                    sqlCommand.Parameters.AddWithValue("@CodigoTipo", prestamo.CodigoTipo);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        prestamo.Codigo = reader.GetInt32(0);
                    }
                    sqlConnection.Close();

                    return Ok(prestamo);
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
                    SqlCommand sqlCommand = new SqlCommand(@"delete Prestamo  where Codigo=@Codigo", sqlConnection);
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
        public IHttpActionResult Actualizar(Prestamo prestamo)
        {
            if (prestamo == null)
            {
                return BadRequest();
            }
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand(@"update Prestamo set CodigoMoneda=@CodigoMoneda ,CodigoUsuario=@CodigoUsuario ,MontoTotal=@MontoTotal ,TasaInteres=@TasaInteres,NumeroCuotas=@NumeroCuotas,CodigoTipo=@CodigoTipo where Codigo=@Codigo", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", prestamo.Codigo);
                    sqlCommand.Parameters.AddWithValue("@CodigoMoneda", prestamo.CodigoUsuario);
                    sqlCommand.Parameters.AddWithValue("@CodigoUsuario", prestamo.CodigoUsuario);
                    sqlCommand.Parameters.AddWithValue("@MontoTotal", prestamo.MontoTotal);
                    sqlCommand.Parameters.AddWithValue("@TasaInteres", prestamo.TasaInteres);
                    sqlCommand.Parameters.AddWithValue("@NumeroCuotas", prestamo.NumeroCuotas);
                    sqlCommand.Parameters.AddWithValue("@CodigoTipo", prestamo.CodigoTipo);

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
