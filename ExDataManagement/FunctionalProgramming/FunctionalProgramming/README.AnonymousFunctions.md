<!--
//___________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//____________________________________________________________________________________________________________________________
-->

# Anonymous Functions

## Introduction

Delegates do not explicitly contribute to functional programming, although they cannot be omitted in the context of anonymous functions language constructs. They are also vital for implementing inter-layer communication. Considering both arguments it is clear that delegated must be investigated in detail as a part of the introduction describing selected language constructs implicitly contributing to anonymous function. I don't know where the name anonymous function came from. I can only guess, but let's look at the definition of an anonymous method.

Let's discuss anonymous functions, including

- anonymous methods
- lambda expressions
- expression tree

## Anonymous Method

The following example of an anonymous method is located in the [AnonymousMethodCallBackTest][AnonymousMethodCallBackTest] test method.

``` CSharp
AnonymousFunctions.CallBackTestDelegate _CallBackTestResult = delegate (bool _result) { _testResult = _result; };

```

Let me remind you that an anonymous method is one of the kinds of anonymous functions. We have a typical delegate variable declaration on the left side of the following line. Alt-F12 will remind us that [CallBackTestDelegate][CallBackTestDelegate] is simply a delegate type as follows:

``` CSharp
  internal delegate void CallBackTestDelegate(bool testResult);
```

This is a delegate variable to which we assign a value in the form of a reference to a set of methods. In the above example the set contains only one member.

The method belonging to this set is defined in the expression to the right of the equals sign as follows:

``` CSharp
   delegate (bool _result) { _testResult = _result; }
```

For such a definition, we have a list of parameters, and of course, we have a block, i.e. a sequence of instructions that will be executed when the method is called. Since we do not have a name assigned here, we call this type of definition anonymous. We cannot refer to it in any other way than through the delegate variable, but the delegate variable has a name, so it is not that we cannot refer to the anonymous definition. Of course, the difference between creating a delegate, as in this case, a delegate from a named method and a delegate from an unnamed method, is only that in this case we assign a value into the variable and this means that we can change this value.

## Lambda Expressions

A lambda expression with an expression on the right side of the `=>` operator that is called an expression lambda. An expression lambda has the following syntax form:

``` CSharp
(input-parameters) => expression
```

Sometimes it is difficult or impossible for the compiler to infer the types of input arguments. When this occurs, you can specify the types explicitly as shown in the following example:

``` CSharp
(int x, string s) => s.Length > x
```

But leaving these details aside, in the [LambdaExpressionCallBackTest][LambdaExpressionCallBackTest] method we see an example defining methods references (delegates), similar to a reference to a variable. Again it is defined here as anonymous, where we have a list of parameters and we have a block. I will skip the syntax details because they are known from lessons about the CSharp language.

``` CSharp
      AnonymousFunctions.CallBackTestDelegate _CallBackTestResult = _result => _testResult = _result;
      _newInstance.ConsistencyCheck(_CallBackTestResult);
```

Indeed, we can assign this reference to a method as an actual argument of the formal argument for the method [ConsistencyCheck][ConsistencyCheck]. It is defined within the [AnonymousFunctions][AnonymousFunctions] class and is used to check the internal consistency of it instance. And here, we have an assertion that checks whether a local variable changes the value to `true` It means that the delegate has been invoked as a result of calling the [ConsistencyCheck][ConsistencyCheck] method.

If we compare the definition of a named method - here we have just such a named method - with the definition of an unnamed method - here is such a definition - we can see that the difference is only syntactical. In subsequent programming language versions, further simplifications have been introduced allowing this definition to be shortened and written in a different text form. One difference is that an unnamed method has access to local variables defined in the method in which it has its definition. But this results from the place where it is defined.

Let's move on to the next incarnation of anonymous functions, namely the lambda expression. Here, in this test method, we have the same functionality as before, using the lambda expression. I would like to remind you that nothing has changed in this method. The delegate variable is still a formal parameter. Hence, the current argument must be a reference to a method with a compatible signature. What is written in round brackets is simply a method, the same method as before; with the same functionality. Just using a different syntax again. Moreover, this syntax can be further simplified. You can drop a type specification here and have the compiler determine all possible types. To make it infer the types, for example, the type of passed argument. Of course, knowing the definition of this method, you can easily deduce from this delegate what type of formal argument must be. So, again, comparing the definition of an anonymous method with a lambda expression, we can conclude that only syntax is different.

## Expression Tree

