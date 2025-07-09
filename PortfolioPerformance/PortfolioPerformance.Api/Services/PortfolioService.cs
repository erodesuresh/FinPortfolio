using PortfolioPerformance.Models;
using PortfolioPerformance.Data;

using PortfolioPerformance.Dtos;
namespace PortfolioPerformance.Services
{
    public class PortfolioService
    {
        private readonly PortfolioDbContext _context;

        public PortfolioService(PortfolioDbContext context) => _context = context;

        public IEnumerable<PortfolioDto> GetAll() =>
            _context.Portfolios.Select(p => new PortfolioDto { Id = p.Id, Name = p.Name });

        public Portfolio? Get(Guid id) =>
            _context.Portfolios.FirstOrDefault(p => p.Id == id);

        public void Add(Portfolio portfolio)
        {
            _context.Portfolios.Add(portfolio);
        }

        public bool Delete(Guid id)
        {
            var portfolio = _context.Portfolios.FirstOrDefault(p => p.Id == id);
            if (portfolio == null) return false;
            _context.Portfolios.Remove(portfolio);
            return true;
        }
    }
}