using WordGeneration.Interfaces;

namespace WordGeneration.Tests.Models
{
    public class StringFilters : IPredicate<string>
    {
        public bool IsCorrect(string source)
        => (source[0] == 'A') ? true : false;
     
        public bool MoreTwo(string source)
        => (source.Length > 2) ? true : false;
    }
}
