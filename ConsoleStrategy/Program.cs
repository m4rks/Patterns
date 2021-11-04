using System;

namespace ConsoleStrategy
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            FileReader fileReader = new FileReaderService();

            fileReader.OpenFileSomehow("blabla.txt");

            fileReader.OpenFileWithParameter("blabla.txt", "ddd");

            fileReader.SetupMyMethodToOpenFile(new OpenFileLegacy());




            Console.ReadKey();
        }
    }

    public class FileReaderService : FileReader
    {
        public FileReaderService()
        {
            //   OpenFileLegacy openFileLegacy = new OpenFileLegacy();
            //   OpenFileWithHelperLib openFileWithHelperLib = new OpenFileWithHelperLib();
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class FileReader
    {
        IFileReader FileReaderStrategy;

        protected FileReader()
        {

        }
        public string OpenFileSomehow(string input)
        {
            FileReaderStrategy.OpenFile(input);
            return "open in your way";
        }

        public string OpenFileWithParameter(string input, string parameter)
        {
            Console.WriteLine("do somthing with parameter");
            FileReaderStrategy.OpenFile(input);
            return "opened file with parameter, not from interface, just like that";
        }

        public void SetupMyMethodToOpenFile(IFileReader fileReader)
        {
            FileReaderStrategy = fileReader;
        }

        public abstract void Display();

        public void CreateFile()
        {
            Console.WriteLine("create file");
        }


    }

    public interface IFileReader
    {
        public string OpenFile(string input);
    }

    public class OpenFileWithHelperLib : IFileReader
    {
        public string OpenFile(string input)
        {
            return "use special rocket system to open file";
        }
    }

    public class OpenFileLegacy : IFileReader
    {
        public string OpenFile(string input)
        {
            return "use just typicall Stream";
        }
    }
}
