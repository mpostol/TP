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

In this chapter, we will continue to discuss topics related to structured data and the possibility of creating queries using LINQ expressions. Let me remind you that the LINQ abbreviation stands for Language Integrated Query. Let's start with a few definitions, explanations, and directions for searching for new solutions to improve access to external data. Here we will again return to the previously introduced term LINQ expression written using the query syntax and compare it with the regular expression.

By definition, an expression is a sequence of operations and operands. The previously discussed expression written using query syntax does not look like such a sequence at first glance but it must be reduced to such a sequence, so it must be converted to a form consistent with this definition.

The main goal of introducing the LINQ expressions to programming language is to create queries in a domain-specific language compliant with a remote database management system. It allows prefetching data from external repositories, such as relational databases. But earlier we noticed that data pre-selection also makes sense in the case of local structured data, i.e. a certain object graph. The next challenge of this lesson is to discuss issues related to the design, creation, maintenance, and use of such a structure. Here we will encounter a challenge of how LINQ can help us.

So let's recall the form of a LINQ expression written using query syntax. An example of the LINQ expression written using  query syntax can be found in the method[QuerySyntax][QuerySyntax]:

``` CSharp
    public static string QuerySyntax()
    {
      string[] _words = { "apple", "strawberry", "grape", "peach", "banana" };
      IEnumerable<string> _wordQuery = from word in _words
                                       where word[0] == 'g'
                                       select word;
      return string.Join(";", _wordQuery.ToArray());
    }
```

As I have already said, according to the definition, an expression is a sequence of operations and operands. At the same time, the text composition in the example code contains new keywords, such as `from`, `where`, and `select`, but it does not look like a sequence of operations, and yet it must be able to translate such a sequence to be able to call this text an expression. Okay, what if not? What are the consequences? In such a case, since we will not be able to call this entry an expression, we will not be able to apply the semantics of the expression to it, i.e. knowledge about how it is implemented, in other words, what this entry means.

Instead of adding a new theory to the right side of the assignment instruction, it seems that it will be simpler to try to convert this syntax to the well-known syntax of an expression, which is a sequence of operations and their operands. It should be noted that conversion - or translation - from one syntax to another means acting on the program text. This, in turn, means that any developer can perform this conversion.

The extension method concept will be helpful and even - one might say - irreplaceable to convert the syntax and obtain the typical syntax of an expression.  We learned this concept when examining the basics of functional programming.

## Method Syntax

But now coming to the point, let's start with the observation that as required by a LINQ expression, the data source, in our example, the value of the expression following the `in` keyword must implement the `IEnumerable` interface. If so, let's use the extension method concept to extend this interface.

Using this hint, it's time to look for a solution that will allow us to convert the expression syntax written in the form of a query into an expression written as a sequence of operations and their operands using the mentioned extension methods, but also lambda expressions and anonymous types. We have already learned about all these constructs. Their importance is fundamental, so if there is any doubt about their full understanding, I suggest returning to these topics before continuing to learn the details of the LINQ expression.

An example text after conversion can be found in the [MethodSyntax][MethodSyntax] method,

``` CSharp

    public static string MethodSyntax()
    {
      string[] _words = { "apple", "strawberry", "grape", "peach", "banana" };
      IEnumerable<string> _wordQuery = _words.Where<string>(word => word[0] == 'g').Select<String, String>(word => word);
      return String.Join(";", _wordQuery.ToArray());
    }
```

which can be found in the [LinqMethodSyntaxExamples][LinqMethodSyntaxExamples] class. This method is tested in a separate unit test [MethodSyntaxTest][MethodSyntaxTest]

``` CHarp

    public void MethodSyntaxTest()
    {
      Assert.AreEqual<string>("grape", LinqMethodSyntaxExamples.MethodSyntax());
    }

```

The test result and the content of the method indicate that it is functionally equivalent to the previously discussed method.

In the example discussed, the first extension method used in the conversion process is the 'where' method. Of course, the similarity of the names of the keyword `where` in the query syntax and the name of the method in the transformation of this text to a sequence of operations and their operands is not accidental. In other words, the method name is equivalent to the where keyword in the query syntax.