Expression lambdas are used extensively in the construction of [Expression Trees][ET]. Expression lambdas are a part of anonymous function concept. As an introduction let's come back to the question of what does the term anonymous function mean? There is another outstanding question of what is a reason of all these syntax changes that ira encountered in context of anonymous function? Why do we need another syntax construct of the same functionality that we had in the ([AnonymousMethodCallBackTest][AnonymousMethodCallBackTest]) method? Let's go back again to this entry while answering the question of what an anonymous function is.

``` CSharp
AnonymousFunctions.CallBackTestDelegate _CallBackTestResult = delegate (bool _result) { _testResult = _result; };
```

If we interpret the word `delegate` as the name of the function the right side resembles the function notation. In other words, the delegate keyword is used to return reference to a method that is defined as the right side parameter of this keyword.

But basic question is still unanswered. What's the point of all this? Usually, a functionality expressed in terms of selected programming language syntax must be translated to a domain-specific language to be useful and executable by the external system. To make the translation feasible this functionality must be syntactically embedded in an expression - a sequence of operators and operands. Before translation, it must be expressed using the object model in the form of an expression tree. The expression tree can be created by the compiler.

Unfortunately, the compiler can generate expression trees only from expression lambdas (or single-line lambdas rather). It cannot parse statement lambdas (or multi-line lambdas).

To create expression trees by using the API, use the [Expression Class \(System.Linq.Expressions.Expression\)][ExpressionClass]. This class contains static factory methods that create expression tree nodes of specific types.

We can observe a real change in the following code snippet located in the [DelegateVsExpressionTest][DelegateVsExpressionTest] test class, where we again have a lambda expression on the right side.

``` CSHarp
      Expression<Func<int, bool>> lambda = (int num) => num < 5;
```

On the left, we have the definition of the `lambda` variable, but this time this variable is not a delegate variable as before. This variable is of type [ExpressionExpression<Func<int, bool>>][ExpressionClass]. It is expected that after executing the expression a compatible value will be assigned to this variable. It should be a reference to an instance of the [ExpressionExpression<Func<int, bool>>][ExpressionClass] class.

But according to the entry, on the right side we should create a delegate value, i.e. references to the method written this time as a lambda expression. The delegate type is not compatible with this reference type for the [Expression][ExpressionClass]. It the place where the fundamental difference has been encountered because in this case, we do not create a delegate value, that is, we do not create reference to a method. The compiler translates this expression instead of executing it, causing that this expression will be represented by an object of type [Expression][ExpressionClass] and reference to it is assigned to the `lambda` variable.

So instead of executing the expression, the compiler translates it and represents in an object form. It is possible only when the syntax of this expression is appropriately simplified. Let's look at the example below! Well, when we change the lambda expression to a slightly more complicated one, but still correct, equivalent, and consistent with the lambda expression syntax, the compiler is incapable of solving this translation. For example, I copied a code snippet from the code above. It contains an equivalent lambda expression that was not complained by the compiler a few lines above.

![DelegateVsExpressionTest](../.Media/DelegateVsExpressionTest.gif)

This is important because object representation of an expression using the [Expression][ExpressionClass] type allows creation of something that is called an expression tree. Next, such an expression tree can be translated into another domain-specific language of an external system, for example, SQL. Thus, the resulting SQL query, after translating the expression, can be sent to an external database management system for execution outside the process hosting the program.

> **Note**: If you are creating expression trees that are executed outside of the .NET Framework, such as in SQL Server, you should not use method calls in lambda expressions. The methods will have no meaning outside the context of the .NET common language runtime. For example:

``` CSharp
() => SomeMethod()
```

To make the translation possible all side effects must be omitted because the expression is to be executed in the context of external data source but not in a context of program and especially in the context of an instance of reference type. By design this requirement is well suited to be addressed by the functional programming style.

## See also


- [Anonymous Functions (Programming Guide)](https://docs.microsoft.com/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-functions)
- [Expression Trees][ET]
- [Expression Class][ExpressionClass]
- [Extension Methods](https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)

[AnonymousFunctions]: AnonymousFunctions.cs#L31-L137
[ConsistencyCheck]: AnonymousFunctions.cs#L38-L41
[CallBackTestDelegate]: AnonymousFunctions.cs#L35C5-L35C66

[AnonymousMethodCallBackTest]: ../FunctionalProgramming.UnitTest/AnonymousFunctionsUnitTest.cs#L34-L42
[LambdaExpressionCallBackTest]: ../FunctionalProgramming.UnitTest/AnonymousFunctionsUnitTest.cs#L45-L52
[DelegateVsExpressionTest]: ../FunctionalProgramming.UnitTest/AnonymousFunctionsUnitTest.cs#L20-L109

[ExpressionClass]:https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression
[ET]:https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/expression-trees/index
