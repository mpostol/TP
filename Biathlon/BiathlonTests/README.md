# BiathlonTests

Zbiór testów jednostkowych dla projektu **Biathlon**.

## StrzelnicaTests

### Dependency Injection

Na czas testów dodatkowa metoda z atrybutem `TestInitialize` tworzy i komponuje obiekty wykorzystywane w metodach testowych:

```C#
[TestInitialize()]
public void Initialize()
```