using System.ComponentModel.DataAnnotations;

namespace aff.Data.Models
{
    public class UserPortfolio
    {
        public string? PortfolioId { get; set; }
        public string? Symbol { get; set; }
        public string? Name { get; set; }
        public float? Quantity { get; set; }
        public float? CurrentPrice { get; set; }
    }
}