namespace PortfolioPerformance.Dtos
{
    public class PortfolioValueReportDto
    {
        public decimal TotalValue { get; set; }
        public decimal RealizedGains { get; set; }
        public decimal UnrealizedGains { get; set; }
    }
}