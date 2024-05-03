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

# LINQ expression

- [LINQ expression](#linq-expression)
  - [Introduction](#introduction)
  - [Iteration vs Filtering](#iteration-vs-filtering)
  - [Deferred Execution of the LINQ Expression](#deferred-execution-of-the-linq-expression)

## Introduction

We can get the impression from the previous section, that data is data, and it doesn't matter where it comes from provided it is reliable. Following this deep and generic thought, we should propose a common mechanism that can be used to fetch the necessary data processing from any available source. The only possible way to design this mechanism is by utilizing expandability. Expandability has to allow the possibility of adaptation of this mechanism to any external and internal kind of data repository. A powerful feature in C# that allows you to perform queries against data directly within the language is a technology called LINQ. The LINQ abbreviation stands for Language Integrated Query. Language-Integrated Query (LINQ) is the name for a set of technologies based on the integration of query capabilities directly into the programming language. It is necessary to indicate the following elements that this term includes:

1. Extension of the basic programming language with a new syntax called query and method syntax
2. Extending the basic language with new semantics for LINQ expressions
3. Extending the compiler with new mechanisms for a revolutionary way of implementing LINQ expressions in the code
4. Extension of the .NET library with namespaces offering new mechanisms for accessing structured external data

Here I introduced the new term"LINQ expression". Hence, it is needed to explain what makes this expression different from typical expressions. Let's start with a few definitions, explanations, and indications of directions for searching for new solutions to improve access to structured data managed by external resources.

## Iteration vs Filtering

Let's start the analysis of access mechanisms to structured data with a unit test, which checks that two methods defined in a separate library return the same result.

The first method [ForeachExample][ForeachExample] contains a sequence of instructions that processes an array containing a few words. As a result of using the `foreach` statement and the if statement, all words that start with "g" are selected inside the `foreach` statement and added to the list defined as _wordQuery. Finally, in the return statement, we concatenate all the selected words in the list, separate them with a semicolon, and return them as a single string.

The [QuerySyntax][QuerySyntax] method implements exactly the same algorithm and operates on an identical array of words, based on which the value of the _wordQuery variable is evaluated. Again, the return value is concatenated into a string of words separated by commas.

Because:

1. in both methods, the last statement is the same
2. returned result is the same for both cases

we can conclude that the expression in the [QuerySyntax][QuerySyntax] method plays a similar role as the `foreach` statement in the [ForeachExample][ForeachExample] method. The following expression in the [QuerySyntax][QuerySyntax] method is called a LINQ expression.

``` CSharp
      IEnumerable<string> _wordQuery = from word in _words
                                       where word[0] == 'g'
                                       select word;
```

In the above code snippet, the query syntax has been applied. Later, we will also analyze a different form compliant with the method syntax.

It should be emphasized here that we have an instruction in the [ForeachExample][ForeachExample] method. In contrast, in the [QuerySyntax][QuerySyntax] method there is an expression so they cannot be compared directly because they are two different language constructs. We can only talk about their similar role in the sequence of the return value determination, but we cannot speak about their equivalence. The iterative `foreach` loop instruction refers to a process or sequence of steps that are iterated over the elements contained in a data source to achieve a desired outcome. In contrast, the main aim of the LINQ expression is to select only relevant data from the data source. In both cases, the data source is an expression returning a value implementing the IEnumerable interface.

It is worth noting that in both cases there is the `_words` variable representing the data source with a certain sequence of values. A sequence is characterized by the fact that its first element is known and for each element except the last one its successor is known. Complex data that is characterized by such relationships between elements is represented by the `IEnumerable` type.

The F12 key will take us to the definition of this interface. From this definition, we see that it contains one method: GetEnumerator. Again, the F12 opens the definition of the `IEnumerator` interface, and using the Alt-F12 key opens the non-generic definition of the same interface. The definition of this type shows that the selection of components of the returned object involves highlighting one element, called the `Current` one. However, the `MoveNext` method confirms that this composition is a sequence. This property returns  true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the sequence.

Returning to the analysis of our sample code, it should be emphasized that the `_words` variable must be of a type implementing the `IEnumerable` interface. This is due to the language requirements of the definition of the `foreach` statement and LINQ expression.

However, since we can use two different language structures to implement the same information processing algorithm, we must formulate an objective condition allowing us to choose one of them in a specific case. In other words, we have to address the question: why do we need two similar language constructs and two different ways of operating on data sequences? To answer this question, we need to know one more feature of LINQ expressions.

## Deferred Execution of the LINQ Expression

So let's move on to the [QuerySyntaxSideEffectTest][QuerySyntaxSideEffectTest] test method. This unit test was used to call another implementation of a similar algorithm determining a string value based on the content of an array as before, i.e. containing several words. Unlike the previous implementation, in the [QuerySyntaxSideEffect][QuerySyntaxSideEffect] method under testing, one instruction has been added to modify the source array in such a way as to eliminate words starting with the letter q, but placed in the code after the assignment instruction containing the LINQ expression, which, according to its semantics, is responsible for selecting words for q.

Here we can notice a certain contradiction. An expression is a sequence of operations performed to determine a value of type, which can be predictable in advance at the compilation stage, i.e., when writing the program.

However, suppose that the operations described by the LINQ expression are successfully performed. In that case, the _wordQuery variable should contain a string of selected words, and the [data source modification statement][QuerySyntaxSideEffectL45] should not affect the final result of the operation.

``` CSharp
      _words[2] = "pear";
```

Unfortunately, based on the [QuerySyntaxSideEffectTest][QuerySyntaxSideEffectTest] it can be observed that the result, is an empty text so the previous statement is false. How do I explain this?

For now, we have to use our imagination to try to explain it. So let's imagine that the _words variable, according to the semantics of this expression, actually represents an external data source, e.g. a database. In other words, imagine that the `_words` variable represents a table in a relational database. Locally it contains only in-process data necessary for processing activity and fetched from an external resource. This assumption completely changes the understanding of an expression as a complex but still local value evaluation activity. For this scenario to be realized, the following operations must happen:

- the expression must be translated into a query written in a language understandable by the external repository, e.g. an SQL query if the expression is to be executed in a relational database
- the query must be transferred somehow to the database management system (another process), often implemented remotely on a different hardware and system platform
- after receiving the query, the external process begins to execute it, carrying out the operations described therein, provided, of course, that they are positively authorized in the context of some identity and its permissions
- after completion of the execution, the result is returned in the form of a stream of values. This stream can be further processed locally by subsequent program instructions

Now let's go back to the previous example and try summarizing the effect of using a LINQ expression. Due to the need to gain access to external data, we must clearly distinguish two stages in the algorithm:

- selection of data that will be subject to further processing
- processing selected data following process needs and using an implemented algorithm

In the first step, the LINQ expression is not executed but prepared for translation only and represented as an object. The reference to this object is assigned to the _wordQuery variable. In other words, when a LINQ expression is executed, the value of the `_wordQuery` variable represents what needs to be done to determine the value of the expression. This recipe can be used later in two ways:

- can be executed against a local data source as an typical expression
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
