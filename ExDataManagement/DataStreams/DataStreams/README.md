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

- [Data Streams Implementation Examples](#data-streams-implementation-examples)
  - [External Data Preface](#external-data-preface)
  - [File and Stream Concepts](#file-and-stream-concepts)
    - [Operating System Context](#operating-system-context)
    - [Program Context](#program-context)
    - [XML-based Presentation](#xml-based-presentation)
    - [XML-based Validation](#xml-based-validation)
  - [Attributes](#attributes)
    - [AttributedClass](#attributedclass)
    - [CustomAttribute](#customattribute)
    - [Attribute Access Based Directly on the Type Definition](#attribute-access-based-directly-on-the-type-definition)
    - [Attribute Access Based on the object type](#attribute-access-based-on-the-object-type)
  - [Managing an Object State](#managing-an-object-state)
    - [Preface](#preface)
    - [Self Controlled](#self-controlled)
    - [Reflection-based Read - Write](#reflection-based-read---write)
    - [✍🏻 Reflection-base serialization](#-reflection-base-serialization)
  - [Standardization - generating classes based on schema definition](#standardization---generating-classes-based-on-schema-definition)
  - [Bitstream protection](#bitstream-protection)
    - [Hash](#hash)
    - [Encryption](#encryption)
    - [Digital Signature](#digital-signature)
  - [See Also](#see-also)

## External Data Preface

The external data is recognized as the data we must pull or push from outside of a boundary of the process hosting the computer program. In general, the external data may be grouped as follows:

- **streaming** - bitstreams managed using content of files, or network payload
- **structural** - data fetched/pushed from/to external database management systems using queries
- **graphical** - data rendered on Graphical User Interface (GUI)

This section collects descriptions of examples explaining the usage of the **streaming** data.

## File and Stream Concepts

### Operating System Context

Let's look at the `.Media` folder containing files used in the examples:

![Fig. MediaFolderAnimated](../.Media/MediaFolderAnimated.gif)

We have different files there, but similar descriptive data, i.e. metadata, are defined for all of them. Among these data, `Name`, `Date`, `Type`, `Size`, `Data created`, and much other information that may be useful, but the most important thing is, of course, the content of the file.

After double-clicking on the selected file an image will appear.

![PC](../.Media/PodpisCyfrowy.png)

Here we may ask a question - how to describe this behavior? Well, a program was launched. This program must have been written by some programmer. The program opens the file as input data, so the programmer had to know the syntax and semantics rules that were used in this file. The data contained in the file makes it possible to show the content graphically on the computer screen. This is the first example of graphical representation, but we will return to this topic later.

### Program Context

Using code snippets located in the [FileExample class][FileExample] differences between file and stream may be explained from a program point of view. From this example, it could be learned that the `File` is a static class that represents the available file system and provides typical operations against this file system. The content of the file is represented as a bitstream, or rather the `Stream` class. It is an abstract class that represents basic operations on a data stream (on the stream of bytes), which allows mapping the behavior of various media that can be used to store or transmit data as the bitstream. From this perspective, it can be proved, that file content is always a bitstream (a stream of bytes).

### XML-based Presentation

Using bitstreams (file content) we must face a problem with how to make bitstreams human readable. Firs answer we know from the examples above, namely the bitstream must be compliant with a well-known application. Unfortunately, this answer is not always applicable. Therefore we should consider another answer, namely human-readable representation should be close to natural language. Of course, we have no measure here and therefore it is difficult to say whether a bitstream is close enough to natural language to be comprehensible. The first requirement for humans to understand the stream is that it has to be formatted as text. To recognize bitstream as the text directly or indirectly an encoding must be associated. An example of how to associate directly an encoding with the bitstream is the following XML code snippet:

```xml
<?xml version="1.0" encoding="utf-8"?>
```

The next requirement, common for both humans and computers, is a bitstream association with the comprehensive syntax rules. To make the rules comprehensive for humans the bitstream should have been formatted as a text. Finally, semantic rules should be associated with the bitstream that allows to assigning of meaning to bitstreams.

The [ReadWRiteTest][ReadWRiteTest] sample code demonstrates how to save working data in a file containing an XML document, which next can be directly presented in other applications, like MS Word editor or Internet Explorer. In this concept, it is assumed that the bitstream formatted as XML is transformed using a stylesheet before being presented. An XML stylesheet is a set of rules or instructions for transforming the structure and presentation of XML documents. It defines how the data in an XML file should be formatted. It is the simplest way to detach a custom document content from its formatting to be presented as graphical data provided that the original document is compliant with the XML specification.

After implementation of the [IStylesheetNameProvider][IStylesheetNameProvider] interface by the [Catalog][Catalog] class we can convey information about the default stylesheet that may be used to create an output XML file. Thanks to the implementation of the mentioned interface information about the stylesheet (`XSLT` file) is added to the XML document and can be used by any generic application to open the file and translate the content, for example [catalog.example.xml][catalogexamplexml]:

``` XML
<?xml-stylesheet type="text/xsl" href="catalog.xslt"?>
```

### XML-based Validation

If we are talking about exchanging data between different applications or between an application and a human, the issue of bitstream correctness arises. This issue should be considered on two independent levels. The first one is the correctness of the bitstream as a certain stream of signs, i.e. when the syntax rules are met. The second one is determined by the possibility of assigning information to these sequences and therefore assigning meaning to a bitstream.

To better understand these issues, let's look at them in the context of an example [catalog.example.xml][catalogexamplexml]. The following discussion scops to the XML format but the presented approach should be recognized as a universal one.

The XML (Extensible Markup Language) is a language that defines syntax rules. For example, in the mentioned above XML text after replacing the closing name of the `CD` element (by `CD1` instead of `CD` for example) we get an XML syntax error. Syntax error means that the file is not compliant with the XML standard and should not be used anymore. But after replacing the name of the opening markup of the element with the same `CD1` name then this file is correct in the context of the XML syntax. However, it is difficult to imagine that two subsequent elements will have different names but will represent the same information. So at this point, we can say that this file complies with the XML standard, with the XML syntax. However, it does not represent the semantics we would expect.

Adding these attributes causes it to refer to the XML schema.

```xml
<Catalog xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
         xmlns:xsd="http://www.w3.org/2001/XMLSchema" 
         xmlns="http://Viculu34.org/Catalog.xsd"
         >
  <!-- catalog.example.xml content here -->
</Catalog>

```

The XML Schema allows to define additional syntax rules that will be used to check XML text against these rules. The syntax rules for the XML file must be met in a valid XML document. Hence, we can say that without the XML schema, it is just XML text. After adding schema we can define how to construct the document that is to be verified using this additional schema document. After attaching the rules described in the schema, we can therefore verify the document and assume that if the document does not comply with the schema, it means that it is not valid and should be rejected instead of being used for further processing. Thanks to this, we can ensure that documents transferred between individual applications will be verified from the point of view of their syntax rules, which should be derived from the document semantics.

## Attributes

### AttributedClass

Let's start by creating a very simple [AttributedClass][AttributedClass] example used as a starting point for the discussion on attributes. It has only one method but its functionality is not important in the context of the discussion. The method creates an object and returns it. Imagine, that after some time, we conclude that this method is not perfectly correct anymore and we want to avoid referencing it. We know it is used in many places in the program, so to preserve backward compatibility we cannot simply remove it from the program text to avoid triggering a bunch of syntax errors. Hence, we must keep in place this definition, but we should associate additional information with code in a declarative way. This additional information should prevent it from being used any further. This way we try to fix an issue by preventing referencing of insufficient code instead of replacing it. In other words, there will be no further references to it in new programs.

We can use an attribute for this purpose - the `Obsolete` attribute. To observe this attribute and the effects it causes, let's open a test window and add a test method. In the test method, we simply call the method that we previously marked with the `Obsolete` attribute and we see that the compiler now reports an warning. It is also available in the error list. Therefore, this is a clear signal that we should not use this method because it is no longer valid.

This warning should make us no longer use this method and should use some other alternatives instead. Of course, we could use a regular comment here. Unfortunately, this will cause us to lose the warning to avoid using this method in newly created program fragments. Based on this, we can conclude that a comment is a very good tool for communicating with the reader of this text - after all, the program is a text. Attributes, on the other hand, are a mechanism for communicating with the compiler. And as we will see next, not only with the compiler. The F12 key takes us to the definition and we see that the attribute is a class that is derived from [Attribute][system.attribute]. Now we can formulate a key question; whether we can define our own attributes, which we will then use to add them to the program content and use them later in other programs.

### CustomAttribute

I have created an additional [CustomAttribute][CustomAttribute] class. As before, it inherits from the [System.Attribute][system.attribute] base class. The main goal of it is to provide additional information related to the program content. Therefore, to define it, we need to specify two things. The first one is what additional information we want to convey using it. And second one, with what other linguistic constructs - called targets - it makes sense to associate this additional information.

The first task - related to the selection of information that is to be conveyed using an attribute can be achieved by choosing how this information is to be represented (data type selection) and adding appropriate properties (value holder) that will convey this data. In this case, it is the `Description` property, which is of type `string`. This way some descriptions expressed in natural language may be added to the target. Notice that also a constructor is added here, which is responsible for initializing this description when an object is created.

The second task of choosing where adding this additional information by employing attributes makes sense may be accomplished by associating an existing, dedicated attribute with a definition of a new attribute class. And here's a crucial note about terminology. I used the term attribute for both (a) to name a class that is derived from the [System.Attribute][system.attribute] base class and (b) also as an identifier that is used elsewhere and surrounded between square brackets. Maybe it sounds puzzling but it is a typical recurring reference to the joint terms. In other words, we use an existing attribute to define a new one. The [AttributeUsage][AttributeUsage] attribute is predefined by the built-in definitions of this programming language that allows expressing where adding a new attribute makes sense.

Let's examine the features of the newly created [CustomAttribute][CustomAttribute] class using the unit tests [ReflectionUnitTest.CustomAttributeTest][CustomAttributeTest]. It just instantiates an object of this class traditionally using the `new` operator and then compares the value of the embedded property value with an expected one. This way we can prove that this class behaves like any other regular class.

Keeping in mind that the newly created attribute is a class, let's try to use it to add additional information to the previously defined [AttributedClass][AttributedClass] class. So a linguistic construct appears, where between square brackets we will have the name of the class and additional data that we want to be associated with this linguistic construction, with this class. Since this is additional data, we call it meta-data; in other words, data describing data. Since in this case, the data described is a linguistic construction, there is the text of the program - the program becomes data. The question is how this data can be used throughout the processing process. Let's see this with an example of a unit test where we try to retrieve this information; and recover this data.

From this example, we see that it can also be associated with actual parameters placed between round brackets. In other words, it looks like a method call, doesn't it? Moreover, because the name is the same as the class name it looks like a constructor call. A detailed discussion of the syntax of these linguistic constructs is beyond the scope of the example. To possibly fill in the gaps in this respect, I recommend the C# language user manual. From now on, we will only focus on the semantics, i.e. on the meaning, of these entries.

So let's add a test method in the test class, in which the code will refer to [AttributedClass][AttributedClass] that has been associated an attribute. To refer to the type the [typeof keyword][typeof] is applied. As a result of using `typeof` an object of the `Type` type is instantiated for the selected type. An object created this way contains details of the source type definition. And here we encounter reflection for the first time. Reflection, which means that we can create objects in the program that represent selected linguistic constructs. In this case, `_objectType` is a variable of the `Type` type that will contain a reference to the object representing the [AttributedClass][AttributedClass] class definition. Notice that to avoid code cloning the test continues in the [GoTest][GoTest] method. Then, from this object, we can read all attributes related to the selected type using the `GetCustomAttribute` instance method. Additionally, in this case, it is specified that I am only interested in attributes of the selected type. We can then determine that I am indeed getting an array with exactly one element in it. This element is of the [CustomAttribute][CustomAttribute] type, i.e. the type we added before the class as a class attribute.

Therefore, we can return to the discussion about semantics, i.e. the meaning of the notation between square brackets. We see that the `GetCustomAttributes` method creates objects. Objects that are associated with selected language construct, in this case, [AttributedClass][AttributedClass] . It looks the same as if we used the `new` keyword to create an object of the [CustomAttribute][CustomAttribute] class. After creating the object it can be used as if it had been created using the `new` keyword.

So, once again, back to the heart of the topic. We can ask what role this linguistic construct plays. I mean where the class name is placed between square brackets. A class that is an attribute, i.e. a class that is a derived from the [System.Attribute][system.attribute] class. We see that the main purpose of this construct is to describe the instantiation of an object, and therefore answers the question of how to create an object. This way we can conclude that it is equivalent to the constructor call, which is typically placed after the `new` operator. Here it plays the same role except that it is not part of the expression in the assignment statement. Hence it has to provide all values for the constructor and initial parameter for the members of the attribute class.

### Attribute Access Based Directly on the Type Definition

Let's first go back to the [AttributedClass][AttributedClass] example. This class is preceded by a custom attribute, which is defined below this class. In unit test, we have the [AttributedClassTypeTest][AttributedClassTypeTest] test method that proved how to retrieve features of the definitions of this type by creating an instance of the `Type` type. I moved the main testing stuff to the [GoTest][GoTest] method to reuse this functionality without code cloning. This example shows that we can recover type features that are provided in the form of attributes. Additionally, we can perform operations on attributes (instances of classes derived from the [System.Attribute][system.attribute] base type) that are created as a result of the `GetCustomAttributes` operation. In this approach the identifier of the type definition is directly used. In this code snipped, the `typeof` is an operator, which is used to instantiate an object that represents a metadata of a type, utilizing the identifier of an attribute type definition. The argument to the `typeof` operator must be the name of a type definition.

### Attribute Access Based on the object type

In the example [AttributedClassTypeTest][AttributedClassTypeTest] mentioned above, there is a weak point.Unfortunately, talking about serialization/deserialization we have to implement appropriate algorithms in such a way that we do not have to refer to the type definitions because we simply do not know them. In general, the type is defined later, and it doesn't matter if it is defined milliseconds, or years later. Let's try to imagine a scenario in which we have to deal with objects whose types we do not know.

To prepare an example that resembles the above scenario, I have added the [Siyova16][Siyova16] class with all identifiers created randomly by a password generator. The main idea of creating a random definition is to give the impression and stress that there is no need to refer directly to them while implementing the required functionality. To create a generic solution the reality is that we need to be prepared for a situation where referencing identifiers directly is impossible. The reflection can be applied to both cases, so we can investigate it using a simplified case.

To continue building an example in which we will show how to operate on objects of unknown types, I have inserted the [ObjectFactory][ObjectFactory] class, which task is to create such objects. Precisely, the objects are of different types, but they have one thing in common, namely they are preceded by the same [CustomAttribute][CustomAttribute] attribute. The [AttributedClassInstanceTest][AttributedClassTypeTest] test shows that it is possible to detect this feature without referring to identifiers associated with the object type. For this purpose, objects of various types are created using the dedicated [ObjectFactory][ObjectFactory] class. Regardless of the object type, the same [GoTest][GoTest] test method is performed, which checks the presence of the selected attribute. For this purpose, an enumeration type is defined in this class, in which the values are also random. It is worth stressing that there is no direct relationship between the enum identifier and the identifier of instantiated type.

The [ObjectFactory][ObjectFactory] method is responsible for creating objects of various types. Because it creates objects of different not related to each other types, the return value must be of the `object` type, which allows returning object of any type. Therefore, after calling [ObjectFactory][ObjectFactory] we don't really know the type of the returned instance. Hiding the type of the created object is intended to mimic operation on unknown types. Of course, this is just a simulation for this example. I want to emphasize that the tests are solely used to demonstrate certain features and the possibility of using reflection for serialization/deserialization.

To show how to operate on objects without referring directly to their type definitions we can recover the features of the instantiated types. Check out the example from the [AttributedClassInstanceTest][AttributedClassInstanceTest] test method. Once again, it instantiates a variety of types having the same feature and executes test against this feature.

Now the question is: how to achieve a similar situation as before, i.e. how to recover the features of an object type without knowing the type. We already know that this can be done by creating a `Type` instance for the selected type definition using the `typeof` keyword and the type identifier of this definition. In the case of an object for which the type is not known for some reason, the `GetType` instance method inherited from the `System.Object` type comes in handy. Let me remind you that this operation is inherited from the base type `Object`. It is a very basic type for all types. So in our case, reflection starts when an instance of `Type` is created. This instance can be created for a selected type definition and for a selected object without knowing its type. It should be emphasized here that based on this example, we can conclude that reflection is related even to the `Object` base type.

To make a summary of the discussion above, regardless of whether we have a type definition visible or we need to bother with recovering the type description from an instance instead, the common point in the process of further processing and converting the state of objects to bitstreams form and vice versa is to create an instance of the [System.Type][system.type] abstract type, which holds a detailed description of the type in concern. Because it is abstract we cannot create this instance directly and have to use the `typeof` keyword or employ the `GetType` instance method. Going right to the point, since in both cases we can reach a common point, we can have the same test method [GoTest][GoTest] to  avoid text cloning.

## Managing an Object State

### Preface

There is one more issue to discuss, namely how to mange the state of an object, i.e. reading and writing values to its members without directly referring to its type. The main problem is that if the type is not visible we do not have knowledge about its members. To illustrate this scenario, our task now is to implement a library class that enables reading from and assigning to a property defined as a member of a type.

### Self Controlled

The [SelfControlSerialization][SelfControlSerialization] class contains three properties. One of which is named `AverageIncome`, and returns a calculated value, so it returns the result of an expression. This example shows that to recreate an object of this class, we only need to transform two values because the third one is always calculated, so there is no need to remember it. The constructor of this class initializes the initial values of this class when the object is created.

To transform an instance of this class (to serialize it), first, an attribute has to be associated with this class that will indicate that it is intended for serialization. However, this does not solve the issue of selecting the values that contribute to the state of the object. We already know a condition that must be fulfilled thanks to these values. Theoretically, it enables the selection of them. The question is how to do it.

The first approach to selecting values contributing to the object state is to have built-in functionality allowing the selection of values that contribute to the state of the object. It means moving this responsibility to the target class. Unfortunately, it solves only partially the problem because this functionality must be implemented each time. Let's look at the serialization process using a unit test in this context. The test method [SelfControlSerializationTest][SelfControlSerializationTest] implements functionality well suited for this purpose.

In this test class, we create an object of the class that is to be serialized. In the next step, we must have a class in a library that implements the serialization functionality. I have prepared a class called [CustomFormatter][CustomFormatter]. A bit later I will describe this class in more detail. After implementing the serialization functionality we can create a stream. Let's use a file stream with a given name for this purpose and serialize the object to it, i.e. write a bitstream to its content. After that, the content contains the state of the serialized object according to the selection made by the object itself thanks to the implementation of the `ISerializable` interface.

After preparing the serialization result, in the next step, let's check that this file exists and that its length indicates that values that constitute the object's state have been written to it. Then let's read this file and save it locally to manually examine its content.

But now let's move on to the implementation of the [CustomFormatter][CustomFormatter] class. Our [CustomFormatter][CustomFormatter] inherits from the [Formatter][Formatter] class. The `Formatter` class is defined in the language library and it implements many operations to avoid cloning code and to provide the same functionality over and over. Using this type to implement serialization it is assumed that the object to be serialized implements the `ISerializable` interface. The main aim is to avoid using reflection and use custom functionality allowing to select and read values that contribute to the object state. Thanks to this, we can retrieve them from this object using the `GetObjectData` operation. As a result of this operation, we will have access to all values. We can perform serialization operations for all values. So we can repeat the writing of individual values thanks to the `WriteMember` method, which is implemented in the `Formatter` class. Next, we have operations related to creating an XML document and saving this document to a file.

Using this approach to implement serialization, it is assumed that the object to be serialized implements the `ISerializable` interface. The main aim is to read values that contribute to the object state using typical pragmatical means. By design, this functionality must be provided by the target type. An example is in the [SelfControlSerialization][SelfControlSerialization] class. Thanks to this, we can retrieve the vital values from the target object by using the `GetObjectData` method. As a result of this operation, we have access to all values even private ones,  and we can, therefore, perform serialization operations for all values even invisible outside of the target object. So, we can repeat the writing of individual values thanks to the `WriteMember` method, which is implemented in the `Formatter` class. Next, there are operations related to creating an XML document and saving this document in a file.

It is worth emphasizing that in our example we only write `double` values and it si a reason that only the `WriteDouble` method has been implemented. It creates an instance of `XElement` type passing the value and key to the constructor. It is also important here that the [CustomFormatter][CustomFormatter] class is implemented in the library. The architecture of the solution shows that this class cannot have references (cannot use), and cannot refer to the definition of a target type that is subject to the serialization process. The object that is subject to the serialization process can be of any type but we assume here that it must implement the `ISerializable` interface, and therefore must provide an implementation of the `GetObjectData` operation method.

### Reflection-based Read - Write

To prepare this example, let's use a previously defined class [Siyova16][Siyova16] that has a random name and several properties defined. All the members names are also random. The main goal of using a random definition is to explain how to deal with invisible types.

In the test project, the `ReflectionUnitTest` test class includes the [AttachedPropertyTest][AttachedPropertyTest] test method, which contains a program fragment showing how to use such a mechanism for managing a property value of an object without having to refer to its type definition. However, it should be emphasized that to implement this functionality we need to know only the name of the property and its type. This requirement must be fulfilled because the language is strongly typed. The [AttachedProperty\<TypeParameter\>][AttachedProperty] class, which is the implementation holder of the reading and writing operations, is implemented in a separate library project. So obviously the library class won't be able to refer to this type because it doesn't know it - it is invisible for many reasons. We will analyze this class based on the example of the [AttachedProperty\<TypeParameter\>][AttachedProperty] class. The example class [Siyova16][Siyova16] serves as a simulation of any type.

In the [AttachedPropertyTest][AttachedPropertyTest] method I need to create a target object of type [Siyova16][Siyova16] that is to be controlled. It is worth emphasizing that creating the target object is redundant here because, in a real scenario, we should assume that the object is already created elsewhere. In the next step, a surrogate object as a wrapper of the target object is created. The surrogate object functionality is to enable reading and writing to the selected property from the target object without referring to the type of the target object. The expected behavior of the wrapper class is that the `Value` property can be assigned to and read from. These values are transferred transparently to and from the target object that is passed to it as an actual parameter of the constructor.

The functionality enabling the possibility to manage a selected property of a target class has been implemented as a generic library class named [AttachedProperty\<TypeParameter\>][AttachedProperty]. To get more about the generic type concept check out the course or section titled "Information Computation". The library class uses a simple constructor which takes two parameters that are responsible for initializing the data members of the new object. The first parameter is used to pass references to the target object that is to be wrapped by this class. The second argument is used to pass the name of the property that is to be managed using an instance of this class. The first step of the constructor is to save the reference to the target object in the local variable. This reference will be used later. It is worth stressing that this way we cannot refer to the type of the target object. Because the target typeof the object in concern is invisible reflection is engaged and the `GetType` method is used to recover the required features of the target object. The recovered description of the target object type is conveyed by a new instance of the `Type` type. Thanks to this object, in the next step we can obtain information about the property we want to write and read. This description is saved in the next local variable. The last step will be to create an intermediary property that, thanks to the previously obtained information about the target property, will allow transferring values to/from this property.

### ✍🏻 Reflection-base serialization

Examples collected in this section are dedicated to demonstrate how to deal with the presented above scenario. It defines a few helper functions, for serialization and deserialization located in the static [XmlFile][XmlFile] class.

The `ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation` folder contains classes that represent XML schema and are used by the program as an object model of the working data.

Thanks to presented example we showed how attributed programming and reflection can be used to ensure autonomy and synchronization of object-to-stream conversion processes and vice versa.

As an example of reflection based data values access is the [Catalog][Catalog] class, which is to contain an array of CD descriptions. So here we have property, which is an array containing CD descriptions complaint with the `CatalogCD` class defined in the same file.

Let me stress again that we have two issues that we need to resolve. The first one is which of these properties should be included in the resulting stream. The second one is how we can read the values for these selected properties without directly referencing the type definition. Additionally, in general, they don't have to be properties.

## Standardization - generating classes based on schema definition

To generate classes in CSharp; I have prepared a script [GoCS.cmd][GoCS] that uses the XSD program (this program is available in the Visual Studio environment). Try to use this program to generate the classes that we previously created manually. The classes are generated automatically based on the `Catalog.xsd` schema. We should get the result in the file created manually previously.

As the result of executing the mentioned above script [GoCS.cmd][GoCS] the [Catalog][Catalog] class is generated. A consequence of generating a new program text is that all previous modification are overwritten. They disappeared, they are overwritten because a new text is generated without caring about what was there before. Hence, it is time to recall our considerations regarding partial definitions. This is an example where we could confirm that this concept is necessary when dealing with auto-generated code because auto-generated code will always ignore any modifications we make to this file. That's why the following message at the top of the generated fi;le warns not to change this file.

```txt
// <auto-generated>
//     This code was generated by a tool.
...
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
```

Thanks to the use of schema XML, we also showed how documents can be verified and how document syntax can be saved using a schema and thus automatically generate program text in various languages, ensuring data conversion between various technologies; and between different programming platforms.

## Bitstream protection

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
[system.type]: https://learn.microsoft.com/dotnet/api/system.type
[system.attribute]: https://learn.microsoft.com/dotnet/api/system.attribute
[AttributeUsage]: https://learn.microsoft.com/dotnet/api/system.attributeusageattribute

[FileExample]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams/FileAndStream/FileExample.cs#L19-L32

[AttachedProperty]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams/Reflection/AttachedProperty.cs#L17-L46

[AttributedClass]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams/Reflection/AttributedClass.cs#L17-L24
[CustomAttribute]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams/Reflection/AttributedClass.cs#L27

[AttributedClassInstanceTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L46-L55
[AttachedPropertyTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L57-L68
[ObjectFactory]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L81-L101
[AttributedClassTypeTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L39-L43
[Siyova16]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L73-L79
[typeof]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L41
[CustomAttributeTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L24-L29
[GoTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L103

[SelfControlSerializationTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/SerializationUnitTest.cs#L26-L39

[CustomFormatter]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams/Serialization/CustomFormatter.cs#L21-L153
[Formatter]: https://learn.microsoft.com/dotnet/api/system.runtime.serialization.formatter
[SelfControlSerialization]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/SelfControlSerialization.cs#L22-L79
[Catalog]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/Catalog.xsd.cs#L21-L55

[ReadWRiteTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/SerializationUnitTest.cs#L42-L57
[IStylesheetNameProvider]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams/Serialization/IStylesheetNameProvider.cs#L17-L23
[XmlFile]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams/Serialization/XmlFile.cs#L22-L97

[GoCS]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/GoCS.cmd#L1-L2

[catalogexamplexml]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/catalog.example.xml#L1-L23
