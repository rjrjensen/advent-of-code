using GiftShop;

var input = File.ReadAllText("input.txt");

var idRanges = input.Split(',');

var invalidIds = new ProductIdValidator().PullDoubleIdsFromIdRanges(idRanges);

Console.WriteLine("Invalid ID Sum: " + invalidIds.Sum());