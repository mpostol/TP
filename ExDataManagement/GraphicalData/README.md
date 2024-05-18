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

# Graphical Data

## Preface

- XAML - Description of the Graphical Interface
- MVVM Programming Design Pattern

## Research

### What is control?

It is a type that encapsulates user interface functionality and is used in client-side applications. This type has associated shape and responsibility to be used on the graphical user interface. A Control is a base class used in .NET applications, and the MSDN documentation explains it in detail. There is a bunch of derived classes that inherit from it, for example, Button.

## See also

- [XAML in WPF](https://docs.microsoft.com/dotnet/framework/wpf/advanced/xaml-in-wpf)
- [TreeView Overview](https://docs.microsoft.com/dotnet/framework/wpf/controls/treeview-overview?view=netframework-4.7.2)

<!--

# Graficzny Interfejs Użytkownika (GUI)

- [Graficzny Interfejs Użytkownika (GUI)](#graficzny-interfejs-użytkownika-gui)
  - [Jaki mamy problem](#jaki-mamy-problem)
    - [Wstęp](#wstęp)
    - [Informacja](#informacja)
    - [GUI jako drzewo kontrolek](#gui-jako-drzewo-kontrolek)
  - [Wykorzystanie](#wykorzystanie)
    - [Wprowadzenie](#wprowadzenie)
    - [Od ogółu do szczegółu](#od-ogółu-do-szczegółu)
    - [Wprowadzanie danych](#wprowadzanie-danych)
    - [Dynamika](#dynamika)
    - [Wykonywanie Poleceń](#wykonywanie-poleceń)
    - [Nieaktywne Kontrolki](#nieaktywne-kontrolki)
    - [Zakres Wyświetlanych Danych](#zakres-wyświetlanych-danych)
    - [Kompozycja Kontrolek](#kompozycja-kontrolek)
      - [Rendering](#rendering)
      - [Edycja w Blend](#edycja-w-blend)
  - [Praca domowa](#praca-domowa)
  - [Zakończenie](#zakończenie)

Tą lekcją zaczynamy nowy cykl, poświęcony omówieniu wybranych zagadnień związanych z reprezentacją informacji procesowej w postaci graficznej, a mianowicie spróbuję w żołnierskich słowach odpowiedzieć na pytanie jak zbudować graficzny interfejs użytkownika. Muszę tu jednak podkreślić, że zgodnie z głównym tytułem kursu będę się koncentrował na zagadnieniach związanych z językiem programowania C#, więc jego składnią i semantyką. Niestety nie możemy całkowicie tu uciec od zagadnień związanych z wykorzystywanym środowiskiem projektowym, więc Visual Studio oraz wykorzystaniem kolejnego języka Extensible Application Markup Language, w skrócie xaml. Niestety poznanie tego języka jest poza zakresem kursu. Tu jednak muszę uspokoić, jego znajomość nie jest warunkiem koniecznym, to nie jest warunek zrozumienia żadnej z lekcji w tej grupie tematycznej.

## Jaki mamy problem

### Wstęp

Zacznijmy od kilu definicji, wyjaśnień i wskazania kierunków poszukiwań nowych rozwiązań, w zakresie usprawnienia operowania danymi graficznymi. Na początek zacznijmy od rysunku, który już kilka razy przydał się do zobrazowania o czym będziemy mówili. Na pokazanej ilustracji tekst naszego programu został skompilowany, wprowadzony do pamięci i stał się procesem zarządzanym przez system operacyjny komputera. System operacyjny silnie broni integralności zasobów przekazanych do procesu. Ta obrona to hermetyzacja, która zmusza do korzystania z systemu operacyjnego w przypadku konieczności wymiany danych z otoczeniem zewnętrznym, a w tym z ekranem komputera.

Rysunek przedstawia program jako konstrukcję warstwową. Przyczyny wprowadzenia warstw zostały już omówione i proponuję ponownie szczegółowo nie wracać do tego tematu teraz. Poprzednio mówiliśmy o zagadnieniach związanych z zarządzaniem zewnętrznymi repozytoriami danymi. Strumienie udostępniane przez system plików to jedna z opcji, którą możemy wykorzystać w roli repozytorium.  W tym przypadku dane są przechowywane jako strumień bitów, który możemy przekształcić w dane przetwarzane w ramach procesu i na odwrót z wykorzystaniem operacji serializacji i deserializacji. Tu warto przypomnieć, że było kilka lekcji na ten temat.

Kolejna opcja, o której również mówiliśmy dość szczegółowo, to bazy danych, a więc pewien zewnętrzny systemem zarządzania danymi strukturalnymi (Database Management System, w skrócie DBMS). Celem DBMS jest spójne przechowywanie i archiwizowanie danych zgodnie z pewnym schematem, który pozwala na archiwizowanie danych złożonych i jednocześnie tworzenie relacji pomiędzy poszczególnymi bytami tych danych. Dane są udostępniane i przetwarzane przez DBMS z wykorzystaniem pewnego języka zapytań.

W tej lekcji omówimy graficzną reprezentację informacji, czyli dane graficzne w postaci umożliwiającej  komunikację z użytkownikiem. To zmusza, aby tym razem nasze rozważania były osadzone w kontekście szeroko rozumianego języka naturalnego, w którym jak mówi klasyk, rysunek zastępuje tysiąc słów. Skoro padło słowo język, to musimy wrócić do naszej definicji języka. Według niej język zawiera trzy definicje składowe, a mianowicie

- alfabet – czyli zbiór znaków,
- reguły składniowe – czyli jak znaki łączyć w poprawne ich ciągi i
- reguły semantyczne pozwalające przypisać znaczenie do tak utworzonych ciągów znaków.

W przypadku współczesnego ekranu komputerowego alfabet to zbiór kolorowych pikseli, które nasz program będzie traktował jako słowo binarne. I tu już zaczynają się schody, bo długość tego słowa - limitująca przecież ilość kolorów - może zależeć od konkretnego sprzętu, więc być różna dla poszczególnych instancji naszego programu, który musi być zawsze taki sam. Tą niejednorodność da się jeszcze jakoś obejść. Natomiast, znacznie gorzej jest z regułami składniowymi i semantycznymi kompozycji pikseli. Niestety jak zwykle, kiedy mamy do czynienia z językiem naturalnym w miejsce przypisania informacji do poprawnie utworzonych ciągów znaków musimy borykać się z interpretacją znaczenia utworzonej kompozycji pikseli. To często jest dla programistów frustrujące, ponieważ prowadzi do kwestionowania jakości ich pracy w sytuacji, kiedy miary jakości są niedookreślone. Jako przykład przytoczę sytuację, w której zespół demonstrował nową aplikację naszemu amerykańskiemu partnerowi. Z aplikacji byliśmy bardzo dumni i pokaz wypadł super dobrze - dostaliśmy wiele pochwał. Było tylko jedno bardzo zasadnicze zastrzeżenie – kolory zastosowanego motywu okazały się nie amerykańskie, tak dosłownie nie amerykańskie, pomimo że próbowaliśmy dokładnie naśladować te, przesłane nam kiedyś w gifie.

### Informacja

Tyle teoria, ale jak sobie z tym poradzić – to prawdziwe wyzwanie dla tej części kursu. Wychodząc mu naprzeciw proponuję zdefiniować kierunki dalszych poszukiwań. Informacja, czyli wiedza która jest reprezentowana przez pewien obraz jest z niego odczytywana na drodze interpretacji. Więc tworzenie grafiki będzie wymagało uwzględnienia wrażeń estetycznych, co wymaga odwoływania się do niedookreślonego poczucia piękna. Obrazek musi również spełniać wymagania ergonomii, czyli być dostosowanym do możliwości psychofizycznych użytkownika, więc człowieka – to zgodnie z Wikipedią wymaga wiedzy z zakresu psychologii, socjologii, fizjologii, higieny, medycyny, antropometrii oraz nauk technicznych, np. budowy maszyn. Bez wątpienia – komputer to maszyna – to już przerabialiśmy na samym wstępie tej przygody intelektualnej. Co więcej, każdy program to implementacja pewnego algorytmu, czyli automatyzacja wybranego procesu. Zatem zachowanie ekranu, który staje się pulpitem sterujący przebiegiem tego procesu, musi być bezpośrednio związane z tym procesem, a to wymaga wiedzy dziedzinowej związanej z procesem.

Na liście dziedzin uwikłanych w komunikację człowiek-maszyna był komputer, a to już nasza działka, mówiąc kolokwialnie. Obrazek na jego ekranie musi być wynikiem działania naszego programu. Program to tekst utworzony przez programistę, a programiści to nie nadludzie, którzy znają się na wszystkim o czym przed chwilą mówiłem, a w szczególności na tym, które kolory są amerykańskie, że wrócę do przytoczonej wcześniej z życia wziętej dykteryjki.

To nasz pierwszy problem, a mianowicie jak włączyć innych specjalistów, a w tym bezpośrednich użytkowników w proces projektowania GUI. Jeszcze raz wróćmy do dykteryjki, jeśli nie wiemy co to znaczy kolor amerykański, dajmy szansę wykazać się naszej koleżance z za Oceanu. Tylko bez przesady nie wymagajmy od niej technicznej wiedzy, a w szczególności znajomości jakiegoś języka programowania.

### GUI jako drzewo kontrolek

Obrazek jest ciągiem kolorowych pikseli. Muszą się one komponować w taki sposób, aby reprezentować wybrane informacje procesowe, tzn. jego stan lub zachowanie. Podobnie jak w przypadku danych w pamięci, które przecież przetwarzamy nie odwołując się bezpośrednio do ich binarnej reprezentacji, również GUI nie tworzymy mozolnie składając piksele w spójną kompozycję. Co więcej, jak wspomniałem wcześniej GUI stanowi pulpit sterujący przebiegiem procesu, więc musi również zachowywać się dynamicznie, a w tym umożliwiać wprowadzanie danych i wydawanie poleceń.

Kolejnym problemem jest zatem to, jak zapewnić odpowiedni poziom abstrakcji, tzn. ukryć szczegóły związane z powstawaniem obrazka. Wprowadzimy tu dwa pojęcia kontrolka i renderowanie.  Ukrywanie szczegółów zawsze prowadzi do pogodzenia się z faktem, że coś się dzieje poza naszą kontrolą. Mieliśmy z tym już do czynienia w przypadku generowania kwerend SQL na podstawie wyrażeń LINQ. Podobnie jak w przypadku LINQ, aby nasze rozważania były osadzone w kontekście praktycznych przykładów, musimy użyć konkretnej technologii. Wybrałem Windows Presentation Foundation (w skrócie bardziej swojsko brzmiący skrót WPF), ale postaram się, byśmy nie stracili ogólności rozważań.  Omówienie WPF wymaga osobnego kursu, a my pozostaniemy możliwie blisko zagadnieniom związanym z praktyką wykorzystania języka C#.

## Wykorzystanie

### Wprowadzenie

Najlepszym sposobem, aby zilustrować podstawowe zagadnienia związane z reprezentacją informacji procesowej z wykorzystaniem graficznego interfejsu użytkownika, jest próba przedstawienia ich w kontekście przykładowego programu i jego interfejsu użytkownika.

W przykładowym programie jest projekt, który zawiera interfejs użytkownika i może być uruchomiony jako samodzielna aplikacja. Możemy go uruchomić bezpośrednio korzystając z mechanizmów systemu operacyjnego. Ja jednak proponuję jego start wprost z Visual Studio, gdzie mamy opcję uruchomienia nowej instancji w trybie diagnostycznym korzystając z menu kontekstowego. W efekcie tworzony jest proces do którego przydzielane są zasoby. Możemy to obserwować korzystając z narzędzi diagnostycznych. Omówienie korzystania z tych narzędzi jest całkowicie poza zakresem naszych zainteresowań, więc spróbuję teraz znaleźć rezultat w postaci GUI programu, który właśnie uruchomiłem. Jest on na sąsiednim ekranie, więc muszę go przesunąć w obszar rejestracji tego video. Jak widzimy to typowe okienko aplikacji Windows, w którym możemy wyróżnić nagłówek i potrzebną zawartość użytkową. Nagłówek to tytuł, czyli jakiś tekst oraz dwa klawisze służące do skalowania okna względem ekranu monitora i trzeci pozwalający zakończyć proces realizujący nasz program.

Co do wrażeń estetycznych, to nie będziemy tematu drążyć. Ale oczywiście bez specjalnego problemu możemy zakwestionować kolory i stwierdzić, że nie są amerykańskie. Znowu nawiązuję do poprzedniej dykteryjki nie po to, by się pastwić nad tym zagadnieniem ale, aby spróbować znaleźć rozwiązanie tego i setek podobnych problemów. Ten przysłowiowy kolor niech będzie ilustracją zagadnień związanych z interdyscyplinarną pracą zespołową i podziałem kompetencji związanych z projektem graficznej reprezentacji informacji. Na kilku wybranych przykładach pokażę, gdzie możemy spodziewać się kłopotów. Celem moim są zagadnienia związane z językiem programowania, więc proszę mi wybaczyć lapidarność przykładów i spłycenie omawianych zagadnień.

W śród tych problematycznych zagadnień są zapewne zagadnienia związane z ergonomią tego interfejsu. Przykład jest dydaktyczny, a nie produkcyjny, ale nawet tu można wiele zdziałać w tym zakresie. Przejdę zatem do funkcjonalności, czyli danych i zachowania się tego interfejsu. Te białe prostokąty to miejsca wymiany danych pomiędzy instancją programu a jego użytkownikiem. Te szare prostokąty to klawisze, które zmieniają kolor po najechaniu myszką, wskazując możliwość kliknięcia w nie. Nie pastwiąc się nad estetyką rozwiązania załóżmy tylko, że kolor tła fragmentu okna w którym pokazały się dane w wyniku kliknięcia jednego z klawiszy nie jest idealny, żeby nie powiedzieć, że nie jest amerykański i wymaga konsultacji z kimś kto wie jaki powinien być i ten ktoś nie jest programistą.

Z faktu, że w wyniku kliknięcia w ten obszar zmieniło się tło dla kilku danych, możemy domniemywać, że stanowią one pewną całość, więc są daną złożoną. Dana złożona to jeden byt tylko taki w którym widoczne są składowe. Jako przykład problemu związanego z ergonomią rozwiązania możemy tu wytknąć, że fakt występowania grupowania wymaga pewnej akcji ze strony użytkownika, a przecież grupowanie to powinno być widoczne zawsze. Dla programisty to grupowanie może być czymś absolutnie oczywistym, a potrzeba graficznego wyróżnienia grupowania nieuświadomioną potrzebą.

### Od ogółu do szczegółu

Kolejna funkcja interfejsu ujawnia się po kliknięciu na grupę danych, co powoduje pojawienie się kolejnych szczegółów w innych częściach interfejsu. Tu specjaliści od ergonomii pewnie będą kwestionowali brak podkreślenia trwałego związku danych szczegółowych z danymi ogólnymi, czyli skąd wiadomo, że po prawej stronie mamy szczegóły tego, co wybrano po stronie lewej.

### Wprowadzanie danych

Najechanie myszką na kolejny obszar przeznaczony na dane ujawnia kolejną funkcję, a mianowicie możliwość wprowadzenia nowych lub modyfikowania aktualnych danych. Na ekranie widzimy przypadek modyfikacji. I tu znowu pytanie do ekspertów od ergonomii, a nie do programistów: skąd użytkownik ma wiedzieć, że ten tekst jest edytowalny.

Tu warto wspomnieć o kolejnej funkcjonalności, którą interfejs użytkownika powinien realizować, a mianowicie kontrola poprawności wprowadzanych danych. A to już nasza działka. W przykładzie możemy wpisać dowolny tekst, ale można sobie łatwo wyobrazić, że teks będzie sprawdzany pod kątem ortografii dla wybranego języka naturalnego.

### Dynamika

Po modyfikacji danej możemy zasymulować dynamiczne zachowanie interfejsu, a mianowicie kliknięcie w klawisz nad tekstem powoduje rozpoczęcie procedury przetwarzania nowej wartości dla wybranej danej, w tym przypadku potwierdzonego wyświetleniem okna sygnalizującego zakończenia operacji. Tu mamy jeszcze kolejny problem, jak zapewnić, żeby aplikacja była responsywna, czyli żeby omawiany interfejs nie był zamrożony w sytuacji, gdy zlecona operacja trwa zauważalnie długo.

### Wykonywanie Poleceń

Pozostał jeszcze jeden klawisz. On demonstruje scenariusz, w którym zawartość okna okazuje się niewystarczająca i trzeba otworzyć nowe okno. Znów okno to pojawia się na sąsiednim ekranie, więc muszę je przeciągnąć do mojego obszaru roboczego. To okno posłuży mi do zademonstrowania dwóch scenariuszy. Pierwszy to, że interfejs użytkownika może zależeć od stanu, czyli od historii operacji wykonywanych wcześniej. Drugi to, że użytkownik decyduje jakie dane chce oglądać.

### Nieaktywne Kontrolki

Na nowym okienku znów mamy klawisze jako szare prostokąty, a biały prostokąt po prawej to  miejsce zarezerwowane na wyświetlania danych. Klawisze są szare ale dolny ma wyraźnie inny odcień i jak widzimy nie da się kliknąć – jest nieaktywny. Aby stał się aktywny trzeba kliknąć w górny klawisz, co symuluje na przykład scenariusz, w którym dwie operacje muszą być wykonane w sekwencji, czyli wykonanie pewnej operację dopiero twarzy sytuację warunkującą możliwość wykonanie kolejnej. Przykładowo, wcześniej trzeba wskazać plik, by można było wykonać analizę danych w nim zawartych. Oczywiście znów kłania się ergonomia, jak to uzależnienie czytelnie pokazać na ekranie.

### Zakres Wyświetlanych Danych

W tym przypadku dane są symulowane, ale w prawej części tego okienka pojawia się ich zobrazowanie w postaci drzewka, które możemy rozwijać na dowolną głębokość. To może przypominać sytuację, w której pobieramy dynamicznie z repozytorium zewnętrznego kolejne dane zgodnie z aktualnymi potrzebami użytkownika. Ten scenariusz jest szczególnie przydatny, kiedy pobranie wszystkich danych prowadzi do nieskończonej pętli w wyniku rekurencji, czyli cyklicznych odwołań, a ilość wyświetlanych danych zależy od potrzeb użytkownika.

Jeszcze raz przypomnę, że przedstawiany tu interfejs nie jest związany z konkretnymi potrzebami wybranego procesu, ale warto zapamiętać jego cechy, gdy będę do nich się odwoływał analizując tekst przykładowego programu, który go realizuje.

### Kompozycja Kontrolek

W przykładowej aplikacji widzieliśmy dwa okienka, które przed chwilą posłużyły jako repozytorium i interfejs użytkownika dla wejściowych i wyjściowych danych procesowych. Dodatkowo okienka te umożliwiały sterowanie zachowaniem się programu. Ponieważ za to wszystko odpowiedzialny jest program, czyli teks znajdźmy zatem w programie miejsca, które odpowiadają odpowiednio za grafikę, dane i zachowanie interfejsu użytkownika. W tej lekcji interesuje nas wyłącznie grafika. Danymi i zachowaniem zajmiemy się w następnej lekcji.

#### Rendering

Nie wchodząc w szczegóły w projekcie mamy folder, w którym zgromadziłem pliki odpowiedzialne za renderowanie okienek na ekranie, czyli tworzenie ich wyglądu na podstawie formalnego opisu zawartego w tekście programu. Renderowenie to spolszczone angielskie słowo rendering. Innymi słowy to cały skomplikowany proces zamiany naszego tekstu na kompozycję ekranowych pikseli. Ponieważ jest to proces powtarzalny, w większości przypadków można go całkowicie zautomatyzować i tak się dzieje od czasów pierwszych systemów klasy Windows.

#### Edycja w Blend

Wybierzmy jeden z tych plików i w menu kontekstowym widzimy, że można go edytować w Blend – co by to nie znaczyło - wybierzmy tą opcję. To chwilę trwa i w końcu wygląd naszego przykładowego okna zobaczymy w niezależnym edytorze, którego nazwa to właśnie Blend.

Korzystając z tego edytora możemy zająć się kwestią koloru wybranego fragmentu okna. Jak widzimy klikając po prawej stronie mogę wybrać dowolny kolor i co więcej spowodować, że wybrany obszar jest wypełniany tłem gradientowym co polega na wypełnieniu określonego obszaru płynnym przejściem tonalnym pomiędzy co najmniej dwoma kolorami. Kształt tego wypełnienia może być prosty lub promienisty. Więc jeśli komuś jest mało jednego koloru może zastosować wybraną paletę kilkoma kliknięciami. Tu ważne słowo to kliknięciami, bo to oznacza, że myszkę możemy przekazać komuś, kto wie jakie kolory powinny być, wracając po raz ostatni do dykteryjki – co to jest kolor amerykański. Co więcej można to zrobić nawet zdalnie w ramach mówiąc kolokwialnie confcalla, czyli zdalnej konferencji.

Troszeczkę trudniejszą sprawą jest uwypuklenie, że używamy klawiszy, czyli klikalnych miejsc na ekranie. Do tego celu wykorzystamy marginesy, które zmniejszą wielkość kliklnego obszaru na ekranie. Tu trzeba z klawiatury wprowadzić cztery liczby, więc sprawa jest trochę bardziej skomplikowań, ale wydaje się, że poradzi sobie z nią każdy bez względu na posiadaną wiedzę informatyczną. Podobnie, podkreślając ważność klawisza możemy mu zmienić kolor podobnie jak poprzednio.

Zaproponowane podejście jest rozwiązaniem całkowicie statycznym, tzn. że wybranych kolorów i kształtów nie możemy traktować jako dane procesowe. Sytuacja się całkowicie zmieni, jeśli wybór koloru ma być rezultatem procesu przetwarzania, przykładowo zmieniamy tło na odcień czerwieni, jeśli wyniki obliczeń stają się niepokojąco złe zgodnie z jakimś mierzalnym kryterium procesowym określającym poziom zła. Podobnie jeśli klawisz ma się pokazywać tylko w pewnych sytuacjach. Niesyty w takim przypadku te kolory i kształty stają się reprezentacją informacji procesowej, a więc danymi które zgodnie z pewną relacją łączącą dane z informację muszą się zmieniać. Tu musimy być świadomi, że właśnie tworzymy własny kod, z własnym alfabetem, bo dobieramy paletę kolorów i kształty kompozycji pikseli, własną składnię, bo określamy jak one mogą się zmieniać i w końcu własną semantykę, czyli jak te kompozycje pikseli rozumieć – inaczej jaką wiedzę reprezentują. O kodach było na samym początku, więc proponuję wrócić do tych lekcji jeśli jest taka potrzeba. Tu wspomniany edytor jest nadal bardzo pomocny, ale nas w prosty sposób nie zastąpi, ale to już temat osobnego kursu.

## Praca domowa

Na koniec lekcji, jak zwykle, praca domowa. Aby następna lekcja była bardziej zrozumiała proponuję zabawić się w projektanta interfejsu graficznego i z wykorzystaniem programu Blend zmodyfikować zamieszczone w programie przykłady, by dopasować je do swojego gustu i spróbować zmniejszyć niedogodności wspomniane w trakcie mojego opisu tego interfejsu. Oczywiście nie trzeba w tym celu od razu zapisywać się na studia podyplomowe w Akademii Sztuk Pięknych i Pożytecznych. Również pogłębione studia z ergonomii nie są niezbędne. Po prostu użyjmy własnej intuicji i poczucia estetyki. Celem jest wstępne określenie ograniczeń tego scenariusza metodą prób i błędów. To zadanie jest szczególnie ważne dla tych, którzy z tym podejściem nigdy w praktyce się nie spotkali.

## Zakończenie

W tej lekcji to już wszystko. Dziękuję za poświęcony czas. W następnej lekcji będę kontynuował omawianie tych zagadnień ze szczególny uwzględnieniem integracji grafiki oraz danych i zachowania się interfejsu graficznego, czyli jak go wykorzystać do monitorowania i sterowania procesu biznesowego, który automatyzujemy.

-->