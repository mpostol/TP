
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming
{
    public class Keyboard : IDisposable
    {

        public event EventHandler<ReadKeyFromKeyboardBufferCompletedEventArgs> ReadKeyFromKeyboardBufferCompleted;
        public Keyboard()
        {
            m_Timer = new Timer(GenerateChar, m_AutoResetEvent, 1500, 200);
        }
        //TODO ist is not async method 
        public Task<char> ReadKeyFromKeyboardBufferAsync()
        {
            char result;
            TaskCompletionSource<char> _tcs = new TaskCompletionSource<char>();
            m_AutoResetEvent.WaitOne();
            Debug.Assert(_charBuffer.Any<Char>());
            _charBuffer.TryDequeue(out result);
            _tcs.SetResult(result);
            return _tcs.Task;
        }
        public void ReadKeyFromKeyboardBufferAsyncUsingEAP()
        {
            char _result = default;
            AutoResetEvent _autoResetEvent = new AutoResetEvent(false);
            void _Callback(object state)
            {
                try
                {
                    _result = ReadKeyFromKeyboardBuffer();
                }
                finally
                {
                    _autoResetEvent.Set();
                }
            }
            ThreadPool.QueueUserWorkItem(_Callback);
            _autoResetEvent.WaitOne();
            _autoResetEvent.Close();
            ReadKeyFromKeyboardBufferCompleted?.Invoke(this, new ReadKeyFromKeyboardBufferCompletedEventArgs { Result = _result });
        }
        public IAsyncResult BeginReadKeyFromKeyboardBuffer(AsyncCallback callback, object parameter)
        {
            m_Caller = ReadKeyFromKeyboardBuffer;
            return m_Caller.BeginInvoke(callback, parameter);
        }
        public char EndReadKeyFromKeyboardBuffer(IAsyncResult result)
        {
            return m_Caller.EndInvoke(result);
        }
        private char ReadKeyFromKeyboardBuffer()
        {
            char result;
            m_AutoResetEvent.WaitOne();
            Debug.Assert(_charBuffer.Any<Char>());
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
                m_AutoResetEvent.Close();
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
        private delegate char AsyncMethodCaller();
        private readonly ConcurrentQueue<char> _charBuffer = new ConcurrentQueue<char>();
        private readonly AutoResetEvent m_AutoResetEvent = new AutoResetEvent(false);
        private Timer m_Timer;
        private Random m_Random = new Random();
        private AsyncMethodCaller m_Caller;

        private void GenerateChar(object state)
        {
            _charBuffer.Enqueue((char)m_Random.Next('a', 'z'));
            m_AutoResetEvent.Set();
        }
        #endregion

    }
}
