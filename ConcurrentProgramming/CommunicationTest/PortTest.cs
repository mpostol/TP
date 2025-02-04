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
using TP.ConcurrentProgramming.Fundamentals;

namespace TP.ConcurrentProgramming.Communication.Test
{
  [TestClass]
  public class PortTest
  {
    /// <summary>
    /// Verifies that the Count property returns 0 when no messages are in the queue.
    /// </summary>
    [TestMethod]
    public void Count_ShouldReturnZero_WhenNoMessages()
    {
      int count = -1;
      // Arrange
      using (Port _port = new Port())
      {
        // Act, Test
        Assert.ThrowsException<InvalidOperationException>(() => count = _port.Count); //indirectly checking if port is open
        Assert.AreEqual(-1, count);
      }
    }

    /// <summary>
    /// Verifies that the port can be opened and indirectly checks if the port is open by checking the count.
    /// </summary>
    [TestMethod]
    public void Open_ShouldSetOpenedToTrue()
    {
      Mock<IEnvelope> _mockEnvelope = new Mock<IEnvelope>();
      // Arrange
      using (Port _port = new Port())
      {
        // Act
        _port.Open();
        // Test
        Assert.IsTrue(_port.Count == 0); //indirectly checking if port is open
      }
    }
  }
}