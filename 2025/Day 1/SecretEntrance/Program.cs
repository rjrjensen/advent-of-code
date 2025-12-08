using SecretEntrance;

var input = File.ReadAllLines("input.txt");

// var zeroCount = new DialTurner().CountEveryLandingZero(input);
var zeroCount = new DialTurner().CountEveryPassingZero(input);

Console.WriteLine("Zero Count: " + zeroCount);
