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
- [2. Deployment](#2-deployment)
  - [2.1. Window and Pop-up Window](#21-window-and-pop-up-window)
  - [2.2. UI Elements Appearance](#22-ui-elements-appearance)
  - [2.3. GUI Modification](#23-gui-modification)
  - [2.4. Master-detail GUI pattern](#24-master-detail-gui-pattern)
  - [2.5. Code-behind](#25-code-behind)
- [3. Layered Architecture](#3-layered-architecture)
  - [3.1. Introduction](#31-introduction)
  - [3.2. View - Inversion of Control](#32-view---inversion-of-control)
  - [3.3. MVVM as Sub-layers of the Presentation Layer](#33-mvvm-as-sub-layers-of-the-presentation-layer)
  - [3.4. MVVM Implementation Using Project Concept](#34-mvvm-implementation-using-project-concept)
  - [3.5. MVVM implementation Conclusion](#35-mvvm-implementation-conclusion)
  - [3.6. Layered architecture Benefits](#36-layered-architecture-benefits)
- [4. Bindings - User Interface Interoperability](#4-bindings---user-interface-interoperability)
  - [4.1. Coupling Controls with Data](#41-coupling-controls-with-data)
  - [4.2. DataContext](#42-datacontext)
  - [4.3. Binding](#43-binding)
  - [4.4. INotifyPropertyChange](#44-inotifypropertychange)
  - [4.5. ICommand](#45-icommand)

## 1. Introduction

In the case of graphic data, a window is a self-contained graphical unit created by the program and managed by the operating system. Managed means moving, enlarging, reducing, etc. This, of course, is not surprising since the development of the first Windows operating system, in which the window is the basis for human-machine communication.

The program can, of course, use several windows, as well as several databases or several files. In all cases, we can talk about an independent external data repository. In the case of Windows, however, we must consider an important difference, namely the interaction is two-way. In the case of databases, we can also expect the need to consider dynamic data change. However, only in the case of using the Windows operating system (OS), programs must respond to events triggered by the user.

Let's start by defining the most important problems and indicating directions for further search for solutions regarding application architecture in the context of communication with the user using the MVVM pattern that stands for Model-View-ViewMode.

Manipulating an image, i.e. changing its features, such as form, color, and appearance, is the first task at the edge between the program and the graphical representation of data. Here we return to the question of where to dynamically modify the image. The image is described in the `XAML` language not created to implement an operating algorithm, i.e. business logic. On the other hand, this language uses the types defined in CSharp. Hence, there must be a trade-off between graphic customization and process-related behavior implementation.

According to best practice of software engineering rules any program should have a layered architecture. Layered architecture means that one layer may be recognized as upper and a second one as a lower one although there are usually more layers. So that we can distinguish which one is higher. Only the upper layer may refer to the underneath layer. In contrast, the lower layers must be composed so that they don't depend on the upper layer. Hence, the inter-layer reference must be unidirectional, often called hierarchical. Because the hierarchy should be vertical the relationship should be top to bottom.

The program should have a layered structure - it's easy to say, but what is a layer? The program is text containing a stream of characters instead. Of course, in this principle the concept of a layer is abstract, but to say that the program architecture is layered, we must somehow implement this concept so that everyone knows what a layer is. In this respect, a programming pattern called MVVM is examined which stands for Model-View-ViewModel.

It is not difficult to imagine a scenario in which, when performing a certain operation, we need additional details from the user, for example, a file name. Obtaining this information requires additional at-hock communication with the user, which means engaging the topmost layer and displaying a pop-up window. This event must be handled by the layer underneath. It may be recognized as a confusion that it should be constructed so it is not aware of the existence of the upper layer, because it is above it. In scenarios like this, we will look for help in the Dependency Injection programming pattern. Those who have already heard something about this pattern may feel anxious that it is not another point in the discussion, but an introduction to a completely new topic. The concerns are justified, because many publications have already been written on this topic, and many frameworks and derivative terms have been created. An example is Inversion of Control. Without getting into academic disputes and deciding whether these publications and solutions concern dependency injection itself or the automation of dependency injection rather, we will try to solve the problem and separate the layers to avoid cyclical references between them, i.e. recursion in the architecture.

## 2. Deployment

### 2.1. Window and Pop-up Window

 Let's start a Discussion about a graphical user interface implementation by determining how we can bring the content of a program user interface to "make it alive". The phrase "make it alive" is a colloquialism that means **dynamically modifying graphics on the compute screen features**, editing data through it, and responding to user commands. The basic element to compose a Graphical User Interface, we already know, is a Window. An example is shown in the figure below. The primary element (Window ) is created during the bootstrapping by an executing platform according to the description in the program sequence. However, in the examined project, we have one more window. It appears after clicking one of the keys (in Fig. below).

![Pop-up Window](.Media/Pop-upWindow.gif)

Without going into details, let's assume that clicking a key causes some hard work to be performed in the background - for example, a file is being read and analyzed - and as a result, another window is displayed - a typical pop-up scenario - if everything goes well. This means we must deal with

- event handling - deciding when a window should be exposed on the screen. 
- view - deciding what the window should look like.

It is worth recalling here that a window is a class that inherits from the `Window` class and for the window to appear you need to call the [Show][Show] method.

### 2.2. UI Elements Appearance

The window element is an organization unit composed using controls. The control UI element is any type that inherits directly or indirectly from the [Control][Control] type. The [Control][Control] class is a base class for most of the user interface elements. It means that types inheriting from the base [Control][Control] type can be rendered on the screen. In other words, they have a graphical representation.

Looking at the content of an example class defining the main program window [MainWindow][MainWindow], we see that the displayed controls create a tree structure. The content is described using the XAML domain-specific language defined atop the `XML` technology. The references of internal controls, for example, `TreeView`, are added to the collection of containing elements. The containment hierarchy is determined by the structure of the `XML` document. Theoretically, by manipulating the contents of these collections by adding and removing elements, you can change the window's content and behavior. Because this approach is limited to the design stage of the program life cycle we will not analyze it further.

Instead of adding controls to the parent control's collection, we can use the [Visibility][Visibility] property. It takes one of the following values `Collapsed`, `Hidden`, and  `Visible`. Therefore, a practical tip is to add all the controls that may appear on the screen when designing a static image and then dynamically change this property as needed.

Sometimes controls may be visible on the screen but in static mode. An example of such a mode is an inactive key. The inactive key is visible on the screen but cannot be clicked. Another property, called [IsEnabled][IsEnabled], can be used for this purpose. It can be changed dynamically depending on the state the process is in. It is worth mentioning that GUI should be considered a state machine and the appearance of controls depends on the state of the UI. Hence, the controls should be grouped to change the state only of the selected part of the UI, not just by changing the individual controls.

### 2.3. GUI Modification

Similarly, by modifying the values ​​of various properties, we change other features of the controls, such as color, shape, filling method, etc. There are many of them. What to modify to refresh the user interface is the first important question. But now we come to the second question of where to make modifications. Of course, there are several answers to this question, and let's now try to analyze them and make some general practical recommendations.

We already know the first answer to the question of where to modify. Of course, it is the `XAML` text. Modification in `XAML` has a disadvantage in that it is essentially limited to assigning constants. It should be emphasized here that default values ​​are already assigned for each property defined by the controls, so there is no need to modify anything for typical behavior. An example is `Visibility`, whose default value is `Visible`. This language allows us to assign any values compliant with the appropriate type but its use to implement algorithms not directly related to GUI control is not a good idea.

### 2.4. Master-detail GUI pattern

The master-detail GUI pattern is commonly used in software applications to display hierarchical data. The master view displays a list or summary of items (e.g., records, files, contacts, products). Users can select an item from this list. When a user selects an item from the master view, the detail view updates to show detailed information about that item. It provides a more comprehensive view, including additional data and related details. Depending on the capability of the hardware the detail view may be displayed on the same window, on the pop-up window, or a window replacing the master one.

In this scenario, users start by scanning the master view to find the item they’re interested in. Once they select an item, the detail view updates dynamically to show relevant details. Users can navigate back to the master view or select another item to explore further.

### 2.5. Code-behind

Code-behind is a term used to describe the code joined with the `XAML` text. Both form one class definition because they are partial definitions. Therefore, all properties of this type can be modified in the code-behind part. However, this solution has several drawbacks. Let's narrow the discussion to the following ones that can be recognized as a good reason to exclude this approach.

1. The first drawback relates to the obvious violation of the principle of **separation of concerns**. This principle means avoiding the need to divide attention and encourages focusing only on single, well-separated issues. Probably,  this is a result of the human limitation of thought processes when solving a multi-threaded problem. In our case, if we are working on the GUI, we are not also working on process automation, i.e. algorithms implementation related to the process in concern. Let's focus solely on human-machine communication.
2. There is another very tangible disadvantage, namely one of the popular ways of checking the correctness of a program is the use of unit tests. Unit tests have the property that they do not support testing of a graphical user interface. Hence, to be used as widely as possible, the concerns of graphical representation and interface behavior controlling this interface should be separated so that independent unit tests can be created for them without the need to run graphics rendering. In our example, I have achieved this separation by implementing interface behavior in the project `GraphicalData.ViewModel` implementing the ViewModel layer according to the MVVM pattern.
3. The next disadvantage is also tangible. In a project dedicated to the GUI, we see a hard dependency, i.e. a reference to `Microsoft.WindowsDesktop.App.Ref`. This prevents the results generated by this project from being used on operating systems other than Microsoft Windows. So the program becomes hard to port. Placing text here that is not directly related to graphics violates another principle of programming engineering, namely reusability, so again it limits the possibility of reusing the text - in this case for other GUI technology. The possibility of reusing translates directly into money because if the product is not portable, a similar program text must be written again and, what is worse, it must be maintained later.

To sum up, placing the text of a program implementing any activities related to process data processing in the code-behind, violates the principle of separation of concerns, limits the possibility of using unit tests, and limits the portability of the solution. This analize lead to the conclusion - let's not do it, it's not a good idea.

What about overriding the [OnInitialized][OnInitialized] in the `MainWindow` class? Am I contradicting myself? I will come back to this point. For now, please trust me that this is following the recommendations. Again, the recommendation says **the code-behind should not contain any line of code except the required one**. This exception is vital here.

Since the place where the user interface comes to life should not be XAML and code-behind, it must be other parts of the program. Here, unfortunately, we encounter a barrier related to type compliance control. Namely, you first need to know these types to control type compatibility. Suppose technologically unrelated projects are to be independent, as is the case with the `GraphicalData.ViewModel` and `GraphicalData.Model` projects. In that case, the mentioned projects cannot refer to the control types because they will become dependent on the technology and the elaborate plan will fail.

How to cut this Gordian knot? So far, the discussion has been reactive, ending with a statement of what we cannot do. As we can guess, the solution is, of course, compromise. As a compromise - first - we will limit the roles of the controls that make up the view to the role of an intermediary passing data between the user interface and the rest of the program. As a result of simplifying we can treat the view as a separate project. Returning to the role of the intermediary, this role is limited to, colloquially speaking, transparently transferring data from and to the screen. Occasionally, as part of this operation, we may provide a conversion operation, e.g. adjust the date format depending on the natural language used by the interface user. Additionally, the GUI interface must be responsible for activating appropriate functionality in response to user commands.

The functionality of the scenario in which `XAML` is only a transparent data relay has been implemented in WPF technology. To transfer data, it must first be pulled from some source. We don't have much choice here, they have to be objects, or rather their properties - described by types. Since these types must already be related to process data processing, their definition is dedicated to the needs of this process, which is located in the `GraphicalData.View` project. The `View` layer has references to this project. However, when WPF was implemented - specifically the transfer mechanism - it could not have known these types. Data transfer in WPF is a generic mechanism, so it cannot refer to specific types, although it can have references to data holed of these types. This leads to the conclusion that we cannot use type definitions in this process, so what is left is only reflection, which allows us to recover these definitions during program execution, which should not worry us much, because we are not the ones who have to use them directly and, consequently know this technology.

## 3. Layered Architecture
  
### 3.1. Introduction

Before examining the gathered examples, first I must remind you that to make the discussion practical we must apply the layered pattern to the program text but not to the thinking process. The main goal is to apply the layered pattern rules directly to the program text as a result of the implementation of the algorithm derived from a research process. To promote a practical approach, I propose investigating this issue in the context of the syntax and semantics of a selected programming language. Although we are using a concrete development environment, the main hope is that the proposed approach is easily portable. All the examples in concern have been added to the `GraphicalData` folder. Check out the [ExDataManagement.sln][ExDataManagement] solution to follow the discursion in this respect. All examples are available in the [5.13-India tag][ExDataManagement].

According to good engineering practices, the program should be constructed using a layered design pattern. A layer is an abstract concept recognized as a program architecture design pattern formed as a hierarchy of layers where the upper layer refers only to the underneath layer. An example of a layered model is MVVM. It stands for Model, View, ViewModel.

In other words, we will talk about the program architecture keeping in mind that the program is only a sequence of characters. Here, unfortunately, I often encounter the practice of disregarding the principles of layered program structure, because it only complicates matters, and limits, and it is easier and possible to live without it, etc. Let us note that we have three significantly different approaches to this.

1. **PLD**: the second one is a typical program architecture, which also distinguishes three layers, but this time called presentation, logic, and data (PLD for short).
1. **MVVM**: the first is the model mentioned in the topic, i.e. MVVM. We don't see any signs of its presence yet, but it appeared in the context of engineering a graphical user interface (GUI).
1. **Spaghetti**: In the third approach there are no layers at all.

If these approaches exist there are probably some reasons behind each of them, even trivial ones, such as lack of knowledge. To rule out a lack of knowledge let's take a closer look at this topic.

Simplifying, by design, the master PLD layered program design pattern applies to the program as one whole - keeping in mind - that the program is just a text. A program is just a text compliant with a selected programming language. Hence the pattern including the layers and layers relationship must be expressed using terminology defined by the language itself. Further discussion may depend on the selection of a concrete programming language. Therefore, according to the rules, further discussion is conducted using CSharp as the programming language and Visual Studio as the development environment.

The layered architecture is also an abstract term and must be implemented somehow. High-level programming languages are designed to be more intuitive and user-friendly for human programmers. They usually use the custom types definitions as building blocks that take responsibility for implementing the algorithm/data in concern. To implement the layers I propose **sets of custom-type definitions**. In maths, the set is a group of well-defined entities called members. The set notion is well known from high school education, hence we may skip deep diving into this theory. In the proposed approach the well-defined entity is a custom type - a language construct. The only important thing is how to recognize the membership. There must be a boundary that we can use to distinguish if a type belongs to the selected set or not. To make the layer unambiguous it must be assumed that any type belongs only to one set, to one layer. This way we can convert the discussion about mathematical sets to an examination of types grouping. Now we must answer a question about how to recognize the membership of a type. In other words the fact of being a member of a selected group.

The namespace construct could be a relief to help make up a boundary of a set and finally of a layer. Namespaces are used to organize and provide a level of separation of program parts and to avoid name collisions. The namespace unique name could be used as a prefix of an identifier of the definition to make the full name unique in the program scope. On the other hand, the namespace can also be considered a container or an organization unit of definitions. This concept perfectly fits the idea of grouping or formally enforcing set membership of types. Let's examine how this works in context of the MVVM programming pattern withe the goal to build a Graphical User Interface (GUI for short).

### 3.2. View - Inversion of Control

If the application is to be built according to the MVVM model, we can decide how the window should look only in the View layer. In the layer below we can decide when it should be displayed. Displaying another window, often called a pop-up, is the result of clicking on the basic window key, which is handled in the view model layer, which is a separate project in our case. Let me remind you that a window is an object of some type. In this scenario, we ask for the `ViewModel` to create this object and display it. Consequently, as part of this service, the `ViewModel` layer should instantiate an appropriate pop-up window object and display it, but this requires a reference to the `View` layer and, as a result, leads to recursion that is prohibited here. When multiple projects are used, it is not only a problem of breaking the rules, but also the inability to add cyclical dependence of projects to each other.

After taking a closer look at the example implementation of the `View` layer in the `MainWindow` class, we notice that the empty code-behind rule is not fully held. The exception we see here is solely related to ensuring layer decoupling - i.e. ensuring hierarchical references.


### 3.3. MVVM as Sub-layers of the Presentation Layer

The MVVM is a design pattern commonly used in Windows Presentation Foundation (WPF for short) to structure the code and separate concerns. Let me stress, here, we have the word _"presentation"_ in the name, in the context of the master architecture, we can assume that the layers of the MVVM model contribute to the presentation layer of the PLD master architectural model. Assuming that MVVM is an implementation of the Presentation layer in the master PLD model let's next answer a question: how to derive implementation methodology of the MVVM from the general layered model concept?

A namespace is a linguistic construct that contains a group of type definitions, so it is a good candidate for implementing also MVVM layers. It's also easy to isolate text within a namespace of your choice. So, using filters, let's remove all organizational elements related to the tool. In the example, it is the folder and projects. After tidying up the diagram, we see that the MVVM layers have been implemented as namespaces. Within layers, there may be additional namespaces containing definitions of auxiliary types. For example, I have defined two auxiliary classes that facilitate the implementation and control of the correct use of this pattern and provide the functionality needed for the `ViewModel` layer. Implementations of two interfaces, namely `INotifyPropertyChange` and `ICommand` may be found in the `MVVMLight` sub-namespace.

This concept is illustrated in the figure below. In this diagram, we can recognize three main layers created using the proposed method. It was generated from the text gathered in the `GraphicalData` folder. This image has been created using a code analytic tool embedded in the development environment. Thanks to this image - after removing unimportant parts - we can distinguish three layers View, ViewModel, and Model. It is also worth noting that internally, inside the layer circular references are perfectly OK. Let me recall that only between layers we must have unidirectional top-down dependencies.

![MVVM Layered Architecture](.Media/MVVMLayeredArchitecture.png)

As a side effect of using the embedded tool to analyze the architecture of the program text, there are different kinds of arrows. We may safely neglect this. This tool is not a subject of our examination.

### 3.4. MVVM Implementation Using Project Concept

Namespace construct is one option to distinguish sets and finally create layers. The purpose of implementing layers using independent projects may be to minimize the program area dependent on technology. On the other hand, minimizing the number of projects in a solution reduces maintenance costs and dependency hell. Hence, if there are no special reasons it may not be worth forcing separate projects. However, here - for the education purpose - we are dealing with a scenario where portability is critical, so separating projects is justified. Let me give you an example. A graphical user interface should be implemented differently for desktop devices with high-resolution monitors and smartphone devices. So let's try to put forward the thesis that layers can be implemented using projects.

From the development environment point of view, a project is just an organization unit within the solution. Solution and project are concepts related to the tool like Visual Studio, and not to the program text consistent with the selected programming language. This would indicate that using projects to implement layers is not a good idea. It looks like this concept has nothing in common with the programming language. However, we must consider an important project feature within a solution - the project is also a compilation unit. Therefore, its content must be consistent and compliant with a programming language. Hence, despite everything, it can be treated as the boundary of a set containing type definitions. Unidirectional and hierarchical top-down relationships can be implemented using the References/Dependencies branches. Additionally, in the case of projects compared to namespaces, type definitions visibility (encapsulation - OOP paradigm) control can be employed, which should further facilitate the implementation of a layer as a set of type definitions and hierarchical unidirectional relationships between layers. The same code snippet is shown in the figure below but now exposes projects as implementation of the MVVM layers.

![MVVM Layered Architecture Using Projects](.Media/MVVMLayeredArchitectureProjectBased.png)

This example proves that while implementing the MVVM pattern it is possible to gather text describing the interface graphics - the View layer - in a separate project. It groups all references to WPF technology, namely to a certain group of types, whose definitions are tightly coupled with execution platform features.

Let's start with the fact that our sample program has three projects. The first one with the `View` suffix is ​​based on Framework Net 6.0 for Windows OS, so it is dedicated to a specific implementation of the .NET library. This limits the portability on other hardware and system platforms, but there is no option because WPF is a technology dedicated to Windows. The remaining projects are based on .NET Standard. .NET Standard is an abstract definition of the .NET library, i.e. it does not contain any implementation, only abstract definitions. Thanks to this, projects based on the .NET standard are portable and once the library is compiled, it can be deployed on any system platform for which there is a .NET implementation. Without going into details, we can illustrate the relationship between these projects as follows.

### 3.5. MVVM implementation Conclusion

Using this example, let's define a few simplified rules that will make it easier to implement the MVVM programming pattern.

1. Only definitions that refer to types defined in the PresentationFramework should be gathered in the View layer. 
2. These definitions can only refer to types defined in the ViewModel layer. 
3. By design, include text written in XAML and empty definitions in the code-behind part in the View layer.
4. In the `ViewModel` layer, define all types which are  bound to the properties of the controls.
5. Placing definitions of auxiliary types here to meet the requirements for this layer is optional. Due to the universal nature of these implementations, we often use external libraries.
6. To put it simply, the Model layer is everything else related to implementation of the Presentation layer of the master PLD programming pattern. The Model layer encapsulates the functionality and data-related operations relevant to implementing a graphical user interface and ensuring a clean separation from the UI rest of the program. It allows developers to work on business logic independently of the view, making the application easier to test, maintain, and evolve.

Let me stress again. The `MVVM` is a programming pattern well suited to implementing the presentation layer in the Presentation, Logic, and Data (PLD) master programming pattern. By design, to implement the MVVM collect types in namespaces to maintain only hierarchical references between them. Therefore, a critical error for a layered architecture is if cyclic references occur between namespaces, i.e. if starting from any layer and moving along the dependency arrows you manage to return to the same namespace. You should also avoid situations where namespaces do not refer exclusively to the underneath layer. 

When implementing layers using namespaces, we must consider the problem that these layers are not visible in the solution with the naked eye. A trade-off seems to be keeping folder names and namespaces in sync. The relationship is loose, but when you create a new class in a selected folder, it is added to a namespace whose name is created as a hierarchical combination of the default name, the names of the folders that make up the hierarchy, and with a suffix determined by the name of the final folder in the hierarchy.

### 3.6. Layered architecture Benefits

Hierarchical architecture is often contrasted with spaghetti architecture if spaghetti can be called architecture at all. To prove there is no alternative let's summarize what we got in return for the layered architecture.

1. Separating the layers allows you to carry out design work independently assuming that the API, i.e. the layer interface, is abstract. This way, the GUI can be developed in parallel.
2. We can employ additional specialists and reduce the product development time and time to market.
3. Layered architecture enables portability from platform to platform.
4. The lack of cyclic references improves modifications and limits side effects. This way maintenance costs can be reduced.
5. Efficiency of the design process may be increased by applying the principle of separation of concerns, i.e. good planning of layers will avoid being distracted by solving several threads at the same time.
6. Layers can not only be implemented into separate projects but deployed on other physical machines. (a) Executing the same layer in parallel on many computers horizontal scalability is deployed. (b) The ability to execute individual layers on independent hardware platforms means vertical scalability.

## 4. Bindings - User Interface Interoperability

### 4.1. Coupling Controls with Data

Let's look at an [example][TextBox] where the `TextBox` control is used. Its task is to expose a text on the screen, i.e. a stream of characters. The current value, so what is on the screen, is provided via the `Text` property. By design, it allows reading and writing `string` value. The equal sign after the `Text` identifier must mean transferring the current value to/from the selected place. We already know that the selected place must be a property of some object. The word `Binding` means that it is attached somehow to [ActionText][ActionText]. Hence, the [ActionText][ActionText] identifier is probably the name of the property defined in one of our types. Let's find this type using the Visual Studio context menu navigation. As we can see, it works and the property has the name as expected.

![asas](.Media/TextBox-ActionText.gif)

### 4.2. DataContext

As you can notice, the navigation works, so VisualStudio has no doubts about the type of instance this property comes from. If Visual Studio knows it, I guess we should know it too. The answer to this question is in these three lines of the `MainWindow` XAML definition.

``` xaml
    <Window.DataContext>
      <vm:MainViewModel />
    </Window.DataContext>
```

Let's start with the middle line, where we have the full class name. The namespace has been replaced by the `vm` alias defined a few lines above. The class definition has been opened as a result of previous navigation to a property containing the text for the `TextBox` control. Let's consider what the class name means here. For the sake of simplicity, let's first look up the meaning of the `DataContext` identifier. It is the name of the property. It is of the object type. The `object` is the base type for all types. Since it's a property, we can read or assign a new value to it. Having discarded all the absurd propositions, it is easy to guess that the `MainViewModel` identifier here means a parameter-less constructor of the `MainViewModel` type, and this entire fragment should be recognized as the equivalent of an association statement to the `DataContext` property of a newly created instance of the `MainViewModel` type. In other words, it is equivalent to the following statement

``` CSharp
  DataContext = new MainViewModel();
```

Finally, at run-time, we can consider this object as a source and repository of process data used by the user interface. From a data point of view, it creates a kind of mirror of what is on the screen.

### 4.3. Binding

Let's go back to the previous example with the `TextBox` control and coupling its `Text` property with the [ActionText][ActionText] property from the class whose instance was assigned to `DataContext`. Here, there is a magic word `Binding` that may be recognized as a virtual connection to transfer values between. When asked how this happens and what the word `Binding` means, i.e. when asked about the semantics of this notation, I usually receive an answer like this it is some magic wand, which should be read as an internal implementation of WPF, and `Binding` is a keyword of the XAML language. This explanation would be sufficient, although it is a colloquialism and simplification. Unfortunately, at least, we need to understand when this transfer is undertaken. The answer to this question is fundamental to understanding the requirements for the classes that can be used to create an object whose reference is assigned to the `DataContext` property. The main goal is to keep the screen up to date. To find the answer, let's try to go to the definition of this word using the context menu or the F12 key.

![sdsds](.Media/TextBox-ActionText.gif) <!-- zrobić gifa -->

It turns out that `Binding` is the identifier of a class or rather a constructor of this class. This must consequently mean that at this point a magic wand means creating a `Binding` instance responsible for transferring values ​​from one property to another. The properties defined in the `Binding` type can be used to control how this transfer is performed. Since this object must operate on unknown types, reflection is used. This means that this mechanism is rarely analyzed in detail. The colloquial explanation previously given that the transfer is somehow carried out is quite common because it has its advantages in the context of describing the effect.

The [AttachedProperty][AttachedProperty] class definition simulates this action providing the functionality of assigning a value to the indicated property of an object whose type is unknown.

### 4.4. INotifyPropertyChange

As I mentioned earlier, using properties defined in the `Binding` type, we can parameterize the transfer process and, for example, limit its direction. Operations described by XAML text are performed once at the beginning of the program when the MainWindow instance is created. Therefore, we cannot here specify the point in time when this transfer should be carried out. To determine the point in time when an object of the `Binding` type should trigger this transfer, let's look at the structure of the [ActionText][ActionText] property from the `MainViewWindow` type. Here we see that the setter performs two additional methods. In the context of the main problem, the `RaisePropertyChanged` method is invoked. This method activates an event required to implement the `INotifyPropertyChanged` interface. This event is used by objects of the `Binding` class to invoke the current value transfer. By activating this event, we call methods whose delegates have been added to the event. If the class does not implement this interface or the activation of the `PropertyChanged` event required by the mentioned interface does not occur, the new value will not be passed to and will not be refreshed on the screen - the screen will be static.

It is typical communication where the `MainViewWindow` instance notifies about the selected value change and the `MainWindow` instance pulls a new value and displays it. In this kind of communication the `MainViewWindow` has a publisher role and the `MainWindow` is the subscriber. It is worth stressing that communication is a run-time activity. It is initiated in the opposite direction compared with the design time types relationship. Hence we can recognize it as an inversion of control or a callback communication method.

### 4.5. ICommand

The analysis of the previous examples shows the screen content synchronization mechanism with the property values change ​​of classes dedicated to providing data for the GUI. Now we need to explain the sequence of operations carried out as a consequence of issuing a command by the user interface, e.g. clicking on the on-screen key - `Button`. We have an example here, and its `Command` property has been associated, as before, with something with the identifier [ShowTreeViewMainWindowCommend][ShowTreeViewMainWindowCommend]. Using navigation in Visual Studio, we can go to the definition of this identifier and notice that it is again a property from the `MainViewWindow` class, but this time of the type `ICommand`. This time, this binding is not used to copy the property value but to convert a key click on the screen, e.g. using a mouse, into calling the `Execute` operation, which is defined in the `ICommand` interface and must be implemented in the class that serves to create an object and substitute a reference to it into this property.

For the sake of simplicity, the `ICommand` interface is implemented by a helper class called [RelayCommand][RelayCommand]. In the constructor of this class, you should place a delegate to the method to be called as a result of the command execution. The second constructor is helpful in dynamically changing the state of a button on the screen. This can block future events, i.e. realize a state machine. And this is exactly the scenario implemented in the examined example program. Please note the `RaiseCanExecuteChanged` method omitted in the previous explanation.

[ExDataManagement]: https://github.com/mpostol/TP/blob/5.13-India/
[Show]:             https://learn.microsoft.com/dotnet/api/system.windows.window.show
[Control]:          https://learn.microsoft.com/dotnet/api/system.windows.controls.control
[Visibility]:       https://learn.microsoft.com/dotnet/api/system.windows.uielement.visibility
[IsEnabled]:        https://learn.microsoft.com/dotnet/api/system.windows.uielement.isenabled


[MainWindow]:       https://github.com/mpostol/TP/blob/5.13-India/ExDataManagement/GraphicalData/GraphicalData.View/MainWindow.xaml#L1-L46
[OnInitialized]:    https://github.com/mpostol/TP/blob/5.13-India/ExDataManagement/GraphicalData/GraphicalData.View/MainWindow.xaml.cs#L27-L33
[TextBox]:          https://github.com/mpostol/TP/blob/5.13-India/ExDataManagement/GraphicalData/GraphicalData.View/MainWindow.xaml#L44
[ActionText]:       https://github.com/mpostol/TP/blob/5.13-India/ExDataManagement/GraphicalData/GraphicalData.ViewModel/MainViewModel.cs#L74-L83
[AttachedProperty]: https://github.com/mpostol/TP/blob/5.13-India/ExDataManagement/DataStreams/DataStreams/Reflection/AttachedProperty.cs#L20-L27
[RelayCommand]:     https://github.com/mpostol/TP/blob/5.13-India/ExDataManagement/GraphicalData/GraphicalData.ViewModel/MVVMLight/RelayCommand.cs#L24-L101
[ShowTreeViewMainWindowCommend]: https://github.com/mpostol/TP/blob/5.13-India/ExDataManagement/GraphicalData/GraphicalData.ViewModel/MainViewModel.cs#L104-L107
