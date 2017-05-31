using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CsvProgram.Services;
using CsvProgram.UnitTests.TestBuilders;

namespace CsvProgram.UnitTests
{
    [TestClass]
    public class NamesDataTransformerTests
    {
        private Mock<IDataTransformer> Sut;
        private PersonsCsvBuilder PersonsCsvBuilder;
        private NamesCsvBuilder NamesCsvBuilder;

        [TestInitialize()]
        public void Initialize()
        {  
            Sut = new Mock<IDataTransformer>();
            PersonsCsvBuilder = new PersonsCsvBuilder();
            NamesCsvBuilder = new NamesCsvBuilder();
        }

        [TestMethod]
        public void Transform_should_return_list_of_names_count_ordered_to_csv()
        {
            var expected = NamesCsvBuilder.Csv().Build();
            Sut.Setup(x => x.Transform(It.IsAny<string>())).Returns(expected);

            var actual = Sut.Object.Transform(PersonsCsvBuilder.Csv().Build());

            Assert.AreEqual(expected, actual);
        }
    }
}
