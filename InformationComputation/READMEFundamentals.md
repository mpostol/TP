# Introduction

## Preface

### Computer Science

Let us try to start our research by answering a very fundamental question what is computer science, the main field of our activity I mean software engineering. Form the Google we can get a response like this

> **Computer Science**: is the study of computers and computational systems. Computer scientists deal mostly with software and software systems; this includes their theory, design, development, and application.

This definition says that Computer Science is the study of computers and computational systems. Computer scientists deal mainly with software and software systems; this includes their theory, design, development, and application. In general, we can conclude that it is dedicated to information processing - it deals with information processing and the production of systems used to process information. Unfortunately, I have a couple of problems with this definition.

### Information Processing Applicability Scope

The first problem I have is the meaning of the term information processing itself. For example, are medicine or journalism not concerned with information processing? They also use technology. Here we need to make a certain distinction between what doctors and journalists do and our activities as software developers. This question is the easiest to answer because we can say that computer science deals with the automation of the information processing process. Thanks to this, we can say that computer science is a service field that allows us to provide solutions, i.e. information processing systems that will be used in medicine, for example for diagnostics or in journalism for the publication of a new edition of a newspaper. Concluding in our activity we should pay special attention to producing software that guarantees the repeatability of outcomes.

### Information as a knowledge

In this context, the information term should be understood as knowledge about the state and behavior of the process in concern. The process that we want to monitor or control, with the use of devices, with the use of technology, with the use of computers to be precise - to achieve the goal automatically.

### Information Processing Summary

Explaining the `Information Computation` title, we came to the conclusion that the discussion concerns the automation of information processing. This process is based on two tightly coupled terms. The first relevant term is **information** about a process - shortly called process information. The process information must be recognized as knowledge about the state and behavior of the process. The second term is the **algorithm**, which again is information but this time about how to solve the problem in concern. In other words, we can say that processing must be implemented based on a knowledge of how to achieve a goal, or how to solve a given problem by applying information processing. That is algorithm could be recognized as an abstract description of the information processing behavior.

### Contradiction

Concluding, the automation of information processing requires the use of technology, and therefore a computer. A computer is a device that is governed by the laws of physics. And here we come to a fundamental contradiction, namely, we need to answer the question of how a physical machine can process something that is abstract, namely information. The problem addressed by this course is how to represent process information and implement algorithms to be suitable for computation that is processing using a computer device.

## Outline of Scope

Referring to the previous discussion, the automation of information processing requires the use of technology, and therefore a computer. A computer is a device that is governed by the laws of physics. And here we come to a fundamental contradiction, namely, we need to answer the question of how a physical machine can process something that is abstract, namely information. In this section, we will continue a more or less theoretical discussion necessary to make a foundation for further learning related to information representation as a consistent part of programming language. After that, the next subsection titled `Information Representation` is focused on how to represent process information. It covers the fundamentals of types in the context of object-oriented programming. We will also learn some special approaches to types definitions, namely anonymous, partial, and generic types. Last but not least section titled `Algorithm Implementation` covers selected aspects of algorithm implementation using the object-oriented programming concept and layered program design pattern. The main goal is to deal with software engineering fundamentals. Concluding, the main goal is to understand the applicability scope - reasons why we need all that special and more or less dedicated solutions and principles of the program architecture.

## Program Design Phase Requirements

### Programming Language

As a general goal of the course, we will focus on learning rules but not training in a particular language or development tool. To make sure that our discussion is practical and implementable we must use a selected programming language as a context for further explanation. I have selected CSharp to prepare examples that are to be explored during deploying the Information Computation course. But let me get ahead of your doubts and stress now that in principle the programming language is considered only a tool to write down examples. According to the main assumption of the course, I hope it will be not an obstacle to port solutions to another development environment dominated by other programming languages.

### Integrated Development Environment

Again, to make our discussion about programming practical we must distinguish between design-time and run-time environments. Both are tightly coupled but the possibility to trace the behavior of the examples at run time is very important for the `Programming in Practice` as a learning path and also for the `Information Computation` course. I selected Visual Studio as the integrated development environment to be used to deal with examples in the course.

### GitHub

All topics covered by the course are discussed in the context of examples stored in a public repository. I have selected GitHub to store the code examples. Additionally, GitHub is a perfect solution because it allows improvement or adding new examples. All examples used during the course are gathered in the TP public open-source repository.

