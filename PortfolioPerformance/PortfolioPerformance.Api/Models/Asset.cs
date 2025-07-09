using System.ComponentModel.DataAnnotations;

namespace PortfolioPerformance.Models
{
    public class Asset
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Symbol { get; set; } = string.Empty;
        public AssetType Type { get; set; }
        public decimal CurrentPrice { get; set; }
        public List<Transaction> Transactions { get; set; } = new();
    }
}