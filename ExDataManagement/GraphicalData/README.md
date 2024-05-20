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

### Graphical Data as a kind of external data

This folder concerns selected issues related to the representation of process information in graphical form. It tries to answer how to build a graphical user interface. However, it must be emphasized that, following the main title, we will focus on issues related to the CSharp programming language, i.e. its syntax and semantics. Unfortunately, we cannot completely avoid **problems** related to the design environment used, so Visual Studio and employing another language, Extensible Application Markup Language, XAMLfor short. Unfortunately, learning this language is beyond the scope of the course. However, I must reassure you that knowing it is not a condition for understanding any of the issues discussed.

Let's start with a few definitions, explanations, and indications of directions for searching for new solutions to improve the handling of graphic data. Let's start with a drawing used already several times to illustrate what we would talk about. In the figure, the text of our program has been compiled, entered into memory, and has become a process managed by the computer's operating system. The operating system strongly defends the integrity of resources committed to the process. This defense measure is encapsulation. It forces to use the operating system when it is needed to exchange data with the external environment, including the computer screen.

![ProgramLayered Design Pattern](.Media/CoursImageProgramLayeredDesignPattrn.png)

The figure shows the program text as a layered structure. The reasons for the employment of layers have already been discussed. Previously, we talked about issues related to managing external data employing repositories. In general, three classes of external data have been distinguished:

- **streaming**: files, network packets
- **structural**: databases
- **graphical**: Graphical User Interface (GUI)

The external data is recognized as the data we must pull or push from outside of the process hosting the computer program.

Streams provided by the file system are one of the options that we can use as a repository. In this case, data is stored as a stream of bits, which we can transform into process data and vice versa using serialization and deserialization operations.

Another option, which we also talked about in some detail, is databases, i.e. an external structured data management system (Database Management System, DBMS for short). The purpose of a DBMS is to consistently store and archive data in compliance with a certain scheme that allows for archiving complex data and creating relationships between individual entities of this data at the same time. Data is accessed and processed by the DBMS using a certain query language.

In this chapter, the graphical representation of information is the main topic for discussion, i.e. graphical data in a form that allows communication with the user. This forces us to place our considerations in the context of broadly understood natural language, in which, as the classic statement, “A picture is worth a thousand words”. This saying suggests that visual representations can convey complex ideas or emotions more effectively than lengthy descriptions. This adage highlights the power of visual communication—a single image can represent complex ideas more effectively than lengthy descriptions.

Unfortunately, as usual, when we deal with a non-standard representation, we have to struggle with interpreting the meaning of the created image. This is often frustrating for developers because it could mean bad quality of their work when quality measures are unclear. I will cite a situation in which the team demonstrated a new application to our American partner, as an example. We were very proud of the application and the presentation went very well - we received much praise. There was only one major drawback - the colors of the profile used turned out to be un-American, even though we tried to apply those sent to us in a GIF.

So much for the theory, but how to deal with it? The information, or knowledge, represented by a certain image is read from by interpreting it. So creating graphics will require considering aesthetic impressions, which requires appealing to an undefined sense of beauty. The image must also meet the requirements of ergonomics, i.e. be adapted to the psychophysical capabilities of the user, i.e. a human being - according to Wikipedia, this requires knowledge in the field of psychology, sociology, physiology, hygiene, medicine, anthropometry, and technical sciences, e.g. machine construction. Without a doubt, a computer is a machine. Moreover, each program implements a certain algorithm, i.e. automation of a selected process. Therefore, the behavior of the screen, which becomes the dashboard controlling the course of this process, must be directly related to this process, and this requires domain knowledge related to the process.

The list of fields involved in human-machine communication included computers, and this is our stuff, to put it colloquially. The image on its screen must be the result of our program. A program is a text created by a programmer, and a programmer is not a superman who know everything I have just mentioned, especially which colors are American, so let me return to the real-life scenario I mentioned earlier.

This is our first **problem**: involving other specialists, including but not limited to direct users, in the GUI design process. Let's go back to the national colors anecdote again, if we don't know what the American color means, let's give our friend from overseas a chance to prove herself. But let's not exaggerate and do not require technical knowledge from her, especially knowledge of a programming language.

### GUI as a tree containing controls as nodes

An image is a composition of colored pixels. They must be composed in such a way as to represent selected process information, i.e. its state or behavior. Similarly to the case of data in memory, which we process without directly referring to their binary representation, we do not create a GUI by laboriously assembling pixels into a coherent composition. Moreover, as I mentioned earlier, the GUI is a dashboard controlling the process, so it must also behave dynamically, including enabling data entry and issuing commands.

An image is a composition of colored pixels. They must be composed in such a way as to represent selected process information, i.e. its state or behavior. Similarly to the case of data in memory, which we process without directly referring to their binary representation, we do not create a GUI by laboriously assembling pixels into a coherent composition. Moreover, as I mentioned earlier, the GUI is a dashboard controlling the process, so it must also behave dynamically, including enabling data entry and issuing commands.

The next **problem** is how to ensure the appropriate level of abstraction, i.e. how to hide the details related to the creation of an image on the screen. Let's introduce two concepts here: control and rendering. Hiding details always leads to coming to terms with the fact that something is happening beyond our control. We've seen this while generating SQL queries from LINQ expressions. As with LINQ, we need to use a specific technology to express our considerations in a practical practical context backed by examples. I chose Windows Presentation Foundation (the more familiar-sounding abbreviation WPF), but I will try not to lose the generality of the discussion. A discussion of WPF requires a separate course, and we will stay as close as possible to issues related to the practice of using the CSharp language.

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

## Jaki mamy problem

### Wstęp

### Informacja

### GUI jako drzewo kontrolek

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