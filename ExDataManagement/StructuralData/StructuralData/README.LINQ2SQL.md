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

# LINQ to SQL

## Introduction

In this chapter, we will continue to discuss structured data and the ability to create queries using LINQ expressions. Let me remind you that the LINQ abbreviation stands for language-integrated query. This time, we will use these queries to pre-select data from the relational database.

However, I must emphasize here that we will focus only on issues related to the programming language, i.e. its syntax and semantics. Unfortunately, we cannot completely avoid topics related to the design environment used, namely Visual Studio and the dedicated libraries used. Anticipating questions about why I chose this and not another approach, I would like to emphasize that, in my opinion, it guarantees minimization of the costs of entering the subject. If the priority is different, then of course most of what we will talk about also applies in another environment, e.g. Entity Framework.

Let's start with a few definitions, explanations, and indications of directions for searching for new solutions in terms of improving the management of access to external data using relational databases as an example.

At run-time, the text of our program (in the following illustration) has been compiled, entered into memory, and has become a process managed by the computer's operating system. The operating system strongly defends the integrity of resources committed to the process. This defense is encapsulation, which forces you to use the operating system when you need to exchange data with the external environment.

![Program Layered Design Pattern](../.Media/ProgramLayeredDesignPattern.png)

The figure also shows the layered architecture of the program. The reasons for introducing layers have already been discussed. I suggest not returning to this topic now. Currently, our goal is to discuss issues related to the management of external data, i.e. data whose entities are outside the boundaries of the process hosting the program.

Shared bitstreams exposed by the filesystem are one option, and we've already talked about them. Later, we will discuss the graphical representation of information intended for communication with the user.

Now our goal is to discuss issues related to the interaction of the process executing the program with databases, i.e. with an external database management system (Database Management System, DBMS for short). The purpose of a DBMS is to consistently store and archive data according to a certain scheme that allows for the creation of data structures. Data is made available and processed by the DBMS using a query language that should be widely known and accepted to guarantee the scalability of solutions. Examples include the relational database and SQL. Other examples that can be treated as equivalent in this context are Triple Store and SharePoint databases. However, in further analysis, we will refer only to relational databases, although the topic of how to use the discussed mechanisms to gain access to other types of databases will also be the subject of discussion.

In the above figure, we can distinguish two places where data can be located. Of course, this is the database itself, but also the data layer of the program. To make this possible, in the data layer of the program we must have a kind of process data buffer and an interface enabling management of the database itself. A typical operation directly related to the DBMS, but only indirectly related to the process data, is opening and closing a connection to the database. From time to time the local data has to be synchronized with a database storage.

Database operations are executed and data between the mentioned locations is transferred using the:

- Custom application in concern
- Local system software, and libraries referred to by the program
- Operating system
- Communication protocols in the case of a distributed system - this is usually also part of the operating system
- Query language interpreter in DBMS software, for example, SQL language processor

It's a very diverse environment, so the real challenge is:

- how to ensure proper training of programmers
- how to minimize the possibility of making mistakes
- how to ensure a consistent diagnostic system
- how to ensure the possibility of transferring solutions between various environments, for example changing the operating system,

LINQ expression, i.e. language integrated query, is a technology integrated with a programming language that allows for the implementation of many of the mentioned goals. Therefore, we will devote this lesson to familiarize ourselves with this mechanism in the context of relational databases as an example that can also be expanded and used for other external data repositories.

## Database Example

To have something to practice on, we will start by creating a sample database and connection setup using the Visual Studio design environment. To make the example useful, we also need to create metadata describing the structure of the data in the database. We will call this metadata database schema. By design, the database schema is a logical representation of how data should be organized and stored within a database system. It acts as a blueprint that defines the structure and relationships of data. Think of it as the skeleton of the database, outlining the essential components.

