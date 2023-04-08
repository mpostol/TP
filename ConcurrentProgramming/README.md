# Concurrent Programming

## Program life cycle

### Design Time

At design time the computer program is developed to be compliant with a requirement specification. It includes selected algorithms implementation and testing. Implementation is a process of program text editing according to the selected programming language and development environment.

### Execution Time

A computer program is always executed in a surrounding context called an execution platform, for example operating system. One of the operating systems' responsibilities is to protect computer programs from each other by running each program in its own process. If a program fails, only that process is affected; programs wrapped by other processes can continue to perform. As a result addresses in one process have no meaning in another process. In the managed environment, application domains (or logical processes) and contexts provide a similar level of isolation and security at less cost and with a greater ability to scale well than an operating-system process.

## Sequential Programming

### Introduction

This section provides examples related to executing program instructions (statements) one by one in the order defined in advance at design time. Only patterns vital for the concept of concurrent programming have been selected. The original execution sequence may change as the result of applying control instructions and implicit concurrent programming.

It is worth stressing that in sequential programming concurrent programming is applied implicitly if ever.

### Dependency Injection (DI)

It is a programming pattern where the abstraction paradigm defined as a part of the object-oriented programming concept is applied to provide an instance of a concrete type when the type is not visible or shall be not referred to for some reason. In other words, the `new` operator is not applicable to create an instance in a location where this instance is to be used. The lack of possibility to deal directly with the concrete type in concern or deliberate avoiding direct access to this type for some reasons shall be recognized as a problem to be solved.

Below there are selected reasons why a concrete type is not visible or shall not be referred to in a program location:

1. the type in concern is defined in the programming layer above and shall not be used directly to comply with separation of concerns and responsibility rules
1. the type in concern is defined in the not referenced project, for example in the unit test project to provide testing data that must be not located inside of a shippable deliverable and as the result, the type is not visible
1. the type in concern will be defined later for some reason, for example, to avoid waiting for the final implementation when work is forked to be conducted simultaneously by independent developers
1. the type in concern is defined out of the current solution, for example, it is a part of a plug-in

### Inversion of Control (IoC)

It is a programming pattern that may be used to describe calling unknown methods because their implementation is not or should not be visible in the location where they are to be called. The following examples show typical scenarios

- an abstract method implemented elsewhere by a type that an instance is provided applying the dependency injection pattern
- a delegate object wrapping set of methods assigned elsewhere to an event or delegate variable

### GUI Interoperability (Reactive and Interactive User Interface)

**Interactive**:
It is a user of a computer and computer user interface interoperability pattern where one party of this interoperability triggers an action and expects a reaction from the other one. An example of this kind of interoperability is a mouse clicking on a virtual button on the computer screen and expecting a reaction from the program responsible to render this button on the screen. According to the definition, it is a blocking relationship, hence the round trip latency should be minimized to keep the user interface responsive and react smoothly to the triggered action.

**Reactive**:
It is a user of a computer and computer user interface interoperability pattern where one party of this interoperability triggers an action and doesn't expect a reaction from the other one. An example of this kind of interoperability is updating the current time on the watch control rendered on the screen. On the other hand, pressing a virtual button on the computer screen without any visual reaction is also reactive interoperability but it should be avoided because it makes the user interface nonresponsive - it could be recognized as no response to the user demand.

Because usually the GUI should be recognized as a critical section, its interoperability with any underlying activity must be synchronized. It depends on the framework used to implement the interoperability.

### Program Entities Interoperability

**Synchronous**:
It is a programming pattern to describe an interaction between a programming entity and a method called by it where the method is executed synchronously. In other words, the further execution of the calling entity is postponed until the called one has been finished. The concurrent programming concept deliberately is not applicable to implement this relationship.

**Asynchronous**:
It is a programming pattern to describe an interaction between a programming entity and an action called by it. The called action is executed simultaneously. In other words, the further execution of the calling entity is continued and synchronized with the called one after finishing. It requires concurrent programming.

- Task-based Asynchronous Pattern (TAP)
- Asynchronous Programming Model Pattern (APM)

**Interactive**:
It is a programming pattern to describe an interaction between programming entities where the selected one triggers an action and expects a reaction from another interoperable party. If the triggered action is non-blocking the interaction is called asynchronous, otherwise, it is called synchronous.

**Reactive**:
It is a programming pattern to describe an interaction between programming entities where the selected one triggers an action and does not expects a reaction from it. The triggered action must be non-blocking, which means that the interoperability action should last as short as possible. It is a one-to-many programming entity interoperability relationship. This programming pattern may be used to implement the publisher-subscriber pattern.

- Event-based Asynchronous Pattern (EAP)
- DataObservable
- TickEventArgs

## Concurrent programming

### Introduction to Concurrent programming

- **Concurrent programming**: performing operations as a result of nondeterministic events
- **Parallel Programming**: simultaneous execution of program operations
- **Real Time Programming**: the time must be taken into account as a factor determining the correctness of the program

### Multi-threading or concurrent programming

Both terms are used to refer to the programming pattern that allows writing a program to execute operations at run time as a result of nondeterministic events. Concurrency is when multiple sequences of instructions are run in overlapping periods of time. In other words, the instructions sequence execution is undetermined in advance. Thread is a type that may be used to represent a sequence of instructions in this scenario.

- RunMethodAsynchronously from mpostol/RealTime#33

### Resource sharing

- CriticalSectionExample

### Synchronization

- Hoare's monitor concept - MFT

### Communication

Real time library

## Distributed Programming - Network Nodes Communication (out of scope)

**Interactive**: It is a communication pattern to describe an interaction between communicating entities where the selected one triggers sending a request and expects a response message from the another interconnected parties. If the triggered request is non-blocking the interaction is called asynchronous, otherwise it is call synchronous.

**Reactive**: it is a communication pattern to describe an interaction between communicating entities where the selected one triggers sending a message and does not expects reaction from the others parties receiving it. The triggered message send action must be non-blocking, It means that the message sending action should last as short as possible. It is one to many nodes interconnection relationship.

## See also

- [Postół, M, IMPLEMENTATION OF MONITOR CONCEPT IN MODULA-2; 2004; DOI: 10.13140/RG.2.2.30414.54087](https://www.researchgate.net/publication/358308019_IMPLEMENTATION_OF_MONITOR_CONCEPT_IN_MODULA-2)
- [Teaching of Programming (TP)](http://mpostol.github.io/TP/)
- [Programming in Practice; GitHub repository containing set of examples targeting education purpose.](https://github.com/mpostol/TP)
- [Real-Time Programming Helpers Library; GitHub repository](https://github.com/mpostol/RealTime)
- [Managed threading; MSDN](https://docs.microsoft.com/dotnet/standard/threading/)
