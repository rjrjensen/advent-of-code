namespace GiftShopTests;

using GiftShop;

public class ProductIdValidatorTests
{
    [Theory]
    [InlineData("11-22", 11L, 22L)]
    [InlineData("95-115", 99L)]
    [InlineData("998-1012", 1010L)]
    [InlineData("1188511880-1188511890", 1188511885L)]
    [InlineData("222220-222224", 222222L)]
    [InlineData("446443-446449", 446446L)]
    [InlineData("38593856-38593862", 38593859L)]
    [InlineData("1-100", 11L, 22L, 33L, 44L, 55L, 66L, 77L, 88L, 99L)]
    public void PullDoubleIdsFromIdRanges_GivenIdRange_ReturnsCorrectInvalidIds(string idRange, params long[] expectedInvalidIds)
    {
        var idValidator = new ProductIdValidator();

        var invalidIds = idValidator.PullDoubleIdsFromIdRanges([idRange]);
        
        Assert.Equal(expectedInvalidIds, invalidIds);
    }
    
    [Fact]
    public void PullDoubleIdsFromIdRanges_GivenIdRanges_ReturnsCorrectInvalidIdsTotal()
    {
        string[] idRanges =
        [
            "11-22", "95-115", "998-1012", "1188511880-1188511890", "222220-222224", "1698522-1698528", "446443-446449",
            "38593856-38593862", "565653-565659", "824824821-824824827", "2121212118-2121212124"
        ];

        var idValidator = new ProductIdValidator();
            
        var invalidIds = idValidator.PullDoubleIdsFromIdRanges(idRanges);

        var total = invalidIds.Sum();

        Assert.Equal(1227775554, total);
    }
    
    [Theory]
    [InlineData("11-22", 11L, 22L)]
    [InlineData("95-115", 99L, 111L)]
    [InlineData("998-1012", 999L, 1010L)]
    [InlineData("1188511880-1188511890", 1188511885L)]
    [InlineData("222220-222224", 222222L)]
    [InlineData("446443-446449", 446446L)]
    [InlineData("38593856-38593862", 38593859L)]
    [InlineData("565653-565659", 565656L)]
    [InlineData("824824821-824824827", 824824824L)]
    [InlineData("2121212118-2121212124", 2121212121L)]
    [InlineData("123412341230-123412341239", 123412341234L)]
    [InlineData("1-100", 11L, 22L, 33L, 44L, 55L, 66L, 77L, 88L, 99L)]
    public void PullAllRepeatingIdsFromIdRanges_GivenIdRange_ReturnsCorrectInvalidIds(string idRange, params long[] expectedInvalidIds)
    {
        var idValidator = new ProductIdValidator();

        var invalidIds = idValidator.PullAllRepeatingIdsFromIdRanges([idRange]);
        
        Assert.Equal(expectedInvalidIds, invalidIds);
    }
    
    [Fact]
    public void PullAllRepeatingIdsFromIdRanges_GivenIdRanges_ReturnsCorrectInvalidIdsTotal()
    {
        string[] idRanges =
        [
            "11-22", "95-115", "998-1012", "1188511880-1188511890", "222220-222224", "1698522-1698528", "446443-446449",
            "38593856-38593862", "565653-565659", "824824821-824824827", "2121212118-2121212124"
        ];

        var idValidator = new ProductIdValidator();
            
        var invalidIds = idValidator.PullAllRepeatingIdsFromIdRanges(idRanges);

        var total = invalidIds.Sum();

        Assert.Equal(4174379265, total);
    }
}