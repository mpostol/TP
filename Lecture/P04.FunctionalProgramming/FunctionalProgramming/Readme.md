<!--
//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________
-->
# Functional Programming

## Functional Programming Basis

Functional programming is a style of developing the computer programs that treats computation as the evaluation of mathematical functions and avoids changing-state and mutable data. A mutable data is an object whose state can be modified after it is created. An immutable object is an object whose state cannot be modified after it is created.

The most important behavior of a function in the context of functional programming paradigm is that its output value depends only on the actual parameter values that are passed to while calling it. In other words, the function behavior doesn't depend on the local or global state. So calling a function f twice with the same value for a parameter x produces the same result f(x) each time. An example of the function conforming to this paradigm is for example:

```
    public static bool StringIsLongPredicate(string stringToTest)
    {
      return stringToTest.Length > 10;
    }
```
This predicate returns always `true` if the current string assigned to `stringToTest` is longer than 10.

It represents the method that defines a set of criteria and determines whether the specified object meets those criteria.

It eliminates side effects, which is one of the key motivations for using the functional programming approach to manage external data. In this scenario, the function can be sent and executed by a data management system and produce a set of related data.

Usually, the function expressed in terms of selected language syntax must be translated to be useful and executable by the external system. To make the translation feasible the function must be syntactically embedded in an expression - a sequence of operators and operands. Before translation, it must be expressed using the object model in the form of an expression tree. The expression tree can be created by the compiler or grammatically using the API. 

The C# compiler can generate expression trees only from expression lambdas (or single-line lambdas). It cannot parse statement lambdas (or multi-line lambdas).

To create expression trees by using the API, use the [Expression Class \(System.Linq.Expressions.Expression\)][ExpressionClass]. This class contains static factory methods that create expression tree nodes of specific types.

## Anonymous Functions 

### Lambda Expressions

A lambda expression with an expression on the right side of the `=>` operator is called an expression lambda. Expression lambdas are used extensively in the construction of [Expression Trees][ET]. An expression lambda returns the result of the expression and takes the following basic form:
```
(input-parameters) => expression
```

Sometimes it is difficult or impossible for the compiler to infer the input types. When this occurs, you can specify the types explicitly as shown in the following example:

```
(int x, string s) => s.Length > x
```

> If you are creating expression trees that are executed outside of the .NET Framework, such as in SQL Server, you should not use method calls in lambda expressions. The methods will have no meaning outside the context of the .NET common language runtime. For example:

```
() => SomeMethod()
```

### Anonymous Method


## Extension Methods

### Introduction

C# simulates existence of an instance method for a selected type via extension methods. To do this, the signature of the static method must have `this` keyword as the prefix of the the first parameter. In other words, extension methods are a kind of static method, that can be called as if they were instance methods of the first parameter type.

### Content

The class `ExtensionMethods` provides a few examples of extension methods.

The UT located in the class `TP.Lecture.UnitTest.ExtensionMethodsUnitTest` has test methods illustrating how to use the extension methods and points out differences between usage the instance and extension methods against the instance methods.

# See also

- [Anonymous Functions (C# Programming Guide)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-functions)
- [Expression Trees (C#)][ET]
- [Expression Class \(System.Linq.Expressions.Expression\)][ExpressionClass] 
- [Extension Methods \(C# Programming Guide\) on MSDN](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)

[ExpressionClass]:https://docs.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression
[ET]:https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/expression-trees/index