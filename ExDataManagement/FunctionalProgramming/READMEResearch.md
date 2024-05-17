# Research

## Is the event or delegate variable a foundation for the polimorfizm?

**Delegates**: Delegates are a fundamental construct in C# that enables late binding scenarios allowing the definition of a type-safe reference to a method, which can then be invoked dynamically at runtime. In essence, delegates provide a way to call methods indirectly, allowing for flexibility in method invocation.

**Events**: Events are built using the language support for delegates - an event is essentially a delegate with additional restrictions. Only the class containing the event can **invoke** it, while other classes can **subscribe** to listen to those events.

The event, delegate type, and delegate variable definitions are in the [DelegateExample][DelegateExample] class as follows:

``` C#
   public delegate int PerformCalculation(int x, int y);
   public PerformCalculation PerformCalculationVar;
   public event EventHandler PerformSumMethodCalled;
```

``` C#
      DelegateExample _newInstance = new DelegateExample();
      _newInstance.PerformCalculationVar = _newInstance.PerformSumMethod;
...
      _newInstance.PerformSumMethodCalled += (x, y) => { _Called++; _sender = x; _args = y; };
```

Check out the [DelegateExampleUnitTest][DelegateExampleUnitTest] unit test class to get more.

**Polymorphism**: It refers to situations where something (such as a method or operator) can take on **various roles or forms**. Technically, polymorphism occurs when a method has different implementation based on inheritance and overriding implementation. By using polymorphism, we achieve flexibility in our code, as methods with the same names can implement the same responsibility using various operations according to business requirements.

In summary, while delegates provide the mechanism for late binding and method invocation, events are a specific use case of delegates for handling notifications and interactions within a program. In C#, both **events** and **delegates** play a role in achieving **polymorphism**.

## Is the event or delegate a foundation for the inversion of control (IoC)?

**Delegates**: are a fundamental construct in C# that enables late binding scenarios allowing the definition of a type-safe reference to a method, which can then be invoked dynamically at runtime. In essence, delegates provide a way to call methods indirectly, allowing for flexibility in method invocation.

**Events**: are built using the language support for delegates - an event is essentially a delegate with additional restrictions. For example, only the class containing the event can invoke it, while other classes can **subscribe** to listen to those events.

**Inversion of Control (IoC)**: is a program design pattern used in software engineering to achieve loose coupling. In sequential programming, it allows for a change in the natural sequence of instructions.

The event, delegate type, and delegate variable definitions are in the [DelegateExample][DelegateExample] class as follows:

``` C#
   public delegate int PerformCalculation(int x, int y);
   public PerformCalculation PerformCalculationVar;
   public event EventHandler PerformSumMethodCalled;
```

``` C#
      DelegateExample _newInstance = new DelegateExample();
      _newInstance.PerformCalculationVar = _newInstance.PerformSumMethod;
...
      _newInstance.PerformSumMethodCalled += (x, y) => { _Called++; _sender = x; _args = y; };
```

Check out the [DelegateExampleUnitTest][DelegateExampleUnitTest] unit test class to get more.

[DelegateExample]: https://github.com/mpostol/TP/blob/0b5f0b4f4f752182d8a83410b1c6019413934808/ExDataManagement/FunctionalProgramming/FunctionalProgramming/DelegateExample.cs#L23-L32
[DelegateExampleUnitTest]: https://github.com/mpostol/TP/blob/0b5f0b4f4f752182d8a83410b1c6019413934808/ExDataManagement/FunctionalProgramming/FunctionalProgramming.UnitTest/DelegateExampleUnitTest.cs#L18-L73

## See also

1. [Polymorphism in C# with Examples - Dot Net Tutorials.](https://dotnettutorials.net/lesson/polymorphism-csharp/)
2. [Delegates vs. events - C#; Microsoft Learn](https://learn.microsoft.com/dotnet/csharp/distinguish-delegates-events)
3. [Polymorphism vs Delegates - CodeGuru](https://forums.codeguru.com/showthread.php?392879-Polymorphism-vs-Delegates)
4. [c# - Polymorphic delegates - Stack Overflow](https://stackoverflow.com/questions/3868110/polymorphic-delegates)
5. [Introduction to delegates and events in C# - C# | Microsoft Learn](https://learn.microsoft.com/otnet/csharp/delegates-overview)