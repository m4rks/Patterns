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

            fileReader.SetupMyMethodToOpenFile(new OpenFileWithLog());

            fileReader.OpenFileSomehow("withLog.txt");

            fileReader.CompareTwoFiles("asdf.txt", "zxcv.txt");

            fileReader.GetSizeOfFile("zxcv.txt");

            fileReader.SetupMyMethodToOpenFile(new OpenFilewWithDecode());

            fileReader.OpenFileSomehow("zxcv.zxcv.zxcv");

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

        public override void Info()
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

        public string CompareTwoFiles(string input, string input2file)
        {
            FileReaderStrategy.OpenFile(input);

            FileReaderStrategy.OpenFile(input2file);
            return "diff";
        }

        public string OpenFileWithParameter(string input, string parameter)
        {
            Console.WriteLine("do somthing with parameter");
            FileReaderStrategy.OpenFile(input);
            return "opened file with parameter, not from interface, just like that";
        }

        public string GetSizeOfFile(string input)
        {
            return "Get Size Of File";
        }

        public void SetupMyMethodToOpenFile(IFileReader fileReader)
        {
            FileReaderStrategy = fileReader;
        }

        public abstract void Display();

        public abstract void Info();

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

    public class OpenFileWithLog : IFileReader
    {
        public string OpenFile(string input)
        {
            return "Open File With Log";
        }
    }

    public class OpenFileSilent : IFileReader
    {
        public string OpenFile(string input)
        {
            return "Open File Silent";
        }
    }

    public class OpenFilewWithDecode : IFileReader
    {
        public string OpenFile(string input)
        {
            return "GetSizeOfFile";
        }
    }
}
