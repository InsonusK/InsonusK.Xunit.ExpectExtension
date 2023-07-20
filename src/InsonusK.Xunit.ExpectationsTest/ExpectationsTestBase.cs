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
  protected void ExpectTask(string exception, Func<Task> assertAction)
  {
    try
    {
      assertAction.Invoke().Wait();
    }
    catch (System.Exception)
    {
      Logger.LogInformation($"{exception} - Failed");
      throw;
    }
    Logger.LogInformation($"{exception} - Checked");
  }
  protected async Task ExpectTaskAsync(string exception, Func<Task> assertAction)
  {
    try
    {
      await assertAction.Invoke();
    }
    catch (System.Exception)
    {
      Logger.LogInformation($"{exception} - Failed");
      throw;
    }
    Logger.LogInformation($"{exception} - Checked");
  }
  protected async Task<TRet> ExpectTaskAsync<TRet>(string exception, Func<Task<TRet>> assertAction)
  {
    try
    {
      var returnObject = await assertAction.Invoke();
      Logger.LogInformation($"{exception} - Checked");
      return returnObject;
    }
    catch (System.Exception)
    {
      Logger.LogInformation($"{exception} - Failed");
      throw;
    }
  }
  protected void ExpectTask<TRet>(string exception, Func<Task<TRet>> assertAction, out TRet returnObject)
  {
    try
    {
      returnObject = assertAction.Invoke().GetAwaiter().GetResult();
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
