using System.Data;
using System.Data.SqlClient;

namespace StaffTrackApp.DAL.DataAccess.Abstractions
{
    public interface IStoredProceduresHelper
    {
        Task<DataTable> ExecuteStoredProcedureAsync(string procedureName, SqlParameter[] parameters = null);
    }
}