Since the database functionality is implemented as an independent external process called Database Management System ( DBMS) the program we have developed cannot directly use its functionality. Instead, it uses the intermediary of the operating system by using a local data cache to indirectly operate on the database. As a result, we have a solution similar to the well-known proxy pattern. Additionally, for local program needs, the replica represents the schema and is a process data buffer. Typically, this is a partial replica that is not fully functionally equivalent to the DBMS and contains only selected data. And here we have a problem with how to define the criterion for selecting data in the buffer. These issues will be our concern in this part of the lesson.

The next issue is using the database in a custom program. We will examine selected issues related to this topic using unit tests. For a local replica to be useful, it must be interconnected with the database. In addition to creating appropriate communication channels between the replica and the DBMS, they are connected by a session responsible for authentication and authorization of operations performed on the database. Operations on the database and the data deposited in it are performed based on a formal description, in this case, compliant with the SQL language. Creating error-free SQL queries in the context of a custom program written using another programming language is another challenge we have to face. If we use expressions written using query syntax written in a programming language, we can automatically translate them into any other language, including SQL. How to do it? An attempt to answer this question is included in this part, which will concern mapping definitions in the local replica and remote database schema.

Since the examples discussed require access to a database, it is necessary to provide a server that acts as a DBMS and publishes data following a previously designed scheme for testing purposes. Since the program text is in a public repository and can be used in various environments, the unified use of a real SQL server is difficult to fulfill. One way to solve this problem is to use the Visual Studio environment in the server role. This requires creating a database file and then making it available for testing in such a way that the conditions of our tests do not differ significantly from the real production environment in which an external server is natural.

So we'll start by creating a sample database file. The example is located in the unit test project in a separate folder. The folder name doesn't matter. Our library is indeed educational, not production-oriented, but this approach allows us to design a library implementing the data layer in such a way that it is completely independent of the DBMS implementation method and does not contain elements dedicated to the test environment. Thanks to this, it can be later used in production without the need to modify the program text.

Therefore, in the selected place in the project, from the context menu, select add a new element. A window appears with a vast variety of components that we can potentially add to the project. Let's limit the list of proposals by selecting `Date` in the list of available categories. The component we need is a `Service-based Database`. It is added to the project already with the name `CDCatalog`. As a result, two files are attached to the project. Select cop always to make sure that they are copied to the target folder after the program compilation is completed. We will come back to this issue later because it is a condition for the correct use of the relational database imitation created this way.

![Create in-process db](../.Media/CreatinInMemoryDB.gif)

The condition for using subsequent tools available in Visual Studio is to establish a connection and, as a result, create an imitation of a SQL server. For this purpose, we will use the Server Explorer and Data Connection windows in the server type selection tree. The context menu allows us to add a new connection. You must select Microsoft SQL Database File as the data source. This will permit us to select a file with the .mdf extension in the next step. We can still test the correctness of the connection to this database server. The result is a new multi-component tree node that, when expanded, has content identical to that of a typical relational database.

![Server Explorer](../.Media/ServerExplorer.gif)

For the example to be useful, we also need to create metadata describing the structure of the database. We will call this metadata the database schema. Designing a database schema is beyond the scope of this document. However, this will not be a big divergence from the real scenario if we assume that the database already exists and is compatible with the purpose it is intended to serve. According to our needs, a schema was created assuming the creation of, as before, a primitive CD catalog, which consists of two tables: CDCatalogEntity and Person. Stepping into these tables - colloquially speaking - shows their structure and the SQL scripts that can be used to create them. It is worth paying attention to the external key defining their mutual relationship. This feature of the diagram will be used later.

![Database Content](../.Media/DatabaseContent.gif)

For the program to process data stored under the control of an external repository, i.e. an independent process, it must be fetched to local memory first. This means that a local memory replica is used to store relevant data. It is like a database mirroring feature. The replication may be partial or complete. In addition to buffering process data, it is also responsible for providing the functionality of data synchronization with the repository. The mentioned functionality and process data structures require their implementation using types. To meet this requirement, two mutually consistent areas can be distinguished. The first area consists of typical solutions, repeatable for every program using a DBMS. The second area includes the need to meet individual requirements. An example of individual requirements is the local mapping of usable data structures. As a result, from the program's point of view, the obtained replica creates an additional abstract layer, i.e. it hides the implementation details of the actual mechanisms of interaction with external structured data repositories.

