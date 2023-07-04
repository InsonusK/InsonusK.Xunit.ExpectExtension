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

  public void MakeFailedExpectation(string expectation, int id)
  {

    Expect(expectation, () => throw new ExpectedException(id));

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