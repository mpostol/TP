//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

namespace TP.InformationComputation.CustomTypes
{
  public struct Roman
  {
    #region operators

    // Operations set
    public static implicit operator int(Roman value)
    {
      return value.m_value;
    }

    public static implicit operator Roman(string value)
    {
      Roman _roman;
      _roman.m_value = RomanToInteger(value);
      return _roman;
    }

    public static implicit operator Roman(int value)
    {
      Roman _roman;
      _roman.m_value = value;
      return _roman;
    }

    public static Roman operator *(Roman value1, Roman value2)
    {
      return value1.m_value * value2.m_value;
    }

    #endregion operations

    #region Object override

    public override string ToString()
    {
      return m_value.ToString();
    }

    #endregion Object override

    #region private

    private int m_value; //holder of value - the place where the number is kept - allowed values set is determined by int

    private static int RomanToInteger(string roman)
    {
      int number = 0;
      for (int i = 0; i < roman.Length; i++)
        if (i + 1 < roman.Length && RomanMap[roman[i]] < RomanMap[roman[i + 1]])
          number -= RomanMap[roman[i]];
        else
          number += RomanMap[roman[i]];
      return number;
    }

    private static readonly Dictionary<char, int> RomanMap = new Dictionary<char, int>()
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000}
    };

    #endregion private
  }
}