<!--
//________________________________________________________________________________________________________________
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the 
// discussion panel at https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//________________________________________________________________________________________________________________
-->

# Structural Data Preface

Generally speaking, we can say that data processing is carried out through the execution of operations. From this point of view, we can divide the data into:

1. **Simple data** - in this case, the data can be processed by a single operation, it is one action as a result of which the value is referred to as one whole. For example, changing the sign of an int variable.
2. **Complex data** – here the data is composed of components. Therefore, to operate on complex data we need a selector operation to select a component that is to be subject to an operation. The selection method is determined by the data type, e.g. index for arrays and field selection for class or structure.
3. **Structured data** - by design, the distinguishing feature is that individual data items in a structure are selected based on intentionally programmed relationships between items.

This section is focused on structural data. Let's analyze this case using sample code. An example is the [Person][Person] and [CDCatalog][CDCatalog] classes, which are defined in the [TestDataGenerator][TestDataGenerator] class. In the program code, we see that the [CDCatalog][CDCatalog] class has references to an object of the [Person][Person] class to represent information about the author of the CD. The [Person][Person] class, on the other hand, contains a representation of a set of albums released by one author, so it has references to objects of the [CDCatalog][CDCatalog] class. This code snippet is included in the unit testing project and will be used later to analyze the use cases of the LINQ expression.

Now let's perform a graphical analysis of the code. We can see the references between classes in the diagram. Therefore, structured data, i.e. a certain set of objects interconnected by references, is often called a graph.

![PersonCodeMap](.Media/PersonCodeMap.png)

## See also

* [Language Integrated Query (LINQ)](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/linq)
* [Query Syntax and Method Syntax in LINQ (C#)](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq)
* [LINQ to SQL tools in Visual Studio](https://docs.microsoft.com/visualstudio/data-tools/linq-to-sql-tools-in-visual-studio2?view=vs-2017)
* [LINQ to SQL](https://docs.microsoft.com/dotnet/framework/data/adonet/sql/linq/)
* [Entity Framework Documentation](https://docs.microsoft.com/ef/)

[TestDataGenerator]: StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L17-L73
[Person]: StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L29-L47
[CDCatalog]: StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L61-L72