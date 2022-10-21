# 1. Computation of Information

## Table of content <!-- omit in toc -->

- [1. Computation of Information](#1-computation-of-information)
  - [1.1. Preface](#11-preface)
  - [1.2. Executive Summary](#12-executive-summary)
    - [1.2.1. Welcome (TH)](#121-welcome-th)
    - [1.2.2. Instructor Intro (TH)](#122-instructor-intro-th)
    - [1.2.3. What's the problem?](#123-whats-the-problem)
      - [1.2.3.1. Introduction](#1231-introduction)
      - [1.2.3.2. Information and Computation Meaning](#1232-information-and-computation-meaning)
      - [1.2.3.3. Computer Science Definition](#1233-computer-science-definition)
      - [1.2.3.4. Information Processing Applicability Scope](#1234-information-processing-applicability-scope)
      - [1.2.3.5. Information as a knowledge](#1235-information-as-a-knowledge)
      - [1.2.3.6. Information Processing Summary](#1236-information-processing-summary)
      - [1.2.3.7. Contradiction](#1237-contradiction)
    - [1.2.4. Outline of Scope](#124-outline-of-scope)
    - [1.2.5. Education context](#125-education-context)
      - [1.2.5.1. Language](#1251-language)
      - [1.2.5.2. Development Environment](#1252-development-environment)
      - [1.2.5.3. GitHub](#1253-github)
      - [1.2.5.4. Working as a Team](#1254-working-as-a-team)
      - [1.2.5.5. How to Use Supporting Entities](#1255-how-to-use-supporting-entities)
    - [1.2.6. Define your audience](#126-define-your-audience)
    - [1.2.7. Learning outcomes and benefits (TH)](#127-learning-outcomes-and-benefits-th)
    - [1.2.8. That's all For Now](#128-thats-all-for-now)
  - [1.3. Information versus data](#13-information-versus-data)
  - [1.4. Algorithm Versus Program](#14-algorithm-versus-program)
  - [1.5. Summary](#15-summary)

## 1.1. Preface

Information Computation means a process engaging a computer (a physical device) to process information as a series of actions or steps taken in order to achieve a particular result or help to fulfill a task. The main challenge is that information is abstract, it is a kind of knowledge that cannot be processed directly by any physical device. This solution contains code that by design is to be used as a set of examples for an online video course and class lectures. The examples can also be used alone.

Generally speaking, two main topics are covered. That is dealing with the data recognized as the information representation and behavior description using a program compliant with an algorithm. 

- C# Language introduction
- TP repository relationship
- Content description.
 
## 1.2. Executive Summary

### 1.2.1. Welcome (TH)

I would like to invite you to participate in a course on information processing. The course is a part of the Programming in Practice series of courses. This lesson covers introductory topics. My point is that we could distinguish between two kinds of education:

1. training - focused on products adoption and maintenance
2. learning - focused on knowledge (concepts, standards, best practices, etc) adoption and maintenance

This curse will focus on p. 2 - the improvement of your knowledge related to software engineering. My goal is that it will be beneficial for you in the long run.

### 1.2.2. Instructor Intro (TH)

My name is Mariusz Postół. If your job or professional career depends on software development skills, consider joining us to learn how to improve your knowledge and experience in this respect. I'm gonna share with you the principles of a learning concept called Programming in Practice - information Computation. It has evolved atop 30 years of experience gathered by me as a University teacher and leader of hundreds of innovative IT projects realized, among others, for aviation, energy, tobacco, and mines industries. I am also an author and project leader of commercial software packages published on GitHub as open-source software. Since 1994 - that is from the very beginning - I am also a lecturer at Lodz University of Technology. If you are serious about programming skills, I believe that this mixture will cause a synergy effect. Welcome and thank you for joining the community.

### 1.2.3. What's the problem?

#### 1.2.3.1. Introduction

All lessons in this course begin by trying to define the most important topics that are vital to the lesson. And now let's try to answer the question of what the problem is, but in the context of the entire course - as an introduction to the course as one whole. Let's start by investigating the meaning of the title keywords.

#### 1.2.3.2. Information and Computation Meaning

To learn more about programming in practice meaning check out the free introduction to the series of courses titled "Programming in Practice - Executive summary". It is a free course. Consider enrolling in. Let us try to start our research by answering a very fundamental question what is computer science, the main field of our activity I mean software engineering.

#### 1.2.3.3. Computer Science Definition

> **Computer Science**: is the study of computers and computational systems. Computer scientists deal mostly with software and software systems; this includes their theory, design, development, and application.

This definition says that Computer Science is the study of computers and computational systems. Computer scientists deal mainly with software and software systems; this includes their theory, design, development, and application. In general, we can conclude that it is dedicated to information processing - it deals with information processing and the production of systems used to process information. Unfortunately, I have a couple of problems with this definition.

#### 1.2.3.4. Information Processing Applicability Scope

The first problem I have is the meaning of the term information processing itself. For example, are medicine or journalism not concerned with information processing? They also use technology. Here we need to make a certain distinction between what doctors and journalists do and our activities as software developers. This question is the easiest to answer because we can say that computer science deals with the automation of the information processing process. Thanks to this, we can say that computer science is a service field that allows us to provide solutions, i.e. information processing systems that will be used in medicine, for example for diagnostics or in journalism for the publication of a new edition of a newspaper. Concluding in our activity we should pay special attention to producing software that guarantees the repeatability of outcomes

#### 1.2.3.5. Information as a knowledge

In this context, the information term should be understood as knowledge about the state and behavior of the process in concern. The process that we want to monitor or control, with the use of devices, with the use of technology, with the use of computers to be precise - to achieve the goal automatically.

#### 1.2.3.6. Information Processing Summary

Explaining the title of our course, we came to the conclusion that the discussion concerns the automation of information processing. This process is based on two tightly coupled terms. The first relevant term is **information** about a process - shortly called process information. The process information must be recognized as knowledge about the state and behavior of the process. The second term is the **algorithm**, which again is information but this time about how to solve the problem in concern. In other words, we can say that processing must be implemented based on a knowledge of how to achieve a goal, or how to solve a given problem by applying information processing. That is algorithm could be recognized as an abstract description of the information processing behavior.

#### 1.2.3.7. Contradiction

Concluding, the automation of information processing requires the use of technology, and therefore a computer. A computer is a device that is governed by the laws of physics. And here we come to a fundamental contradiction, namely, during this course, we need to answer the question of how a physical machine can process something that is abstract, namely information. The problem addressed by this course is how to represent process information and implement algorithms to be suitable for computation that is processing using a computer device.

### 1.2.4. Outline of Scope

Referring to the previous discussion, the automation of information processing requires the use of technology, and therefore a computer. A computer is a device that is governed by the laws of physics. And here we come to a fundamental contradiction, namely, we need to answer the question of how a physical machine can process something that is abstract, namely information. In this section, we will continue a more or less theoretical discussion necessary to make a foundation for further learning related to information representation as a consistent part of programming language. After that, the next section is focused on how to represent process information. It covers the fundamentals of types in the context of object-oriented programming. We will also learn some special approaches to types definitions, namely anonymous, partial, and generic types. Last but not least section covers selected aspects of algorithm implementation using the object-oriented programing concept and layered program architecture. The main goal is to deal with software engineering fundamentals. Concluding, the main goal is to understand the applicability scope - reasons why we need all that special and more or less dedicated solutions and principles of the program architecture.

### 1.2.5. Education context

#### 1.2.5.1. Language

As a general goal of the course, we will focus on learning rules but not training in a particular language or development tool. To make sure that our discussion is practical and implementable we must use a selected programming language as a context for further explanation. I have selected CSharp to prepare examples that are to be explored during deploying the Information Computation course. But let me get ahead of your doubts and stress now that in principle the programming language is considered only a tool to write down examples. According to the main assumption of the course, I hope it will be not an obstacle to port solutions to another development environment dominated by other programming languages.

#### 1.2.5.2. Development Environment

Again, to make our discussion about programming practical we must distinguish between design-time and run-time environments. Both are tightly coupled but the possibility to trace the behavior of the examples at run time is very important for the `Programming in Practice` as a learning path and also for the `Information Computation` course. I selected Visual Studio as the integrated development environment to be used to deal with examples in the course.

#### 1.2.5.3. GitHub

All topics covered by the course are discussed in the context of examples stored in a public repository. I have selected GitHub to store the code examples. Additionally, GitHub is a perfect solution because it allows improvement or adding new examples. All examples used during the course are gathered in the TP public open-source repository.

#### 1.2.5.4. Working as a Team

Today almost always software is developed by teams. That is tightly coupled contributors. Hence you have to be prepared to work as a team member. We cannot organize real teamwork, so I propose to apply community collaboration by employing the GitHub repository. The  GitHub repository is not only the storage of reusable open-source software but is also a collaboration platform. When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change. Visit the repository to follow the contribution rules in all your interactions with the repository.

#### 1.2.5.5. How to Use Supporting Entities

Discussing details on how it works and how to use the mentioned above tools is a good subject for a few independent courses. However, at least we must know how to get started. Enroll in and finish the free course titled [Programming in Practice - Executive Summary](https://www.udemy.com/course/pipintroduction/?referralCode=E1B8E460A82ECB36A835) to get more on how to use the CSharp language, Visual Studio, and GitHub repository. Check it out also if you need more information about the Programming in Practice general educational path this course is compliant with.

### 1.2.6. Define your audience

To begin with, let's start by defining the target group. The course is intended for students and teachers who have knowledge and experience related to programming fundamentals. It is not a hard requirement, but rather a recommendation, but it is advisable to already have some knowledge and experience in object-oriented programming. Certainly, it will be useful to recall such concepts as instruction, method, type, class, interface, reference, iteration, recursion, polymorphism, inheritance, abstraction, encapsulation,  etc. Although the goal of the course is not to learn the selected programming language or the development environment, the knowledge of CSharp, the MS Visual Studio environment, and the GitHub repository, which are used to present sample programs, will be very helpful. Enroll in and finish the free course [Programming in Practice - Executive Summary](https://www.udemy.com/course/pipintroduction/?referralCode=E1B8E460A82ECB36A835) to accommodate this requirement. Usually, background knowledge is enough to finish successfully this course and reuse the knowledge and experience you will get.

### 1.2.7. Learning outcomes and benefits (TH)

In the context of examples, you will learn how to use types to represent custom information and how to organize the program text compliant with the layered architecture. After the course, you will be familiar with a vast variety of methods that can be applied to design the object model as a subject for further information computation. You will also be able to

- select appropriate methods to spread the work of a team according to the separation of concerns rules,
- organize the obtained this way program parts using unidirectional layers relationship (dependencies), and
- make them interoperable using bidirectional communication engaging reactive programming, dependency injection, and inversion of control.
 
All discussion is conducted based on the examples gathered in a dedicated solution and maintained using a GitHub repository. These examples are ready to use as a foundation for programming skills learning. All the time I will keep the discussion on a level that guarantees common and easy portable conclusions, which are applicable independently of the used development environment.

### 1.2.8. That's all For Now

That's all for now. Thank you for your time and see you again during the next lesson. The next lesson will address a discussion that allows us to distinguish two important terms, namely information, and data.

## 1.3. Information versus data

**TBD**:

## 1.4. Algorithm Versus Program

**TBD**:

## 1.5. Summary

**TBD**:
