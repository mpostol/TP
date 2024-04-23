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

<!--

## 1. Wprowadzenie

W trakcie tej lekcji będziemy kontynuowali omawianie tematyki dotyczącej danych strukturalnych i możliwość tworzenia kwerend z wykorzystaniem wyrażeń klasy LINQ – przypomnę, że skrót LINQ pochodzi od angielskiego Language Integrated Query, co w tłumaczeniu oznacza zintegrowany język zapytań.

## 2. Jaki mamy problem

### 2.1. Wprowadzenie

Zacznijmy od kilu definicji, wyjaśnień i wskazania kierunków poszukiwań nowych rozwiązań w zakresie usprawnienia zarządzania dostępem do danych zewnętrznych.

### 2.2. Zakres lekcji

Tu jeszcze raz wrócimy do poznanego poprzednio terminu „wyrażenie klasy LINQ” zapisanego zgodnie ze składnią query sysntax - co tłumaczymy jako składnia zapytań - i wtedy przypomnę, czym oprócz składni, różni się wyraźnie tej klasy od innych wyrażeń nie należących do grupy wyrażeń klasy LINQ.

Zgodnie z definicją, wyrażenie to ciąg operacji i operandów. Omówione wcześniej wyrażenie zapisane z wykorzystaniem składni zapytań, na pierwszy rzut oka na taki ciąg nie wygląda, a przecież musi dać się do takiego ciągu sprowadzić, więc być skonwertowane do postaci zgodnej z tą definicją z wykorzystaniem metod rozszerzających, wyrażeń lambda i typów anonimowych.
Wyrażenia LINQ powstały, aby umożliwić zapisanie w języku programowania kwerendy umożliwiające zdalną preselekcję w zewnętrznych repozytoriach danych, przykładowo relacyjnych bazach danych. Ale wcześniej zauważyliśmy, że preselekcja danych ma również sens w przypadku lokalnych danych strukturalnych, czyli pewnego grafu obiektów. Kolejnym zatem wyzwaniem tej lekcji jest omówienie zagadnień związanych z projektowaniem, tworzeniem, utrzymaniem i wykorzystaniem takiej struktury. Tu również spróbujemy odpowiedzieć na pytanie jak LINQ może nam pomóc.

## 3. Praca z kodem

### 3.1. Składnia kwerendy

Zgodnie z planem wróćmy zatem na chwilę do poprzedniej lekcji i przypomnijmy sobie postać wyrażenia LINQ zapisanego z wykorzystaniem składni kwerendy.

Wyrażenie LINQ w postaci kwerendy znajdziemy w omówionej poprzednio metodzie [QuerySyntax][QuerySyntax]:

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

Jak już mówiłem, zgodnie z definicją wyrażenie to ciąg operacji i operandów, natomiast składnia tekstu w przykładowym kodzie zawiera nowe słowa kluczowe, jak `from`, `where`, `selekt` ale nie wygląda jak ciąg operacji, a przecież musi dać się do takiego ciągu sprowadzić, by moc ten tekst nazywać wyrażeniem. No dobrze, a co jeśli nie. Jakie są konsekwencje. W takim przypadku ponieważ nie będziemy mogli nazwać tego zapisu wyrażeniem to w konsekwencji nie będziemy mogli do niego zastosować semantyki wyrażenia, czyli wiedzy o tym jak jest ono realizowane, inaczej, co ten zapis oznacza.

Zamiast dorabiać nową teorię do prawej strony instrukcji podstawienia, wydaje się, że prościej będzie spróbować konwersji tej składni do znanej nam dobrze składni wyrażenia, które jest ciągiem operacji i ich operandów. Tu trzeba zauważyć, że konwersja - inaczej przekształcenie - z jednej składni do innej oznacza działanie na tekście programu. A to z kolei oznacza, że konwersję tę może dokonać każdy programista.

W konwersji bardzo pomocna, a nawet można powiedzieć niezastąpiona, będzie konstrukcja „metoda rozszerzająca”, którą poznaliśmy wcześniej, kiedy uczyliśmy się podstaw programowania funkcyjnego.

