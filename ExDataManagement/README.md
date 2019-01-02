# C# External Data-intensive Programming (ExDM)

## Key words:

education, training, external data, data management, information processing, data processing

## Subject

Computer science in general, and especially programming activities, is a field of knowledge that deals with automation of information processing. Programs can be recognized as a driving force of that automated behavior. To achieve information processing goals programs have to implement algorithms required by the application concerned. In other words, the programs describe how to process data, which represent information relevant to the application. Data management - apart from the implementation of the algorithms – is, therefore,  a key issue from the point of view of automation of the entire information processing and computer science in general.

Let's review selected language constructs, patterns, and frameworks targeting data-intensive programming.
 
## Goal 

The aim of the course is to extend knowledge and skills related to object-oriented programming focusing on interoperability between the computing process and data visualization, archiving and networking environment. Particular emphasis is placed on the identification of solutions that can serve as a certain pattern with the widest possible use over a long-term horizon. Providing a long-term horizon is extremely difficult for such a dynamically developing field. Here, the experience of the author comes to the rescue, who has been employing similar solutions for years using constantly changing programming tools.

In order to ensure the practical context of the discussion and provide sound examples, all topics are illustrated using the C# language and the MS Visual Studio design environment. The source code used during the course is available in this repository. I believe that the proposed principles, design patterns, and scenarios are generic in nature and may be seamlessly ported to other environments. The language and tools mentioned above have been used only to embed the discussion in a particular environment and to ensure that the course is very practical.

The course discusses solutions for practical scenarios regarding various aspects of process data management, i.e. those that are input or output for the business logic of the program. In general, three classes of an external data have been distinguished:

- **streaming**: files, network packets
- **structural**: databases
- **graphical**: Graphical User Interface (GUI)

The external data is recognized as the data we must pull or push from outside of the process hosting the computer program.

## Scope

The repository is scoped to provide sound examples covering the following topics:

1. Introduction
	1. About the course, information versus data, algorithm versus program, type - what does it mean
	2. Useful assets: C# language, Visual Studio, GitHub 
	3. Program robustness: exception, unit tests, environment simulation 
2. Data semantics
	1. Type concept
	5. Anonymous type
	6. Partial types and methods
	7. Generics 
3. Data streams
	1. File and Stream Concepts
	9. Attributes
	10. Reflection
	11. Serialization
	12. Cryptography basics
4. Functional programming basics
	1. Anonymous function and lambda expression
	14. Extension method
5. Structural Data
	 1. LINQ query and methods syntax
	16. LINQ to object
	17. LINQ to SQL
5. Graphical data
   1. [xaml](https://docs.microsoft.com/en-us/dotnet/framework/xaml-services/)
	19. MVVM (Model, View, ViewModel) pattern

> **NOTE**: Unit Test role is solely code explanation rather than testing the correctness of it. 

<!--//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________
-->
