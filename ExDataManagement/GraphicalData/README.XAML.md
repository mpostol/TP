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

# XAML - Description of the Graphical Interface <!-- omit in toc -->

## Table of content <!-- omit in toc -->

- [1. Introduction (Preface)](#1-introduction-preface)
  - [1.1. Technology Selection](#11-technology-selection)
  - [1.2. Program Bootstrap](#12-program-bootstrap)
  - [Changes tracing](#changes-tracing)
  - [Why XML](#why-xml)
- [2. What is control?](#2-what-is-control)
- [3. See also](#3-see-also)

## 1. Introduction (Preface)

In this article, we continue the series dedicated to discussing selected issues related to the representation of process information in graphical form. The main goal is to address selected topics in the context of graphics, which is used as a kind of control panel for the business process. Generating such graphics requires a formal description. In this section, we use a dedicated domain-specific language (Extensible Application Markup Language - XAML for short). It is used to describe formally what we see on the screen. A new language - it sounds disturbing - especially since learning this language is beyond the scope of this publication. Fortunately, in-depth knowledge of it is not required. This is not a necessary condition to understand any of the topics in concern. The main goal is to examine selected topics bounded to generating a graphical user interface based on its formal description, which we programmers can somehow integrate into the entire program.

An image is a sequence of colored pixels. They must be composed in such a way as to represent selected process information, i.e. its state or behavior. Similarly to the case of data residing in memory, which we do not process by directly referring to their binary representation, we do not create a graphical user interface (GUI for short) by laboriously assembling pixels into a coherent composition. Moreover, as I mentioned earlier, the GUI is a dashboard controlling the process, so it must also behave dynamically, including enabling data entry and issuing commands.

### 1.1. Technology Selection

The next problem is how to ensure the appropriate level of abstraction, i.e. hide the details related to the creation of the image and not lose the ability to keep it under control. As usual, for our considerations to be based on practical examples we must use a specific technology. I chose the Windows Presentation Foundation (WPF). Still, I will try to ensure that we do not lose the generality of the considerations regardless of this choice. An important component of this technology is the XAML language, which we will use to achieve an appropriate level of abstraction. A discussion of WPF requires a separate course, and we will stay as close as possible to the topics related to the practice of using the CSharp language to deploy a Graphical User Interface.

### 1.2. Program Bootstrap

It may sound mysterious at first, but the fact that the graphical user interface is an element of the program is obvious to everyone. However, it is not so obvious to everyone that it is not an integral part of the executing program process. Let's look at the diagram below, where we see the GUI as something external to the process. Like streaming and structured data. This interface can even be deployed on another physical machine. In such a case, the need for communication between machines must also be considered. As a result, we must look at the interface and the running program as two independent entities operating in asynchronous environments. So the problem is how to synchronize its content and behavior with the program flow. In this article, we will only discuss the relationship between the creation of the GUI and the lifetime of the program instance.

### Changes tracing

Let's go back for a moment to the previous article describing how to use the independent Blend program while working on the UI appearance. After finishing work in Blend, we can return to creating the program text, i.e. return to Visual Studio. An additional note: Blend is an independent program that can be executed using the operating system interface, including the file browser context menu. It is independent, provided that the results of its work can be uploaded to the repository as an integral part of the entire program and the history of its changes can be tracked. This will only be possible if its output is text. This is our programmers' demand today, which must be followed without any compromise. This is an additional reason why graphic formats such as GIF, JPG, and PowerPoint files, to name only selected ones for determining the appearance of the GUI are generally a bad idea.

Let's see how this postulate is implemented in the proposed scenario. After returning to Visual Studio, we notice that one of the files has changed. After opening it in the editor, we see that it is a file with XML syntax, i.e. a text file, although next to it there is a similar image. Let's close the picture because we should focus on the text itself. However, it should be noted that the image-text relationship exists. Going to the folder where this file is located, we can analyze its changes. I suggest not wasting time on analyzing the changes in the file itself. It is better to spend this time understanding the content and role of this document as a part of our program. So let's go back to Visual Studio.

### Why XML


## 2. What is control?

It is a type that encapsulates user interface functionality and is used in client-side applications. This type has associated shape and responsibility to be used on the graphical user interface. A Control is a base class used in .NET applications, and the MSDN documentation explains it in detail. There is a bunch of derived classes that inherit from it, for example, Button.

## 3. See also

- [XAML in WPF](https://docs.microsoft.com/dotnet/framework/wpf/advanced/xaml-in-wpf)
- [TreeView Overview](https://docs.microsoft.com/dotnet/framework/wpf/controls/treeview-overview?view=netframework-4.7.2)

<!-- 
- [Dane graficzne - Generowanie Interfejsu Graficznego](#dane-graficzne---generowanie-interfejsu-graficznego)
  - [Praca z kodem](#praca-z-kodem)
    - [Śledzenie Zmian](#śledzenie-zmian)
    - [Czemu xml](#czemu-xml)
    - [Integracja funkcjonalności i grafiki](#integracja-funkcjonalności-i-grafiki)
    - [Klasa częściowa](#klasa-częściowa)
    - [xaml-semantyka - tworzenie nowych obiektów](#xaml-semantyka---tworzenie-nowych-obiektów)
    - [Kontrolka i renderowanie](#kontrolka-i-renderowanie)
    - [GUI jako drzewo kontrolek](#gui-jako-drzewo-kontrolek)
    - [Co to jest kontrolka](#co-to-jest-kontrolka)
    - [Kompilacja xaml](#kompilacja-xaml)
    - [Konwersja xaml na CSharp](#konwersja-xaml-na-csharp)
    - [Refleksja](#refleksja)
  - [Sekwencja uruchomienia](#sekwencja-uruchomienia)
  - [Praca domowa](#praca-domowa)
  - [Zakończenie](#zakończenie)

## Praca z kodem

### Czemu xml

Pewnie pierwszym zaskoczeniem jest to, że zamiast CSharp mamy xml. Są tego co najmniej dwa powody. Pierwszym jest to, że proces renderingu grafiki nie jest związany z implementacją algorytmów akurat w języku CSharp. Jak to wielokrotnie podkreślałem jest wiele języków, które możemy wykorzystać w tym celu. Więc pierwszy powód to przenośność rezultatu pracy. Drugi powód jest związany z użyciem edytora Blend, więc jakiegoś narzędzia programowego. Przypomnę, że standard xml, tak w ogóle powstał jako język przeznaczony do wymiany danych pomiędzy programami, czyli do integracji aplikacji. Tu widzimy, jak to działa w praktyce dla Blend i Visual Studio. Blend i Visual Studio to właśnie dwa niezależne programy, których funkcjonalność jest kompatybilna względem siebie.

### Integracja funkcjonalności i grafiki

Z punktu widzenia projektowania grafiki fakt, że mamy do czynienia z xml nas specjalnie nie powinien martwić. Wystarczy, że osoby znające się na kolorach i kształtach dadzą nam wygenerowany plik, który my dołączymy do projektu i nich Visual Studio zrobi resztę. No niestety to podejście jest zbyt piękne, by było realne. Cały ten misterny plan rozbija się o fakt, że prędzej czy później - a jak się możemy domyślać raczej prędzej - musimy zacząć mówić o integracji obrazka z funkcjonalnością procesową, a więc to za co nam płacą. Funkcjonalność to aktualne dane procesowe i zachowanie się interfejsu. My natomiast dane, czyli zbiory dopuszczanych wartości i operacje na nich realizowanych, definiujemy używając typów i o nich musimy zacząć mówić.

### Klasa częściowa

Szukanie rozwiązania tego dylematu, co nasze, a co wynik działania jakiegoś edytora, rozpoczniemy od zauważenia pozornie błahego faktu, a mianowicie plik, który edytowaliśmy jest połączony w parę z innym plikiem. Jak otworzymy jego parę w edytorze to stwierdzamy, że jest to tekst CSharp. Co więcej widzimy słowo partial, więc zawiera on częściową definicję klasy. A może te dwa pliki tworzą jedną klasę, jeden typ zgodnie z tym o czym mówiliśmy poprzednio w temacie definicji częściowych, czyli partial. W omawianych poprzednio przypadkach definicji częściowych pokazywałem, że ostateczna definicja powstaje w wyniku zmieszania tekstu poszczególnych części. To ma sens tylko wtedy, jeśli części są napisane w tym samym języku, więc mają tą samą składnię i semantykę. W rozważanym przypadku to oczywiście nie jest spełnione. Tu próba mieszania tekstów o różnych składniach musi doprowadzić do rezultatu, który nie jest zgodny z żadnym językiem. Wróćmy zatem do poprzedniego pliku xml. Nasze podejrzenia się potwierdzają,  bo jak widzimy, w pierwszym elemencie tego pliku jest atrybut `class` i nazwa klasy częściowej, która jest połączona w parę.

### xaml-semantyka - tworzenie nowych obiektów

Składnia i semantyka plików xml zdefiniowana przez specyfikację tego standardu nie jest wystarczająca do wyjaśnienia naszych obaw, ale przecież do każdego pliku xml możemy dodać własne reguły semantyczne, które określą przykładowo, co tu oznacza słowo `Grid`. Z menu kontekstowego możemy przejść do definicji tego słowa i widzimy, że otwiera się dodatkowe okienko z definicja klasy o tej samej nazwie i gdzie wyróżniony jest konstruktor bezparametrowy dla tej klasy. To pozwala uprawdopodobnić tezę, że znaczenie tego zapisu jest następujące: wywołaj konstruktor bezparametrowy i w konsekwencji utwórz i zainicjuj obiekt tej klasy.
Analizując kolejne elementy i atrybuty tego pliku xml widzimy, że odwołują się one do properties, czyli właściwości tej klasy.

### Kontrolka i renderowanie

Upraszczając, renderowanie to proces tworzenia kompozycji pikseli na ekranie korzystając z jakiegoś opisu – czyli u nas to zamiana tekstu w żywy obraz. Ponieważ układamy piksele na ekranie, to możemy mówić wyłącznie o czasie realizacji programu. W przypadku programowania obiektowego ten jakiś opis istniejący w trakcie realizacji programu musi być zbiorem obiektów połączonych w strukturę, a więc grafem. Obiekty są tworzone na podstawie typów. Zatem typy, które użyjemy do opisu obrazka muszą mieś wspólną cechę, a mianowicie przypisany kształt. Cały obrazek zatem musi być kompozycją typowych kształtów, które umożliwiają realizację dwóch dodatkowych funkcji, jak wprowadzanie danych i wykonywanie poleceń. Dodatkowo te kształty muszą również dać się adoptować do aktualnych potrzeb, co widzieliśmy w przypadku sposobu wypełnienia wybranego fragmentu ekranu. To wszystko można zrealizować dzięki polimorfizmowi i właściwościom czyli property typów.

### GUI jako drzewo kontrolek

Wróćmy zatem do pliku xaml, w którym widzimy mechanizm tworzenia obiektów. I teraz już wiemy, że tworzone obiekty muszą mieć wspólną cechę, a mianowicie dać się renderować. Skoro powstaje obiekt, to co zrobić z referencją do niego – przykładowo tworzymy obiekt na podstawie definicji klasy Grid. Jeśli nic, to garbage collector zajmie się nim natychmiast by go unicestwi. Przyjmijmy zatem tezę, że każdy obiekt utworzony zgodnie z hierarchią elementów pliku xml to kolekcja obiektów wewnętrznych. W takim przypadku wspomniany obiekt Grid byłby dodany do naszej klasy, ale przecież ona nie jest kolekcją. Tu zauważmy, że dziedziczy ona z klasy Window, która już taką kolekcję może być lub ją zawierać. W rezultacie tworzy się drzewko obiektów, którego elementem centralnym – czyli pniem - jest nasza klasa, która jest klasą częściową i dziedziczy z klasy Window.

### Co to jest kontrolka

Systematyczne omówienie języka xaml to temat na osobny kurs, więc tu przyjmijmy, że dostajemy ten plik jako rezultat działania specjalistów od estetyki, ergonomii i procesu biznesowego. Bez wnikania w szczegóły tego pliku, możemy zauważyć, że utworzony na ekranie obrazek też ma drzewiastą naturę i składa się z obrazków, które dalej składają się z następnych obrazków. W naszym przykładzie okienko to rodzaj tablicy, w komórkach której znajdują się lista, klawisze, pola tekstowe, itd. Innymi słowy każdy obiekt, który utworzyliśmy jest renderowany na ekranie, czyli każda klasa opisująca formalnie ten obiekt musi mieć skojarzony wygląd, więc reguły tworzenia pewnej kompozycji pikseli. Te klasy nazywamy potocznie kontrolkami. Więc nie wchodząc w szczegóły kontrolka to klasa, która implementuje funkcjonalność pozwalającą odwzorować pewien kształt i zachowanie na ekranie.

### Kompilacja xaml

Za wielce prawdopodobny możemy zatem przyjąć scenariusz, w którym plik xml napisany zgodnie z regułami pewnego języka bazującego na składni xml, jest konwertowany do języka CSharp i następnie możemy już te ujednolicone składniowo i semantycznie teksty wymieszać, tworząc z dwóch części ujednoliconą definicję klasę, a więc wrócić do dobrze znanego nam świata programowania w CSharp. Ten nowy język nazywamy xaml. Zgodnie z przedstawionym tu scenariuszem nie musimy nawet tego języka znać. I to by była prawda, gdyby wystarczyło utworzyć statyczny obrazek. My jednak musimy go ożywić, tzn. zobrazować stan procesu i zachowanie procesu przetwarzania, a więc wyświetlić dane procesowe, umożliwić ich edycję i reagować na polecenia użytkownika. Do tego tematu wrócimy w trakcie następnej lekcji. Może nas uspokajać fakt, że oprócz części w xaml mamy część w CSharp, zwaną code-behind i to że skoro kompilator może dokonać konwersji xaml na CSharp, to może my możemy wszystko napisać od razu w CSharp. Odpowiedź na pytanie czy jest to możliwe by nie używać xaml, jest twierdząca, więc pokusa jest duża. Niestety są koszta i to niemałe. Przed przejsciem do ich szacowania, musimy zrozumieć skąd się biorą, ale pamiętajmy, że mamy trzy opcje. Tylko Blend, tylko CSharp i jakaś ich kombinacja.

### Konwersja xaml na CSharp

Żeby te wspomniane poprzednio koszty konwersji zaml na CSharp oszacować i lepiej zrozumieć mechanizmy działania środowiska, musimy popatrzeć, co robi kompilator na podstawie analizy tekstu programu. Zróbmy krótką analizę bez wnikania w szczegóły. W konstruktorze klasy znajdziemy wywołanie metody InitializeComponent, której - na pierwszy rzut oka - nie ma w tekście programu, ale kompilator nie zgłasza błędu, więc gdzieś jest. Z menu kontekstowego przejdźmy do definicji w tekście, gdzie ta metoda jest zdefiniowana. Z nagłówka otwartego pliku widzimy, że ten tekst jest automatycznie wygenerowany, ale zauważmy też, że nie zawiera on prostej konwersji tekstu zaml na CSharp, natomiast przekazuje on ścieżkę do pliku zaml do metody LoadComponent. Funkcjonalność tej metody jest dostarczana przez bibliotekę, ale z opisu możemy się dowiedzieć, że to ona tworzy wszystkie obiekty używając refleksji. Refleksja to wyższy stopień wtajemniczenia i to są te koszty. Bez refleksji konwersja 1:1 zaml na CSharp w ogólnym przypadku jest niemożliwa.

### Refleksja

Refleksja to temat, o którym mówiliśmy już trochę, więc można do niego wrócić. Tu jednak zakończymy nasze dociekania. Wrócimy jeszcze do tego tematu w następnej lekcji w kontekście automatycznego wiązania warstw w czasie komponowania programu polegającego na tworzeniu obiektów i wykorzystaniu referencji do nich by utworzyć strukturę obiektów odpowiedzialną za kompozycję, dwukierunkowy transfer danych i zachowanie się GUI.

## Sekwencja uruchomienia

W programowaniu obiektowym uruchomienie aplikacji musi skutkować utworzeniem pierwszego obiektu. Jego konstruktor zatem zawiera instrukcję, która jest jako pierwsza realizowana przez proces utworzony przez system operacyjny. Tu rodzi się pytanie, jak ją znaleźć.

Każdy projekt zawiera swój plik konfiguracyjny. W analizowanym projekcie jego zawartość można odczytać korzystając z menu kontekstowego. I tu znajdujemy miejsce, w którym możemy wybrać obiekt startowy. Do wyboru jest tylko jeden, a składnia jego nazwy przypomina nazwę typu. Skoro to jest typ, to tu warto sobie zadać pytanie jak środowisko deleguje typy do tej listy? Czy tu może być więcej elementów na tej liście?

Skoro to ma być obiekt startowy to identyfikator w dropboxie musi być nazwą klasy. W drzewku class view znajdujemy odpowiedni typ. Po otwarciu widzimy, że jest to teks zgodny z xml z rozszerzeniem zaml. Po synchronizacji z resztą plików można zauważyć, że plik ten jest jednym z pary połączonych plików. Drugim jest plikiem CSharp, ale jest to pusta definicja i nie ma tu nawet konstruktora. Jest to kolejny przykład klasy częściowej napisanej w dwóch językach, a więc spodziewamy się konwersji zaml na CSharp i mieszania tekstów. Wynik konwersji możemy znaleźć wracając do drzewka klas. W dolnej części okna znajduje się lista dwóch metod. Wybierając dowolną z nich otwiera się tekst, który został wygenerowany automatycznie i który zawiera metodę statyczną o nazwie Main tworzącą obiekt tej klasy. Wywołuje ona metodę instancji utworzonej klasy Initialize. W tej metodzie możemy znaleźć odwołanie do pliku zaml, a mianowicie podstawienie do property StartupUri wskazujące na poprzednio analizowany plik zawierający definicję graficznego interfejsu użytkownika, często zwanego shell.

Tu warto zwrócić uwagę, na fakt, że ta klasa dziedziczy po klasie Application. W ramach pracy domowej proszę sprawdzić, czy można zadeklarować więcej klas, które dziedziczą po klasie Application i jak to wpływa na zwartość drop-box’a w konfiguracji projektu. Definicja tej klasy jest praktycznie pusta, tzn. nie ma nawet konstruktora, co oznacza, że wykonywany jest konstruktor domyślny, czyli rób nic. Co jednak pozawala na to, żeby tu zdefiniować własny konstruktor bezparametrowy. Można też nadpisać wybrane metody zklasy bazowej, by zachowanie dopasować do indywidualnych potrzeb programu. Z wykorzystaniem wspomnianych konstrukcji językowych tu możemy zlokalizować wymagane działania pomocnicze przed rozpoczęciem realizacji logiki biznesowe. Typowym przykładem jest przygotowanie infrastruktury związanej ze śledzeniem programu, wywoływanie przed zakończeniem programu operacji Dispose dla wszystkich obiektów, które tego wymagają, ale również tworzenie dodatkowych obiektów związanych z logika biznesową lub przygotowanie infrastruktury do wstrzykiwania zależności.

## Praca domowa

Na koniec lekcji, jak zwykle, praca domowa. Aby następna lekcja była bardziej zrozumiała proponuję trzy zadania w ramach pracy domowej.

Po pierwsze, proszę utworzyć własny projekt WPF i zmienić domyślny obiekt startowy. Drugie zadanie to dodać dwie metody, które będą wywołane odpowiednio na początku i na końcu programu. Wszystko to sprawdzić w testach jednostkowych. Uprzedzam, że to ostanie zadanie nie jest banalne.

## Zakończenie

W tej lekcji to już wszystko. Dziękuję za poświęcony czas. W następnej lekcji będziemy kontynuowali omawianie tych zagadnień ze szczególny uwzględnieniem odprzężenia widoku oraz danych/funkcjonalności, które sterują interfejsem graficznym. Omówione tu przykłady ograniczyłem do współdziałania z technologią WPF. Musimy jednak pamiętać, że poznane konstrukcje językowe są uniwersalne i rozszerzalne, innymi słowy mogą być wykorzystane również w kontekście innych technologii.

-->
