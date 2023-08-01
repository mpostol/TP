# Information Computation Course Description

## Welcome

I would like to invite you to participate in a course on `Information Computation`. The course is a part of the Programming in Practice series of courses.

My point is that we could distinguish between two kinds of education:

1. training - focused on products adoption and maintenance
2. learning - focused on knowledge (concepts, standards, best practices, etc) adoption and maintenance

This curse will focus on p. 2 - the improvement of your knowledge related to software engineering. My goal is that it will be beneficial for you in the long run.

Anyway, to learn more about programming in practice meaning check out the free introduction to the series of courses titled [Programming in Practice - Executive summary][udemyPiPES]. It is a free course published on [udemy.com][MPUdemy]. Consider enrolling in.

Check the course from Udemy. Consider enrolling in.

- [Programming in Practice - Information Computation; Udemy course, 2023][udemyPiPIC] - Information Computation means a process engaging a computer (a physical device) to process information as a series of actions or steps taken to achieve a particular result or help to fulfill a task. The main challenge is that information is abstract. Precisely speaking, it is a kind of knowledge that cannot be processed directly by any physical device. Generally speaking, To resolve this inconsistency two main topics are covered. The first one refers to selected aspects of information modeling using types as descendants of a coding system. The second one covers program architecture design patterns to improve the design and deployment of the computer behavior description using a program implementing an algorithm.

## Instructor Intro

My name is Mariusz Postół. If your job or professional career depends on software development skills, consider joining us to learn how to improve your knowledge and experience in this respect. I'm gonna share with you the principles of a learning concept called Programming in Practice - Information Computation. It has evolved atop 30 years of experience gathered by me as a University teacher and leader of hundreds of innovative IT projects realized, among others, for aviation, energy, tobacco, and mines industries. I am also an author and project leader of commercial software packages published on GitHub as open-source software. Since 1994 - that is from the very beginning - I am also a lecturer at Lodz University of Technology. If you are serious about programming skills, I believe that this mixture will cause a synergy effect. Welcome and thank you for joining the community.

## Aim of the course

Concluding, the aim of the course is to deal with the implementation of selected algorithms, not just training that is scoped on the language itself and the development environment in which it is embedded. In order to ensure the practical nature of the course, selected topics are illustrated using CSharp and the Microsoft Visual Studio integrated development environment. The main assumption of the course is that the main goals, design patterns, and discussed scenarios are of generic nature to be easily portable to other environments. The selected language and tools are only used to conduct the discussion using a well-defined environment and ensure that the course achievements are also very practical.

## Outline

### Section 1 - Information Computation Fundamentals

This section covers the following topics:

- Introduction
- Information versus data
- Algorithm Versus Program

### Section 2 - Information Representation

This section covers the following topics:

- Coding System versus Type
- Custom types
- Object-oriented programming
- Anonymous Types
- Partial Definitions
- Generic Types and methods

### Section 3 - Algorithm Implementation

This section covers the following topics:

- Program Layered Design Pattern
- Inter-layers Communication
- Dependency Injection

### Section 4 - Summary

This section covers the following topics:

- Conclusion

## Course Content

### Preface

The associated course on Udemy is about information computation in practice. We will start with the statement that the course title is a bit provoking because information is abstract and cannot be directly subject to processing by a physical computer even if a computer and implemented algorithm make up a powerful artificial intelligence bot that is capable of understanding human speech and producing in-depth writing that humans easily understand. While learning, we distinguish the following information kinds: process information and algorithm. The process information describes the state and behavior of a physical process in concern. In turn, the algorithm is a piece of information describing how to solve the problems related to the problem in concern. The course addresses topics that are vital for overcoming this inconsistency in practice.

