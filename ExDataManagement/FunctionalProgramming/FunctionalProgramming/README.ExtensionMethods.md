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
# Extension Methods <!-- omit in toc -->

## Table of Content <!-- omit in toc -->

- [1. Introduction](#1-introduction)
  - [1.1. Static class](#11-static-class)
  - [Extension Methods](#extension-methods)
- [2. The Extension Methods in a Nutshell](#2-the-extension-methods-in-a-nutshell)
- [3. The use of extension methods ✍🏻](#3-the-use-of-extension-methods-)
- [4. Definition](#4-definition)
- [5. Conclusion](#5-conclusion)
- [6. See Also](#6-see-also)

## 1. Introduction

### 1.1. Static class

Object-oriented programming is not always beneficial. Static methods and a static class are language constructs committed to work without engaging object-oriented programming. There are several compelling reasons to use static constructs in CSharp. For example, static methods within a static class serve as utility functions. They allow you to group implementation of related responsibility without the any need to other with creating an instance. For example, the `System.Math` class provides static methods for common mathematical operations.

The static class construct has unique characteristics that set it apart from regular (non-static) classes. A static class is defined using the `static` keyword. It can only contain **static members** (methods, fields, properties). Unlike non-static classes, a static class cannot be instantiated. You cannot create an instance of it using the `new` operator. Since there's no instance variable, you access the members of a static class directly using the definition name itself. For example, if you have a static class named `UtilityClass` with a public static method called `MethodA`, you invoke it like this:

``` C#
   UtilityClass.MethodA(); 
```

In contrast to non-static classes, static classes cannot be inherited. A static constructor if present is called automatically before any member declared in that class is referenced. It ensures that necessary initialization occurs before any other code execution related to the static class.

In summary, a static class provides a convenient way to group related static members. It's a powerful tool for organizing utility functions and other stateless operations. Therefore, the static class can be recognized as an organization unit gathering its members. Compared to namespace it supports encapsulation allowing controlling the visibility of members outside of the boundary of definitions.

Because there are no variables of the static class type it is impossible to refer to members using the instance selector to operate on contributing members. Traditionally, to refer to a member of a static class it must be prefixed by the class name instead. To access the members of a static class directly the class name must be applied as a prefix. In other words, a static class selector "." has to be applied only to a static class name.

### Extension Methods

Because there are no variables of the static class type it is impossible to invoke the static methods using the instance method invocation syntax. Traditionally, to invoke a method defined inside a static class it must be prefixed by the class name. As a result, the invocations cannot be cascaded. For example, we can't call `A().B().C()` of A, B, and C methods, which are exposed by a static class because the selector "." may be applied only to a value but there is no value of the static class. To access the members of a static class directly the class name must be applied as a prefix. To overcome this obstacle the extension method concept has been introduced. Thanks to the C Sharp programming language the existence of an instance method for a selected type can be simulated using the extension methods construct. To do this, the signature of the static method must have the `this` keyword as the prefix of the first argument. In other words, extension methods are a kind of static method, that can be called as if they were instance methods of the first argument type.

To illustrate the problem, let's consider a scenario where we want to invoke static methods in a cascade. Cascading invocation is a technique where multiple method calls are chained together in a single expression. To investigate this scenario, I have defined two static methods in the [ExtensionMethods][ExtensionMethods] class. The first [WordCount][WordCount] whose `string` parameter is analyzed and the number of words this `string` argument contains is evaluated. The second method, `[Even][Even] has an integer argument and returns a boolean value that indicates whether the number is even or odd.

In a project that wraps unit tests, the [TypicalCallTestMethod][TypicalCallTestMethod] is responsible for returning the number of words in the sample text and checking whether the evaluated number is odd. The following code snippet shows how to call them sequentially - typically using the syntax of invocation static methods.

``` C#
      string _TestString = "Hello Extension Methods";
      int _wordCount = ExtensionMethods.WordCount(_TestString);
      Assert.IsFalse(ExtensionMethods.Even(_wordCount));
```

This code snippet shows that we need an additional variable containing the intermediate result of the first static method. The second static method will operate on this result. Alternatively, we can apply a nested call but again we will end up with a necessity to use many independent expression constructs to evaluate nested actual arguments.

## 2. The Extension Methods in a Nutshell

The extension method is a linguistic construct. It allows you to simulate calling static methods in a similar way to methods defined as members for the selected type, for example, methods that are defined as members of non-static class types. The [CascadedCallTestMethod][CascadedCallTestMethod] contains just such a call. This is the test method where the `WordCount` and `Event` methods invocation are cascaded in one single expression evaluating argument that is passed to `Assert.IsFalse` method.

``` C#
    Assert.IsFalse(_TestString.WordCount().Even());
```

In contrast, previously we had to declare an additional variable to preserve the intermediate result and all calculations were performed in two independent expressions.

To enable extension methods for a particular type, the declarations of them must be visible. At this point, the methods fulfill the requirements of static methods, namely, they are defined in the static class and their first parameter is preceded by the word `this`. additionally, the static class definition is visible thanks to using the same namespace.

It is still possible to call the extension method traditionally, just like a static method. The following code snippet proves it.

``` C#
    Assert.AreEqual<int>(_TestString.WordCount(), ExtensionMethods.WordCount(_TestString));
```

In the above code snippet, both calls of the same method are equivalent considering the returned value. Here the `WordCount` method is invoked using the dot selector, like in case of instance invocation, and traditionally like the extension method. The test passes because these two invocations differ only in the syntax but have the same result.

We can summarize this part of the discussion by stating that it is possible and equivalent for the extension method to have a method call using the syntax derived from the invocation of instance method and traditional as for static methods.

## 3. The use of extension methods ✍🏻

Let's return to the class where the previously used methods were defined. I have defined another extension method for the `string` class. Intentionally it duplicates the definition of the same instance method exposed by the `string` class. Here we have the definition of the `string` class and, in this definition, we find a method with the same name. Since this is an extension method you need to use two parameters instead of one. The first parameter indicates the expanded type. In this example, it is `string`. The second parameter is intended to pass the word to be searched for in the input string. There is only one statement in this method that throws an exception of the type `NotImplementedException`. Invocation of this method, and as the result execution of this statement has to cause the unit test to fail.

Now, let's look at the behavior when we are trying to invoke it. Let's get back to testing. Two test methods demonstrate the use of these methods. The first way is to use it as an extension method and use the instance method call syntax. We see a string here and we call the `Contains` method for this string. In this case, the test returns the expected result equal to true,  which means that the word `Hello` is in the source stream. It indicates that an instance method for the string is invoked, namely the one with the conflicting name. In the second test method, let's try to call this method classically, just like a static method avoiding invocation syntax using instance calls. In this case, we see that the test results in an exception being thrown, confirming that this time the static method was executed.

Now we can summarize this discussion. If the name of an extension method conflicts with the name of a method for the extended type, it will not be invoked using the new syntax resembling the call for a member of the extended type. To execute it we must use the typical calling syntax for a static method.

Analyzing the behavior of previously presented extension methods, we can observe that the kind of type that is to be extended is not limited. It can be a reference type, as in the case of the `WordCount` method, or a value type, as in the case of the `Even` method. An interesting case is extending the interface. The [ProtectedMyInterfaceMethodCall][ProtectedMyInterfaceMethodCall] method uses the interface defined in the context of this example. This interface defines the [MyInterfaceMethod][MyInterfaceMethod] method which is executed provided that the first parameter of this method is not null, as follows

[ProtectedMyInterfaceMethodCall]: ExtensionMethods.cs#L58-L63
[MyInterfaceMethod]: IMyInterface.cs#L16-L22

```C#
    public static void ProtectedMyInterfaceMethodCall(this IMyInterface myInterface)
    {
      if (myInterface == null)
        throw new ArgumentNullException($"{nameof(myInterface)} cannot be null.");
      myInterface.MyInterfaceMethod();
    }
```

Let's look at the behavior of this method in several scenarios. The first one may be found in this test method where the value of the `_myInterface` variable is null. For the null value calling the interface method results in the environment throwing an exception and signaling that it is impossible to call the instance method for the null value in case there is no instance.

W przypadku wykorzystywania składni dla metody rozszerzającej; to kolejna metoda testowa; W tym przypadku znowu zmienna `_myInterface` jest null, ale wykonujemy metodę jako metodę rozszerzającą. Tutaj widzimy, że sprawdzamy, czy pierwszy parametr jest null to rzucamy exception. I w tym przypadku możemy potwierdzić, że ta metoda została wykonana i że w wyniku wykonania tej metody został wyrzucony wyjątek, co sygnalizowane jest w metodzie testowej atrybutem `ExpectedException`.

## 4. Definition

So let's summarize what an extension method is. Well, it is a static method declared in a static class. Following the second condition, it must have at least one parameter. Additionally, this parameter must be preceded by the `this` keyword. To be visible, the namespace in which it is declared must be added to the list of default namespaces applying the `using` directive.

To conclude the discussion on calling extension methods, it should be emphasized that in this case, we can use the invocation syntax exactly as we know it from calling methods defined as components of the selected type.

## 5. Conclusion

It should be stressed that extension methods do not overwrite the members of an existing type. That is, they cannot be used to modify or replace existing type methods, so they do not work in this case; there is no similarity with inheriting from the base type and defining methods in the derived type. Another important feature of extension methods is that they can be invoked for null values because the compiler replaces the syntax for calling the extension method with the syntax for the static method. Therefore we should be aware that extension method invocation only mimics invocation of a type member. Sometimes it could confuse but it should be recognized as a trade-off considering the benefits we will learn later.

## 6. See Also

- [Extension Methods (C# Programming Guide) on MSDN](https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)
- Static Classes and Static Class Members (C# Programming Guide). <https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members>.
- What is a Static Class in C#? - C# Corner. <https://www.c-sharpcorner.com/UploadFile/74ce7b/static-class-in-C-Sharp/>
- Static Class in C# with Examples - Dot Net Tutorials. <https://dotnettutorials.net/lesson/static-class-in-csharp/>
- Static keyword in C# - GeeksforGeeks. <https://www.geeksforgeeks.org/static-keyword-in-c-sharp/>.
- C# | Static Class - GeeksforGeeks. <https://www.geeksforgeeks.org/c-sharp-static-class/>
- [Extension Methods (C# Programming Guide) on MSDN](https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)

[ExtensionMethods]: ExtensionMethods.cs#L19-L64
[WordCount]: ExtensionMethods.cs#L26-L29
[Even]: ExtensionMethods.cs#L36-L39
[TypicalCallTestMethod]:  ../FunctionalProgramming.UnitTest/ExtensionMethodsUnitTest.cs#L27-L32
[CascadedCallTestMethod]: ../FunctionalProgramming.UnitTest/ExtensionMethodsUnitTest.cs#L38-L43
