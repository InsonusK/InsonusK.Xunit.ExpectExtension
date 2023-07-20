using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace InsonusK.Xunit.ExpectationsTest.Test;

public class ExpectationsTest_Example : ExpectationsTestBase
{
  public ExpectationsTest_Example(ITestOutputHelper output, LogLevel logLevel = LogLevel.Debug) : base(output, logLevel)
  {
  }


  [Fact]
  public async void Example_of_expectation_test()
  {
    #region Array
    Logger.LogDebug("Test ARRAY");

    var expectedValue = 123;

    #endregion


    #region Act
    Logger.LogDebug("Test ACT");



    #endregion


    #region Assert
    Logger.LogDebug("Test ASSERT");

    Expect("Expect something", () => Assert.True(true));
    await ExpectTaskAsync("Expectation from Delayed Assert", async () => await DelayedAssert());

    var assertedReturnValue = await ExpectTaskAsync("Expectation from DelayedValue", async () => await DelayedValue(expectedValue));
    Assert.Equal(expectedValue, assertedReturnValue);

    Logger.LogInformation("Experimental solution");

    ExpectTask("Expectation  from DelayedValue with out await", async () => await DelayedValue(expectedValue), out var assertedOutValue);
    Assert.Equal(assertedOutValue, assertedReturnValue);

    ExpectGroup("Expect group of conditions", () =>
    {
      Expect("Expectation from group 1", () => Assert.True(true));
      Expect("Expectation from group 2", () => Assert.True(true));
    });

    #endregion
  }
  public static async Task DelayedAssert()
  {
    // Wait for 1000 ms using Task.Delay
    await Task.Delay(1000);

    Assert.True(true);
  }
  public static async Task<int> DelayedValue(int returnValue)
  {
    // Wait for 1000 ms using Task.Delay
    await Task.Delay(1000);

    return returnValue;
  }
}