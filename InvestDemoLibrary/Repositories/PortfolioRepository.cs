using InvestDemoLibrary.Data;
using InvestDemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestDemoLibrary.Repositories
{
    public class PortfolioRepository : RepositoryBase<Portfolio, ApplicationDbContext>
    {
        public PortfolioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
