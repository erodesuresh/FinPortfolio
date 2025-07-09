using Microsoft.AspNetCore.Mvc;
using PortfolioPerformance.Models;
using PortfolioPerformance.Data;
using PortfolioPerformance.Dtos;

namespace PortfolioPerformance.Controllers
{
    [ApiController]
    [Route("api/portfolios/{portfolioId}/assets")]
    public class AssetsController : ControllerBase
    {
        private readonly PortfolioDbContext _context;

        public AssetsController(PortfolioDbContext context) => _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<AssetDto>> GetAll(Guid portfolioId)
        {
            var portfolio = _context.Portfolios.FirstOrDefault(p => p.Id == portfolioId);
            if (portfolio == null) return NotFound();

            var assets = portfolio.Assets.Select(a => new AssetDto
            {
                Id = a.Id,
                Symbol = a.Symbol,
                Type = a.Type,
                CurrentPrice = a.CurrentPrice
            });

            return Ok(assets);
        }

        [HttpPost]
        public ActionResult<Guid> Create(Guid portfolioId, [FromBody] CreateAssetDto dto)
        {
            var portfolio = _context.Portfolios.FirstOrDefault(p => p.Id == portfolioId);
            if (portfolio == null) return NotFound();

            var asset = new Asset
            {
                Symbol = dto.Symbol,
                Type = dto.Type,
                CurrentPrice = dto.CurrentPrice
            };

            portfolio.Assets.Add(asset);
            return CreatedAtAction(nameof(GetAll), new { portfolioId }, asset.Id);
        }
    }
}