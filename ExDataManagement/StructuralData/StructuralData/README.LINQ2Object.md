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

# 1. LINQ to Object

- [1. LINQ to Object](#1-linq-to-object)
  - [1.1. Introduction](#11-introduction)
  - [1.2. DataSet - Creating Structural Data](#12-dataset---creating-structural-data)
  - [1.3. DataSet - Usage](#13-dataset---usage)
  - [1.4. See also](#14-see-also)

## 1.1. Introduction

In this chapter, we will continue to discuss topics related to structural data and the possibility of creating queries using LINQ expressions. Let me remind you that the LINQ abbreviation stands for Language Integrated Query. The main goal of embedding the LINQ expressions into the programming language is to create a construct that allows automatic preparation of queries in a domain-specific language compliant with a remote database management system without leaving a comfort zone, I mean to change the programming language. It allows data management in external repositories (for example relational databases) using the same development environment. But we also noticed that data pre-selection makes sense in the case of local data structures, i.e. certain object graphs. Here we will encounter a challenge of how LINQ can help.

By design, in-process structural data doesn't need any special prefetching data access mechanism. A naive approach is that we don't need in-process data in case we are going to maintain the process data in external repositories. By definition, instead of processing data on the database site computer programs work on local variables. In other words, local variables are a natural environment for data processing addressed by the education classes and programming languages. It leads to

- limiting the operations executed on a repository site only to create, read, update, and delete (shortly CRUD) operations
- maintaining a sort of in-memory snapshot using in-process local variables
- mapping database schema to types of variables  and vice versa

CRUD operations are actions used to manage data in a database. The **Create** (C) operation inserts new data into database content. The **Read** (R) operation retrieves existing data from the database to local variables. The **Update** (U) operation modifies existing data in the database. The **Delete** (D) operation removes data from the database. Understanding CRUD operations is crucial for building robust programs for all kinds of databases.

A set of variables are value holders when data is retrieved from the database. They represent a partial snapshot of the data at that moment. Any changes made to the data should be persisted back to the database to make database content consistent. This relationship requires a synchronization mechanism.

Seamless interaction between the program and the database needs a sort of mapping. The primary purpose of the mapping is a harmonization of metadata between the program object model and the database schema. It defines how features and relationships of types in the program are related to database components. Relationships define how entities are related to each other. For example, database components in the case of the relational database are tables, rows in tables, tables relationships, etc. The object-oriented programming is applied to model relationships defined by the database schema. Hence, the reference types are of crucial importance to create the mapping. The variables in the memory subject to processing mirror the relationships between tables in a database. They serve as a bridge between the object-oriented programming approach and database content.

A crucial impact on the improvements of the program development performance related to the database integration should be expected by automation of query creation and communication. The term ORM is commonly used in the context of software development when working with databases. ORM stands for Object-Relational Mapping. It’s a technique that bridges the gap between object-oriented programming and relational databases. Instead of writing raw SQL queries, you interact with objects in your programming language such as Python, Java, or C#. It abstracts away the low-level details of database interactions using automatically created queries. It facilitates smooth communication between the application and the underlying database. It acts as a translator, allowing developers to work with objects in their programming language while mapping them to corresponding database entities (such as tables, views, or stored procedures).

To implement a partial in-process database snapshot the following differences between an object model and database schema must be harmonized:

- relation of entities
- data types

Recently the object model concept is applied to create relationships between entities contributing to one whole in memory. It requires using object-oriented programming and finally the reference types.

In contrast, the database management systems (DBMS) don't allow to use of object-oriented programming. For example, in relational databases, the common approach to reflect the relationship between entities is primary and foreign keys. A primary key is a column (or a set of columns) in a table that uniquely identifies each row in that table. Most databases automatically index primary keys, which speeds up data retrieval operations using the key. A foreign key is a column (or a set of columns) in one table that references the primary key of another table. The most common use of foreign keys is to create a one-to-many relationship between two tables. For example, in a database containing table `Person` of [PersonRow][PersonRow], and associated CD represented by [CDCatalogEntityRow][CDCatalogEntityRow], the table containing [CDCatalogEntityRow][CDCatalogEntityRow] would include a foreign key `Person` that references the primary key `Id` of the table containing [PersonRow][PersonRow].

![CatalogXSD.png](../.Media/CatalogXSD.png)

This example is described in detail later.

In summary, primary keys ensure uniqueness and data integrity, while foreign keys establish relationships between tables, enabling efficient querying and maintaining consistency in the database.

Typically, the types used by the database schema are incompatible with types embedded in the programming language. Additionally, the program can define custom types unknown by DBMS. There must be a kind of mapper handling the translation between the two. realization of queries may cause the transfer of sequences of bitstreams between the DBMS and in-process values. The bitstream must be converted based on its meaning.

In conclusion, we can state that the development environment is completely different and needs different knowledge, experience, and tools to be engaged to deploy successfully a database solution. An example of an in-process database that resembles the existence of a relational database is the DataSet. The next subsection presents how to create and maintain an example of this data structure. Let's look at how to design, create, maintain, and use such structures. Here we will also try to answer how LINQ can help us.

## 1.2. DataSet - Creating Structural Data

An alternative way to create in-process structured data manually is to use a dedicated editor that allows you to define object model using a graphical interface. To start working, add the `DataSet` component, which can be found in the set of available Visual Studio components, in a selected place in the project. It is easier to find them if we limit the number of displayed components by selecting `Date` in the category tree. Using this approach - for comparison - I propose to define a functionally equivalent data structure to the one discussed previously. Let's call it `Catalog`.

![Catalog DataSet](../.Media/CatalogDataSet.gif)

Once created, the new multi-component item appears in the selected location. By double-clicking on the element grouping these components, the graphic editor appears. It allows you to add data tables, and their rows and define relationships between them. I have initially prepared two `DataTable` items, similar to the classes from the previous example. I also defined the relationship between them as before. We can also edit the properties of this relationship in a separate editor window, which we open from the context menu. I will use the previously defined classes in unit tests to initialize the data structure, which confirms their equivalence from the point of view of the represented information.

![Catalog DataSet Content](../.Media/CatalodDataSetEditor.gif)

Designing this structure results in automatically generated program text that implements it in a partial class. We see that this time the program contains multiple classes, each representing dedicated information. The entire structure is represented by the [Catalog][CatalogDataSet] class, and all others are defined as its internal class definitions. The author is represented by a class named [PersonRow][PersonRow], and the CD is represented by [CDCatalogEntityRow][CDCatalogEntityRow].

Since the [Catalog][CatalogDataSet] class is a partial class, we can implement custom functionality in a separate file. As before, there are three methods implementing the same algorithm in three different ways, namely selecting a list of people indicated by the method parameter. We will return to these implementations in the context of unit tests, which we will use for a more detailed comparative analysis of these three implementations.

Since the generated text of the [Catalog][CatalogDataSet] class is over 1000 lines, I now suggest analyzing it using the Show on Code Map function. The resulting graphical representation of the text describes the content of the generated classes and shows the relationships between them. The goal of the analysis is to find similar relationships that we had previously in classes created manually.

![Catalog Code Map](../.Media/CatalogCodeMap.png)

Analysis using this tool requires an appropriate configuration of filters so that only the most important components of the definition appear on the screen. In this case, we are looking for the [PersonRow][PersonRow] class and a component that provides relationships to objects of the [CDCatalogEntityRow][CDCatalogEntityRow] class. This many-to-one relationship between [PersonRow][PersonRow] and [CDCatalogEntityRow][CDCatalogEntityRow] is implemented as the [GetCDCatalogRows][GetCDCatalogRows] method, which returns an array of objects of type [CDCatalogEntityRow][CDCatalogEntityRow].

``` CSharp
            public CDCatalogEntityRow[] GetCDCatalogRows() {
                if ((this.Table.ChildRelations["ArtistRelation"] == null)) {
                    return new CDCatalogEntityRow[0];
                }
                else {
                    return ((CDCatalogEntityRow[])(base.GetChildRows(this.Table.ChildRelations["ArtistRelation"])));
                }
            }
```

Let's now move on to finding the relationship in the opposite direction, namely the relationship that will connect the CD with its author. And again, we need to properly configure the display filters to make the image readable for this presentation. In the [CDCatalogEntityRow][CDCatalogEntityRow] class, the one-to-one relationship connecting the corresponding [PersonRow][PersonRow] object is implemented by a property with the same name as the target class, namely [PersonRow][PersonRow].

Let us now move on to the analysis of the added methods in the context of unit tests filtering data from the structure created in this way. These methods are located as components of the [Catalog][CatalogDataSet] class, or rather in its internal class [PersonRow][PersonRow].

## 1.3. DataSet - Usage

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

## 1.4. See also

- [Person][Person]
- [CDCatalog][CDCatalog]
- [TestDataGenerator][TestDataGenerator]

[TestDataGenerator]: ../StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L17-L73
[Person]:            ../StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L29-L47
[CDCatalog]:         ../StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L61-L70

[FilterPersonsByLastName_ForEachTest]:     ../StructuralDataUnitTest/LINQ_to_objectUnitTest.cs#L44-L57
[FilterPersonsByLastName_QuerySyntaxTest]: ../StructuralDataUnitTest/LINQ_to_objectUnitTest.cs#L60-L73
[FilterPersonsByLastName_MethodSyntaxTest]: ../StructuralDataUnitTest/LINQ_to_objectUnitTest.cs#L76-L89

[CatalogDataSet]:     LINQ%20to%20object/Catalog.Designer.cs#L25-L1304
[PersonRow]:          LINQ%20to%20object/Catalog.Designer.cs#L1136-L1235
[CDCatalogEntityRow]: LINQ%20to%20object/Catalog.Designer.cs#L959-L1131
[GetCDCatalogRows]:   LINQ%20to%20object/Catalog.Designer.cs#L1227-L1234
