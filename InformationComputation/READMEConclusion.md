# Conclusion

## Preface

I want to review the learning outcomes and idea exchange related to the information computation course during this lesson. It is a kind of recap of the course learning outcome. The main goal of the course was to concentrate on learning - it means concentration on knowledge (concepts, standards, best practices, etc) adoption. I focused on learning rules related to information computation but not training in a particular language or development tool. We started with the statement that the course title - that is information computation - is a bit provocative because information - as a kind of knowledge - is abstract and cannot be directly processed by a physical computer even if a computer and implemented algorithm make up a powerful artificial intelligence bot that is capable of understanding human speech and producing in-depth writing that humans easily understand. While learning, we distinguished process information and algorithm terms. The process information describes the state and behavior of a process in concern. In turn, the algorithm is a kind of knowledge to be deployed to solve problems related to this process. Together both are indispensable to employing a computer to automate this process of information processing using a device. As usual, I will start with a short introduction to problems related to information computation we must face up.

## Information Computation Fundamentals

### Information representation fundamentals

Concluding the section titled **Information Computation Fundamentals** I stated that applying information technology could be very helpful for human beings to improve the performance and robustness of their activity. It is a result of the automation of information computation. Unfortunately, process information is an abstraction and, hence, cannot be processed by a physical machine, including but not limited to computers. This inconsistency can be overcome by applying coding systems. In reality, this way, we are computing the data but not the information.

### Algorithm implementation

To accomplish benefits from processing data by a machine we must employ technology. We need a driving force - an engine - to realize the processing. Today it is a binary computer. In the context of information computation, we must deal with two kinds of information: process information and algorithm. The process information describes the state and behavior of a process in concern. In turn, the algorithm is a piece of information on how to solve the selected problem. We stated that both are tightly coupled and must be represented together using a programming language, which is suitable to be used as a recipe of the computer behavior and information representation of a process in concern.

### Programming language fundamentals

In other words, computers are programmable devices and need a kind of program to be controlled. The computer world is binary. It means that to be controlled they require a binary program. Today, typically we use high-level languages that are based on an alphabet derived from the Latin alphabet. Syntax of these languages is founded on keywords borrowed from the natural English language and semantics supports object-oriented programming concept. It was emphasized that modern languages use the type concept to describe process information representation and algorithms implementation consistently. To obtain a binary version of the computer program a kind of compiler is required.

## Information representation

### Type versus Coding System

Let me stress again, the coding system is replaced by the type notion that is well known and widely accepted concept offered by practically all modern programming languages. On the other hand, we have to recognize the type definitions as a part of a programming language, that is set of syntax rules and associated semantics rules governing a text to express the type definition. How to use types is a good question for an independent course related to fundamentals programming. Still, it is partially covered by the second section of this course titled information representation. Text is a string of characters. This idea was explained during the lecture Coding System Versus Type in this section. Hence, as a software developer instead of selecting or even creating an appropriate coding system, you must deal with types. Types are also used to control the program consistency if the programming language is strongly typed. Type is an embedded notion of modern programming languages.

### Custom Types

Because the type determines a set of values, the main idea behind custom types is the possibility to represent practically any information to be processed by a computer. To fulfill your duty you must define new types addressing the custom information computation needs. Using modern programming languages, new types may be defined from scratch or derived from existing ones. Any type implicitly or explicitly specifies also the set of operations that can be applied to these values.

### Object-Oriented Programming

Object-oriented programming is well known and widely accepted programming concept allowing to solve polymorphic problems and organizing interoperability of software program parts using abstraction, inheritance, and encapsulation. We recognized this abstraction as a kind of contract used to harmonize the development process of the software program parts at design time.

### Selected Type Definition techniques

#### Type Definition Techniques - Preface

In the sections Anonymous Types, Partial Definitions, and Generic Types and Methods we learned a variety of program text management techniques related to the type definitions. Let's conclude what learned.

#### Anonymous types

As a result of using Anonymous Types, the compiler infers type definition from the expression evaluated as a value. The most important feature of this approach is that the entire set of values belonging to a type is defined based on one selected value. Anonymous types are characterized by the fact that when defining a new anonymous type, we cannot define specialized operations for it that can be applied to process values of this type. Another feature of this kind of type is that it defines a sequence of key-value pairs. These two characteristics indicate that this type is particularly well suited to represent external data. In other words, external data has no type in the sense we use in the programming language. As a rule of thumb, for external data, operations are performed outside of the process hosting the programming realm, so they cannot be used locally.

#### Partial Definitions