Repeatable solutions are offered in the form of design environment dedicated features (for example, Visual Studio and its server explorer), but also libraries and additional tools. These tools can be used, for example, to automate the process of managing program text related to meeting individual needs. One of such needs is the automatic generation of types that will represent a similar process data structure to that in the repository. The whole thing usually creates a complex infrastructure, often referred to as a framework. Our main goal is to focus on solutions integrated with a programming language that can be used in any case. Discussing the selected infrastructure is beyond the scope of the course, but something must be chosen to ensure that relevant content is placed in a practical context. Since we're discussing LINQ expressions, LINQ to SQL seems like a natural choice.

To start working with the database, in a selected place in the application project, add the LINQ to SQL classes component, which can be found in the set of available Visual Studio components. It is easier to find this component if we limit the number of displayed components by selecting Date in the category tree. As you can see, the LINQ to SQL classes technology is not the only implementation that enables cooperation with external repositories for archiving and processing data. Let's call this component similar to the previous one, namely Catalog.

![DBML Generation](../.Media/DBMLGeneration.gif)

Once created, the new multi-component item appears in the selected location. By double-clicking on the node grouping these components, the graphical editor appears.

![DBML Content](../.Media/DBMLContent.gif)

This editor allows you to transfer tables from a previously connected SQL server to the working plane of the graphical editor. Using the schema defined in the database, we can drag and drop two previously designed tables on the graphical editor surface. The structure diagram created this way contains appropriate properties for table columns and relationships between tables. It is worth noting here that the types of these properties were automatically selected based on the component types used in the tables.

The created diagram resembles a UML class diagram. In this diagram, as I mentioned, the classes were automatically connected using associations. This association in the diagram is a consequence of the foreign key used to define the relationship between table entities in the database. It must therefore be implemented in the program code as a reference value to introduce similar structural dependencies into the program. We can edit relationship properties in a separate editor window, which we open from the context menu.

Designing this structure results in automatically generated program text that implements it in partial classes. This time, the program contains three classes representing dedicated information. The database is represented by the [CatalogDataContext][CatalogDataContextDGML] class. The author is represented by a class called [Person][PersonDGML], and the CD is represented by the [CDCatalogEntity][CDCatalogEntityDGML] class. It is worth noting that all classes are partial so that additional definitions can be added in a separate file, thus meeting individual needs related to the implemented data processing algorithm.

![DBML Content](../.Media/DGMLDiagram.png)

[CatalogDataContextDGML]: LINQ%20to%20SQL/Catalog.designer.cs#L26-L471
[PersonDGML]: LINQ%20to%20SQL/Catalog.designer.cs#L89-L248
[CDCatalogEntityDGML]: LINQ%20to%20SQL/Catalog.designer.cs#L251-L471

<!--

In both examples, LINQ operations remain essentially the same. The difference lies in the data source to which LINQ expressions are applied.

If the source implements `IEnumerable<T>` then operations with additional conditions are generally performed in memory, as in this case of LINQ to Objects.

If the source implements `IQueryable<T>` (which extends `IEnumerable<T>`) then operations with additional conditions may result in optimization, that translates to SQL queries enriched with these conditions that are generally performed on the database, as in the case of LINQ to SQL.

-->

<!--
### 3.2. Lokalna replika bazy

Klasa CatalogDataContext dziedziczy z DataContext, której definicja znajduje się w bibliotece środowiska .NET. To dziedziczenie pokazuje, jak wykorzystano polimorfizm do realizacji potrzeb indywidualnych i klasy bazowej do implementacji wymagań wspólnych dotyczących funkcjonalności dedukowanej do operowania na bazie danych jako pewnej całości. Klasa ta implementuje również interfejs IDisposable, co należy wykorzystać do odpowiedniego zarządzania czasem życia i stanem obiektu utworzonego z tej klasy.

