using static SecretEntrance.DialTurner;

var input = File.ReadAllLines("input.txt");

// var zeroCount = CountEveryLandingZero(input);
var zeroCount = CountEveryPassingZero(input);

Console.WriteLine("Zero Count: " + zeroCount);
