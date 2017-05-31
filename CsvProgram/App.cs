using CsvProgram.Services;
using System;

namespace CsvProgram
{
    public class App
    {
        private ICsvProcessorFactory _factory;

        public App(ICsvProcessorFactory factory)
        {
            _factory = factory;
        }

        public void RunAddressCsvProcess(string source,string destination)
        {
            Console.WriteLine("Processing address csv...");
            var csvProcessor = _factory.CreateAddressCsvProcessor();
            csvProcessor.Load(source,destination);
            Console.WriteLine("Addresses csv processing completed successfully.");
        }

        public void RunNamesCsvProcess(string source,string destination)
        {
            Console.WriteLine("Processing names csv...");
            var csvProcessor = _factory.CreateNamesCsvProcessor();
            csvProcessor.Load(source, destination);
            Console.WriteLine("Names csv processing completed successfully.");
        }
    }
}
