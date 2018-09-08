//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.Collections;

namespace TP.DataSemantics.TypeConcept
{
  public class InterfaceExample: ICollection
  {

    #region ICollection Members
    /// <summary>
    /// Copies the elements of the <see cref="T:System.Collections.ICollection" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.
    /// </summary>
    /// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.ICollection" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
    /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
    public void CopyTo( Array array, int index )
    {
      m_ArrayExample.CopyTo( array, index );
    }
    /// <summary>
    /// Gets the number of elements contained in the <see cref="T:System.Collections.ICollection" />.
    /// </summary>
    /// <returns>The number of elements contained in the <see cref="T:System.Collections.ICollection" />.</returns>
    public int Count
    {
      get { return m_ArrayExample.Length; }
    }
    /// <summary>
    /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe).
    /// </summary>
    /// <returns>true if access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe); otherwise, false.</returns>
    public bool IsSynchronized
    {
      get { return m_ArrayExample.IsSynchronized; }
    }
    /// <summary>
    /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.
    /// </summary>
    /// <returns>An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.</returns>
    public object SyncRoot
    {
      get { return m_ArrayExample.SyncRoot; }
    }
    #endregion

    #region IEnumerable Members
    /// <summary>
    /// Returns an enumerator that iterates through a collection.
    /// </summary>
    /// <returns>
    /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
    /// </returns>
    public IEnumerator GetEnumerator()
    {
      return m_ArrayExample.GetEnumerator();
    }
    #endregion

    #region public API
    public double this[int index]
    {
      get { return m_ArrayExample[index]; }
      set { m_ArrayExample[index] = value; }
    }
    #endregion

    #region private
    private double[] m_ArrayExample = { 0, 1, 2, 3 };
    #endregion

  }
}
