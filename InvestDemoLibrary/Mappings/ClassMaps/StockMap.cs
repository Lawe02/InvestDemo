using CsvHelper.Configuration;
using InvestDemoLibrary.Models;

namespace InvestDemoLibrary.ClassMaps;

public class StockMap : ClassMap<Stock>
{
    public StockMap()
    {
        Map(m => m.Symbol).Name("symbol");
        Map(m => m.Name).Name("name");
        Map(m => m.Exchange).Name("exchange");
    }
}
