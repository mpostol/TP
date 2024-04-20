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

# Extension Methods

## Static Classes and Static Methods

Object-oriented programming is not always beneficial. Static constructs like static classes and static methods are language concepts committed to work without engaging object-oriented programming. There are several compelling reasons to use static constructs in CSharp. For example, static methods within a static class serve as utility functions. They allow you to group implementation of related responsibilities without creating an instance.

The [StaticClass][StaticClass] is an example of a static class. The [StaticClassTestMethod][StaticClassTestMethod] illustrating the usage of the static class is located in the [StaticClassTest][StaticClassTest]. We will not discuss them in detail, but a few things need to be underlined. In particular, I will not discuss the issues related to the programming language itself. So if you need detailed information about the syntax of the static class definition you must check out the CSharp user guide.

The static class construct has unique characteristics that set it apart from regular (non-static) classes. A static class is defined using the `static` keyword. It can only contain static members (methods, fields, properties). Unlike non-static classes, a static class cannot be instantiated. In other words, you cannot create an instance of it using the `new` operator. Since there's no instance variable, you access the members of a static class directly using the definition name itself. For example, if you have a static class named [StaticClass][StaticClass] with a public static method called [StaticClassInitializer][StaticClassInitializer]:

``` CSharp
    public static void StaticClassInitializer(double maxIncome, double minIncome)
    {
      MaxIncome = maxIncome;
      MinIncome = minIncome;
    }
```

you invoke it like this:

``` CSharp
      StaticClass.StaticClassInitializer(3.0, 1.0);
```

In contrast to non-static classes, static classes cannot be inherited. A static constructor if present is called automatically before any member declared in that class is referenced. It ensures that necessary initialization occurs before any other code execution related to the static class.

Because there are no variables of the static class it is impossible to refer to members using the instance selector to operate on contributing members. By design, to refer to a member of a static class it must be prefixed by the class name instead. In other words, a static class selector "." has to be a postfix of a static class name.

It is worth stressing that the static class cannot be used as the type defining the compatible values of a variable. As a result, we can state that the static class is not a type. You cannot instantiate the static class and cannot operate on values of that type. So in the sense of type, as a linguistic construct that defines a set of allowable values the static class cannot be used. On the other hand, a static class can contain variables and these variables can be modified. It may also contain the implementation of responsibility. What it is if it isn't the type because its features don't fulfill the type definition. Because it can contain members - I mean variables and methods for example - we can recognize the static class as an organization unit gathering internal definitions and declarations available in the context of the static class name.

In summary, a static class provides a convenient way to group related static members. It's a powerful tool for organizing utility functions and other stateless operations. Therefore, the static class can be recognized as an organization unit gathering its members. In contrast with the namespace construct it supports encapsulation allowing controlling the visibility of members outside of the boundary of definitions.

## Extension Method

### Extension Methods in a Nutshell

Because there are no variables of the static class type it is impossible to invoke the exposed by it methods using the instance method invocation syntax. To invoke a method defined as a member of a static class it must be prefixed by the class name. As a result, the invocations cannot be cascaded. For example, we can't call `A().B().C()` of A, B, and C methods, which are exposed by a static class because the selector `.` may be applied only to a value but there is no value of the static class. To access the members of a static class directly the class name must be added as a prefix. To overcome this obstacle the extension method concept has been introduced. Thanks to the extension method concept the existence of an instance method for a selected type can be simulated using the extension methods construct. To do this, the signature of the static method must have the `this` keyword as the prefix of the first argument. In other words, extension methods are a kind of static method, that can be called as if they were instance methods of the first argument type.

To illustrate the problem, let's consider a scenario where we want to invoke static methods in a cascade. Cascading invocation is a technique where multiple method calls are chained together in a single expression. To examine this scenario I have defined two static methods in the [ExtensionMethods][ExtensionMethods] class. The first [WordCount][WordCount] whose `string` argument content is analyzed and the number of words this `string` contains is evaluated. The second method, [Even][Even] has an integer argument and returns a boolean value that indicates whether the number is even or odd.

In a project that wraps unit tests, the [TypicalCallTestMethod][TypicalCallTestMethod] is responsible for returning the number of words in the sample text and checking whether the evaluated number is odd. The following code snippet shows how to call them sequentially using the typical syntax of invocation static methods.

