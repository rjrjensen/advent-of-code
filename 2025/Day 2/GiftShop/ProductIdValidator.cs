namespace GiftShop;

public class ProductIdValidator
{
    public long[] PullDoubleIdsFromIdRanges(string[] idRanges)
    {
        List<long> invalidIds = [];
        
        foreach(var range in idRanges)
        {
            var (beginning, end) = range.GetBoundsAsIntegers();

            for (var id = beginning; id <= end; id++)
            {
                var characters = id.ToString();
                if (characters.Length % 2 != 0) continue;

                var halfway = characters.Length / 2;
                var firstHalf = characters[..halfway];
                var secondHalf = characters[halfway..];

                if (string.Equals(firstHalf, secondHalf)) invalidIds.Add(id);
            }
        }
        
        return invalidIds.ToArray();
    }
}

public static class StringExtensions
{
    public static (long beginning, long end) GetBoundsAsIntegers(this string range)
    {
        var split = range.Split('-');
        return (long.Parse(split[0]), long.Parse(split[1]));
    }
}