namespace CsvProgram.Services
{
    public class CsvProcessorFactory : ICsvProcessorFactory
    {
        private IFileService _fileService;
        private IDataTransformerFactory _csvTransformerFactory;

        public CsvProcessorFactory(IFileService fileService,IDataTransformerFactory csvTransformerFactory)
        {
            _fileService = fileService;
            _csvTransformerFactory = csvTransformerFactory;
        }

        public BaseProcessor CreateAddressCsvProcessor()
        {
            var csvTransformer = _csvTransformerFactory.CreateAddressesCsvTransformer();
            return new AddressCsvDataProcessor(_fileService, csvTransformer);
        }

        public BaseProcessor CreateNamesCsvProcessor()
        {
            var csvTransformer = _csvTransformerFactory.CreateNamesCsvTransformer();
            return new NamesCsvDataProcessor(_fileService, csvTransformer);
        }
    }
}
