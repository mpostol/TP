# MetrykiLib

Biblioteka obliczeń odległości dla wektorów n-wymiarowych, reprezentowanych jako tablice n-elementowe, które zawierają kolejne współrzędne takich wektorów.

## Główne elementy

### `IMiaraOdleglosci`

Interfejs definiujacy jedną metodę:
```C#
double ObliczOdleglosc(double[] a, double[] b);
```

### `MetrykaEuklidesowa`

Klasa implementująca interfejs `IMiaraOdleglosci`. Odległość obliczana jest jako pierwiastek kwadratowy z sumy kwadratów odległości (różnic odpowiednich współrzędnych) w każdym kolejnym wymiarze.
Patrz: [Przestrzeń euklidesowa](https://pl.wikipedia.org/wiki/Przestrze%C5%84_euklidesowa#Definicja)

### `MetrykaTaksowkowa`
Klasa implementująca interfejs `IMiaraOdleglosci`. Odległość obliczana jest jako suma wartości bezwzględnych odległości (różnic odpowiednich współrzędnych) w każdym kolejnym wymiarze.
Patrz: [Przestrzeń metryczna](https://pl.wikipedia.org/wiki/Przestrze%C5%84_metryczna#Metryka_.E2.80.9Emiasto.E2.80.9D)
