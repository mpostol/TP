# Biathlon

Projekt przedstawia zagadnienia:

- Podział projektu na testowalne części
- Testy jednostkowe (unit tests)
- Test Driven Development (najpierw test, później kod)
- Wstrzykiwanie zależności (Dependency Injection)

## Zadanie

Opracować aplikację, która będzie dla podanego punktu (reprezentującego strzał do celu na strzelnicy) wczytywać ze standardowego wejścia parami współrzędne kolejnych punktów. Napotkanie pierwszego punktu odległego o nie więcej niż podany zakres ma zakończyć pozytywnie poszukiwanie: znaleziony punkt ma zostać zwrócony i zinterpretowany jako trafienie. Napotkanie punktu o współrzędnych `(0, 0)` ma przerwać negatywnie poszukiwanie: ma zostać zwrócony pusty punkt (np. `null`) i zinterpretowany jako brak trafienia.

## Rozwiązanie

W tym celu przygotowane będą następujące projekty:

### MetrykiLib

Biblioteka obliczeń odległości dla wektorów n-wymiarowych, reprezentowanych jako tablice n-elementowe, które zawierają kolejne współrzędne takich wektorów.

### MetrykiLibTests

Zbiór testów jednostkowych dla projektu **MetrykiLib**.

### Biathlon

Projekt aplikacji konsolowej realizującej zadanie analizy punktów reprezentujących strzały do celu na strzelnicy.
Zawiera moduł obliczeń odległości pomiędzy obiektami typu `Punkt`.

### BiathlonTests

Testy jednostkowe dla projektu **Biathlon**.
