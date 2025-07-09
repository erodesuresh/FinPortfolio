using PortfolioPerformance.Dtos;
using PortfolioPerformance.Models;
namespace PortfolioPerformance.Dtos
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public decimal Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
    }

    public class CreateTransactionDto
    {
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public decimal Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
    }
}