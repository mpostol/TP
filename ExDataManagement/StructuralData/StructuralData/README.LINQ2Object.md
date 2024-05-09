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

# LINQ to Object

- [LINQ to Object](#linq-to-object)
  - [Introduction](#introduction)
  - [Local Structural Data](#local-structural-data)
  - [DataSet to create structural data](#dataset-to-create-structural-data)
    - [Creating](#creating)
    - [Using](#using)
  - [See also](#see-also)

## Introduction

In this chapter, we will continue to discuss topics related to structure data and the possibility of creating queries using LINQ expressions. Let me remind you that the LINQ abbreviation stands for Language Integrated Query. Let's start with a few definitions, explanations, and directions for searching for new solutions to improve access to external data. Here we will again return to the previously introduced term LINQ expression written using the query syntax and compare it with the typical expression.

The main goal of embedding the LINQ expressions into the programming language is to create a construct that allows automatic preparation of queries in a domain-specific language compliant with a remote database management system without leaving a comfort zone, I mean to change the programming language. It allows prefetching data from external repositories (for example relational databases) using the same programming environment. But we also noticed that pre-selection makes sense in the case of local data structures, i.e. certain object graphs. Here we will encounter a challenge of how LINQ can help.

## Local Structural Data

We spent a relatively large amount of time discussing LINQ expression in the context of structured data collected and made available by external data repositories but all operations in the sample program text were performed on local data. Although this was complex data - an array for example - it did not represent relationships between independent objects, so we did not use structured data. Now, let's look at how to design, create, maintain, and use such structures. Here we will also try to answer how LINQ can help us. In particular, if there is a need for separate data pre-selection in the case of local structured data, i.e. a certain object graph.

An example is the [Person][Person] and [CDCatalog][CDCatalog] classes, which are defined in the [TestDataGenerator][TestDataGenerator] class. In the program code we see that the [CDCatalog][CDCatalog] class has references, so a reference, to an object of the [Person][Person] class to represent information about the author of the CD. It is a one-to-one relationship. However, the [Person][Person] class contains a collection of CDs released by a single author, so it has references to objects of the [CDCatalog][CDCatalog] class. This time the relationship is one to many. These references are available as an object implementing `IEnumerable`, and such an object can be used as a data source in a foreach statement and a LINQ expression.

## DataSet to create structural data

### Creating

### Using

Let us now move on to the analysis of the added methods in the context of unit tests filtering data from the structure created in this way. These methods are located as components of the [Catalog][CatalogDataSet] class, or rather in its internal class [PersonRow][PersonRow].

The first [FilterPersonsByLastName_ForEachTest][FilterPersonsByLastName_ForEachTest] uses the `foreach` statement and an internal if statement responsible for filtering the table content according to the value of the method parameter.

``` CSharp
      public IEnumerable<PersonRow> FilterPersonsByLastName_ForEach(string lastName)
      {
        List<PersonRow> _result = new List<PersonRow>();
        foreach (PersonRow _row in this)
          if (_row.LastName.Equals(lastName))
            _result.Add(_row);
        return _result;
      }
```

In addition to the value returned by the method, the type of the returned value and the result of calling its `ToString` method are also examined. Based on the result analysis it could be stated that an object of the generic class `List` is returned. Its type parameter is [PersonRow][PersonRow]. This is the next proof that the result is a collection of selected values.

In the [FilterPersonsByLastName_QuerySyntaxTest][FilterPersonsByLastName_QuerySyntaxTest] we examine the returned value of a method implementing the same filtering algorithm but implemented using a LINQ expression written using the query syntax as a sequence of operations using extension methods. This time the returned object type of the method result is different, which again confirms that LINQ expressions return an object representation of the expression itself, not its result.

The last test [FilterPersonsByLastName_MethodSyntaxTest][FilterPersonsByLastName_MethodSyntaxTest] concerns the implementation of a method using a LINQ expression written following the method syntax. This time the result is identical to the previous one, confirming that the result of using a LINQ expression is always the same regardless of the syntax used. Of course, this statement is true as long as the compiler can translate the program text into a form that allows such transformation during its execution.

## See also

- [Person][Person]
- [CDCatalog][CDCatalog]
- [TestDataGenerator][TestDataGenerator]

[TestDataGenerator]: ../StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L17-L73
[Person]: ../StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L29-L47
[CDCatalog]: ../StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L61-L72
[FilterPersonsByLastName_ForEachTest]:     ../StructuralDataUnitTest/LINQ_to_objectUnitTest.cs#L44-L57
[FilterPersonsByLastName_QuerySyntaxTest]: ../StructuralDataUnitTest/LINQ_to_objectUnitTest.cs#L60-L73
[FilterPersonsByLastName_MethodSyntaxTest]: ../StructuralDataUnitTest/LINQ_to_objectUnitTest.cs#L76-L89

[CatalogDataSet]: LINQ%20to%20object/Catalog.Designer.cs#L25-L1304
[PersonRow]: LINQ%20to%20object/Catalog.Designer.cs#L1136-L1235
[CDCatalogEntityRow]: LINQ%20to%20object/Catalog.Designer.cs#L959-L1131
