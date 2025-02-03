//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2025, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

namespace TP.ConcurrentProgramming.Fundamentals
{
  /// <summary>
  /// Interface for envelope management - the envelope is a kind of packet that is transmitted in the communication or application layer,
  /// it is base unit for message exchange mechanism.
  /// </summary>
  /// <remarks>It is a part of the <a href="https://en.wikipedia.org/wiki/Message_passing">Message passing</a> concept.
  /// This interface is intended for managing envelopes, which are described as packets used in communication for message exchange mechanisms.
  /// </remarks>
  public interface IEnvelope
  {
    /// <summary>
    /// Used by a user to return an empty envelope to a pool. It also resets the message content.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the envelope is not in the pool.</exception>"
    void ReturnEmptyEnvelope();

    /// <summary>
    /// Checks if the <see cref="IEnvelope"/> is in the pool of envelopes associated with a specific <see cref="IEnvelopeManager"/>.
    /// </summary>
    /// <remarks>This read-only property checks if the envelope is currently in the pool.
    /// </remarks>
    /// <returns>
    /// `true`, the envelope is in the pool and available for reuse. If `false`, the envelope is currently in use by a user.
    /// </returns>
    bool InPool
    {
      get;
    }

    /// <summary>
    /// Gets the <see cref="IEnvelopeManager"/> associated with this <see cref="IEnvelope"/>.
    /// </summary>
    IEnvelopeManager GetIEnvelopeManager
    {
      get;
    }
  }
}