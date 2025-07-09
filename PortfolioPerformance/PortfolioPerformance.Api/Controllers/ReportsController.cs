using Microsoft.AspNetCore.Mvc;
using PortfolioPerformance.Data;
using PortfolioPerformance.Dtos;
using PortfolioPerformance.Models;

namespace PortfolioPerformance.Controllers
{
    [ApiController]
    [Route("api/portfolios/{portfolioId}/report")]
    public class ReportsController : ControllerBase
    {
        private readonly PortfolioDbContext _context;

        public ReportsController(PortfolioDbContext context) => _context = context;

        [HttpGet]
        public ActionResult<PortfolioValueReportDto> Get(Guid portfolioId)
        {
            var portfolio = _context.Portfolios.FirstOrDefault(p => p.Id == portfolioId);
            if (portfolio == null) return NotFound();

            decimal totalValue = 0;
            decimal realizedGains = 0;
            decimal unrealizedGains = 0;

            foreach (var asset in portfolio.Assets)
            {
                var buys = asset.Transactions.Where(t => t.Type == TransactionType.Buy).ToList();
                var sells = asset.Transactions.Where(t => t.Type == TransactionType.Sell).ToList();

                decimal buyQty = buys.Sum(b => b.Quantity);
                decimal sellQty = sells.Sum(s => s.Quantity);
                decimal heldQty = buyQty - sellQty;

                totalValue += heldQty * asset.CurrentPrice;

                // Realized Gains
                foreach (var sell in sells)
                {
                    if (!buys.Any()) continue;
                    var avgBuyPrice = buys.Average(b => b.PricePerUnit);
                    realizedGains += sell.Quantity * (sell.PricePerUnit - avgBuyPrice);
                }

                // Unrealized Gains
                if (buys.Any())
                {
                    var avgBuyPrice = buys.Average(b => b.PricePerUnit);
                    unrealizedGains += heldQty * (asset.CurrentPrice - avgBuyPrice);
                }
            }

            var report = new PortfolioValueReportDto
            {
                TotalValue = totalValue,
                RealizedGains = realizedGains,
                UnrealizedGains = unrealizedGains
            };

            return Ok(report);
        }
    }
}