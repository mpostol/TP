# Extension Methods

## Introduction

C# simulates existence of an instance method for a selected type via extension methods. To do this, the signature of the static method must have `this` keyword as the prefix of the the first parameter. In other words, extension methods are a kind of static method, that can be called as if they were instance methods of the first parameter type.

## Content

The class `ExtensionMethods` provides a few examples of extension methods.

The UT located in the class `TP.Lecture.UnitTest.ExtensionMethodsUnitTest` has test methods illustrating how to use the extension methods and points out differences between usage the instance and extension methods against the instance methods.

## See also

- [Extension Methods \(C# Programming Guide\) on MSDN](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)

