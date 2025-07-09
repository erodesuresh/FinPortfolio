using System.ComponentModel.DataAnnotations;

namespace PortfolioPerformance.Models
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public decimal Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
    }
}