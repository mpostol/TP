//____________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System.IO;

namespace TPA.Reflection.Compilation
{
  /// <summary>
  /// Compliler that perform compilation of any cs class from stream or string
  /// </summary>
  public class CSharpStreamCompiller : CodeBuilderBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CSharpStreamCompiller"/> class.
    /// </summary>
    /// <param name="streamSource">The stream source of source code.</param>
    /// <param name="referencedAssemblies">The referenced assemblies list.</param>
    public CSharpStreamCompiller(Stream streamSource, string[] referencedAssemblies) :
      this(new StreamReader(streamSource).ReadToEnd(), referencedAssemblies)
    {
    }
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
