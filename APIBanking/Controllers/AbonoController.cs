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
    [RoutePrefix("api/abono")]
    public class AbonoController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Insertar(Abono abono) {
            if (abono == null)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString)) {
                        SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO ABONO output inserted.Codigo VALUES(@CODIGOPRESTAMO,@FECHA,@CANTIDAD)",sqlConnection);
                        sqlCommand.Parameters.AddWithValue("@CODIGOPRESTAMO",abono.CodigoPrestamo);
                        sqlCommand.Parameters.AddWithValue("@FECHA", abono.Fecha);
                        sqlCommand.Parameters.AddWithValue("@CANTIDAD", abono.Cantidad);
                        sqlConnection.Open();
                        SqlDataReader reader= sqlCommand.ExecuteReader();
                        while (reader.Read()) {
                            abono.Codigo=reader.GetInt32(0);
                        }
                        sqlConnection.Close();
                        if (abono.Codigo != 0)
                        {
                            return Ok(abono);
                        }
                        else {
                            return InternalServerError();
                        }
                    }
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
        }
        [HttpGet]
        public IHttpActionResult getByID(int id) {
            if (id == 0)
            {
                return BadRequest();
            }
            else {
                Abono abono = new Abono();
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString)) {

                    SqlCommand sqlCommand = new SqlCommand(@"SELECT CODIGOPRESTAMO,FECHA,CANTIDAD FROM ABONO WHERE CODIGO=@CODIGO", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@CODIGO", id);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        abono.Codigo = id;
                        abono.CodigoPrestamo = reader.GetInt32(0);
                        abono.Fecha = reader.GetDateTime(1);
                        abono.Cantidad = reader.GetDecimal(2);
                    }
                    sqlConnection.Close();
                    return Ok(abono);

                }
            }
        }
        [HttpGet]
        public IHttpActionResult getAll()
        {
            List<Abono> list = new List<Abono>();
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand(@"SELECT CODIGO,CODIGOPRESTAMO,FECHA,CANTIDAD FROM ABONO", sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Abono abono = new Abono();
                        abono.Codigo = reader.GetInt32(0);
                        abono.CodigoPrestamo = reader.GetInt32(1);
                        abono.Fecha = reader.GetDateTime(2);
                        abono.Cantidad = reader.GetDecimal(3);
                    list.Add(abono);
                    }
                    sqlConnection.Close();
                    return Ok(list);
            }
        }



        [HttpPut]
        public IHttpActionResult Actualizar(Abono abono) {
            if (abono == null)
            {
                return BadRequest();
            }
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"update Abono set CodigoPrestamo=@CodigoPrestamo,Fecha=@Fecha,CANTIDAD=@CANTIDAD where Codigo=@Codigo", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", abono.Codigo);
                    sqlCommand.Parameters.AddWithValue("@CodigoPrestamo", abono.CodigoPrestamo);
                    sqlCommand.Parameters.AddWithValue("@Fecha", abono.Fecha);
                    sqlCommand.Parameters.AddWithValue("@CANTIDAD", abono.Cantidad);
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
        public IHttpActionResult borrar(int id)
        {
            if (id == 0)
                return BadRequest();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"delete Abono  where Codigo=@Codigo", sqlConnection);
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
