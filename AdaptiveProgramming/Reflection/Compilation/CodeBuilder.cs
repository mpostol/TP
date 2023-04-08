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
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;

namespace TPA.Reflection.Compilation
{
  /// <summary>
  /// Code Builder using CodeDom
  /// </summary>
  public class CodeBuilder : CodeBuilderBase
  {
    #region private

    /// <summary>
    /// Main driving routine for building a class
    /// </summary>
    private void BuildClass(string expression)
    {
      StringWriter sw = new StringWriter(Source);
      //Declare your provider and generator
      CSharpCodeProvider codeProvider = new CSharpCodeProvider();
      ICodeGenerator generator = codeProvider.CreateGenerator(sw);
      CodeGeneratorOptions codeOpts = new CodeGeneratorOptions();

      CodeNamespace myNamespace = new CodeNamespace("ExpressionEvaluator");
      myNamespace.Imports.Add(new CodeNamespaceImport("System"));
      myNamespace.Imports.Add(new CodeNamespaceImport("System.Windows.Forms"));
      //Build the class declaration and member variables
      CodeTypeDeclaration classDeclaration = new CodeTypeDeclaration
      {
        IsClass = true,
        Name = "Calculator",
        Attributes = MemberAttributes.Public
      };
      classDeclaration.Members.Add(FieldVariable("answer", typeof(double), MemberAttributes.Private));
      //default constructor
      CodeConstructor defaultConstructor = new CodeConstructor
      {
        Attributes = MemberAttributes.Public
      };
      defaultConstructor.Comments.Add(new CodeCommentStatement("Default Constructor for class", true));
      defaultConstructor.Statements.Add(new CodeSnippetStatement("//TODO: implement default constructor"));
      classDeclaration.Members.Add(defaultConstructor);
      //property
      classDeclaration.Members.Add(MakeProperty("Answer", "answer", typeof(double)));
      //Our Calculate Method
      CodeMemberMethod myMethod = new CodeMemberMethod
      {
        Name = "Calculate",
        ReturnType = new CodeTypeReference(typeof(double))
      };
      myMethod.Comments.Add(new CodeCommentStatement("Calculate an expression", true));
      myMethod.Attributes = MemberAttributes.Public;
      myMethod.Statements.Add(new CodeAssignStatement(new CodeSnippetExpression("Answer"), new CodeSnippetExpression(expression)));
      //myMethod.Statements.Add(new CodeSnippetExpression("MessageBox.Show(String.Format(\"Answer = {0}\", Answer))"));
      myMethod.Statements.Add(
          new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "Answer")));
      classDeclaration.Members.Add(myMethod);
      //write code
      myNamespace.Types.Add(classDeclaration);
      generator.GenerateCodeFromNamespace(myNamespace, sw, codeOpts);
      sw.Flush();
      sw.Close();
    }

    private CodeMemberField FieldVariable(string fieldName, string typeName, MemberAttributes accessLevel)
    {
      CodeMemberField field = new CodeMemberField(typeName, fieldName)
      {
        Attributes = accessLevel
      };
      return field;
    }

    private CodeMemberField FieldVariable(string fieldName, Type type, MemberAttributes accessLevel)
    {
      CodeMemberField field = new CodeMemberField(type, fieldName)
      {
        Attributes = accessLevel
      };
      return field;
    }

    /// <summary>
    /// Very simplistic getter/setter properties
    /// </summary>
    /// <param name="propertyName">Name of the property.</param>
    /// <param name="internalName">Name of the internal.</param>
    /// <param name="type">The type.</param>
    /// <returns></returns>
    private CodeMemberProperty MakeProperty(string propertyName, string internalName, Type type)
    {
      CodeMemberProperty _Property = new CodeMemberProperty
      {
        Name = propertyName
      };
      _Property.Comments.Add(new CodeCommentStatement(string.Format("The {0} property is the returned result", propertyName)));
      _Property.Attributes = MemberAttributes.Public;
      _Property.Type = new CodeTypeReference(type);
      _Property.HasGet = true;
      _Property.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), internalName))); _Property.HasSet = true;
      _Property.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), internalName), new CodePropertySetValueReferenceExpression()));
      return _Property;
    }

    /// <summary>
    /// Runs the Calculate method in our on-the-fly assembly
    /// </summary>
    /// <param name="results"></param>
    private void RunCode(CompilerResults results)
    {
      Assembly executingAssembly = results.CompiledAssembly;
      try
      {
        //cant call the entry method if the assembly is null
        if (executingAssembly != null)
        {
          object assemblyInstance = executingAssembly.CreateInstance("ExpressionEvaluator.Calculator");
          //Use reflection to call the static Main function
          Module[] modules = executingAssembly.GetModules(false);
          Type[] types = modules[0].GetTypes();
          //loop through each class that was defined and look for the first occurrance of the entry point method
          foreach (Type type in types)
          {
            MethodInfo[] mis = type.GetMethods();
            foreach (MethodInfo mi in mis)
            {
              if (mi.Name == "Calculate")
              {
                object result = mi.Invoke(assemblyInstance, null);
                OutputTextFromLastRun = result.ToString();
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("An exception occurred while executing the script: {0}", ex.Message);
      }
    }

    #endregion private

    #region public

    /// <summary>
    /// Initializes a new instance of the <see cref="CodeBuilder"/> class.
    /// </summary>
    /// <param name="expression">The expression to be calculated.</param>
    public CodeBuilder(string expression)
    {
      // build the class using CodeDom
      BuildClass(expression);
      PerformCompilation();
    }

    /// <summary>
    /// Gets the output text from last run.
    /// </summary>
    /// <value>The output text from last run.</value>
    public string OutputTextFromLastRun { get; private set; } = "";

    /// <summary>
    /// Runs the code.
    /// </summary>
    public void RunCode()
    {
      // if the code compiled okay, run the code using the new assembly (which is inside the results)
      if (Results != null && Results.CompiledAssembly != null)
        RunCode(Results); // run the evaluation function
      else
      {
        throw new Exception("Cannot Run The Code:" + SourceCode + "\r\n error:" + ErrorText);
      }
    }

    #endregion public
  }
}