namespace CsvProgram.Services
{
    public class AddressCsvDataProcessor:BaseProcessor
    {
        private IDataTransformer _transformer;
       
        public AddressCsvDataProcessor(IFileService fileService, IDataTransformer transformer):base(fileService)
        {
            _transformer = transformer;
        }

        protected override string Transform(string sourceData)
        {
            return _transformer.Transform(sourceData);
        }

    }
}