Using the `go to definition` menu entry or the F12 key, we will move to the definition of the `where` method. After scrolling a few screens, you can see that it is in the static `Enumerable` class of the .NET library.

- animated gif illustrating this

This class also contains all other methods that are necessary to perform the described conversion operation. This is an important statement and is worth remembering to understand the answer to the previously asked questions about what the difference is between the  LINQ and regular expressions. As I mentioned, this question has been asked before, but we'll come back to it again.

The next keyword in the query syntax is `select`. Again, we can use the extension method of the `IEnumerable` interface because the where method returns an object implementing this interface. As we can see from the definition of the Enumerable class, most of the extension methods located in the Enumerable class are functions that return objects implementing the mentioned interface.

Let's go back to the text of the method in question, which contains a LINQ expression after conversion to a string of operations.

Now that we know how to convert a LINQ query into a sequence of method calls, let's consider what to do with the constructs following the where and select keywords. At first glance, they look like expressions, and in fact, their syntax follows the syntax of an expression. However, the where method is called on a sequence of elements, so this expression must be executed on every element in the data source. In this case, we check whether the first letter of each word in the array is `g`. To make this possible, following the semantics of the language, we must replace them with a method that will have one parameter with a type consistent with the element type in the source and will return a true or false value. Since we cannot send another method as an argument to a method, let's use the concept of delegate, i.e. references to a method. Additionally, we can write this as an anonymous function using lambda expression syntax.

We can do a similar thing with the expression following the word 'select' and replace it with a delegate to a method using the lambda expression syntax. In our example, this method returns the value of the current argument, so it does nothing and is therefore removed from the next example.

Now let's look at the method text resulting from the query transformation in the context of a unit test. The test shows that the result is identical to the method using the LINQ query syntax.

## Postponing execution of the LINQ expression

So let's check whether, after converting a LINQ query to an operation stream, it still retains features indicating that, as before, the expression is not executed in the assignment statement, but only converted to an object representing this expression in preparation for possible further translation into a form compliant with the language queries valid for the selected repository, for example a relational database. We will later discuss an example in which a LINQ expression will be converted to an SQL query as required by this repository.

To check this, similarly as before, we modify the data source between the statement to assign the value obtained from the expression after conversion to the _wordQuery variable and the statement to check the final result in the unit test. Since the result we expect is a list of words starting with g, and we receive an empty text, we can state that the operation of determining the value is postponed similarly to before, while in the line

``` CSharp
  IEnumerable<string> _wordQuery = _words.Where<string>(word => word[0] == 'g');
```
the `_wordQuery` variable will be assigned a value representing only the description of the expression located to the right of the assignment character. In other words, the syntax of a LINQ expression does not matter to its features. In other words, writing an expression as a query or a string of operations has no impact on the semantics of this notation. In both cases, talk about a LINQ expression regardless of the form of notation. Since the behavior of LINQ expressions differs significantly from the behavior of regular we have to return to the question of how to distinguish them.

Earlier we said that conversion to a string of operations requires the use of extension methods defined in the `Enumerable` class. As we know, for each type you can create your extension methods, and also for the `IEnumerable` interface. It is therefore possible to also use these methods during the operations discussed. This is of course possible, but the expression will no longer be a LINQ expression and, as a result, cannot be converted to a query that can be executed remotely in an external repository as an equivalent operation. The use of only methods belonging to the `Enumerable` class in an expression is the first distinguishing feature of a LINQ class expression, but not the only one.

The sample program that demonstrates the process of converting the query syntax of a LINQ expression to a stream of operations used lambda expressions as the operands for these operations. Here it is worth asking whether delegates to named custom methods can be used instead. The answer is yes, but in this case, you need to be aware that such methods may not be known in the external repository and how to refer to them in a query written in a language dedicated to this repository. This is another criterion for distinguishing LINQ and regular expressions.

## Anonymous type

To describe the next ones, we need to analyze the next test method and the related library method [AnonymousType][AnonymousType].

