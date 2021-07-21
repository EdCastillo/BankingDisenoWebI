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
    [RoutePrefix("api/categoria")]
    public class CategoriaController : ApiController
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
                Categoria categoria = new Categoria();
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo,NombreCategoria,Descripcion from Categoria where Codigo=@Codigo", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", id);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        categoria = new Categoria { Codigo = reader.GetInt32(0), NombreCategoria = reader.GetString(1), Descripcion = reader.GetString(2) };
                    }
                    sqlConnection.Close();

                    if (categoria.Codigo == 0)
                    {
                        return NotFound();
                    }
                }
                return Ok(categoria);
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
                List<Categoria> list = new List<Categoria>();
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT Codigo,NombreCategoria,Descripcion from Categoria", sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new Categoria { Codigo = reader.GetInt32(0), NombreCategoria = reader.GetString(1), Descripcion = reader.GetString(2) });
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
        public IHttpActionResult insert(Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest();
            }
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(@"insert into Categoria (NombreCategoria,Descripcion) output inserted.Codigo values(@NombreCategoria,@Descripcion)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", categoria.Codigo);
                    sqlCommand.Parameters.AddWithValue("@NombreCategoria", categoria.NombreCategoria);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        categoria.Codigo = reader.GetInt32(0);
                    }
                    sqlConnection.Close();

                    return Ok(categoria);
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
                    SqlCommand sqlCommand = new SqlCommand(@"delete Categoria  where Codigo=@Codigo", sqlConnection);
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
        public IHttpActionResult Actualizar(Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest();
            }
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString))
                {
                    //Se salta la actualizacion de la fecha 
                    SqlCommand sqlCommand = new SqlCommand(@"update Categoria set NombreCategoria=@NombreCategoria,Descripcion=@Descripcion where Codigo=@Codigo", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Codigo", categoria.Codigo);
                    sqlCommand.Parameters.AddWithValue("@NombreCategoria", categoria.NombreCategoria);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);
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
