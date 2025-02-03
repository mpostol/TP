//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2025, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________
using System.Linq;

namespace TP.ConcurrentProgramming.Fundamentals
{
  /// <summary>
  /// The EnvelopePool class manages a pool of IEnvelope objects.
  /// Thread Safety:
  /// Instances members of this type are safe for multi-threaded operations.
  /// </summary>
  public class EnvelopePool<DTOType>: IEnvelopeManager
    where DTOType : IEnvelope
  {
    #region PRIVATE

    private Queue<IEnvelope> m_Queue = new Queue<IEnvelope>();
    private readonly CreateEnvelope m_NewEnvelope;

    #endregion PRIVATE

    #region PUBLIC

    /// <summary>
    /// Delegate used to create new envelope. New envelope is created each time
    /// GetEmptyEnvelope is called while the pool is empty.
    /// </summary>
    public delegate DTOType CreateEnvelope(EnvelopePool<DTOType> source);

    /// <summary>
    /// It gets an empty envelope from the common pool, or if empty creates ones.
    /// </summary>
    /// <remarks>
    /// Retrieves an empty IEnvelope from the pool. If the pool is empty, it creates a new IEnvelope using the delegate passed by the constructor.
    /// The method is thread-safe, using a lock statement to ensure that only one thread can access the pool at a time.
    /// </remarks>
    public IEnvelope GetEmptyEnvelope()
    {
      IEnvelope currEnv;
      lock (this)
      {
        if (m_Queue.Count == 0)
          currEnv = m_NewEnvelope(this); //If empty, creates a new IEnvelope using the m_NewEnvelope delegate.
        else
          currEnv = m_Queue.Dequeue(); //If not empty, retrieves an empty IEnvelope from the pool.
      }
      return currEnv;
    }

    /// <summary>
    /// Returns an empty envelope to the common pool.
    /// </summary>
    /// <param name="mess">Envelope to return</param>
    public void ReturnEmptyEnvelope(IEnvelope envelope)
    {
      if (envelope == null)
        throw new NullReferenceException($"{nameof(envelope)} must not be null");
      if (m_Queue.Contains(envelope))
        throw new InvalidOperationException("ReturnEmptyEnvelope: envelope is already in pool");
      if (envelope.GetIEnvelopeManager != this)
        throw new InvalidOperationException("ReturnEmptyEnvelope: envelope is not from this pool");
      lock (this)
      {
        m_Queue.Enqueue(envelope);
      }
    }

    /// <summary>
    /// Creates instance of EnvelopePool
    /// </summary>
    /// <param name="userCreator">Is used to create new <see cref="IEnvelope"/>each time
    /// GetEmptyEnvelope is called while the pool is empty.</param>
    public EnvelopePool(CreateEnvelope userCreator)
    {
      m_NewEnvelope = userCreator;
    }

    #endregion PUBLIC
  }
}