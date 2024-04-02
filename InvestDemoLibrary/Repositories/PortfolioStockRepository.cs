using InvestDemoLibrary.Data;
using InvestDemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestDemoLibrary.Repositories
{
    public class PortfolioStockRepository : RepositoryBase<PortfolioStock, ApplicationDbContext>
    {
        public PortfolioStockRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