Limiting the scope of our discussion only to methods applicable at design time we know that for the strongly typed programming languages, the type of a variable may be devised by a developer or inferred by the compiler. We must keep in mind that there is a next option. Another possibility is an auto-generation of the required data type definition from metadata using a development tool. Converting some metadata defined in any form to a definition expressed using any programming language always produces text. Let me remind you that at the beginning of the life cycle, any program is just a text that has to be compliant with the syntax and semantics of the selected programming language. Therefore, to be precise, we are talking about text management, that is writing, modifying, and merging text in various circumstances. Partial Definitions are used to blend autogenerated text with the custom ones finally making up a type definition as one whole. It is a text management engineering in the context of the type definition syntax.

#### Generic Types and Methods

We know that the possibility of reusing the outcome of previous programming work is extremely important. It improves economic efficiency, is beneficial for reliability, and minimizes training costs. We also know that the type concept is extremely important for modern programming languages. The generic definition concept allows for types definition by applying parametrized templates. Therefore, the generic definitions expand object-oriented programming somehow and consequently extend our possibilities of reusing the previous results. This, as we know, decreases the total costs of software development. The main idea behind using the generic types and methods is the possibility to define types as a result of applying parametrized templates to generate the final type definition instead of the definition of a concrete type. We may use the template to define new concrete types provided that the formal parameters of the template are replaced by names of concrete types. Again, the idea is to use a parameterized template of a type definition instead of the concrete one. Hence this method of type definitions may be recognized as the text management functionality involved at design time.

## Algorithm Implementation

### Algorithm Implementation Preface

Process information representation and algorithm implementation are tightly coupled but following the previous discussion divided to cover topics related to the design of types and the design of a program as one whole. The second part titled `Algorithm Implementation` covers the following examples and associated explanation:

### Program Layered Architecture

#### Program Layered Architecture - Preface

The main goal of the lessons titled Program Layered Architecture was to learn more about the architecture of the computer program in the context of typical functionality and the development time cycle. A computer program begins its life cycle as a text that follows the rules of a selected programming language. To decrease the cost and improve the performance of the program development process, the text of the program is often organized into autonomous fragments addressing typical functionality or issues. There are many design patterns applicable to help solve typical issues but the layered model is well-suited to be applied to the program archetype as one whole.

#### Parts Separation

The program development should be commenced by researching knowledge helpful to solve a problem in concern or achieve the computation goal. This knowledge as one whole we call algorithm. The algorithm is the foundation of the software development process. The separation of concerns is a very useful concept while working on software development in general and particularly on algorithms. From sociology we know, that separation of concerns improves our performance of thinking because thanks to the separation of concerns we may think about independent topics with minimal overlapping between them. So to improve our productivity at software design time we must leverage separation. It is important because by improving productivity we are decreasing development costs and probability of the failure in the long run. Finally as a result we are reducing development costs. The main challenge is to answer the question of when and where we should deal with the separation of concerns - while thinking about the solution or while implementing it as a text. The only thing that is out of the discussion is that it is very beneficial to apply separation of concerns.

#### Benefits

During the classes related to program layered architecture, we stressed that thanks to layers the following benefits may be accomplished: separation of concerns, simultaneous development, independent testability, adoption of technology change, scalability

Concluding, all of them make development faster, more reliable, and finally cheaper.

#### Typical archetype

Usually talking about a layered design pattern applied to the program as one whole we may distinguish three layers: the presentation, logic, and data layers as follows:

- Presentation - is responsible for managing the communication with the user using typically the graphical interface
- Logic - is responsible for the implementation of a dedicated algorithm related to the process in concern
- Data - is responsible for accessing data representing the process state and behavior information typically managed by the file system, computer network, custom communication interfaces, and databases to name only the most common

We concluded that this design pattern is clear and doesn't need any special education background or explanation to understand it. Hence, it should be used for further development.

![figure 1](../InformationComputation/.Media/2109-0302-ProgramLayeredArchitecture-Script-Layers.png)

### Deployment

Languages offering object-oriented programming usually use the custom types definitions as building blocks that take responsibility for implementing the algorithm in concern. Based on the discussed examples I proposed using sets of custom-type definitions to implement the layers. When it comes to explaining what a layer is within the framework of a programming language, here's a breakdown: it's essentially a group of type definitions that belong to a specific set. These definitions must either be self-contained within the layer itself, or they can refer to declarations that are visible in the layer directly beneath it. In other words, the top-down relationship means that the layer above only refers to the declarations available by the layer below. In maths, sets are a collection of well-defined entities called members of the set. In the proposed implementation scenario the well-defined entity is a custom type - a language construct. The set concept is derived from the mathematical theory and is well-known from primary school education, hence we may skip dip dive into this theory. The only important thing is how to recognize the membership. There must be a boundary that we can use to distinguish if a type belongs to the selected set or not. To make the layer unambiguous it must be assumed that any type belongs only to one set, to one layer. This way we can convert the discussion about mathematical sets to the examination of types grouping.

