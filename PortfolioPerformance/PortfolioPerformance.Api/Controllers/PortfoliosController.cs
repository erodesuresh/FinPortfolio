using Microsoft.AspNetCore.Mvc;
using PortfolioPerformance.Models;
using PortfolioPerformance.Services;
using PortfolioPerformance.Dtos;

namespace PortfolioPerformance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortfoliosController : ControllerBase
    {
        private readonly PortfolioService _service;

        public PortfoliosController(PortfolioService service) => _service = service;

        [HttpGet]
        public ActionResult<IEnumerable<PortfolioDto>> GetAll() =>
            Ok(_service.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Portfolio> Get(Guid id)
        {
            var portfolio = _service.Get(id);
            if (portfolio == null) return NotFound();
            return Ok(portfolio);
        }

        [HttpPost]
        public ActionResult<Guid> Create([FromBody] CreatePortfolioDto dto)
        {
            var portfolio = new Portfolio { Name = dto.Name };
            _service.Add(portfolio);
            return CreatedAtAction(nameof(Get), new { id = portfolio.Id }, portfolio.Id);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            if (!_service.Delete(id)) return NotFound();
            return NoContent();
        }
    }
}