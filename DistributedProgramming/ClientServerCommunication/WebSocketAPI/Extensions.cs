//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

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