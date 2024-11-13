# 1. Concurrent Programming <!-- omit in toc -->

## Table of content <!-- omit in toc -->

- [1. Introduction](#1-introduction)
  - [1.1. Program life cycle](#11-program-life-cycle)
    - [1.1.1. Design Time](#111-design-time)
    - [1.1.2. Execution Time](#112-execution-time)
  - [1.2. Sequential Programming](#12-sequential-programming)
    - [1.2.1. Introduction](#121-introduction)
    - [1.2.2. Dependency Injection (DI)](#122-dependency-injection-di)
    - [1.2.3. Inversion of Control (IoC)](#123-inversion-of-control-ioc)
    - [1.2.4. GUI Interoperability (Reactive and Interactive User Interface)](#124-gui-interoperability-reactive-and-interactive-user-interface)
    - [1.2.5. Program Entities Interoperability](#125-program-entities-interoperability)
  - [1.3. Concurrent programming ✍🏻](#13-concurrent-programming-)
    - [1.3.1. Introduction to Concurrent programming](#131-introduction-to-concurrent-programming)
    - [1.3.2. Multithreading or concurrent programming](#132-multithreading-or-concurrent-programming)
  - [1.4. Distributed Programming - Network Nodes Communication (out of scope)](#14-distributed-programming---network-nodes-communication-out-of-scope)
- [2. Fundamentals](#2-fundamentals)
- [3. Common Data Consistency](#3-common-data-consistency)
  - [3.1. Critical Section ✍🏻](#31-critical-section-)
- [4. Synchronization ✍🏻](#4-synchronization-)
- [5. Communication ✍🏻](#5-communication-)
- [6. Real-Time Programming ✍🏻](#6-real-time-programming-)
- [7. See also](#7-see-also)

## 1. Introduction

### 1.1. Program life cycle

#### 1.1.1. Design Time

At design time the computer program is developed to be compliant with a requirement specification. It includes selected algorithms implementation and testing. Implementation includes a process of program text editing according to the selected programming language and development environment.

#### 1.1.2. Execution Time

A computer program is always executed in a surrounding context called an execution platform, for example operating system. One of the operating systems' responsibilities is to protect computer programs from each other by running each program in its own process. If a program fails, only that process is affected; programs wrapped by other processes can continue to perform. As a result addresses in one process have no meaning in another process. In the managed environment, application domains (or logical processes) and contexts provide a similar level of isolation and security at less cost and with a greater ability to scale well than an operating-system process.

### 1.2. Sequential Programming

#### 1.2.1. Introduction

✍🏻 This section provides examples related to executing program instructions (statements) one by one in the order defined in advance at design time. Only patterns vital for the concept of concurrent programming have been selected. The original execution sequence may change as the result of applying control instructions and implicit concurrent programming.

✍🏻 It is worth stressing that in sequential programming concurrent programming is applied implicitly if ever.

#### 1.2.2. Dependency Injection (DI)

It is a programming pattern where the abstraction paradigm defined as a part of the object-oriented programming concept is applied to provide an instance of a concrete type when the type is not visible or shall be not referred to for some reason. In other words, the `new` operator is not applicable to create an instance in a location where this instance is to be used. The lack of possibility to deal directly with the concrete type in concern or deliberate avoiding direct access to this type for some reasons shall be recognized as a problem to be solved.

Below there are selected reasons why a concrete type is not visible or shall not be referred to in a program location:

1. the type in concern is defined in the programming layer above and shall not be used directly to comply with separation of concerns and responsibility rules
1. the type in concern is defined in the not referenced project, for example in the unit test project to provide testing data that must be not located inside of a shippable deliverable and as the result, the type is not visible
1. the type in concern will be defined later for some reason, for example, to avoid waiting for the final implementation when work is forked to be conducted simultaneously by independent developers
1. the type in concern is defined out of the current solution, for example, it is a part of a plug-in

#### 1.2.3. Inversion of Control (IoC)

It is a programming pattern that may be used to describe calling unknown methods because their implementation is not or should not be visible in the location where they are to be called. The following examples show typical scenarios

- an abstract method implemented elsewhere by a type that an instance is provided applying the dependency injection pattern
- a delegate object wrapping set of methods assigned elsewhere to an event or delegate variable

#### 1.2.4. GUI Interoperability (Reactive and Interactive User Interface)

✍🏻
> it refers to the computer usage but not programming proces

**Interactive**:
It is a user of a computer and computer user interface interoperability pattern where one party of this interoperability triggers an action and expects a reaction from the other one. An example of this kind of interoperability is a mouse clicking on an abstract button on the computer screen and expecting a reaction from the program responsible to render this button on the screen and associate a functionality to it under a hood. According to the definition, it is a blocking relationship, hence the round trip latency should be minimized to keep the user interface responsive and react smoothly to the triggered action.

**Reactive**:
It is a user of a computer and computer user interface interoperability pattern where one party of this interoperability triggers an action and doesn't expect a reaction from the other one. An example of this kind of interoperability is updating the current time on the watch control rendered on the screen. On the other hand, pressing an abstract button on the computer screen without any visual reaction is also reactive interoperability but it should be avoided because it makes the user interface nonresponsive - it could be recognized as no response to the user demand.

Because usually the GUI should be recognized as a critical section, its interoperability with any underlying activity must be synchronized. It depends on the framework used to implement the interoperability.

#### 1.2.5. Program Entities Interoperability

**Synchronous**:
It is a programming pattern to describe an interaction between a programming entity and an action invoked by it where the method is executed synchronously. In other words, the further execution of the calling entity is postponed until the called one has been finished. The concurrent programming concept deliberately is not applicable to implement this relationship.

**Asynchronous**:
It is a programming pattern to describe an interaction between a programming entity and an action invoked by it. The called action is executed simultaneously with the invoking one. In other words, the further execution of the calling entity is continued and synchronized with the called one after finishing.

✍🏻 It requires concurrent programming.

**Interactive**:
It is a programming pattern to describe an interaction between programming entities where the selected one triggers an action and expects a reaction from another interoperable party. If the triggered action is non-blocking the interaction is called asynchronous, otherwise, it is called synchronous.

**Reactive**:
It is a programming pattern to describe an interaction between programming entities where the selected one triggers an action and does not expects a reaction from it. The triggered action must be non-blocking, which means that the interoperability action should last as short as possible. It is a one-to-many programming entity interoperability relationship. This programming pattern may be used to implement the publisher-subscriber pattern.

<!-- 
- Event-based Asynchronous Pattern (EAP)
- DataObservable
- TickEventArgs
-->

### 1.3. Concurrent programming ✍🏻

#### 1.3.1. Introduction to Concurrent programming

- **Concurrent programming**: performing operations as a result of nondeterministic events
- **Parallel Programming**: simultaneous execution of program operations
- **Real Time Programming**: the time must be taken into account as a factor determining the correctness of the program

- **Concurrency vs. Parallelism**: Concurrency is about managing multiple tasks at the same time, while parallelism is about executing multiple tasks simultaneously.
- **Threads and Processes**: Threads are the smallest unit of execution within a process, sharing the same memory space. Processes are independent execution units with their own memory space.

#### 1.3.2. Multithreading or concurrent programming

Both terms are used to refer to the programming pattern that allows writing a program to execute operations at run time as a result of nondeterministic events. Concurrency is when multiple sequences of instructions are run in overlapping periods of time. In other words, the instructions sequence execution is undetermined in advance. Thread is a type that may be used to represent a sequence of instructions in this scenario.

<!-- 

- TODO RunMethodAsynchronously from mpostol/RealTime#33

Real time library 

-->

### 1.4. Distributed Programming - Network Nodes Communication (out of scope)

**Interactive**: It is a communication pattern to describe an interaction between communicating entities where the selected one triggers sending a request and expects a response message from the another interconnected parties.

✍🏻If the triggered request is non-blocking the interaction is called asynchronous, otherwise it is call synchronous.

**Reactive**: it is a communication pattern to describe an interaction between communicating entities where the selected one triggers sending a message and does not expects reaction from the others parties receiving it. The triggered message send action must be non-blocking, It means that the message sending action should last as short as possible. It is one to many nodes interconnection relationship.

✍🏻

## 2. Fundamentals

**Threads Creations:**

> **TBD**

**Asynchronous Programming:**

- Event-based Asynchronous Pattern (EAP)
- Task-based Asynchronous Pattern (TAP)
- Asynchronous Programming Model Pattern (APM)

**Common Data Consistency:**

> **TBD**

**Threads Synchronization:**

> **TBD**
>
> - ded lock

**Threads Communication:**

- Producer-consumer Design Pattern
- Writers-readers Design Pattern
- Publisher-subscriber Design Pattern

The Readers-Writers, Producer-Consumer, Publisher-Subscriber design patterns are both used in concurrent programming but serve different purposes and have distinct characteristics:

**Readers-Writers:**

- Purpose - Manages access to a shared resource where multiple threads can read from the resource simultaneously, but only one thread can write to it at a time.
- Scenario -  Useful when you have a resource that is frequently read but infrequently written to, such as a database or a file.
- Behavior
  - Readers Multiple readers can access the resource concurrently without interfering with each other.
  - Writers Writers require exclusive access to the resource, meaning no other readers or writers can access it while a writer is writing.
- Challenges - Ensuring fairness and preventing starvation, where writers might be blocked indefinitely if readers keep accessing the resource¹.

**Producer-Consumer:**

- Purpose - Decouples the production of data from its consumption, allowing producers and consumers to operate at different rates.
- Scenario - Commonly used in scenarios like data processing pipelines, where data is produced by one part of the system and consumed by another.
- Behavior
  - Producers - Generate data and place it into a buffer or queue.
  - Consumers - Retrieve data from the buffer or queue and process it.
- Challenges - Managing the buffer size to prevent overflow (when producers generate data faster than consumers can process) or underflow (when consumers process data faster than producers can generate)².

**Key Differences between `Readers-Writers` and `Producer-Consumer`:**

- Access Control
  - Readers-Writers - focuses on managing concurrent access to a shared resource with different rules for readers and writers.
  - Producer-Consumer - focuses on decoupling the production and consumption processes using a buffer or queue.
- Concurrency
  - Readers-Writers- allows multiple readers or a single writer at a time.
  - Producer-Consumer - allows producers and consumers to work independently and concurrently, with synchronization handled via the buffer.

- (1) [8.4. Readers-Writers Problem — Computer Systems Fundamentals - JMU.](https://w3.cs.jmu.edu/kirkpams/OpenCSF/Books/csf/html/ReadWrite.html)
- (2) [Producer/Consumer Architecture in LabVIEW - NI - National Instruments.](https://www.ni.com/en/support/documentation/supplemental/21/producer-consumer-architecture-in-labview0.html.)

**Publisher-Subscriber:**

> TBD

## 3. Common Data Consistency

### 3.1. Critical Section ✍🏻

- **Definition**: A critical section is a part of the code that accesses shared resources and must not be executed by more than one thread at a time.
- **Implementation**: Use synchronization mechanisms like locks (mutexes), and monitors to ensure that only one thread can enter the critical section at a time.
- **Synchronization**: Techniques to control the access of multiple threads to shared resources to prevent conflicts.

## 4. Synchronization ✍🏻

- **Locks (Mutexes)**: Ensure mutual exclusion by allowing only one thread to access a resource at a time.
- **Semaphores**: Counting mechanisms that control access to a resource by multiple threads.
- **Monitors**: High-level synchronization constructs that combine mutual exclusion and condition variables. (Hoare's monitor concept - MFT)

Ref [WaitHandle class and lightweight synchronization types](https://learn.microsoft.com/dotnet/standard/threading/overview-of-synchronization-primitives)

## 5. Communication ✍🏻

- **Shared Memory**: Threads communicate by reading and writing to shared variables. Requires careful synchronization to avoid race conditions.
- **Message Passing**: Threads or processes communicate by sending messages to each other, which can help avoid issues related to shared memory.

## 6. Real-Time Programming ✍🏻

- **Definition**: Real-time programming involves writing software that guarantees response within strict timing constraints.
- **Types**:
  - **Hard Real-Time**: Systems where missing a deadline can lead to catastrophic failures (e.g., medical devices, automotive systems).
  - **Soft Real-Time**: Systems where deadlines are important but not critical (e.g., video streaming).
- **Techniques**:
  - **Priority Scheduling**: Assigning priorities to tasks to ensure critical tasks are executed first.
  - **Deterministic Behavior**: Ensuring that the system's behavior is predictable and consistent.

## 7. See also

- [Postół, M, IMPLEMENTATION OF MONITOR CONCEPT IN MODULA-2; 2004; DOI: 10.13140/RG.2.2.30414.54087](https://www.researchgate.net/publication/358308019_IMPLEMENTATION_OF_MONITOR_CONCEPT_IN_MODULA-2)
- [Postół, M, Programming in Practice; ebook](https://mpostol.gitbook.io/pip)
- [Programming in Practice; home page](http://mpostol.github.io/TP/)
- [Programming in Practice; GitHub repository](https://github.com/mpostol/TP)
- [Real-Time Programming Helpers Library; GitHub repository](https://github.com/mpostol/RealTime)
- [Managed threading; MSDN](https://docs.microsoft.com/dotnet/standard/threading/)
- [Overview of synchronization primitives](https://learn.microsoft.com/dotnet/standard/threading/overview-of-synchronization-primitives)
- [List of all references](../REFERENCES.md#references)