Ale teraz przechodząc do sedna tematu, zacznijmy od tego, że zgodnie z wymaganiami wyrażenia LINQ źródło danych, w naszym przykładzie wartość wyrażenia występującego po słowie kluczowym in musi implementować interfejs IEnumerable. Jeśli tak, to wykorzystajmy koncepcję wspomnianej wcześniej metody rozszerzającej do rozszerzenia właśnie tego interfejsu.

### 3.2. Konwersja składni kwerendy do typowej składni wyrażenia

Korzystając z tej podpowiedzi już czas na poszukanie rozwiązania, które umożliwi nam dokonanie konwersji omówionej składni wyrażenia zapisanej w postaci kwerendy na wyrażenie zapisane w postaci ciągu operacji i ich operandów z wykorzystaniem wspomnianych metod rozszerzających, ale również wyrażeń lambda i typów anonimowych. Wszystkie te konstrukcje poznaliśmy już poprzednio. Ich znaczenie jest fundamentalne, więc jeśli są wątpliwości co do ich pełnego zrozumienia proponuje wrócić do tych tematów przed dalszą kontynuacją rozważań nad wyrażeniem LINQ.

Przykładowy tekst po konwersji znajduje się w metodzie [MethodSyntax][MethodSyntax], 

``` CSharp

    public static string MethodSyntax()
    {
      string[] _words = { "apple", "strawberry", "grape", "peach", "banana" };
      IEnumerable<string> _wordQuery = _words.Where<string>(word => word[0] == 'g').Select<String, String>(word => word);
      return String.Join(";", _wordQuery.ToArray());
    }
```

którą znajdziemy w klasie [LinqMethodSyntaxExamples][LinqMethodSyntaxExamples]. Metoda ta jest testowana w osobnym teście jednostkowym

``` CHarp

    public void MethodSyntaxTest()
    {
      Assert.AreEqual<string>("grape", LinqMethodSyntaxExamples.MethodSyntax());
    }

```
Wynik testu oraz treść metody wskazują, że jest ona funkcjonalnie ekwiwalentną z poprzednio omówioną metodą.

[QuerySyntax]: LINQQueryAndMethodsSyntax/LinqQuerySyntaxExamples.cs#L30-L37
[MethodSyntax]: LINQQueryAndMethodsSyntax/LinqMethodSyntaxExamples.cs#L21-L26
[LinqMethodSyntaxExamples]: LINQQueryAndMethodsSyntax/LinqMethodSyntaxExamples.cs#L19-L47
[MethodSyntaxTest]: ../StructuralDataUnitTest/LinqMethodSyntaxExamplesUnitTest.cs#L21-L24

W omawianym przykładzie pierwszą metodą rozszerzającą, którą wykorzystano w procesie konwersji jest metoda [where]. Oczywiście zbieżność nazw słowa kluczowego `where` w składni zapytań i nazwy metody w transformacji tego tekstu do ciągu operacji i ich operandów nie jest przypadkowa. Innymi słowy nazwa metody jest ekwiwalentna do słowa kluczowego where w składni kwerendy.

Używając skrótu „go to definition” menu kontekstowego albo klawisza F12 przeniesiemy się do definicji metody where. Po przewinięciu kilku ekranów widać, że znajduje się ona w statycznej klasie `Enumerable` biblioteki .NET. 

- filmik

Klasa ta zawiera również wszystkie pozostałe metody, które są niezbędne do realizacji opisanej operacji konwersji. To ważne stwierdzenie i warto je zapamiętać dla zrozumienia odpowiedzi na postawione już wcześniej zadane co to jest wyrażenie LINQ i czym się ono różni od wyrażeń nie należących do tej kategorii wyrażeń. Jak wspomniałem, to pytanie padło już wcześniej , ale wrócimy do niego jeszcze raz.

Kolejnym słowem kluczowym w składni kwerendy jest `selekt`. I znów możemy zastosować metodę rozszerzającą interfejsu `IEnumerable`, ponieważ metoda where zwraca obiekt implementujący ten interfejs. Jak widzimy z definicji klasy Enumerable większość metod rozszerzających zlokalizowanych w klasie Enumerable to funkcje zwracające obiekty implementujące wspomniany interfejs.

