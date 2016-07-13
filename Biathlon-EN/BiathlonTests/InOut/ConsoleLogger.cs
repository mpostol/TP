using System;
using System.Collections.Generic;
using System.IO;

namespace BiathlonTests.InOut
{
    //public class ConsoleLogger
    //{
    //}

    public class ConsoleInput : IDisposable
    {
        private StringReader stringReader;
        private TextReader originalInput;

        public ConsoleInput(string line)
        {
            stringReader = new StringReader(line + Environment.NewLine);
            originalInput = Console.In;
            Console.SetIn(stringReader);
        }

        public ConsoleInput(string[] lines)
            : this(String.Join(Environment.NewLine, lines))
        {
        }

        public ConsoleInput(List<Double> numbers)
            : this(numbers.ConvertAll(n => String.Format("{0}", n)).ToArray())
        {
        }

        public ConsoleInput(Double[] numbers)
            : this(new List<Double>(numbers))
        {
        }

        public void Dispose()
        {
            Console.SetIn(originalInput);
            stringReader.Dispose();
        }
    }

    // Source:
    // http://www.codeproject.com/Articles/501610/Getting-Console-Output-Within-A-Unit-Test

    public class ConsoleOutput : IDisposable
    {
        private StringWriter stringWriter;
        private TextWriter originalOutput;

        public ConsoleOutput()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public string GetOuput()
        {
            return stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }
}
