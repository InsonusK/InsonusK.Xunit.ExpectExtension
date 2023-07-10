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
[Link to example](./test/InsonusK.Xunit.ExpectationsTest.Test/ExpctationsTest.Example.cs)
```C#
Expect("Expect something", () => Assert.True(true));

ExpectGroup("Expect group of conditions", () =>
{
  Expect("Expectation from group 1", () => Assert.True(true));
  Expect("Expectation from group 2", () => Assert.True(true));
});
```
