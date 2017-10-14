using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.AsynchronousBehavior.ConcurrentProgramming
{
    public delegate void ReadKeyFromKeyboardBufferCompletedEventHandler(object sender,
        ReadKeyFromKeyboardBufferCompletedEventArgs e);

    public class ReadKeyFromKeyboardBufferCompletedEventArgs : EventArgs
    {
        public char Result { get; set; }
    }
}
