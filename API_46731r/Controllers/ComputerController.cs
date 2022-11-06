using API_46731r.Contracts.Computer;
using API_46731r.Domain.Entities;
using API_46731r.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_46731r.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly IComputerService _computerService;
        private readonly ILogger<ComputerController> _logger;

        public ComputerController(IComputerService computerService, ILogger<ComputerController> logger)
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

        [HttpPost]
        public async Task<ActionResult<Computer>> CreateComputer([FromBody]Computer computer)
        {
            var result = await _computerService.CreateAsync(computer);

            if (result is null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetComputer), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Computer>> GetComputer(int id)
        {
            var result = await _computerService.GetByIdAsync(id);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateComputer([FromBody]Computer computer)
        {
            var resultOfUpdate = await _computerService.Update(computer);

            if (resultOfUpdate is null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComputer(int id)
        {

            var resultOfDelete = await _computerService.RemoveById(id);

            if (!resultOfDelete)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
