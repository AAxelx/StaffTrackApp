using StaffTrackApp.DAL.DataAccess.Abstractions;
using System.Data;
using System.Data.SqlClient;

namespace StaffTrackApp.DAL.DataAccess
{
    public class StoredProceduresHelper : IStoredProceduresHelper
    {
        private readonly string connectionString;

        public StoredProceduresHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<DataTable> ExecuteStoredProcedureAsync(string procedureName, SqlParameter[] parameters = null)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    dataTable.Load(reader);
                }
            }

            return dataTable;
        }

        public DataTable GetDataTableFromList<T>(List<T> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Value");

            if (list != null)
            {
                foreach (var value in list)
                {
                    dt.Rows.Add(value);
                }
            }

            return dt;
        }

    }
}
