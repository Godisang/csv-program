using System.Collections.Generic;
using System.Linq;

using CsvProgram.Services.Model;

namespace CsvProgram.UnitTests.TestBuilders
{
    public class PersonsBuilder
    {
        private List<Person> Persons;
        private PersonsCsvBuilder PersonsCsvBuilder;

        public PersonsBuilder()
        {
            Persons = new List<Person>();
            PersonsCsvBuilder = new PersonsCsvBuilder();
        }


        public PersonsBuilder FromCsv()
        {
            var personArray = PersonsCsvBuilder.Build().Split('\n');
           
            foreach (var person in personArray.Skip(1))
            {
                if (person != string.Empty)
                {
                    var row = person.Split(',');
                    Persons.Add(new Person
                    {
                        FirstName = row[0].ToString(),
                        LastName = row[1].ToString(),
                        Address = row[2].ToString(),
                        PhoneNumber = row[3].ToString()
                    });
                }
            }

            return this;
        }

        public List<Person> Build()
        {
            return this.Persons;
        }
    }
}
