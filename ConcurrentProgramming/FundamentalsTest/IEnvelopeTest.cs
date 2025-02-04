//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2025, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

using Moq;

namespace TP.ConcurrentProgramming.Fundamentals.Test
{
  [TestClass]
  public class IEnvelopeTest
  {
    [TestMethod]
    public void DetachedEnvelopeTest()
    {
      Mock<IEnvelopeManager> envelopeManager = new Mock<IEnvelopeManager>();
      IEnvelope envelope = new EnvelopeFixture(envelopeManager.Object);
    }

    #region tests instrumentation

    private class EnvelopeFixture : Envelope
    {
      public EnvelopeFixture(IEnvelopeManager manager) : base(manager)
      {
      }
    }

    #endregion tests instrumentation
  }
}