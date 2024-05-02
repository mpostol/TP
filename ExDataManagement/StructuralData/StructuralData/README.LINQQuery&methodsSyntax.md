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

# LINQ expression - query and methods syntax

- [LINQ expression - query and methods syntax](#linq-expression---query-and-methods-syntax)
  - [Introduction](#introduction)
  - [External Repositories](#external-repositories)
  - [Iteration vs Filtering](#iteration-vs-filtering)

## Introduction

We will briefly discuss the term structure data in detail, but for now, let's decipher the LINQ abbreviation - it states for Language Integrated Query. When expanding this abbreviation, it is necessary to indicate the following elements that this term includes:

1. Extension of the basic programming language with a new syntax called Query Syntax
2. Extending the basic language with new semantics for LINQ expressions expressed using this syntax
3. Extending the compiler with new mechanisms (I don't hesitate to use this term) for a revolutionary way of implementing LINQ expressions in the code
4. Extension of the .NET library with namespaces offering new mechanisms for accessing structured external data

Here I introduced a new term, namely "LINQ expression", so we need to explain what makes this expression different from other expressions. Let's start with a few definitions, explanations, and indications of directions for searching for new solutions to improve access to structured data managed by external resources.

## External Repositories

In general, the data managed by external repositories can be grouped as follows:

- Bitstreams offered by the file system and network
- Data structures offered by database management systems

Topics related to the use of bitstreams have already been discussed and we will not return to them now. So let's go straight to discussing issues in the context of accessing external repositories managed structured data.

We already answered the question of what structured data is and how to process it as part of the process responsible for hosting our program. External data means that it is managed by an independent process. This process has two tasks: data sharing and data processing. This requires that it has allocated resources, such as processor, memory, files, network, etc. Consequently, we must talk about a database management system. An example is a relational database. In a relational database, data is processed using SQL. SQL stands for Structured Query Language.

Unlike files, a DBMS allows you to share data. This means that if we want to use the file we have to open it and as a result, it is locked for exclusive use by the modifying process. There is no such limitation for databases, but access to data is carried out using queries. Such queries can be handled sequentially ensuring data consistency.

There is a fundamental difference between operating on streaming and structured data managed by an external system:

- By design, streaming data is serialized and deserialized into local structured data as an entity stored in a file
- Access to external structured data is provided through queries that are carried out in the DBMS process, i.e. remotely, and data processing can take place both remotely and locally.

## Iteration vs Filtering

Usually, in the case of data sequences, for example, a sequence of records from a personal database, we process them iteratively, i.e. we repeat selected activities for each element of the sequence, starting from the first element up to the end of the sequence. The need to perform queries remotely via the DBMS forces the process to be divided into two stages:

- selection of data that meets a certain criterion
- processing only selected data locally

In the case of external data repositories, we have no alternative to this scenario. However, in practice, it also turned out that such an approach is a good scenario when operating on local data in the working memory of the program.

Let's start the analysis of access mechanisms to structured data with a unit test, which checks that two methods defined in a separate library return the same result.

The first method [ForeachExample][ForeachExample] contains a sequence of instructions that processes an array containing a few words. As a result of using the `foreach` statement and the if statement, all words that start with "g" are selected inside the `foreach` statement and added to the list defined as _wordQuery. Finally, in the return statement, we concatenate all the selected words in the list, separate them with a semicolon, and return them as a single string.

The [QuerySyntax][QuerySyntax] method implements exactly the same algorithm and operates on an identical array of words, based on which the value of the _wordQuery variable is evaluated. Again, the return value is concatenated into a string of words separated by commas.

Because:

1. in both methods, the last statement is the same
2. returned result is the same for both cases

we can conclude that the expression in the second method plays a similar role as the `foreach` statement in the first method.

The expression in the second method is called a LINQ.

``` CSharp
      IEnumerable<string> _wordQuery = from word in _words
                                       where word[0] == 'g'
                                       select word;
```

Language-Integrated Query (LINQ) is the name for a set of technologies based on the integration of query capabilities directly into the programming language. In the above snippet, the query syntax has been applied. Later, we will also analyze a different form compliant with the method syntax.

It should be clearly emphasized here that we have an instruction in the `ForeachExample` method. In contrast, in `QuerySyntax` we have an expression, so they cannot be compared - because they are two different language constructs. We can only talk about their similar role in the sequence of value determination, but we cannot speak about their equivalence.

It is worth noting that in both cases there is the `_words` variable representing the data source with a certain sequence of values. A sequence is characterized by the fact that its first element is known and for each element except the last one its successor is known. Complex data that is characterized by such relationships between elements is represented by the `IEnumerable` type.

The F12 key will take us to the definition of this interface. From this definition, we see that it contains one method: GetEnumerator. Again, the F12 opens the definition of the `IEnumerator` interface, and using the Alt-F12 key opens the non-generic definition of the same interface. The definition of this type shows that the selection of components of the returned object involves highlighting one element, called the `Current` one. However, the MoveNext method confirms that this composition is a sequence.

Returning to the analysis of our sample code, it should be emphasized that the `_words` variable must be of a type implementing the `IEnumerable` interface. This is due to the language requirements of the definition of the `foreach` statement and LINQ expression.

However, since we can use two different language structures to implement the same information processing algorithm, we must formulate an objective condition allowing us to choose one of them in a specific case. In other words, we have to address the question: why do we need two similar language constructs and two different ways of operating on data sequences? To answer this question, we need to know one more feature of LINQ expressions.

So let's move on to the next example. This unit test was used to call another implementation of a similar algorithm for determining a string value based on the contents of an array as before, i.e. containing several words. Unlike the previous implementation, in the [QuerySyntaxSideEffect][QuerySyntaxSideEffect] method, one instruction has been added to modify the source array in such a way as to eliminate words starting with the letter q, but placed in the code after the instruction containing the LINQ expression, which, according to its semantics, is responsible for selecting words for q. Here we can notice a certain contradiction. An expression is a sequence of operations performed to determine one base type value, which can be predicted in advance at the compilation stage, i.e., when writing the program. However, suppose the operations described by the LINQ expression were successfully performed. In that case, the _wordQuery variable should contain a string of selected words, and the [data source modification statement][QuerySyntaxSideEffectL45] should not affect the final result of the operation. Unfortunately.

``` CSharp
      _words[2] = "pear";
```

Based on the [QuerySyntaxSideEffectTest][QuerySyntaxSideEffectTest] it can be observed that the result, nevertheless, is an empty text so the previous statement is false. How do I explain this?

For now, we have to use our imagination to try to explain it. So let's imagine that the _words variable, according to the semantics of this expression, actually represents an external data source, e.g. a database. In other words, imagine that the `_words` variable is not an array in local memory, but a table in a relational database. This assumption completely changes the understanding of an expression as a complex but still local value evaluation activity. For this scenario to be realized, the following operations must happen:

- the expression must be translated into a query written in a language understandable by the external repository, e.g. an SQL query if the expression is to be executed in a relational database
- the query must be transferred somehow to the database management system (another process), often implemented remotely on a different hardware and system platform
- after receiving the query, the external process begins to execute it, carrying out the operations described therein, provided, of course, that they are positively authorized in the context of some identity and its permissions
- after completion of the execution, the result is returned in the form of a stream of values. This string can be further processed locally by subsequent program instructions

Now let's go back to the previous example and try summarizing the effect of using a LINQ expression. Due to the need to gain access to external data, we must clearly distinguish two stages in the algorithm:

- selection of data that will be subject to further processing
- processing selected data following process needs and using an implemented algorithm

In the first step, the LINQ expression is not executed but prepared for translation only and represented as an object. The reference to this object is assigned to the _wordQuery variable. In other words, when a LINQ expression is executed, the value of the `_wordQuery` variable represents what needs to be done to determine the value of the expression. This recipe can be used later in two ways:

- can be executed locally as an regular expression
- can be translated into any domain-specific language compliant with a selected external repository and sent to it for remote execution

The scenario in which an expression is translated into another language and a query is executed remotely requires additional conditions to be met. We will come back to this topic later.

Let's consider a theoretical scenario in which we use the foreach statement and a variable representing an external repository. Since in both cases this variable must implement the `IEnumerable` interface, this is even practically possible. However, in this case, pre-selection cannot be performed and all data must be fetched to local storage from the remote repository to be used by this instruction.

This breakdown into (a) selection of relevant data and (b) processing of only selected data applies not only to external repositories where it must be used. Namely, it is also useful when it is necessary to separate the place of data pre-selection and processing in the program to improve the software development performance according to the separation of concern principle.  The separation of concern (SoC) is the fundamental principle in software engineering. It aims to break down complex problems into smaller, more manageable parts.

[QuerySyntaxSideEffectTest]: ../StructuralDataUnitTest/LinqQuerySyntaxExamplesUnitTest.cs#L28-L31
[QuerySyntaxSideEffect]: LINQQueryAndMethodsSyntax/LinqQuerySyntaxExamples.cs#L39-L47
[QuerySyntaxSideEffectL45]: LINQQueryAndMethodsSyntax/LinqQuerySyntaxExamples.cs#L45
[ForeachExample]: LINQQueryAndMethodsSyntax/LinqQuerySyntaxExamples.cs#L20-L28
[QuerySyntax]: LINQQueryAndMethodsSyntax/LinqQuerySyntaxExamples.cs#L30-L37

<!--

## Praca domowa

### Kod

Przejdźmy do zdefiniowania pracy domowej, a w ramach pracy domowej zagadka. Ilustracją do niej jest metoda AnonymousType i skojarzona z nią metoda testowa, które znajdują się w przykładowym kodzie programu.

Aby odpowiedzieć na pytania, które zaraz zadam, po pierwsze, trzeba przeanalizować kod przykładowy, by go zrozumieć. Nie powinno to być trudne, bo jest bardzo podobny do omówionych w ramach tej lekcji przykładów, a mianowicie w tej metodzie wybieramy wszystkie obiekty klasy Customer spełniajcie warunek zdefiniowany w konstrukcji where wyrażenia LINQ. W konstrukcji select natomiast tworzymy obiekty zawierające wybrane dane odczytane z obiektów Customer.

Następnie z lekcji poprzednich trzeba przypomnieć sobie, z lekcji poprzednich, dwa tematy:

- co to jest typ anonimowy?
- co oznacz słowo kluczowe var w przedstawionym programie?

### Prezentacja

I teraz pytania:

- Czy w przykładowym kodzie programu możemy wykorzystać typ nazwany i tworzyć obiekty tego typu w konstrukcji select?
Proszę udzielić odpowiedzi niezależnie dla dwóch przypadków:

- Zmienna customers reprezentuje lokalny obiekt, jak w tym przykładzie
- Zmienna customers reprezentuje wybrane dane w zewnętrznym repozytorium, przykładowo jest tabelą w relacyjnej bazie danych

Poprawność odpowiedzi na to pytanie i co ważniejsze jakie są konsekwencje można sprawdzić modyfikując kod tak, aby testować odroczenie wykonania wyrażenia LINQ, tak jak to robiliśmy poprzednio. Poprawna odpowiedź na to pytanie powinna być podpowiedzią do następnego pytania

- Czy i kiedy musimy korzystać z typów anonimowych ?

Ważnym słowem w tym pytaniu jest „musimy”, no bo jeśli musimy to pytanie „czy warto?” staje się bezzasadne. Jeśli musimy to nie trzeba już szukać innych kryteriów uzasadniających wykorzystanie typów anonimowych.  
-->
