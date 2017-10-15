using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming
{
    public class Keyboard : IDisposable
    {
        public event ReadKeyFromKeyboardBufferCompletedEventHandler ReadKeyFromKeyboardBufferCompleted;

        public Keyboard()
        {
            m_Timer = new Timer(GenerateChar, m_AutoResetEvent, 1500, 200);
        }
        public Task<char> ReadKeyFromKeyboardBufferAsync()
        {
            char result;
            TaskCompletionSource<char> _tcs = new TaskCompletionSource<char>();
            //race condition
            if (_charBuffer.Any())
            {
                _charBuffer.TryDequeue(out result);
                _tcs.SetResult(result);
                return _tcs.Task;
            }
            //
            //if the GenerateChar is called here we will wait forever.
            //A race condition exists when the success of your program depends on the uncontrolled order of completion of two independent threads. 
            m_AutoResetEvent.WaitOne();
            _charBuffer.TryDequeue(out result);
            _tcs.SetResult(result);
            return _tcs.Task;
        }

        public void ReadKeyFromKeyboardBufferAsyncUsingEAP()
        {
            char result = default;
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);

            void Callback(object state)
            {
                try
                {
                    result = ReadKeyFromKeyboardBuffer();
                }
                finally
                {
                    autoResetEvent.Set();
                }
            }

            ThreadPool.QueueUserWorkItem(Callback);
            autoResetEvent.WaitOne();
            autoResetEvent.Close();

            ReadKeyFromKeyboardBufferCompleted?.Invoke(this, new ReadKeyFromKeyboardBufferCompletedEventArgs { Result = result });
        }

        public IAsyncResult BeginReadKeyFromKeyboardBuffer(AsyncCallback callback, object parameter)
        {
            _caller = ReadKeyFromKeyboardBuffer;

            return _caller.BeginInvoke(callback, parameter);
        }

        public char EndReadKeyFromKeyboardBuffer(IAsyncResult result)
        {
            return _caller.EndInvoke(result);
        }

        private char ReadKeyFromKeyboardBuffer()
        {
            char result;

            if (_charBuffer.Any())
            {
                _charBuffer.TryDequeue(out result);
                return result;
            }

            m_AutoResetEvent.WaitOne();

            _charBuffer.TryDequeue(out result);
            return result;
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
        private readonly ConcurrentQueue<char> _charBuffer = new ConcurrentQueue<char>();
        private readonly AutoResetEvent m_AutoResetEvent = new AutoResetEvent(false);
        private Timer m_Timer;
        private Random m_Random = new Random();

        private delegate char AsyncMethodCaller();
        private AsyncMethodCaller _caller;

        private void GenerateChar(object state)
        {
            _charBuffer.Enqueue((char)m_Random.Next('a', 'z'));
            m_AutoResetEvent.Set();
        }
        #endregion

    }
}
