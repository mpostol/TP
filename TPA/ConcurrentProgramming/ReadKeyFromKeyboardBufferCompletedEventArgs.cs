
using System;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming
{

    public class ReadKeyFromKeyboardBufferCompletedEventArgs : EventArgs
    {
        public char Result { get; set; }
    }
}
