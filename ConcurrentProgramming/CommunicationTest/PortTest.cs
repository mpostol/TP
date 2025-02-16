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
  /// <summary>
  /// Test class for the <see cref="Port"/> class. Here are the unit tests for all the methods of the <see cref="Port"/> class:
  /// </summary>
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

    /// <summary>
    /// Verifies that the port can be closed and indirectly checks if the port is closed by checking the count.
    /// </summary>
    [TestMethod]
    public void Close_ShouldSetOpenedToFalse()
    {
      // Arrange
      using (Port _port = new Port())
      {
        _port.Open();
        // Act
        _port.Close();
        // Test
        Assert.ThrowsException<InvalidOperationException>(() => _port.Count);
      }
    }

    /// <summary>
    /// Verifies that the port can be cleared and all messages are returned to the pool.
    /// </summary>
    [TestMethod]
    public void Clear_ShouldEmptyTheQueue()
    {
      // Arrange
      Mock<IEnvelope> _mockEnvelope = new Mock<IEnvelope>();
      IEnvelope _envelope = _mockEnvelope.Object;
      using (Port _port = new Port())
      {
        _port.Open();
        _port.SendMsg(ref _envelope);
        // Act
        _port.Clear();
        // Test
        Assert.IsNull(_envelope);
        Assert.AreEqual(0, _port.Count);
      }
    }

    /// <summary>
    /// Verifies that a message can be sent to the port.
    /// </summary>
    [TestMethod]
    public void SendMsg_ShouldAddMessageToQueue()
    {
      // Arrange
      Mock<IEnvelope> _mockEnvelope = new Mock<IEnvelope>();
      IEnvelope _envelope = _mockEnvelope.Object;
      using (Port _port = new Port())
      {
        _port.Open();
        // Act
        _port.SendMsg(ref _envelope);
        // Test
        Assert.AreEqual(1, _port.Count);
      }
    }

    /// <summary>
    /// Verifies that a message can be received from the port.
    /// </summary>
    [TestMethod]
    public void WaitMsg_ShouldRetrieveMessageFromQueue()
    {
      // Arrange
      Mock<IEnvelope> _mockEnvelope = new Mock<IEnvelope>();
      IEnvelope _envelope = _mockEnvelope.Object;
      IEnvelope? receivedMessage = null;
      using (Port _port = new Port())
      {
        _port.Open();
        _port.SendMsg(ref _envelope);
        // Act
        bool result = _port.WaitMsg(out receivedMessage);
        // Test
        Assert.IsTrue(result);
        Assert.IsNotNull(receivedMessage);
        Assert.AreSame(_mockEnvelope.Object, receivedMessage);
      }
    }
  }
}