Ponieważ auto-generowany tekst zawiera kilkaset linii, proponuję teraz, aby dokonać jego analizy korzystając z funkcji Show on Code Map. Otrzymana reprezentacja graficzna tekstu, czyli diagram zawiera opis zawartości wygenerowanych klas i pokazuje relacje pomiędzy nimi. Celem analizy jest znalezienie podobnych relacji, jakie mieliśmy poprzednio w klasach utworzonych ręcznie. Jak już to ustaliliśmy w wygenerowanym tekście znajdują się trzy klasy, które widać na utworzonym diagramie. Po odfiltrowaniu zbędnych do tej analizy elementów widać, że klasa Person reprezentująca autora płyty i CDCatalogEntity reprezentująca płytę są połączone ze sobą rekurencyjnie.

W pierwszej kolejności szukamy klasy CDCatalogEntity i relacji jeden do jednego łączącej płytę CD z jej autorem, a mianowicie klasą Person. Jest ona zrealizowana przez property (właściwość) o nazwie takiej jak klasa docelowa, a mianowicie Person. Jak to widać na ekranie zwraca ona referencje do obiektu klasy Person.

Przejdźmy teraz do wyszukania relacji w drugą stronę, a mianowicie relacji która połączy autora reprezentowanego przez klasę Person i wszystkie jego płyty, czyli składnika udostępniającego relacje do obiektów klasy CDCatalogEntity. Ta relacja wiele do jednego jest zaimplementowana jako właściwość CDCatalogEntities, która zwraca obiekt generyczny typu EntitySet. Jak widać to w utworzonym tekście programu obiekt tego typu jest kolekcją obiektów typu CDCatalogEntity.

Ponieważ klasa CatalogDataContext , która reprezentuje funkcjonalność bazy danych, jest klasą częściową możemy w osobnym pliku zaimplementować własną funkcjonalność dedykowana do indywidualnych potrzeb. W naszym przypadku ograniczymy się przykładów użycia różnych from wyrażeń LINQ i porównamy je z typowymi operacjami iteracyjnymi.

Zatem podobnie jak poprzednio umieszczono tu trzy metody implementujące na trzy różne sposoby ten sam algorytm, a mianowicie wybór listy osób wskazanych przez parametr metody. Do implementacji tych wrócimy w kontekście testów jednostkowych, które użyjemy do bardziej szczegółowej analizy porównawczej tych trzech implementacji.

Dodatkowo klasa ta zawiera metodę AddContent, która przeznaczona jest do dodawania nowych danych do bazy.
W pierwszej metodzie porównawczej różne implementacji filtrowania danych wykorzystano instrukcję foreach. W drugiej algorytm filtrowania zapisano wykorzystując wyrażenie LINQ zapisane jako kwerenda. W kolejnej implementacji wykorzystano wyrażenie LINQ zapisane jako ciąg operacji
Metoda TruncateAllData jest przeznaczona do czyszczenia zawartości bazy. Jest ona wykorzystywana w testach jednostkowych do zagwarantowania jednakowych warunków rozpoczęcia testu.

Cech poszczególnych metod będziemy badali wykorzystując testy jednostkowe. Tu należy podkreślić jednak, że testy do których za chwilę przejdziemy nie są przeznaczone to kontroli poprawności proponowanych rozwiązań, ale tylko do badania ich właściwości.

### 3.3. Korzystanie z bazy

#### 3.3.1. Wstęp

Przejdźmy teraz do analizy przykładowych metod filtrujących dane z bazy danych w kontekście testów jednostkowych. Pełnią one rolę usług zapewniających dostęp do danych strukturalnych warstwom wyższym. Tu istotnymi zagadnieniami są połączenie do bazy danych, budowanie kwerend SQL i ich realizacja w kontekście tego połączenia. Ponieważ lokalnie dane przetwarzane są z wykorzystaniem pewnej pamięciowej repliki bazy, o której mówiliśmy poprzednio, trzeba harmonizować proces tworzenia kwerend ze strukturą tej repliki.

