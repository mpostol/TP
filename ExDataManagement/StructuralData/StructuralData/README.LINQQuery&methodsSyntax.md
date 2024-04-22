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
  - [Structure Dane Fundamentals](#structure-dane-fundamentals)
  - [External Repositories](#external-repositories)
  - [Iteration vs Filtering](#iteration-vs-filtering)

## Introduction

This section is focused on structural data. We will discuss the term structured data in detail in a moment, but for now let's decipher the LINQ abbreviation, which comes from the English Language Integrated Query. When expanding this abbreviation, it is necessary to indicate the following elements that this term includes:

1. Extension of the basic programming language with a new syntax called Query Syntax
2. Extending the basic language with new semantics for LINQ expressions expressed using this syntax
3. Extending the compiler with new mechanisms (I don't hesitate to use this term) for a revolutionary way of implementing LINQ expressions in the code
4. Extension of the .NET library with namespaces offering new mechanisms for accessing structured external data

Here I introduced a new term, namely "LINQ expression", so we need to explain what makes this expression different from other expressions. Let's start with a few definitions, explanations, and indications of directions for searching for new solutions to improve access to structured data managed by external resources.

## Structure Dane Fundamentals

Generally speaking, we can say that data processing is carried out through the operations performed. From this point of view, we can divide the data into:

1. Simple data - in this case, the data can be processed by a single operation, it is one action as a result of which the value is referred to as one whole. For example, changing the sign of an int variable.
2. Complex data – here the data is composed of components. Therefore, to operate on complex data we need a selector operation to select a component that is to be subject to an operation. The selection method is determined by the data type, e.g. index for arrays and field selection for class or structure.
3. Structured data - by design, the distinguishing feature is that individual data items in a structure are selected based on intentionally programmed relationships between items

Let's analyze this case using sample code. An example is the [Person][Person] and [CDCatalog][CDCatalog] classes, which are defined in the [TestDataGenerator][TestDataGenerator] class. In the program code, we see that the [CDCatalog][CDCatalog] class has references to an object of the [Person][Person] class to represent information about the author of the CD. The [Person][Person] class, on the other hand, contains a representation of a set of albums released by one author, so it has references to objects of the [CDCatalog][CDCatalog] class. This code snippet is included in the unit testing project and will be used later to analyze the use cases of the LINQ expression.

Now let's perform a graphical analysis of the code. We can see the references between classes in the diagram. Therefore, structured data, i.e. a certain set of objects interconnected by references, is often called a graph.

![PersonCodeMap](../.Media/PersonCodeMap.png)

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

<!--
Tu trzeba wyraźnie podkreślić, że w pierwszej metodzie mamy instrukcję, natomiast w drugim wrażenie, więc nie można ich porównywać – bo to dwie różne konstrukcje językowe. Można jedynie mówić o ich podobnej roli w sekwencji wyznaczania wartości, natomiast nie można mówić o ich ekwiwalentności.

Warto tu jednak zauważyć, że w obu przypadkach mam do czynienia ze zmienną, która reprezentuje źródło danych tworzących pewien ciąg wartości. Ciąg charakteryzuje się tym, że znany jest jego pierwszy element i dla każdego element z wyjątkiem ostatniego znany jest jego następnik. Dane złożone, które charakteryzują się takimi relacjami pomiędzy elementami są reprezentowane przez typ IEnumerable.

#### IEnumerable

Tradycyjnie klawisz F12 przeniesie nas do definicji tego interfejsu. Z definicji tej widzimy, że zawiera on jedną metodę: GetEnumerator. I znowu używając klawisza F12 otwieramy definicję interfejsu `IEnumerator`, natomiast klawiszem Alt-F12 definicję niegeneryczną tego samego interfejsu. Z definicji tego typu wynika, że selekcja składowych zwracanego obiektu polega na wyróżnieniu jednego elementu zwanego aktualnym. Natomiast istnienie metody MoveNext potwierdza, że to złożenie jest ciągiem.

Wracając do analizy naszego kodu przykładowego, trzeba podkreślić, że w obu rozważanych przypadkach, tzn. w obu metodach zmienna _words musi być typu implementującego interfejs `IEnumerable`. Wynika to z wymagań językowych definicji instrukcji foreach i wyrażenia LINQ.

Skoro jednak dwie różne konstrukcje językowe możemy wykorzystać do implementacji tego samego algorytmu przetwarzania informacji musimy sformułować obiektywne kryterium pozwalające wybrać jedno z nich w konkretnym przypadku. Innymi słowy musimy zaadresować pytanie: po co nam dwie konstrukcje językowe, a zatem dwa różne sposoby operowania na ciągach danych. Aby odpowiedzieć na to pytanie musimy poznać jeszcze jedną właściwość wyrażeń LINQ.

Przejdźmy zatem do kolejnego przykładu. Ten test jednostkowy został wykorzystany do wywołania kolejnej implementacji podobnego algorytmu wyznaczania wartości typu string na podstawie zawartości tablicy jak poprzednio, a więc zawierajacej kilka słów. W odróżnieniu od poprzedniej implementacji, w metodzie [QuerySyntaxSideEffect][QuerySyntaxSideEffect] dodano jedną instrukcję modyfikującą tablicę źródłową w ten sposób, aby wyeliminować w niej słowa zaczynające się na literę q, ale umieszczoną w kodzie po instrukcji zawierającej wyrażenie LINQ, które zgodnie z jego semantyką jest odpowiedzialne za dokonanie selekcji słów na q. Tu możemy zauważyć pewną sprzeczność, a mianowicie wyrażenie to ciąg operacji, które są wykonywany w celu wyznaczenia jednej wartości o typie bazowym, który z góry da się przewidzieć na etapie kompilacji, więc w trakcie pisania programu. Gdyby jednak operacje opisane wyrażeniem LINQ były skutecznie wykonane, to zmienna _wordQuery powinna zawierać ciąg wybranych słów i instrukcja modyfikacji źródła danych w linijce 41 kodu nie mogłaby wpłynąć na końcowy rezultat działania, a w tym przypadku rezultatem jest pusty string. Jak to wyjaśnić?

[QuerySyntaxSideEffect]: LINQQueryAndMethodsSyntax/LinqQuerySyntaxExamples.cs#L39-L47

Na razie, aby próbować to wyjaśnić, musimy użyć naszej wyobraźni. Wyobraźmy sobie zatem, że zmienna _words zgodnie z semantyką tego wyrażenia faktycznie reprezentuje zewnętrzne źródło danych, np. bazę danych. Innymi słowy wyobraźmy sobie, że zmienna `_words` to nie tablica w pamięci lokalnej, tylko tablica w relacyjnej bazie danych. Takie założenie całkowicie rujnuje rozumienie wyrażenia jako złożonej ale ciągle lokalnej operacji wyznaczania wartości. Aby ten scenariusz mógł być zrealizowany muszą się zdarzyć następujące operacje:

- wyrażenie musi być przetłumaczone na kwerendę zapisaną w języku zrozumiałym dla zewnętrznego repozytorium, np. kwerendę SQL w przypadku zamiaru realizacji wyrażenia w relacyjnej bazie danych
- kwerenda musi być wysłana do innego procesu, często realizowanego zdalnie na innej platformie sprzętowej i systemowej
- Po odebraniu kwerendy proces przystępuje do jej wykonania realizując opisane w niej operacje, oczywiście pod warunkiem pozytywnej ich autoryzacji w kontekście jakiejś tożsamości i jej uprawnień
- Po zakończeniu realizacji zwracany jest rezultat w postaci ciągu wartości. Ciąg ten może być przetwarzany dalej lokalnie przez kolejne instrukcje programu

Aby zbytnio nie narażać wyobraźni i cierpliwości na szwank, obiecuję, że omówimy konkretny przykład ilustrujący ten scenariusz.

Wróćmy teraz do poprzedniego przykładu i spróbujmy podsumować skutek wykorzystania wyrażenia LINQ, a nie jednej z operacji iteracyjnego przetwarzania danych. Z uwagi na konieczność uzyskania dostępu do danych zewnętrznych musimy w algorytmie wydzielić wyraźnie dwie fazy:

- Wstępną selekcję danych podlegających dalszemu przetwarzaniu
- Przetwarzanie wyselekcjonowanych danych zgodnie z potrzebami procesowymi

W pierwszym kroku wyrażenie LINQ nie jest wykonywane, tylko tłumaczone tak, by mogło być reprezentowane jako obiekt. Referencja do tego obiektu jest podstawiana do zmiennej _wordQuery. Innymi słowy po wykonaniu wyrażenia LINQ wartość zmiennej `_wordQuery` reprezentuje przepis co trzeba zrobić, by wyznaczyć wartość wyrażenia. Przepis ten może być wykorzystany później na dwa sposoby:

- może być wykonany lokalnie jako wyrażenie
- może być przetłumaczony na dowolny język dedykowany dla wybranego repozytorium i wysłany do niego w celu zdalnego wykonania

Scenariusz, w którym tłumaczymy wyrażenie na inny język i wykonujemy kwerendę zdalnie wymaga spełnienia dodatkowych warunków, o których opowiem później.

Rozważmy jeszcze teoretyczny scenariusz, w którym użyjemy instrukcji foreach i zmiennej reprezentującej zewnętrzne repozytorium. Ponieważ w obu przypadkach zmienna ta musi implementować interfejs IEnumerable, jest to nawet praktycznie możliwe. Jednak w takim przypadku nie można zrealizować wstępnej selekcji i wszystkie dane muszą być skopiowane do lokalnej pamięci ze zdalnego repozytorium, aby mogły być wykorzystane przez tą instrukcję.

Takie rozbicie procesu przetwarzania na selekcję i w związku z tym operowanie tylko na podzbiorze danych, które zostały wyselekcjonowane, ma zastosowanie nie tylko do zewnętrznych repozytoriów, gdzie musi być zastosowane. Mianowicie, jest przydatne również, gdy trzeba rozdzielić miejsce występowania w programie preselekcji danych i ich przetwarzania w celu poprawy efektywności procesu tworzenie programu dzięki możliwości koncentracji uwagi na wybranych aspektach implementacji algorytmu, a w tym przypadku na selekcji danych i operowaniu na danych.

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

[ForeachExample]: LINQQueryAndMethodsSyntax/LinqQuerySyntaxExamples.cs#L20-L28
[QuerySyntax]: LINQQueryAndMethodsSyntax/LinqQuerySyntaxExamples.cs#L30-L37
[TestDataGenerator]: ../StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L17-L73
[Person]: ../StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L29-L47
[CDCatalog]: ../StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L61-L72
