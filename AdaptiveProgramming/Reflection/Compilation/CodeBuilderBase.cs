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

using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;

namespace TPA.Reflection.Compilation
{
  /// <summary>
  /// Base class for oder code builder classes
  /// </summary>
  public class CodeBuilderBase
  {
    /// <summary>
    /// Create parameters for compiling
    /// </summary>
    /// <returns></returns>
    private static CompilerParameters CreateCompilerParameters(StringCollection referencedAsseblies)
    {
      //add compiler parameters and assembly references
      CompilerParameters compilerParams = new CompilerParameters
      {
        CompilerOptions = "/target:library /optimize",
        GenerateExecutable = false,
        GenerateInMemory = true,
        IncludeDebugInformation = false
      };
      foreach (string ref_as in referencedAsseblies)
        compilerParams.ReferencedAssemblies.Add(ref_as);
      //below default references
      compilerParams.ReferencedAssemblies.Add("mscorlib.dll");
      compilerParams.ReferencedAssemblies.Add("System.dll");
      compilerParams.ReferencedAssemblies.Add("System.Windows.Forms.dll");
      //add any aditional references needed
      //            foreach (string refAssembly in code.References)
      //              compilerParams.ReferencedAssemblies.Add(refAssembly);
      return compilerParams;
    }

    /// <summary>
    /// Compiles the code from the code string
    /// </summary>
    /// <param name="compiler"></param>
    /// <param name="parms"></param>
    /// <param name="source"></param>
    /// <returns></returns>
    private CompilerResults CompileCode(CSharpCodeProvider compiler, CompilerParameters parms, string source)
    {
      //actually compile the code
      CompilerResults results = compiler.CompileAssemblyFromSource(parms, source);
      //Do we have any compiler errors?
      if (results.Errors.Count > 0)
      {
        foreach (CompilerError error in results.Errors)
          WriteLine("Compile Error:" + error.ErrorText);
        return null;
      }
      return results;
    }

    /// <summary>
    /// Writes the output to the text box on the win form
    /// </summary>
    /// <param name="txt"></param>
    /// <param name="args"></param>
    private void WriteLine(string txt, params object[] args)
    {
      ErrorText += string.Format(txt, args) + "\r\n";
    }

    /// <summary>
    /// Compiles the c# into an assembly if there are no syntax errors
    /// </summary>
    /// <returns></returns>
    private CompilerResults CompileAssembly()
    {
      // create a compiler
      CSharpCodeProvider compiler = new CSharpCodeProvider();
      // get all the compiler parameters
      CompilerParameters parms = CreateCompilerParameters(ReferencedAsseblies);
      // compile the code into an assembly
      CompilerResults _results = CompileCode(compiler, parms, Source.ToString());
      return _results;
    }

    /// <summary>
    /// Performs the compilation.
    /// </summary>
    protected void PerformCompilation()
    {
      // compile the class into an in-memory assembly.
      // if it doesn't compile, show errors in the window
      Results = CompileAssembly();
      if (Results != null && Results.CompiledAssembly != null)
      {
        IsReadyToUse = true;
      }
      else
      {
        IsReadyToUse = false;
      }
#if DEBUG
      Console.WriteLine("...........................\r\n");
      Console.WriteLine(Source.ToString());
#endif
    }

    /// <summary>
    /// Gets the compiled assembly.
    /// </summary>
    /// <value>The compiled assembly.</value>
    public Assembly CompiledAssembly()
    {
      // if the code compiled okay, run the code using the new assembly (which is inside the results)
      if (Results != null && Results.CompiledAssembly != null)
      {
        return Results.CompiledAssembly;
      }
      else
      {
        throw new ArgumentException("Cannot Run The Code:" + SourceCode + "\r\n error:" + ErrorText);
      }
    }

    /// <summary>
    /// Gets the error text from last compilation or run.
    /// </summary>
    /// <value>The error text from last compilation or run.</value>
    public string ErrorText { get; private set; } = "";

    /// <summary>
    /// Gets the source code string builder object.
    /// </summary>
    /// <value>The source.</value>
    public StringBuilder Source { get; } = new StringBuilder();

    /// <summary>
    /// Gets the results of compilation.
    /// </summary>
    /// <value>The results.</value>
    public CompilerResults Results { get; private set; }

    /// <summary>
    /// Gets a value indicating whether this instance is ready to use.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is ready to use; otherwise, <c>false</c>.
    /// </value>
    public bool IsReadyToUse { get; private set; } = false;

    /// <summary>
    /// Gets the referenced assemblies.
    /// </summary>
    /// <value>The referenced assemblies.</value>
    public StringCollection ReferencedAsseblies { get; } = new StringCollection();

    /// <summary>
    /// Gets the source code.
    /// </summary>
    /// <value>The source code.</value>
    public string SourceCode => Source.ToString();
  }
}