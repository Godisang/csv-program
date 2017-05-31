using System;
using CsvProgram.Services;
using System.IO;
using Microsoft.Extensions.DependencyInjection;

namespace CsvProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Application...");

            string AddressFileName = string.Format("address{0}.csv", DateTime.Now.ToString("yyyyMMddhhmmss"));
            string NamesFileName = string.Format("names{0}.csv", DateTime.Now.ToString("yyyyMMddhhmmss"));
            string BaseDirectory = Directory.GetCurrentDirectory();

            string SourceFile = Path.Combine(BaseDirectory, "Source","data.csv");
            string DestinationFolder = Path.Combine(BaseDirectory, "Destination");

            var serviceProvider = ConfigureServices(new ServiceCollection());

            var app = serviceProvider.GetService<App>();
            try
            {
                app.RunNamesCsvProcess(SourceFile, Path.Combine(DestinationFolder, NamesFileName));
                app.RunAddressCsvProcess(SourceFile, Path.Combine(DestinationFolder, AddressFileName));

                Console.WriteLine("Completed successfully.");
               
            }
            catch(Exception exception){
                Console.WriteLine("An unexpected error occured! - {0}",exception.Message);
            }

            Console.WriteLine("Enter any key to exit");
            Console.Read();
        }

        static IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IFileService, FileSystemService>();
            services.AddTransient<INamesDataTransformer, NamesTransformer>();
            services.AddTransient<IAddressDataTransformer, AddressesTransformer>();
            services.AddTransient<ICsvProcessorFactory, CsvProcessorFactory>();
            services.AddTransient<IDataTransformerFactory, DataTransformerFactory>();
            services.AddSingleton<App>();

            return services.BuildServiceProvider();
        }
    }
}