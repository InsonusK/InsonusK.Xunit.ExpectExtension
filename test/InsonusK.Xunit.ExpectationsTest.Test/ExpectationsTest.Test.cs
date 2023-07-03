using InsonusK.Xunit.ExpectationsTest.Test.Mocks;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit.Abstractions;

namespace InsonusK.Xunit.ExpectationsTest.Test;

public class ExpectationsTest_TestCase
{

  ILogger logger;
  public ExpectationsTest_TestCase(ITestOutputHelper output)
  {
    logger = output.BuildLoggerFor<ExpectationsTest_TestCase>();
  }

  [Fact]
  public void WHEN_call_expect_method_THEN_logging_is_called()
  {
    #region Array
    this.logger.LogDebug("Test ARRAY");

    ITestOutputHelper mockOutput = Substitute.For<ITestOutputHelper>();

    var assertedClass = new MockExpectationClass(mockOutput);
    var expectedExpectation = "Expect1";
    #endregion


    #region Act
    this.logger.LogDebug("Test ACT");

    var assertedIsAssertCalled = assertedClass.MakeExpectation(expectedExpectation);

    #endregion


    #region Assert
    this.logger.LogDebug("Test ASSERT");

    mockOutput.Received().WriteLine(Arg.Is<string>(v => v.Contains(expectedExpectation) && v.Contains("Checked")));

    #endregion
  }

  [Fact]
  public void WHEN_call_expect_method_THEN_assert_logic_is_called()
  {
    #region Array
    this.logger.LogDebug("Test ARRAY");

    ITestOutputHelper mockOutput = Substitute.For<ITestOutputHelper>();

    var assertedClass = new MockExpectationClass(mockOutput);
    #endregion


    #region Act
    this.logger.LogDebug("Test ACT");

    var assertedIsAssertCalled = assertedClass.MakeExpectation("Expect1");

    #endregion


    #region Assert
    this.logger.LogDebug("Test ASSERT");

    Assert.True(assertedIsAssertCalled);

    #endregion
  }

  [Fact]
  public void WHEN_expectation_in_expectation_THEN_it_throws_up()
  {
    #region Array
    this.logger.LogDebug("Test ARRAY");

    ITestOutputHelper mockOutput = Substitute.For<ITestOutputHelper>();

    var assertedClass = new MockExpectationClass(mockOutput);
    var expectedExpectation = "Expect1";
    var expectedId = new Random().Next();
    #endregion


    #region Act
    this.logger.LogDebug("Test ACT");

    #endregion


    #region Assert
    this.logger.LogDebug("Test ASSERT");

    var assertedException = Assert.Throws<ExpectedException>(() => assertedClass.MakeFailedExpectation(expectedExpectation, expectedId));
    Assert.Equal(expectedId, assertedException.ID);
    mockOutput.Received().WriteLine(Arg.Is<string>(v => v.Contains(expectedExpectation) && v.Contains("Failed")));

    #endregion
  }

  [Fact]
  public void WHEN_call_group_expect_THEN_log_called()
  {
    #region Array
    this.logger.LogDebug("Test ARRAY");


    ITestOutputHelper mockOutput = Substitute.For<ITestOutputHelper>();

    var assertedClass = new MockExpectationClass(mockOutput);
    var expectedExpectation = "Group Expect1";

    #endregion


    #region Act
    this.logger.LogDebug("Test ACT");

    var assertedIsAssertCalled = assertedClass.MakeGroupExpectation(expectedExpectation);

    #endregion


    #region Assert
    this.logger.LogDebug("Test ASSERT");
    mockOutput.Received().WriteLine(Arg.Is<string>(v => v.Contains(expectedExpectation) && v.Contains("Checking")));
    mockOutput.Received().WriteLine(Arg.Is<string>(v => v.Contains(expectedExpectation) && v.Contains("Checked")));

    #endregion
  }

  [Fact]
  public void WHEN_call_group_expect_THEN_sub_logic_called()
  {
    #region Array
    this.logger.LogDebug("Test ARRAY");


    ITestOutputHelper mockOutput = Substitute.For<ITestOutputHelper>();

    var assertedClass = new MockExpectationClass(mockOutput);

    #endregion


    #region Act
    this.logger.LogDebug("Test ACT");

    var assertedIsAssertCalled = assertedClass.MakeGroupExpectation("Group expectation");

    #endregion


    #region Assert
    this.logger.LogDebug("Test ASSERT");

    Assert.True(assertedIsAssertCalled);

    #endregion
  }

  [Fact]
  public void WHEN_expectation_group_in_expectation_THEN_it_throws_up()
  {
    #region Array
    this.logger.LogDebug("Test ARRAY");

    ITestOutputHelper mockOutput = Substitute.For<ITestOutputHelper>();

    var assertedClass = new MockExpectationClass(mockOutput);
    var expectedExpectation = "Expect1";
    var expectedId = new Random().Next();
    #endregion


    #region Act
    this.logger.LogDebug("Test ACT");

    #endregion


    #region Assert
    this.logger.LogDebug("Test ASSERT");

    var assertedException = Assert.Throws<ExpectedException>(() => assertedClass.MakeFailedGroupExpectation(expectedExpectation, expectedId));
    Assert.Equal(expectedId, assertedException.ID);
    mockOutput.Received().WriteLine(Arg.Is<string>(v => v.Contains(expectedExpectation) && v.Contains("Checking")));
    mockOutput.Received().WriteLine(Arg.Is<string>(v => v.Contains(expectedExpectation) && v.Contains("Failed")));

    #endregion
  }
}