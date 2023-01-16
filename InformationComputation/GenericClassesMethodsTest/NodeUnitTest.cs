//__________________________________________________________________________________________
//
//  Copyright 2023 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TP.InformationComputation.GenericClassesMethods
{
  [TestClass]
  public class NodeUnitTest
  {
    [TestMethod]
    public void IntSequenceTest()
    {
      Node<int> firstNode = new Node<int>(null, 2141252485);
      Assert.AreEqual<int>(2141252485, firstNode.Value);
      firstNode = new Node<int>(firstNode, 472362326);
      Assert.AreEqual<int>(472362326, firstNode.Value);
      Assert.AreEqual<int>(2141252485, firstNode.Next.Value);
      Assert.AreNotSame(firstNode, firstNode.Next);
    }

    [TestMethod]
    public void AnyClassSequenceTest()
    {
      Node<AnyClass> firstNode = new Node<AnyClass>(null, new AnyClass());
      firstNode = new Node<AnyClass>(firstNode, new AnyClass());
      Assert.AreNotSame(firstNode, firstNode.Next);
    }

    //instrumentation
    private class AnyClass
    { }
  }
}