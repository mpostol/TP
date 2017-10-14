using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming
{
    public class Keyboard
    {
        private readonly Queue<char> _charBuffer = new Queue<char>();
        private readonly AutoResetEvent _autoResetEvent = new AutoResetEvent(false);
        private Timer _timer;

        public void StartTyping()
        {
            _timer = new Timer(GenerateChar, _autoResetEvent, 1500, 200);
        }

        public void StopTyping()
        {
            _timer.Dispose();
            _charBuffer.Clear();
        }

        public Task<char> ReadKeyFromKeyboardBufferAsync()
        {
            TaskCompletionSource<char> tcs = new TaskCompletionSource<char>();

            if (_charBuffer.Any())
            {
                tcs.SetResult(_charBuffer.Dequeue());
                return tcs.Task;
            }

            _autoResetEvent.WaitOne();

            tcs.SetResult(_charBuffer.Dequeue());

            return tcs.Task;
        }

        private void GenerateChar(object state)
        {
            Random r = new Random();
            _charBuffer.Enqueue((char) r.Next('a', 'z'));
            _autoResetEvent.Set();
        }
    }
}
