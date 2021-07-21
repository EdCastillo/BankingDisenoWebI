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
    [RoutePrefix("api/tarjeta")]
    public class TarjetaController : ApiController
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
                Tarjeta tarjeta = new Tarjeta();
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo,NumeroTarjeta,CodigoCuenta,FechaEmision,FechaExpiracion,CVC,Tipo from Tarjeta where Codigo=@Codigo", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", id);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        tarjeta = new Tarjeta { Codigo = reader.GetInt32(0), NumeroTarjeta = reader.GetInt32(1), CodigoCuenta = reader.GetInt32(2), FechaEmision = reader.GetDateTime(3), FechaExpiracion = reader.GetDateTime(4), CVC = reader.GetInt32(5), Tipo = reader.GetString(6) };
                    }
                    sqlConnection.Close();

                    if (tarjeta.Codigo == 0)
                    {
                        return NotFound();
                    }
                }
                return Ok(tarjeta);
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
                List<Tarjeta> list = new List<Tarjeta>();
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo,NumeroTarjeta,CodigoCuenta,FechaEmision,FechaExpiracion,CVC,Tipo from Tarjeta", sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new Tarjeta { Codigo = reader.GetInt32(0), NumeroTarjeta = reader.GetInt32(1), CodigoCuenta = reader.GetInt32(2), FechaEmision = reader.GetDateTime(3), FechaExpiracion = reader.GetDateTime(4), CVC = reader.GetInt32(5), Tipo = reader.GetString(6) });
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
        public IHttpActionResult insert(Tarjeta tarjeta)
        {
            if (tarjeta == null)
            {
                return BadRequest();
            }
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"insert into Tarjeta(NumeroTarjeta,CodigoCuenta,FechaEmision,FechaExpiracion,CVC, Tipo) output inserted.Codigo values(@NumeroTarjeta,@CodigoCuenta,@FechaEmision,@FechaExpiracion,@CVC, @Tipo)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@NumeroTarjeta", tarjeta.NumeroTarjeta);
                    sqlCommand.Parameters.AddWithValue("@CodigoCuenta", tarjeta.CodigoCuenta);
                    sqlCommand.Parameters.AddWithValue("@FechaEmision", tarjeta.FechaEmision);
                    sqlCommand.Parameters.AddWithValue("@FechaExpiracion", tarjeta.FechaExpiracion);
                    sqlCommand.Parameters.AddWithValue("@CVC", tarjeta.CVC);
                    sqlCommand.Parameters.AddWithValue("@Tipo", tarjeta.Tipo);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        tarjeta.Codigo = reader.GetInt32(0);
                    }
                    sqlConnection.Close();

                    return Ok(tarjeta);
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
                    SqlCommand sqlCommand = new SqlCommand(@"delete Tarjeta where Codigo=@Codigo", sqlConnection);
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
        public IHttpActionResult Actualizar(Tarjeta tarjeta)
        {
            if (tarjeta == null)
            {
                return BadRequest();
            }
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    //Se salta la actualizacion de la fecha 
                    SqlCommand sqlCommand = new SqlCommand(@"update Tarjeta set NumeroTarjeta=@NumeroTarjeta,CodigoCuenta=@CodigoCuenta,FechaEmision=@FechaEmision,FechaExpiracion=@FechaExpiracion,CVC=@CVC,Tipo=@Tipo where Codigo=@Codigo", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", tarjeta.Codigo);
                    sqlCommand.Parameters.AddWithValue("@NumeroTarjeta", tarjeta.NumeroTarjeta);
                    sqlCommand.Parameters.AddWithValue("@CodigoCuenta", tarjeta.CodigoCuenta);
                    sqlCommand.Parameters.AddWithValue("@FechaEmision", tarjeta.FechaEmision);
                    sqlCommand.Parameters.AddWithValue("@FechaExpiracion", tarjeta.FechaExpiracion);
                    sqlCommand.Parameters.AddWithValue("@CVC", tarjeta.CVC);
                    sqlCommand.Parameters.AddWithValue("@Tipo", tarjeta.Tipo);
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