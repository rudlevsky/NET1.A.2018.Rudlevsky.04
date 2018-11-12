using WordGeneration.Interfaces;

namespace WordGeneration.Tests.Models
{
    public class IntFilters : IPredicate<int>
    {
        public bool IsCorrect(int source) 
        => (source % 2 == 0) ? true : false;

        public bool MoreZero(int source)
        => (source > 0) ? true : false;
    }
}
