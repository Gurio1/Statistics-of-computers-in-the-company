using API_46731r.Contracts.Computer;
using API_46731r.Domain.Entities;
using API_46731r.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace API_46731r.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    [Authorize]
    public class BuildingController : GenericCRUDController<Building,IBuildingService>
    {
        private readonly IBuildingService _buildingService;
        private readonly ILogger<BuildingController> _logger;

        public BuildingController(IBuildingService buildingService, ILogger<BuildingController> logger) : base(buildingService, logger)
        {
            _buildingService = buildingService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComputerDTO>>> GetAll()
        {
            Stopwatch stopwatc = Stopwatch.StartNew();

            var entities = await _buildingService.GetAllWithIncludesAsync();
            
            stopwatc.Stop();

            _logger.LogInformation($"{nameof(GetAll)} was executed for {stopwatc.ElapsedMilliseconds} ms");

            return Ok(entities);

        }
        
        [HttpPost]
        public async Task<ActionResult<Room>> AddRoom([FromBody] Room entity)
        {

            var result = await _buildingService.AddRoom(entity);

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

    }
}
