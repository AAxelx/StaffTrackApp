using StaffTrackApp.Common.Models.Responses;
using StaffTrackApp.Common.Models;
using StaffTrackApp.DAL.DataAccess.Abstractions;
using StaffTrackApp.SAL.Services.Abstractions;

namespace StaffTrackApp.SAL.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository repository)
        {
            _positionRepository = repository;
        }

        public async Task<ServiceValueResult<List<Position>>> GetPositionsAsync()
        {
            var positions = await _positionRepository.GetPositionsAsync();

            return new ServiceValueResult<List<Position>>(positions);
        }
    }
}
