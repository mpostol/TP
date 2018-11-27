//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;

namespace TPA.Reflection.DynamicType
{
  public enum StringSearchOption { Contains, StartsWith, EndsWith }

  public class ReadOnlyFile : DynamicObject
  {

    public ReadOnlyFile(string filePath)
    {
      if (!File.Exists(filePath))
        throw new FileLoadException("File path does not exist.");
      p_filePath = filePath;
    }
    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
      result = GetPropertyValue(binder.Name);
      return result == null ? false : true;
    }
    public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
    {
      StringSearchOption _stringSearchOption = StringSearchOption.StartsWith;
      bool trimSpaces = true;
      try
      {
        if (args.Length > 0)
          _stringSearchOption = (StringSearchOption)args[0];
      }
      catch
      {
        throw new ArgumentException("StringSearchOption argument must be a StringSearchOption enum value.");
      }
      try
      {
        if (args.Length > 1)
          trimSpaces = (bool)args[1];
      }
      catch
      {
        throw new ArgumentException("trimSpaces argument must be a Boolean value.");
      }
      result = GetPropertyValue(binder.Name, _stringSearchOption, trimSpaces);
      return result == null ? false : true;
    }

    private string p_filePath;
    private IEnumerable<string> GetPropertyValue(string propertyName, StringSearchOption StringSearchOption = StringSearchOption.StartsWith, bool trimSpaces = true)
    {
      StreamReader _sr = null;
      List<string> _results = new List<string>();
      string _line = "";
      string _testLine = "";
      try
      {
        _sr = new StreamReader(p_filePath);
        while (!_sr.EndOfStream)
        {
          _line = _sr.ReadLine();
          _testLine = _line.ToUpper();
          if (trimSpaces)
            _testLine = _testLine.Trim();
          switch (StringSearchOption)
          {
            case StringSearchOption.StartsWith:
              if (_testLine.StartsWith(propertyName.ToUpper())) { _results.Add(_line); }
              break;
            case StringSearchOption.Contains:
              if (_testLine.Contains(propertyName.ToUpper())) { _results.Add(_line); }
              break;
            case StringSearchOption.EndsWith:
              if (_testLine.EndsWith(propertyName.ToUpper())) { _results.Add(_line); }
              break;
          }
        }
      }
      catch
      {
        _results = null;
      }
      finally
      {
        if (_sr != null)
          _sr.Close();
      }
      return _results;
    }

  }
}
