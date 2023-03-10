using API_46731r.Contracts.Computer;
using API_46731r.Domain.Entities;
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
    public class ComputerController : GenericCRUDController<Computer, IComputerService>
    {
        private readonly IComputerService _computerService;
        private readonly IUserService _userService;
        private readonly ILogger<ComputerController> _logger;

        public ComputerController(IComputerService computerService,IUserService userService, ILogger<ComputerController> logger) : base(computerService, logger)
        {
            _computerService = computerService;
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComputerDTO>>> GetAll()
        {
            Stopwatch stopwatc = Stopwatch.StartNew();

            var entities = await _computerService.GetAllWithIncludesAsync();

            stopwatc.Stop();

            _logger.LogInformation($"{nameof(GetAll)} was executed for {stopwatc.ElapsedMilliseconds} ms");
            
            return Ok(entities);

        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateComputer([FromBody] Computer computer)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetByEmailAsync(userEmail);
            var resultOfUpdate = await _computerService.UpdateComputer(computer,user);

            if (resultOfUpdate is null)
            {
                return BadRequest();
            }

            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult<ComputerDTO>> CreateComputer([FromBody] Computer entity)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetByEmailAsync(userEmail);
            
            var result = await _computerService.CreateComputer(entity,user);

            if (result is null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetEntity), new { id = result.Id }, result);
        }
    }
}