The main goal of the course is to concentrate on learning - it means focussing on knowledge adoption. It focuses on learning rules related to information computation but not training in a particular language or development tool. To make the learning outcomes practical the examples are indispensable. To avoid overloading the examples with details unimportant for investigated topics, it is proposed to apply extended examples. By extended examples, we mean examples that can be executed as independent unit tests. This way, you can observe not only a pattern but also trace the behavior of selected code snippets. I believe that it should also improve the reusability of the examples. By design, the unit tests are used to validate the correctness and consistency of a program. The role of the unit tests included in the attached examples is significantly different. They are created with teaching values in mind. By design, they are used to make the examples intelligible and add the possibility to analyze also the behavior of the code patterns presented here. As a result of this approach, the examples are not obscured by a bunch of unimportant details needed to execute the examples as a part of an entire program.

This Information Computation course is a member of the courses suite titled Programming in Practice. Hence, more details about the rules overseeing this course you can find in the independent free course titled [Programming in Practice - Executive Summary][udemyPiPES] - consider enrolling and passing it if haven't yet.

### Information Computation Fundamentals

You will learn that the process information is an abstraction and, hence, cannot be subject to processing by any physical machine, including computers. This inconsistency can be overcome by applying coding systems. In reality, this way, we are computing the data but not the information. Fortunately, this way we can address the challenge that the same information could have an infinitive number of representations. To realize the processing., we need a driving force - an engine. Today it is a binary computer. Hence, in the context of information computation, we must deal with two kinds of information: process information and algorithm. The process information describes the state and behavior of a process in concern. In turn, the algorithm is a piece of information on how to solve the selected problem. Both are tightly coupled and must be represented together using a programming language, which is suitable to be used as a recipe of the computer behavior and information representation of a process in concern.

Computers are programmable devices and need a kind of program to be controlled. To accomplish it, we use high-level languages based on an alphabet derived from the Latin alphabet. Syntax of these languages is founded on keywords borrowed from the natural English language and semantics supports object-oriented programming concept. Informally, they are designed to produce text that is more human-readable and easier to use. Modern languages consistently use the type concept to describe process information representation and algorithms implementation. The object-oriented programming concept is the foundation of this learning path.

### Information Representation Using Types and object-oriented programming

In this part, we recognize the type definitions as a part of a programming language that is a set of syntax and semantics rules governing a text of a computer program. The main idea behind custom types is the possibility to represent practically any process information to be the subject of computation. Types are used to control the program consistency if the programming language is strongly typed. Hence by applying types, we could improve the robustness of the development outcome. The course prepares you to define new custom types. You will learn that using modern programming languages, new types may be defined from scratch or derived from existing ones. To accomplish it, the object-oriented programming concept could be recognized as a very helpful learning outcome. Additionally, the application of this concept allows us to solve polymorphic problems and organize the interoperability of software program parts using abstraction, inheritance, and encapsulation. Additionally, abstraction may be recognized as a concept to harmonize the development process of the software program parts.

### Algorithm implementation

It is stressed that the process information representation and algorithm implementation are tightly coupled and must be the subject of a computer program development using a selected programming language. Computer programs begin their time cycle as text that must be compliant with a programming language. The course addresses methods and patterns that may be applied to manage the program text as one whole with the purpose to make teamwork easier, allow independent testing, decoupling the development outcome from the technology change, and make scalability easier, to name only the most important. A computer program begins its life cycle as a text that follows the rules of a selected programming language. To decrease the production cost and improve robustness, we consider organizing the computer program text into autonomous fragments addressing typical responsibilities. There are many design patterns applicable in this respect but the layered design pattern is best-suited to be applied to the program as one whole.

The program development should be commenced by researching knowledge helpful to solve a problem in concern or achieve the computation goal. This knowledge as one whole we call algorithm. The separation of concerns is a very useful concept while working on algorithms. From sociology we know, that the separation of concerns improves our performance of thinking because as a result, we may think about independent topics with minimal overlapping between them. So to improve our productivity we must leverage separation while working on the computer program text. You will learn that the main challenge is to decide when and where we should deal with the separation of concerns - while thinking about the solution or while implementing it as a text.

