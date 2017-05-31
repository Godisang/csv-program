using System.Collections.Generic;
using System.Linq;
using CsvProgram.Services.Model;

namespace CsvProgram.UnitTests.TestBuilders
{
    public class NamesBuilder
    {
        private static IEnumerable<Names> _names;
        private PersonsBuilder PersonsBuilder;
        private List<Person> Persons;

        public NamesBuilder()
        {
            _names = new List<Names>();
            PersonsBuilder = new PersonsBuilder();
            Persons = new List<Person>();
        }

        public NamesBuilder FromPersons()
        {
            Persons = PersonsBuilder.FromCsv().Build();
            return this;
        }

        public IEnumerable<Names> Build()
        {
            var names = Persons.GroupBy(x =>  x.FirstName).Select(x => new Names
            {
                Name = x.Key,
                 Count = x.Count()
               
            });

            var surnames = Persons.GroupBy(x => x.LastName).Select(x => new Names
            {
                Name = x.Key,
                Count = x.Count()
            });

            var totals = names.Concat(surnames).GroupBy(x => x.Name).Select(x => new Names
            {
                Name = x.Key,
                Count = x.Sum(s => s.Count)
            });
            
            return totals.OrderBy(x => x.Name).OrderByDescending(x => x.Count);
        }
    }
}
