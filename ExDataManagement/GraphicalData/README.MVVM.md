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

# MVVM Program Design Pattern <!-- omit in toc -->

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
  - [3.5. Code behind - dependency injection (Binding)](#35-code-behind---dependency-injection-binding)
- [Bindings - View and ViewModel Interoperability](#bindings---view-and-viewmodel-interoperability)
  - [Coupling Control Types with Data Source](#coupling-control-types-with-data-source)
  - [DataContext](#datacontext)
  - [Binding](#binding)
  - [DataBinding](#databinding)
  - [INotifyPropertyChange](#inotifypropertychange)
  - [ICommand](#icommand)
  - [RelayCommand](#relaycommand)

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

According to well-known principles of software engineering, the program should have a layered architecture. Layered architecture means that one layer may be recognized as upper and a second one as a lower one although there are usually more layers. So that we can distinguish which one is higher. To achieve this only the upper layer may refer to the underneath layer. In contrast, the lower layer must be composed in such a way that it doesn't depend on the upper layer. hence, the inter-layer reference must be unidirectional, often called hierarchical.

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

1. The first drawback is related to the obvious violation of the principle of **separation of concerns**. This principle means avoiding the need to divide attention and encourages focusing only on single, well-separated issues. Probably,  this is a result of the human limitation of thought processes when solving a multi-threaded problem. In our case, if we are working on the GUI, we are not also working on process automation, i.e. algorithms implementation related to the process in concern. Let's focus solely on human-machine communication.

There is another very tangible disadvantage, namely one of the popular ways of checking the correctness of a program is the use of unit tests. In addition to testing for correctness, they are also useful for checking whether significant modifications have been made to the program text that may have side effects and require inclusion in other parts of the program. Additionally, and somewhat unusually, I use tests in examples to show selected features of the solutions discussed, and not to check the correctness of the examples discussed. Unit tests have the property that they do not support testing of a graphical user interface. Hence, to be used as widely as possible, the concerns of graphical representation and interface behavior controlling this interface should be separated so that independent unit tests can be created for them without the need to run graphics rendering. In our example, I implemented this separation by implementing interface behavior controlling in a separate project implementing the ViewModel layer according to the MVVM pattern.

The next disadvantage is also tangible. In a project dedicated to the GUI, we see a hard dependency, i.e. a reference to **PresentationFramework**. This prevents the results generated here from being used on operating systems other than Microsoft Windows. So the program becomes hard to portable. Placing text here that is not directly related to graphics control violates another principle of programming engineering, namely reusability, so again loosely translated it means the possibility of reusing the text - in this case for another GUI technology. The possibility of re-use translates directly into money because if it is not portable, a similar program text must be written again and, what is worse, it must be maintained later.

To sum up, placing the text of a program implementing any activities related to process data processing in the code-behind, i.e. in this part of the program, violates the principle of separation of concerns, limits the possibility of using unit tests, and limits the portability of the solution. These are limiting remarks and lead to the conclusion - let's not do it, it's not a good idea.

### 3.5. Code behind - dependency injection (Binding)

What about this piece of text? Am I contradicting myself? I will come back to this point, for now, please trust me that this is following the recommendations, and theoretically, this text can be removed, but it is not that simple. Again, the recommendation is the code-behind should not contain any line of code except the required one. This exception is vital here.

Since the place where the user interface comes to life should not be XAML and code-behind, it must be other parts of the program. Here, unfortunately, we encounter a barrier related to type compliance control. Namely, you first need to know these types to control type compatibility. Suppose technologically unrelated projects are to be independent, as is the case with the `GraphicalData' project. In that case, they cannot know these types because they will become dependent on the technology and the elaborate plan will fail.

How to cut this Gordian knot? So far, the discussion has been reactive, ending with a statement of what we cannot do. As we can guess, the solution is, of course, compromise. As a compromise - first - we will limit the roles of the controls that make up the View layer to the role of an intermediary passing data between users of the interface and the layers lying below the View layer. We will return to the layered architecture topic later in this article but as a result of simplifying we can treat the `View` layer as a separate project. Returning to the role of the intermediary, this role of the intermediary is limited to, colloquially speaking, transparently transferring data from and to the screen. Occasionally, as part of this operation, we may provide a conversion operation, e.g. date format depending on the natural language used by the interface user. Additionally, the GUI interface must be responsible for activating appropriate functionality in response to user commands.

The functionality of the scenario in which XAML is only a transparent data relay has been implemented in WPF technology. To transfer data, it must first be downloaded from some source. We don't have much choice here, they have to be objects, or rather their properties - described by types. Since these types must already be related to process data processing, their definition is dedicated to the needs of this process, which is located in the GraphicalData project. The View layer has references to this project. However, when WPF was implemented - and specifically the transfer mechanism - it could not have known these types. Data transfer in WPF is a generic mechanism, so it cannot refer to specific types, although it can have references to those types. This leads to the conclusion that we cannot use type definitions in this process, so what is left is only reflection, which allows us to recreate these definitions during program execution, which should not worry us much, because we are not the ones who have to use them and, consequently, know.

## Bindings - View and ViewModel Interoperability

### Coupling Control Types with Data Source

Let's look at an example. In the lower right corner of the window, we use a `TextBox` control. Its task is to write and possibly read text, i.e. a string of characters. The current value, so what is on the screen is provided via the `Text` property. Since we expect reading and writing, the equal sign after the `Text` name must mean transferring the current value to/from the selected place. We already know that this selected place must be a property of some object. The word `Binding` means that it is attached somehow to ActionText. Hence, the ActionText identifier is probably the name of the property defined in one of our types. Let's try to find this type using the Visual Studio context menu navigation. As we can see, it works and the property has the name as expected.

### DataContext

As you can notice, the navigation works, so VisualStudio has no doubts about the type of instance this property comes from. If Visual Studio knows it, I guess we should know it too. The answer to this question is in these three lines of the `MainWindow` XAML definition.

``` xaml
    <Window.DataContext>
      <vm:MainViewModel />
    </Window.DataContext>
```

Let's start with the middle one, in which we have the full class name, but the namespace has been replaced by the two-letter `vm` alias defined a few lines above. The class definition has been opened as a result of previous navigation to a property containing the text for the `TextBox` control. Let's consider what the class name means here. For the sake of simplicity, let's first look up the meaning of the `DataContext` identifier. It is the name of the property. It is of the object type. The `object` is the base type for all types. Since it's a property, we can only read it or assign a new value. Having discarded all the absurd propositions, it is easy to guess that the only correct answer is that the `MainViewModel` identifier here means a parameter-less constructor of the `MainViewModel` type, and this entire fragment should be recognized as the equivalent of an association statement to the `DataContext` property of a newly created instance of the `MainViewModel` type. In other words, it is equivalent to the following statement

``` CSharp
  DataContext = new MainViewModel();
```

Finally, at run-time, we can consider this object as both a source and a repository of process data dedicated to the GUI, in other words, it is a kind of GUI replica. From a data point of view, it creates a sort of mirror of what is on the screen.

### Binding

Let's go back to the previous example with the `TextBox` control and coupling its `Text` property with the `ActionText` property from the class whose instance was assigned to `DataContext`. Here, there is a magic word `Binding` that may be recognized as an invocation to transfer value between. When asked how this happens and what the word `Binding` means, i.e. when asked about the semantics of this notation, I usually receive an answer like this it is some magic wand, which should be read as an internal implementation of WPF, and `Binding` is a keyword of the XAML language. And this explanation would be sufficient, although it is a colloquialism. Unfortunately, usually, we need to understand when this transfer takes place. The answer to this question is fundamental to understanding the requirements for the classes that can be used to create an object whose reference is assigned to the `DataContext` property. To find the answer, let's try to go to the definition of this word using the context menu or the F12 key.

### DataBinding

It turns out that `Binding` is the identifier of a class or rather a constructor of this class. This must consequently mean that at this point a magic wand means creating a `Binding` instance responsible for transferring values ​​from one property to another. The properties defined in this type allow you to control how this transfer is performed. We can see their list here. Since this object must operate on unknown types, reflection is used. This means that this mechanism is rarely analyzed in detail. The colloquial explanation previously given that the transfer is somehow carried out is quite common because it has its advantages in the context of describing the effect. 

> I propose to create a class definition that will simulate this action and provide the functionality of assigning the selected value to the indicated property of an object whose type is unknown.

### INotifyPropertyChange

### ICommand

### RelayCommand

<!--
# Wzorzec MVVM

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

👉🏻 Okazuje się, że `Binding` jest identyfikatorem klasy, a właściwie bezparametrowego konstruktora tej klasy. To w konsekwencji musi oznaczać, że w tym miejscu magia kina oznacza utworzenie obiektu typu Binding, który odpowiada za transfer wartości z jednej właściwości do drugiej. Właściwości zdefiniowane w tym  typie pozwalają na sterowanie sposobem realizacji tego transferu. Tu możemy zobaczyć ich listę. Ponieważ obiekt ten musi operować na nieznanych typach wykorzystywana jest refleksja. To powoduje, że mechanizm ten rzadko jest analizowany w szczegółach i kolokwialne tłumaczenie poprzednio przytoczone, że transfer jest jakoś realizowany jest dość powszechne, bo ma swoje zalety w kontekście opisu skutku. W ramach pracy domowej proponuję stworzyć definicję klasy, która zasymiluje to działanie i dostarczy funkcjonalność podstawiania wybranej wartości do wskazanej właściwości obiektu, którego typ nie jest znany.

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