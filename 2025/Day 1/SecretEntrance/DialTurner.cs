namespace SecretEntrance;

public static class DialTurner
{
    /// <summary>
    /// Part 1
    /// </summary>
    public static int CountEveryLandingZero(string[] instructions)
    {
        int zeroCount = 0, currentNumber = 50;
       
        foreach (var instruction in instructions)
        {
            var clicks = int.Parse(instruction[1..]);
            var direction = instruction[0] == 'R' ? 1 : -1;
            var rotation = clicks * direction;
   
            currentNumber += rotation;
            currentNumber = (currentNumber % 100 + 100) % 100;
   
            if (currentNumber == 0) zeroCount++;
        }

        return zeroCount;
    } 
   
    /// <summary>
    /// Part 2
    /// </summary>
    public static int CountEveryPassingZero(string[] instructions)
    {
        int zeroCount = 0, currentNumber = 50;

        foreach (var instruction in instructions)
        {
            var clicks = int.Parse(instruction[1..]);
            var direction = instruction[0] == 'R' ? 1 : -1;
            var fullRotations = clicks / 100;
            zeroCount += fullRotations;
            var rotation = (clicks - fullRotations * 100) * direction;

            currentNumber += rotation;
            zeroCount += currentNumber < 0 && currentNumber != rotation ? 1 : currentNumber > 100 ? currentNumber / 100 : 0;
            currentNumber = (currentNumber % 100 + 100) % 100;

            if (currentNumber == 0) zeroCount++;
        }

        return zeroCount;
    }
}
