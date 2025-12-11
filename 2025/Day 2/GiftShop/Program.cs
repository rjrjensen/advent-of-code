using GiftShop;

var input = File.ReadAllText("input.txt");

var idRanges = input.Split(',');

// var invalidIds = new ProductIdValidator().PullDoubleIdsFromIdRanges(idRanges);
var invalidIds = new ProductIdValidator().PullAllRepeatingIdsFromIdRanges(idRanges);

Console.WriteLine("Invalid ID Sum: " + invalidIds.Sum());