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
- [2. What's our problem?](#2-whats-our-problem)
- [3. What is a static method?](#3-what-is-a-static-method)
- [4. The use of extension methods](#4-the-use-of-extension-methods)
- [5. Definition](#5-definition)
- [6. Conclusion](#6-conclusion)

## 1. Introduction

This lesson is about extension methods.

## 2. What's our problem?

Let's start by defining the problem. To illustrate the problem, let's consider a scenario where we want to invoke static methods in a cascade. I have defined two static methods in the `ExtensionMethods` class, which is a non-static class. The first `WordCount` whose `string` parameter is analyzed and the number of words this `string` contains is evaluated. The second method, `Even`, has an integer parameter and returns a boolean value that indicates whether the number is even or odd.

However, in a project that wraps unit tests, there is a test showing how to call them sequentially. This is the method (`TypicalCallTestMethod`). It is responsible for returning the number of words in the sample text and checking whether the indicated number is odd. Here we have a test to check that this number is odd. We see that there are only three words in the string. This solution shows that to operate we need an additional variable into which we substitute the intermediate result of the first static method. The second static method will operate on this result.

## 3. What is a static method?

The solution is a linguistic construct called the Extension Method. It allows you to simulate calling static methods in a similar way to methods defined for the selected type. For example, methods for a selected instance of a class or interface. The next test contains just such a call; this is the test method where the WordCount and Event methods are cascaded into one expression. In the previous example, we had to declare an additional variable. Here we have the `_wordCount` variable, which... but in addition, all calculations were performed in two expressions. Here we have the first expression in the substitution instruction to the right of the substitution sign. The second expression is the current value of the `IsFalse` method. I suggest remembering this fact because it will be crucial for understanding the language constructs that allow you to integrate the programming language with the selected query language for external data repositories. Currently, the compiler reports an error that says that there is no `WordCount` method for the string and no extension method can be found by the compiler.

For the example methods to become extension methods, we need to make several changes to the program text in question. So let's go back to the definition of both methods; I will organize the screen in such a way that I can see both the definitions of the methods and their use. The first thing we need to change in the text in question is that the class in which extension methods are defined must be static, so let's add the word static here. Another requirement for extension methods is that the first parameter of each extension method is preceded by the word `this`. So we have to add this word in one method and the other method.

At this point, the methods FULFILS the requirements of static methods,  namely they are defined in the static class and their first parameter is preceded by the word `this`. We can see on the left side of the screen that the compiler still reports an error. Previously these methods we used; they are visible all the time and all the time; there is no error here because we have preceded the name of the class name in which these methods are located and the name of the method with the name of the namespace in which they were defined. In this case, when we have a call like for instance, i.e. a call for extension methods, unfortunately, we have no place to insert the names of the namespaces where they were defined and therefore the compiler cannot locate them. But we have options here where we can import the namespace, we can indicate which namespace the compiler should use to find all the extension methods and at this point, the compilation errors are gone. However, it is still possible to invoke traditional methods; Maybe I'll close the method definition screen now.

On the left, it is still possible to call the extension method classically, just like a static method. We can also check that both calls are equivalent considering only the returned value. Here we have `WordCount` in the form with a dot, like in case of instance invocation, and a classic call, as for the extension method. The test should give the correct result because these two invocations differ only in the call syntax, so they only enable the use of extension methods, they use the syntax that is used for instance methods for the selected reference type..

We can already see the test result; it has passed, so these two invocations are equivalent. So we can summarize this part of the discussion as saying that for extension methods it is possible and equivalent to have a method call; in the form using the syntax for the extension method as for the instance method and traditional as for static methods.

## 4. The use of extension methods

Let's go back to the class where the previously used methods were defined. I have defined another extension method for the `string` class. Intentionally it duplicates the definition of the same instance method exposed by the `string` class. Here we have the definition of the `string` class and, in this definition, we find a method with the same name. Since this is an extension method, you need to use two parameters instead of one. The first parameter indicates the type to be expanded, in this `string`. The second parameter is intended to pass the word that is to be searched for in the input string. There is only one statement in this method that throws an exception of the type `NotImplementedException`. Invocation of this method, and as the result execution of this statement has to cause the unit test to fail.

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

## 5. Definition

So let's summarize what an extension method is. Well, it is a static method declared in a static class. Following the second condition, it must have at least one parameter. Additionally, this parameter must be preceded by the `this` keyword. To be visible, the namespace in which it is declared must be added to the list of default namespaces applying the `using` directive.

To conclude the discussion on calling extension methods, it should be emphasized that in this case, we can use the invocation syntax exactly as we know it from calling methods defined as components of the selected type.

## 6. Conclusion

It should be stressed that extension methods do not overwrite the members of an existing type. That is, they cannot be used to modify or replace existing type methods, so they do not work in this case; there is no similarity with inheriting from the base type and defining methods in the derived type. Another important feature of extension methods is that they can be invoked for null values because the compiler replaces the syntax for calling the extension method with the syntax for the static method. Therefore we should be aware that extension method invocation only mimics invocation of a type member. Sometimes it could confuse but it should be recognized as a trade-off considering the benefits we will learn later.
