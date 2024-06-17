<!--
//________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_________________________________________________________________________________________________________________________
-->

# MVVM Programming Design Pattern <!-- omit in toc -->

## Table of content <!-- omit in toc -->

- [1. Introduction](#1-introduction)
- [2. What's our problem?](#2-whats-our-problem)
  - [2.1. Image manipulation](#21-image-manipulation)
  - [2.2. Layered Model](#22-layered-model)
  - [2.3. Dependency injection](#23-dependency-injection)
- [3. Dynamically Modification of Image Features](#3-dynamically-modification-of-image-features)
  - [3.1. Introduction](#31-introduction)
  - [3.2. Control Visibility](#32-control-visibility)
  - [3.3. Modification of other features](#33-modification-of-other-features)
  - [3.4. Limited Role of Code-behind](#34-limited-role-of-code-behind)

## 1. Introduction

We continue discussing selected issues related to the engineering of creating a graphical user interface - GUI for short. Previously, we discussed general design requirements and software mechanisms for creating a GUI. Now I will try to answer the question of how to animate the interface image.

In the case of graphic data, a window is a self-contained graphical unit created by the program and managed by the operating system. Managed means moving, enlarging, reducing, etc. This, of course, is not surprising since the development of the first Windows operating system, in which the window is the basis for human-machine communication.

The program can, of course, use several windows, as well as several databases or several files. In all cases, we can talk about an independent external data repository. In the case of Windows, however, we must consider an important difference, namely the interaction is two-way. In the case of databases, we can also expect the need to consider dynamic data change, but only in the case of Windows, we must respond to user commands.

So let's see how to deal with these problems.

## 2. What's our problem?

Traditionally - to introduce elementary order - let's start by defining the most important problems and indicating directions for further search for solutions regarding application architecture in the context of communication with the user using the MVVM pattern that stands for model, view, view-mode.

### 2.1. Image manipulation

Manipulating an image, i.e. changing its features, such as color and appearance, is the first task at the edge between the program and the graphical representation of data. Here we will return to the XAML language with the question of where to dynamically modify image features. The image is described in a new language not created to implement an operating algorithm, i.e. business logic. On the other hand, this language uses the types defined in CSharp, so the point of contact is only how to use it.

### 2.2. Layered Model

should have a layered architecture. Layered architecture means that one layer may be recognized as upper and a second one as a lower one although there are usually more layers. So that we can distinguish which one is higher. To achieve this only the upper layer may refer to the underneath layer. In contrast, the lower layer must be composed in such a way that it doesn't depend on the upper layer. hence, the inter-layer reference must be unidirectional, often called hierarchical.

The program should have a layered structure - it's easy to say, but what is a layer? The program is text and has a stream structure instead - it is a sequence of characters. Of course, in this principle the concept of a layer is abstract, but to say that the program architecture is layered, we must somehow implement this concept so that everyone knows what a layer is. We will learn a specific implementation called MVVM which stands for model, view, and view-model.

### 2.3. Dependency injection

It is not difficult to imagine a scenario in which, when performing a certain operation in the Logic layer, we need additional information from the user, for example, a file name. Obtaining this information requires communication with the user, which means engaging the Presentation layer and displaying a pop-up window. However, the Logic layer should be constructed so that it is not aware of the existence of the Presentation layer, because it is above it. In this scenario, we will look for help in the Dependency Injection programming pattern. Those who have already heard something about this pattern may feel anxious that it is not another point in the discussion, but an introduction to a completely new discussion. The concerns are justified, because many publications have already been written on this topic, and many frameworks and derivative terms have been created. An example is Inversion of Control. Without getting into academic disputes and deciding whether these publications and solutions concern perse dependency injection or rather the automation of dependency injection, we will try to solve the problem and separate the layers to avoid cyclical references between them, i.e. recursion in the architecture.

## 3. Dynamically Modification of Image Features

### 3.1. Introduction

Let's start by determining how we can bring the content of the interface to "make it alive". The phrase "make it alive" is a colloquialism that means **dynamically modifying image features**, editing data through it, and responding to user commands. In other words, the task is as follows: interconnecting the previously generated GUI image with the process data.

The basic solution that we already know is showing on the screen a Window. The primary Window is opened by the environment. However, in this project, we have one more window that appears after clicking one of the keys. Without going into details, let's assume that clicking a key causes some hard work to be performed in the background - for example, a file is being read and analyzed - and as a result, another window is displayed - a typical pop-up, if everything goes well. This means that the View layer is responsible for what the window should look like. However, in the ViewModel layer underneath, we must decide when it should be exposed on the screen. It is worth recalling here that a window is a class that inherits from the Window class and for the window to appear, you need to call the `Show` method, which we can see in the Window class definition preview.

The basic solution that we already know is showing on the screen a Window. The primary Window is opened by the environment. However, in this project, we have one more window that appears after clicking one of the keys. Without going into details, let's assume that clicking a key causes some hard work to be performed in the background - for example, a file is being read and analyzed - and as a result, another window is displayed - a typical pop-up, if everything goes well. This means that the View layer is responsible for what the window should look like. However, in the ViewModel layer underneath, we must decide when it should be exposed on the screen. It is worth recalling here that a window is a class that inherits from the Window class and for the window to appear, you need to call the `Show` method, which we can see in the Window class definition preview.

### 3.2. Control Visibility

> _**ChatGPT**_: The `Control` class is a part of the inheritance chain for control types. The `Control` class is a base class for most of the user interface elements. It provides common functionality that all controls share, such as styling, layout, and input handling. So, when you create a new control type like these controls inherit from the `Control` class and therefore gain all the properties, methods, and events defined in the `Control` class. A `UserControl` is a customizable control that allows you to combine existing controls and add custom logic to create a reusable user interface component. It's useful for encapsulating complex UI parts that you can use across different parts of your program.

Looking at the content of the definition of this class written in XAML, we see that the displayed controls create a tree structure, i.e. the references of internal controls, for example, `TreeView`, are added to the collection of external objects. The containment hierarchy is determined by the structure of the XML file. Theoretically, by manipulating the contents of these collections by adding and removing elements from them, you can influence the content of the window. Since this is quite an unusual procedure and this functionality can be easily replaced, we will not analyze this approach further, it is simply a waste of time.

Instead of adding controls to the parent control's collection, we can use the Visibility property. It takes one of the three values ​​that we see on the screen. Therefore, a practical tip is to add all the controls that may appear on the screen at the stage of designing a static image and then dynamically change this property as needed.

Sometimes the controls may be visible on the screen but in static mode. An example of such a mode is an inactive key, i.e. one that is visible on the screen but cannot be clicked and therefore issue an appropriate command. Another property, this time called IsEnabled, can be used for this purpose. I'm changing it statically here, but in reality, it has to be done dynamically depending on the state the process is in. It is worth mentioning here that the XAML language allows you to define the GUI as a state machine and control its appearance depending on the state the interface is in. This allows us to group controls and control them by changing the state of the entire part of the user interface, not just by changing individual properties of the controls. Since our goal here and now is not to learn the XAML language, I refer anyone interested in learning this mechanism in detail and the XAML language in general to other materials dedicated to this topic.

### 3.3. Modification of other features

Similarly, by modifying the values ​​of various properties, we change other features of the controls, such as color, shape, filling method, etc. There are many of them, so the previously learned Blend editor may be useful in this respect.

What to modify to revitalize the interface is the first important question. But now we come to the second question, namely where to make modifications. Of course, there are several answers to this question, and let's now try to analyze them and make some general practical recommendations.

We already know the first answer to the question of where to modify, that place is, of course, the XAML text. Modification in XAML has the disadvantage that it is essentially limited to constant substitution. It should be emphasized here that default values ​​are already substituted for each property defined by the controls, so there is no need to modify anything for typical behavior. An example is Visibility, whose default value is of course Visible. Of course, this language allows us to assign not only constants but its use to implement algorithms not directly related to GUI control is not a good idea.

### 3.4. Limited Role of Code-behind

The XAML text and its associated CSharp text, called code behind, form one class (one definition) because they are partial definitions. Of course, all properties can therefore be modified in the code behind. However, this solution has several drawbacks. Let's narrow the discussion only to the following three that can be recognized as excluding this approach.


<!--
# Wzorzec MVVM

  - [Dynamiczne Modyfikowanie Cech obrazka](#dynamiczne-modyfikowanie-cech-obrazka)
    - [Ograniczona Rola Code-behind](#ograniczona-rola-code-behind)
    - [Code behind - dependency injection (Binding)](#code-behind---dependency-injection-binding)
  - [Obsługa widoku poprzez powiązania](#obsługa-widoku-poprzez-powiązania)
    - [Sprzęganie kontrolek z danymi](#sprzęganie-kontrolek-z-danymi)
    - [DataContext](#datacontext)
    - [Binding](#binding)
    - [DataBinding – użycie refleksji](#databinding--użycie-refleksji)
    - [INotifyPropertyChange](#inotifypropertychange)
    - [ICommand](#icommand)
    - [RelayCommand](#relaycommand)
  - [Model warstwowy](#model-warstwowy)
    - [Model Warstwowy Wprowadzenie](#model-warstwowy-wprowadzenie)
    - [Czy projekt może być warstwą](#czy-projekt-może-być-warstwą)
    - [MVVM jako podwarstwy warstwa prezentacji](#mvvm-jako-podwarstwy-warstwa-prezentacji)
    - [Diagram View](#diagram-view)
    - [Porządkowanie diagramu](#porządkowanie-diagramu)
    - [Jak Zaimplementować](#jak-zaimplementować)
    - [Implementacja warstw ogólnej architektury programu](#implementacja-warstw-ogólnej-architektury-programu)
    - [Powody Wprowadzenia Warstw](#powody-wprowadzenia-warstw)
    - [Wstrzykiwanie zależności View](#wstrzykiwanie-zależności-view)
  - [Praca domowa](#praca-domowa)
    - [Refleksja](#refleksja)
    - [Wstrzykiwanie zaleznosci](#wstrzykiwanie-zaleznosci)
    - [Diagram kontroli zależności](#diagram-kontroli-zależności)
  - [Zakończenie](#zakończenie)

## Dynamiczne Modyfikowanie Cech obrazka

### Ograniczona Rola Code-behind

👉🏻 Pierwsza wada związana jest z ewidentnym złamaniem w takim przypadku zasady **separation of concerns**. W bardzo wolnym tłumaczeniu ta zasada znaczy unikanie konieczności wykorzystania podzielności uwagi, a w istocie zachęca do koncentrowania się wyłącznie na pojedynczych dobrze odseparowanych zagadnieniach. Ma to związek z psychologią i stwierdzonymi ułomnościami przebiegu naszych procesów myślowych, jeśli rozwiązujemy problem wielowątkowy. W naszym przypadku jeśli pracujemy nad GUI, to nie pracujmy jednocześnie nad automatyzacją procesu, czyli implementacją algorytmów przetwarzania danych procesowych. Skoncentrujmy się wyłącznie na komunikacji człowiek maszyna.

Jest jeszcze jedna bardzo wymierna wada, a mianowicie jednym z popularnych sposobów sprawdzania poprawności programu jest zastosowanie **testów jednostkowych**. Oprócz testowania poprawności są one również szczególnie przydatne do sprawdzenia, czy w tekście programu nie zostały wprowadzone istotne modyfikacje, które mogą mieć efekt uboczny i wymagać uwzględnienia w innych częściach programu. Ja dodatkowo i trochę nietypowo używam testów w przykładach do kursu tak, aby  pokazać wybrane cechy omawianych rozwiązań. Testy jednostkowe mają tę wadę, że nie mają wsparcia dla graficznego interfejsu użytkownika. By je można było stosować w możliwie szerokim zakresie,  dane i funkcjonalność tego interfejsu powinny być odseparowane tak, by można było dla nich utworzyć niezależne testy jednostkowe bez konieczności uruchamiania renderingu grafiki. W naszym przykładzie ten podział zrealizowałem poprzez umieszczenie sterowania grafiką w osobnym projekcie, który w nazwie ma przyrostek View.

Kolejna wada jest równie wymierna. W projekcie dedykowanym dla GUI widzimy twardą zależność, czyli referencję do **PresentationFramework**. To uniemożliwia używanie generowanych tu rezultatów na systemach operacyjnych innych niż Microsoft Windows. Więc program staje się nieprzenośny. Umieszczenie tu tekstu nie związanego bezpośrednio ze sterowaniem grafiką łamie kolejną zasadę inżynierii programowania, a mianowicie reusability, więc znowu w wolnym tłumaczeniu oznacza to możliwość ponownego wykorzystania tekstu - w tym przypadku dla innej technologii GUI. Możliwość ponownego wykorzystania, to już bezpośrednie przełożenie na pieniądze, bo w przypadku braku przenośności podobny tekst programu trzeba jeszcze raz napisać, a co gorsza później go utrzymać.

Podsumowując, umieszczenie tekstu programu implementującego jakiekolwiek działania związane z przetwarzaniem danych procesowych w code-behind, a więc w tej części programu, łamie zasadę separation of concerns, ogranicza możliwość korzystania z testów jednostkowych i ogranicza przenośność rozwiązania. To uwagi limitujące i prowadzą do wniosku – nie róbmy tego, to nie jest dobry pomysł.

### Code behind - dependency injection (Binding)

A co z tym fragmentem tekstu. Czy przypadkiem sam sobie nie zaprzeczam. To tego jeszcze wrócę, na razie proszę przyjąć na wiarę odpowiedź, że to jest zgodnie z zaleceniami, a ten tekst teoretycznie można usunąć, ale to nie takie proste.

Skoro miejscem ożywienia interfejsu użytkownika nie powinien być XAML i code-behind to muszą być inne części programu. Tu niestety napotykamy na barierę związaną z kontrolą zgodności typów. A mianowicie, żeby kontrolować zgodność typów, to najpierw te typy trzeba znać. Skoro projekty technologicznie nie związane z GUI mają być niezależne, jak to jest w naszym przypadku dla projektu `GraphicalData`, nie mogą znać tych typów, bo staną się zależne od technologii i cały misterny plan spali na panewce.

Jak przeciąć ten węzeł gordyjski? Do tej pory dyskusja była reaktywna, mianowicie kończyła się stwierdzeniem czego nie możemy zrobić. Jak się możemy domyślać, rozwiązaniem jest oczywiście kompromis. W ramach kompromisu - po pierwsze - ograniczymy role kontrolek, które tworzą warstwę View do roli pośrednika przekazującego dane pomiędzy użytkownikami interfejsu i warstwami leżącymi poniżej tej warstwy. Do kwestii warstw jeszcze wrócimy w dalszej części lekcji, więc dla uproszczenia tu warstwę View możemy traktować, jako osobny projekt. Wracając do roli pośrednika, ta rola pośrednika ogranicza się do kolokwialnie mówiąc przezroczystego kopiowania danych z i na ekran. W szczególnych przypadkach w ramach tego kopiowania możemy przewidzieć operację konwersji, np. format daty w zależności od języka naturalnego używanego przez użytkownika interfejsu. Dodatkowo interfejs GUI musi być odpowiedzialny za uruchamianie odpowiedniej funkcjonalności w reakcji na polecenia użytkownika.

Funkcjonalność do scenariusza, w którym XAML jest tylko przezroczystym przekaźnikiem danych została zaimplementowana w technologii WPF. Żeby przekazywać dane, to najpierw trzeba je pobrać z jakiegoś źródła. Tu nie mamy wielkiego wyboru, to muszą być obiekty, a właściwie ich właściwości – properties – opisane typami. Ponieważ te typy muszą już być związane z przetwarzaniem danych procesowych, więc ich definicja jest dedykowana do potrzeb tego procesu, więc nasza i znajduje się w projekcie GraphicalData do którego projekt zawierający View ma referencje. Jednak Microsoft implementując WPF – a konkretnie mechanizm kopiowania - tych typów nie mógł znać. Transfer danych w WPF jest mechanizmem generycznym, więc nie może odwoływać się do konkretnych typów, mimo, że może mieć referencje do tych typów. To prowadzi do wniosku, że nie możemy w tym procesie korzystać z definicji typów, więc cóż zostaje tylko refleksja, co nas nie specjalnie powinno zmartwić, bo to nie my musimy jej używać, a w konsekwencji jej znać.

## Obsługa widoku poprzez powiązania

### Sprzęganie kontrolek z danymi

Popatrzmy na przykład. W prawym dolnym rogu okienka używamy kontrolki typu TextBox. Jej zadaniem jest wypisywać i ewentualnie czytać tekst, czyli ciąg znaków. Aktualna wartość, więc to co jest na ekranie jest dostępne za pośrednictwem właściwości Text. Ponieważ oczekujemy czytania i pisania więc znak równości za nazwą Text musi oznaczać transferuj aktualną wartość do/z wybranego miejsca. Wiemy już, że tym wybranym miejscem musi być właściwość jakiegoś obiektu. Słowo `Binding` możemy przetłumaczyć na powiąż, więc prawdopodobnie ActionText jest to właściwość zdefiniowana w jakimś naszym typie. Spróbujmy ten typ znaleźć korzystając z nawigacji w menu kontekstowym Visual Studio. Jak widzimy to działa i właściwość ma faktycznie nazwę zgodną z oczekiwaniami.

### DataContext

Jak widać nawigacja działa, czyli VisualStudio nie ma wątpliwości z jakiego typu pochodzi ta właściwość. Skoro Visual Studio to wie, to chyba my też powinniśmy wiedzieć. Odpowiedź na to pytanie znajduje się w tych trzech linijkach tekstu. Zacznijmy od środkowej, w której mamy pełną nazwę klasy z tym, że przestrzeń nazw została zastąpiona przez dwuliterowy alias vm zdefiniowany zresztą kilka linijek wyżej. Niestety tym razem nawigacja do definicji nie działa, ale definicja klasy jest otwarta w wyniku wcześniejszego poszukiwania właściwości zawierającej tekst do kontrolki TextBox. Zastanówmy się co oznacza nazwa klasy w tym miejscu. Aby uprościć sprawę, najpierw poszukajmy znaczenia identyfikatora DataContext. Jest to właściwość typu object, więc typu bazowego dla wszystkich typów. Skoro właściwość to możemy tylko odczytać lub podstawić do niej jakąś wartość. Odrzuciwszy wszystkie absurdalne propozycje, łatwo wydedukować jedyną poprawna odpowiedź, a mianowicie, że identyfikator MainViewModel w tym miejscu oznacza konstruktor bezparametrowy, a cały ten fragment należy rozumieć jako ekwiwalent instrukcji podstawienia do właściwości DataContext nowo utworzonego z wykorzystaniem tego konstruktora obiektu. Obiekt ten możemy uważać jednocześnie za źródło i repozytorium danych procesowych dedykowanych dla GUI, innymi słowy to rodzaj repliki GUI. Z punktu widzenia danych tworzy on rodzaj repliki tego co jest na ekranie.

### Binding

Wróćmy jeszcze do poprzedniego przykładu z kontrolką TextBox i sprzężenia jej właściwości Text z właściwością ActionText pochodzącą z klasy, której obiekt został podstawiony do DataContext. Występuje tu magiczne słowo `Binding`, które możemy przetłumaczyć transferuj wartość pomiędzy. Na pytanie jak to się dzieje i co oznacza słowo `Binding`, czyli na pytanie o semantykę tego zapisu zwykle otrzymuję odpowiedz: to jakaś magia kina, co należy czytać wewnętrzna implementacja WPF, a `Binding` to słowo kluczowe języka XAML. I to tłumaczenie byłoby wystarczające, choć jest to kolokwializm, gdyby nie fakt, że musimy zrozumieć, kiedy ten transfer ma miejsce. Odpowiedź na to pytanie jest fundamentalna do zrozumienia wymagań dla klas, które mogą być wykorzystane do utworzenia obiektu, którego referencja jest podstawiana do właściwości `DataContext`. Aby znaleźć odpowiedź spróbujmy przejść do definicji tego słowa używając menu kontekstowego lub klawisza F12.

### DataBinding – użycie refleksji

Okazuje się, że `Binding` jest identyfikatorem klasy, a właściwie bezparametrowego konstruktora tej klasy. To w konsekwencji musi oznaczać, że w tym miejscu magia kina oznacza utworzenie obiektu typu Binding, który odpowiada za transfer wartości z jednej właściwości do drugiej. Właściwości zdefiniowane w tym  typie pozwalają na sterowanie sposobem realizacji tego transferu. Tu możemy zobaczyć ich listę. Ponieważ obiekt ten musi operować na nieznanych typach wykorzystywana jest refleksja. To powoduje, że mechanizm ten rzadko jest analizowany w szczegółach i kolokwialne tłumaczenie poprzednio przytoczone, że transfer jest jakoś realizowany jest dość powszechne, bo ma swoje zalety w kontekście opisu skutku. W ramach pracy domowej proponuję stworzyć definicję klasy, która zasymiluje to działanie i dostarczy funkcjonalność podstawiania wybranej wartości do wskazanej właściwości obiektu, którego typ nie jest znany.

### INotifyPropertyChange

Jak wspomniałem wcześniej używając właściwości zdefiniowanych w typie `Binding` możemy parametryzować przebieg transferu i na przykład ograniczyć jego kierunek. Operacje, które są opisane tekstem XAML są realizowane jednorazowo na początku programu, kiedy obiekt MainWindow jest tworzony. Nie możemy zatem określić tu chwil czasowych, w których ten transfer powinien być realizowany. Aby określić te chwile czasowe, w której obiekt typu Binding powinien dokonać tego transferu prześledźmy budowę właściwości ActionText pochodzącej z naszego typu. Tu widzimy, że seter oprócz podstawienia wartości do lokalnego pola wykonuje dwie metody. W kontekście postawionego problemu dla nas istotne jest wywołanie metody RaisePropertyChanged. Metoda ta aktywuje zdarzenie - event, który jest wymagany do zaimplementowania interfejsu INotifyPropertyChanged. Właśnie to zdarzenie wykorzystywane jest przez obiekty klasy Binding do rozpoczęcia transferu wartości. Aktywując to zdarzenie wywołujemy metody zwane handlerami, których delegaty zostały zasubskrybowane do zdarzenia, czyli to my dokonujemy pośrednio tego transferu za pośrednictwem tych handlerów. Jeśli klasa nie implementuje tego interfejsu lub jeśli taka aktywacja zdarzenia PropertyChanged wymaganego przez wspomniany interfejs nie nastąpi, nowa wartość nie zostanie przekazana i nie będzie wyświetlona na ekranie – ekran będzie statyczny.

### ICommand

Analiza poprzednich przykładów pokazuje działanie mechanizmu synchronizacji zawartości ekranu z wartościami właściwości klas dedykowanych do udostępniania danych na potrzeby GUI, które tworzą rodzaj pamięciowej repliki ekranu. Teraz musimy jeszcze tylko wyjaśnić sekwencję operacji realizowanych w konsekwencji wydania polecenia przez użytkownika interfejsu, np. kliknięcia na klawisz ekranowy - `Button`. Przykład mamy tu, a jego właściwość `Command` została podobnie jak poprzednio skojarzona z czymś o identyfikatorze `ShowTreeViewMainWindowCommend`. Korzystając z nawigacji w Visual Studio możemy przejść do definicji tego identyfikatora i zauważamy, że jest to znowu właściwość z naszej klasy, ale tym razem typu `ICommand`. Tym razem to powiązanie nie służy to kopiowania wartości właściwości, tylko do zamiany kliknięcia klawisza na ekranie, np. z wykorzystaniem myszki, na wywołanie operacji `Execute`, która jest zdefiniowana w interfejsie `ICommand` i zatem musi być zaimplementowana w klasie, która służy do utworzenia obiektu i podstawienia referencji do niego do tej właściwości.

### RelayCommand

Dla ułatwienia ten interfejs został zaimplementowany przez klasę pomocniczą o nazwie `RelayCommand`. W konstruktorze tej klasy należy umieścić delegację do metody, która ma być wywołana w wyniku realizacji polecenia. W ramach pracy domowej proszę prześledzić zastosowanie drugiego konstruktora. Ten konstruktor jest pomocny w dynamicznej zmianie stanu aktywności klawisza. Można to wykorzystać, aby uwzględnić zdarzenia przeszłe do ewentualnego blokowania zdarzeń przyszłych, czyli zrealizować maszynę stanu. I właśnie taki scenariusz w przykładowym programie został zaimplementowany. Proszę zwrócić tu uwagę na pominiętą w poprzedniej analizie metodę  `RaiseCanExecuteChanged`.

## Model warstwowy

### Model Warstwowy Wprowadzenie

Kolejnym tematem tej lekcji jest **warstwowy model** architektoniczny nazwany mvvm. Ten skrót pochodzi od angielskiego model, view, view-model, czyli model, widok i model widoku. Zgodnie z dobrymi praktykami inżynierii program powinien być skonstruowany z wykorzystaniem warstw. Warstwa to pojęcie abstrakcyjne i charakteryzuje się tym, że w takim modelu warstwy wyższe odwołują się wyłącznie do warstwy sąsiedniej leżącej poniżej.

Innymi słowy będziemy mówić o architekturze programu. Tu niestety często spotykam się z praktyką lekceważenia zasad warstwowej budowy programu, bo to komplikuje, bo to ogranicza, bo bez tego jest łatwiej i da się żyć, itd. Zauważmy, że mamy tu trzy istotnie różniące się światy. Pierwszy to model wymieniony w temacie, czyli mvvm. Oznak jego bytności jeszcze nie widzimy, ale pojawił się on w kontekście inżynierii tworzenia graficznego interfejsu użytkownika. Drugi, to model wielokrotnie używany w trakcie kursu, w którym wyróżniono też trzy warstwy, ale tym razem nazwane prezentacja, logika i dane. Trzeci świat, to całkowity brak warstw. Skoro te światy istnieją, to pewnie za każdym z nich stoją jakieś powody, choćby błahe, jak brak wiedzy. Żeby wykluczyć brak wiedzy, przyjrzyjmy się temu tematowi z bliska.

Zacznijmy od tego, że nasz program przykładowy ma dwa projekty. Pierwszy z przyrostkiem View bazuje na Framework 4.61, więc jest dedykowany dla konkretnej implementacji biblioteki .NET. To ogranicza pole manewru w zakresie jego wykorzystania na innych platformach sprzętowych i systemowych, ale wyjścia nie ma, bo WPF jest technologią dedykowaną dla Windows. Drugi projekt bazuje na .NET Standard. .NET Standard jest abstrakcyjną definicją biblioteki .NET, tzn. nie zawiera żądnej implementacji, a jedynie abstrakcyjne definicje. Dziki temu projekty bazujące na .NET standard są przenośne i raz skompilowana biblioteka może być realizowana na każdej platformie systemowej, dla której istnieje implementacja .NET. Nie wchodząc w szczegóły, zależność pomiędzy tymi projektami możemy zilustrować w następujący sposób. Dla dociekliwych co oznaczają poszczególne strzałki jest legenda. Na potrzeby tej lekcji nas będzie interesował tylko zwrot tych strzałek.

### Czy projekt może być warstwą

Odpowiadając na pytanie co to jest warstwa, spróbujmy zatem postawić tezę, że warstwy powinny być zaimplementowane z wykorzystaniem projektów. Zauważmy, że w poprzedniej lekcji używałem tego samego programu przykładowego, ale wszystko było w jednym projekcie i działało. Generalnie minimalizowanie liczby projektów prowadzi do zmniejszenia kosztów utrzymania, więc jeśli przenośność nie jest wartością dodaną, to może nie warto wydzielać na siłę osobnych projektów. Tu jednak ćwiczymy scenariusz, w który przenośność jest krytyczna, więc rozdzielenie projektu na dwa jest konieczne. Wydzielenie części programu do  osobnego projektu - z punktu widzenia jego semantyki, więc działania - nic nie zmieniło. Tu trzeba podkreślić, że projekt to tylko jednostka organizacyjna w ramach solution. Solution, czyli rozwiązanie i projekt to pojęcie związane z narzędziem jakim jest Visual Studio, a nie z semantyką programu. Tak, czy inaczej używanie projektów do implementacji warstw to nie jest dobry pomysł. Tu jednak ważne zastrzeżenie, tylko dzięki odpowiedniej architekturze programu wydzielenie jego fragmentu do osobnego projektu nie było trudne. Natomiast warunkiem koniecznym, aby ten proces w ogóle był możliwy jest, aby referencje, czyli odwołania do definicji typów były wyłącznie hierarchiczne, ponieważ tylko takie można zdefiniować dla projektów. Z rysunku oraz z gałęzi references i Depencies widać, że w tym przypadku jest to spełnione.

### MVVM jako podwarstwy warstwa prezentacji

Omawiany wzorzec mvvm powstał jako integralna część technologii Windows Presentation Foundation, więc skoro w nazwie mamy słowo presentation, to w kontekście ogólnej architektury, możemy przyjąć, że warstwy modelu mvvm są podwarstwami warstwy prezentacji tego ogólnego modelu architektonicznego. Na podstawie tej analizy szczegółowej spróbujmy jednak odpowiedzieć na bardziej ogólne pytanie: co to jest warstwa i jak ją zaimplementować.

### Diagram View

Analizę realizacji tego wzorca i implementacji warstw model, view, View-Model rozpocznijmy od wygenerowania diagramu pokazującego różne związki występujące w tekście przykładowego programu. Rozpoczynamy od projektu zawierającego tekst opisujący grafikę interfejsu, a więc warstwę View, czyli widok. Przypomnę, że zastała ona zaimplementowana w osobnym projekcie grupującym wszelkie odwołania do technologii WPF, a więc do pewnej grupy typów, których definicja jest osadzona w ściśle określonych realia zewnętrznych w tym przypadku systemu operacyjnego. Wcześniej podobne uzależnienie dotyczyło baz danych, gdzie w trakcie jednej z lekcji wykorzystaliśmy technologię LINQ to SQL dedykowaną dla konkretnego rodzaju baz danych. Na rysunku mamy trzy elementy składowe Folder rozwiązania, projekt i po rozwinięci projektu jego przestrzenie nazw. Umieśćmy na tym rysunku również projekt zawierający tekst pozostałej części programu i rozwińmy go by pokazać jego zawartość. Wracając do implementacji warstwy. W programie, aby abstrakcyjna warstwa była zaimplementowana, musimy wykorzystywać jakąś konstrukcję językową, którą do tego wykorzystamy. Innymi słowy program jest tekstem, więc warstwa musi być jednoznacznie wydzielonym fragmentem tego teksu.

### Porządkowanie diagramu

Przestrzeń nazw jest konstrukcją językową i zawiera wybraną grupę definicji typów, więc wygląda na dobrego kandydata do implementacji warstw. Łatwo jest również wydzielić tekst w ramach wybranej przestrzeni nazw. Zatem korzystając z filtrów usuńmy z diagramu wszystkie elementy organizacyjne związane z narzędziem, a nie ze składnią i semantyką programu. W tym przypadku to jest folder i projekty. Po uporządkowaniu diagramu widzimy, że w tym przypadku warstwy zostały zaimplementowane jako przestrzenie nazw. W ramach przestrzeni nazw tworzących warstwy mogą występować dodatkowe przestrzenie składowe, w których znajdują się definicje typów pomocniczych i tak wewnątrz przestrzeni MVVMLight zdefiniowałem dwie klasy pomocnicze ułatwiające implementację i kontrolę poprawnego wykorzystania tego wzorca i dostarczające potrzebną dla warstwy View-Model funkcjonalność, więc implementację dwóch interfejsów, a mianowicie INotifyPropertyChange i ICommand. Po uporządkowaniu możemy te trzy warstwy wyróżnić.

### Jak Zaimplementować

Korzystając z tego przykładu spróbujmy teraz zdefiniować kilka uproszczonych reguł, których zastosowanie ułatwi implementację wzorca mvvm. Po pierwsze w przestrzeni nazw View należy zgromadzić wyłącznie definicje, które odwołują się do typów zdefiniowanych w PresentationFramework. Dodatkowo te definicje mogą odwoływać się wyłącznie to typów zdefiniowanych w przestrzeni ViewModel. W skrócie tu umieszczamy praktycznie wyłącznie tekst zapisany w języku zaml i puste definicje w code-behind. W przestrzeni ViewModel natomiast definiujemy wszystkie typy, których obiekty podstawiane są do właściwości DataContex wybranych kontrolek. Ucieszenie tu definicji typów pomocniczych pozwalających sprostać wymaganiom stawianym dla tej warstwy jest już opcjonalnie. Z uwagi na uniwersalny charakter tych implementacji często korzystamy tu z zewnętrznych bibliotek. W uproszczeniu warstwa Model to cała reszta. Podkreślę tu jeszcze raz, że mvvm to wzorzec, więc zasady sprzęgania warstw i podział na same warstwy, natomiast całość dotyczy wyłącznie warstwy Prezentacji ogólnej architektury programu.

### Implementacja warstw ogólnej architektury programu

Postępując podobnie w osobnych przestrzeniach nazw możemy gromadzić typy tak, by zachować wyłącznie hierarchiczne odwołania pomiędzy nimi. Zatem błędem krytycznym dla architektury warstwowej jest, jeśli pomiędzy przestrzeniami nazw wystąpią cykliczne odwołania, czyli jeśli rozpoczynając od dowolnej warstwy i poruszając się wydłuż strzałek zależności uda się wrócić do tej samej przestrzeni nazw. Należy również unikać sytuacji, w której przestrzenie nazw nie odwołują się wyłącznie do swoich poniższych sąsiadów. Implementując warstwy z wykorzystaniem przestrzeni nazw musimy natomiast liczyć się z problemem, że tych warstw nie widać w rozwiązaniu gołym okiem. Wydaje się, że kompromisem jest utrzymywanie nazw folderów i przestrzeni nazw w synchronizacji. Związek jest luźny, ale tworząc nową klasę w wybranym folderze jest ona dodawana do przestrzeni nazw, której identyfikator jest utworzony jako hierarchiczne połączenie nazwy domyślnej, nazw folderów tworzących hierarchię i z przyrostkiem określonym przez nazwę końcowego w hierarchii folderu.

### Powody Wprowadzenia Warstw

Na koniec podsumujmy co dostaliśmy w zamian architektury warstwowej. Odseparowanie warstw pozwala na prowadzanie niezależnie prac projektowych. Oczywiście pod warunkiem, że API, czyli interfejs warstwy jest niezmienny. Można to wykorzystać to prowadzenia prac nad GUI i logiką obsługi interfejsu użytkownika równolegle. Korzyści są dwie, możemy zatrudnić specjalistów i skrócić czas opracowywania produktu. Brak odwołań cyklicznych pozwala natomiast lepiej zaplanować ewentualne modyfikacje i zapanować nad efektami ubocznym. W ten sposób można zmniejszyć koszty utrzymania. Często architektura hierarchiczna zestawiana jest w kontrze do architektury typu spaghetti, o ile spaghetti można w ogóle nazwać architekturą. W przykładzie pokazałem jak dzięki warstwom można uniezależnić się od technologii, więc zapewnić możliwość przenoszenia wyników pracy pomiędzy różnymi platformami. Poprawę wydajności procesu projektowania zapewnimy dzięki zastosowaniu zasady separation of concerns, czyli dobre zaplanowanie warstw pozwoli uniknąć rozpraszania się na rozwiązywanie jednocześnie kilku wątków. Warstwy nie tylko mogą być wydzielane do odrębnych projektów, ale realizowane na innych fizycznych maszynach. Przekładem jest farma serwerów WWW stanowiąca front–end dla całego systemu informatycznego, np. Google, Gmail, itp. Jeśli tę samą warstwę będziemy potrafili realizować równolegle na wielu komputerach - jak w tych przykładach - to zapewnimy skalowalność poziomą - horyzontalną. Możliwość realizacji poszczególnych warstw na niezależnych platformach sprzętowych to skalowalność pionowa (wertykalna).

### Wstrzykiwanie zależności View

Jeżeli aplikacja ma być zbudowana zgodnie z modelem MVVM, to tylko w warstwie widoku – view będziemy decydowali o tym jak ma wyglądać okienko. Natomiast w warstwie poniżej będziemy decydować o konieczności jego wyświetlenia. Wyświetlenie kolejnego okienka często nazywanego pop-up jest wynikiem kliknięcia na klawisz okna podstawowego, które to zdarzenie jest obsługiwane w warstwie modelu widoku, która u nas jest w osobnym projekcie. Przypomnę, że okienko to obiekt o jakimś typie. W tym scenariuszu, aż się prosi żeby to View-Model tworzył ten obiekt i go wyświetlał. Czyli w konsekwencji jako element tej obsługi model widoku powinien utworzyć stosowny obiekt okna pop-up i go wyświetlić, ale to wymaga odwołania się do warstwy widoku, a w efekcie prowadzi do zabronionej tu rekurencji. W tym przypadku to nie tylko problem połamania zasad, ale braku możliwości dodania cyklicznego uzależnienia projektów od siebie.

Po uważnym przyjrzeniu się implementacji warstwy widoku w klasie MainWindow zauważamy, że zasadza dotycząca pustego code-behind nie w pełni jest spełniona. Wyjątek, który tu widzimy jest związany wyłącznie z zapewnieniem odprzęgnięcia warstw- czyli zapewnienia hierarchicznych odwołań. Szczegółową analizę pozostawiam jako pracę domową. Przy okazji proszę się zastanowić, w jaki sposób można się pozbyć tego fragmentu programu i faktycznie zapewnić, że code-behind będzie pusty.

## Praca domowa

Na koniec lekcji, jak zwykle, praca domowa.

### Refleksja

W trakcie lekcji mówiliśmy o wykorzystaniu refleksji do transferowania wartości z właściwości obiektu utworzonego na podstawie typu zdefiniowanego w warstwie ViewModel i obiektu zdefiniowanego w warstwie View. Aby lepiej zrozumieć ten mechanizm poproszę o napisanie metody, która podstawia przekazywaną do niej jako parametr wartość do właściwości obiektu, którego nazwa jest drugim parametrem. Oczywiście w tym scenariuszu nie znamy typu obiektu, który zawiera wspomnianą właściwość. Zadanie nie jest łatwe, ale przykład łatwo znaleźć. Aby podnieść poprzeczkę rozwiązanie powinno być genetyczne, a sygnatura metody może wyglądać jakoś tak:

### Wstrzykiwanie zaleznosci

Kolejne zadanie to, dokonać analizy tekstu programu w nadpisanej metodzie OnInitialized w klasie MainWindow w celu określenia celu w jakim ten tekst został tu umieszczony. Wykorzystać podobne podejście do otwarcia i przeczytania zawartości jakiegoś pliku tekstowego w wyniku wydania polecenia Browse w okienku TreeView example. Klawisz Show TreeView powinien stać się aktywny  wyłącznie jeśli operacja czytania pliku się uda. Proszę pamiętać o konieczności wyświetlenia odpowiedniego okienka pytającego użytkownika o ścieżkę do pliku. Przy okazji proszę się zastanowić, w jaki sposób można się pozbyć tego rodzaju operacji z code-behind i zapewnić, że będzie on faktycznie pusty.

### Diagram kontroli zależności

W tym punkcie pracy domowej proszę dodać do tekstu omawianego programu przykładowego diagram kontroli zależności i sprawdzić jaki jest rezultat próby naruszenia korzystania z warstw, czyli próby zastosowania odwołań cyklicznych. Uwaga nie wszystkie wersje Visual Studio wspierają tą funkcjonalność.

## Zakończenie

W tej lekcji to już wszystko. To również ostatnia lekcja kursu. Dziękuję za poświęcony czas. Mam nadzieję, że trud przebrnięcia przez wszystkie przedstawione tu meandry związane z przetwarzaniem danych zewnętrznych przydadzą się w praktyce. Zapraszam do współpracy nad tekstem przykładowego programu, który jest dostępny na GitHub.

-->