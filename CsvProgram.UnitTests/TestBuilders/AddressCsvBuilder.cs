using System.Text;
using CsvProgram.Services.Model;
using System.Reflection;
using System.Linq;

namespace CsvProgram.UnitTests.TestBuilders
{
    public class AddressCsvBuilder
    {
        private AddressesBuilder AddressesBuilder;
        private StringBuilder CsvBuilder;

        public AddressCsvBuilder()
        {
            AddressesBuilder = new AddressesBuilder();
           
        }

        public AddressCsvBuilder Csv()
        {
            CsvBuilder = new StringBuilder();

            var properties = typeof(Street).GetProperties();
            var header = string.Join(",", properties.Select(x => x.Name));
            CsvBuilder.AppendLine(header);

            foreach (var row in AddressesBuilder.UnSorted().Build())
            {
                CsvBuilder.AppendLine(string.Format("{0}", row.Address));
            }

            return this;
        }

        public string Build()
        {
            
            return CsvBuilder.ToString();
        }
    }
}