``` CSharp
    public static string AnonymousType()
    {
      Customer[] customers = new Customer[] { new Customer() { City = "Phoenix", Name = "Name1", Revenue=11.0E3F  },
                                              new Customer() { City = "NewYork", Name = "Name2", Revenue=12.0E4F   },
                                              new Customer() { City = "Phoenix", Name = "Name3", Revenue=13.0E4F   },
                                              new Customer() { City = "Washington", Name = "Name4", Revenue=14.0E4F   }
      };
      var _customerQuery = customers.Where(_customer => _customer.City == "Phoenix").Select(_customer => new { _customer.Name, _customer.Revenue });
      return String.Join("; ", _customerQuery.Select(x => $"{x.Name}:{x.Revenue.ToString("F", CultureInfo.InvariantCulture)}").ToArray<string>());
    }
```

This method selects from the array of 'Customer' elements all items in which the following condition is true

``` CSharp
City == "Phoenix".
```

Based on them, a sequence of anonymous type values is returned - the select method uses an anonymous type to create new values. However, there is a doubt as to whether the use of this type is necessary. Is it possible to create new values in the `select` method using a custom-named type? As part of your homework, I suggest checking this scenario and whether the expression will still have the characteristics of a LINQ class expression. Note that the custom type may not be known in the context of the query language used for the selected external data repository. Anonymous types are a set of values that can always be converted to a sequence of ordered pairs (key, value), which is a representation that could be easily implemented in the context of any query language compliant with any external data repository.

## 3.3. Local Structural Data

We spent a relatively large amount of time discussing LINQ expression in the context of structured data collected and made available by external data repositories but all operations in the sample program text were performed on local data. Although this was complex data - an array for example - it did not represent relationships between independent objects, so we did not use structured data. Now, let's look at how to design, create, maintain, and use such structures. Here we will also try to answer how LINQ can help us. In particular, if there is a need for separate data pre-selection in the case of local structured data, i.e. a certain object graph.

In object-oriented programming, the basic way to create structured data is to define custom classes and link them using references. This approach is illustrated by the [Person][Person] class definition. This code is located in the unit test project and contains two classes with relationships between them.

Now let's look at the graphical analysis of the code. As a result - after configuring the appropriate filtering settings - we can see the mentioned relationships between classes in the figure. In the case of local data, relationships between objects are implemented through reference variables.

![PersonCodeMap](../.Media/PersonCodeMap.png)

<!--

Przykład to klasy [Person][Person] i [CDCatalog][CDCatalog], które zostały zdefiniowane w klasie [TestDataGenerator][TestDataGenerator]. W kodzie programu widzimy, że klasa [CDCatalog][CDCatalog] ma odwołania, więc referencję, do obiektu klasy [Person][Person], aby reprezentować informacje o autorze płyty CD. Jest to relacja jeden do jeden. Natomiast klasa [Person][Person] zawiera kolekcję płyt wydanych przez jednego autora, więc ma referencje do obiektów klasy [CDCatalog][CDCatalog]. Tym razem relacja jest jeden do wielu. Te referencje są dostępne jako obiekt implementujący `IEnumerable`, a taki obiekt może być wykorzystany jako źródło danych i być użyty w instrukcji foreach i wyrażeniu LINQ.

Alternatywnym sposobem tworzenia danych strukturalnych jest wykorzystanie dedykowanego edytora, który pozwala na definiowanie danych z wykorzystaniem interfejsu graficznego. Aby rozpocząć pracę, w wybranym miejscu projektu należy dodać składnik `DataSet`, który znajdziemy w zestawie dostępnych składników Visual Studio. Łatwiej go znaleźć, jeśli ograniczmy liczbę wyświetlanych składników przez wybór Data na drzewku kategorii. Używając tego podejścia - dla porównania - proponuję zdefiniować funkcjonalnie ekwiwalentną strukturę danych do omówionej poprzednio. Nazwijmy ją `Catalog`.

