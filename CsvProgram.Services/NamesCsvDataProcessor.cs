
namespace CsvProgram.Services
{
    public class NamesCsvDataProcessor:BaseProcessor
    {
        private IDataTransformer _transformer;
     

        public NamesCsvDataProcessor(IFileService fileService,IDataTransformer transformer):base(fileService)
        {
            _transformer = transformer;
          
        }

        protected override string Transform(string sourceData)
        {
            return _transformer.Transform(sourceData);
        }
        
       
    }
}
