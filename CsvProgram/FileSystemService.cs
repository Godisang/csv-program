using System.IO;
using CsvProgram.Services;

namespace CsvProgram
{
    public class FileSystemService:IFileService
    {

         public string ReadText(string path)
        {
            return File.ReadAllText(path);
        }

        public void WriteText(string path,string contents)
        {
            File.WriteAllText(path, contents);
        }
    }    
}
