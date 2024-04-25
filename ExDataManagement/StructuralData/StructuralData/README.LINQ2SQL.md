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

# LINQ to SQL

In both examples, LINQ operations remain essentially the same. The difference lies in the data source to which LINQ expressions are applied.

If the source implements `IEnumerable<T>` then operations with additional conditions are generally performed in memory, as in this case of LINQ to Objects.

If the source implements `IQueryable<T>` (which extends `IEnumerable<T>`) then operations with additional conditions may result in optimization, that translates to SQL queries enriched with these conditions that are generally performed on the database, as in the case of LINQ to SQL.
