using System.ComponentModel.DataAnnotations;

namespace PortfolioPerformance.Models
{
    public class Portfolio
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public List<Asset> Assets { get; set; } = new();
    }
}