Po utworzeniu pojawia się nowy wieloskładnikowy element w wybranym miejscu. Klikając dwa razy w element grupujący te składniki, pojawia się z kolei edytor graficzny. Pozwala on dodać tabele danych, ich wiersze i zdefiniować relacje pomiędzy nimi. Ja wstępnie przygotowałem dwie DataTable (tabele danych) analogicznie do klas z poprzedniego przykładu. Pomiędzy nimi zdefiniowałem również relację jak poprzednio. Właściwości tej relacji możemy również edytować w osobnym okienku edytora, które otwieramy z menu kontekstowego. Poprzednio zdefiniowane klasy będę wykorzystywał w testach jednostkowych do zainicjowania, tak zdefiniowanej struktury danych, co potwierdza ich ekwiwalentność z punktu widzenie reprezentowanej informacji.

Zaprojektowanie tej struktury skutkuje automatycznie wygenerowanym tekstem programu, który ją implementuje w klasie częściowej. Widzimy, że tym razem program zawiera wiele klas, z których każda reprezentuje dedykowane informacje. Całą strukturę reprezentuje klasa [Catalog][CatalogDataSet], a wszystkie pozostałe są zdefiniowane jako jej klasy częściowe. Autora reprezentuje klasa o nazwie [PersonRow][PersonRow], natomiast płytę CD [CDCatalogEntityRow][CDCatalogEntityRow].

[CatalogDataSet]: 
[PersonRow]: 
[CDCatalogEntityRow]: 

Ponieważ klasa [Catalog][CatalogDataSet] jest klasą częściową możemy w osobnym pliku zaimplementować własną funkcjonalność. Podobnie jak poprzednio umieszczono tu trzy metody implementujące na trzy różne sposoby ten sam algorytm, a mianowicie wybór listy osób wskazanych przez parametr metody. Do implementacji tych wrócimy w kontekście testów jednostkowych, które użyjemy do bardziej szczegółowej analizy porównawczej tych trzech implementacji.

Ponieważ wygenerowany teks klasy [Catalog][CatalogDataSet] to ponad 1000 linii, proponuję teraz dokonać jego analizy korzystając z funkcji Show on Code Map. Otrzymana reprezentacja graficzna tekstu zawiera opis zawartości wygenerowanych klas i pokazuje relacje pomiędzy nimi. Celem analizy jest znalezienie podobnych relacji, jakie mieliśmy poprzednio w klasach utworzonych ręcznie.

Analiza z wykorzystaniem tego narzędzia wymaga odpowiedniego wykorzystania filtrów tak, aby na ekranie znalazły się tylko istotne składniki definicji. W tym przypadku szukamy klasy [PersonRow][PersonRow] i składnika udostępniającego relacje do obiektów klasy [CDCatalogEntityRow][CDCatalogEntityRow]. Ta relacja wiele do jednego pomiędzy [PersonRow][PersonRow] i [CDCatalogEntityRow][CDCatalogEntityRow] jest zaimplementowana jako metoda GetCDCatalogRows, która zwraca tablicę obiektów typu [CDCatalogEntityRow][CDCatalogEntityRow].

Przejdźmy teraz do wyszukania relacji w drugą stronę a mianowicie relacji, która połączy płytę CD z jej autorem. I znowu musimy odpowiednio skonfigurować filtry wyświetlania, aby obrazek był czytelny dla potrzeb tej prezentacji. W klasie [CDCatalogEntityRow][CDCatalogEntityRow] relacja jeden do jednego łącząca odpowiedni obiekt typu [PersonRow][PersonRow] jest zrealizowana przez property (właściwość) o nazwie takiej jak klasa docelowa, a mianowicie [PersonRow][PersonRow].

Przejdzmy teraz do analizy dodanych metod w kontekście testów jednostkowych filtrujących dane z tak utworzonej struktury. Metody te zlokalizowano jako składowe klasy [Catalog][CatalogDataSet], a właściwie w jej wewnętrznej klasie [PersonRow][PersonRow].
W pierwszej użyto instrukcję foreach i wewnętrzną instrukcję if odpowiedzialną za filtrowanie zawartości tabeli zgodnie z wartością parametru metody.

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

