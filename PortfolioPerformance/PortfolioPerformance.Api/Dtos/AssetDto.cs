using PortfolioPerformance.Models;
namespace PortfolioPerformance.Dtos
{
    public class AssetDto
    {
        public Guid Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public AssetType Type { get; set; }
        public decimal CurrentPrice { get; set; }
    }

    public class CreateAssetDto
    {
        public string Symbol { get; set; } = string.Empty;
        public AssetType Type { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}