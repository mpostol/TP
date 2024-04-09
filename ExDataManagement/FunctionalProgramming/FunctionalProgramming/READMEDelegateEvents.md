# Delegate and Events

- [Delegate and Events](#delegate-and-events)
  - [Zdarzenie](#zdarzenie)
  - [DelegateVsExpressionTest](#delegatevsexpressiontest)
  - [Praca domowa](#praca-domowa)

Delegates in C# do not explicitly contribute to functional programming, although they cannot be omitted in the context of anonymous functions language constructs. They are also vital for implementing inter-layer communication. Considering both arguments it is clear that delegated must be investigated in detail as a part of the introduction describing selected language constructs implicitly contributing to functional programming.

Delegates are similar to C++ function pointers, but delegates are fully object-oriented, and unlike C++ pointers to member functions, delegates encapsulate both an object instance and a method.

- Delegates allow methods to be passed as parameters.
- Delegates can be used to define callback methods.
- Delegates can be chained together; for example, multiple methods can be called on a single event.
- Methods don't have to match the delegate type exactly. For more information, see Using Variance in Delegates.
- Lambda expressions are a more concise way of writing inline code blocks. Lambda expressions (in certain contexts) are compiled to delegate types. For more information about lambda expressions, see the section [Anonymous Functions][AnonymousFunctions].

## Zdarzenie

Definicję zdarzenia, czyli `event`, znajdziemy w tej linijce. Widzimy, ze mamy tutaj słowo kluczowe `event`, po którym nastepuje identyfikator i jak podejrzymy to ten identyfikator podobnie jak wczesniej pokazuje na typ delegacyjny. Więc jest to odwołanie do typu delegacyjnego. Dalej mamy identyfikator i w sumie cała ta definicja jest identyczna z definicją zmiennej. A więc w tym przypadku również mamy do czynienia ze zmienną delegacyjną. Pytanie jest tylko co zmienia słowo `event`. W jaki sposób to słowo wpływa na sposób wykorzystania zmiennej. Mianowicie słowo event ogranicz możliwość wywołania metod które są wskazywane, do których są referencje w tej zmiennej tylko i wyłacznie do wnetrza tej klasy.

## DelegateVsExpressionTest

Prawdziwa jakościową zmianę możemy zaobserwowac w tej linijce, w które znowu po prawej stronie mamy wyrażenie lambda. Po prawej mamy definicje zmiennej, ale tym razem ta zmienna nie jest zmienna delegacyjną. To jest zmienna, która jest typu expression. Jest to klasa, a więc jest to zmienna referencyjna, która będzie miała referencje do obiektu tej klasy. Ale przecież po prawej stronie zgodnie z zapisem, który mamy tutaj powinniśmy utworzyc delegację. Typ delegacyjny nie jest zgodny z type referencyjnym. I tu własnie jest ta zasadnicza różnica, ponieważ w tym przypadku nie tworzymy typu delegacyjnego; nie tworzymy wartości delegacyjnej; nie tworzymy referencji do metody. Kompilator tłumaczy prawą strone, całe to wyrażenie tłumaczy do obiektu, który jest typu `Expression`. A więc kompilator szuka reprezentacji obiektowej dla wyrażenia, które jest po prawej stronie. Jets to możliwe tylko i wyłacznie wtedy, kiedy składnia tego wyrażenia jest odpowiednio uproszczona. Popatrzmy na błąd! Otóż kiedy zmieniłem zapis wyrazenia lambda na troche bardziej skomplikowany, nadal zgodny ze składnią wyrazenia lambda; tu użyłem nawiasów kwadratowych, a więc spodziewamy się, że tu może być kilka instrukcji. W tym momencie kompilator juz nie potrafi tego przetłumaczyć; nie potrafi znaleźć reprezentacji obiektowej. Dlaczego to jest takie ważne. Otóż ważne to jest dla tego, że reprezentacja obiektowa (22:20) z wykorzystaniem typu `Expression` pozwala na zbudowanie czegoś, co nazywamy expression tree. I takie expression tree może byc przetłumaczone na język zewnetrznego systemu, na przykład SQL. I tak kwerenda SQL po przetłumaczeniu wyrażenia może być wysłana do zewnętrznego systemu w celu realizacji go poza naszym procesem, poza naszym programem.

I tutaj widzimy rewolucję. Po raz pierwszy stosując wyrażenia lambda mozemy bezposrednio pisać program, który będzie przetłumaczalny; będzie mógł być tłumaczony na zewnetrzny język, który jest jezykiem natywnym dla zewnetrznego repozytorium danych.

## Praca domowa

No i praca domowa. Po pierwsze, chciałbym poprosić o przeanalizowanie kodu, który jest tutaj pokazany. On jest załączony w testach jednostkowych (`EventTestMethod`) i zrozumienie tego testu, pod kątem testowania zdarzenia. A drugie pytanie dotyczy błędy, który tam jest zakomentowany. Z jakiego powodu ten błąd wystepuje?

[AnonymousFunctions]: README.AnonymousFunctions.md
