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

# Functional programming implementation

## Introduction

Object-oriented languages, including but not limited to CSharp, incorporate several features that contribute to functional programming. Let’s explore some of these constructs:

- [delegate and events][DelegateEventsMD] - delegates are a fundamental construct in CSharp that enables late binding scenarios allowing the definition of a type-safe reference to a method; an event is essentially a delegate variable with additional restrictions,
- [extension methods][ExtensionMethodsMD] - the extension method to use for static methods invocation syntax similar to the invocation of type members methods and finally cascading execution chain.
- [anonymous functions][AnonymousFunctionsMD] - allow definition and use of inline methods that don't have names,

This folder provides examples that can be applied to explain the above concepts.

## Delegates and Events

The class [DelegateExample][DelegateExample] provides a few examples of delegates and events. Check out the section [Delegate and Events][DelegateEventsMD] to get details. The UT located in the class [DelegateExampleUnitTest][DelegateExampleUnitTest] contains test methods illustrating how to use the delegates and events.

## Extension Methods

The class [ExtensionMethods][ExtensionMethods] provides a few examples of extension methods. Check out the section [Extension Methods][ExtensionMethodsMD] to get details. The UT located in the class [ExtensionMethodsUnitTest][ExtensionMethodsUnitTest] contain test methods illustrating how to use the extension methods and points out differences between usage the instance and extension methods against the instance methods.

## Anonymous Functions

The class [AnonymousFunctions][AnonymousFunctions] provides a few examples of delegates and events. Check out the section [Anonymous Functions][AnonymousFunctionsMD] to get details. The UT located in the class [AnonymousFunctionsUnitTest][AnonymousFunctionsUnitTest] contains test methods illustrating how to use the Anonymous Functions amd Expression Tree.

[DelegateExample]: DelegateExample.cs#L16-L68
[DelegateEventsMD]: READMEDelegateEvents.md
[DelegateExampleUnitTest]: ..//FunctionalProgramming.UnitTest/DelegateExampleUnitTest.cs#L18-L73

[ExtensionMethods]: ExtensionMethods.cs#L19-L64
[ExtensionMethodsMD]: README.ExtensionMethods.md
[ExtensionMethodsUnitTest]: ../FunctionalProgramming.UnitTest/ExtensionMethodsUnitTest.cs#L21-L76

[AnonymousFunctions]: AnonymousFunctions.cs#L31-L146
[AnonymousFunctionsMD]: README.AnonymousFunctions.md
[AnonymousFunctionsUnitTest]: ../FunctionalProgramming.UnitTest/AnonymousFunctionsUnitTest.cs#L20-L109
