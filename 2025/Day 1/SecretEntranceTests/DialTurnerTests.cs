using SecretEntrance;

namespace SecretEntranceTests;

public class DialTurnerTests
{
    [Fact]
    public void EverLandingZero_GivenSimpleInstructions_ReturnsCorrectZeroCount()
    {
        string[] simpleInstructions = ["L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82"];
        var zeroCount = new DialTurner().CountEveryLandingZero(simpleInstructions);
        Assert.Equal(3, zeroCount);
    }
    
    [Theory]
    [InlineData("L1000", 10)]
    [InlineData("L1049", 10)]
    [InlineData("L1050", 11)]
    [InlineData("L1051", 11)]
    [InlineData("R1000", 10)]
    [InlineData("R1049", 10)]
    [InlineData("R1050", 11)]
    [InlineData("R1051", 11)]
    public void EveryPassingZero_GivenInstruction_ReturnsCorrectZeroCount(string instruction, int expectedZeroCount)
    {
        string[] instructions = [instruction];
        var zeroCount = new DialTurner().CountEveryPassingZero(instructions);
        Assert.Equal(expectedZeroCount, zeroCount);
    }
    
    [Fact]
    public void EverPassingZero_GivenSimpleInstructions_ReturnsCorrectZeroCount()
    {
        string[] simpleInstructions = ["L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82"];
        var zeroCount = new DialTurner().CountEveryPassingZero(simpleInstructions);
        Assert.Equal(6, zeroCount);
    }
}
