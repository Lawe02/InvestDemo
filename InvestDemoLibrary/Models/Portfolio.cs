using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestDemoLibrary.Models
{
    public class Portfolio
    {
        public int ID { get; set; }         
        public int Quantity { get; set; }
        public DateTime Created { get; set; }
        public int Value { get; set; }
 
        public IdentityUser User { get; set; }           
        public ICollection<PortfolioStock> PortfolioStocks { get; set; }
    }
}
