
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CsvProgram.Services;
using CsvProgram.UnitTests.TestBuilders;

namespace CsvProgram.UnitTests
{
    [TestClass()]
    public class NamesCsvDataProcssorTests
    {
        private Mock<IDataTransformer> NamesDataTransformer;
        private Mock<IFileService> FileService;
        private PersonsCsvBuilder PersonsCsvBuilder;

        [TestInitialize()]
        public void Initialize()
        {
            NamesDataTransformer = new Mock<IDataTransformer>();
            FileService = new Mock<IFileService>();
            PersonsCsvBuilder = new PersonsCsvBuilder();
        }


        [TestMethod()]
        public void Export_should_verify_transform_is_called_once()
        {
            FileService.Setup(x => x.ReadText(It.IsAny<string>())).Returns(PersonsCsvBuilder.Csv().Build());
            var sut = new NamesCsvDataProcessor(FileService.Object,NamesDataTransformer.Object);

            sut.Load(FakePath.SourceFile,FakePath.DestinationFile);

            NamesDataTransformer.Verify(x => x.Transform(It.IsAny<string>()));

        }

       
       
    }
}
