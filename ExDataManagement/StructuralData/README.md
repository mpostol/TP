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

In both examples, LINQ operations remain essentially the same. The difference lies in the data source to which LINQ expressions are applied.

If the source implements `IEnumerable<T>` then operations with additional conditions are generally performed in memory, as in this case of LINQ to Objects.

If the source implements `IQueryable<T>` (which extends `IEnumerable<T>`) then operations with additional conditions may result in optimization, that translates to SQL queries enriched with these conditions that are generally performed on the database, as in the case of LINQ to SQL.

## See also

* [Language Integrated Query (LINQ)](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/linq)
* [Query Syntax and Method Syntax in LINQ (C#)](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq)
* [LINQ to SQL tools in Visual Studio](https://docs.microsoft.com/visualstudio/data-tools/linq-to-sql-tools-in-visual-studio2?view=vs-2017)
* [LINQ to SQL](https://docs.microsoft.com/dotnet/framework/data/adonet/sql/linq/)
* [Entity Framework Documentation](https://docs.microsoft.com/ef/)
