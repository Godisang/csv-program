using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvProgram.Services.Model;
using System.Reflection;

namespace CsvProgram.UnitTests.TestBuilders
{
    public class AddressesBuilder
    {
        private List<Street> Addresses;
        private PersonsBuilder PersonsBuilder;

        public AddressesBuilder()
        {
            Addresses = new List<Street>();
            PersonsBuilder = new PersonsBuilder();

        }

        public AddressesBuilder UnSorted()
        {
            Addresses = PersonsBuilder.FromCsv().Build().Select(x => new Street
            {
                Address = x.Address
            }).ToList();

            return this;
        }

        public AddressesBuilder Sorted()
        {
            Addresses = PersonsBuilder.FromCsv().Build().Select(x => new Street
            {
                Address = x.Address
            }).ToList();

            return this;
        }

        public AddressesBuilder ToCsv()
        {
            var csvBuilder = new StringBuilder();

            var properties = typeof(Street).GetProperties();
            var header = string.Join(",", properties.Select(x => x.Name));
            csvBuilder.AppendLine(header);

            foreach (var row in Addresses)
            {
                csvBuilder.AppendLine(string.Format("{0}", row.Address));
            }

            return this;
        }

        public List<Street> Build()
        {
            return Addresses;
            //return addresses.OrderBy(x=>x.Street);
        }
    }
}
