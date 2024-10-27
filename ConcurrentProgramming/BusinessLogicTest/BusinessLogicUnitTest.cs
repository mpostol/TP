//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

using TP.ConcurrentProgramming.BusinessLogic;

namespace BusinessLogicTest
{
  [TestClass]
  public class BusinessLogicUnitTest
  {
    [TestMethod]
    public void BusinessLogicConstructorTestMethod()
    {
      BusinessLogicAbstractAPI instance1 = BusinessLogicAbstractAPI.GetBusinessLogicLayer();
      BusinessLogicAbstractAPI instance2 = BusinessLogicAbstractAPI.GetBusinessLogicLayer();
      Assert.AreSame(instance1, instance2);
    }

    [TestMethod]
    public void StartTestMethod()
    {
      BusinessLogicAbstractAPI instance = BusinessLogicAbstractAPI.GetBusinessLogicLayer();
      Assert.ThrowsException<NotImplementedException>(() => instance.Start(10));
    }

    [TestMethod]
    public void DisposeTestMethod()
    {
      BusinessLogicAbstractAPI instance = BusinessLogicAbstractAPI.GetBusinessLogicLayer();
      Assert.ThrowsException<NotImplementedException>(() => instance.Dispose());
    }

    [TestMethod]
    public void GetDimensionsTestMethod()
    {
      BusinessLogicAbstractAPI instance = BusinessLogicAbstractAPI.GetBusinessLogicLayer();
      Assert.AreEqual<Dimensions>(new(10.0, 10.0, 10.0), instance.GetDimensions);
    }
  }
}