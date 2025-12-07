var input = File.ReadAllLines("input.txt");

int zeroCount = 0, currentNumber = 50;

foreach (var instruction in input)
{
    var clicks = int.Parse(instruction[1..]);
    var direction = instruction[0] == 'R' ? 1 : -1;
    var rotation = clicks * direction;

    currentNumber += rotation;
    currentNumber %= 100;

    if (currentNumber == 0) zeroCount++;
}

Console.WriteLine("Zero Count: " + zeroCount);
