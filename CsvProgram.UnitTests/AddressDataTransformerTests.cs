using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CsvProgram.Services;
using CsvProgram.UnitTests.TestBuilders;

namespace CsvProgram.UnitTests
{
    [TestClass()]
    public class AddressDataTransformerTests
    {
        private Mock<IDataTransformer> SUT;
        private PersonsCsvBuilder PersonsCsvBuilder;
        private AddressCsvBuilder AddressCsvBuilder;

        [TestInitialize()]
        public void Initialize()
        {
            SUT = new Mock<IDataTransformer>();
            PersonsCsvBuilder = new PersonsCsvBuilder();
            AddressCsvBuilder = new AddressCsvBuilder();
        }

        [TestMethod]
        public void Transform_should_return_list_of_addresses_ordered_by_street_name_to_csv()
        {
            var expected = AddressCsvBuilder.Csv().Build();

            SUT.Setup(x => x.Transform(It.IsAny<string>())).Returns(expected);

            var actual = SUT.Object.Transform(PersonsCsvBuilder.Csv().Build());

            Assert.AreEqual(expected, actual);
        }

    }
}
