using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Services
{
    public class Database
    {

        private readonly string connectionstring;
        public Database(string connectionstring)
        {
            this.connectionstring = connectionstring;

        }

        public DataTable GetTable(string query)
        {
            DataTable dtTemp = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(connectionstring);
            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtTemp);

            }
            return dtTemp;
        }
        public void ExecuteNonQuery(string query, params object[] parameter) 
        {
            SqlConnection sqlConnection = new SqlConnection(connectionstring);
            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                for(int x = 0; x < parameter.Length;x++)
                {
                    cmd.Parameters.AddWithValue($"@p{x + 1}", parameter[x]);
                }
                cmd.ExecuteNonQuery();

            }
        }

    }
}
