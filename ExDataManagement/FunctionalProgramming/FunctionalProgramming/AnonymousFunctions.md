# Anonymous Functions

<!--
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
-->

# Anonymous Functions

## Lambda Expressions

A lambda expression with an expression on the right side of the `=>` operator is called an expression lambda. Expression lambdas are used extensively in the construction of [Expression Trees][ET]. An expression lambda returns the result of the expression and takes the following basic form:

```C#
(input-parameters) => expression
```

Sometimes it is difficult or impossible for the compiler to infer the input types. When this occurs, you can specify the types explicitly as shown in the following example:

```C#
(int x, string s) => s.Length > x
```

> If you are creating expression trees that are executed outside of the .NET Framework, such as in SQL Server, you should not use method calls in lambda expressions. The methods will have no meaning outside the context of the .NET common language runtime. For example:

```C#
() => SomeMethod()
```

<!-- ### Anonymous Method

TBD -->

## See also

- [Anonymous Functions (C# Programming Guide)](https://docs.microsoft.com/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-functions)
- [Expression Trees (C#)][ET]
- [Expression Class \(System.Linq.Expressions.Expression\)][ExpressionClass]
- [Extension Methods (C# Programming Guide) on MSDN](https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)

[ExpressionClass]:https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression
[ET]:https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/expression-trees/index