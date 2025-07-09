using PortfolioPerformance.Models;

namespace PortfolioPerformance.Data
{
    public class PortfolioDbContext
    {
        public List<Portfolio> Portfolios { get; set; } = new();
    }
}