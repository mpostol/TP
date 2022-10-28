# 1. Computation of Information

## Table of content <!-- omit in toc -->

- [1. Computation of Information](#1-computation-of-information)
  - [1.1. Executive Summary](#11-executive-summary)
    - [1.1.1. Welcome](#111-welcome)
    - [1.1.2. Instructor Intro](#112-instructor-intro)
    - [1.1.3. What's the problem?](#113-whats-the-problem)
      - [1.1.3.1. Introduction](#1131-introduction)
      - [1.1.3.2. Programming in Practice](#1132-programming-in-practice)
      - [1.1.3.3. Computer Science](#1133-computer-science)
      - [1.1.3.4. Information Processing Applicability Scope](#1134-information-processing-applicability-scope)
      - [1.1.3.5. Information as a knowledge](#1135-information-as-a-knowledge)
      - [1.1.3.6. Information Processing Summary](#1136-information-processing-summary)
      - [1.1.3.7. Contradiction](#1137-contradiction)
    - [1.1.4. Outline of Scope](#114-outline-of-scope)
    - [1.1.5. Education context](#115-education-context)
      - [1.1.5.1. Language](#1151-language)
      - [1.1.5.2. Development Environment](#1152-development-environment)
      - [1.1.5.3. GitHub](#1153-github)
      - [1.1.5.4. Working as a Team](#1154-working-as-a-team)
      - [1.1.5.5. How to Use Supporting Entities](#1155-how-to-use-supporting-entities)
    - [1.1.6. Audience](#116-audience)
    - [1.1.7. Learning outcomes and benefits](#117-learning-outcomes-and-benefits)
  - [1.2. Information Representation](#12-information-representation)
    - [1.2.1. Preface](#121-preface)
    - [1.2.2. What's the problem?](#122-whats-the-problem)
    - [1.2.3. Introduction to Title Explanation](#123-introduction-to-title-explanation)
    - [1.2.4. First Problem](#124-first-problem)
    - [1.2.5. First Conclusion](#125-first-conclusion)
    - [1.2.6. Fundamental Inconsistency](#126-fundamental-inconsistency)
    - [1.2.7. Syntax Analysis](#127-syntax-analysis)
    - [1.2.8. Semantics analysis](#128-semantics-analysis)
    - [1.2.9. Data Definition](#129-data-definition)
    - [1.2.10. Coding System](#1210-coding-system)
    - [1.2.11. Possibility to Replace Information Term by Data](#1211-possibility-to-replace-information-term-by-data)
    - [1.2.12. Algorithm Implementation](#1212-algorithm-implementation)
  - [1.3. Algorithm Versus Program](#13-algorithm-versus-program)
    - [1.3.1. Preface](#131-preface)
    - [1.3.2. What's the problem?](#132-whats-the-problem)
    - [1.3.3. Algorithm implementation](#133-algorithm-implementation)
    - [1.3.4. Computer Program is Text](#134-computer-program-is-text)
    - [1.3.5. Programming Language](#135-programming-language)
    - [1.3.6. Binary machine needs binary alphabet](#136-binary-machine-needs-binary-alphabet)
    - [1.3.7. Aim of the course](#137-aim-of-the-course)
  - [1.4. Conclusion](#14-conclusion)
  - [1.5. See also](#15-see-also)

## 1.1. Executive Summary

Information Computation means a process engaging a computer (a physical device) to process information as a series of actions or steps taken in order to achieve a particular result or help to fulfill a task. The main challenge is that information is abstract, it is a kind of knowledge that cannot be processed directly by any physical device.

This MS Visual Studio (TM) solution contains code that by design is to be used as a set of examples for an online video course and class lectures. The examples can also be used alone.

Generally speaking, two main topics are covered. That is dealing with the data recognized as the information representation and behavior description using a program compliant with an algorithm.

### 1.1.1. Welcome

I would like to invite you to participate in a course on information processing. The course is a part of the Programming in Practice series of courses. My point is that we could distinguish between two kinds of education:

1. training - focused on products adoption and maintenance
2. learning - focused on knowledge (concepts, standards, best practices, etc) adoption and maintenance

This curse will focus on p. 2 - the improvement of your knowledge related to software engineering. My goal is that it will be beneficial for you in the long run.

### 1.1.2. Instructor Intro

My name is Mariusz Postół. If your job or professional career depends on software development skills, consider joining us to learn how to improve your knowledge and experience in this respect. I'm gonna share with you the principles of a learning concept called Programming in Practice - information Computation. It has evolved atop 30 years of experience gathered by me as a University teacher and leader of hundreds of innovative IT projects realized, among others, for aviation, energy, tobacco, and mines industries. I am also an author and project leader of commercial software packages published on GitHub as open-source software. Since 1994 - that is from the very beginning - I am also a lecturer at Lodz University of Technology. If you are serious about programming skills, I believe that this mixture will cause a synergy effect. Welcome and thank you for joining the community.

### 1.1.3. What's the problem?

#### 1.1.3.1. Introduction

All subsections in this course begin by trying to define the most important topics. And now let's try to answer the question of what the problem is, but in the context of the entire course - as an introduction to the course as one whole. Let's start by investigating the meaning of the title keywords.

#### 1.1.3.2. Programming in Practice

To learn more about programming in practice meaning check out the free introduction to the series of courses titled [Programming in Practice - Executive summary][2108-PiP-TP-repository]. It is a free course published on [udemy.com][MPUdemy]. Consider enrolling in. Let us try to start our research by answering a very fundamental question what is computer science, the main field of our activity I mean software engineering.

#### 1.1.3.3. Computer Science

> **Computer Science**: is the study of computers and computational systems. Computer scientists deal mostly with software and software systems; this includes their theory, design, development, and application.

This definition says that Computer Science is the study of computers and computational systems. Computer scientists deal mainly with software and software systems; this includes their theory, design, development, and application. In general, we can conclude that it is dedicated to information processing - it deals with information processing and the production of systems used to process information. Unfortunately, I have a couple of problems with this definition.

#### 1.1.3.4. Information Processing Applicability Scope

The first problem I have is the meaning of the term information processing itself. For example, are medicine or journalism not concerned with information processing? They also use technology. Here we need to make a certain distinction between what doctors and journalists do and our activities as software developers. This question is the easiest to answer because we can say that computer science deals with the automation of the information processing process. Thanks to this, we can say that computer science is a service field that allows us to provide solutions, i.e. information processing systems that will be used in medicine, for example for diagnostics or in journalism for the publication of a new edition of a newspaper. Concluding in our activity we should pay special attention to producing software that guarantees the repeatability of outcomes

#### 1.1.3.5. Information as a knowledge

In this context, the information term should be understood as knowledge about the state and behavior of the process in concern. The process that we want to monitor or control, with the use of devices, with the use of technology, with the use of computers to be precise - to achieve the goal automatically.

#### 1.1.3.6. Information Processing Summary

Explaining the title of our course, we came to the conclusion that the discussion concerns the automation of information processing. This process is based on two tightly coupled terms. The first relevant term is **information** about a process - shortly called process information. The process information must be recognized as knowledge about the state and behavior of the process. The second term is the **algorithm**, which again is information but this time about how to solve the problem in concern. In other words, we can say that processing must be implemented based on a knowledge of how to achieve a goal, or how to solve a given problem by applying information processing. That is algorithm could be recognized as an abstract description of the information processing behavior.

#### 1.1.3.7. Contradiction

Concluding, the automation of information processing requires the use of technology, and therefore a computer. A computer is a device that is governed by the laws of physics. And here we come to a fundamental contradiction, namely, during this course, we need to answer the question of how a physical machine can process something that is abstract, namely information. The problem addressed by this course is how to represent process information and implement algorithms to be suitable for computation that is processing using a computer device.

### 1.1.4. Outline of Scope

Referring to the previous discussion, the automation of information processing requires the use of technology, and therefore a computer. A computer is a device that is governed by the laws of physics. And here we come to a fundamental contradiction, namely, we need to answer the question of how a physical machine can process something that is abstract, namely information. In this section, we will continue a more or less theoretical discussion necessary to make a foundation for further learning related to information representation as a consistent part of programming language. After that, the next subsection titled `Information representation` is focused on how to represent process information. It covers the fundamentals of types in the context of object-oriented programming. We will also learn some special approaches to types definitions, namely anonymous, partial, and generic types. Last but not least section titled `Algorithm Versus Program` covers selected aspects of algorithm implementation using the object-oriented programing concept and layered program architecture. The main goal is to deal with software engineering fundamentals. Concluding, the main goal is to understand the applicability scope - reasons why we need all that special and more or less dedicated solutions and principles of the program architecture.

### 1.1.5. Education context

#### 1.1.5.1. Language

As a general goal of the course, we will focus on learning rules but not training in a particular language or development tool. To make sure that our discussion is practical and implementable we must use a selected programming language as a context for further explanation. I have selected CSharp to prepare examples that are to be explored during deploying the Information Computation course. But let me get ahead of your doubts and stress now that in principle the programming language is considered only a tool to write down examples. According to the main assumption of the course, I hope it will be not an obstacle to port solutions to another development environment dominated by other programming languages.

#### 1.1.5.2. Development Environment

Again, to make our discussion about programming practical we must distinguish between design-time and run-time environments. Both are tightly coupled but the possibility to trace the behavior of the examples at run time is very important for the `Programming in Practice` as a learning path and also for the `Information Computation` course. I selected Visual Studio as the integrated development environment to be used to deal with examples in the course.

#### 1.1.5.3. GitHub

All topics covered by the course are discussed in the context of examples stored in a public repository. I have selected GitHub to store the code examples. Additionally, GitHub is a perfect solution because it allows improvement or adding new examples. All examples used during the course are gathered in the TP public open-source repository.

#### 1.1.5.4. Working as a Team

Today almost always software is developed by teams. That is tightly coupled contributors. Hence you have to be prepared to work as a team member. We cannot organize real teamwork, so I propose to apply community collaboration by employing the GitHub repository. The  GitHub repository is not only the storage of reusable open-source software but is also a collaboration platform. When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change. Visit the repository to follow the contribution rules in all your interactions with the repository.

#### 1.1.5.5. How to Use Supporting Entities

Discussing details on how it works and how to use the mentioned above tools is a good subject for a few independent courses. However, at least we must know how to get started. Enroll in and finish the free course titled [Programming in Practice - Executive Summary][2108-PiP-TP-repository] to get more on how to use the CSharp language, Visual Studio, and GitHub repository. Check it out also if you need more information about the Programming in Practice general educational path this course is compliant with.

### 1.1.6. Audience

To begin with, let's start by defining the target group. The course is intended for students and teachers who have knowledge and experience related to programming fundamentals. It is not a hard requirement, but rather a recommendation, but it is advisable to already have some knowledge and experience in object-oriented programming. Certainly, it will be useful to recall such concepts as instruction, method, type, class, interface, reference, iteration, recursion, polymorphism, inheritance, abstraction, encapsulation,  etc. Although the goal of the course is not to learn the selected programming language or the development environment, the knowledge of CSharp, the MS Visual Studio environment, and the GitHub repository, which are used to present sample programs, will be very helpful. Enroll in and finish the free course [Programming in Practice - Executive Summary][2108-PiP-TP-repository] to accommodate this requirement. Usually, background knowledge is enough to finish successfully this course and reuse the knowledge and experience you will get.

### 1.1.7. Learning outcomes and benefits

In the context of examples, you will learn how to use types to represent custom information and how to organize the program text compliant with the layered architecture. After the course, you will be familiar with a vast variety of methods that can be applied to design the object model as a subject for further information computation. You will also be able to

- select appropriate methods to spread the work to team members according to the separation of concerns rules,
- organize the obtained this way program parts using unidirectional layers relationship (dependencies), and
- make them interoperable using bidirectional communication engaging reactive programming, dependency injection, and inversion of control.

All discussion is conducted based on the examples gathered in a dedicated solution and maintained using a GitHub repository. These examples are ready to use as a foundation for programming skills learning. All the time I will keep the discussion on a level that guarantees common and easy portable conclusions, which are applicable independently of the used development environment.

## 1.2. Information Representation

### 1.2.1. Preface

The main goal of this subsection is to explain the meaning of the course title to create a starting point to improve your further understanding.

### 1.2.2. What's the problem?

To explain the meaning of the course title we must start by explaining the meaning of the keywords that are in the title of this course. So, the terms: information, and computation require clarification. The research must be conducted in the context of computer science and information technology. Of course, don't expect deep dive or a theoretical lecture because in general, I am going to present a part of the programming in practice story. Let me stress again that my goal is an improvement of your development skills but not a formal elaboration and definition of the meaning of the course title - in other words - I will try to avoid a complicated discussion related to the meaning of the title.

### 1.2.3. Introduction to Title Explanation

Thanks to googling, it is easy to discover from the internet something like this "computer science uses technology to solve problems and prepare for the future". We can conclude from this statement that a computer may be recognized as a technology used to process information provided that information is knowledge about problems and the future. It looks like a common junction point with the information technology subject. In other words, we are talking about applying a technique and technology to problem-solving, or information processing to be more general. I must say that I have a few problems with this approach or rather this explanation.

### 1.2.4. First Problem

The first problem I have is the term information processing itself. Let me ask you a question, do you think that medicine or journalism is not concerned with information processing? It is an important question for further discussion because we need to make a certain distinction between what doctors and journalists do and what you are going to do as an active member of the computer science ecosystem. Additionally, let me stress that doctors and journalists also use technology on a daily basis. This question is the easiest one to answer because we can say that computer science deals with the automation of information processing by applying programmable devices, I mean computers. Thanks to this, we can say that computer science embeds also an engineering domain aimed at providing solutions - information processing systems to be used in medicine for diagnostics or in journalism for the publication of a newspaper.

### 1.2.5. First Conclusion

Concluding, our particular goal is to learn how to make information processing automatic using computers. In this context, information should be recognized as knowledge about the state or behavior of a set of interoperable real-time activities. The activities that we want to monitor or control, with the use of technology, or more precisely with the use of physical programmable devices, so as to achieve problem-solving automatically. It is our goal and responsibility as computer science active members of an ecosystem  - shortly developers.

### 1.2.6. Fundamental Inconsistency

The automation of information computation requires the use of technology, simplifying a computer. Any computer is a device, so it is governed by the laws of physics. And here we come to our fundamental inconsistency, how it is possible to use a physical device (the computer) to operate against abstraction (information). To solve the problem, I mean to resolve this inconsistency, let's try to address this issue by answering another question, namely, whether the left side is equal to the right side.

![InformacjaVersusData](.Media/2109-010201007000-InformationVersusData-InformacjaVersusData.png)

### 1.2.7. Syntax Analysis

The first answer may be based on the observation that what we see are characters. That is on the left side of the equal sign we have two characters, and on the right side of the equal sign, we have one character. From this fact, we can conclude, that the left side is not equal to the right side. Generally speaking, we use characters in the syntax layer analysis. In this discussion, the set of allowed characters that we can use, I mean concatenate to make a valid string is called an alphabet. If the alphabet is intended for a human, it contains alphanumeric characters - for example letters, digits, or symbols for the Latin alphabet. In the case of today's computers, which are governed by the laws of physics, we must consider only two discrete states. It makes a difference because in this case, the alphabet must contain exactly two signs. Following this rule, the alphabet is called a binary alphabet - no matter what signs it contains. In case the alphabet is intended for a human we are talking about characters, in case the alphabet is intended to be used by a computer we are talking about signs. In both cases, we are talking about the alphabet as a set of entities to be concatenated in streams. For the characters, we have a shape, in the case of signs we have measurable features.

### 1.2.8. Semantics analysis

If we now move from a syntax analysis to a semantic analysis of what we see, we can claim that the left side may represent the number four. And the right side can also represent the number four. In that case, the numbers are equal to each other, so the equal sign is legitimate because both sides are equivalent. That could have the same meaning. Only one question remains to be answered: what conditions must be met for the left side to represent the number four, and the right side also represents the number four? In this case, we are comparing the meaning but not the streams of characters. Again, meaning is an abstraction so physical computers cannot be able to compare meanings, they always compare bitstreams, and they always work on a stream of signs.

### 1.2.9. Data Definition

Continuing this discussion to resolve any doubts related to the meaning of the title, I will use a funny illustration in which the number four is presented as a ghost, something that does not exist in the real world. It is information, it is an abstraction, but it has two equivalent representations interconnected by arrows indicating a bidirectional relationship with the streams of characters associating a meaning to them. To stress the difference between information and information representation that is associated with streams of characters the representation we call data. I believe that now it is very easy for you to distinguish the terms information and data. The simplified rule is as follows: if something is a stream of signs and we are able to assign a meaning to this stream it is just data.

![Coding System](.Media/2109-010201010000-InformationVersusData-InformacjaVersusData.png)

### 1.2.10. Coding System

To build a meaningful relationship between something abstract, in our case a number, and something that has a physical nature - a sequence of characters - we first need to define the alphabet, I mean a set of characters that you are allowed to use in this sequence. Then we need to define a set of rules expressing how to concatenate these characters into valid sequences - called syntax. Finally, we must define the semantics, I mean rules we could apply to correct characters sequences to associate meaning to them. Finally, the alphabet, syntax, and semantics make up a coding system. It is a very important conclusion for subjects related to types, which I will cover.

### 1.2.11. Possibility to Replace Information Term by Data

Returning once again to the discussion about the title of the course, we can observe that in reality, we are computing the data but not the information. Hence, someone could put forward a proposal that maybe it is enough to replace the term information with the term data, and as a result, we will be able to avoid this whole long introduction, which is relatively low-level and theoretical. Of course, the answer is that we can't do that because your duty, as a software developer, is to select or even create if necessary an appropriate coding system. The good news is that the creation of a new coding system is built upon the existing ones. In other words, typically new coding systems are derived from the existing ones. In any case, it is part of your responsibility, so you must know how to deal with it and acquire appropriate skills.

### 1.2.12. Algorithm Implementation

Explaining the title of our course, we concluded that we are talking about the automation of the information computation process. To be more practical and talk in the context of problem-solving we may recognize the information as a piece of knowledge about the state and behavior of a selected real-time set of activities - part of the natural realm. But to solve any problem using a computer we need to know how to compute the information to fulfill an expectation of the activities owner or a manager. Again, additionally, we need knowledge, a piece of information on how to solve the selected problem. How to monitor and possibly control the behavior of the activities in concern. How to control the activities to achieve the chosen goal. This kind of knowledge we may call an algorithm. Let me stress it is also information that cannot be directly applied or used by any physical device including but not limited to computers.

## 1.3. Algorithm Versus Program

### 1.3.1. Preface

Let me recall that our challenge is to learn all about information computation. Information computation means a process employing a computer (a physical device) to process information as a series of actions or steps taken to achieve a particular result or help fulfill a task. The first challenge of this process is that information is abstract. In other words, it is a kind of knowledge that cannot be used directly to describe computer behavior. In this subsection, we will learn how to describe the actions or steps to achieve a particular result in compliance with the limitations of modern computers. I mean the computer is a physical device and cannot process any abstraction.

### 1.3.2. What's the problem?

- how to control a physical device (precisely computer) behavior to process information in compliance with an algorithm

Explaining the title of the course, we concluded that we are talking about the automation of information processing. To be more practical and talk in the context of problem-solving we may recognize the information as a piece of knowledge about the state and behavior of a selected real-time set of activities - part of the natural realm. But to solve any problem using a computer we also need to know how to process the information to reach a goal. Again, additionally, we need information, a piece of knowledge describing how to solve the selected problem. How to control the activities to achieve the goal we are facing with. This kind of knowledge we call an algorithm. Let me stress it is also information that cannot be directly applied or used by any physical device including but not limited to computers. The main challenge of this subsection is to learn more about how to do it.

### 1.3.3. Algorithm implementation

Computation means a set of actions that ensure the automation of information processing. To ensure automatic processing, we need to use technology, which means a programmable device. Today it is the binary computer for sure. Anyway, we must ensure that this processing engine behaves following an appropriate algorithm. The algorithm is again information because it is a piece of knowledge on how to solve the problem. Hence, it is an abstraction that will be useful in the computation process only if it can be represented in binary form - similar to the process information discussed earlier. And this is the next task of software developers, namely algorithms implementation, and the results of this work are computer programs. That is a recipe instructing the computer how to control the activities to achieve the chosen goal. From the previous subsection, we learned that information to be processed by a physical device must be represented by data first using the alphabet, syntax, and data semantics. That is a coding system. A similar approach can be applied to the algorithm, which is also a piece of information describing the computer behavior - shortly algorithm. The most promising solution is coupling together custom coding system design and algorithm implementation because both are tightly coupled.

### 1.3.4. Computer Program is Text

Today, we do not need to implement the algorithm using a binary representation. Thanks to the compilation process, we can use alpha-numeric alphabets - just like the natural languages we use on a daily basis. Typically the alphabet is derived from the Latin alphabet. This leads to the statement that any program at the beginning of its life cycle is just a text, hence a sequence of characters. **Text becomes a computer program when it meets additional rules that will enable it to be compiled.
**
### 1.3.5. Programming Language

And so we come to the term programming language. To be used to control a computer it is a kind of contract between the software developer and compiler that both must comply with and use to finally implement information processing as the data computation. It must be a set of rules. The contract must be exhaustive. To fulfill this requirement the syntax and semantics must be defined and applied respectively to provide appropriate rules that can be used:

- syntax: to create the correct text by concatenating characters from the alphabet and
- semantics: to make the text meaningful.

CSharp is such a language that I use to explain software development issues with concrete examples.

### 1.3.6. Binary machine needs binary alphabet

Using an alphanumeric instead of a binary alphabet and the requirement that the design of the process data coding system should be coupled together with the algorithm implementation leads to a need to replace the coding system with the type concept to design the information representation and computer behavior. Defining a programming language atop of alphanumeric alphabet allows us to better suit the definition to human needs finally we get high-level languages. The type concept is the main subject of the section titled `Information representation`.

### 1.3.7. Aim of the course

This way we finished the theoretical introduction. Maybe it was boring or annoying for you but I believe that it will give you a firm foundation to reach the main aim of the course. It must be stressed that the aim of the course is to deal with the implementation of selected algorithms, not just training that is scoped on the language itself and the development environment in which it is embedded. In order to ensure the practical nature of the course, selected topics are only illustrated using CSharp and the Microsoft Visual Studio development environment. A foundation of the course is that the main goals, design patterns, and discussed scenarios are of generic nature to be easily portable to other environments. The selected language and tools are only used to conduct the discussion using a well-defined environment and ensure that the course achievements are also very practical.

## 1.4. Conclusion

It is time to conclude our discussion and idea exchange related to Information Computation.

The last message from the discussion is that applying computer science could be very helpful to solve our problems and support human beings to improve the performance and robustness of their activity. It is a result of the automation of information processing. A main result of automation is the repeatability of results obtained from information processing. Repeatability enables the applicability of testing as a method to improve robustness. To apply information technology or computer science, as the name says, we must employ technology to implement information processing. We need a driving force - an engine - to realize the processing. Today it is a binary computer but the most important thing is that it is a device governed by physics. This led to the conclusion that abstraction must not be a subject of processing by any device today and in the future.

In this respect, that is in the context of information processing, we must deal with two kinds of information. It is process information describing the state and behavior of a process in concern and an algorithm, which is a piece of knowledge describing the solution of a problem using the computer. Both are tightly coupled and must be represented together using a programming language, which could be compiled into a binary form suitable to be used as a recipe of the computer behavior and process information representation. Today, typically we use high-level languages that are based on an alphanumeric alphabet derived from the Latin alphabet. Syntax of these languages is founded on keywords borrowed from the natural English language and semantics supports object-oriented programming concept. It was emphasized that modern languages use type as a concept to describe process information and algorithms consistently.

Process information representation and algorithm implementation software developer responsibility are tightly coupled but following the previous discussion divided to cover topics related to the design of types and the design of a program as one whole.

The first part titled `Information representation` covers the following examples and associated explanation:

- Coding System versus Type
- Custom types
- Object-oriented programming
- Anonymous Types
- Partial Definitions
- Generic Types and methods

The second part titled `Algorithm Implementation` covers the following examples and associated explanation:

- Program Layered Architecture
- Inter Layers Communication
- Dependency injection

## 1.5. See also

- [Mariusz Postol profile on udemy][MPUdemy]
- [Mariusz Postol profile on GitHub][MPGitHub]
- [Programming in Practice software development skills educational path executive summary][2108-PiP-TP-repository]

[2108-PiP-TP-repository]: https://www.udemy.com/course/pipintroduction/?referralCode=E1B8E460A82ECB36A835
[MPUdemy]:https://www.udemy.com/user/mariusz-postol/
[MPGitHub]:https://github.com/mpostol
