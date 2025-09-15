if (args.Length < 2)
{
    Console.WriteLine("Error: Please provide 2 arguments — file path and search word.");
    return;
}

string path = args[0];
string word = args[1];

try
{
    string text = File.ReadAllText(path);

    string[] words = text.Split([' ', '.', ',', '!', '?', '\n', '\r', '\t'],
                                StringSplitOptions.RemoveEmptyEntries);

    int count = words.Count(w => w.Equals(word, StringComparison.OrdinalIgnoreCase));

    Console.WriteLine(count);
}
catch (Exception ex)
{
    Console.WriteLine($"Error reading file: {ex.Message}");
}