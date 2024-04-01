# C# in Practice - Adaptive Programming (AP)

## Key words

education, training, code examples, csharp, csharp-examples, adaptive-programming, asynchronous programming, reflection, dependency injection, inversion of control, dynamic programming, plug-in, cloud tracing, LINQ

## Subject

The adaptive programming is presented as a catalog of language constructs, patterns, and frameworks used at the development and deployment stage with the goal to increase the adaptability of the program against changing production environment in which it is executed.

## Goal

The aim of the course is to expand knowledge and improve skills of software development thanks to using technology and design patterns to enable adaptation of the created program against the changing requirements and capabilities of the run-time production environment. This objective includes issues related to the practical knowledge of technology dedicated to postpone the decisions regarding software interoperability with development framework and the external environment. Students learn the selected technologies, design patterns, archetypes and their practical implementation in the .NET with the goal to be used while developing their own programs.

## Learning outcomes

After completing the course students will:

1. evaluate and use the dynamic programming,
2. use the technologies enabling the program composition using the independently developed modules,
3. analyze and use the technologies to improve adaptability of the program against different process data repositories,
4. understand the need and apply a consistent configuration mechanism against a program composed of independently created modules,
5. analyze the need to track program activity and select programming technology to guarantee its adaptability at run-time,
6. test the proposed solutions based on the architecture of the program composed using a set of loosely coupled modules.

## Prerequisites

Knowledge of the following topics is required to understand the content:

* Object-oriented programming
* Software Development Technologies
* Component Programming

## Repository Content

<!--
What we must do to prove the goal have been achieved. Extent or range of development, view, outlook, application, operation, effectiveness, etc. 
-->

This folder collects examples that can serve as a certain pattern with the widest possible use addressing the mentioned above application domain. In order to ensure the practical context and provide sound examples, all topics are illustrated using the C# language and the MS Visual Studio design environment. The source code is available in this repository.

### Framework

This part covers the following topics:

* Asynchronous Behavior - critical section, synchronization,
* Application Architecture - layers dependency, implementation and design time control
* Application Localization - application resources
* Reflection - object model, code generation, dynamic programming, objects instantiation, data binding

### Application Composition

* Service Locator
* Dependency Injection
* Plug-in

### Logging

* Application Trace Source
* Application Trace Remote Control
* Distributed Application Tracing
* Semantic Tracing
* Cloud Tracing

### Configuration

* Configuration Manger
* XML, JSON Based Configuration
* Distributed Application Configuration

## Lecture

During the lecture the presentation of the selected topics is based on the source code snippets. The presentation is followed by a discussion on the following topics supporting the adaptive programming:

* most often occurring practical scenarios,
* available archetypes and design patterns,
* available libraries supporting discussed solutions,
* syntax and semantics of selected programming language,
* testing methods and tools.

In particular this covers such issues as:

* the dynamic creation of application domains, threads and types according to current needs,
* representation of the process data outside of the application domain,
* dynamic functionality composition of the program,
* program functional expandability using the modules developed independently (plugins)
* flexible selection of communication protocols,
* flexible selection of the process data repositories,
* flexible software configuration,
* customization of the application behavior tracking system,

The lecture is focused on the following topics:

* syntax and semantics of the C# patterns useful for adaptive programming
  * parallel and asynchronous programming,
  * reflection,
  * attributed programming model,
  * dynamic programming,
* expression representation and their translation as required by the target external system
* architecture and design patterns related to access external data based management systems
  * materialization to save objects state and objects graph relationship using XML, JSON, etc.,
  * object relation mapping,
* program composition using independently developed modules
  * dependency injection (DI),
  * functionality extension using modules developed independently (plug-in),
  * to assure the separation of responsibilities,
  * composition modules versioning,
  * application domain,
* tracing of the program activities in the production environment
  * multisource tracing systems,
  * semantic logging,
  * dynamic configuration of the tracing,
  * cloud based tracing,
  * modules development reusable patterns promoting separation of concerns,
* systematic approach to configuration development
  * the program as a one whole,
  * independently developed modules,
  * properties in the context of individual users,
* unit and integration tests
  * testing environment requirements against the program composed using independently developed modules,
  * processing data simulation for testing purpose,
  * simulation of production environment behavior for testing purpose,

> **NOTE**: Unit Test role is code explanation rather than testing the correctness of it.

<!--
//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________
-->