#### 3.3.2. Połączenie do bazy danych

Jak zwykle wykorzystamy testy jednostkowe do analizy wybranych cech omawianego zagadnienia. Wszystkie testy są zlokalizowane w jednym pliku. Ponieważ testowane metody wymagają dostępu do bazy danych niezbędne jest stworzenie na te potrzeby serwera pełniącego rolę DBMS i publikującego dane zgodnie z wcześniej zaprojektowanym schematem. Ponieważ tekst programu znajduje się w publicznym repozytorium i może być wykorzystywany w różnych środowiskach, zastosowanie tu rzeczywistego serwera SQL jest warunkiem bardzo trudnym do spełnienia. Jednym ze sposobów rozwiązania tego problemu jest wykorzystanie środowiska Visual Studio w roli właśnie takiego serwera. Wymaga to dostępu do pliku bazy danych w trakcie realizacji testów, które muszą znać bezwzględną ścieżkę do niego.

Aby wykorzystać to podejście do projektu testowego został dołączony plik z zawartością bazy danych. Aby testy nie modyfikowały jego zawartości za każdym razem, kiedy są wykonywane, należy go skopiować do przestrzeni roboczej testu. W tym celu wykorzystano atrybut DeploymentItem, którego zadaniem jest spowodowanie skopiowania pliku do lokalnego folderu o przewidywalnej nazwie przed uruchomieniem testów w tej klasie. Atrybut ten powoduje kopiowanie pliku korzystając z aktualnej ścieżki do miejsca, gdzie kompilator umieszcza rezultaty swojego działania. To pozwala kopiować pliki niezależnie od używanej aktualnie konfiguracji kompilatora.

Aby uprzednio dodany plik bazy danych był kopiowane przez kompilator, a właściwie przez program msbuild, musi mieć ustawioną odpowiednią właściwość w pliku konfiguracyjnym projektu. Możemy tego dokonać korzystając z menu kontekstowego dla tego pliku, w tym przypadku pliku CDCatalog z rozszerzeniem mdf.

Metoda ClassInitializationMethod jest odpowiedzialna za utworzenie aktualnego connection string na podstawie znanego miejsca, gdzie jest kopiowany plik bazy danych oraz tekstu szablonu umożliwiającego wykorzystanie środowiska Visual Studio do emulowania połączenia z serwerem bazy danych, więc z DBMS. Wyznaczony ciąg znaków będzie dalej wykorzystany do zestawienia połączenia z naszą imitacją bazy danych.

Baza danych jest reprezentowana w lokalnej replice jako obiekt klasy CatalogDataContext. Ponieważ klasa ta implementuje interfejs IDisposable utworzenie nowego obiektu tej klasy umieściłem w instrukcji using, która gwarantuje wywołanie metody Dispose zawsze, kiedy zmienna _newCatalog wyjdzie z zakresu widzialności, więc obiekt do którego przechowuje referencje nie będzie mógł być już bezpośrednio wykorzystany w programie. Do konstruktora tej klasy jest przekazywany connection string, co świadczy o tym, że utworzony obiekt jest odpowiedzialny za zarządzanie połączeniem i utworzoną na jego bazie sesją. Sesja przechowuje kontekst w którym odbywa się komunikacja pomiędzy lokalnym obiektami tworzącymi replikę bazy i DBMS. W ramach tego kontekstu bardzo ważna jest tożsamość, która będzie używana do autoryzacji operacji zlecanych poprzez lokalną replikę do zdalnego DBMS.

