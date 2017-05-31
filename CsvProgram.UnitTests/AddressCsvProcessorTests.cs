using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsvProgram.Services;
using Moq;
using CsvProgram.UnitTests.TestBuilders;


namespace CsvProgram.UnitTests
{
    [TestClass()]
    public class AddressCsvProcessorTests
    {
        private Mock<IDataTransformer> AddressDataTransformer;
        private Mock<IFileService> FileService;
        private PersonsBuilder PersonsBuilder;
        private PersonsCsvBuilder PersonsCsvBuilder;

        [TestInitialize()]
        public void Initialize()
        {
            AddressDataTransformer = new Mock<IDataTransformer>();
            FileService = new Mock<IFileService>();
            PersonsBuilder = new PersonsBuilder();
            PersonsCsvBuilder = new PersonsCsvBuilder();
        }


        [TestMethod()]
        public void Load_should_verify_transform_is_called_once()
        {
            FileService.Setup(x => x.ReadText(It.IsAny<string>())).Returns(PersonsCsvBuilder.Csv().Build());
            var sut = new AddressCsvDataProcessor(FileService.Object, AddressDataTransformer.Object);

            sut.Load(FakePath.SourceFile, FakePath.DestinationFile);

            AddressDataTransformer.Verify(x => x.Transform(It.IsAny<string>()));

        }
    }
}
