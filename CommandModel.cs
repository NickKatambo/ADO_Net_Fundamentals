using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAppOne
{
    public class CommandModel
    {
        int RowsAffected;
        string ResultText;

        public int GetProductsCountScalar()
        {
            RowsAffected = 0;
            // Create SQL statement to submit
            string sql = "SELECT COUNT(*) FROM Product";

            // Create a Connection
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                // Create command object
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    // Open the connection
                    cnn.Open();

                    // Execute command
                    RowsAffected = (int)cmd.ExecuteScalar();
                }
            }
            ResultText = $"Rows Affected: {RowsAffected.ToString() }";
            Console.WriteLine(ResultText);
            return RowsAffected;
        }
    }
}
