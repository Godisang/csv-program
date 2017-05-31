using System.Text;

namespace CsvProgram.UnitTests.TestBuilders
{
    public class PersonsCsvBuilder
    {
        private StringBuilder CsvBuilder;

        public PersonsCsvBuilder()
        {
            CsvBuilder = new StringBuilder();
        }

        public PersonsCsvBuilder Csv()
        {
            CsvBuilder.AppendLine("FirstName,LastName,Address,PhoneNumber");
            CsvBuilder.AppendLine("Ina,Vaughn,225 Mibic Circle,(701) 749-1743");
            CsvBuilder.AppendLine("Dean,McKinney,1524 Felbu Loop,(826) 540-2182");
            CsvBuilder.AppendLine("Maud,Vaughn,1569 Pilwah Square,(231) 712-5380");
            CsvBuilder.AppendLine("Catherine,Owen,1170 Mojak Lane,(943) 500-5164");
            CsvBuilder.AppendLine("Bessie,Dean,1000 Duliz View,(862) 889-2772");
            CsvBuilder.AppendLine("Nannie,Owen,1021 Cocve Turnpike,(287) 680-9342");
            CsvBuilder.AppendLine("Reyes,Knight,1464 Lala View,(206) 802-2178");
            CsvBuilder.AppendLine("William,Vaughn,908 Vozgo Circle,(847) 563-8493");
            CsvBuilder.AppendLine("Owen,Reyes,229 Tupmoj View,(633) 311-9706");
            CsvBuilder.AppendLine("Eddie,Owen,1970 Bofhen Way,(933) 902-8536");

            return this;
        }
       public string Build()
        {
            return CsvBuilder.ToString();
        }
    }
}
