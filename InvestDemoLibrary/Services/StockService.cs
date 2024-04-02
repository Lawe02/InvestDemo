using CsvHelper;
using System.Globalization;
using InvestDemoLibrary.Models;
using InvestDemoLibrary.ClassMaps;
using InvestDemoLibrary.Repositories;
using Microsoft.Identity.Client;
using HtmlAgilityPack;

public class StockService
{
    private readonly HttpClient _httpClient;
    private readonly StockRepository _stockRepository;

    public StockService(HttpClient httpClient, StockRepository stockRepository)
    {
        _httpClient = httpClient;
        _stockRepository = stockRepository; 
    }

    public async Task<List<Stock>> GetActiveStocksAsync()
    {
        var stocks = new List<Stock>();
        string requestUri = "https://www.alphavantage.co/query?function=LISTING_STATUS&apikey=M78CIK0T40MEZHNZ";

        using (var response = await _httpClient.GetAsync(requestUri))
        {
            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<StockMap>();
                stocks = csv.GetRecords<Stock>().ToList();
            }
        }
        return stocks;
    }
    public static int GetCurrentStockPrice(string id)
    {
        string url = $"https://finance.yahoo.com/quote/{id}/";

        HtmlWeb web = new HtmlWeb();
        var htmlDocument = web.Load(url);

        var priceNode = htmlDocument.DocumentNode.SelectSingleNode("//fin-streamer[contains(@class, 'Fw(b) Fz(36px) Mb(-4px) D(ib)')]");

        int price = int.Parse(priceNode.InnerText);

        return price;     
    }
        
    public async Task<List<Stock>> GetAllStocksAsync()
    {
        return _stockRepository.GetAll(s => true).ToList();
    } 

    public async Task DeleteAllStocksAsync()
    {
        await _stockRepository.DeleteRangeAsync(s => true);
    }

    public async Task AddMultipleStocksAsync(IEnumerable<Stock> stocks)
    {
        await _stockRepository.CreateRangeAsync(stocks);
    }
}
