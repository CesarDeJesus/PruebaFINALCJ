using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace CJMusic.Models
{
    
    public class DBCommon
    {
        private static string Conn = @"Data Source=CESAR;Initial Catalog=Disquera;Integrated Security=True";

        public static IDbConnection Conexion()
        {
            return new SqlConnection(Conn);

        }


    }
}