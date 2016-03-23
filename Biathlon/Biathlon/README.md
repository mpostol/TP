# Biathlon

Projekt aplikacji konsolowej realizującej zadanie analizy punktów reprezentujących strzały do celu na strzelnicy.
Zawiera moduł obliczeń odległości pomiędzy obiektami typu `Punkt`, oraz klasę `Strzelnica` z algorytmem poszukiwania punktu dającego trafienie w okolicy punktu zadanego.

## Główne elementy

### `Pomiary/Punkt`

Klasa reprezentująca punkt na płaszczyźnie, z dwoma współrzędnymi `X` i `Y`.
Jest to klasa typu POCO ([Plain Old CLR Object](https://pl.wikipedia.org/wiki/Plain_Old_CLR_Object)) czyli obiekt, który:

* nie wymaga zależności ani atrybutów pochodzących z dodatkowych bibliotek
* nie wchodzi w relacje dziedziczenia z klasami dodatkowych bibliotek
* nie zawiera logiki biznesowej
* jest nieświadomy wymagań utrwalania danych (persistence)
* służy przede wszystkim do reprezentacji danych

### `Pomiary/OdlegloscPunktow`

Klasa zaprojektowana w stylu wzorca projektowego [Adapter](https://pl.wikipedia.org/wiki/Adapter_(wzorzec_projektowy)). Zawiera jedną główną metodę:

```C#
double ObliczOdleglosc(Punkt p1, Punkt p2)
```

Jej celem jest dopasowanie metody `ObliczOdleglosc(double[] a, double[] b)` z interfejsu `IMiaraOdleglosci` do potrzeby wykonania obliczeń na innym typie danych.
W tym przypadku metoda klasy `OdlegloscPunktow` ma działać na dwóch obiektach typu `Punkt`, a nie jak w bibliotece **MetrykiLib**, gdzie metody klas działają na dwóch wektorach n-elementowych.

Klasa `OdlegloscPunktow` wykorzystuje technikę **wstrzykiwania zależności** ([Dependency Injection](https://en.wikipedia.org/wiki/Dependency_injection)) do przekazania obiektu używanego przy obliczaniu odległości. Obiekt typu `IMiaraOdleglosci` przekazywany jest jako parametr konstruktora:

```C#
public OdlegloscPunktow(IMiaraOdleglosci miernik)
```

Ten sposób realizacji określa _zależność wymaganą_ - nie da się utworzyć obiektu klasy `OdlegloscPunktow` bez przekazania obiektu, bo bez niego nie będzie wiadomo jak obliczać odległość.

### `Strzelnica`

Zawiera algorytm poszukiwania punktów, metodę sprawdzania warunku końca pętli oraz sprawdzanie trafienia w zakresie nie większym niż podany promień od zadanego punktu.

Klasa ta ma zależność od obiektu `OdlegloscPunktow`, który jest przekazywany z użyciem techniki **wstrzykiwania zależności** poprzez parametr konstruktora:

```C#
public Strzelnica(OdlegloscPunktow odleglosc)
```

Przekazany obiekt klasy `OdlegloscPunktow` wykorzystywany jest w metodzie sprawdzającej trafienie:

```C#
public bool SprawdzTrafienie(Punkt punkt, Punkt zadany, double promien)
```