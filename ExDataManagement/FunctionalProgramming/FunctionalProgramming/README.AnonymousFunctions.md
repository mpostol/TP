<!--
//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________
-->

# Anonymous Functions

## Lambda Expressions

A lambda expression with an expression on the right side of the `=>` operator is called an expression lambda. Expression lambdas are used extensively in the construction of [Expression Trees][ET]. An expression lambda returns the result of the expression and takes the following basic form:

```C#
(input-parameters) => expression
```

Sometimes it is difficult or impossible for the compiler to infer the input types. When this occurs, you can specify the types explicitly as shown in the following example:

```C#
(int x, string s) => s.Length > x
```

> If you are creating expression trees that are executed outside of the .NET Framework, such as in SQL Server, you should not use method calls in lambda expressions. The methods will have no meaning outside the context of the .NET common language runtime. For example:

```C#
() => SomeMethod()
```

<!-- ### Anonymous Method

Delegates in C# do not explicitly contribute to functional programming, although they cannot be omitted in the context of anonymous functions language constructs. They are also vital for implementing interlayer communication. Considering both arguments it is clear that delegated must be investigated in detail as a part of the introduction describing selected language constructs implicitly contributing to functional programming. 

## 6. Agenda - Funkcje anonimowe

Przejdzmy juz do omówienia funkcji anonimowych, a w tym metod anonimowych i wyrażeń lambda. Przykład metody anonimowej znajduje się w tej metodzie testowej (`AnonymousMethodTest`). Przypomnę, że metoda anonimowa jest jednym z rodzajów funkcji anonimowych (ang. anonymous functions). Skąd sie wzieła nazwa funkcja anonimowa nie wiem. Moge się tylko domyślać, ale prześledźmy definicję metody anonimowej. Po lewej stronie w tej linijce mamy typową deklaracje zmiennej (13:40) delegacyjnej. Alt-F12 przypomni nam, że `CallBackTestDelegate` jest po prostu typem delegacyjnym; to jest zmienna delegacyjna do której podstawiamy wartość w postaci referencji do jakiejś metody. Tym razem ta metoda jest zdefiniowana w wyrażeniu, które znajduje sie po prawej stronie znaku równości. Dla takiej definicji mamy oczywiście listę parametrów, mamy oczywiscie blok, czyli ciag instrukcji; które będą wykonane, kidy metoda zostanie wywołana. Poniewaz nie mamy tutaj przypisanej nazwy, nazywamy tego typu tupu definicje anonimową. Nie mozemy sie do niej odwołać w żaden inny sposób, jak tylko poprzez zmienną delegacyjna, ale zmienna delegacyjna ma nazwę, w zwiazku z powyższym to nie jest tak, że definicja anonimowa; ze do definicji anonimowej nie możemy się odwołać. Oczywiście różnica pomiędzy utworzeniem delegacji i to jak w tym przypadku delegacji z metody nazwanej i tutaj delegacji z metody nienazwanej jest tylko taka, że w tym przypadku podstawiamy wartość do zmiennej i to oznacza, że możemy tą wartość zmienić. Ale pomijając te szczegóły w nastepnej linijce widzimy kolejna alternatywę definiowania referencji, podobnie referencji do zmiennej, a więc delegacji do metody, która znowu jest tutaj zdefiniowana jako anonimowa, gdzie mamy listę parametrów oraz mamy blok. Ja nie będę szczegółów składniowych omawiał. Znamy to z lekcji dotyczących samego jezyka CSharp.

Rzeczywiście ta referencję do metody mozmy podstawić jako argument aktualny do argumentu formalnego, dla tej metody, która już wcześniej żeśmy ją omawialismy jest zdefiniowana w ramach tego obiektu i służy do sprawdzenia spójności wewnetrznej obiektu. I tutaj podobnie jak wczesniej may niezmiennik, który sprawdza, czy w tym przypadku zmienna; nie musimy tworzyć obiektu tylko mamy zmienną, która zmienia wartość na `true`.

Jesli porównamy definicję metody nazwanej; tu mamy właśnie taka metodę nazwaną; z definicja metody nienazwanej; tu jest taka definicja to widzimy, że różnica jest wyłacznie składniowa. W kolejnych wersjach języka wprowadzono kolejne uproszczenia, które pozwalają na skrócenie tej definicji i zapisanie jej w innej formie. Jedna różnica jaka wystepuje to fakt, ze metoda nienazwana ma dostep do zmiennych lokalnych, które sa zdefiniowane w metodzie, w której ona ma swoja definicję. Ale to wynika z miejsca, w którym jest ona definiowana.

Przejdzmy di kolejnego wcielenia funkcji anonimowych, a mianowicie wyrazenia lambda. Tutaj may w tej metodzie testowej zapisana dokładnie taka samą funkcjonalność jak poprzednio z wykorzystaniem właśnie wyrażenia lambda. Przypomnijmy, że ta metoda nic sie nie zmieniło nadal parametrem formalnym jest zmienna delegacyjna. Jets argument typu delegacyjnego, a więc parametrem aktualnym; a więc argumentem aktualnym musi byc również delegacja do metody, a więc pewna referencja do metody. Tak naprawdę to co jest zapisane w nawiasach okrągłych to po prostu metoda, zresztą taka dokładnie sama metoda jak i poprzednio; z tą samą funkcjonalnością. Tylko z wykorzystaniem znowuż innej składni. Co wiecej, ta składnię można jeszcze uprościć. Mozna tu wrzucić okreslenie typu i zlecić kompilatorowi, aby sam określił wszystkie możliwe typy. Aby domyslił sie typów, na przykład typu argumentu, który jest przekazywany. Oczywiscie znając definicję tej metody z tej delegacji łatwo można wywnioskować jakiego typu musi być argument formalny. A więc znowu porównując definicję metody anonimowej z wyrażeniem lambda mozmy stwierdzic, ze różnica jet tylko i wyłacznie składniowa.

więc po pierwsze; mamy pytanie i wróćmy do tego pytania; co to znaczy funkcja anonimowa; skad się wzieła nazwa funkcji anonimowej? To po pierwsze, a po drugie, po co to wszystko, po co te wszystkie zmiany składniowe. Dlaczego potrzebujemy inny zapis tej samej funkcjonalnosci, która mieliśmy tu (`AnonymousMethodTest`) i która mielismy tu ? Wróćmy do tego zapisu, zeby odpowiedzieć na pytanie co to jest funkcja anonimowa. Otóż widzimy, że prawa strona przypomina zapis funkcji, jesli słowo `delegate` będziemy rozumieli jako nazwa funkcji, to funkcja delegate zwraca nam właśnie referencje do metody, która jest zdefiniowana po prawej stronie. Podstawowe pytanie; po co to wszystko?


TBD -->

## See also

- [Anonymous Functions (C# Programming Guide)](https://docs.microsoft.com/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-functions)
- [Expression Trees (C#)][ET]
- [Expression Class \(System.Linq.Expressions.Expression\)][ExpressionClass]


[ExpressionClass]:https://docs.microsoft.com/dotnet/api/system.linq.expressions.expression
[ET]:https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/expression-trees/index