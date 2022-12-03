using API_46731r.Contracts.Computer;
using API_46731r.Domain.Entities;
using API_46731r.Services;
using API_46731r.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace API_46731r.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    [Authorize]
    public class RoomController : GenericCRUDController<Room, IRoomService>
    {
        private readonly IRoomService _roomService;
        private readonly ILogger<RoomController> _logger;

        public RoomController(IRoomService roomService, ILogger<RoomController> logger) : base(roomService, logger)
        {
            _roomService = roomService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetAllComputers()
        {
            Stopwatch stopwatc = Stopwatch.StartNew();

            var entities = await _roomService.GetAllWithIncludesAsync();

            stopwatc.Stop();

            _logger.LogInformation($"{nameof(GetAllComputers)} was executed for {stopwatc.ElapsedMilliseconds} ms");

            return Ok(entities);

        }
    }
}
