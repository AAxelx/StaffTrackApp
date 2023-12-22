using StaffTrackApp.Common.Models;
using StaffTrackApp.DAL.DataAccess.Abstractions;
using System.Data;

namespace StaffTrackApp.DAL.DataAccess.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly IStoredProceduresHelper _proceduresHelper;

        public PositionRepository(IStoredProceduresHelper proceduresHelper)
        {
            _proceduresHelper = proceduresHelper;
        }

        public async Task<List<Position>> GetPositionsAsync()
        {
            var result = await _proceduresHelper.ExecuteStoredProcedureAsync("GetPositions");

            var positions = new List<Position>();

            foreach (DataRow row in result.Rows)
            {
                var position = new Position
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString()
                };

                positions.Add(position);
            }

            return positions;
        }
    }
}
