class Program
{
    static void Main(string[] args)
    {

        var fi = new FileInfo(@"C:\Users\UsernameT\words.txt");
        var f1 = new FileInfo(@"C:\Users\UsernameT\test.txt");


        using (var fs = fi.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
        using (var sw = new StreamWriter(fs))
        {
            sw.WriteLine("My first text file");
            sw.WriteLine("My first text file");
            sw.WriteLine("My first text file");
            sw.WriteLine("1");
            sw.WriteLine("1");
            sw.WriteLine("5");

        }

        using (var fs1 = f1.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
        using (var ww = new StreamWriter(fs1))
        {
            ww.WriteLine("My first text file");
            ww.WriteLine("My first text file");
            ww.WriteLine("1");
            ww.WriteLine("1");
        }

            // Read words from words.txt
            string[] words = File.ReadAllLines(@"C:\Users\UsernameT\words.txt");

            // Read text from test.txt
            string text = File.ReadAllText(@"C:\Users\UsernameT\test.txt");

            // Count occurrences of each word
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                int count = CountOccurrences(text, word);
                wordCounts[word] = count;
            }

            // Sort by occurrences in descending order
            var sortedWordCounts = wordCounts.OrderByDescending(pair => pair.Value);

            // Write result to result.txt
            using (StreamWriter writer = new StreamWriter(@"C:\Users\UsernameT\result.txt"))
            {
                foreach (var pair in sortedWordCounts)
                {
                    writer.WriteLine($"{pair.Key}: {pair.Value}");
                }
            }

            Console.WriteLine("Result written to result.txt");  
    }

    static int CountOccurrences(string text, string word)
    {
        int count = 0;
        int index = text.IndexOf(word, StringComparison.OrdinalIgnoreCase);

        while (index != -1)
        {
            count++;
            index = text.IndexOf(word, index + 1, StringComparison.OrdinalIgnoreCase);
        }

        return count;
    }
}