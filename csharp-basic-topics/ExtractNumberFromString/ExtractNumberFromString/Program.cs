using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main(string[] args)
    {
        string input = "The price is $123.45";
        FindNumberRegExMethod(input);
        FindNumberLinqMethod(input);
    }
    public static string FindNumberRegExMethod(string input)
    {
        var output = string.Empty;
        // Define a regex pattern to match numbers
        string pattern = @"\d+\.?\d*";

        // Use Regex.Match to find the first match
        Match match = Regex.Match(input, pattern);

        // Check if a match is found
        if (match.Success)
        {
            // Retrieve the matched number
            string numberString = match.Value;
            double number = Convert.ToDouble(numberString);
            output = $"Found numbers: {number}";
            Console.WriteLine(output);
        }
        else
        {
            output = "No numbers found in the string.";
            Console.WriteLine(output);
        }
        return output;
    }
    public static string FindNumberLinqMethod(string input)
    {
        var output = string.Empty;
        // Split the string based on non-digit characters
        string[] parts = input.Split(new char[] { ' ', ',', '.', '$', '%', '-' }, StringSplitOptions.RemoveEmptyEntries);

        // Use LINQ to filter out non-numeric strings and convert to numbers
        var numbers = parts.Where(s => double.TryParse(s, out _)).Select(s => Convert.ToDouble(s)).ToList();

        // Check if any numbers are found
        if (numbers.Count > 0)
        {
            output = $"Found numbers: {string.Join(", ", numbers)}";
            Console.WriteLine(output);
            //Console.WriteLine("Found numbers: " + string.Join(", ", numbers));
        }
        else
        {
            output = "No numbers found in the string.";
            Console.WriteLine(output);
        }
        return output; 
    }
}