using Microsoft.Extensions.Logging;

namespace MauiApp1
{
    public class Goods
    {
        public decimal Price { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Name { get; set; }
        public DateTime PackagingDate { get; set; }
        public string Description { get; set; }
    }

    public class Product : Goods
    {
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
    }

    public class Book : Goods
    {
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }
        public List<string> ListOfAuthors { get; set; }
    }

    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }

}