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
    [RoutePrefix("api/cuenta")]
    public class CuentaController : ApiController
    {

        [HttpGet]
        public IHttpActionResult getByID(int id) {
            if (id == 0) {
                return BadRequest();
            }
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo,CodigoUsuario,Descripcion,IBAN,CodigoMoneda,Saldo,Estado FROM Cuenta where Codigo=@Codigo", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", id);
                    Cuenta cuenta = new Cuenta();
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        cuenta = new Cuenta { Codigo = reader.GetInt32(0), CodigoUsuario = reader.GetInt32(1), Descripcion = reader.GetString(2), IBAN = reader.GetString(3), CodigoMoneda = reader.GetInt32(4), Saldo = reader.GetDecimal(5), Estado = reader.GetString(6) };
                    }
                    sqlConnection.Close();
                    return Ok(cuenta);
                }
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
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo,CodigoUsuario,Descripcion,IBAN,CodigoMoneda,Saldo,Estado FROM Cuenta", sqlConnection);
                    List<Cuenta> list = new List<Cuenta>();
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new Cuenta { Codigo = reader.GetInt32(0), CodigoUsuario = reader.GetInt32(1), Descripcion = reader.GetString(2), IBAN = reader.GetString(3), CodigoMoneda = reader.GetInt32(4), Saldo = reader.GetDecimal(5), Estado = reader.GetString(6) });
                    }
                    sqlConnection.Close();
                    return Ok(list);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }


        [HttpPost]
        public IHttpActionResult Ingresar(Cuenta cuenta) {
            if (cuenta == null)
                return BadRequest();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"insert into Cuenta output inserted.Codigo values(@CodigoUsuario,@Descripcion,@IBAN,@CodigoMoneda,@Saldo,@Estado)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@CodigoUsuario",cuenta.CodigoUsuario);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", cuenta.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@IBAN", cuenta.IBAN);
                    sqlCommand.Parameters.AddWithValue("@CodigoMoneda", cuenta.CodigoMoneda);
                    sqlCommand.Parameters.AddWithValue("@Saldo", cuenta.Saldo);
                    sqlCommand.Parameters.AddWithValue("@Estado", cuenta.Estado);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        cuenta.Codigo = reader.GetInt32(0);
                    }
                    sqlConnection.Close();
                    return Ok(cuenta);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }


        [HttpPut]
        public IHttpActionResult Actualizar(Cuenta cuenta)
        {
            if (cuenta == null)
                return BadRequest();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"update Cuenta set CodigoUsuario=@CodigoUsuario,Decripcion=@Descripcion,IBAN=@IBAN,CodigoMoneda=@CodigoMoneda,Saldo=@Saldo,Estado=@Estado where Codigo=@Codigo", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", cuenta.Codigo);
                    sqlCommand.Parameters.AddWithValue("@CodigoUsuario", cuenta.CodigoUsuario);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", cuenta.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@IBAN", cuenta.IBAN);
                    sqlCommand.Parameters.AddWithValue("@CodigoMoneda", cuenta.CodigoMoneda);
                    sqlCommand.Parameters.AddWithValue("@Saldo", cuenta.Saldo);
                    sqlCommand.Parameters.AddWithValue("@Estado", cuenta.Estado);
                    sqlConnection.Open();
                    int filasAfectadas = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (filasAfectadas > 0) {
                        return Ok(cuenta);
                    }
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        [HttpDelete]
        public IHttpActionResult Borrar(int id)
        {
            if (id == 0)
                return BadRequest();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"delete Cuenta  where Codigo=@Codigo", sqlConnection);
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
