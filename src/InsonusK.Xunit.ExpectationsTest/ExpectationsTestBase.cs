using Divergic.Logging.Xunit;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace InsonusK.Xunit.ExpectationsTest;

public abstract class ExpectationsTestBase : LoggingTestsBase
{
  public ExpectationsTestBase(ITestOutputHelper output, LogLevel logLevel = LogLevel.Debug) : base(output, logLevel)
  {

  }

  protected void Expect(string exception, Action assertAction)
  {
    try
    {
      assertAction.Invoke();
    }
    catch (System.Exception)
    {
      Logger.LogInformation($"{exception} - Failed");
      throw;
    }
    Logger.LogInformation($"{exception} - Checked");
  }
  protected void Expect<TRet>(string exception, Func<TRet> assertFunc, out TRet returnObject)
  {
    try
    {
      returnObject = assertFunc.Invoke();
    }
    catch (System.Exception)
    {
      Logger.LogInformation($"{exception} - Failed");
      throw;
    }
    Logger.LogInformation($"{exception} - Checked");
  }
  protected void ExpectGroup(string exception, Action assertAction)
  {
    Logger.LogInformation($"{exception} - Checking");
    try
    {
      assertAction.Invoke();
    }
    catch (System.Exception)
    {
      Logger.LogInformation($"{exception} - Failed");
      throw;
    }
    Logger.LogInformation($"{exception} - Checked");
  }
  protected void ExpectGroup<TRet>(string exception, Func<TRet> assertFunc, out TRet returnObject)
  {
    Logger.LogInformation($"{exception} - Checking");
    try
    {
      returnObject = assertFunc.Invoke();
    }
    catch (System.Exception)
    {
      Logger.LogInformation($"{exception} - Failed");
      throw;
    }
    Logger.LogInformation($"{exception} - Checked");
  }
}
