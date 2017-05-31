namespace CsvProgram.Services
{
    public interface ICsvProcessorFactory
    {
        BaseProcessor CreateNamesCsvProcessor();
        BaseProcessor CreateAddressCsvProcessor();
    }
}
