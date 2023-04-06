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

using System.IO;

namespace TPA.Reflection.Compilation
{
  /// <summary>
  /// Complier that perform compilation of any cs class from stream or string
  /// </summary>
  public class CSharpStreamCompiller : CodeBuilderBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CSharpStreamCompiller"/> class.
    /// </summary>
    /// <param name="streamSource">The stream source of source code.</param>
    /// <param name="referencedAssemblies">The referenced assemblies list.</param>
    public CSharpStreamCompiller(Stream streamSource, string[] referencedAssemblies) : this(new StreamReader(streamSource).ReadToEnd(), referencedAssemblies) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CSharpStreamCompiller"/> class.
    /// </summary>
    /// <param name="stringSource">The source code in string.</param>
    /// <param name="referencedAssemblies">The referenced assemblies list.</param>
    public CSharpStreamCompiller(string stringSource, string[] referencedAssemblies)
    {
      string source = stringSource;
      Source.Append(source);
      ReferencedAsseblies.AddRange(referencedAssemblies);
      PerformCompilation();
    }
  }
}