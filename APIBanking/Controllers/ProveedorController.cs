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
    public class ProveedorController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Insertar(Proveedor proveedor)
        {
            if (proveedor == null)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                    {
                        SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO PROVEEDOR output inserted.Codigo VALUES(@NOMBREPROVEEDOR,@TELEFONOPROVEEDOR,@CORREOPROVEEDOR,@DESCRIPCION)", sqlConnection);
                        sqlCommand.Parameters.AddWithValue("@NOMBREPROVEEDOR", proveedor.NombreProveedor);
                        sqlCommand.Parameters.AddWithValue("@TELEFONOPROVEEDOR", proveedor.TelefonoProveedor);
                        sqlCommand.Parameters.AddWithValue("@CORREOPROVEEDOR", proveedor.CorreoProveedor);
                        sqlCommand.Parameters.AddWithValue("@DESCRIPCION", proveedor.Descripcion);
                        sqlConnection.Open();
                        SqlDataReader reader = sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            proveedor.Codigo = reader.GetInt32(0);
                        }
                        sqlConnection.Close();
                        if (proveedor.Codigo != 0)
                        {
                            return Ok(proveedor);
                        }
                        else
                        {
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
        public IHttpActionResult getByID(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                Proveedor proveedor = new Proveedor();
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {

                    SqlCommand sqlCommand = new SqlCommand(@"SELECT NOMBREPROVEEDOR,TELEFONOPROVEEDOR,CORREOPROVEEDOR,DESCRIPCION FROM PROVEEDOR WHERE CODIGO=@CODIGO", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@CODIGO", id);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        proveedor.Codigo = id;
                        proveedor.NombreProveedor = reader.GetString(0);
                        proveedor.TelefonoProveedor = reader.GetString(1);
                        proveedor.CorreoProveedor = reader.GetString(2);
                        proveedor.Descripcion = reader.GetString(3);
                    }
                    sqlConnection.Close();
                    return Ok(proveedor);

                }
            }
        }
        [HttpGet]
        public IHttpActionResult getAll()
        {
            List<Proveedor> list = new List<Proveedor>();
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
            {

                SqlCommand sqlCommand = new SqlCommand(@"SELECT CODIGO,NOMBREPROVEEDOR,TELEFONOPROVEEDOR,CORREOPROVEEDOR,DESCRIPCION FROM PROVEEDOR", sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Proveedor proveedor = new Proveedor();
                    proveedor.Codigo = reader.GetInt32(0);
                    proveedor.NombreProveedor = reader.GetString(1);
                    proveedor.TelefonoProveedor = reader.GetString(2);
                    proveedor.CorreoProveedor = reader.GetString(3);
                    proveedor.Descripcion = reader.GetString(4);
                    list.Add(proveedor);
                }
                sqlConnection.Close();
                return Ok(list);
            }
        }



        [HttpPut]
        public IHttpActionResult Actualizar(Proveedor proveedor)
        {
            if (proveedor == null)
            {
                return BadRequest();
            }
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"update Proveedor set NombreProveedor=@NombreProveedor,TelefonoProveedor=@TelefonoProveedor,CorreoProveedor=@CorreoProveedor,Descripcion=@Descripcion where Codigo=@Codigo", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", proveedor.Codigo);
                    sqlCommand.Parameters.AddWithValue("@NombreProveedor", proveedor.NombreProveedor);
                    sqlCommand.Parameters.AddWithValue("@TelefonoProveedor", proveedor.TelefonoProveedor);
                    sqlCommand.Parameters.AddWithValue("@CorreoProveedor", proveedor.CorreoProveedor);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", proveedor.Descripcion);
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
                    SqlCommand sqlCommand = new SqlCommand(@"delete Proveedor  where Codigo=@Codigo", sqlConnection);
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
