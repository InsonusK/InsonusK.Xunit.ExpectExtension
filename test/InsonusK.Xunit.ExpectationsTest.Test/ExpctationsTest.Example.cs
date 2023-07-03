using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace InsonusK.Xunit.ExpectationsTest.Test;

public class ExpectationsTest_Example : ExpectationsTest
{
  public ExpectationsTest_Example(ITestOutputHelper output, LogLevel logLevel = LogLevel.Debug) : base(output, logLevel)
  {
  }


  [Fact]
  public void Example_of_expectation_test()
  {
    #region Array
    Logger.LogDebug("Test ARRAY");



    #endregion


    #region Act
    Logger.LogDebug("Test ACT");



    #endregion


    #region Assert
    Logger.LogDebug("Test ASSERT");

    Expect("Expect something", () => Assert.True(true));

    ExpectGroup("Expect group of conditions", () =>
    {
      Expect("Expectation from group 1", () => Assert.True(true));
      Expect("Expectation from group 2", () => Assert.True(true));
    });

    #endregion
  }
}