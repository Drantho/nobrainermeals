using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace bp2
{
    public class MyConnection
    {
        public static SqlConnection CurrentConnection
        {
            get{
                SqlConnection connection;

                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                return connection;
            }            
        }
    }
}