//___________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.IO;

namespace TPA.ApplicationArchitecture.BusinessLogic.Tests
{
  public class ConsoleOutput : IDisposable
  {
    private StringWriter stringWriter;
    private readonly TextWriter originalOutput;

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