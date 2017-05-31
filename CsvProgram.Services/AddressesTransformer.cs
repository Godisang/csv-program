using CsvHelper;
using System.IO;
using System.Text.RegularExpressions;
using CsvProgram.Services.Model;
using System.Linq;

namespace CsvProgram.Services
{
    public class AddressesTransformer : IAddressDataTransformer
    {
        public string Transform(string data)
        {
            var csvReader = new CsvReader(new StringReader(data));
            var addresses = csvReader.GetRecords<Street>();

            var sorted = addresses.OrderBy(x => Regex.Replace(x.Address,"[0-9]",string.Empty));
            
            var stringWriter = new StringWriter();
            var csvWriter = new CsvWriter(stringWriter);
            csvWriter.WriteHeader<Street>();
            csvWriter.WriteRecords(sorted);

            return stringWriter.ToString();
        }
    }
}
