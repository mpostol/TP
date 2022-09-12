# 1. Object-oriented programming

## Table of content <!-- omit in toc -->

- [1. Object-oriented programming](#1-object-oriented-programming)
  - [1.1. Script ✍🏻](#11-script-)
    - [1.1.1. Topic introduction](#111-topic-introduction)
    - [1.1.2. What's the problem?](#112-whats-the-problem)
      - [1.1.2.1. Main bullets 🖥️](#1121-main-bullets-️)
      - [1.1.2.2. Custom Structure of the Complex Data](#1122-custom-structure-of-the-complex-data)
      - [1.1.2.3. Polymorphism as a problem ✍🏻](#1123-polymorphism-as-a-problem-)
      - [1.1.2.4. Invisible types ✍🏻](#1124-invisible-types-)
    - [1.1.3. Structural types](#113-structural-types)
      - [1.1.3.1. Introduction](#1131-introduction)
      - [1.1.3.2. Object-oriented Programming Theory 🧑‍🏫](#1132-object-oriented-programming-theory-)
      - [1.1.3.3. Looking For Language Constructs 🧑‍🏫](#1133-looking-for-language-constructs-)
      - [1.1.3.4. Objects Graph 🧑‍🏫](#1134-objects-graph-)
      - [1.1.3.5. diamond pattern 📋](#1135-diamond-pattern-)
      - [1.1.3.6. Information Model versus Object Model 🖥️](#1136-information-model-versus-object-model-️)
    - [1.1.4. Polymorphism](#114-polymorphism)
      - [1.1.4.1. Topic introduction](#1141-topic-introduction)
      - [1.1.4.2. Abstraction Implementation 📋(SC)](#1142-abstraction-implementation-sc)
      - [1.1.4.3. Calling Abstract Method 📋(SC)](#1143-calling-abstract-method-sc)
      - [1.1.4.4. Notes on Interfaces 📋(SC)](#1144-notes-on-interfaces-sc)
      - [1.1.4.5. Abstractions (must be moved somewhere)](#1145-abstractions-must-be-moved-somewhere)
      - [1.1.4.6. Inheritance](#1146-inheritance)
    - [1.1.5. Invisible Types](#115-invisible-types)
  - [1.2. Research](#12-research)
    - [1.2.1. Terms to be used](#121-terms-to-be-used)
    - [1.2.2. Diamond structure](#122-diamond-structure)
    - [1.2.3. See Also](#123-see-also)

## 1.1. Script ✍🏻

### 1.1.1. Topic introduction

In my opinion, a key to a good understanding of the course is understanding the object-oriented programming concept. Hence, I gonna spend a short amount of time recalling this concept. I will remind you of such object-oriented programming terms as class, interface, inheritance, implementation, polymorphism, etc. I will pay special attention to the constructs that are characteristic of these terms. I want to stress that not all programming languages provide exactly the same constructs but we can find many similar ones, so my hope is that this discussion will also help to reuse the knowledge and port it to other languages if needed. We will come back to this topic many times throughout the course.

### 1.1.2. What's the problem?

#### 1.1.2.1. Main bullets 🖥️

- Custom structure of data
- Polymorphism
- Invisible Types

Usually learning a new programming concept we may find entry questions like this if you need for example object-oriented programming you may use class and interface constructs. I propose the opposite direction against learning the object-oriented programming concept. We start defining real problems that can be solved using this programming concept.

#### 1.1.2.2. Custom Structure of the Complex Data

The first problem we could have is how to process complex information composed using parts interconnected by associations according to a custom pattern. This way we must deal with a graph of entities where both the value of entities and the shape of the graph are meaningful in the context of the information processing process. For example, typical shapes we must deal with are streams, trees, stacks, and diamonds to name only a few. Usually, programming languages support selected complex types representing the typical relationships between parts, like arrays, and records. Thanks to that the relationship between these parts is well known in advance a default selector operation can be defined. To select and process a part (value) contained by the array an indexer can be used. In C#, the record concept is implemented as the class or structure types. In this case, it is possible to select the member using dot operation and the unique in the context of the type identifier of the member - both make a qualified name. To deal with any custom pattern that is not directly supported by the programming language we may apply object-oriented programming to implement structural types. Structural type means that using it we can model any pattern we need to implement an algorithm in concern. I used the word "model" instead of "create" because at design time we may only define types that may be used to create a graph at run-time using this model. From the examples - I am going to discuss - we will see that the pattern is only a template, it is only a limitation, and may be recognized as a bit of advice for further processing. Because the structure is also subject to the design there is no one generic selection operation, hence instead of selecting we are using a browsing operation.

#### 1.1.2.3. Polymorphism as a problem ✍🏻

- polymorphism that was shown as a problem to solve

#### 1.1.2.4. Invisible types ✍🏻

- we cannot use the new operator in the place of a type use to create an object because the type is or shall be invisible

### 1.1.3. Structural types

#### 1.1.3.1. Introduction

At the very beginning, I wanna recall object-oriented programming concept fundamentals. I assume that it is not your first touch with this concept and you have background knowledge or some experience related to object-oriented programming learned during the course on introduction to programming or programming fundamentals. Today most programming languages support this concept somehow. This concept is also addressed by a vast variety of independent courses. Therefore, we start our journey in the context of the first problem, namely how to apply object-oriented programming to finally make possible creation of a graph of objects according to a custom pattern.

#### 1.1.3.2. Object-oriented Programming Theory 🧑‍🏫

Object-oriented programming is considered a paradigm according to which the information processing algorithm is implemented using a graph of objects. Since we have a graph, it means that the objects - parts of the graph - are interconnected by relations, so they may create a custom structure. Objects do not have unique names, hence the only way to select one of them is to use these relationships to perform selective access operations. The graph navigation using these relationships is called browsing. However, the lack of the need to use unique names allows you to create objects freely as needed. From the point of view of the implemented algorithm, the object is a representation of the information under processing and functionality that can be applied to process this information representation - it means data. The objects are created in compliance with selected types. It means that any object may be an active element, I mean, operations may be associated with it.

#### 1.1.3.3. Looking For Language Constructs 🧑‍🏫

This is a theory that has evolved a lot over the past years, so please treat this lesson as a shortcut rather than an introduction to a serious discussion about object-oriented programming. This discussion is important here how these principles of object-oriented programming were implemented in CSharp because some of them are crucial for further discussion. Here it should be noted that object-oriented programming talks about objects that are created in order to implement the algorithm. If we are talking about objects inevitably we are talking about the run-time phase of the program lifetime, not its design time for sure. So this is the result of the programming process, which in the previous lesson we defined as the process of creating text according to the rules of a programming language, so CSharp in our case and in these categories, you have to look for relationships. Well, this is the design phase of the program, not the execution phase. So the task is as follows. We are looking for language constructs that we will use in the design phase of the program, in order to obtain the effect during the run time phase as described previously, i.e. the object-oriented programming paradigm.

#### 1.1.3.4. Objects Graph 🧑‍🏫

Since in the execution phase we are to obtain a structure of objects in which the objects are related to each other by associations, we have to talk about reference data. As we know from the previous lesson, data is formally described by types. The flagship representative of the reference type group is, of course, the class. Here, as part of your homework, please recall at least two other types that also belong to this group. I will talk about both of them later in the course. Class definition, type declaration, and the `new` keyword allow you to create dynamically objects as needed and assign references to build practically any structure of objects at run-time. A reference is a one-way associations that can be used to selectively access selected objects, I mean the components of the structure, components of the graph. Since a class is a type, it is a linguistic construct that allows you to define a set of allowable values ​​and operations on them. This fulfills the other requirements of the object-oriented programming paradigm outlined above. We'll discuss others in the context of CSharp to avoid any general and abstract discussion.

#### 1.1.3.5. diamond pattern 📋

Using object-oriented programming we can create practically any structure of objects at run-time. Let's see how it works on a concrete example. In this example of classes, a diamond pattern has been implemented as a set of classes. This patter is not very popular but I selected it because it is well defined. Suppose that the final graph is to contain four interconnected nodes, named top, left, right, and bottom. The nodes have been implemented using the classes with names resembling positions in the patterns. Finally, the shape like a diamond may be instantiated. Check out the unit tests to learn how the diamond graph of objects is instantiated at run time. Not always objects structures at the run time must be exactly the same as a structure of classes related to each other. Partially it may be overcome. In the examined examples the constructor requires arguments pointing to the appropriate nodes depending on the planned position in the graph.

#### 1.1.3.6. Information Model versus Object Model 🖥️

Classes related to each other, followed by the objects that are their instances, make it possible to build an information model. Because at run-time, it contains a graph of objects it may be called also an object model. Sometimes we can get an opinion that the object model is an information model expressed using the object-oriented concept. I propose to skip this academic discussion. Here we must only notice that in spite of the model name (I mean relationships) placeholders for references to create a demanded pattern are added to the types at design time. At run time we have to deal with an instance of the information model instantiated as a graph of objects. This information model instance may be modified dynamically - I mean at on demand, any point in time - by adding and removing objects at any point in time to the graph using references. In other words, dynamically means that the graph could change in time according to the needs as a result of information processing at run-time but it cannot be called dynamic programming. My point is that dynamic programming refers to situations where we must deal with unknown types in advance at design type. In this approach, the information model that is designed at the design time may be used as the graph pattern at rub time.

![Diamond Information Model](DiamondInformationModel.png)

### 1.1.4. Polymorphism

#### 1.1.4.1. Topic introduction

**Refine**: Inheritance, together with encapsulation and polymorphism, is one of the three primary characteristics of object-oriented programming. Inheritance enables you to create new classes that reuse, extend, implement, and modify the behavior defined in other classes. The class whose members are inherited is called the base class, and the class that inherits those members is called the derived class. A derived class can have only one direct base class.

**Encapsulation**: refers to a definition's ability to hide the visibility of the properties, methods, and other members that intentionally shall not be referred to outside of this definition.

#### 1.1.4.2. Abstraction Implementation 📋(SC)

From this example, we can learn that our solution requires a polymorphic approach. You may implement polymorphism using abstraction and inheritance. I used abstraction to define the type of the `...` field of the class. In this language, we call it field of class but in general, it is just a variable, I mean value holder. Abstraction means that we are hiding implementation details. We know that the object referred to by this variable has the `...` method, and the signature is defined by an interface. Finally, we are calling a method but we are not aware of its implementation details. At run time when we are talking about objects, all implementation must be defined by the object creator, but the implementation could be different depending on the user's needs. The interface is abstract because doesn't provide any implementation details and can be recognized as a contract between the class _ConstructorInjection_ and any user of this class, I mean any creator of this class. According to this contract, there are two clear roles. First is the interface user. In this case, it is the _ConstructorInjection_ class. _The second is the implementation provider, and in this case, it is a console application or a unit test._ To create an object a concrete class must be derived from the contract, and this scenario we call inheritance.

#### 1.1.4.3. Calling Abstract Method 📋(SC)

Here we can see that the _m_TraceEngine_ field returns some object, but its type has been declared as an interface offering one method. If the object used contains data, we do not assume what. Here, however, we indicate that the object must perform the `...` operation, but again we should not assume how this operation works. As I said it is just a kind of contract. We only specify a formal declaration containing formal arguments because we define only the header of the method called the method signature. As a result, the declaration is there, but it hides (or it rather doesn't provide) implementation details and that is why we call it abstract declaration. This does not prevent you from using it and calling it, passing to it the current values ​​of its arguments in accordance with the declared signature.

#### 1.1.4.4. Notes on Interfaces 📋(SC)

Using ALT-F12 we may get the Interface definition. From this example, we may notice that it is like abstract classes. It is worth noting that interfaces cannot be used to create objects. In this example, it is not possible to create an `.......` object in the `.....`. One of the reasons is that Interface methods do not have a block (body) - the body is provided by the class that implements the interface. On implementation of an interface, you must fully define all of the methods declared by the interface. Interface methods are by default abstract and public. An interface cannot contain a constructor (as it cannot be used to create objects). Simplifying we may say that an Interface has only declaration - it is like an announcement of implementation in the derived classes.

#### 1.1.4.5. Abstractions (must be moved somewhere)

In CSharp, we have two constructs that allow abstractions to be declared, namely the abstract class and the interface. As part of your homework, please compare the features of both language constructs.

#### 1.1.4.6. Inheritance

> Example must be prepared

During the program execution phase, the expected algorithm must be implemented. This can only be ensured by creating objects from concrete types, so only objects with all implementation details can be instantiated. In the considered example for this interface, it is necessary to declare a new type that will provide this interface implementation. Using the navigation let's look for all references. On the list we get, we have a few suggestions, but let's choose _the one that relates to the project of the previously launched sample console application_✍🏻. Here we see this relationship where the new type is defined with the use of the source type. We call this relationship inheritance, the source type is called the base type, and the newly created type we call the derived type. There are other names, but I will use these consequently. In the newly created concrete class, all abstract declarations must be refined in such a way that the missing implementation details are provided. In our case, the block is missing in the TraceData method, which we add here to the signature of the method inherited from the interface. We call this process the abstraction implementation. As a side note, a block is a sequence of instructions separated by a semicolon - sometimes it is also called body for some reason.

### 1.1.5. Invisible Types

## 1.2. Research

### 1.2.1. Terms to be used

- Polymorphism is often referred to as the third pillar of object-oriented programming, after encapsulation and inheritance.
- Abstract and virtual members are the basis for polymorphism, which is the second primary characteristic of object-oriented programming. For more information, see Polymorphism.
- Derived classes that aren't abstract themselves must provide the implementation for any abstract methods from an abstract base class.
- **Preventing further derivation**: A class can prevent other classes from inheriting from it, or from any of its members, by declaring itself or the member as sealed.
- work in an uniform way
- suppose you ...
- keep truck
- compile time; run time, design time
- constructors aren't inherited.

### 1.2.2. Diamond structure

Consider implementation

a-> b, c -> d

### 1.2.3. See Also

- [Polymorphism](https://docs.microsoft.com/dotnet/csharp/fundamentals/object-oriented/polymorphism)
