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
  - [2.3. Displaying Pop-up Window](#23-displaying-pop-up-window)
- [3. Modification of Screen Image](#3-modification-of-screen-image)
  - [3.1. Introduction](#31-introduction)
  - [3.2. Visibility](#32-visibility)
  - [3.3. Modification of other features](#33-modification-of-other-features)
- [4. Code-behind](#4-code-behind)
  - [4.1. Responsibility](#41-responsibility)
  - [4.2. Dependency injection](#42-dependency-injection)
- [5. Bindings - Layers Interoperability](#5-bindings---layers-interoperability)
  - [5.1. Coupling Control Types with Data Source](#51-coupling-control-types-with-data-source)
  - [5.2. DataContext](#52-datacontext)
  - [5.3. Binding](#53-binding)
  - [5.4. DataBinding](#54-databinding)
  - [5.5. INotifyPropertyChange](#55-inotifypropertychange)
  - [5.6. ICommand](#56-icommand)
- [6. Layered Architecture](#6-layered-architecture)
  - [6.1. Introduction](#61-introduction)
  - [6.2. Layer Implementation using project concept](#62-layer-implementation-using-project-concept)
  - [6.3. MVVM as Sub-layers of the Presentation Layer](#63-mvvm-as-sub-layers-of-the-presentation-layer)
  - [6.4. Code Map Diagram](#64-code-map-diagram)
  - [6.5. Implementacja warstw ogólnej architektury programu](#65-implementacja-warstw-ogólnej-architektury-programu)
  - [6.6. Layered architecture Benefits](#66-layered-architecture-benefits)
  - [6.7. View - Inversion of Control](#67-view---inversion-of-control)

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

According to well-known principles of software engineering, the program should have a layered architecture. Layered architecture means that one layer may be recognized as upper and a second one as a lower one although there are usually more layers. So that we can distinguish which one is higher. To achieve this architecture only the upper layer may refer to the underneath layer. In contrast, the lower layer must be composed in such a way that it doesn't depend on the upper layer. Hence, the inter-layer reference must be unidirectional, often called hierarchical. Because the hierarchy should be vertical the relationship should be top to bottom.

The program should have a layered structure - it's easy to say, but what is a layer? The program is text and has a stream structure instead - it is a sequence of characters. Of course, in this principle the concept of a layer is abstract, but to say that the program architecture is layered, we must somehow implement this concept so that everyone knows what a layer is. We will learn a specific implementation called MVVM which stands for model, view, and view-model.

### 2.3. Displaying Pop-up Window

It is not difficult to imagine a scenario in which, when performing a certain operation, we need additional details from the user, for example, a file name. Obtaining this information requires communication with the user, which means engaging the topmost layer and displaying a pop-up window. However, the layer underneath should be constructed so that it is not aware of the existence of the upper layer, because it is above it. In this scenario, we will look for help in the Dependency Injection programming pattern. Those who have already heard something about this pattern may feel anxious that it is not another point in the discussion, but an introduction to a completely new topic. The concerns are justified, because many publications have already been written on this topic, and many frameworks and derivative terms have been created. An example is Inversion of Control. Without getting into academic disputes and deciding whether these publications and solutions concern perse dependency injection or rather the automation of dependency injection, we will try to solve the problem and separate the layers to avoid cyclical references between them, i.e. recursion in the architecture.

## 3. Modification of Screen Image

### 3.1. Introduction

Let's start by determining how we can bring the content of the interface to "make it alive". The phrase "make it alive" is a colloquialism that means **dynamically modifying image features**, editing data through it, and responding to user commands. In other words, the task is as follows: interconnecting the previously generated GUI image with the process data.

The basic solution that we already know is showing on the screen a Window. The primary Window is opened by the environment. However, in this project, we have one more window that appears after clicking one of the keys. Without going into details, let's assume that clicking a key causes some hard work to be performed in the background - for example, a file is being read and analyzed - and as a result, another window is displayed - a typical pop-up, if everything goes well. This means that the View layer is responsible for what the window should look like. However, in the ViewModel layer underneath, we must decide when it should be exposed on the screen. It is worth recalling here that a window is a class that inherits from the Window class and for the window to appear, you need to call the `Show` method, which we can see in the Window class definition preview.

The basic solution that we already know is showing on the screen a Window. The primary Window is opened by the environment. However, in this project, we have one more window that appears after clicking one of the keys. Without going into details, let's assume that clicking a key causes some hard work to be performed in the background - for example, a file is being read and analyzed - and as a result, another window is displayed - a typical pop-up, if everything goes well. This means that the View layer is responsible for what the window should look like. However, in the ViewModel layer underneath, we must decide when it should be exposed on the screen. It is worth recalling here that a window is a class that inherits from the Window class and for the window to appear, you need to call the `Show` method, which we can see in the Window class definition preview.

### 3.2. Visibility

> _**ChatGPT**_: The `Control` class is a part of the inheritance chain for control types. The `Control` class is a base class for most of the user interface elements. It provides common functionality that all controls share, such as styling, layout, and input handling. So, when you create a new control type like these controls inherit from the `Control` class and therefore gain all the properties, methods, and events defined in the `Control` class. A `UserControl` is a customizable control that allows you to combine existing controls and add custom logic to create a reusable user interface component. It's useful for encapsulating complex UI parts that you can use across different parts of your program.

Looking at the content of the definition of this class written in XAML, we see that the displayed controls create a tree structure, i.e. the references of internal controls, for example, `TreeView`, are added to the collection of external objects. The containment hierarchy is determined by the structure of the XML file. Theoretically, by manipulating the contents of these collections by adding and removing elements from them, you can influence the content of the window. Since this is quite an unusual procedure and this functionality can be easily replaced, we will not analyze this approach further, it is simply a waste of time.

Instead of adding controls to the parent control's collection, we can use the Visibility property. It takes one of the three values ​​that we see on the screen. Therefore, a practical tip is to add all the controls that may appear on the screen at the stage of designing a static image and then dynamically change this property as needed.

Sometimes the controls may be visible on the screen but in static mode. An example of such a mode is an inactive key, i.e. one that is visible on the screen but cannot be clicked and therefore issue an appropriate command. Another property, this time called IsEnabled, can be used for this purpose. I'm changing it statically here, but in reality, it has to be done dynamically depending on the state the process is in. It is worth mentioning here that the XAML language allows you to define the GUI as a state machine and control its appearance depending on the state the interface is in. This allows us to group controls and control them by changing the state of the entire part of the user interface, not just by changing individual properties of the controls. Since our goal here and now is not to learn the XAML language, I refer anyone interested in learning this mechanism in detail and the XAML language in general to other materials dedicated to this topic.

### 3.3. Modification of other features

Similarly, by modifying the values ​​of various properties, we change other features of the controls, such as color, shape, filling method, etc. There are many of them, so the previously learned Blend editor may be useful in this respect.

What to modify to revitalize the interface is the first important question. But now we come to the second question, namely where to make modifications. Of course, there are several answers to this question, and let's now try to analyze them and make some general practical recommendations.

We already know the first answer to the question of where to modify, that place is, of course, the XAML text. Modification in XAML has the disadvantage that it is essentially limited to constant substitution. It should be emphasized here that default values ​​are already substituted for each property defined by the controls, so there is no need to modify anything for typical behavior. An example is Visibility, whose default value is of course Visible. Of course, this language allows us to assign not only constants but its use to implement algorithms not directly related to GUI control is not a good idea.

## 4. Code-behind

### 4.1. Responsibility

The XAML text and its associated CSharp text, called code behind, form one class (one definition) because they are partial definitions. Of course, all properties can therefore be modified in the code behind. However, this solution has several drawbacks. Let's narrow the discussion only to the following three that can be recognized as excluding this approach.

1. The first drawback is related to the obvious violation of the principle of **separation of concerns**. This principle means avoiding the need to divide attention and encourages focusing only on single, well-separated issues. Probably,  this is a result of the human limitation of thought processes when solving a multi-threaded problem. In our case, if we are working on the GUI, we are not also working on process automation, i.e. algorithms implementation related to the process in concern. Let's focus solely on human-machine communication.

There is another very tangible disadvantage, namely one of the popular ways of checking the correctness of a program is the use of unit tests. In addition to testing for correctness, they are also useful for checking whether significant modifications have been made to the program text that may have side effects and require inclusion in other parts of the program. Additionally, and somewhat unusually, I use tests in examples to show selected features of the solutions discussed, and not to check the correctness of the examples discussed. Unit tests have the property that they do not support testing of a graphical user interface. Hence, to be used as widely as possible, the concerns of graphical representation and interface behavior controlling this interface should be separated so that independent unit tests can be created for them without the need to run graphics rendering. In our example, I implemented this separation by implementing interface behavior controlling in a separate project implementing the ViewModel layer according to the MVVM pattern.

The next disadvantage is also tangible. In a project dedicated to the GUI, we see a hard dependency, i.e. a reference to **PresentationFramework**. This prevents the results generated here from being used on operating systems other than Microsoft Windows. So the program becomes hard to portable. Placing text here that is not directly related to graphics control violates another principle of programming engineering, namely reusability, so again loosely translated it means the possibility of reusing the text - in this case for another GUI technology. The possibility of re-use translates directly into money because if it is not portable, a similar program text must be written again and, what is worse, it must be maintained later.

To sum up, placing the text of a program implementing any activities related to process data processing in the code-behind, i.e. in this part of the program, violates the principle of separation of concerns, limits the possibility of using unit tests, and limits the portability of the solution. These are limiting remarks and lead to the conclusion - let's not do it, it's not a good idea.

### 4.2. Dependency injection

What about this piece of text? Am I contradicting myself? I will come back to this point, for now, please trust me that this is following the recommendations, and theoretically, this text can be removed, but it is not that simple. Again, the recommendation is the code-behind should not contain any line of code except the required one. This exception is vital here.

Since the place where the user interface comes to life should not be XAML and code-behind, it must be other parts of the program. Here, unfortunately, we encounter a barrier related to type compliance control. Namely, you first need to know these types to control type compatibility. Suppose technologically unrelated projects are to be independent, as is the case with the `GraphicalData' project. In that case, they cannot know these types because they will become dependent on the technology and the elaborate plan will fail.

How to cut this Gordian knot? So far, the discussion has been reactive, ending with a statement of what we cannot do. As we can guess, the solution is, of course, compromise. As a compromise - first - we will limit the roles of the controls that make up the View layer to the role of an intermediary passing data between users of the interface and the layers lying below the View layer. We will return to the layered architecture topic later in this article but as a result of simplifying we can treat the `View` layer as a separate project. Returning to the role of the intermediary, this role of the intermediary is limited to, colloquially speaking, transparently transferring data from and to the screen. Occasionally, as part of this operation, we may provide a conversion operation, e.g. date format depending on the natural language used by the interface user. Additionally, the GUI interface must be responsible for activating appropriate functionality in response to user commands.

The functionality of the scenario in which XAML is only a transparent data relay has been implemented in WPF technology. To transfer data, it must first be downloaded from some source. We don't have much choice here, they have to be objects, or rather their properties - described by types. Since these types must already be related to process data processing, their definition is dedicated to the needs of this process, which is located in the GraphicalData project. The View layer has references to this project. However, when WPF was implemented - and specifically the transfer mechanism - it could not have known these types. Data transfer in WPF is a generic mechanism, so it cannot refer to specific types, although it can have references to those types. This leads to the conclusion that we cannot use type definitions in this process, so what is left is only reflection, which allows us to recreate these definitions during program execution, which should not worry us much, because we are not the ones who have to use them and, consequently, know.

## 5. Bindings - Layers Interoperability

### 5.1. Coupling Control Types with Data Source

Let's look at an example. In the lower right corner of the window, we use a `TextBox` control. Its task is to write and possibly read text, i.e. a stream of characters. The current value, so what is on the screen is provided via the `Text` property. Since we expect reading and writing, the equal sign after the `Text` name must mean transferring the current value to/from the selected place. We already know that this selected place must be a property of some object. The word `Binding` means that it is attached somehow to ActionText. Hence, the ActionText identifier is probably the name of the property defined in one of our types. Let's try to find this type using the Visual Studio context menu navigation. As we can see, it works and the property has the name as expected.

### 5.2. DataContext

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

### 5.3. Binding

Let's go back to the previous example with the `TextBox` control and coupling its `Text` property with the `ActionText` property from the class whose instance was assigned to `DataContext`. Here, there is a magic word `Binding` that may be recognized as an invocation to transfer value between. When asked how this happens and what the word `Binding` means, i.e. when asked about the semantics of this notation, I usually receive an answer like this it is some magic wand, which should be read as an internal implementation of WPF, and `Binding` is a keyword of the XAML language. And this explanation would be sufficient, although it is a colloquialism. Unfortunately, usually, we need to understand when this transfer takes place. The answer to this question is fundamental to understanding the requirements for the classes that can be used to create an object whose reference is assigned to the `DataContext` property. To find the answer, let's try to go to the definition of this word using the context menu or the F12 key.

### 5.4. DataBinding

It turns out that `Binding` is the identifier of a class or rather a constructor of this class. This must consequently mean that at this point a magic wand means creating a `Binding` instance responsible for transferring values ​​from one property to another. The properties defined in this type allow you to control how this transfer is performed. We can see their list here. Since this object must operate on unknown types, reflection is used. This means that this mechanism is rarely analyzed in detail. The colloquial explanation previously given that the transfer is somehow carried out is quite common because it has its advantages in the context of describing the effect. 

> I propose to create a class definition that will simulate this action and provide the functionality of assigning the selected value to the indicated property of an object whose type is unknown.

### 5.5. INotifyPropertyChange

As I mentioned earlier, using properties defined in the `Binding` type, we can parameterize the transfer process and, for example, limit its direction. Operations described by XAML text are performed once at the beginning of the program when the MainWindow instance is created. Therefore, we cannot here specify the time moments in which this transfer should be carried out. To determine the moments when an object of the `Binding` type should trigger this transfer, let's look at the structure of the `ActionText` property from the `MainViewWindow` type. Here we see that the setter performs two methods in addition to assigning values ​​to the local field. In the context of the problem posed, we need to call the RaisePropertyChanged method. This method activates an event that is required to implement the `INotifyPropertyChanged` interface. This event is used by objects of the `Binding` class to invoke the transfer of values. By activating this event, we call methods called handlers whose delegates have been added to the event, i.e. we indirectly perform this transfer through these handlers. If the class does not implement this interface or the activation of the PropertyChanged event required by the mentioned interface does not occur, the new value will not be passed to and will not be refreshed on the screen - the screen will be static.

It is typical communication where the `MainViewWindow` instance notifies about the selected value change and the `MainWindow` instance pulls a new value and displays it. In this kind of communication the `MainViewWindow` has a publisher role and the `MainWindow` is the subscriber. It is worth stressing that communication is a run-time activity. It is initiated in the opposite direction compared with the design time types relationship. Hence we can recognize it as an inversion of control or a callback communication method.

### 5.6. ICommand

The analysis of the previous examples shows the operation of the screen content synchronization mechanism with the property values ​​of classes dedicated to providing data for the GUI, which creates a kind of memory replica of the screen. Now we need to explain the sequence of operations carried out as a consequence of issuing a command by the user interface, e.g. clicking on the on-screen key - `Button`. We have an example here, and its `Command` property has been associated, as before, with something with the identifier `ShowTreeViewMainWindowCommend`. Using navigation in Visual Studio, we can go to the definition of this identifier and notice that it is again a property from the `MainViewWindow` class, but this time of the type `ICommand`. This time, this binding is not used to copy the property value but to convert a key click on the screen, e.g. using a mouse, into calling the `Execute` operation, which is defined in the `ICommand` interface and must be implemented in the class that serves to create an object and substitute a reference to it into this property.

For the sake of simplicity, this interface is implemented by a helper class called `RelayCommand`. In the constructor of this class, you should place a delegation to the method to be called as a result of the command execution. Please follow the use of the second constructor. The second constructor is helpful in dynamically changing the active state of a key. This can block future events, i.e. realize a state machine. And this is exactly the scenario implemented in the sample program. Please note the `RaiseCanExecuteChanged` method omitted in the previous explanation.

## 6. Layered Architecture
  
### 6.1. Introduction

The next topic is a layered model called MVVM. It stands for model, view, view-model. According to good engineering practices, the program should be constructed using a layered design pattern. A layer is an abstract concept recognized as a program architecture design pattern formed as a hierarchy of layers where the upper layer refers only to the underneath layer.

In other words, we will talk about the program architecture keeping in mind that the program is only a sequence of characters. Here, unfortunately, I often encounter the practice of disregarding the principles of layered program structure, because it complicates, and limits, and it is easier and possible to live without it, etc. Let us note that we have three significantly different worlds here. The first is the model mentioned in the topic, i.e. MVVM. We don't see any signs of his presence yet, but he appeared in the context of engineering a graphical user interface. The second one is a typical program architecture, which also distinguishes three layers, but this time called presentation, logic, and data. The third world lacks of layers. If these worlds exist there are probably some reasons behind each of them, even trivial ones, such as lack of knowledge. To rule out a lack of knowledge, let's take a closer look at this topic.

### 6.2. Layer Implementation using project concept

Let's start with the fact that our sample program has three projects. The first one with the View suffix is ​​based on Framework 4.61, so it is dedicated to a specific implementation of the .NET library. This limits the portability on other hardware and system platforms, but there is no option because WPF is a technology dedicated to Windows. The remaining projects are based on .NET Standard. .NET Standard is an abstract definition of the .NET library, i.e. it does not contain any implementation, only abstract definitions. Thanks to this, projects based on the .NET standard are portable and once the library is compiled, it can be implemented on any system platform for which there is a .NET implementation. Without going into details, we can illustrate the relationship between these projects as follows. There is a legend for those curious about what the individual arrows mean. Now, for the sake of simplicity, we are only interested in the direction of these arrows.

### 6.3. MVVM as Sub-layers of the Presentation Layer

The MVVM  is a design pattern commonly used in Windows Presentation Foundation to structure the code and separate concerns. Hence, we have the word presentation in the name, in the context of the general architecture, we can assume that the layers of the MVVM model contribute to the presentation layer of a general architectural model. Based on this detailed analysis, let's try to answer a more general question: what is a layer, and how to implement it?

Before examining the gathered examples, first I must remind you that the algorithm development is far beyond the scope of our discursion. Second, to make the discursion practical we must apply the layered pattern to the program text but not to the thinking process. The main goal is to apply the layered pattern rules directly to the program text as a result of the implementation of the algorithm derived from a research process. To promote a practical approach, I propose investigating this issue in the context of the semantics and syntax of a selected programming language. Although we are using a concrete development environment, the main hope is that the proposed approach is easily portable. All the examples in concern have been added to the `Graphical Data` folder. Check out the solution `ExDataManagement`solution to follow me in this respect.

We already proved that theoretically a layered program design pattern is very beneficial. Simplifying, by design, layered program design pattern applies to the program as one whole - keeping in mind - that the program is just a text. A program is just a text compliant with a selected programming language. Hence the pattern including the layers and layers relationship must be expressed using terminology defined by the language itself. Further discussion may depend on the selection of a concrete programming language. Therefore, according to the rules the further discussion is conducted using CSharp as the programming language and Visual Studio as the development environment.

The layered architecture is also abstract term and therefore must be implemented somehow. High-level programming languages are designed to be more intuitive and user-friendly for human programmers. They usually use the custom types definitions as building blocks that take responsibility to implement the algorithm/data in concern. To implement the layers I propose **sets of custom-type definitions**. In maths, the set is a group of well-defined entities called members. The set notion is well known from the background school education, hence we may skip deep diving into this theory. In the proposed approach the well-defined entity is a custom type - a language construct. The only important thing is how to recognize the membership. There must be a boundary that we can use to distinguish if a type belongs to the selected set or not. To make the layer unambiguous it must be assumed that any type belongs only to one set, to one layer. This way we can convert the discussion about mathematical sets to an examination of types grouping. Now we must answer a question about how to recognize the membership of a type. In other words the fact of being a member of a selected group.

The namespace construct could be a relief to help make up a boundary of the set and finally of a layer. Namespaces are used to organize and provide a level of separation of program parts and to avoid name collisions. The namespace unique name could be used as a prefix of an identifier of the definition to make the full name unique in the program scope. On the other hand, the namespace can also be considered a container or an organization unit of definitions. This concept perfectly fits the concept of grouping or more formally enforcing set membership of types.

This concept is illustrated in the figure below. In this diagram where we can recognize three main layers created using the proposed method. It was generated from the text gathered in the `Graphical Data` folder. This image has been created using a code analytic tool embedded in the development environment. After removing not important parts, thanks to this image we can distinguish three layers, called View, ViewModel, and Model. It is also worth notifying that internally inside the layer circular dependencies are perfectly OK. Let me recall that only between layers we must have unidirectional top-down dependencies.  As a side effect of using the embedded tool to analyze the architecture of the program text, there are different kinds of arrows. We may safely neglect this. This tool is not a subject of our examination.

![MVVM Layered Architecture](.Media/MVVMLayeredArchitecture.png)

The purpose of implementing layers using independent projects may be to minimize the program area dependent on technology.  On the other hand, minimizing the number of projects in a solution reduces maintenance costs and dependency hell. Hence, if there are no special reasons it may not be worth forcing separate projects. However, here we are dealing with a scenario where portability is critical, so separating projects is justified. Let me give you an example. A graphical user interface should be implemented differently for desktop devices with high-resolution monitors and smartphone devices. So let's try to put forward the thesis that layers can be implemented using projects.

From the development environment point of view, a project is just an organizational unit within the solution. Solution and project are concepts related to the tool like Visual Studio, and not to the program text consistent with the selected programming language. This would indicate that using projects to implement layers is not a good idea. It looks like this concept has no direct connection with the programming language. However, we must consider an important project feature within a solution- the project is also a compilation unit. Therefore, its content must be consistent and compliant with a programming language. Hence, despite everything, it can be treated as the boundary of a set of type definitions. Unidirectional and hierarchical top-down relationships can be implemented using the References/Dependencies branches. Additionally, in the case of projects compared to namespaces, type definitions visibility control can be employed, which should further facilitate the implementation of a layer as a set of type definitions and hierarchical unidirectional relationships between layers. The same as the previous code snippet is shown in the figure below but now employing projects as implementation of the MVVM layers.

![MVVM Layered Architecture Using Projects](.Media/MVVMLayeredArchitectureProjectBased.png)

### 6.4. Code Map Diagram

Let's start the analysis of the implementation of the MVVM pattern and the implementation of the Model, View, and ViewModel layers by generating a diagram showing various relationships occurring in the text of the example program. We start with a project containing text describing the interface graphics, i.e. the View layer. Let me remind you that it was implemented in a separate project grouping all references to WPF technology, i.e. to a certain group of types whose definition is embedded in precisely defined external realities, in this case of the operating system. In the presented diagram we have three components: The solution folder, the project, and, after expanding the project, its namespaces. Let's add to the diagram projects containing the rest of the program. After extending it shows the content. 

Let's examine in detail the implementation of MVVM layers using these examples. The layer is an abstract notion, hence we must use some language construct that will be used for this purpose. In other words, the program is text, so the layer must be a separate fragment of this text.

A namespace is a linguistic construct and contains a group of type definitions, so it seems like a good candidate for implementing layers. It's also easy to isolate text within a namespace of your choice. So, using filters, let's remove all organizational elements related to the tool. In this case, it is the folder and projects. After tidying up the diagram, we see that the layers have been implemented as namespaces. Within the namespaces creating the layers, there may be additional namespaces containing definitions of auxiliary types within the MVVMLight namespace, I have defined two auxiliary classes that facilitate the implementation and control of the correct use of this pattern and provide the functionality needed for the ViewModel layer. It contains an implementation of two interfaces, namely INotifyPropertyChange and ICommand.

Using this example, let's define a few simplified rules that will make it easier to implement the MVVM pattern. 

1. Only definitions that refer to types defined in the PresentationFramework should be gathered in the View layer. Additionally, these definitions can only refer to types defined in the ViewModel space. By design, we only include text written in XAML and empty definitions in the code-behind part in the View layer. 
2. In the ViewModel layer, we define all types whose objects are bound to the properties of the controls. Placing definitions of auxiliary types here to meet the requirements for this layer is optional. Due to the universal nature of these implementations, we often use external libraries. 
3. To put it simply, the Model layer is everything else. The Model layer encapsulates the functionality and data-related operations relevant to implementing a graphical user interface and ensuring a clean separation from the UI rest of the program. It allows developers to work on business logic independently of the view, making the application easier to test, maintain, and evolve.

Let me stress again. The MVVM is a programming pattern well suited to implementing the presentation layer in the Presentation, Logic, and Data master programming pattern.

### 6.5. Implementacja warstw ogólnej architektury programu

The same can be done for other namespaces, namely collect types to maintain only hierarchical references between them. Therefore, a critical error for a layered architecture is if cyclic references occur between namespaces, i.e. if starting from any layer and moving along the dependency arrows you manage to return to the same namespace. You should also avoid situations where namespaces do not refer exclusively to the underneath layer. When implementing layers using namespaces, we must consider the problem that these layers are not visible in the solution with the naked eye. A trade-off seems to be keeping folder names and namespaces in sync. The relationship is loose, but when you create a new class in a selected folder, it is added to a namespace whose ID is created as a hierarchical combination of the default name, the names of the folders that make up the hierarchy, and with a suffix determined by the name of the final folder in the hierarchy.

### 6.6. Layered architecture Benefits

Hierarchical architecture is often contrasted with spaghetti architecture if spaghetti can be called architecture at all. To prove there is no alternative let's summarize what we got in return for the layered architecture.

1. Separating the layers allows you to carry out design work independently assuming that the API, i.e. the layer interface, is abstract. This way, the GUI can be developed in parallel. There are two benefits: we can employ additional specialists and shorten the product development time.
1. Layered architecture enables portability from platform to platform.
1. The lack of cyclic references improves modifications and limits side effects. This way maintenance costs can be reduced.
1. Efficiency of the design process may be increased by applying the principle of separation of concerns, i.e. good planning of layers will avoid being distracted by solving several threads at the same time.
1. Layers can not only be implemented into separate projects but implemented on other physical machines.  (a) Executing the same layer in parallel on many computers horizontal scalability is deployed. (b) The ability to execute individual layers on independent hardware platforms means vertical scalability.

### 6.7. View - Inversion of Control

If the application is to be built according to the MVVM model, we can decide how the window should look only in the View layer. In the layer below we can decide when it should be displayed. Displaying another window, often called a pop-up, is the result of clicking on the basic window key, which is handled in the view model layer, which is a separate project in our case. Let me remind you that a window is an object of some type. In this scenario, we ask for the ViewModel to create this object and display it. Consequently, as part of this service, the ViewModel layer should instantiate an appropriate pop-up window object and display it, but this requires a reference to the View layer and, as a result, leads to recursion that is prohibited here. When multiple projects are used, it is not only a problem of breaking the rules, but also the inability to add cyclical dependence of projects on each other.

After taking a closer look at the example implementation of the View layer in the MainWindow class, we notice that the empty code-behind rule is not fully held. The exception we see here is solely related to ensuring layer decoupling - i.e. ensuring hierarchical references. I leave the detailed analysis as homework.
