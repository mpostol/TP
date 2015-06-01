using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Lecture
{
  public class InterfaceExample: ICollection
  {
    #region ICollection Members
    /// <summary>
    /// Copies the elements of the <see cref="T:System.Collections.ICollection" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.
    /// </summary>
    /// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.ICollection" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
    /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
    /// <exception cref="System.NotImplementedException"></exception>
    public void CopyTo( Array array, int index )
    {
      m_ArrayExample.CopyTo( array, index );
    }

    /// <summary>
    /// Gets the number of elements contained in the <see cref="T:System.Collections.ICollection" />.
    /// </summary>
    /// <returns>The number of elements contained in the <see cref="T:System.Collections.ICollection" />.</returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public int Count
    {
      get { return m_ArrayExample.Length; }
    }

    /// <summary>
    /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe).
    /// </summary>
    /// <returns>true if access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe); otherwise, false.</returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public bool IsSynchronized
    {
      get { return m_ArrayExample.IsSynchronized; }
    }

    /// <summary>
    /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.
    /// </summary>
    /// <returns>An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.</returns>
    /// <exception cref="System.NotImplementedException"></exception>
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
    /// <exception cref="System.NotImplementedException"></exception>
    public IEnumerator GetEnumerator()
    {
      return m_ArrayExample.GetEnumerator();
    }
    #endregion
    public double this[ int index ]
    {
      get { return m_ArrayExample[ index ]; }
      set { m_ArrayExample[ index ] = value; }
    }
    #region private
    public double[] m_ArrayExample = { 0, 1, 2, 3 };
    #endregion

  }
}
