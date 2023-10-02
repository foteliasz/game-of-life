namespace GameOfLife.Data.Tests;

[TestClass]
public class WorldTests
{
    [TestMethod]
    public void Set_CorrectlySetsValueInMatrix_Always()
    {
        // --- Arrange --------------------------------------------------------
        var world = new World(3, 3);

        // --- Act ------------------------------------------------------------
        world.Set(1, 1);
        
        // --- Assert ---------------------------------------------------------
        var result = world.ToString();
        var expected =
            $"   {Environment.NewLine}" +
            $" ■ {Environment.NewLine}" +
            "   ";
        Assert.AreEqual(expected, result);
    }
}