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

# Data Streams Implementation Examples

## Introduction

Let's look at the folder containing example files. We have different files here, but similar descriptive data, i.e. metadata, are defined for all of them. Among these data, location is interesting. For example, we can see that this file is probably not located locally because it does not contain a computer name, which would indicate that it is available on a remote file system. We also have the creation date, modification date, and many other information that may be useful, but the most important thing is, of course, the content of the file.

After double-clicking on the selected file an image will appear. Here we may ask a question - what happened? Well, a program was launched. This program must have been written by some programmer. The program did open this file as input, so the programmer had to know the syntax and semantics that were used in this file. The data contained in the file make it possible to visualize them graphically. This is the first example of graphical representation, but we will return to this issue soon.

## File and Stream Concepts

Using code snippets, let's explain what is a file and what is a stream. So again, a file is a static class that represents available file systems and provides typical operations against these file systems. A stream, or rather the `Stream` class, is an abstract class that represents basic operations on a data stream (on the stream of bytes), which allows mapping the behavior of various media that can be used to store or transmit data as the bitstream.

This sample demonstrates how to save working data in a file containing an XML document, which next can be directly presented for example in MS Word editor or Internet Explorer translated using a style sheet. It is the simplest way to detach the document content from its presentation.

## Serialization

This example is dedicated to demonstrate how to deal with the presented above scenario. It defines a few helper functions, for serialization and deserialization located in the static class:

`Example.Xml.DocumentsFactory.XmlFile`

The `Example.Xml.CustomData` namespace contains classes that represent XML schema and are used by the program as an object model of the working data.

After implementation of the `Example.Xml.DocumentsFactory.IStylesheetNameProvider` by the root class of the object model we can convey information about default stylesheet that may be used to transform resultant XML file. Information about the stylesheet (xslt file) is added to the XML document and can be used by the application to open the file and translate the content.

An example of xslt file has been added to the CustomData and is copied during project build to destination folder. In the same folder an example of XML file (named Catalog.xml ) is created. You can open it using IE or MS Word using the instruction below.

Program class demonstrates how to use read/write operation.

## Useful Technologies

### Reflection

Let's first go back to the example we discussed in the previous lesson. Let me remind you that we had a class that we have preceded by a custom attribute, which is defined below this class. In unit testing, we had the [AttributedClassTypeTest][AttributedClassTypeTest] test method that proved how to retrieve features of the definitions of this type by creating an object of type `Type`. I moved the testing stuff to the [GoTest][GoTest] method because to reuse this functionality without code cloning. This example shows that we can recover type features that are provided in the form of attributes. Additionally, we can perform operations on attributes (on objects of the `Attribute` type) that were created as a result of the `GetCustomAttributes` operation.

In the pointed-out example, the only weak point is that it uses an identifier of the type definition. In this code snipped, the `typeof` is an operator, which is used to instantiate an object that represents a type utilizing the identifier of a type definition. The argument to the `typeof` operator must be the name of a type. Hence, talking about serialization/deserialization we have to implement appropriate algorithms in such a way that we do not have to refer to the type definitions because we simply do not know them. In general, the type is defined later, and it doesn't matter if it is milliseconds, or years later. Let's try to imagine a scenario in which we have to deal with objects whose types we do not know.

To show an example a bit similar to the above scenario, in the unit test project, I have added the [Siyova16][Siyova16] class with all identifiers created randomly by a password generator. The main idea of creating a random definition is to give the impression and stress that there is no need to refer directly to them while implementing the required functionality. As it was mentioned already, to create a generic solution the reality is that we need to be prepared for a situation where referencing identifiers directly is impossible. The reflection can be applied to both cases, so we can investigate it using a simplified case.

To continue building an example in which we will show how to operate on objects of unknown types, I have inserted the [ObjectFactory][CreateObject] class here, whose task is to create such objects. Precisely, the objects are of different types, but they have one thing in common, namely they are preceded by the same `CustomAttribute` attribute. The [AttributedClassInstanceTest][AttributedClassTypeTest] test shows that it is possible to detect this feature without referring to identifiers associated with the object type. For this purpose, in this test method, objects of various types are created using the dedicated `ObjectFactory` class. For all, regardless of the type, the same [GoTest][GoTest] test method is performed, which checks the presence of the attribute and tests the selected property. For this purpose, an enumeration type is defined in this class, in which the values are also random. The Tn enumeration type was used to indicate which object should be created from which type. But here there is no direct relationship between the identifier used in the enum type and the type identifier (with the type definition).

