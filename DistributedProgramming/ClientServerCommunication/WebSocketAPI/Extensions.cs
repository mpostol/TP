//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//___________________________________________________________________________________

using System;
using System.Text;

namespace TPD.Communication.ClientServerCommunication.WebSocketAPI
{
  internal static class Extensions
  {
    internal static ArraySegment<byte> GetArraySegment(this string message)
    {
      byte[] buffer = Encoding.UTF8.GetBytes(message);
      return new ArraySegment<byte>(buffer);
    }
  }
}