Zwykle baza danych zawiera dane odzwierciedlające stan pewnego procesu, a to oznacza konieczność uzależnienia się od historii operacji wykonywanych na tej bazie. W konsekwencji, z punktu widzenia testów zawartość bazy staje się nieprzewidywalna – nie jest zdeterminowana w czasie. Aby zapewnić przewidywalny rezultat testów jednostkowych, zawartość bazy musi być też przewidywalna. Celem metody PrepareData jest rozwiązanie tego problemu. Tworzy ona obiekty i łączy je w graf o powtarzalnej i znanej zwartości. Wykorzystamy go jako dane testowe, które posłużą jako dane inicjacyjne. Aby zainicjować bazę musimy utworzyć obiekty o typach zgodnych z zawartością tabel w bazie i połączyć je w ekwiwalentną strukturę. Utworzony graf nie ma dodatkowej funkcjonalności, więc może być traktowany jako obiekt transferowy w terminologii angielskiej nazywany Data Transfer Object (DTO). W naszym przypadku jest to bardziej graf niż pojedynczy obiekt, ale to już nieistotny szczegół.

Klasy spełniające wymagania DTO zostały zdefiniowane w testach jednostkowych, więc w bibliotece nie są znane. Aby zaimplementować metodę AddContent posłużmy się wzorcem wstrzykiwania zależności. Zgodnie z nim typ parametru tej metody jest abstrakcyjny, to dwa interfejsy IPerson i ICDCatalog połączone w strukturę, które mogą być zaimplementowane w zależności od potrzeb. Takie podejście pozwala odprzęgnąć konkretne źródło danych, więc sposób powstawania danych, od sposobu ich wykorzystania.

Przejdźmy do przykładu, a przykład to klasy Person i CDCatalog, które zostały zdefiniowane w klasie TestDataGenerator. W kodzie programu widzimy, że klasa CDCatalog ma odwołania, więc referencję, do obiektu klasy Person, aby reprezentować informacje o autorze płyty CD. Jest to relacja jeden do jeden. Natomiast klasa Person zawiera reprezentację zbioru płyt wydanych przez jednego autora, więc ma referencje do obiektów klasy CDCatalog. Tym razem relacja jest jeden do wielu. Te referencje są dostępne jako obiekt implementujący IEnumerable, a taki obiekt może być wykorzystany jako źródło danych w instrukcji foreach i wyrażeniu LINQ.

#### 3.3.3. Budowanie kwerend SQL

Jak wcześniej zaznaczyłem wszystkie operacje wykonywane na bazie danych muszą być opisane w odpowiednim języku dla wybranego DBMS. Ponieważ w przykładzie wykorzystujemy bazę relacyjną, więc jej naturalnym językiem jest SQL, ale program piszemy w C#. Popatrzmy na trzech implementacjach tego samego algorytmu preselekcji danych jak sobie z tym problemem poradzić, żeby nie używać bezpośrednio języka SQL.

W pierwszej metodzie użyto instrukcję foreach i wewnętrzną instrukcję if odpowiedzialną za filtrowanie zawartości tabeli zgodnie z wartością parametru metody. W teście oprócz zwracanej przez metodę wartości badany jest również typ zwracanego obiektu oraz wynik wywołania jego metody ToString. Z rezultatu widzimy, że zwracany jest obiekt generycznej klasy List, której parametrem typu jest Person. To kolejny dowód na to, że w tym przypadku wynikiem jest kolekcja wybranych wartości, a więc wynik działania wspomnianych instrukcji. Konsekwencją takiej implementacji jest konieczność ściągnięcia wszystkich wartości z tablicy Persons by lokalnie podjąć decyzję o wyborze poszukiwanych danych.

W drugim teście badamy implementację metody wykorzystującej wyrażenie LINQ zapisane zgodnie ze składnią kwerendy. Wynik testu jest identyczny z poprzednim, ale tym razem zwracany typ obiektu wyniku działania metody jest inny, co ponownie potwierdza, że w przypadku wyrażeń klasy LINQ zwracana jest obiektowa reprezentacja samego wyrażenia, a nie wynik jego działania. Oczywiście to twierdzenie jest prawdziwe tak długo, jak długo kompilator radzi sobie z tłumaczeniem tekstu programu na postać umożliwiającą takie przekształcenie do postaci obiektowej w trakcie jego realizacji.

