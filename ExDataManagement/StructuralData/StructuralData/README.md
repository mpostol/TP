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

# Structural Data - Implementation Examples

## Introduction

 Generally speaking, we can say that data processing is carried out through the execution of operations. From this point of view, we can divide the data into:

1. **Simple data** - in this case, the data can be processed by a single operation, it is one action as a result of which the value is referred to as one whole. For example, changing the sign of an int variable.
2. **Complex data** – here the data is composed of components. Therefore, to operate on complex data we apply a selector operation to select a component that is to be subject to an operation. The data type determines the selection method, e.g. index for arrays and field selection for class or structure.
3. **Structured data** - by design, the distinguishing feature is that individual data items in a structure are selected based on intentionally programmed relationships between items.

This section is focused on **structural data**. In object-oriented programming, the basic way to create structural data is to define custom types and interconnect them using references. By design, the Database Management Systems don't support object-oriented programming, hence the query must be used instead. Let's analyze these topics using examples and unit tests gathered in this folder.

## LINQ Expression

A technology called LINQ is a powerful feature in C# language that allows performing queries against data directly within the language. The LINQ abbreviation stands for Language Integrated Query. LINQ is the name for a set of technologies based on the integration of query capabilities directly into the programming language. The subsection [LINQ Expression][LINQExpression] presents the LINQ in context of examples.

## LINQ to object

This section continues on topics related to structural data and the possibility of creating queries using LINQ expressions. The main goal of embedding the LINQ expressions into the programming language is to create a construct that allows automatic preparation of queries in a domain-specific language compliant with a remote database management system without leaving a comfort zone, I mean to change the programming language. But we also noticed that pre-selection of data makes sense in the case of local data structures, i.e. certain object graphs. Here we will encounter a challenge of how LINQ can help. In conclusion, we can state that the development environment is completely different and needs different knowledge, experience, and tools to be engaged to deploy successfully a database solution. An example of an in-process database that resembles the one deployed using a relational database is the `DataSet`. The subsection [LINQ to Object][LINQ2Object] presents how to create and maintain an example of this data structure. Let's look at how to design, create, maintain, and use such structures. Here we will also try to answer how LINQ can help us.

## LINQ to SQL

In this chapter, we will continue discussing structural data and the ability to create queries using LINQ expressions. We will use these queries to pre-select data from the relational database. We will focus only on issues related to the programming language, i.e. its syntax and semantics. Unfortunately, we cannot completely avoid topics related to the design environment used, namely Visual Studio and the dedicated libraries used.

Usually, in the case of data sequences, for example, a sequence of records from a personal database, we process them iteratively, i.e. we repeat selected activities for each element of the sequence, starting from the first element up to the end of the sequence. The need to perform queries remotely via the DBMS forces the process to be divided into two stages:

- **remotely**, selection of data that meets a certain condition
- **locally**, processing only preselected data

In the case of external data repositories, we have no alternative to deploy this scenario but both stages can be subject to independent mechanisms. Therefore, in practice, it also turned out that such an approach is a good scenario when operating on local in-process data gathered in the working memory. More about interconnection with external databases may be learned from the subsection [LINQ to SQL][LINQ2SQL].

## See also

- [Section LINQ Expression][LINQExpression]
- [Section LINQ to Object][LINQ2Object]
- [Section LINQ to SQL][LINQ2SQL]

[LINQExpression]: README.LINQExpression.md
[LINQ2Object]:    README.LINQ2Object.md
[LINQ2SQL]:       README.LINQ2SQL.md
