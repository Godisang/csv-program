using CsvHelper;
using System.IO;
using System.Linq;
using CsvProgram.Services.Model;

namespace CsvProgram.Services
{
    public class NamesTransformer : INamesDataTransformer
    {
        
        public string Transform(string data)
        {
            var csvReader = new CsvReader(new StringReader(data));
            var persons = csvReader.GetRecords<Person>().ToList();

            var names = persons.GroupBy(x => x.FirstName).Select(x => new Names
            {
                Name = x.Key,
                Count = x.Count()
            });

            var surnames = persons.GroupBy(x => x.LastName).Select(x => new Names
            {
                Name = x.Key,
                Count = x.Count()
            });

            var grouped = names.Concat(surnames).GroupBy(x => x.Name).Select(x => new Names
            {
                Name = x.Key,
                Count = x.Sum(s => s.Count)
            }).OrderBy(x=>x.Name).OrderByDescending(x=>x.Count);

            var stringWriter = new StringWriter();

            var csvWriter = new CsvWriter(stringWriter);
            csvWriter.WriteHeader<Names>();
            csvWriter.WriteRecords(grouped);
            return stringWriter.ToString();
        }
    }
}
