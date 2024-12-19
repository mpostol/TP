//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

namespace TP.ConcurrentProgramming.Synchronization.Test
{
  [TestClass]
  public class ConditionUnitTest
  {
    [TestMethod]
    public void ConstructorTest()
    {
      Condition condition = new Condition();
      Assert.IsNotNull(condition);
    }
  }
}