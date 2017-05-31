using System.Text;
using CsvProgram.Services.Model;
using System.Reflection;
using System.Linq;

namespace CsvProgram.UnitTests.TestBuilders
{
    public class NamesCsvBuilder
    {
        private NamesBuilder NamesBuilder;
        private StringBuilder CsvBuilder;

        public NamesCsvBuilder()
        {
            NamesBuilder = new NamesBuilder();
            
        }

        public NamesCsvBuilder Csv()
        {
            CsvBuilder = new StringBuilder();

            var properties = typeof(Names).GetProperties();
            var header = string.Join(",", properties.Select(x => x.Name));
            CsvBuilder.AppendLine(header);

            foreach (var row in NamesBuilder.FromPersons().Build())
            {
                CsvBuilder.AppendLine(string.Format("{0},{1}", row.Name, row.Count));
            }

            return this;
        }

        public string Build()
        {
            return this.CsvBuilder.ToString();
        }
    }
}
