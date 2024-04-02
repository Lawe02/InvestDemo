using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestDemoLibrary.Models
{
    public class PortfolioStock
    {
        public int Id { get; set; }
        public int PortfolioID { get; set; }
        public Portfolio Portfolio { get; set; }

        public int PortfolioStockId { get; set; }
        public Stock Stock { get; set; }

        // Quantity of the stock in this portfolio
        public int Quantity { get; set; }

        // Purchase price might be different for each stock entry in the portfolio
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseTime { get; set; }  
    }
}
