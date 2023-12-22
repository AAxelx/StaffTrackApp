using StaffTrackApp.Common.Models;
using StaffTrackApp.DAL.DataAccess.Abstractions;
using System.Data;

namespace StaffTrackApp.DAL.DataAccess.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IStoredProceduresHelper _proceduresHelper;

        public DepartmentRepository(IStoredProceduresHelper proceduresHelper)
        {
            _proceduresHelper = proceduresHelper;
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetDepartments");

            var departments = new List<Department>();

            foreach (DataRow row in result.Rows)
            {
                var department = new Department
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString()
                };

                departments.Add(department);
            }

            return departments;
        }
    }
}
