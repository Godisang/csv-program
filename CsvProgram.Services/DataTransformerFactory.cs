
namespace CsvProgram.Services
{
    public class DataTransformerFactory : IDataTransformerFactory
    {
        
        public IDataTransformer CreateAddressesCsvTransformer()
        {
            return new AddressesTransformer();
        }

        public IDataTransformer CreateNamesCsvTransformer()
        {
            return new NamesTransformer();
        }
    }
}
