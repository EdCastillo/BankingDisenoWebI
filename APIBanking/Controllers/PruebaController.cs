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
    [RoutePrefix("api/prueba")]
    public class PruebaController : ApiController
    {

        public IHttpActionResult insertAndReturnIdentity(string nombre, string apellido) {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Banking"].ConnectionString)) {
                int flag = 0;
                //into table 'output inserted.primaryKey' values... 
                //Return identity
                SqlCommand sqlCommand = new SqlCommand(@"insert into PRUEBA output inserted.ID values(@NOMBRE,@APELLIDO);", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@NOMBRE", nombre);
                sqlCommand.Parameters.AddWithValue("@APELLIDO", apellido);
                sqlConnection.Open();
                SqlDataReader reader=sqlCommand.ExecuteReader();
                while (reader.Read()) {
                    flag = reader.GetInt32(0);
                }
                sqlConnection.Close();
                if (flag != 0) {
                    return Ok(flag);
                }
                return InternalServerError();
            }
        }
    }
}
