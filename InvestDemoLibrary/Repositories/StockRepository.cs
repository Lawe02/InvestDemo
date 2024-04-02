using InvestDemoLibrary.Data;
using InvestDemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestDemoLibrary.Repositories
{
    public class StockRepository : RepositoryBase<Stock, ApplicationDbContext>
    {
        public StockRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
