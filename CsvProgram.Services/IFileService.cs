
namespace CsvProgram.Services
{
    public interface IFileService
    {
        string ReadText(string path);
        void WriteText(string path, string data);
    }
}
