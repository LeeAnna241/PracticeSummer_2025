namespace task01;

public static class StringExtensions
{
    public static bool IsPalindrome(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        List<char> output_1 = new List<char>();

        string low_input = input.ToLower();
        foreach (var c in low_input)
        {
            if (!Char.IsWhiteSpace(c) && !Char.IsPunctuation(c)) output_1.Add(c);
        }

        List<char> output_2 = new List<char>(output_1);
        output_2.Reverse();

        return output_1.SequenceEqual(output_2);
    }
}

