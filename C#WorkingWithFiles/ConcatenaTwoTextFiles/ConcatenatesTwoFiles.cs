public class ConcatenatesTwoFiles
{
    public static void Main()
    {
        var fi = new FileInfo(@"C:\Users\UsernameT\words.txt");
        var f1 = new FileInfo(@"C:\Users\UsernameT\test.txt");

        using (var fs = fi.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))

        using (var sw = new StreamWriter(fs))
        {
            sw.WriteLine("My first text file");
        }

        using (var fs1 = f1.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))

        using (var ww = new StreamWriter(fs1))
        {
            ww.WriteLine("Content from the second file.");
        }

        string outputFilePath = @"C:\Users\UsernameT\ConcatenateData.txt";

        using (var outputWriter = new StreamWriter(outputFilePath))
        {
            outputWriter.Write(File.ReadAllText(fi.FullName));
            outputWriter.Write(File.ReadAllText(f1.FullName));
        }
    }
}