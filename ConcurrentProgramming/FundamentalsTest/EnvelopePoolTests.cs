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
  public class EnvelopePoolTests
  {
    [TestMethod]
    public void ConstructorTest()
    {
      EnvelopePool<IEnvelope> pool = new(x => new DTOFixture(x));
      Assert.IsNotNull(pool.GetEmptyEnvelope());
    }

    [TestMethod]
    public void ReturnEmptyEnvelope_WhenEnvelopeIsNull_ThrowsException()
    {
      // Arrange
      EnvelopePool<IEnvelope> envelopePool = new(source => new Mock<IEnvelope>().Object);

      // Act & Assert
      Assert.ThrowsException<NullReferenceException>(() => envelopePool.ReturnEmptyEnvelope(null));
    }

    [TestMethod]
    public void GetEmptyEnvelope_WhenPoolIsEmpty_CreatesNewEnvelope()
    {
      // Arrange
      IEnvelope? mockEnvelope = null;
      EnvelopePool<IEnvelope> envelopePool = new(envelopePoo => { mockEnvelope = new DTOFixture(envelopePoo); return mockEnvelope; });

      // Act
      IEnvelope result = envelopePool.GetEmptyEnvelope();

      // Assert
      Assert.AreSame<IEnvelope>(mockEnvelope, result);
    }

    [TestMethod]
    public void EmptyEnvelopeIsInstanceOfTypeType()
    {
      // Arrange
      EnvelopePool<IEnvelope> envelopePool = new(envelopePoo => new DTOFixture(envelopePoo));

      // Act
      IEnvelope result = envelopePool.GetEmptyEnvelope();

      // Assert
      Assert.IsInstanceOfType(result, typeof(DTOFixture));
    }

    [TestMethod]
    public void GetEmptyEnvelopeCreatesNewEnvelopeEachTimeTestMethod()
    {
      // Arrange
      EnvelopePool<IEnvelope> envelopePool = new(envelopePoo => new DTOFixture(envelopePoo));

      // Act
      IEnvelope[] result = [envelopePool.GetEmptyEnvelope(), envelopePool.GetEmptyEnvelope()];

      // Assert
      Assert.AreNotSame<IEnvelope>(result[0], result[1]);
    }

    [TestMethod]
    public void Return_Alien_Envelope_ThrowsException()
    {
      // Arrange
      Mock<IEnvelope> mockEnvelope = new Mock<IEnvelope>();
      IEnvelopeManager envelopePool = new EnvelopePool<IEnvelope>(source => mockEnvelope.Object);

      // Act & Assert
      Assert.ThrowsException<InvalidOperationException>(() => envelopePool.ReturnEmptyEnvelope(mockEnvelope.Object));
    }

    [TestMethod]
    public void ReturnEmptyEnvelope_WhenEnvelopeIsAlreadyInPool_ThrowsException()
    {
      // Arrange
      EnvelopePool<IEnvelope> envelopePool = new(source =>  new DTOFixture(source));
      IEnvelope mockEnvelope = envelopePool.GetEmptyEnvelope();
      envelopePool.ReturnEmptyEnvelope(mockEnvelope);

      // Act & Assert
      Assert.ThrowsException<InvalidOperationException>(() => envelopePool.ReturnEmptyEnvelope(mockEnvelope));
    }

    #region test instrumentation

    private class DTOFixture : Envelope
    {
      public DTOFixture(EnvelopePool<IEnvelope> manager) : base(manager)
      {
      }
    }

    #endregion test instrumentation
  }
}