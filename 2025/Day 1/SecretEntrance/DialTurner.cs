namespace SecretEntrance;

public class DialTurner
{
    private int _currentNumber = 50, _zeroCount = 0;
    
    /// <summary>
    /// Part 1
    /// </summary>
    public int CountEveryLandingZero(string[] instructions)
    {
        foreach (var instruction in instructions)
        {
            var (clicks, direction) = ParseInstruction(instruction);
            
            var rotation = clicks * direction;
   
            _currentNumber += rotation;
            
            WrapAroundTheDial();
   
            if (_currentNumber == 0) _zeroCount++;
        }

        return _zeroCount;
    } 
   
    /// <summary>
    /// Part 2
    /// Increment zeroCound for three scenarios:
    /// <list type="bullet">
    ///     <item>The number of clicks is greater than 100, and you can count each full rotation</item>
    ///     <item>After rotating the dial, you've passed 0</item>
    ///     <item>You land on zero</item>
    /// </list>
    /// </summary>
    public int CountEveryPassingZero(string[] instructions)
    {
        foreach (var instruction in instructions)
        {
            var (clicks, direction) = ParseInstruction(instruction);
            
            var fullRotations = clicks / 100;
            _zeroCount += fullRotations;
            
            var rotation = (clicks - fullRotations * 100) * direction;

            _currentNumber += rotation;
            
            var hasPassedZero = (_currentNumber < 0 && _currentNumber != rotation) || _currentNumber > 100;
            _zeroCount += hasPassedZero ? 1 : 0;

            WrapAroundTheDial();
            
            if (_currentNumber == 0) _zeroCount++;
        }

        return _zeroCount;
    }

    /// <summary>
    /// Pull the number of clicks and direction from the instruction string in that order
    /// </summary>
    /// <returns>A tuple containing the number of clicks and direction</returns>
    private static (int, int) ParseInstruction(string instruction) =>
        (int.Parse(instruction[1..]), instruction[0] == 'R' ? 1 : -1);
    
    /// <summary>
    /// C# doesn't modulo like other languages, so we have to manually wrap around the dial
    /// Otherwise, I'd just use <c>_currentNumber %= 100;</c>
    /// </summary>
    private void WrapAroundTheDial() => _currentNumber = (_currentNumber % 100 + 100) % 100;
}
