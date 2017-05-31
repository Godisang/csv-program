namespace CsvProgram.Services
{
    public abstract class BaseProcessor
    {
        private IFileService _fileService;

        public BaseProcessor(IFileService fileService)
        {
            _fileService = fileService;
        }

        private string Extract(string sourceFile)
        {
            return _fileService.ReadText(sourceFile);
        }

        protected abstract string Transform(string sourceData);
        

        public void Load(string sourceFile, string destinationFile)
        {
            var sourceData = Extract(sourceFile);
            var names = Transform(sourceData);

            _fileService.WriteText(destinationFile, names);

        }
    }
}
