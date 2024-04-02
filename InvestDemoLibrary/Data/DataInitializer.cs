using InvestDemoLibrary.Data;
using InvestDemoLibrary.Models;
using InvestDemoLibrary.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InvestDemoLibrary.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly StockService _stockService;
        public DataInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, StockService stockService)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _stockService = stockService;
        }
        public void SeedData()
        {
            _dbContext.Database.Migrate();
            SeedRoles();
            SeedUsers();
            RefreshStocks();
        }

        // Här finns möjlighet att uppdatera dina användares loginuppgifter
        private void SeedUsers()
        {
            AddUserIfNotExists("lawza02@gmail.com", "Lawe1234#", new string[] { "Trader" });
            AddUserIfNotExists("lawza03@gmail.com", "Lawe1234#", new string[] { "Trader" });
            AddUserIfNotExists("lawza04@gmail.com", "Lawe1234#", new string[] { "Trader" });
            AddUserIfNotExists("lawza02@admin.com", "Lawe1234#", new string[] { "Admin" });
            AddUserIfNotExists("lawza03@admin.com", "Lawe1234#", new string[] { "Admin" });
        }

        // Här finns möjlighet att uppdatera dina användares roller
        private void SeedRoles()
        {
            AddRoleIfNotExisting("Admin");
            AddRoleIfNotExisting("Trader");
        }

        private void AddRoleIfNotExisting(string roleName)
        {
            var role = _dbContext.Roles.FirstOrDefault(r => r.Name == roleName);
            if (role == null)
            {
                _dbContext.Roles.Add(new IdentityRole { Name = roleName, NormalizedName = roleName });
                _dbContext.SaveChanges();
            }
        }

        private void AddUserIfNotExists(string userName, string password, string[] roles)
        {
            if (_userManager.FindByEmailAsync(userName).Result != null) return;

            var user = new IdentityUser
            {
                UserName = userName,
                Email = userName,
                EmailConfirmed = true
            };
            _userManager.CreateAsync(user, password).Wait();
            _userManager.AddToRolesAsync(user, roles).Wait();
        }

        private void RefreshStocks()
        {
            _stockService.DeleteAllStocksAsync().Wait();
            List<Stock> activeStocks = _stockService.GetActiveStocksAsync().Result;
            _stockService.AddMultipleStocksAsync(activeStocks).Wait();
        }
    }
}
