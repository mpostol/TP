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
