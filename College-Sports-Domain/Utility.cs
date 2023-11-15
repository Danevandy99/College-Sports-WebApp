public static class Utility
{
    public static string RemoveNewLines(string input)
    {
        return input.Replace("\n", "").Replace("\r", "");
    }
}