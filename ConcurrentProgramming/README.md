# Concurrent Programming

## Patterns

### No Shared Resources

- Synchronous Programming (out of scope)
  - Performing operations in a sequence
- Asynchronous Programming: Performing operations as a result of nondeterministic events
  - Interactive Programming
    - Task-based Asynchronous Pattern (TAP)
    - Asynchronous Programming Model Pattern (APM)
    - Event-based Asynchronous Pattern (EAP)
    - RunMethodAsynchronously from mpostol/RealTime#33
  - Reactive programming
    - DataObservable
    - TickEventArgs

- Distributed Programming (out of scope)

### Shared Resources

Asynchronous programming scenarios:

- Concurrent programming: performing operations as a result of nondeterministic events
  - CriticalSectionExample
- Parallel Programming: simultaneous execution of program operations
- Real Time Programming: the time must be taken into account as a factor determining the correctness of the program
- Asynchronous programming implementation scenarios

## Definitions

### Processes

Windows operating systems protect applications from each other by running each application in its own process. If an application fails, only that process is affected; applications in other processes continue to perform. As the result memory addresses in one process have no meaning in another process.

In the managed environment, application domains (or logical processes) and contexts provide isolation and security at less cost and with greater ability to scale well than an operating-system process by relying on, among other things, the fact that managed code is verifiably type-safe. Every managed application runs in an application domain, whether another application starts a domain on its behalf or the host environment starts one for it.

## See also

- [Postół, M, IMPLEMENTATION OF MONITOR CONCEPT IN MODULA-2; 2004; DOI: 10.13140/RG.2.2.30414.54087](https://www.researchgate.net/publication/358308019_IMPLEMENTATION_OF_MONITOR_CONCEPT_IN_MODULA-2);
- [Teaching of Programming (TP)](http://mpostol.github.io/TP/)
- [Programming in Practice; GitHub repository containing set of examples targeting education purpose.](https://github.com/mpostol/TP)
- [Real-Time Programming Helpers Library; GitHub repository](https://github.com/mpostol/RealTime)
- [Managed threading; MSDN](https://docs.microsoft.com/dotnet/standard/threading/)
