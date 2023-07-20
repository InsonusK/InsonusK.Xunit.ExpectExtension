# Expectation test

## Description
Lib define class Expectatin Test which suppert "Expect" methods

## Example

### Import
```xml
<ItemGroup>
  <PackageReference Include="InsonusK.Xunit.ExpectationsTest" Version="1.0.3" />
</ItemGroup>
```

### Using
[Link to example](./test/InsonusK.Xunit.ExpectationsTest.Test/ExpctationsTestBase.Example.cs)
```C#
public class ExpectationsTest_Example : ExpectationsTestBase
{
  public ExpectationsTest_Example(ITestOutputHelper output, LogLevel logLevel = LogLevel.Debug) : base(output, logLevel)
  {
  }


  [Fact]
  public void Example_of_expectation_test()
  {
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
  }
}
```
