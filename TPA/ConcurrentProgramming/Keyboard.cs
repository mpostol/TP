
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming
{
    public class Keyboard : IDisposable
    {

        public Keyboard()
        {
            m_Timer = new Timer(GenerateChar, m_AutoResetEvent, 1500, 200);
        }
        public Task<char> ReadKeyFromKeyboardBufferAsync()
        {
            TaskCompletionSource<char> _tcs = new TaskCompletionSource<char>();
            //raise condition 
            if (_charBuffer.Any())
            {
                _tcs.SetResult(_charBuffer.Dequeue());
                return _tcs.Task;
            }
            //
            //if the GenerateChar is called here we will wait forever.
            //A race condition exists when the success of your program depends on the uncontrolled order of completion of two independent threads. 
            m_AutoResetEvent.WaitOne();
            _tcs.SetResult(_charBuffer.Dequeue());
            return _tcs.Task;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue)
                return;
            if (disposing)
            {
                m_Timer.Dispose();
                _charBuffer.Clear();
            }
            disposedValue = true;
        }
        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion

        #region private
        private readonly Queue<char> _charBuffer = new Queue<char>();
        private readonly AutoResetEvent m_AutoResetEvent = new AutoResetEvent(false);
        private Timer m_Timer;
        private Random m_Random = new Random();
        private void GenerateChar(object state)
        {
            _charBuffer.Enqueue((char)m_Random.Next('a', 'z'));
            m_AutoResetEvent.Set();
        }
        #endregion

    }
}
