namespace InsonusK.Xunit.ExpectationsTest.Test.Mocks;

public class ExpectedException : Exception
{
  public readonly int? ID=null;
  public ExpectedException(int id)
  {
    ID = id;
  }
  public ExpectedException()
  {
  }
}