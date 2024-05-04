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
  - [Query Syntax](#query-syntax)
  - [Method Syntax](#method-syntax)
  - [Deferred Execution of the LINQ Expression](#deferred-execution-of-the-linq-expression)
  - [Anonymous type](#anonymous-type)
  - [Local Structural Data](#local-structural-data)
  - [DataSet to create structural data](#dataset-to-create-structural-data)
  - [See also](#see-also)

## Introduction

In this chapter, we will continue to discuss topics related to structured data and the possibility of creating queries using LINQ expressions. Let me remind you that the LINQ abbreviation stands for Language Integrated Query. Let's start with a few definitions, explanations, and directions for searching for new solutions to improve access to external data. Here we will again return to the previously introduced term LINQ expression written using the query syntax and compare it with the regular expression.

The main goal of embedding the LINQ expressions into the programming language is to create a construct that allows automatic preparation of queries in a domain-specific language compliant with a remote database management system without leaving a comfort zone, I mean to change the programming language. It allows prefetching data from external repositories (for example relational databases) using the same programming environment. But we also noticed that pre-selection makes sense in the case of local data structures, i.e. certain object graphs. Here we will encounter a challenge of how LINQ can help.

## Query Syntax

So let's recall the form of a LINQ expression written using query syntax. An example of the LINQ expression written using  query syntax can be found in the method [QuerySyntax][QuerySyntax]:

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

By definition, an expression is a sequence of operations and operands. Expressions are composed of variables, operators, function calls, and literals. They represent computations or transformations and yield a result. The previously discussed expression written using query syntax does not look like such a sequence at first glance. Unfortunately,  the text in the example code contains unknown keywords, such as `from`, `where`, and `select`, but it does not resemble a sequence of operations. To be executed it must be converted to a form compliant with this definition. Okay, but what if not? What are the consequences? In such a case, since we will not be able to recognize this entry as an expression, we will not be able to apply the semantics of the expression to it, i.e. knowledge about how it is implemented, in other words, what this entry means.

Instead of adding a new theory to the right side of the assignment instruction, it seems that it will be simpler to try to convert this syntax to the well-known syntax of an expression, which is a sequence of operators and their operands. It should be noted that conversion - or translation - from one syntax to another means acting on the program text. This, in turn, means that any developer can perform this conversion.

The extension method concept will be helpful and even - one might say - irreplaceable to convert the syntax and obtain the typical syntax of an expression.  We learned this concept when examining the basics of functional programming.

## Method Syntax

But now coming to the point, let's start with an observation that as required by a LINQ expression, the data source, in our example, the value of the expression following the `in` keyword must implement the `IEnumerable` interface. If so, let's use the extension method concept to extend this interface.

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

In the example discussed, the first extension method used in the conversion process is the 'where' method. Of course, the similarity of the names of the keyword `where` in the query syntax and the name of the method in the transformation of this text to a sequence of operations and their operands is not accidental. In other words, the method name is equivalent to the `where` keyword in the query syntax.

Using the `go to definition` menu entry or the F12 key, we will move to the definition of the `Where` method. After scrolling you can see that it is in the static `Enumerable` class of the .NET library.

![Where Method](../.Media/WhereMethod.gif)

This class also contains all other methods that are necessary to perform the described conversion operation. This is an important statement and is worth remembering to understand the answer to the previously asked questions about what the difference is between the  LINQ and regular expressions. As I mentioned, this question has been asked before, but we'll come back to it again.

The next keyword in the query syntax is `select`. Again, we can use the extension method of the `IEnumerable` interface because the where method returns an object implementing this interface. As we can see from the definition of the Enumerable class, most of the extension methods located in the Enumerable class are functions that return objects implementing the mentioned interface.

Let's go back to the text of the method in question, which contains a `LINQ` expression after conversion to a string of operations.

Now that we know how to convert a `LINQ` query into a sequence of method calls, let's consider what to do with the constructs following the where and select keywords. At first glance, they look like expressions, and in fact, their syntax follows the syntax of an expression. However, the where method is called on a sequence of elements, so this expression must be executed on every element in the data source. In this case, we check whether the first letter of each word in the array is `g`. To make this possible, following the semantics of the language, we must replace them with a method that will have one parameter with a type consistent with the element type in the source and will return a true or false value. Since we cannot send another method as an argument to a method, let's use the concept of delegate, i.e. references to a method. Additionally, we can write this as an anonymous function using lambda expression syntax.

We can do a similar thing with the expression following the word 'select' and replace it with a delegate to a method using the lambda expression syntax. In our example, this method returns the value of the current argument, so it does nothing and is therefore removed from the next example.

Now let's look at the method text resulting from the query transformation in the context of a unit test. The test shows that the result is identical to the method using the LINQ query syntax.

``` CSharp
      Assert.AreEqual<string>("grape", LinqMethodSyntaxExamples.MethodSyntax());
```

## Deferred Execution of the LINQ Expression

So let's check whether, after converting the LINQ expression from query syntax to method syntax, it still retains features indicating that, as before, the expression execution is deferred to make room for possible further translation into a form compliant with the language queries valid for the selected repository, for example, a relational database.

To check this, similarly as before, we modify the data source between the statement to assign the value obtained from the expression after conversion to the _wordQuery variable and the statement to check the final result in the unit test. Since the result we expect is a list of words starting with g, and we receive an empty text, we can state that the operation of determining the value is deferred similarly to before, while in the line

``` CSharp
  IEnumerable<string> _wordQuery = _words.Where<string>(word => word[0] == 'g');
```

the `_wordQuery` variable is assigned a value representing only the description of the expression located on the right-hand side of the assignment symbol. In other words, the syntax of a LINQ expression does not matter to its features. In other words, writing an expression using query syntax or method syntax has no impact on the semantics of this notation. In both cases, we deal with LINQ expression regardless of the syntax applied. Since the behavior of LINQ expressions differs significantly from the behavior of typical expressions we have to return to the question of how to distinguish them.

Earlier we said that conversion from query syntax to the method syntax requires the use of extension methods defined in the `Enumerable` class. As we know, for each type definition we can create your extension methods, and this is also true for the `IEnumerable` interface. It is therefore possible to use these methods during the operations discussed. This is of course possible, but the expression will no longer be a LINQ expression and, as a result, cannot be converted to a query that can be executed remotely in an external repository as an equivalent operation. The use of only methods belonging to the `Enumerable` class in an expression is the first distinguishing feature of the LINQ expression, but not the only one.

The code snippets in [LinqMethodSyntaxExamples][LinqMethodSyntaxExamples] demonstrate the process of converting the query syntax of a LINQ expression to the method syntax using lambda expressions as the operands for these operations. Here it is worth asking whether delegates to named custom methods can be used instead of anonymous methods. The answer is yes, but in this case, you need to be aware that such methods may not be known in the external repository making you unable reference to them in a query written in a language dedicated to this repository. This is another criterion for distinguishing LINQ and regular expressions.

## Anonymous type

To describe the next conditions having an impact on the classification of the LINQ expression the next test method must be analyzed and the related library method [AnonymousType][AnonymousType].

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

This method selects from the array of 'Customer' elements all items in which the following condition is hold

``` CSharp
City == "Phoenix".
```

Based on them, a sequence of anonymous type values is returned - the select method uses an anonymous type to create new values. However, there is a doubt as to whether the use of this type is necessary. Is it possible to create new values in the `select` method using a custom-named type?  Note that the custom type may not be known in the context of the query language used for the selected external data repository. Anonymous types are a set of values that can always be converted to a sequence of ordered pairs (key, value), which is a representation that could be easily implemented in the context of any query language compliant with any external data repository.

## Local Structural Data

We spent a relatively large amount of time discussing LINQ expression in the context of structured data collected and made available by external data repositories but all operations in the sample program text were performed on local data. Although this was complex data - an array for example - it did not represent relationships between independent objects, so we did not use structured data. Now, let's look at how to design, create, maintain, and use such structures. Here we will also try to answer how LINQ can help us. In particular, if there is a need for separate data pre-selection in the case of local structured data, i.e. a certain object graph.

In object-oriented programming, the basic way to create structured data is to define custom classes and link them using references. This approach is illustrated by the [Person][Person] class definition. This code is located in the unit test project and contains two classes with relationships between them.

Now let's look at the graphical analysis of the code. As a result - after configuring the appropriate filtering settings - we can see the mentioned relationships between classes in the figure. In the case of local data, relationships between objects are implemented through reference variables.

![PersonCodeMap](../.Media/PersonCodeMap.png)

An example is the [Person][Person] and [CDCatalog][CDCatalog] classes, which are defined in the [TestDataGenerator][TestDataGenerator] class. In the program code we see that the [CDCatalog][CDCatalog] class has references, so a reference, to an object of the [Person][Person] class to represent information about the author of the CD. It is a one-to-one relationship. However, the [Person][Person] class contains a collection of CDs released by a single author, so it has references to objects of the [CDCatalog][CDCatalog] class. This time the relationship is one to many. These references are available as an object implementing `IEnumerable`, and such an object can be used as a data source in a foreach statement and a LINQ expression.

## DataSet to create structural data

An alternative way to create structured data is to use a dedicated editor that allows you to define data using a graphical interface. To start working, add the `DataSet` component, which can be found in the set of available Visual Studio components, in a selected place in the project. It is easier to find them if we limit the number of displayed components by selecting Date in the category tree. Using this approach - for comparison - I propose to define a functionally equivalent data structure to the one discussed previously. Let's call it `Catalog`.

Once created, the new multi-component item appears in the selected location. By double-clicking on the element grouping these components, the graphic editor appears. It allows you to add data tables, and their rows and define relationships between them. I have initially prepared two `DataTable` items, similar to the classes from the previous example. I also defined the relationship between them as before. We can also edit the properties of this relationship in a separate editor window, which we open from the context menu. I will use the previously defined classes in unit tests to initialize the data structure, which confirms their equivalence from the point of view of the represented information.

Designing this structure results in automatically generated program text that implements it in a partial class. We see that this time the program contains multiple classes, each representing dedicated information. The entire structure is represented by the [Catalog][CatalogDataSet] class, and all others are defined as its internal class definitions. The author is represented by a class named [PersonRow][PersonRow], and the CD is represented by [CDCatalogEntityRow][CDCatalogEntityRow].

Since the [Catalog][CatalogDataSet] class is a partial class, we can implement custom functionality in a separate file. As before, there are three methods implementing the same algorithm in three different ways, namely selecting a list of people indicated by the method parameter. We will return to these implementations in the context of unit tests, which we will use for a more detailed comparative analysis of these three implementations.

Since the generated text of the [Catalog][CatalogDataSet] class is over 1000 lines, I now suggest analyzing it using the Show on Code Map function. The resulting graphical representation of the text describes the content of the generated classes and shows the relationships between them. The goal of the analysis is to find similar relationships that we had previously in classes created manually.

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

Analysis using this tool requires an appropriate configuration of filters so that only the most important components of the definition appear on the screen. In this case, we are looking for the [PersonRow][PersonRow] class and a component that provides relationships to objects of the [CDCatalogEntityRow][CDCatalogEntityRow] class. This many-to-one relationship between [PersonRow][PersonRow] and [CDCatalogEntityRow][CDCatalogEntityRow] is implemented as the [GetCDCatalogRows][GetCDCatalogRows] method, which returns an array of objects of type [CDCatalogEntityRow][CDCatalogEntityRow].

[GetCDCatalogRows]: LINQ%20to%20object/Catalog.Designer.cs#L1227-L1234

Let's now move on to finding the relationship in the opposite direction, namely the relationship that will connect the CD with its author. And again, we need to properly configure the display filters to make the image readable for this presentation. In the [CDCatalogEntityRow][CDCatalogEntityRow] class, the one-to-one relationship connecting the corresponding [PersonRow][PersonRow] object is implemented by a property with the same name as the target class, namely [PersonRow][PersonRow].

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

[QuerySyntax]: LINQQueryAndMethodsSyntax/LinqQuerySyntaxExamples.cs#L30-L37
[MethodSyntax]: LINQQueryAndMethodsSyntax/LinqMethodSyntaxExamples.cs#L21-L26
[LinqMethodSyntaxExamples]: LINQQueryAndMethodsSyntax/LinqMethodSyntaxExamples.cs#L19-L47
[AnonymousType]: LINQQueryAndMethodsSyntax/LinqMethodSyntaxExamples.cs#L37-L46

[MethodSyntaxTest]: ../StructuralDataUnitTest/LinqMethodSyntaxExamplesUnitTest.cs#L21-L24
[TestDataGenerator]: ../StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L17-L73
[Person]: ../StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L29-L47
[CDCatalog]: ../StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L61-L72
[FilterPersonsByLastName_ForEachTest]:     ../StructuralDataUnitTest/LINQ_to_objectUnitTest.cs#L44-L57
[FilterPersonsByLastName_QuerySyntaxTest]: ../StructuralDataUnitTest/LINQ_to_objectUnitTest.cs#L60-L73
[FilterPersonsByLastName_MethodSyntaxTest]: ../StructuralDataUnitTest/LINQ_to_objectUnitTest.cs#L76-L89

[CatalogDataSet]: LINQ%20to%20object/Catalog.Designer.cs#L25-L1304
[PersonRow]: LINQ%20to%20object/Catalog.Designer.cs#L1136-L1235
[CDCatalogEntityRow]: LINQ%20to%20object/Catalog.Designer.cs#L959-L1131
