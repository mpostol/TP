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
  /// Envelope management - the envelope is a kind of packet that is transmitted in the communication between threads,
  /// </summary>
  public interface IEnvelopeManager
  {
    /// <summary>
    /// Returns an envelope instance of the <see cref="Envelope"/> type to a common pool.
    /// </summary>
    /// <param name="envelope">Data Transfer Object</param>
    void ReturnEmptyEnvelope(IEnvelope envelope);
  }
}