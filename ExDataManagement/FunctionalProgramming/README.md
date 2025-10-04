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

# Functional Programming

Functional programming (FP) is widely recognized in academic literature as a declarative programming paradigm that emphasizes the use of mathematical functions to construct software. Domain-specific programming languages (DSLs) often implement this paradigm through coding styles, also known as code styles. These styles are developed based on rules or guidelines that govern the structure and templating of source code. They help programmers read and understand code more easily, maintain it effectively, and reduce the likelihood of introducing errors.

Functional programming is recognized as a foundational paradigm for managing structured external data, particularly when interfacing with a Database Management System (DBMS). A DBMS is software that runs on a suitable platform or technology, used to organize, store, retrieve, and manipulate data in a systematic manner.

### 1.1. Functional Programming Preface  

Functional programming (FP) is widely recognized in academic literature as a declarative programming paradigm that emphasizes the use of mathematical functions to construct software [@bird1988introduction, @hughes1989functional, @wadler1992essence, @zebaCodingStandards]. Dedicated domain-specific programming languages (DSLs) often implement this paradigm through coding styles, also known as code styles. These styles are developed based on rules or guidelines that govern the structure and templating of source code. They help programmers read and understand code more easily, maintain it effectively, and reduce the likelihood of introducing errors.

FP emphasizes treating data processing as a series of mathematical functions. In this paradigm, functions are first-class citizens—meaning they can be passed as arguments [@wikipediaFunctionalProgramming], returned from other functions, and assigned to variables. Functional programming treats computation as the evaluation of mathematical functions and avoids changing state and mutable data. A mutable object is one whose state can be modified after it is created, whereas an immutable object cannot be modified once created.

One of the most important properties of a function in the context of functional programming is that its output depends solely on the actual parameter values passed during the call. In other words, the function's behavior does not rely on any local or global state. Therefore, calling a function twice with the same parameter values will produce the same result each time. An example of the function conforming to this paradigm is for example:

```C#
    public static bool StringIsLongPredicate(string stringToTest)
    {
      return stringToTest.Length > 10;
    }
```

The predicate always returns true if the current string assigned to `stringToTest` is longer than 10 characters. It represents a method that defines a set of criteria and determines whether a specified object meets those criteria. This approach eliminates side effects—one of the key motivations for using functional programming to manage external data.

Functional programming also serves as a foundation for managing structured external data, especially when interfacing with a Database Management System (DBMS). A DBMS is software that runs on a suitable platform or technology and is used to organize, store, retrieve, and manipulate data in a systematic manner.

Because  DBMS handles concurrent access to data, thanks to functional programming data consistency can be protected by reducing side effects. While managing data using DBMS the following operation may be distinguished:

- Insert: Add new data to repository
- Update: Modify existing repository
- Delete: Remove data from repository
- Select: Retrieve data from repository

The operations are described by a Domain-specific Language (SQL for example) and executed by the DBMS. Functional programming constructs of the main programming language are a good candidate to be used as an equivalent solution to define these operations that can be integrated with the rest of the program. Let's delve into the details of this approach.

Functional programming is a style of developing the computer programs that treats computation as the evaluation of mathematical functions and avoids changing-state and mutable data. A mutable data is an object whose state can be modified after it is created. An immutable object is an object whose state cannot be modified after it is created.


The most important behavior of a function in the context of functional programming paradigm is that its output value depends only on the actual parameter values that are passed to while calling it. In other words, the function behavior doesn't depend on the local or global state. So calling a function f twice with the same value for a parameter x produces the same result f(x) each time. An example of the function conforming to this paradigm is for example:

```C#
    public static bool StringIsLongPredicate(string stringToTest)
    {
      return stringToTest.Length > 10;
    }
```

This predicate returns always `true` if the current string assigned to `stringToTest` is longer than 10. It represents the method that defines a set of criteria and determines whether the specified object meets those criteria. It eliminates side effects, which is one of the key motivations for using the functional programming approach to manage external data. In this scenario, the function can be sent and executed by a data management system and produce a set of related data.

Object-oriented languages, including but not limited to C\#, incorporate several features that contribute to functional programming. Let’s explore some of these constructs:

- [delegate and events](FunctionalProgramming/READMEDelegateEvents.md) - delegates are a fundamental construct in C# that enables late binding scenarios allowing the definition of a type-safe reference to a method; an event is essentially a delegate with additional restrictions
- [extension methods](FunctionalProgramming/README.ExtensionMethods.md) - the extension method to use for static methods invocation syntax similar to the invocation of type members methods and finally cascading execution chain
- [anonymous functions](FunctionalProgramming/README.AnonymousFunctions.md) - allow definition and use of inline methods that don't have names

In programming languages, inline method definitions refer to a technique where the method header and its block of statements are located directly as an operand of expression where it is to be executed contributing to the evaluated result, rather than being defined in advance as a separate named construct (named block). As a result the method definition is unnamed. The main goal is to compress the whole expression to one line of code.

Check out the sections [Functional(Programming Implementation](FunctionalProgramming/Readme.md) to get more about available examples.

Check out the sections [Extension Methods](FunctionalProgramming/ExtensionMethods.md) and [Anonymous Functions](FunctionalProgramming/AnonymousFunctions.cs) to learn more on these concepts, which booth contributes to the Language Integration Query (LINQ) concept. The LINQ concept will be examined in detail as a main topic contributing to the Structural Data section.
