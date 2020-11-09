using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAppOne
{
    public class ConnectionModel
    {
        string resultText;

        #region Connect Method
        public void Connect(string cnnString)
        {
            ConnectWithErrors(cnnString);
            Console.WriteLine(resultText);

            // Create SQL Connection object
            // SqlConnection cnn = new SqlConnection(cnnString);

            // Open the connection
            //cnn.Open();

            // Gather connection information
            //resultText = GetConnectionInformation(cnn);

            // Close the connection
            //cnn.Close();

            // Dispose of the connection
            // cnn.Dispose();
        }

        #region ConnectWithErrors Method
        public void ConnectWithErrors(string cnnString)
        {
            try
            {
                // Create SQL connection object
                using (SqlConnection cnn = new SqlConnection(cnnString))
                {
                    // Open the connection
                    cnn.Open();

                    resultText = GetConnectionInformation(cnn);
                }
            }
            catch (Exception ex)
            {
                resultText = ex.ToString();
            }
        }
        #endregion

        public void ConnectUsingBlock(string cnnString)
        {
            // Create SQL connection object in using block
            // for automatic closing and disposing
            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                // Open the connection
                cnn.Open();

                resultText = GetConnectionInformation(cnn);
            }
        }

        protected virtual string GetConnectionInformation(SqlConnection cnn)
        {
            StringBuilder sb = new StringBuilder(1024);

            sb.AppendLine($"Connection String: {cnn.ConnectionString}");
            sb.AppendLine($"State: {cnn.State.ToString()}");
            sb.AppendLine($"Connection Timeout: {cnn.ConnectionTimeout.ToString()}");
            sb.AppendLine($"Database: {cnn.Database}");
            sb.AppendLine($"Data Source: {cnn.DataSource}");
            sb.AppendLine($"Server Version: {cnn.ServerVersion}");
            sb.AppendLine($"Workstation ID: {cnn.WorkstationId}");

            return sb.ToString();
        }
        #endregion
    }
}
