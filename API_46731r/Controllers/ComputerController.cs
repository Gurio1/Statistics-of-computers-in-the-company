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
    public class ComputerController : GenericCRUDController<Computer, IComputerService>
    {
        private readonly IComputerService _computerService;
        private readonly ILogger<ComputerController> _logger;

        public ComputerController(IComputerService computerService, ILogger<ComputerController> logger) : base(computerService, logger)
        {
            _computerService = computerService;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ComputerDTO>>> GetAllComputers()
        {
            Stopwatch stopwatc = Stopwatch.StartNew();

            var entities = await _computerService.GetAllWithIncludesAsync();

            stopwatc.Stop();

            _logger.LogInformation($"{nameof(GetAllComputers)} was executed for {stopwatc.ElapsedMilliseconds} ms");

            await Task.Delay(5000);
            return Ok(entities);

        }
    }
}
