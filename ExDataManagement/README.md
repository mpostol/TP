# External Data Management (ExDM)

## Key words

software engineering, education, learning, external data, data management, information processing, data processing,  serialization, SQL, LINQ, XAML, GUI

## Introduction

### Subject

Computer science in general, and especially software engineering, is a field of knowledge that deals with the automation of information processing. Programs can be recognized as a driving force of that automated behavior. To achieve information processing goals programs have to implement algorithms required by the application. In other words, the programs describe how to process data, which represents information relevant to the application. Apart from the implementation of the algorithms, therefore, data management is a key issue from the point of view of automation of information processing in particular and computer science in general. Let's review selected language constructs, design patterns, and frameworks targeting external data management by a program.

### Goal

The main aim, of the collected code snippets in this folder, is to extend knowledge and improve skills related to object-oriented programming focusing on interoperability between the computing process and data visualization, archiving, and networking resources. Particular emphasis is placed on the identification of solutions that can serve as a certain design pattern with the widest possible use in the long run. Providing solutions valid for a long-term horizon is extremely difficult for such a dynamically developing field. Here, the experience of the author comes to the rescue, who has been employing similar solutions for years using constantly changing programming tools.

To ensure the practical context of the discussion and provide sound examples, all topics are illustrated using the C\# language and the MS Visual Studio design environment. The source code used during the course is available in this repository. I believe that the proposed principles, design patterns, and scenarios are generic and may be seamlessly ported to other environments. The language and tools mentioned above have been used only to embed the discussion in a particular environment and to ensure that the course is very practical.

The course discusses solutions for practical scenarios regarding various aspects of external process data management.  In general, the external data may be grouped as follows:

- **streaming** - bitstreams managed using content of files, or network payload
- **structural** - data fetched/pushed from/to external database management systems using queries
- **graphical** - data rendered on Graphical User Interface (GUI)

The external data is recognized as the data we must pull or push from outside of a boundary of the process hosting the computer program.

## Scope

In the `ExDataManagement` folder, the code snippets are scoped to provide sound examples covering the following topics:

- Section 1 - Introduction
  - Lesson 01 - Executive Summary
    - About the course, information versus data, algorithm versus program, type - what does it mean
    - Useful assets: C\# language, Visual Studio, GitHub
  - Lesson 02 - Data semantics
    - Type concept
    - Anonymous type
    - Partial types and methods
    - Generics
- Section 2 - Data streams
  - Lesson 03 - File and Stream Concepts
  - Lesson 04 - Attributes
  - Lesson 05 - Reflection
  - Lesson 06 - Serialization
  - Lesson 07 - Cryptography basics
- Section 3 - Structural Data](#3-section-3---structural-data)
  - Lesson 08 - Anonymous function and lambda expression
  - Lesson 09 - Extension method
  - Lesson 10 - LINQ query and methods syntax
  - Lesson 11 - LINQ to object
  - Lesson 12 - LINQ to SQL
- Section 4 - Graphical data
  - Lesson 13 - Graphical data (Part 1)
    - [xaml](https://docs.microsoft.com/dotnet/framework/xaml-services/)
  - Lesson 14 - Graphical data (Part 2)
    - MVVM (Model, View, ViewModel) design pattern
- Section 5 - Summary
  - Lesson 15 - Conclusion

> **NOTE**: Unit Test role is solely code explanation rather than testing the correctness of it.

## Lesson 15 - Conclusion

TBD

## See also

- [Programming in Practice - Executive Summary; Udemy course; 2021][udemyPiPES]; The course explains the role of this repository as the extended examples storage that is a foundation for the Programming in Practice paradigm. The course is for all serious about the improvement of the software development skills education methodology.
- [Programming in Practice; GitBook eBook](https://mpostol.gitbook.io/pip/) - The content of this eBook is auto-generated using the markdown files collected in this repository. It is distributed online upon the open access rules.
- [Discussion panel][Discussion]
- [Postół. M, Programming Technologies 2021; Recorded lectures](https://youtube.com/playlist?list=PLC7zPvgw-YbyWXRTAe9m-ABP9YWmpLvUk)
- [Postół. M, Programming Technologies 2020; Recorded lectures](https://youtube.com/playlist?list=PLC7zPvgw-YbwOD3GaSPl6kzKhDRmmrA-9)
- [Postol. M, profile on Udemy.com][MPUdemy]

[Discussion]: https://github.com/mpostol/TP/discussions
[MPUdemy]:https://www.udemy.com/user/mariusz-postol/
[udemyPiPES]: https://www.udemy.com/course/pipintroduction/?referralCode=E1B8E460A82ECB36A835

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