Wróćmy ponownie do tekstu omawianej metody, która zawiera wyrażenie LINQ po konwersji do postaci ciągu operacji.

Mając wiedzę na temat konwersji kwerendy LINQ do postaci sekwencji wywołań metod zastanówmy się teraz co zrobić z konstrukcjami występującymi po słowach kluczowych where i selekt. Na pierwszy rzut oka wyglądają jak wyrażenia i faktycznie ich składnia jest zgodna ze składnią wyrażenia. Jednak metoda where jest wywoływana na rzecz ciągu elementów, a zatem to wyrażenie musi być wykonywane na rzecz każdego elementu w źródle danych. W tym przypadku sprawdzamy czy pierwsza litera każdego słowa w tablicy to g. Aby to było możliwe zgodnie z semantyką języka musimy je zastąpić metodą, która będzie miała jeden parametr o typie zgodnym z typem elementu w źródle i będzie zwracała wartość true lub false. Ponieważ nie możemy do metody przesłać innej metody jako argumentu, wykorzystajmy koncepcję delegacji, więc referencji do metody. Dodatkowo możemy to zapisać jako funkcja anonimowa z wykorzystaniem składni wyrażenia lambda.

Podobnie możemy postąpić z wyrażeniem występującym po słowie selekt i zastąpić je delegacją do metody zapisanej jak wyrażenie lambda. W naszym przykładzie ta metoda zwraca wartość argumentu aktualnego, a więc robi nic i dlatego z następnego przykładu została usunięta.

Popatrzmy teraz na tekst metody otrzymanej w wynik przekształcenia kwerendy w kontekście testu jednostkowego. Test pokazuje, że rezultat jest identyczny jak dla metody wykorzystującej zapis w postaci kwerendy LINQ.

Zbadajmy zatem, czy po konwersji kwerendy LINQ do postaci ciągu operacji nadal zachowuje on cechy wskazujące, że podobnie jak poprzednio wyrażenie nie jest wykonywane w instrukcji podstawienia, a tylko konwertowane do obiektu reprezentującego to wyrażenie w celu przygotowania do ewentualnego dalszego tłumaczenia na postać zgodną z językiem zapytań obowiązującym dla wybranego repozytorium, przykładowo relacyjnej bazy danych. W trakcie następnej lekcji omówimy właśnie taki przykład, w którym wyrażenie LINQ będzie konwertowane do postaci kwerendy SQL zgodnie z wymaganiami tego repozytorium.

Aby to sprawdzić, podobnie jak poprzednio, modyfikujemy źródło danych pomiędzy instrukcją podstawienia wartości otrzymanego z wyrażenia po konwersji do zmiennej _wordQuery i instrukcją sprawdzającą ostateczny wynik w teście jednostkowym. Ponieważ w wyniku spodziewamy się listy słów na g, a otrzymujemy pusty string, możemy postawić tezę, że operacja wyznaczenia wartości jest odroczona podobnie jak poprzednio, natomiast w linii

``` CSharp
  IEnumerable<string> _wordQuery = _words.Where<string>(word => word[0] == 'g');
```

do zmiennej `_wordQuery` będzie podstawiana jakaś wartość reprezentująca tylko opis wyrażenia, które znajduje się po prawej stronie znaku podstawienia. Innymi słowy składnia wyrażenia LINQ nie ma znaczenia dla jego cech. Innymi słowy zapisanie wyrażenia w postaci kwerendy lub ciągu operacji nie ma wpływu na semantyke tego zapisu. W obu przypadkach mówić o wyrażeniu LINQ bez względu na postać zapisu. Ponieważ zachowanie wyrażeń LINQ znacznie odbiega od zachowań innych wyrażeń, które do tej grupy nie należą musimy wrócić do pytania, jak je rozróżnić.

Wcześniej mówiliśmy, że konwersja do postaci ciągu operacji wymaga użycia metod rozszerzających zdefiniowanych w klasie Enumerable. Jak wiemy dla każdego typu można utworzyć własne metody rozszerzające, więc do `IEnumerable` również. Jest zatem możliwe, aby w ciągu omawianych operacji użyć również tych własnych metod. To oczywiście jest możliwe, ale wyrażenie przestanie być wyrażeniem LINQ i w rezultacie nie będzie mogło być konwertowane do kwerendy, która możne być wykonywana zdalnie w zewnętrznym repozytorium jako ekwiwalentna operacja. Użycie w wyrażeniu wyłącznie metod należących do klasy `Enumerable` jest pierwszym wyróżnikiem wyrażenia klasy LINQ, ale nie jedynym.

