//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2025, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

namespace TP.ConcurrentProgramming.Fundamentals.Test
{
  [TestClass]
  public class IEnvelopeTest
  {
    [TestMethod]
    public void DetachedEnvelopeTest()
    {
      IEnvelope envelope = new DetachedEnvelope();
      Assert.IsFalse(envelope.InPool);
      Assert.ThrowsException<InvalidOperationException>(() => envelope.ReturnEmptyEnvelope());
      Assert.ThrowsException<NotImplementedException>(() => envelope.GetIEnvelopeManager);
    }

    #region tests instrumentation

    private abstract class EnvelopeAbstract : IEnvelope
    {
      private bool inPool = false;

      public bool InPool => inPool;

      public IEnvelopeManager GetIEnvelopeManager => throw new NotImplementedException();

      public void ReturnEmptyEnvelope()
      {
        if (!inPool)
          throw new InvalidOperationException("The envelope is not in the pool.");
      }
    }

    private class DetachedEnvelope : EnvelopeAbstract
    {
    }

    #endregion tests instrumentation
  }
}