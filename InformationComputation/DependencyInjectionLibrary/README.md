﻿# 1. Dependency injection

## Table of content <!-- omit in toc -->

- [1. Dependency injection](#1-dependency-injection)
  - [1.1. Topic introduction](#11-topic-introduction)
  - [1.2. What's the problem? ✍🏻](#12-whats-the-problem-)
    - [1.2.1. power point presentation 🖥️](#121-power-point-presentation-️)
    - [1.2.2. Section Script 🧑‍🏫](#122-section-script-)
  - [1.3. Library Example Description 📋(SC)](#13-library-example-description-sc)
  - [1.4. Tasks to be solved](#14-tasks-to-be-solved)
  - [1.5. Testing](#15-testing)
  - [1.6. Polymorphism 📋(SC)](#16-polymorphism-sc)
  - [1.7. Polymorphism Implementation 📋 (SC)](#17-polymorphism-implementation--sc)
  - [1.8. Calling Abstract Method 📋(SC)](#18-calling-abstract-method-sc)
  - [1.9. Command line application 📋(SC)](#19-command-line-application-sc)
  - [1.10. User Interface Problems  📋(SC)](#110-user-interface-problems--sc)
  - [1.11. Implementation in the library](#111-implementation-in-the-library)
  - [1.12. Portability Problem](#112-portability-problem)
  - [1.13. Distributing Testing Fixture](#113-distributing-testing-fixture)
  - [1.14. Inheritance](#114-inheritance)
  - [1.15. Object Creation (dependency  injection) 📋(SC)](#115-object-creation-dependency--injection-sc)
  - [1.16. No Polymorphism 📋](#116-no-polymorphism-)
  - [1.17. Dependency Injection](#117-dependency-injection)

## 1.1. Topic introduction

During this lesson, I want to conclude the object-oriented programming topic with a nontrivial example. I propose to learn more about object-oriented programming in the context of dependency injection design pattern. By pattern, I mean a programming archetype to solve a problem. It is a well-known and widely accepted pattern that is useful to be adopted in many scenarios. Those who have already heard about dependency injection may be concerned that this sounds like an introduction to an entirely different course but not a summary of this course. In fact, the concerns are justified, because many publications have already been written about dependency injection, and many frameworks exist on the market. There are also some terms used in this context like Inversion of Control, and Container we should be familiar with. The inversion of control we know from the previous lesson. To make the discussion transparent I will not use any framework. It allows for avoiding discussion about containers and reflection. Finally, you will learn the precise definition distinguishing object-oriented programming and dependency injection concepts. Let me stress that the main goal is not to be aware but to know how to use the dependency injection pattern. Especially I will pay attention to the differences between object-oriented programming and the dependency injection pattern. Again, this may sound puzzling, but I hope it will provide a basis for a better understanding of the object-oriented programming concept.

## 1.2. What's the problem? ✍

### 1.2.1. power point presentation 🖥️

- testing program behavior
- program entry point (bootstrapping)
- polymorphism that was shown as a problem to solve
- object-oriented programming to address the following problems
  - polimorfizm - necessity to create many implementations of the same functionality
  - impossibility to use the new operator in the place of use to create an object because the type is or shall be unknown
- dependency injection fundamentals

### 1.2.2. Section Script 🧑‍🏫

## 1.3. Library Example Description 📋(SC)

Let's assume that our task is to ship a library for an unknown in advance number of users.  Additionally, we don't know where and how our library will be used. We can only assume that it will be a part of the logic layer. For the sake of simplicity, we are neglecting the existence of the data layer. It is not used and relevant in our example. The library examples to be investigated are located in the project DependencyInjectionLibrary. The first code snipped is called ConstructorInjection class. It contains several methods named Alfa, Bravo, Charlie, and Delta. Similar methods are gathered in the following example named PropertyInjection. In a production solution, we must provide only one implementation of the Alfa, Bravo, Charlie, and Delta methods using a constructor or property approach.

## 1.4. Tasks to be solved

The first task you will face in a production environment is resolving a condition that makes the selection between the constructor and property injection pattern easier and more systematic.  Depending on the expected features both have some advantages and disadvantages that should help to make a decision. Here it is worth stressing that there is also possible to merge both ones and provide a hybrid solution but this scenario is out of our lesson scope and you may implement it on your own.

The second task is testing our program, and especially our library before shipping as a product. Unfortunately, testing doesn't guarantee that the final product is errorless but it could increase the chance that the algorithm and its implementation are as expected.  To validate the implementation we have to face up the following tasks:

1. make the text errorless according to the selected programming language
1. testing the program to prove that the returned data is as expected, and
1. check the program to prove that its behavior is as expected

Testing the program text against the selected programming language syntax and semantics is a design-time activity, required to prove that we have a program. Fortunately, this work is usually done by the compiler so we may safely skip this task for now.

## 1.5. Testing

Testing the returned data and behavior correctness is a run-time task and requires the execution of the program in a testing environment. The testing environment must resemble the production environment to make useful results. It is hard at the design time because the production environment is not defined yet.  Usually, it is necessary to make the validity evaluation nondestructive. In other words, it should not disturb or even has an impact on the typical usage of the library in a production environment. Look at the library as a product.

This course is not focussed on testing therefore we can introduce many simplifications making our example especially readable for examination of a selected design pattern, I mean dependency injection and a better understanding of object-oriented programming. First, we can notice that our methods don't return any data so validation in this respect is not necessary.

In the ConstructorInjection and PropertyInjection classes, we have a few methods named Alfa, Bravo, Charlie, and Delta. For the sake of simplicity let's just assume that our job is to test only the sequence in which the methods are called. For testing purposes, I have applied a tracing mechanism. One of the benefits of this approach is the possibility to reuse it also in the production environment if needed. To test the sequence in which the methods are called each one calls an instance method of an object whose reference is assigned to the private `TraceSource` field. Because it is not about testing but about programming patterns the question, which will lead our discussion is how and where to create the object that is used for tracing purposes.

## 1.6. Polymorphism 📋(SC)

Consider two scenarios for testing this class. First, the classes could be used as a part of a hypothetical general-purpose library referred by in a console application. The second is unit testing. It is easy to guess that validation for these two examples must be implemented differently. So it is the first place where we must address polymorphism as a problem because the console application may use messages written on the screen to provide feedback and allow assessment of the implementation correctness be an application designer or user. For the unit testing, we must not use the user interface because it doesn't exist at all. Both tests methods have been implemented and added to the design environment as independent projects called appropriately: DependencyInjectionUserInterface and DependencyInjectionLTest. From this example, we can learn that our solution requires a polymorphic approach, I mean we need at least two independent implementation of the same functionality, namely tracing.

## 1.7. Polymorphism Implementation 📋 (SC)

We may implement polymorphic solution using abstraction, inheritance, and implementation. As I said previously, there are two examples but firs one I will use is the ConstructorInjection class. I used abstraction to define the type of the `TraceSource` field of the class. Its value is assigned while the class constructor is executed. In this language, we call it field of class but in general, it is just a variable, I mean value holder. The type of this variable is `ITraceSource`. Using F12 we can get the type definition. It is interface that defines just one method called `TraceData`. Interface is an abstract definition. The interface construct is abstract definition because it doesn't provide any implementation details and can be recognized as a contract between the class `ConstructorInjection` and any user of this class, I mean any creator of this class. We know that the object referred to by this variable has the TraceData method implemented, and the signature of this method is defined by the mentioned interface. Finally, we are calling a method but we are not aware of its implementation details. At run time when we are talking about objects, all implementations must be defined in place the object is created, but the implementations can be different depending on the creator needs. According to this contract, there are two clear roles. First is the interface user. In this case, it is the `ConstructorInjection` class. The second is the implementation provider, and in this case, it is a console application or a unit test. In the palce we are using the reference of abstract type but we know that to create any object a concrete class must be derived from this interface.

## 1.8. Calling Abstract Method 📋(SC)

Here we can see that the `TraceSource` field contains a reference to an object, but its type has been declared as an interface offering one method. Here, however, based on the interface definition we indicate that the object must provide implementation of the `TraceData` operation, but again we should not assume how this operation works. As I said it is just a kind of contract. We only specify a formal declaration containing formal list of arguments because we define only the header of the method called the method signature. As a result, the declaration is there, but it hides (or it rather doesn't provide) implementation details and that is why we call it abstract declaration. This does not prevent you from using it and calling it, passing to it the current values ​​of its arguments in accordance with the declared signature.

## 1.9. Command line application 📋(SC)

I'll come back to unit tests shortly, but now let's examine an example of tracing process implementation to be used by the console application. The result on the screen we can observe by running the console application. As you can see, the result is four messages displayed on the screen, which can then be used to determine the sequence of methods calls and to diagnose manually the correctness of this sequence. This behavior is provided by a custom implementation of the interface. The object of this class is created and assigned to the constructor of the ConstructorInjection class. The question is if this solution is entirely based on an object-oriented programming paradigm. Let's analyze in detail all the code parts in concern. Here we have abstraction. To the parameter of the abstract type, we are assigning a reference to the object created using the class derived from the interface using inheritance. Concluding, everything looks like covered by object-oriented programming.

## 1.10. User Interface Problems  📋(SC)

In this solution where the user interface is used for diagnostic purposes, we can indicate several important problems related to this implementation. In a production environment, such displaying of diagnostic information on the screen for the user may be confusing and useless because the end user doesn't know the correct sequence, doesn't know the meaning of these messages, or doesn't care about the diagnostic information - the program should be correct and that's it. Today, for the production environment, we usually use a graphical user interface. In this case, displaying several diagnostic lines of messages is not a good idea in general. Let's add that unit tests do not have UI support, so displaying anything to the user is useless. Summing up, we can see that the discussed solution is not practical for the production environment, although on-screen diagnostics has always been a favorite approach for novice programmers, because only lack of experience explains the thoughtless omission of the issue in which there are, for example, several thousand lines. Anyway, the example should be recognized only as another implementation of the testing stuff. It doesn't decrease applicability comparing it with a unit test and our discussion about polymorphism.

## 1.11. Implementation in the library

Let's return to the polymorphic problem we have. Just to recall, we need two independent implementations of the `ITraceSource` interface. One is for the command line application. The second is for unit testing purposes. Of course, we can implement all variants inside the library that will provide the appropriate functionality for each of the cases mentioned. To avoid using our imagination let me try to expand this example and implement the interface locally. I am creating MyClass which inherits the `ITraceSource` interface. Using the context menu we may implement this interface to create a concrete class that the ConstructorInjection class can use. In this case, the object used for the diagnostic purpose can be instantiated locally and passing by the argument the trace engine may be omitted. To support variants the type of argument may be replaced by enumerations allowing for a selection of a variant predictable at design time. For sake of simplicity, this case is omitted. The code is kept as simple as possible. Of course in this case the defined class doesn't implement any actual functionality - it just throws the not implemented exception. I will try to prove shortly that it is a very bad solution.

## 1.12. Portability Problem

This approach - I mean local implementation of the diagnostic functionality - is only possible if we could predict all behavior variants we will need in the future. The future time - that I have used in the previous sentence - suggests that it is impossible or at least impractical because I immediately think of a few other ideas on how such diagnostics can be implemented in a different way, for example saving diagnostic messages to a file, or maybe logging the diagnostic information to the cloud, and there is also a database that may be considered. Let's add that the implementation of the logging mechanism on the screen inside the library will result in the necessity to answer the next question: what technology to use, for example, console application as in the example, Windows Presentation Foundation, or Forms in case of Windows operating system. But in general, local implementation of selected scenarios at design time is devastating for portability ar run time because it requires that the technology exists on the target execution platform.

## 1.13. Distributing Testing Fixture

It is beyond the course scope but it is worth stressing now that the diagnostic information may be generated at run time for testing or maintenance purposes. If the main goal to create the diagnostic information is testing everything that is not necessary should be removed from the library to avoid distributing a code that is useless for the production environment. For example, the implementation of the interface `ITraceSource` that is defined in the code should be located outside of the library assembly to minimize its memory footprint and execution time. Before considering the local implementation of the diagnostic information logging, first, we must answer the question of if this functionality is required in the production environment. Again, if the main purpose is to engage this functionality as the testing fixture we must avoid implementing it as part of the library to avoid distributing useless functionality to the end-user. In this case, the local implementation should do nothing as in the example. Now we can use this class as the default implementation instead of throwing the argument null exception if the input attribute is null.

## 1.14. Inheritance

During the program execution phase, the expected algorithm must be implemented. This can only be ensured by creating objects from concrete types, so only objects with all implementation details can be instantiated. In the considered example for this interface, it is necessary to declare a new type that will provide this interface implementation. Using the navigation let's look for all references. On the list we get, we have a few suggestions, but let's choose the one that relates to the project of the previously launched sample console application. Here we see this relationship where the new type is defined with the use of the source type. We call this relationship inheritance, the source type is called the base type, and the newly created type we call the derived type. There are other names, but I will use these consequently. In the newly created concrete class, all abstract declarations must be refined in such a way that the missing implementation details are provided. In our case, the block is missing in the TraceData method, which we add here to the signature of the method inherited from the interface. We call this process the abstraction implementation. As a side note, a block is a sequence of instructions separated by a semicolon - sometimes it is also called body for some reason.

## 1.15. Object Creation (dependency  injection) 📋(SC)

In order for our example to be finished, it is still necessary to specify what specific object implemented the tracing functionality is to be used in the library. Previously, I used a very broad statement, namely: some object whose reference is assigned to a field. So now is a good time to clarify this statement. This field is initialized in the class constructor using the current value of this argument. The instantiation of an object of this class can be found again by using the navigation available in the context menu and looking for all references to this constructor. An object of this class is instantiated in the sample program and a reference to it is passed to the constructor of the library class from which the methods of its instance are called in the sequence. In this case, the reference to the created object becomes the current argument of the constructor.

## 1.16. No Polymorphism 📋

In this example, we started with a polymorphism requirement that was shown as a problem to solve, and then we applied the object-oriented programming paradigm including abstraction, inheritance, and implementation to solve it. Well, as a result, in case we have the console line application for testing purposes we do not have polymorphism. In this particular case, there is no diversity, the program always behaves the same. What's more, there is even no need to use a variant solution, because its behavior is not even parameterized. Is the use of the entire object-oriented programming engine redundant then?

## 1.17. Dependency Injection

Of course, answering this question we say no it is not a redundant approach because we must take into account the fact that the driving force behind our approach and the problem to be solved was the need to take into account polymorphism in future solutions, and not only in a specific solution, I meant in the library itself. The word "future" is the most important because it means that where the object is referenced, its type is unknown because its definition will be compiled later. And it doesn't matter if it's a few milliseconds later or years later. I named this pattern described here dependency injection to somehow terminologically distinguish the situations of using object-oriented programming to implement a potential polymorphism and using it to create variant local solutions. Concluding, in this scenario, we deal with the separation of concerns. One is the usage, and the second is implementation. Hence, shortly the dependency injection is a pattern where we are using unknown for some reason type that we replace by abstraction. Here the type is located in an independent assembly so cannot be referenced directly to avoid circular references between assemblies. Later, while discussing layered program architecture, we will learn the next example where direct access to the concrete type is impossible and must be replaced by abstraction. Shortly, the dependency injection is a pattern we must apply in any scenario where we cannot use the new operator in the place of use to create an object because the type is or shall be unknown for some reason.