#### CreateObject method

The [CreateObject][CreateObject] method is responsible for creating objects of various types. Because it creates objects of different not related to each other types, the return value must be of the `object` type, which allows returning any object. Therefore, after calling `CreateObject` we don't really know the type of the returned instance. Hiding the type of the created object is intended to mimic operation on unknown types. Of course, this is just a simulation for this example. Once again, I wanted to emphasize that the tests are solely used to demonstrate certain features and the possibility of using reflection for serialization/deserialization.

#### AttributedClassInstanceTest

To show how to operate on objects without referring to their type definitions we can recover the features of the type for which these objects were defined. Check out the example from the [AttributedClassInstanceTest][AttributedClassInstanceTest] test method. Once again, it instantiates a variety of types having the same feature and executes test against this feature.

Now the question is: how to achieve a similar situation as before, i.e. how to recover the features of an object type without knowing the type. we already know that this can be done by creating a `Type` instance for the selected type definition using the `typeof` keyword and the type identifier of this definition. In the case of an object for which the type is not known for some reason, the `GetType` instance method inherited from the `System.Object` type comes in handy. Let me remind you that this operation is inherited from the base type `Object`. It is a very basic type for all types. So in our case, reflection starts when a `Type` instance is created. This instance can be created for a selected type definition and for a selected object without knowing its type. It should be emphasized here that based on this example, we can conclude that reflection is related even to the `Object` base type.