### Inter Layers Communication

#### Inter Layers Communication Preface

The main goal of the lesson titled Inter-layers Communication is to learn more about how to implement the bidirectional communication of layers. We know that, by design, the layered program architecture means its organizations, in which we can distinguish independent entities of a program related to each other making a top-down hierarchy. The distinguishing feature of a layer is that all definitions belonging to a layer are self-contained internally in a layer or may refer only to the declarations visible from the layer directly below. In other words, the top-down relationship means that the layer above only refers to the declarations available by the layer below. We discussed it stressing that it is a compile-time pattern. At run-time, we must consider control flow and data flow in both directions for sure.

#### Communication Executive Summary

To ensure smooth operation, layers within a program must be interoperable. Interoperability means that different layers can work together seamlessly. Inter-layer communication can be categorized into control flow, data transfer, and event notification. Control flow pertains to the order in which program statements or method calls are executed. Data transfer refers to assigning a new value to a variable or property by a producer. Event notification involves alerting that a specific condition has been met. We've explored various examples of inter-layer communication, including properties, callbacks, events, reactive programming, invocation of methods, and dependency injection patterns. Some of these may also be referred to as inversion of control.  

**Invocation of Methods:** Invocation of methods can be considered the foundation for all other solutions because the implementation of inter-layer bidirectional communication - using this approach - is available since the very beginning of the software engineering era. By design, a method is a named block of code that contains a sequence of statements. In this pattern, the upper layer has to invoke the methods defined in the layer beneath it. It causes the execution of the sequence of statements.

**Callback:** One possible approach to implementing bidirectional communication between layers that have a unidirectional relationship is through the concept of callback methods. Essentially, a callback method is a reference to a method that is passed as an argument to another method. It can be thought of as a kind of method pointer, which can be used to execute a sequence of statements. Through this approach, a method can be invoked using variables, or formal parameters. This enables a sequence of statements to be executed by the layer below whenever bottom-up communication is required. Using this method, we can implement bottom-up notification and control flow, and also facilitate data transfer by providing all necessary parameters when invoking the method.

**Event:** One way to establish communication in both directions between layers that have a one-way relationship is by using events. To do this, the upper layer can offer a range of service methods that the lower layer can access through delegates, much like previous versions.

**Reactive Programming:** One potential method for enabling bidirectional communication between layers is through reactive programming. This design pattern enables the creation of a solution that can receive push-based notifications, relying on asynchronous programming logic to handle incoming updates from the upper layer.

**Dependency Injection:** In software design, dependency injection involves the use of abstraction rather than a specific target. This is because the target may not be visible in the intended location. To maintain the top-down layer dependency relationship, we can utilize this pattern for bidirectional inter-layer communication. Essentially, this design pattern is necessary for situations where we cannot create an instance of a reference type using the new operator at the intended location due to the type being invisible or restricted for some reason. However, through object-oriented programming, we can operate abstraction instead of a concrete type to overcome these challenges.

### Dependency Injection

#### Dependency Injection Preface

The main point of the dependency injection design pattern is an assignment to an abstract variable a reference of an invisible type that is derived from this abstraction and which cannot be instantiated at the intended location for some reasons. I named this pattern dependency injection to somehow distinguish the situations of using just object-oriented programming alone. In this scenario, we are using object-oriented programming to deal with the separation of concerns. One concern is the usage, and the second one is the implementation of a concrete type. Hence, shortly the dependency injection is a design pattern where we are using an abstraction in place of an unknown for some reason concrete reference type. This type must implement the mentioned abstraction.

#### Types Location

In the lower layer, it is necessary to use abstraction instead of a concrete-type definition to avoid the bottom-up relationship. Hence, we are considering moving the type definition to the upper layer to ensure the top-down dependency rule of layers. In this design pattern, we are applying the concept of object-oriented programming by using abstraction instead of a concrete type because the type is either not visible or should not be referenced for clear reasons.

#### Abstraction Employment

This particular design pattern implements abstraction to create an agreement between the creation and usage of an instance. The abstraction is employed to specify the property type (property injection) or the formal parameter of the instance method or constructor (method or constructor injection). This design eliminates the requirement for a specific definition of the concrete type in the program's intended location. The type can be instantiated at design time using the new operator or deferred until runtime using reflection.
