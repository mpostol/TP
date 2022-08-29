# 1. Object-oriented programming

## Table of content <!-- omit in toc -->

- [1. Object-oriented programming](#1-object-oriented-programming)
  - [1.1. Script](#11-script)
    - [1.1.1. What's the problem? ✍🏻](#111-whats-the-problem-)
      - [1.1.1.1. Object-oriented programming Entry 🧑‍🏫](#1111-object-oriented-programming-entry-)
    - [1.1.2. Object-oriented Programming Theory 🧑‍🏫](#112-object-oriented-programming-theory-)
    - [1.1.3. Looking For Language Constructs 🧑‍🏫](#113-looking-for-language-constructs-)
    - [1.1.4. Objects Graph 🧑‍🏫](#114-objects-graph-)
    - [1.1.5. Information Model and Object Model 🧑‍🏫](#115-information-model-and-object-model-)
    - [1.1.6. Example Description 📋(SC) ( => dependency injection)](#116-example-description-sc---dependency-injection)
    - [1.1.7. Polymorphism 📋(SC)](#117-polymorphism-sc)
    - [1.1.8. Calling Abstract Method 📋(SC)](#118-calling-abstract-method-sc)
    - [1.1.9. Notes on Interfaces 📋(SC)](#119-notes-on-interfaces-sc)
    - [1.1.10. Command line application 📋(SC)](#1110-command-line-application-sc)
    - [1.1.11. User Interface Problems](#1111-user-interface-problems)
    - [1.1.12. Implementation in the library](#1112-implementation-in-the-library)
    - [1.1.13. Portability Problem](#1113-portability-problem)
    - [1.1.14. Distributing Testing Fixture](#1114-distributing-testing-fixture)
    - [1.1.15. Abstractions](#1115-abstractions)
    - [1.1.16. Inheritance](#1116-inheritance)
    - [1.1.17. Object Creation (dependency  injection) 📋(SC)](#1117-object-creation-dependency--injection-sc)
    - [1.1.18. No Polimorfizm 📋](#1118-no-polimorfizm-)
    - [1.1.19. Dependency Injection](#1119-dependency-injection)
    - [1.1.20. Automation of Dependency Injection](#1120-automation-of-dependency-injection)
    - [1.1.21. Type concept](#1121-type-concept)
      - [1.1.21.1. Built-in types](#11211-built-in-types)
      - [1.1.21.2. Simple types](#11212-simple-types)
      - [1.1.21.3. Complex and structural types](#11213-complex-and-structural-types)
      - [1.1.21.4. Structural types](#11214-structural-types)
  - [1.2. Research](#12-research)

## 1.1. Script

### 1.1.1. What's the problem? ✍🏻

- Why object oriented programming
- information model
- object model
- dynamic graph versus dynamic programming
- polymorphism that was shown as a problem to solve
- we cannot use the new operator in the place of use to create an object because the type is or shall be unknown 

#### 1.1.1.1. Object-oriented programming Entry 🧑‍🏫

In my opinion, a key to a good understanding of the course is understanding the object-oriented programming concept. Hence, I propose to spend a couple of minutes recalling this concept in the context of the implementation of polymorphism. I mean the ability to create different implementations of an abstraction. Putting it upside down, the abstraction is an entity with hidden implementation details. To make the task not trivial, let's consider the dependency injection scenario. This may sound puzzling, but I hope it will provide a basis for a better understanding of the object-oriented programming concept. Especially I will pay attention to differences between the object-oriented programming and dependency injection pattern. By the pattern I men a programming archetype to solve a problem. By the way, I will remind you of such object-oriented programming terms as a class, interface, inheritance, implementation, etc. I will pay special attention to the text constructs that are characteristic of these terms. Not all languages provide exactly the same constructs but we can find many similar ones, so my hope is that this discussion will also help to understand selected fundamental concepts. We will come back to this topic many times throughout the course.

### 1.1.2. Object-oriented Programming Theory 🧑‍🏫

Object-oriented programming is considered a paradigm according to which the information processing algorithm is implemented using a graph of objects. Since we have a graph, it means that the objects are interconnected by relations, so they may create a custom structure. Objects do not have unique names, hence the only way to select one of them is to use these relationships to perform selective access operations - browse the graph. The graph navigation using these relationships is called browsing. However, the lack of the need to use unique names allows you to create objects freely as needed. From the point of view of the implemented algorithm, the object is a representation of the information under processing and functionality that can be applied to process this information representation - it means data. The objects are created in compliance with selected types. It means that any object may be an active element, I mean, operations may be associated with it.

### 1.1.3. Looking For Language Constructs 🧑‍🏫

This is a theory that has evolved a lot over the past years, so please treat it as a shortcut rather than an introduction to a serious discussion about object-oriented programming. This discussion is beyond the scope of the course, but it is important here how these principles of object-oriented programming were implemented in CSharp because some of them are crucial for further discussion. Here it should be noted that object-oriented programming talks about objects that are created in order to implement the algorithm. If we are talking about objects inevitably we are talking about the run-time lifetime phase of the program, not its design time. So this is the result of the programming process, which in the previous lesson we defined as the process of creating text according to the rules of a programming language, so CSharp in our case and in these categories, you have to look for relationships. Well, this is the design phase of the program, not the execution phase. So the task is as follows. We are looking for language constructs that we will use in the design phase of the program, in order to obtain the effect in the execution phase as described previously, i.e. the object-oriented programming paradigm.

### 1.1.4. Objects Graph 🧑‍🏫

Since in the execution phase we are to obtain a structure of objects in which the objects are related to each other by relations, we have to talk about reference data. As we know from the previous lesson, data is formally described by types. The flagship representative of the reference type group is, of course, the class. Here, as part of your homework, please recall at least two other types that also belong to this group. I will talk about both of them later in the course. Class definition, type declaration, and the new keyword allow you to create dynamically objects as needed and assign references to build practically any structure of objects at run-time. A reference is a one-way relationship that can be used to selectively access the created objects, I mean the components of the structure, components of the graph. Since a class is a type, it is a linguistic construct that allows you to define a set of allowable values ​​and operations on them. This fulfills the other requirements of the object-oriented programming paradigm outlined above. We'll discuss others in the context of CSharp to avoid any general and abstract discussion.

### 1.1.5. Information Model and Object Model 🧑‍🏫

Classes, followed by the objects that are their instances, make it possible to build an information model. Because at run-time, it contains a graph of objects it can be called also an object model. Here we must notice that in spite of the model name (I mean relationships) are added to the classes at design time. At run time we have an instance of the information model. This information model instance may be modified dynamically by adding and removing objects to the graph. Dynamically means that the graph could change according to the needs as a result of information processing at run-time but it cannot be called dynamic programming. Dynamic programming will be described later in detail and refers to situations where we must deal with unknown types in advance at design type.

### 1.1.6. Example Description 📋(SC) ( => dependency injection)

But from the previous lesson, we know that the same information could be represented by different data, and therefore the operations performed on that data could be different. In our example, we have a scenario in which we assume the need to validate an implementation of an algorithm. To make the example more engaging let's evaluate the correctness of the usage of a selected class. In the ConstructorInjection class, we have several methods named Alfa, Bravo, Charlie, Delta, and our job is to control the sequence in which they are called. For this purpose, in each method, we call an instance method of an object whose reference is assigned to the private m_TraceEngine field. This operation is executed while calling this class constructor. Consider two examples of using this class. First,  as part of a hypothetical general-purpose library referred by in a console application. The second is unit testing. It is easy to guess that validation for these two examples must be implemented differently.

### 1.1.7. Polymorphism 📋(SC)

For a console application, we can use the user interface and engage the user to perform a final assessment. For the unit test, we don't have the user interface and the result must be evaluated without user intervention. From this example, we can learn that our solution requires a polymorphic approach. You may implement polymorphism using abstraction and inheritance. I used abstraction to define the type of the m_TraceEngine field of the class. In this language, we call it field of class but in general, it is just a variable, I mean value holder. Abstraction means that we are hiding implementation details. We know that the object referred to by this variable has the TraceData method, and the signature is defined by an interface. Finally, we are calling a method but we are not aware of its implementation details. At run time when we are talking about objects, all implementation must be defined by the object creator, but the implementation could be different depending on the user's needs. The interface is abstract because doesn't provide any implementation details and can be recognized as a contract between the class ConstructorInjection and any user of this class, I mean any creator of this class. According to this contract, there are two clear roles. First is the interface user. In this case, it is the ConstructorInjection class. The second is the implementation provider, and in this case, it is a console application or a unit test. To create an object a concrete class must be derived from the contract, and this scenario we call inheritance.

### 1.1.8. Calling Abstract Method 📋(SC)

Here we can see that the `m_TraceEngine` field returns some object, but its type has been declared as an interface offering one method. If the object used contains data, we do not assume what. Here, however, we indicate that the object must perform the `TraceData` operation, but again we should not assume how this operation works. As I said it is just a kind of contract. We only specify a formal declaration containing formal arguments because we define only the header of the method called the signature. As a result, the declaration is there, but it hides (or it rather doesn't provide) implementation details and that is why we call it abstract declaration. This does not prevent you from using it and calling it, passing to it the current values ​​of its arguments in accordance with the declared signature.

### 1.1.9. Notes on Interfaces 📋(SC)

Using ALT-F12 we may get the Interface definition. From this example, we may notice that it is like abstract classes. It is worth noting that interfaces cannot be used to create objects. In this example, it is not possible to create an `.......` object in the `.....`. One of the reasons is that Interface methods do not have a block (body) - the body is provided by the class that implements the interface. On implementation of an interface, you must override all of its methods.  Interface methods are by default abstract and public. An interface cannot contain a constructor (as it cannot be used to create objects). Simplifying we may say that an Interface has only declaration - it is like an announcement of implementation in the derived classes.

### 1.1.10. Command line application 📋(SC)

I'll come back to unit tests shortly, but now let's examine an example of tracing process implementation to be used by the console application. The result on the screen we can observe by running the console application. As you can see, the result is four messages displayed on the screen, which can then be used to determine the sequence of methods calls and to diagnose manually the correctness of this sequence. This behavior is provided by this custom implementation of the interface. The object of this class is created and assigned to the constructor of the ConstructorInjection class. The question is if this solution is entirely based on an object-oriented programming paradigm. Lest analyze in detail all the code parts in concern. Here we have abstraction. To the parameter of the abstract type, we are assigning a reference to the object created using the class derived from the interface using inheritance. Concluding, everything looks like covered by object-oriented programming.

### 1.1.11. User Interface Problems

In this solution, we can indicate several important problems related to this implementation. In a production environment, such displaying of diagnostic information on the screen for the user may be useless, because he doesn't know the correct sequence, or he doesn't know the meaning of these messages, or a user doesn't care about the diagnostic information - the program should be correct and that's it. Today, for the production environment, we usually use a graphical user interface. In this case, displaying several diagnostic lines of messages is not a good idea in general. Let's add that unit tests do not have UI support, so displaying anything to the user is useless. Summing up, we can see that the discussed solution is not practical, although on-screen diagnostics has always been a favorite approach for novice programmers, because only lack of experience explains the thoughtless omission of the issue in which there are, for example, several thousand lines.

### 1.1.12. Implementation in the library

Of course, we can implement all variants in the library that will provide the appropriate functionality for each of the cases mentioned. To avoid using our imagination let me try to expand this example and implement the interface locally. I am creating MyClass that inherits the ITraceSource interface. Using the context menu we may implement this interface to create a concrete class that can be used by the ConstructorInjection class. In this case, the object used for the diagnostic purpose can be created locally and the argument race engine may be omitted. To support variants the type of argument may be replaced by enumerations allowing to select a predictable at design-time variant. For sake of simplicity, this case is omitted. The code is kept as simple as possible. Of course in this case the defined class doesn't implement any real functionality - it just throws the not implemented exception. I will try to prove shortly that it is a bad solution.

### 1.1.13. Portability Problem

This approach - I mean local implementation of the diagnostic functionality - is only possible if we could predict all behaviors we will need in the future. The future time - that I have used in the previous sentence - suggests that it is impossible or at least impractical because I immediately think of a few other ideas on how such diagnostics can be implemented in a different way, for example saving diagnostic messages to a file, or maybe logging the diagnostic information to the cloud, and there is also a database that may be considered. Let's add that the implementation of the logging mechanism on the screen inside the library will result in the necessity to answer the next question: what technology to use, for example, console application as in the example, Windows Presentation Foundation, or Forms in case of Windows operating system. But in general, it is devastating for portability because it is probable that the technology doesn't exist on the target execution platform.

### 1.1.14. Distributing Testing Fixture

It is beyond the course scope but is worth stressing now that the diagnostic information may be generated for testing or maintenance purposes. If the main goal to create the diagnostic information is testing everything that is not necessary should be removed from the library to avoid distributing useless code for the production environment. For example, the implementation of the interface `...` that is defined in the code should be located outside of the library assembly to minimize its memory footprint and execution time. Before considering the local implementation of the diagnostic information logging, first, we must answer the question of if this functionality is required in the production environment. Again, if the main purpose is to engage this functionality as the testing fixture we must avoid implementing it as part of the library to avoid distributing useless functionality for the end-user. In this case, the local implementation should do nothing as in the example. Now we can use this class as default implementation instead of throwing the argument null exception if the input attribute is null.

### 1.1.15. Abstractions

In CSharp, we have two constructs that allow abstractions to be declared, namely the abstract class and the interface. As part of your homework, please compare the features of both language constructs and consider one simple selection condition, let's add one that will allow you to choose one of them in practice. Please remember that conditions such as clearer, more convenient, more effective are abstract conditions because they do not define a measure that can be used to compare and define the selection condition, so they hide the implementation details. As we can see, abstraction occurs not only in a programming language but also in a natural language. The condition should be like this: because it is impossible to apply, I mean there is no alternative and equivalent solution.

### 1.1.16. Inheritance

During the program execution phase, the expected algorithm must be implemented. This can only be ensured by creating objects from concrete types, so only objects with all implementation details can be created. In the considered example for this interface, it is necessary to declare a new type that will provide this interface implementation. Using the navigation let's look for all references. On the list we get, we have a few suggestions, but let's choose the one that relates to the project of the previously launched sample console application. Here we see this relationship where the new type is defined with the use of the source type. We call this relationship inheritance, the source type is called the base type, and the newly created type we call the derived type. There are other names, but I will use these consequently. In the newly created concrete class, all abstract declarations must be refined in such a way that the missing implementation details are provided. In our case, the block is missing in the TraceData method, which we add here to the signature of the method inherited from the interface. We call this process the abstraction implementation. As a side note, a block is a sequence of instructions separated by a semicolon - sometimes it is also called body for some reason.

### 1.1.17. Object Creation (dependency  injection) 📋(SC)

In order for our example to be finished, it is still necessary to specify what specific object implemented the tracing functionality is to be used in the library. Previously, I used a very broad statement, namely: some object whose reference is assigned to a field. So now is a good time to clarify this statement. This field is initialized in the class constructor using the current value of this argument. The creation of an object of this class can be found again by using the navigation available in the context menu and looking for all references to this constructor. An object of this class is created in the sample program and a reference to it is passed to the constructor of the library class from which the methods of its instance are called in the sequence. In this case, the reference to the created object becomes the current argument of the constructor.

### 1.1.18. No Polimorfizm 📋

In this example, we started with a polymorphism that was shown as a problem to solve, and then we applied the object-oriented programming paradigm including abstraction, inheritance, and implementation to solve it. Well, as a result, we do not have polymorphism. In this particular case, there is no diversity, the program always behaves the same. What's more, there is even no need to use a variant solution, because its behavior is not even parameterized. Is the use of the entire object-oriented programming engine redundant then?

### 1.1.19. Dependency Injection

Of course, answering this question we say no it is not a redundant approach because we must take into account the fact that the driving force behind our approach and the problem to be solved was the need to take into account polymorphism in future solutions, and not only in a specific solution, I meant in the library itself. The word "future" is the most important because it means that where the object is referenced, its type is unknown because its definition will be compiled later. And it doesn't matter if it's a few milliseconds later or years later. I named this pattern described here dependency injection to somehow terminologically distinguish the situations of using object-oriented programming to implement a potential polymorphism and using it to create variant local solutions. Concluding, in this scenario, we deal with the separation of concerns. One is the usage, and the second is implementation. Hence, shortly the dependency injection is a pattern where we are using unknown for some reason type that we replace by abstraction. Here the type is located in an independent assembly so cannot be referenced directly to avoid circular references between assemblies. Later, while discussing layered program architecture, we will learn the next example where direct access to the concrete type is impossible and must be replaced by abstraction. Shortly, the dependency injection is a pattern we must apply in any scenario where we cannot use the new operator in the place of use to create an object because the type is or shall be unknown for some reason.

### 1.1.20. Automation of Dependency Injection

Those who have already heard about dependency injection may be concerned that this sounds like an introduction to an entirely different course. In fact, the concerns are justified, because many publications have already been written about dependency injection, many frameworks, and derivative terms, for example, Inversion of Control, Container, and so ones. Without going into terminological disputes and not deciding whether these publications and solutions are about dependency injection itself, or rather the automation of dependency injection, ~~in the next lessons, I will try to use the outline of the pattern presented here to solve other fundamental problems, and by the way, we repeated the basics of object-oriented programming~~.

### 1.1.21. Type concept

#### 1.1.21.1. Built-in types

Simplifying, the type definition may be recognized as the definition of two sets. First set determines all values that belong to the type. In other words, the values are compliant with the type. In most languages, some additional grouping of types kind is engaged. The language defines built-in types and this group is not relevant to us because it depends on the programming language definition, but not the features of a type. C# is not an exception. This language also contains a variety of types that may be used immediately without bothering about the definition source. Examples belonging to this group are int, double, etc.

#### 1.1.21.2. Simple types

In spite of the definition origin, types may be grouped as simple, complex, and structural types. The prevailing feature of simple types is that the values defined by the simple types are processed as one whole even if the type by design contains parts. An example is the floating-point values of the double type containing mantissa and exponent - two related numbers representing one rational number. The second example is the `Roman` type previously defined.

#### 1.1.21.3. Complex and structural types

Complex types contain embedded parts but thanks that the relationship between these parts is well known in advance a selector operation can be defined. Examples of these kinds of types are array and record. To select and process a part (value) contained by the array an indexer can be used. In C#, the record is implemented as the class or structure types. In this case, it is possible to select the value member identified as the unique identifier.

#### 1.1.21.4. Structural types

Last but not least are structural types. In this case, by design the relationship between parts is custom.  Typical patterns used to greater structural dada are tree, stack, and stream, to name only a few. Because the structure is also subject to the design there is no one generic selection operation, hence instead of selecting we are using a browsing operation. To enable definition types to allow designing custom structures reference types are introduced in many languages.

## 1.2. Research

- consider removing dependency injection from this lesson
- consider removing general discussion related to the type concept