To make a summary of the discussion above, regardless of whether we have a type definition visible or we need to bother with recovering the type description from an instance instead, the common point in the process of further processing and converting the state of objects to bitstreams form and vice versa is to create an instance of the [System.Type][[system.type] abstract type, which contains a detailed description of the type in concern. Because it is abstract we cannot create this instance directly and have to use the `typeof` keyword or employ the `GetType` instance method. Going right to the point, since in both cases we can reach a common point, we can have the same test method [GoTest][GoTest].

#### Managing an object State

There is one more issue to discuss, namely how to control the state of an object, i.e. reading and writing values to its members without referring to its type. The main problem is that if the type is not visible we do not have knowledge about its members.

As an introduction, our task now is to implement a library class that enables reading and assigning from/to property defined as a member of a type. To show how to implement this functionality, let's use a previously defined class that has a random name and several properties defined, the names of which are also random. The main goal of using a random definition is to explain how to deal with invisible types.

In the test project, the `ReflectionUnitTest` test class includes the [AttachedPropertyTest][AttachedPropertyTest] test method, which contains a program fragment showing how to use such a mechanism for managing a property value of an object without having to refer to its type definition. However, it should be emphasized that to implement this functionality we need to know the name of the property and its type. This requirement must be fulfilled because the language is highly typed. The [AttachedProperty\<TypeParameter\>][AttachedProperty] class, which is the implementation holder of the reading and writing operations, is implemented in a separate library project. So obviously the library class won't be able to refer to this type because it doesn't know it - it is invisible for many reasons. We will analyze this class based on the example of the [AttachedProperty\<TypeParameter\>][AttachedProperty] class. The previously used type of the example class [Siyova16][Siyova16] serves as a simulation of any type.

In the [AttachedPropertyTest][AttachedPropertyTest] method I need to create a target object of type [Siyova16][Siyova16] that is to be controlled. It is worth emphasizing that creating the target object is redundant here because, in a real scenario, we should assume that the object is already created elsewhere. In the next step, a surrogate object as a wrapper of the target object is created. The surrogate object functionality is to enable reading and writing to the selected property from the target object without referring to the type of the target object. The expected behavior of the wrapper class is that it has a property `Value` to which value can be assigned to and read from. These values are transferred transparently to and from the target object that is passed to it as an actual parameter of a constructor.

#### AttachedProperty

The functionality enabling the possibility to manage a selected property of a target class has been implemented as a generic library class named [AttachedProperty\<TypeParameter\>][AttachedProperty]. To get more about the generic type concept check out the course title "Information Computation". The library class uses a simple constructor which takes two parameters that are responsible for initializing the data members of the new object. The first parameter is used to pass references to the target object that is to be wrapped by this class. The second argument is used to pass the name of the property that is to be managed using an instance of this class. As a wrapper, the first step of the constructor is to save the reference to the target object in the local variable. This reference will be used later. It is worth stressing that this way we cannot refer to the type of the target object. To solve that the type of the target object is invisible reflection is engaged and the `GetType` method is used to recover the required features of the target object. The recovered description of the target object is conveyed by a new instance of the `Type` type. Thanks to this object, in the next step we can obtain information about the property we want to write and read. This description is saved in the next local variable. The last step will be to create an intermediary property that, thanks to the previously obtained information about the target property, will allow transferring values to/from this property.

[AttachedPropertyTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L57-L68
[AttachedProperty]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams/Reflection/AttachedProperty.cs#L17-L46
[system.type]: https://learn.microsoft.com/dotnet/api/system.type
[AttributedClassInstanceTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L46-L55
[CreateObject]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L81-L101
[AttributedClassTypeTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L39-L43
[Siyova16]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L73-L79

### Attributes

#### AttributeClass

Let's start by creating a very simple class used as a starting point for the discussion. It has only one method. The functionality of this method is not important in the context of discussion, but the method creates an object and returns it. Imagine, that after some time, we conclude that this method is not perfectly correct anymore and we want to avoid referencing it. We know it is used in many places in the program, so to preserve backward compatibility we cannot simply remove it from the program text to avoid triggering a bunch of syntax errors. Hence, we must keep in place this definition, but we should associate additional information with code in a declarative way. This additional information should prevent it from being used any further. This way we try to fix an issue by preventing referencing of insufficient code instead of replacing it. In other words, there will be no further references to it in new programs.

We can use an attribute for this purpose - the `Obsolete` attribute. To observe this attribute and the effects it causes, let's open a test window and add a test. On the right side, I added a test class. Let's add a test method to this class. In the test method, we simply call the method that we previously marked with the `Obsolete` attribute and we see that the compiler now reports an error; reports a warning to us. It is also available in the error list. Therefore, this is a clear signal that we should not use this method because it is no longer valid.

This warning should make us no longer use this method and should use some other alternatives instead. Of course, we could use a regular comment here. Unfortunately, this will cause us to lose the warning on the right side that we should not use this method in newly created program fragments. Based on this, we can conclude that a comment is a very good tool for communicating with the reader of this text - after all, the program is a text. Attributes, on the other hand, are a mechanism for communicating with the compiler. And as we will see in a moment, not only with the compiler.

Since we may decide that this was not a good idea, let's go back to the previous entry in which we use the attribute and ask what this attribute is. The F12 key takes us to the definition and we see that the attribute is a derived class of the base class `Attribute`. Now we can formulate a key question for us; whether we can define our own attributes, which we will then use to add them to the program content and use them later in other programs.

#### CustomAttribute

Here, I have created an additional [CustomAttribute][CustomAttribute] class. As before, it inherits from the `Attribute` base class. The main goal of it is to provide additional information related to the program content. Therefore, to define it, we need to specify two things. The first one is what additional information we want to convey using it. And second one, with what other linguistic constructs - called targets - it makes sense to associate this information.

The first task - related to the selection of information that is to be conveyed using an attribute can be achieved by choosing how this information is to be represented (type selection) in the form of data and adding appropriate properties (value holder) that will convey this data. In this case, it is the `Description` property, which is of type `string`. This way some descriptions expressed in natural language may be added to the target. Notice that also a constructor is added here, which is responsible for initializing this description when an object is created.

The second task of choosing where adding this additional information by employing attributes makes sense may be accomplished by associating an existing, dedicated attribute with a definition of a new attribute class. And here's a crucial note about terminology. I used the term attribute for both (a) to name a class that is derived from the [System.Attribute][system.attribute] base class and (b) also as an identifier that is used elsewhere and surrounded between square brackets. Maybe it sounds puzzling but it is a typical recurring reference to the joint terms. In other words, we use an existing attribute to define a new one. The [AttributeUsage][AttributeUsage] attribute is predefined by the built-in definitions of this programming language that allows expressing where adding a new attribute makes sense.

Let's examine the features of the newly created `CustomAttribute` class using the unit tests [ReflectionUnitTest.CustomAttributeTest][CustomAttributeTest]. It just instantiates an object of this class and then compares the value of the embedded property value with the initial one. This way we can prove that this class behaves like any other regular class.

Keeping in mind that the newly created attribute is a class, let's try to use it to add additional information to the previously defined `AttributeClass` class. So a linguistic construct appears, where between square brackets we will have the name of the class and additional data that we want to be associated with this linguistic construction, with this class. Since this is additional data, we call it meta-data; in other words, data describing data. Since in this case, the data described is a linguistic construction, there is the text of the program - the program becomes data. The question is how this data can be used throughout the processing process. Let's see this with an example of a unit test where we try to retrieve this information; and recover this data.

From this example, we see that it can also be associated with actual parameters placed between round brackets. In other words, it looks like a method call, doesn't it? Moreover, because the name is the same as the class name it looks like a construction call. A detailed discussion of these linguistic constructs syntax is beyond the scope of the example. To possibly fill in the gaps in this respect, I recommend the C# language user manual. From now on, we will only focus on the semantics, i.e. on the meaning, of these entries.

So let's add a test method in the test class, in which the code will refer to `AttributedClass` a class that has been assigned an attribute. To refer to the type the [typeof keyword][typeof] is applied. As a result of using `typeof` an object of the `Type` type is created for the selected type. An object created this way contains details of the source type definition. And here we encounter reflection for the first time. Reflection, which means that we can create objects in the program that represent selected linguistic constructs. In this case, `_objectType` is a variable of `Type` type that will contain a reference to the object representing the `AttributedClass` class definition. Notice that to avoid code cloning the test continues in the [GoTest][GoTest] method. Then, from this object, we can read all attributes related to the selected type using the `GetCustomAttribute` instance method. Additionally, in this case, I specify that I am only interested in attributes of the selected type. We can then determine that I am indeed getting an array with exactly one element in it. This element is of the `CustomAttribute` type, i.e. the type we added before the class as a class attribute.

Therefore, we can return to the discussion about semantics, i.e. the meaning of the notation between square brackets. We see that the `GetCustomAttributes` method creates objects. Objects that are associated with selected language construct, in this case, `AttributedClass`. It looks the same as if we used the `new` keyword to create an object of the `CustomAttribute` class. After creating the object it can be used as if it had been created using the `new` keyword.

So, once again, back to the heart of the topic. We can ask what role this construct plays. I mean where the class name is placed between square brackets. A class that is an attribute, i.e. a class that is a derived class of the `Attribute` class. We see that the main purpose of this construct is to describe the creation of an object, and therefore answers the question of how to create an object. This way we can conclude that it is equivalent to the constructor call, which is usually placed after the `new` keyword. Here it plays the same role except that it is not part of the expression in the assignment statement. Hence it has to provide all values for the constructor and initial parameter for the members of the attribute class.


[system.attribute]: https://learn.microsoft.com/dotnet/api/system.attribute
[AttributeUsage]: https://learn.microsoft.com/dotnet/api/system.attributeusageattribute?view=net-7.0
[typeof]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L41
[CustomAttribute]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams/Reflection/AttributedClass.cs#L27
[CustomAttributeTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L24C21-L24C21
[GoTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L103

### Serialization Part 1

On the screen, we see an example class named [TP.DataStreams.Instrumentation.SelfControlSerialization][SelfControlSerialization] that contains three properties. One of which is named `AverageIncome`, and returns the calculated value, so it returns the result of an expression. This example shows that to recreate an object of this class, we only need to transform two values because the third one is always calculated, so there is no need to remember it. The constructor of this class initializes the initial values of this class when the object is created.

To transform an instance of this class (to serialize it), first, an attribute has to be associated with this class that will indicate that it is intended for serialization. However, this does not solve the issue of selecting the values that contribute to the state of the object. We already know a condition that must be fulfilled thanks to these values. Theoretically, It enables the selection of them. The question is how to do it.

## SerializationUnitTest

The first approach to selecting values contributing to the object state is to have built-in functionality allowing the selection of values that contribute to the state of the object is the first step. It means moving this responsibility to the target class. Unfortunately, It solves only partially the problem because this functionality must be implemented each time an instance of a class is to be sterilized. Let's look at the serialization process using a unit test in this context. The test method [TP.DataStreams.SelfControlSerializationTest][SelfControlSerializationTest] implements functionality well suited for this purpose.

[SelfControlSerializationTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/SerializationUnitTest.cs#L26-L39

In this test class, we create an object of the class that is to be serialized next time. In the next step, we must have a class that implements the serialization functionality; I have prepared a class called `CustomFormatter`. A bit later I will describe this class in more detail. After implementing the serialization functionality we can create a stream. Let's use a file stream with a given name for this purpose and serialize the object to it, i.e. write a bitstream to its content. After that, the content contains the state of the serialized object according to the selection made by the object itself thanks to the implementation of the `ISerializable` interface. 

After preparing the serialization result, in the next step, let's check that this file exists and that its length indicates that values that constitute the object's state have been written to it. Then let's read this file and save it locally to examine its content.

## CustomFormatter.Serialize

But now let's move on to the implementation of the [TP.DataStreams.Serialization.CustomFormatter][CustomFormatter] class. Our `CustomFormatter` was created as a class that inherits from the [Formatter][Formatter] class. The `Formatter` class is defined in the language library and it implements many operations to avoid cloning code and implement the same functionality over and over. Using this type to implement serialization it is assumed that the object to be serialized implements the `ISerializable` interface. The main aim is to avoid using reflection and use custom functionality allowing to select and read values that contribute to the object state. Thanks to this, we can retrieve them from this object. , i.e. use the `GetObjectData` operation. As a result of this operation, we will have access to all values. We can perform serialization operations for all values. So we can repeat the writing of individual values thanks to the `WriteMember` method, which is implemented in the `Formatter` class. Next, we have operations related to creating an XML document and saving this document to a file.

But now let's move on to the implementation of the [TP.DataStreams.Serialization.CustomFormatter][CustomFormatter] class. Our [CustomFormatter][CustomFormatter] is defined as a class that inherits from the [Formatter][Formatter] class. The `Formatter` class is defined in the language library and it implements many operations to avoid cloning code and implement the same functionality over and over.

Using this type to implement serialization, it is assumed that the object to be serialized implements the `ISerializable` interface. The main aim is to avoid using reflection to read values that contribute to the object state. By design, this functionality must be provided by the target type. An example is in the [SelfControlSerialization][SelfControlSerialization] class. Thanks to this, we can retrieve them from the target object by using the `GetObjectData` operation. As a result of this operation, we have access to all values even private ones,  and we can, therefore, perform serialization operations for all values even invisible outside of the target object. So, we can repeat the writing of individual values thanks to the `WriteMember` method, which is implemented in the `Formatter` class. Next, there are operations related to creating an XML document and saving this document in a file.

It is worth emphasizing that in our example we only write `double` values and that is why I only implemented the `WriteDouble` method, which creates an instance of `XElement` type passing the value and key to the constructor. It is also important here that the [CustomFormatter][CustomFormatter] class is implemented in the library. The architecture of the solution shows that this class cannot have references (cannot use), and cannot refer to the definition of a target type that is subject to the serialization process. The object that is subject to the serialization process can be of any type but we assume here that it must implement the `ISerializable` interface, and therefore must provide an implementation of the `GetObjectData` operation method.

[CustomFormatter]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams/Serialization/CustomFormatter.cs#L21-L153
[Formatter]: https://learn.microsoft.com/dotnet/api/system.runtime.serialization.formatter
[SelfControlSerialization]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/SelfControlSerialization.cs#L22-L79

## Part 2

As an example, let's consider the [Catalog][Catalog] class, which is to contain an array of CD descriptions. So here we have property, which is an array containing CD descriptions complaint with the `CatalogCD` class defined in the same file. Let me remind you that we have two issues that we need to resolve. The first one is which of these properties should be included in the resulting stream. The second one is how we can read the values for these selected properties. Well, in general, they don't have to be properties.

[Catalog]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/Catalog.xsd.cs#L21-L55

Instead of using a self-serialization approach, the reflection may be employed to read and write values contributing to the object state. This way there is no custom code related to selecting, reading, and writing state values. To select only necessary values the following convention may be applied. It says that the state of the object is constituted by all the values that can be obtained by reading the public properties that have both getter and setter. So from which you can both read the current value and substitute new values. If this convention applies to the target object and all indirectly referenced we can state that the graph of objects is ready for serialization and deserialization using reflection. What is very important is to ensure symmetry between serialization and deserialization.

The serialized classes were defined in the test class. Therefore, if we define a library that will be used to serialize these classes, this graph, then the serializing class cannot know the type of serialized classes, cannot have references to unit tests, and so he can't know the types. This way it could be proved that the solution is generic, I mean it doesn't depend on the target type of serialized classes.

The rule that we will remember in the output stream all the values that we can read from public properties that have both getter and setter cannot be used uncritically. We also need to consider the case when such properties exist, but for some reason, we do not want to save their values in the output stream. The solution to this problem can be based on our knowledge of attributes. In practice, it means that properties of this type are preceded by a selected attribute. For example, it may be `XMLIgnore`, which will indicate that you must use all public properties that have a getter and setter, except those preceded by the indicated attribute. The question is whether in this solution we ensured the symmetry of the serialization and deserialization operations. The answer is yes because both reading data and writing data to newly created objects are in the same place, by using the same property. This means that using reflection there is no need to add any dedicated functionality to the target class related to serialization and deserialization. 

As we see in this example, we do not have to create custom code in the target type that is subject to serialization that is used to implement this operation. So we can say that in this case, the serialization process is strictly autonomous.

The main outcome of the example is that in the target type that is subject to serialization, there is no need to create dedicated code that is used to implement this operation. So we can say that reflection enables us to offer a strictly autonomous solution.

When we talk about the syntax and semantics of a stream, the first thing to consider is the scope of data use. Well, data produced by one instance of a program can also be used by the same instance of the program. In such a case, if the process runs autonomously and is symmetric from a serialization and deserialization point of view, we should not expect any further problems.

However, the same data can be used by the same program but not the same program instance, we also have to take into account that the programs may be in different versions. In such a case, there is a problem of data compatibility between different versions of the program. So the question arises whether if the data serialized by one version of the program is used by another version of the program run as a different instance, will it allow the creation of a graph equivalent to the original graph.

Another application of streams may be the use of them between various programs that are created in different technologies and implemented on different platforms. Then there is also the issue of technological compatibility. Also in this case, it must be taken into account that classes (types) that were created in one technology cannot necessarily be directly used in another technology. And in this case, we are already entering the issue of semantics, so we must take into account the fact that in another technology the same information will be represented in a different way.

We also talked about the human use of streams. In this case, further requirements appear. Among other things, this representation should be close to natural language. Of course, we have no measure here and therefore it is difficult to say whether something is close enough to natural language to be comprehensible. In order for humans to understand the stream, it will also be necessary to define semantic rules, i.e. rules that will allow us to assign meaning and information to strings of bits. The issue of ergonomics is also important, i.e. the ease of absorbing information represented by the stream. Of course, the closer we are to natural language, the easier it will be, but again in this matter, we do not have measures that will allow us to clearly determine how good our solution is.

If we are talking about exchanging data between different applications or between an application and a human, the issue of data correctness arises. This issue should be considered on two independent levels. The first one is the correctness of the stream as a certain stream of signs, i.e. when the syntax rules are met. The second one is correctness from the point of view of the possibility of assigning information to these correct sequences and therefore assigning meaning.

To better understand these issues, let's look at them in the context of code examples. Maybe we will also be able to determine solutions that may be useful in this regard.

### Catalog class

If we assume that objects of the types defined by these classes will be serialized into XML texts, the form of the stream may be, for example, one in which we have a root element `Catalog` containing several `CD` elements describing individual discs. With this type of XML file; we can see that it is a text file because we have defined the encoding for this file. The problem with this type of XML is that if it contains any errors, for example; In this case; it's hard to say that these are mistakes; some modifications; we see that if we enter `CD1` here instead of `CD`, we will get an error, but if we write here; we will complete; so let's also add one, then this file is correct from the point of view of XML syntax. However, it is difficult to imagine a serialization mechanism in which two subsequent elements will have different names but will represent the same information. So at this point, we can say that this file complies with the XML standard, with the XML syntax. However, well, it does not represent the semantics we would expect. The semantics that is written by our class.

Adding this attribute here causes it to refer to the XML schema. The XML Schema allows to define additional syntax rules that will be used to check this XML text against these rules. Hence, we can say that without the XML Schema, it is just XML text. The syntax rules for the XML file must be met in a valid XML document. After adding an XML schema we can define how to construct the document that is to be verified using this additional schema document. In case the text is not compliant with the schema it should be possible to verify this document and receive information that this document is not formatted correctly.

After attaching the rules described in the schema, we can therefore verify the document and assume that if the document does not comply with the schema, it means that it is not valid and should be rejected instead of being used for the deserialization process. Thanks to this, we can ensure that documents transferred between individual applications will be verified from the point of view of their syntax correctness. If the document is not valid concerning these rules, do not attempt to recreate the graph of objects and their states.

If we are talking about communication between different remote applications, we must consider a scenario in which these applications are written in different programming languages. In this case, the problem arises of how to create types in other languages that will represent the same information. Since we recognize the schema as a good idea to validate XML documents, i.e. XML texts, and check whether the XML text is the XML document we expect, then maybe we should turn the issue upside down and generate types in selected programming language based on XML schema. Of course, it is a chicken and egg problem namely, should we first create types in the selected programming language, or should we create these types in the XML schema and then create classes based on the XML schema? But let's try to see how this can be achieved using an example.

To generate classes in CSharp; I have prepared a script that uses the XSD program (this program is available in the Visual Studio environment) and now let's try to use this program to generate the classes that we previously created manually, let's now try to generate them automatically based on the `Catalog.xsd` schema, which we just discussed. To do this, we must have a console window open to run this program. I entered it here and ran it. We should get the result in the file we previously created manually. I confirm that we want to accept all modifications and we see that this program was indeed generated automatically. At the same time, a lot of different attributes appeared here. So here we are dealing with something called attribute programming. Indicating not only what is to be transformed, what data is to be transformed, but also how. How the result should be formatted, what the result should look like in the form of a stream, in this case, it is XML text, and after adding the schema, it is already an XML document.

Tutaj widzimy, że mamy faktycznie klasę `Catalog`, mamy tutaj tablicę opisu poszczególnych płyt CD i tutaj mamy kolejna klasę, która opisuje właśnie pojedynczą płytę. I wszystkie te properties, które mieliśmy poprzednio, ale proszę zwrócić uwagę, nie mam tej którą poprzednio dopisaliśmy. Ona zniknęła, została nadpisana, ponieważ ten program wygenerował w sposób automatyczny tekst nie przejmując się tym, co było poprzednio. Stąd też pora przypomnieć sobie nasze rozważania dotyczące definicji częściowych. To jest pierwszy przykład, w którym widzimy, że ta koncepcja jest niezbędna w sytuacji, kiedy mamy do czynienia z auto generowanym kodem, ponieważ auto-generacja kodu zawsze będzie ignorowała wszelkie modyfikacje, które my wprowadzimy do tego pliku.

Here we see that we have a `Catalog` class, here we have an array of descriptions of individual CDs and here we have another class that describes a single CD. And all the properties we had previously, but please note that I don't have the one we added previously. It disappeared, it was overwritten because this program automatically generated the text without caring about what was there before. Hence, it is time to recall our considerations regarding partial definitions. This is the first example where we see that this concept is necessary when dealing with auto-generated code because auto-generated code will always ignore any modifications we make to this file. That's why the message at the top warns not to change this file.

In this lesson, we showed how attributed programming and reflection can be used to ensure autonomy and synchronization of object-to-stream conversion processes and vice versa. Thanks to the use of schema XML, we also showed how documents can be verified and how document syntax can be saved using a schema and thus automatically generate program text in various languages, ensuring data conversion between various technologies; and between different programming platforms.

## Part 3

This is the third and last lesson dedicated to serialization, i.s. the process of transforming a graph of objects into a bitstream.

### In previous lessons

In the previous two lessons, we talked about how to build universal libraries that will allow you to transfer object data to a stream and from a stream to object data. We also talked about how to use attributes and reflection to ensure full automation of this process and harmonize the behavior of the process of converting objects to a stream and stream to objects. Automation in this context means that the reflection is used to prepare a library and as a result, the conversion process can be performed without human intervention. We also talked about stream semantics and syntax using the example of XML files. We showed how to use the XML schema concept to describe the semantics of a document and, consequently, to create the source code of a program that will be used in the serialization and deserialization process.

### What hasn't been covered yet

We didn't manage to cover all the topics during the previous lessons, so let's look at which topics should be covered in this lesson.

First of all, we need to deal with data visualization, so as to enable the use of streams also by a human computer user. Issues related to graphs are also on the list. Let us introduce two terms: hierarchical and non-hierarchical graph. Loops may occur in non-hierarchical ones. First things first. Let's start with data visualization, taking into account, firstly, natural language, ergonomics, and graphical user interface.

## Cryptography basics

### Hash

### Encryption

### Digital Signature

## See Also

- [XSL\(T\) Languages][XSLW3C]
- [Serialization in .NET][STLZTN]
- [XML Schema Definition Tool (Xsd.exe)][XSD]

[XSLW3C]: (https://www.w3schools.com/xml/xsl_languages.asp)
[XSD]: (http://msdn.microsoft.com/library/x6c1kb0s.aspx)
[STLZTN]: (http://msdn.microsoft.com/library/7ay27kt9.aspx)
