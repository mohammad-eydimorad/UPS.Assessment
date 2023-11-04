public static class StringExtensions
{
    public static string ToUpperFirstLetter(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            // Handle the case where the input is null or an empty string.
            return input;
        }

        char firstChar = char.ToUpper(input[0]);
        return firstChar + input.Substring(1);
    }
}