using System.Text.RegularExpressions;

namespace my_books.Utilites
{
    public static class Utilites
    {
        public static bool IsNameValid(string name) => Regex.IsMatch(name, @"^\d");
    }
}
