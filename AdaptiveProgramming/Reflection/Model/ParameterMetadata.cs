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

namespace TPA.Reflection.Model
{
  internal class ParameterMetadata
  {
    public ParameterMetadata(string name, TypeMetadata typeMetadata)
    {
      this.m_Name = name;
      this.m_TypeMetadata = typeMetadata;
    }

    //private vars
    internal string m_Name;

    internal TypeMetadata m_TypeMetadata;
  }
}