namespace PortfolioPerformance.Dtos
{
    public class PortfolioDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class CreatePortfolioDto
    {
        public string Name { get; set; } = string.Empty;
    }
}