### Working as a Team

Today almost always software is developed by teams. That is tightly coupled contributors. Hence you have to be prepared to work as a team member. We cannot organize real teamwork, so I propose to apply community collaboration by employing the GitHub repository. The  GitHub repository is not only the storage of reusable open-source software but is also a collaboration platform. When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change. Visit the repository to follow the contribution rules in all your interactions with the repository.

### How to Use Supporting Commodities

Discussing details on how it works and how to use the mentioned above commodities is a good subject for a few independent courses. However, at least we must know how to get started. Enroll in and finish the free course titled [Programming in Practice - Executive Summary][2108-PiP-TP-repository] to get more on how to apply them to improve education performance. Check it out also if you need more information about the Programming in Practice general educational path this course is compliant with.

## Audience

To begin with, let's start by defining the target group. The course is intended for students and teachers who have knowledge and experience related to programming fundamentals. It is not a hard requirement, but rather a recommendation, but it is advisable to already have some knowledge and experience in object-oriented programming. Certainly, it will be useful to recall such concepts as instruction, method, type, class, interface, reference, iteration, recursion, polymorphism, inheritance, abstraction, encapsulation,  etc. Although the goal of the course is not to learn the selected programming language or the development environment, the knowledge of CSharp, the MS Visual Studio environment, and the GitHub repository, which are used to present sample programs, will be very helpful. Enroll in and finish the free course [Programming in Practice - Executive Summary][2108-PiP-TP-repository] to accommodate this requirement. Usually, background knowledge is enough to finish successfully this course and reuse the knowledge and experience you will get.

## Learning outcomes and benefits

In the context of examples, you will learn how to use types to represent custom information and how to organize the program text compliant with the layered architecture. After the course, you will be familiar with a vast variety of methods that can be applied to design the object model as a subject for further information computation. You will also be able to

- select appropriate methods to spread the work to team members according to the separation of concerns rules,
- organize the obtained this way program parts using unidirectional layers relationship (dependencies), and
- make them interoperable using bidirectional communication engaging callback, reactive programming, dependency injection, and inversion of control.

All discussion is conducted based on the examples gathered in a dedicated solution and maintained using a GitHub repository. These examples are ready to use as a foundation for programming skills learning. All the time I will keep the discussion on a level that guarantees common and easy portable conclusions, which are applicable independently of the used development environment.

## Conclusion

It is time to conclude our discussion and idea exchange related to Information Computation extended examples collected in this solution.

The last message from the discussion is that applying computer science could be very helpful to solve our problems and support human beings to improve the performance and robustness of their activity. It is a result of the automation of information processing. A main result of automation is the repeatability of results obtained thanks applying information computation. Repeatability enables the applicability of testing as a method to improve robustness. To apply information technology or computer science, as the name says, we must employ technology to implement information processing. We need a driving force - an engine - to realize the processing. Today it is a binary computer but the most important thing is that it is a device governed by physics. This led to the conclusion that abstraction must not be a subject of processing by any device today and in the future.

In this respect, that is in the context of information processing, we must deal with two kinds of information. It is process information describing the state and behavior of a process in concern and an algorithm, which is a piece of knowledge describing the solution of a problem using the computer. Both are tightly coupled and must be represented together using a programming language, which could be compiled into a binary form suitable to be used as a recipe of the computer behavior and process information representation. Today, typically we use high-level languages that are based on an alphanumeric alphabet derived from the Latin alphabet. Syntax of these languages is founded on keywords borrowed from the natural English language and semantics supports object-oriented programming concept. It was emphasized that modern languages use type as a concept to describe process information and algorithms consistently.

Process information representation and algorithm implementation are software developer responsibility.Both are tightly coupled but following the previous discussion divided to cover topics related to the design of types and the design of a program as one whole.

## See also

- [Mariusz Postol profile on udemy][MPUdemy]
- [Mariusz Postol profile on GitHub][MPGitHub]
- [Programming in Practice - Executive Summary; Udemy video course][2108-PiP-TP-repository]

[2108-PiP-TP-repository]: https://www.udemy.com/course/pipintroduction/?referralCode=E1B8E460A82ECB36A835
[MPUdemy]:https://www.udemy.com/user/mariusz-postol/
[MPGitHub]:https://github.com/mpostol
