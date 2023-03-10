using API_46731r.Contracts.Computer;
using API_46731r.Domain.Entities;
using API_46731r.Services;
using API_46731r.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace API_46731r.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    [Authorize]
    public class RoomController : GenericCRUDController<Room, IRoomService>
    {
        private readonly IRoomService _roomService;
        private readonly IUserService _userService;
        private readonly ILogger<RoomController> _logger;

        public RoomController(IRoomService roomService,IUserService userService, ILogger<RoomController> logger) : base(roomService, logger)
        {
            _roomService = roomService;
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetAll()
        {
            Stopwatch stopwatc = Stopwatch.StartNew();

            var entities = await _roomService.GetAllWithIncludesAsync();

            stopwatc.Stop();

            _logger.LogInformation($"{nameof(GetAll)} was executed for {stopwatc.ElapsedMilliseconds} ms");

            return Ok(entities);

        }
        
        [HttpPost]
        public async Task<ActionResult<ComputerDTO>> AddComputer([FromBody] Computer entity)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetByEmailAsync(userEmail);

            var result = await _roomService.AddComputer(entity,user);

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