W teście oprócz zwracanej przez metodę wartości badany jest również typ zwracanego obiektu oraz wynik wywołania jego metody ToString. Z rezultatu widzimy, że zwracany jest obiekt generycznej klasy `List`, której parametrem typu jest [PersonRow][PersonRow]. To kolejny dowód na to, że w tym przypadku wynikiem jest kolekcja wybranych wartości, a więc wynik działania wspomnianych instrukcji.

W kolejnym teście [FilterPersonsByLastName_ForEachTest][FBLN_ForEachTest] badamy zwracany rezultat metody implementującej ten sam algorytm filtrowania, ale zaimplementowany z użyciem wyrażenia LINQ zapisanego jako ciąg operacji z wykorzystaniem metod rozszerzających. Tm razem zwracany typ obiektu wyniku działania metody jest inny, co ponownie potwierdza, że w przypadku wyrażeń klasy LINQ zwracana jest obiektowa reprezentacja samego wyrażenia, a nie wynik jego działania.

Ostatni test dotyczy implementacji metody wykorzystującej wyrażenie LINQ zapisane zgodnie ze składnią kwerendy. Tym razem wynik jest identyczny do poprzedniego, co potwierdza, że rezultat użycia wyrażenia LINQ jest zawsze taki sam niezależnie od użytej składni. Oczywiście to twierdzenie jest prawdziwe tak długo jak długo kompilator radzi sobie z tłumaczeniem tekstu programu na postać umożliwiającą takie przekształcenie w trakcie jego realizacji.

[FBLN_ForEachTest]: FilterPersonsByLastName_ForEachTest
[FBLN_QuerySyntaxTest]: FilterPersonsByLastName_QuerySyntaxTest
[FBLN_MethodSyntaxTest]: FilterPersonsByLastName_MethodSyntaxTest

## 4. Praca domowa i zakończenie

Na koniec lekcji, jak zwykle, praca domowa.

W przykładzie ilustrującym konwersję kwerendy LINQ do postaci wyrażenia zapisanego jako ciąg operacji należy dokonać kilku istotnych modyfikacji.

Tekst programu znajdziemy w klasie LinqMethodSyntaxExamples, gdzie zdefiniowano trzy metody z wykorzystaniem zapisu wyrażenia LINQ jako ciągu operacji.

W tych metodach należy:

- Zastąpić użyte metody rozszerzające własnymi metodami
- Zastąpić wyrażenia lambda delegacjami do własnych metod nazwanych
- Zastąpić typ anonimowy własnym typem nazwanym
- Zmodyfikować odpowiednio testy jednostkowe

Najlepiej zrobić to w osobnej klasie.

W tej lekcji to już wszystko. Dziękuję za poświęcony czas i zapraszam do obejrzenia następnej lekcji w której pójdziemy krok naprzód i wykorzystamy wyrażenie LINQ do preselekcji danych z zewnętrznego źródła. Będzie nim relacyjna baza danych.

[MP1]

Praca domowa- wykorzystać metody nazwane i sprawdzić rezultat.

-->
## See also

- [Person][Person]
- [CDCatalog][CDCatalog]
- [TestDataGenerator][TestDataGenerator]

[QuerySyntax]: LINQQueryAndMethodsSyntax/LinqQuerySyntaxExamples.cs#L30-L37
[MethodSyntax]: LINQQueryAndMethodsSyntax/LinqMethodSyntaxExamples.cs#L21-L26
[LinqMethodSyntaxExamples]: LINQQueryAndMethodsSyntax/LinqMethodSyntaxExamples.cs#L19-L47
[AnonymousType]: LINQQueryAndMethodsSyntax/LinqMethodSyntaxExamples.cs#L37-L46

[MethodSyntaxTest]: ../StructuralDataUnitTest/LinqMethodSyntaxExamplesUnitTest.cs#L21-L24
[TestDataGenerator]: ../StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L17-L73
[Person]: ../StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L29-L47
[CDCatalog]: ../StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L61-L72
