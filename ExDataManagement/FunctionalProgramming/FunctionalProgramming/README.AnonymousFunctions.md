<!--
//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________
-->

# Anonymous Functions <!-- omit in toc -->

## Table of Content <!-- omit in toc -->

- [1. Introduction](#1-introduction)
- [2. Anonymous Method](#2-anonymous-method)
- [3. Lambda Expressions](#3-lambda-expressions)
- [4. Expression Tree](#4-expression-tree)
- [5. See also](#5-see-also)

## 1. Introduction

Delegates do not explicitly contribute to functional programming, although they cannot be omitted in the context of anonymous functions language constructs. They are also vital for implementing inter-layer communication. Considering both arguments it is clear that delegated must be investigated in detail as a part of the introduction describing selected language constructs implicitly contributing to functional programming.

Let's discuss anonymous functions, including

- anonymous methods
- lambda expressions
- expression tree

## 2. Anonymous Method

An example of an anonymous method is provided in this test method (`AnonymousMethodTest`). Let me remind you that an anonymous method is one of the kinds of anonymous functions. I don't know where the name anonymous function came from. I can only guess, but let's look at the definition of an anonymous method. We have a typical delegate variable declaration on the left side of this line. Alt-F12 will remind us that `CallBackTestDelegate` is simply a delegate type. This is a delegate variable to which we associate a value in the form of a reference to a set of methods. In the example the set contains only one member. The method belonging to this set is defined in the expression to the right of the equals sign. For such a definition, we have a list of parameters, and of course, we have a block, i.e. a sequence of instructions that will be executed when the method is called. Since we do not have a name assigned here, we call this type of definition anonymous. We cannot refer to it in any other way than through the delegation variable, but the delegation variable has a name, so it is not that we cannot refer to the anonymous definition. Of course, the difference between creating a delegation, as in this case, a delegation from a named method and a delegation from an unnamed method, is only that in this case we substitute a value into the variable and this means that we can change this value. But leaving these details aside, in the next line we see another alternative to defining references, similar to a reference to a variable, and therefore a delegation to a method, which is again defined here as anonymous, where we have a list of parameters and we have a block. I will skip the syntax details because they are known from lessons about the CSharp language.

Indeed, we can substitute this reference to the method as an actual argument of the formal argument for the method we have already discussed, it is defined within this object and is used to check the internal consistency of the object. And here, as before, we have an invariant that checks whether a variable in this case; we don't have to create an object, we have a variable that changes the value to `true`.

If we compare the definition of a named method - here we have just such a named method - with the definition of an unnamed method - here is such a definition - we can see that the difference is only syntactical. In subsequent programming language versions, further simplifications have been introduced allowing this definition to be shortened and written in a different text form. One difference is that an unnamed method has access to local variables defined in the method in which it has its definition. But this results from the place where it is defined.

Let's move on to the next incarnation of anonymous functions, namely the lambda expression. Here, in this test method, we have the same functionality as before, using the lambda expression. I would like to remind you that nothing has changed in this method, the delegation variable is still a formal parameter. Its argument is of delegation type, so it is a current parameter; so the current argument must be a reference to a method with a compatible signature. What is written in round brackets is simply a method, the same method as before; with the same functionality. Just using a different syntax again. Moreover, this syntax can be further simplified. You can drop a type specification here and have the compiler determine all possible types. To make it guess the types, for example, the type of passed argument. Of course, knowing the definition of this method, you can easily deduce from this delegation what type of formal argument must be. So, again, comparing the definition of an anonymous method with a lambda expression, we can conclude that the difference is only syntactic.

So firstly; we have a question and let's come back to this question; what does the term anonymous function mean? First of all, and secondly, why all this, why all these syntactic changes? Why do we need another syntax construct of the same functionality that we had here (`AnonymousMethodTest`)? Let's go back to this entry to answer the question of what an anonymous function is. Well, we see that the right side resembles the function notation. If we understand the word `delegate` as the name of the function, then the delegate function returns references to the method that is defined on the right side. Basic question; what's the point of all this?

Usually, the function expressed in terms of selected language syntax must be translated to be useful and executable by the external system. To make the translation feasible the function must be syntactically embedded in an expression - a sequence of operators and operands. Before translation, it must be expressed using the object model in the form of an expression tree. The expression tree can be created by the compiler or grammatically using the API.

The compiler can generate expression trees only from expression lambdas (or single-line lambdas). It cannot parse statement lambdas (or multi-line lambdas).

To create expression trees by using the API, use the [Expression Class \(System.Linq.Expressions.Expression\)][ExpressionClass]. This class contains static factory methods that create expression tree nodes of specific types.

## 3. Lambda Expressions

A lambda expression with an expression on the right side of the `=>` operator is called an expression lambda. Expression lambdas are used extensively in the construction of [Expression Trees][ET]. An expression lambda returns the result of the expression and takes the following basic form:

``` CSharp
(input-parameters) => expression
```

Sometimes it is difficult or impossible for the compiler to infer the types of input arguments. When this occurs, you can specify the types explicitly as shown in the following example:

``` CSharp
(int x, string s) => s.Length > x
```

## 4. Expression Tree

We can observe a real change in the following code snippet located in the [DelegateVsExpressionTest][DelegateVsExpressionTest] test class, where we again have a lambda expression on the right side.

``` CSHarp
      Expression<Func<int, bool>> lambda = (int num) => num < 5;
```

On the left, we have the definition of the `lambda` variable, but this time this variable is not a delegate variable as before. This variable is of type [ExpressionExpression<Func<int, bool>>][ExpressionClass]. It is expected that after executing the expression, will be assigned a reference to an object of this class.

But according to the entry, on the right side we should create a delegation, i.e. references to the method written this time as a lambda expression. The delegation type is not compatible with this reference type for class [Expression][ExpressionClass]. This is where the fundamental difference has been encountered because in this case, we do not create a delegate value, that is, we do not create a method reference. The compiler translates this expression instead of executing it, causing that this expression will be represented by an object of type [Expression][ExpressionClass].

So instead of executing the expression, the compiler represents it in object form. It is possible only when the syntax of this expression is appropriately simplified. Let's look at the example below! Well, when we change the lambda expression to a slightly more complicated one, but still correct, equivalent, and consistent with the lambda expression syntax, the compiler is incapable of solving this translation. For example, I copied a code snippet from the code above. It contains an equivalent lambda expression that was not complained by the compiler.

![DelegateVsExpressionTest](../.Media/DelegateVsExpressionTest.gif)

This is important because object representation of an expression using the [Expression][ExpressionClass] type allows the creation of something called an expression tree. Next, such an expression tree can be translated into another domain-specific language of an external system, for example, SQL. Thus, the resulting SQL query, after translating the expression, can be sent to an external database management system for execution outside the program hosting process.

This is important because object representation of an expression using the [Expression][ExpressionClass] type allows the creation of something called an expression tree. Next, such an expression tree can be translated into another domain-specific language of an external system, for example, SQL. Thus, the resulting SQL query, after translating the expression, can be sent to an external database management system for execution outside the program hosting process.

> **Note**: If you are creating expression trees that are executed outside of the .NET Framework, such as in SQL Server, you should not use method calls in lambda expressions. The methods will have no meaning outside the context of the .NET common language runtime. For example:

``` CSharp
() => SomeMethod()
```

## 5. See also

- [Anonymous Functions (Programming Guide)](https://docs.microsoft.com/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-functions)
- [Expression Trees][ET]
- [Expression Class][ExpressionClass]
- [Extension Methods](https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)

[DelegateVsExpressionTest]: ../FunctionalProgramming.UnitTest/AnonymousFunctionsUnitTest.cs#L20-L109
[ExpressionClass]:https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression
[ET]:https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/expression-trees/index
