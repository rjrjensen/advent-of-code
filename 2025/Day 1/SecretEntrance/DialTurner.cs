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
            _currentNumber = (_currentNumber % 100 + 100) % 100;
   
            if (_currentNumber == 0) _zeroCount++;
        }

        return _zeroCount;
    } 
   
    /// <summary>
    /// Part 2
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
            _zeroCount += _currentNumber < 0 && _currentNumber != rotation ? 1 : _currentNumber > 100 ? _currentNumber / 100 : 0;
            _currentNumber = (_currentNumber % 100 + 100) % 100;

            if (_currentNumber == 0) _zeroCount++;
        }

        return _zeroCount;
    }

    private static (int, int) ParseInstruction(string instruction) =>
        (int.Parse(instruction[1..]), instruction[0] == 'R' ? 1 : -1);
}