W kolejnym teście badamy rezultat zwracany z metody realizującej ten sam algorytm filtrowania, ale zaimplementowany z użyciem wyrażenia LINQ zapisanego, jako ciąg operacji z wykorzystaniem metod rozszerzających. I znów wynik testu jest identyczny do poprzedniego i dodatkowo badanie typu zwracanego obiektu daje ten sam wynik jak poprzednio, a to potwierdza, że rezultat użycia wyrażenia LINQ jest zawsze taki sam niezależnie od użytej składni.

Tu warto zauważyć, że tekst zwracany z metody ToString dla obiektu będącego wynikiem działania  badanych metod wykorzystujących wyrażenia LINQ przypomina kwerendę SQL. Ja ten tekst zapisałem do osobnego pliku, który teraz otworzymy w osobnym edytorze. Faktycznie teraz widzimy, że jest to typowa kwerenda selekt. Przed wysłaniem do zdalnego DBMS musi być jeszcze uzupełniona o wartość parametru metody, w której będzie wykorzystana.

Spróbujmy wytłumaczyć ten rezultat. Używając skrótu „go to definition” menu kontekstowego albo klawisza F12 przeniesiemy się do definicji metody where. Widzimy, że jest to metoda rozszerzająca interfejs `IQueryable` i znajduje się ona w statycznej klasie `Queryable` biblioteki .NET. Klasa ta zawiera również wszystkie pozostałe metody, które są niezbędne do realizacji wyrażeń LINQ. To ważne stwierdzenie i warto je zapamiętać dla zrozumienia odpowiedzi na postawione już wcześniej pytanie co to jest wyrażenie klasy LINQ i czym się ono różni od wyrażeń nie należących do tej klasy. Jak wspomniałem, to pytanie padło już w trakcie poprzedniej lekcji, ale wrócimy do niego jeszcze raz.

Na podstawie analizy tekstu programu stwierdzamy, że Where tym razem jest metodą rozszerzającą interfejs `IQueryable`. Jak widzimy, definicja tego interfejsu jest pusta, ale łańcuch dziedziczenia wskazuje, że interfejs ten wymaga również implementacji interfejsu IEnumerable. Zatem znowu możemy powiedzieć, że mamy do czynienia z wyrażeniem LINQ. Ponieważ poprzednio nie otrzymaliśmy kwerendy SQL to nie tłumaczy innego zachowania się wyrażenia LINQ tym razem. Różnicę stanowi niegeneryczny interfejs `IQueryable`, który jest również na liście dziedziczenia. Jego definicja pokazuje, że wymaga on zaimplementowania trzech geterów, które właśnie są wykorzystywane przez środowisko .NET to przetłumaczenie wewnętrznej reprezentacji wyrażenia LINQ na jego zewnętrzny odpowiednik. O tym jaki język zostanie wybrany jako język docelowy decyduje właśnie implementacja tych properties – geterów.

Ponieważ wyrażenie LINQ zawsze wygląda tak samo – ma tą samą składnię niezależnie od źródła danych, kluczowym pytaniem tu jest, jak stwierdzić, że zostanie ono przetłumaczone na kwerendę zewnętrznego repozytorium danych strukturalnych, a nie wykonane lokalnie na danych znajdujących się w pamięci lokalnej procesu. Odpowiedzi należy szukać analizując pochodzenie definicji wartości zwracanej i użytej w roli źródła danych, a więc po słowie in lub jako pierwszy składnik w wyrażeniu LINQ zapisanym jako ciąg operacji, czyli w naszym przykładzie wartość zwracana przez Persons. Przechodząc do definicji tej property można stwierdzić, że zwraca ona wartość generycznego typu Table. Dalsza analiza pochodzenie definicji tego typu wiedzie do komponentu Microsoft’u System.Data.Linq, a definicja tego typu wskazuje, że implementuje on interfejs `IQueryable`. Ponieważ jest to komponent technologii LINQ to SQL, więc jego implementacja gwarantuje konwersję na kwerendy SQL.