``` C#
      string _TestString = "Hello Extension Methods";
      int _wordCount = ExtensionMethods.WordCount(_TestString);
      Assert.IsFalse(ExtensionMethods.Even(_wordCount));
```

This code snippet shows that we need an additional variable containing the intermediate result of the first method. The second method will operate on this result. Alternatively, we can apply a nested call but again we will end up with a necessity to use many independent expression constructs to evaluate nested actual arguments.

The extension method is a linguistic construct. It allows you to simulate calling static methods in a similar way to methods defined as members for the selected type, for example, methods that are defined as members of non-static class types. The [CascadedCallTestMethod][CascadedCallTestMethod] contains just such a call. This is the test method where the `WordCount` and `Event` methods invocation are cascaded in one single expression evaluating argument that is passed to the `Assert.IsFalse` method.

``` C#
    Assert.IsFalse(_TestString.WordCount().Even());
```

In contrast, previously we had to declare an additional variable to preserve the intermediate result and all calculations were performed in two independent expressions.

To enable extension methods for a particular type, the declarations of them must be visible. At this point, the methods fulfill the requirements of static methods, namely, they are defined in the static class and their first parameter is preceded by the word `this`. additionally, the static class definition is visible thanks to the `using` directive with the same namespace.

It is still possible to call the extension method traditionally, just like a static method. The following code snippet proves it.

``` C#
    Assert.AreEqual<int>(_TestString.WordCount(), ExtensionMethods.WordCount(_TestString));
```

In the above code snippet, both calls of the same method are equivalent considering the returned value. Here the `WordCount` method is invoked using the dot selector, like in case of instance invocation, and traditionally like the extension method. The test passes because these two invocations differ only in the syntax but have the same result.

We can summarize this part of the discussion by stating that it is possible and equivalent for the extension method to have the syntax of invocation derived from the instance invocation of methods and classic as for static methods with the class name prefix.

### Collision with Instance Member

Let's return to the [ExtensionMethods][ExtensionMethods] class where the previously used methods were defined. I have defined another extension method for the `string` class. Intentionally it duplicates the definition of the same instance method exposed by the `string` class. Here we have the definition of the `String` class:

``` CSharp
public bool Contains (string value);
```

In the [ExtensionMethods][ExtensionMethods] the [Contains][Contains] method has the same name. Since this is an extension method you need to use two parameters instead of one. The first parameter indicates the expanded type. In this example, it is `string`. The second parameter is intended to pass a stream of characters to be searched for in the input string. If it is called there is one statement in this method that throws an exception of the type `NotImplementedException`. As a result execution of this statement has to cause the unit test to fail.

Now, let's look at the behavior when we are trying to invoke it. Let's get back to [ExtensionMethodsUnitTest][ExtensionMethodsUnitTest] class. The [CollisionWithInstanceMemberTest][CollisionWithInstanceMemberTest] method demonstrates the difference between instance and static call of the  the [Contains][Contains] extension method.

``` CSharp
      string testString = "Hello Extension Methods";
      Assert.IsTrue(testString.Contains("Hello"));
      Assert.ThrowsException<NotImplementedException>(() => ExtensionMethods.Contains(testString, "Hello"));
```

The first way is to use it as an extension method and use the instance method call syntax. We see a string here and we call the `Contains` method for this string. In this case, the test returns the expected result equal to true, which means that the word `Hello` is in the source stream. It indicates that an instance method for the string is invoked, namely the one with the conflicting name, and defined in the `String` class. In the next line there is a call of the [Contains][Contains] method classically, just like a static method avoiding invocation syntax reserved for the instance calls. In this case, we see that the test results in an exception being thrown, confirming that the static method was executed this time.

Now we can summarize this discussion. If the name of an extension method conflicts with the name of a method for the extended type, it will not be invoked using the new syntax resembling the call for a member of the extended type. To make sure it is executed the typical calling syntax for a static method has to be used.

### Instance Invocation for `null` Value

Analyzing the behavior of previously presented extension methods, we can observe there are no limits on what type is to be extended. It can be a reference type, as in the case of the [WordCount][WordCount] method, or a value type, as in the case of the [Even][Even] method. An interesting case is extending the interface. The [ProtectedMyInterfaceMethodCall][ProtectedMyInterfaceMethodCall] method uses the interface defined in the context of this example. This interface defines the [MyInterfaceMethod][MyInterfaceMethod] method which is executed provided that the first parameter of this method is not `null`, as follows

