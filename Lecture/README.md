
# C# Data-intensive Programming [*DRAFT*]

### Key words:

education, training, data management, information processing, data processing

## Subject

Computer science in general, and especially programming activities, is a field of knowledge that deals with the automation of the information processing. Programs can be recognized as a driving force of this automated behavior.  To achieve information processing goals programs have to implement algorithms required by the application in concern. In other words, the programs describe how to process data, which represent information relevant to the application. Therefore, the data management is - apart from the implementation of the algorithms - a key issue from the point of view of automation of the entire information processing and computer science in general.

Let's review selected language constructs, patterns, and frameworks targeting data-intensive programming.
 
## Goal 

The aim of the course is to extend the knowledge and skills related to object-oriented programming focusing on the interoperability between the computing process and the data visualization, archiving and networking environment. Particular emphasis is placed on the identification of solutions that can serve as a certain pattern with the widest possible use over a long time horizon. Providing a long time horizon is extremely difficult for such a dynamically developing field. The author's experience comes to the rescue, which has been used by similar solutions for years, using constantly changing programming tools.

In order to ensure the practical context of the discussion and provide sound examples, all topics are illustrated using the C# language and the MS Visual Studio design environment. The source code used during the course is available in this repository. I believe that the main theses, design patterns, and scenarios used are generic in nature and may be seamlessly ported to other environments. The language and tools mentioned have been used only to embed discussions in a particular environment and to ensure that the course is very practical.

The course discusses solutions for practical scenarios regarding various aspects of process data management, i.e. those that are input or output for the business logic of the program. In general, three types of data have been distinguished:

- **streaming**: files, network packets
- **structural**: databases
- **graphical**: Graphical User Interface

What we are going to achieve - the result or achievement toward which effort is directed.


## Scope

The repository is scoped to provide sound examples covering the following topics:

1. Introduction
	1. About the course, information versus data, algorithm versus program, type - what it means
	2. Useful assets: C# language, Visual Studio, GitHub 
	3. Program robustness: exception, unit tests, environment simulation 
2. Data semantics
 
	1. Type and type compatibility
	5. Anonymous type
	6. Partial types and methods
	7. Generics 
3. Data streams

	1. Open, modification, close
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

	1. Delegates and events
	19. [xaml](https://docs.microsoft.com/en-us/dotnet/framework/xaml-services/)
	20. MVVM (Model, View, ViewModel) pattern

> **NOTE**: Unit Test role is code explanation rather than testing the correctness of it. 