W przykładowym programie, który ilustrował proces konwersji składni kwerendy wyrażenia LINQ do postaci ciągu operacji, użyto wyrażeń lambda jako operandów dla tych operacji. Tu warto sobie zadać pytani, czy w ich miejsce można użyć delegacji do własnych metod nazwanych. Odpowiedź jest, że oczywiście tak, tylko w takim przypadku trzeba sobie zdawać sprawę z faktu, że takie metody mogą nie być znane w zewnętrznym repozytorium i jak się do nich odwołać w kwerendzie zapisanej w języku dedykowanym dla tego repozytorium. I to jest kolejne kryterium pozwalające na odróżnienie wyrażeń klasy LINQ.

Aby opisać kolejne musimy dokonać analizy następnej metody testowej i związanej z nią metody bibliotecznej [AnonymousType]. 

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

Metoda ta wybiera z tablicy elementów 'Customer' wszystkie pozycje w których property City == "Phoenix". Na ich podstawie zwracany jest ciąg wartości typu anonimowego. W metodzie selekt do tworzenia nowych wartości użyto typu anonimowego. Tu jednak rodzi się wątpliwość, czy użycie tego typu jest niezbędne. Czy można w metodzie selekt tworzyć nowe wartości korzystając z własnego typu nazwanego. W ramach pracy domowej proponuję sprawdzić to oraz to czy wyrażenie nadal będzie miało cechy wyrażenia klasy LINQ. Tu jednak zauważmy, że własny typ może nie być znany w kontekście języka kwerend używanego dla wybranego zewnętrznego repozytorium danych. Typy anonimowe to zbiór wartości, który zawsze można przekształcić do ciągu par {klucz, wartość}, co jest reprezentacją łatwo dającą się użyć w kontekście dowolnego języka kwerend dla zewnętrznego repozytorium danych.

### 3.3. Lokalne dane strukturalne 

Relatywnie dużo czasu poświęciliśmy na omówienie wyrażenia LINQ w kontekście danych strukturalnych zgromadzonych i udostępnianych przez zewnętrzne repozytoria danych ale wszystkie operacje w przykładowym tekście programu były wykonywane na danych lokalnych. Choć były to dane złożone, przykładowo tablica, to nie reprezentowały relacji pomiędzy niezależnymi obiektami, więc nie korzystaliśmy z danych strukturalnych. Przyjrzyjmy się teraz jak projektować, tworzyć, utrzymywać i wykorzystywać takie struktury. Tu również spróbujemy odpowiedzieć na pytanie jak LINQ może nam pomóc. W szczególności, jeśli jest potrzeba odrębnej preselekcji danych w przypadku lokalnych danych strukturalnych, czyli pewnego grafu obiektów.

Podstawowym sposobem tworzenia danych strukturalnych jest definiowanie własnych klas i łączenie ich z wykorzystaniem referencji. Takie właśnie podejście ilustruje definicja klas dla przykładowej struktury, którą omówiliśmy wczesniej. Kod ten znajduje się w projekcie testów jednostkowych i zawiera dwie klasy, pomiędzy którymi występują relacje.

Popatrzmy teraz na analizę graficzną kodu. W rezultacie po zmianie ustawień filtrowania możemy wspomniane relacje pomiędzy klasami zobaczyć na rysunku. W przypadku danych lokalnych relacje pomiędzy obiektami są realizowane za pośrednictwem zmiennych referencyjnych.

-->

![PersonCodeMap](../.Media/PersonCodeMap.png)

- [Person][Person]
- [CDCatalog][CDCatalog]
- [TestDataGenerator][TestDataGenerator]

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

[TestDataGenerator]: ../StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L17-L73
[Person]: ../StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L29-L47
[CDCatalog]: ../StructuralDataUnitTest/Instrumentation/TestDataGenerator.cs#L61-L72

