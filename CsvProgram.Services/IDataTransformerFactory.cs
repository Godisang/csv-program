
namespace CsvProgram.Services
{
    public interface IDataTransformerFactory
    {
        IDataTransformer CreateNamesCsvTransformer();
        IDataTransformer CreateAddressesCsvTransformer();
    }
}