It is proposed to implement this separation by applying the layered design pattern to the program as one whole. During the Information Computation course, we stress that thanks to this approach the following benefits may be accomplished: separation of concerns, simultaneous development, independent testability, resistance to changes in technology, and scalability. Finally, thanks to mentioned benefits you will be able to decrease development time and time to market. Usually talking about a layered design pattern we may distinguish three layers: the presentation, logic, and data. Getting more about implementation, the responsibility of layers, and the expected benefits are the next learning outcomes. Layers may be implemented using sets of custom-type definitions. These definitions must either be self-contained within the layer, or they may depend on declarations that are exposed by the layer beneath it. During the course, you will learn how to recognize the membership. To make the layer unambiguous it must be assumed that any type belongs only to one set, to one layer. This way we convert the discussion about mathematical sets to the examination of types grouping. The main goal is to keep the discussion as practical as possible.

By design, the layered program architecture means its organizations, in which we can distinguish independent entities of a program related to each other making a unidirectional top-down hierarchy. The top-down relationship means that the layer above only refers to the declarations exposed by the layer below. You will learn that it is a compile-time pattern. At run-time, we must consider control flow and data flow in both directions between layers. Hence, the next challenge addressed by the course is how to implement the bidirectional communication of layers at run time using a unidirectional dependency relationship. You will learn that inter-layer communication may be categorized into control flow, data transfer, and event notification. During the course, to make the learning outcome practical, we explore various examples of inter-layer communication, including but not limited to properties, callbacks, events, reactive programming, and dependency injection. Some of them may also be referred to as inversion of control.

The next part of the course covers the applicability of the dependency injection design pattern in practice. During the course, it is stressed that the main point of this design pattern is an assignment to an abstract variable a reference to an instance of an invisible type that is derived from this abstraction and which cannot be instantiated at the intended location of instance invocation for some reasons. I named this pattern dependency injection to somehow distinguish this scenario from using just object-oriented programming alone. We are using object-oriented programming to deal with the separation of concerns. One concern is the usage, and the second one is the implementation of a concrete type. Hence, shortly the dependency injection is considered as a design pattern where we are using an abstraction in place of an unknown for some reason concrete reference type to transfer an instance of this type from one place to another. You will learn more about using this design pattern to implement independent testing and bidirectional inter-layer communication.

The dependency injection design pattern uses abstraction to create an agreement between the creation and usage of an instance. The abstraction is employed to specify the property type (property injection) or the formal parameter type of the method or constructor (method or constructor injection). This design pattern eliminates the requirement for visibility of a specific definition of the concrete type in the usage intended location.

## See Also

- [Programming in Practice - Information Computation; Udemy course, 2023][udemyPiPIC] - Information Computation means a process engaging a computer (a physical device) to process information as a series of actions or steps taken to achieve a particular result or help to fulfill a task. The main challenge is that information is abstract. Precisely speaking, it is a kind of knowledge that cannot be processed directly by any physical device. Generally speaking, To resolve this inconsistency two main topics are covered. The first one refers to selected aspects of information modeling using types as descendants of a coding system. The second one covers program architecture design patterns to improve the design and deployment of the computer behavior description using a program implementing an algorithm.
- [Programming in Practice - Executive Summary; Udemy course; 2021][udemyPiPES]; This free course explains the role of this repository as the extended examples storage that is a foundation for the Programming in Practice paradigm. The course is for all serious about the improvement of the software development skills education methodology.
- [Postol. M, profile on Udemy.com][MPUdemy]

[udemyPiPIC]: https://www.udemy.com/course/information-computation/?referralCode=9003E3EF42419C6E6B21
[udemyPiPES]: https://www.udemy.com/course/pipintroduction/?referralCode=E1B8E460A82ECB36A835
[MPUdemy]:https://www.udemy.com/user/mariusz-postol/
