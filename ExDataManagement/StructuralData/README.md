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

This section is focused on structural data. Let's analyze this case using sample code. An example is the [IPerson][IPerson] and [ICDCatalog][ICDCatalog] interfaces. Now let's perform a graphical analysis of the code. We can see the a reference between interfaces in the diagram.

![PersonCodeMap](.Media/IPersonCodeMap.png)

The mentioned interfaces are abstract definitions. To instantiate a graph of objects based on these definitions they have to be implemented first. We will analyze a few different implementations of them. In contrast, they always represent the same structure built up using reference types added to the [IPerson][IPerson] definition and mentioned in the following line:

``` CSharp
    IEnumerable<ICDCatalog> CDs { get; }
```

An example implementation of them is the [Person][Person] and [CDCatalog][CDCatalog] couple of classes, which are defined in the [TestDataGenerator][TestDataGenerator] class. It is worth stressing here that it is a fully manual implementation. In the referred snippet, the [Person][Person] class contains a representation of a set of albums released by one author, so it has references to instances of the [CDCatalog][CDCatalog] type. This code snippet is included in the unit test project and used later to analyze the next use case of creating a similar structure but this time using a dedicated embedded tool.

Now let's perform a graphical analysis of the presented code. We can see the same reference between classes in the diagram. This relationship between types is a result of the relationship between the interfaces and can be used to create structured data, i.e. a certain group of objects interconnected by references. This group is often called a graph.

![PersonCodeMap](.Media/PersonCodeMap.png)

## See also

* [Language Integrated Query (LINQ)](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/linq)
* [Query Syntax and Method Syntax in LINQ (C#)](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq)
* [LINQ to SQL tools in Visual Studio](https://docs.microsoft.com/visualstudio/data-tools/linq-to-sql-tools-in-visual-studio2?view=vs-2017)
* [LINQ to SQL](https://docs.microsoft.com/dotnet/framework/data/adonet/sql/linq/)
* [Entity Framework Documentation](https://docs.microsoft.com/ef/)

[IPerson]: StructuralData/Data/IPerson.cs#L16-L22
[ICDCatalog]: StructuralData/Data/ICDCatalog.cs#L14-L19
[TestDataGenerator]: StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L17-L73
[Person]: StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L29-L58
[CDCatalog]: StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L60-L70