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
  public abstract class Envelope : IEnvelope

  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Envelope"/> class.
    /// </summary>
    /// <param name="manager"> </param>
    /// <exception cref="ArgumentNullException">if the <paramref name="manager"/> is null</exception>
    protected Envelope(IEnvelopeManager manager)
    {
      if (manager == null)
        throw new ArgumentNullException($"{nameof(manager)} must not be null");
      GetIEnvelopeManager = manager;
    }

    public void ReturnEmptyEnvelope()
    {
      GetIEnvelopeManager.ReturnEmptyEnvelope(this);
    }

    public IEnvelopeManager GetIEnvelopeManager { get; set; }

    public bool InPool => throw new NotImplementedException();
  }
}