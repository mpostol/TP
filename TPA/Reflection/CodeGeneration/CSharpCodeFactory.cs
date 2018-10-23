//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;

namespace TPA.Reflection.CodeGeneration
{

  /// <summary>
  /// This code example creates a graph using a CodeCompileUnit and generates source code for the graph using the CSharpCodeProvider.
  /// </summary>
  public class CSharpCodeFactory
  {
    /// <summary>
    /// Define the class.
    /// </summary>
    public CSharpCodeFactory()
    {
      m_TargetUnit = new CodeCompileUnit();
      CodeNamespace _samples = new CodeNamespace("CodeDOMSample");
      _samples.Imports.Add(new CodeNamespaceImport("System"));
      m_TargetClass = new CodeTypeDeclaration("CodeDOMCreatedClass")
      {
        IsClass = true,
        TypeAttributes = TypeAttributes.Public | TypeAttributes.Sealed
      };
      _samples.Types.Add(m_TargetClass);
      m_TargetUnit.Namespaces.Add(_samples);
    }
    /// <summary>
    /// Adds two fields to the class.
    /// </summary>
    public void AddFields()
    {
      // Declare the widthValue field.
      CodeMemberField _widthValueField = new CodeMemberField
      {
        Attributes = MemberAttributes.Private,
        Name = "widthValue",
        Type = new CodeTypeReference(typeof(double))
      };
      _widthValueField.Comments.Add(new CodeCommentStatement("The width of the object."));
      m_TargetClass.Members.Add(_widthValueField);
      // Declare the heightValue field
      CodeMemberField _heightValueField = new CodeMemberField
      {
        Attributes = MemberAttributes.Private,
        Name = "heightValue",
        Type = new CodeTypeReference(typeof(double))
      };
      _heightValueField.Comments.Add(new CodeCommentStatement("The height of the object."));
      m_TargetClass.Members.Add(_heightValueField);
    }
    /// <summary>
    /// Add three properties to the class.
    /// </summary>
    public void AddProperties()
    {
      // Declare the read-only Width property.
      CodeMemberProperty _widthProperty = new CodeMemberProperty
      {
        Attributes = MemberAttributes.Public | MemberAttributes.Final,
        Name = "Width",
        HasGet = true,
        Type = new CodeTypeReference(typeof(double))
      };
      _widthProperty.Comments.Add(new CodeCommentStatement("The Width property for the object."));
      _widthProperty.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "widthValue")));
      m_TargetClass.Members.Add(_widthProperty);
      // Declare the read-only Height property.
      CodeMemberProperty _heightProperty = new CodeMemberProperty
      {
        Attributes = MemberAttributes.Public | MemberAttributes.Final,
        Name = "Height",
        HasGet = true,
        Type = new CodeTypeReference(typeof(double))
      };
      _heightProperty.Comments.Add(new CodeCommentStatement("The Height property for the object."));
      _heightProperty.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "heightValue")));
      m_TargetClass.Members.Add(_heightProperty);
      // Declare the read only Area property.
      //public double Area
      CodeMemberProperty _areaProperty = new CodeMemberProperty
      {
        Attributes = MemberAttributes.Public | MemberAttributes.Final,
        Name = "Area",
        HasGet = true,
        Type = new CodeTypeReference(typeof(double))
      };
      _areaProperty.Comments.Add(new CodeCommentStatement("The Area property for the object."));
      // Create an expression to calculate the area for the get accessor of the Area property.
      //get {return (this.widthValue * this.heightValue); }
      CodeBinaryOperatorExpression _areaExpression =
          new CodeBinaryOperatorExpression(
          new CodeFieldReferenceExpression(
          new CodeThisReferenceExpression(), "widthValue"),
          CodeBinaryOperatorType.Multiply,
          new CodeFieldReferenceExpression(
          new CodeThisReferenceExpression(), "heightValue"));
      _areaProperty.GetStatements.Add(new CodeMethodReturnStatement(_areaExpression));
      m_TargetClass.Members.Add(_areaProperty);
    }
    /// <summary>
    /// Adds a method to the class. This method multiplies values stored in both fields.
    /// </summary>
    public void AddMethod()
    {
      // Declaring a ToString method
      CodeMemberMethod _toStringMethod = new CodeMemberMethod
      {
        Attributes = MemberAttributes.Public | MemberAttributes.Override,
        Name = "ToString",
        ReturnType = new CodeTypeReference(typeof(string))
      };
      CodeFieldReferenceExpression widthReference = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "Width");
      CodeFieldReferenceExpression heightReference = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "Height");
      CodeFieldReferenceExpression areaReference = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "Area");
      // Declaring a return statement for method ToString.
      CodeMethodReturnStatement returnStatement = new CodeMethodReturnStatement();
      // This statement returns a string representation of the width, height, and area.
      string _formattedOutput = "The object:" + Environment.NewLine +
          " width = {0}," + Environment.NewLine +
          " height = {1}," + Environment.NewLine +
          " area = {2}";
      returnStatement.Expression = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("System.String"), "Format", new CodePrimitiveExpression(_formattedOutput), widthReference, heightReference, areaReference);
      _toStringMethod.Statements.Add(returnStatement);
      m_TargetClass.Members.Add(_toStringMethod);
    }
    /// <summary>
    /// Add a constructor to the class.
    /// </summary>
    public void AddConstructor()
    {
      // Declare the constructor
      CodeConstructor _constructor = new CodeConstructor
      {
        Attributes = MemberAttributes.Public | MemberAttributes.Final
      };
      // Add parameters.
      _constructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof(double), "width"));
      _constructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof(double), "height"));
      // Add field initialization logic
      CodeFieldReferenceExpression widthReference = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "widthValue");
      _constructor.Statements.Add(new CodeAssignStatement(widthReference, new CodeArgumentReferenceExpression("width")));
      CodeFieldReferenceExpression heightReference = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "heightValue");
      _constructor.Statements.Add(new CodeAssignStatement(heightReference, new CodeArgumentReferenceExpression("height")));
      m_TargetClass.Members.Add(_constructor);
    }
    /// <summary>
    /// Add an entry point to the class.
    /// <code>
    /// public static void Main()
    /// {
    ///    CodeDOMCreatedClass testClass = new CodeDOMCreatedClass(5.3, 6.9);
    ///    System.Console.WriteLine(testClass.ToString());
    /// }
    /// </code>
    /// </summary>
    public void AddEntryPoint()
    {
      CodeEntryPointMethod start = new CodeEntryPointMethod();
      CodeObjectCreateExpression objectCreate =
          new CodeObjectCreateExpression(
          new CodeTypeReference("CodeDOMCreatedClass"),
          new CodePrimitiveExpression(5.3),
          new CodePrimitiveExpression(6.9));
      // Add the statement:
      // "CodeDOMCreatedClass testClass = new CodeDOMCreatedClass(5.3, 6.9);"
      start.Statements.Add(new CodeVariableDeclarationStatement(new CodeTypeReference("CodeDOMCreatedClass"), "testClass", objectCreate));
      // Create the expression:
      // "testClass.ToString()"
      CodeMethodInvokeExpression toStringInvoke = new CodeMethodInvokeExpression(new CodeVariableReferenceExpression("testClass"), "ToString");
      // Add a System.Console.WriteLine statement with the previous expression as a parameter.
      start.Statements.Add(new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("System.Console"), "WriteLine", toStringInvoke));
      m_TargetClass.Members.Add(start);
    }
    /// <summary>
    /// Generate CSharp source code from the compile unit.
    /// </summary>
    /// <param name="filename">Output file name</param>
    public void GenerateCSharpCode(string fileName)
    {
      CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
      CodeGeneratorOptions options = new CodeGeneratorOptions
      {
        BracingStyle = "C"
      };
      using (StreamWriter sourceWriter = new StreamWriter(fileName))
        provider.GenerateCodeFromCompileUnit(m_TargetUnit, sourceWriter, options);
    }

    #region private
    /// <summary>
    /// Define the compile unit to use for code generation. 
    /// </summary>
    private CodeCompileUnit m_TargetUnit;
    /// <summary>
    /// The only class in the compile unit. This class contains 2 fields,
    /// 3 properties, a constructor, an entry point, and 1 simple method. 
    /// </summary>
    private CodeTypeDeclaration m_TargetClass;
    #endregion

  }
}

