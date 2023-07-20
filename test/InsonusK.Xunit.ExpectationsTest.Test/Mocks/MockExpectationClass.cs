using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace InsonusK.Xunit.ExpectationsTest.Test.Mocks;

public class MockExpectationClass : ExpectationsTestBase
{
  public MockExpectationClass(ITestOutputHelper output, LogLevel logLevel = LogLevel.Debug) : base(output, logLevel)
  {
  }

  public bool MakeExpectation(string expectation)
  {
    var isAssertCalled = false;
    Expect(expectation, () => isAssertCalled = true);
    return isAssertCalled;
  }

  public int MakeExpectationWithReturn(string expectation, int expectedValue)
  {
    Expect(expectation, () => expectedValue, out var returnValue);
    return returnValue;
  }
  public async Task<int> MakeAsyncExpectationWithReturn(string expectation, int expectedValue)
  {
    var returnValue = await ExpectTaskAsync(expectation, async () => await DelayedValue(expectedValue));
    return returnValue;
  }
  public static async Task<int> DelayedValue(int returnValue)
  {
    // Wait for 1000 ms using Task.Delay
    await Task.Delay(1000);

    // Return the integer value (e.g., 42 in this example)
    return returnValue;
  }
  public async Task<bool> MakeAsyncExpectation(string expectation)
  {
    var isAssertCalled = false;
    await ExpectTaskAsync(expectation, async () => await Task.Run(() => { Thread.Sleep(1000); isAssertCalled = true; }));
    return isAssertCalled;
  }

  public void MakeFailedExpectation(string expectation, int id)
  {

    ExpectTaskAsync(expectation, () => throw new ExpectedException(id));

  }

  public async Task MakeFailedAsyncExpectation(string expectation, int id)
  {

    await ExpectTaskAsync(expectation, async () => await Task.Run(() => { Thread.Sleep(1000); throw new ExpectedException(id); }));

  }

  public bool MakeGroupExpectation(string groupExpectation)
  {
    var isAssertCalled = false;
    ExpectGroup(groupExpectation, () => isAssertCalled = true);
    return isAssertCalled;
  }

  public void MakeFailedGroupExpectation(string expectation, int id)
  {

    ExpectGroup(expectation, () => throw new ExpectedException(id));

  }
}