```C#
    public static void ProtectedMyInterfaceMethodCall(this IMyInterface myInterface)
    {
      if (myInterface == null)
        throw new ArgumentNullException($"{nameof(myInterface)} cannot be null.");
      myInterface.MyInterfaceMethod();
    }
```

Let's look at the behavior of this method in several scenarios. The first one may be found in  the [NullCallExceptionTest][NullCallExceptionTest] method where the value of the `_myInterface` variable is null.

``` CSharp
      IMyInterface _myInterface = null;
      Assert.ThrowsException<NullReferenceException>(() => _myInterface.MyInterfaceMethod());
      Assert.ThrowsException<ArgumentNullException>(() => _myInterface.ProtectedMyInterfaceMethodCall());
```

For the `null` value calling the interface method results in the environment throwing an exception and signaling that it is impossible to call the instance method for the `null` value in case there is no instance. When using the instance invocation syntax for an extension the referred method is executed indeed. In this case, we can confirm that an exception was thrown as a result of the execution of this method.

### Conclusion

So let's summarize what an extension method is. Well, it is a static method declared in a static class. Following the second condition, it must have at least one parameter. Additionally, this parameter must be preceded by the `this` keyword. To be visible, the namespace in which it is declared must be added to the list of default namespaces applying the `using` directive. For the extension methods we can use the invocation syntax exactly the same as for  calling methods defined as components of the selected type.

It should be stressed that extension methods do not overwrite the members of an existing type. That is, they cannot be used to modify or replace existing type methods like in the case of inheriting from the base type and defining methods in the derived type. Another important feature of extension methods is that they can be invoked for null values because the compiler replaces the syntax for calling the extension method with the syntax for the static method. Therefore we should be aware that the extension method invocation only mimics the invocation of an instance member. Sometimes it could be confused but it should be recognized as a trade-off considering the benefits we will learn later.

## See Also

- [Static Classes and Static Class Members - C\# Programming Guide][MSDN.sc]
- [Static Class in C\# with Examples (Dot Net Tutorials)][static-class-in-csharp]
- [Extension Methods (C\# Programming Guide) on MSDN][MSDN.EM]

[static-class-in-csharp]: https://dotnettutorials.net/lesson/static-class-in-csharp/
[MSDN.sc]: https://learn.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members
[MSDN.EM]: https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/extension-methods

[ProtectedMyInterfaceMethodCall]: ExtensionMethods.cs#L58-L63
[ExtensionMethods]: ExtensionMethods.cs#L19-L64
[WordCount]: ExtensionMethods.cs#L26-L29
[Even]: ExtensionMethods.cs#L36-L39
[Contains]: ExtensionMethods.cs#L48-L51

[MyInterfaceMethod]: IMyInterface.cs#L16-L22
[StaticClassInitializer]: StaticClass.cs#L50-L54
[StaticClass]: StaticClass.cs#L21-L76

[CollisionWithInstanceMemberTest]: ../FunctionalProgramming/FunctionalProgramming.UnitTest/ExtensionMethodsUnitTest.cs#L49-L54
[StaticClassTestMethod]: ../FunctionalProgramming.UnitTest/StaticClassTest.cs#L20-L31
[StaticClassTest]: ../FunctionalProgramming.UnitTest/StaticClassTest.cs#L17-L32
[TypicalCallTestMethod]:  ../FunctionalProgramming.UnitTest/ExtensionMethodsUnitTest.cs#L27-L32
[CascadedCallTestMethod]: ../FunctionalProgramming.UnitTest/ExtensionMethodsUnitTest.cs#L38-L43
[ExtensionMethodsUnitTest]: ../FunctionalProgramming.UnitTest/ExtensionMethodsUnitTest.cs#L21-L76
[NullCallExceptionTest]: ../FunctionalProgramming.UnitTest/ExtensionMethodsUnitTest.cs#L61-L65

<!--
Research:
- What is a Static Class in C#? - C# Corner. <https://www.c-sharpcorner.com/UploadFile/74ce7b/static-class-in-C-Sharp/>
- Static keyword in C# - GeeksforGeeks. <https://www.geeksforgeeks.org/static-keyword-in-c-sharp/>.
- C# | Static Class - GeeksforGeeks. <https://www.geeksforgeeks.org/c-sharp-static-class/>
-->