Tu jeszcze raz podkreślmy, że składnia wyrażenia LINQ nie odpowiada jednoznacznie na pytanie, co się stanie, jak wyrażenie zostanie wykonane. Innymi słowy tu powiązanie składni z semantyką, więc znaczeniem tekstu nie jest jednoznaczne, co może prowadzić do bardzo kłopotliwych błędów.

#### 3.3.4. Mapowanie

Pozostaje jeszcze jedna zagadka, a mianowicie implementacja `IQueryable` w typie Table jest odpowiedzialna za dokonanie konwersji wewnętrznej reprezentacji wyrażenia LINQ na kwerendę SQL. Patrząc na przykładową, odzyskaną kwerendę SQL widzimy, że operacja konwersji może się udać jedynie wtedy, jeśli dysponuje kilkoma dodatkowymi informacjami, jak: nazwa tablicy, nazwa kolumn oraz typy danych w poszczególnych kolumnach. Ponieważ mówimy o implementacji, więc operacja konwersji na SQL musi być realizowana dynamicznie, czyli w trakcie wykonywania programu.

Zatem zasadnym jest pytanie: jak te informacje pozyskać, lub raczej odzyskać w czasie realizacji programu?

Po pierwsze zauważmy, że typ Table jest typem generycznym. Przeanalizujmy zatem typ jego parametru aktualnego dla wybranego przykładu, czyli Person. Przechodząc do definicji tej klasy widzimy, że jest ona poprzedzona atrybutem Table. Odpowiedź zatem nasuwa się sama – refleksja, więc odzyskiwanie meta danych z definicji auto-generowanych typów korzystając z mechanizmów refleksji.

O refleksji było już wcześniej, więc można sobie przypomnieć, jeśli są jakieś wątpliwości co do jej działania, a wiedza ta będzie potrzebna, bo kolejna metoda testowa `ObjectRelationalMappingTest` pokazuje jak można potrzebne do konwersji dane odzyskać w implementacji interfejsu IQuerable.

## 4. Praca domowa i zakończenie

### 4.1. Wstęp

Na koniec lekcji, jak zwykle, praca domowa.

### 4.2. Zakres

Pokazana metoda wykorzystuje wyrażenie LINQ, w którym tworzone są obiekty typu anonimowego. Trzeba przekształcić ją tak aby zwracała wyrażenie LINQ podobnie jak inne metody w tej klasie, a nie jak to jest teraz sformatowany string z wstawionymi wynikami selekcji.

Następne zadanie dotyczy jej metody testowej – znajdźmy ją w tekście programu. W ramach zadania trzeba dopisać w tej metodzie niezmiennik - przypomnę metodę z klasy Assert- niezmiennik ten ma sprawdzać zwracany tekst kwerendy SQL.

Kolejne zadanie dotyczy modyfikacji omawianej metody selekcji, w której w miejsce metod rozszerzających LINQ trzeba użyć własnych metod rozszerzających. Tu wystarczy sprawdzić jaki to ma wpływ na zwracany rezultat. Podobnie, trzeba sprawdzić jaki wpływ na typ zwracanej wartości ma zastąpienie wyrażenia lambda przez metody nazwane i typu anonimowego przez własny i auto-generowany typ nazwany.

## 5. Zakończenie

W tej lekcji to już wszystko. Dziękuję za poświęcony czas. Tą lekcją kończymy grupę tematyczną związaną z operowaniem na danych strukturalnych dostępnych w zewnętrznych repozytoriach. Omówione tu przykłady ograniczyliśmy do współdziałania z relacyjną bazą danych. Musimy jednak pamiętać, że poznane konstrukcje językowe są uniwersalne i rozszerzalne. Innymi słowy mogą być wykorzystane w kontekście dowolnego repozytorium i zaadoptowane do własnych potrzeb.
-->