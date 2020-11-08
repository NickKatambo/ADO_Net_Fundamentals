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
        #region Connect Method
        public void Connect(string cnnString)
        {
            // Create SQL Connection object
            SqlConnection cnn = new SqlConnection(cnnString);

            // Open the connection
            cnn.Open();

            // Gather connection information
            string resultText = GetConnectionInformation(cnn);

            // Close the connection
            cnn.Close();

            // Dispose of the connection
            cnn.Dispose();
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
