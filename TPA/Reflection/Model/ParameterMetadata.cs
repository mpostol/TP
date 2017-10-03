//Copyright (C) Microsoft Corporation.  All rights reserved.

namespace TPA.Reflection.Model
{
  internal class ParameterMetadata
  {
    private string name;
    private TypeMetadata typeMetadata;

    public ParameterMetadata(string name, TypeMetadata typeMetadata)
    {
      this.name = name;
      this.typeMetadata = typeMetadata;
    }
  }
}