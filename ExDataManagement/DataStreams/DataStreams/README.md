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

# Implementation Examples <!-- omit from toc -->

## Table of Content <!-- omit from toc -->

- [1. Key words](#1-key-words)
- [2. Streaming Data Preface](#2-streaming-data-preface)
- [3. File and Stream Concepts](#3-file-and-stream-concepts)
  - [3.1. Operating System Context](#31-operating-system-context)
  - [3.2. Program Context](#32-program-context)
    - [3.2.1. File Class](#321-file-class)
    - [3.2.2. Stream class](#322-stream-class)
  - [3.3. XML-based Presentation](#33-xml-based-presentation)
  - [3.4. XML-based Validation](#34-xml-based-validation)
  - [3.5. XML-based Classes Generation](#35-xml-based-classes-generation)
- [4. Attributes](#4-attributes)
  - [4.1. Profiling Development Environment](#41-profiling-development-environment)
  - [4.2. Attribute Definition](#42-attribute-definition)
  - [4.3. Attribute Use Based Directly on Type Definition](#43-attribute-use-based-directly-on-type-definition)
  - [4.4. Attribute Use Based Indirectly on Type Instance](#44-attribute-use-based-indirectly-on-type-instance)
  - [4.5. Summary](#45-summary)
- [5. Objects Serialization](#5-objects-serialization)
  - [5.1. Introduction](#51-introduction)
  - [5.2. Self-controlled](#52-self-controlled)
  - [5.3. Attributes and Reflection](#53-attributes-and-reflection)
  - [5.4. Reflection-base Object State](#54-reflection-base-object-state)
- [6. Bitstream Cybersecurity](#6-bitstream-cybersecurity)
- [7. See Also](#7-see-also)

## 1. Key words

Bitstream, File, File System, XML, XSLT, HTML, XmlSerializer, Save file, Transformation, Saving text files, Local File Systems, Open and read file, XML Schema, Common File Format, Data Access, Serialization, Validation,Visualization

## 2. Streaming Data Preface

The external data is recognized as the data we must pull or push from outside of a boundary of the process hosting the computer program. In general, the external data may be grouped as follows:

- **streaming** - bitstreams managed using content of files, or network payload
- **structural** - data fetched/pushed from/to external database management systems using queries
- **graphical** - data rendered on Graphical User Interface (GUI)

This section collects descriptions of examples explaining the usage of the **streaming** data.

## 3. File and Stream Concepts

### 3.1. Operating System Context

Using the file explorer let's get details about the `.Media` folder containing files used in the examples:

![Fig. MediaFolderAnimated](../.Media/MediaFolderAnimated.gif)

We have different files there, but similar descriptive data, i.e. metadata, are defined for all of them. Among these data, `Name`, `Date`, `Type`, `Size`, `Data created`, and much other information that may be useful, but the most important thing is, of course, the content of the file.

After double-clicking on the selected file (for example `PodpisCyfrowy.png`) an image will appear.

![PC](../.Media/PodpisCyfrowy.png)

Here we may ask a question - how to describe this behavior? Well, a program was launched. This program must have been written by a programmer. The program opens the file as input data formatted as a bitstream, so the programmer had to know the syntax and semantics rules that were used in this file. The data contained in the file makes it possible to show the content graphically on the computer screen. This is the first example of graphical representation, but we will return to this topic later.

### 3.2. Program Context

Using a code snippet located in the [FileExample class][FileExample] differences between file and stream may be explained from a program point of view. We can learn from this example that the `File` is a static class that represents the available file system and provides typical operations against this file system. The content of the file is formatted as a bitstream and represented by the `Stream` class. It is an abstract class that represents basic operations on a data stream (on the stream of bytes), which allows mapping the behavior of various media that can be used to store or transmit data as the bitstream. From this perspective, it can be proved, that file content is always a bitstream (a stream of bytes).

#### 3.2.1. File Class

Let's try this piece of program [FileExample class][FileExample] is checked by a unit test. As we can see, this unit test was successful. But let's try to replace this caption `Today is` with the polish translation `dziś jest` and let's do the test again. We already have the result. Unfortunately, the result is not positive and we see that the expected text is different from the text we received. So the behavior of our program is different from before because we introduced Polish letters. There is also a typo here, but it doesn't matter here. What matters is that one letter has been omitted, the letter s with a dash. Why? Because I chose an encoding that does not contain Polish letters. If we take an encoding that contains Polish letters and perform this test again, this time we see that the test is green. This means that the content of the file corresponds to the string of characters, the text that was saved to it, including the letters that are national letters.

I have files of different types here, which would indicate that they are data for different programs. But for example, if we click on this file twice, we will receive information from the operating system that it does not know what program it is associated with. What program can open this file? But I have a program here that can open any file. This program, like the previous one, opens this file, reads its contents, and displays its contents on the screen using hexadecimal code. This means that a file is actually a composite, a sequence of bytes. Since each byte is a sequence of bits, we can conclude that the content of each file is a sequence of bits.

Let us examine the behavior of files using a specific programming example. Here I have the `CreateTextFile` method that will save a text consisting of the words 'Today is' and the current date to a file. The word `File` appears at the very beginning. The F12 key will take us to the definition. Here we will notice that this class is a static class. So there are no instances of it, we cannot create objects of this class. So this class cannot represent an individual file. Can represent all files. It provides operations related to files, where I used one of them and this operation deletes the file whose name was given as a parameter as the current parameter. 

``` csharp
      File.Delete(name);
```

Another interesting thing in this example is the `Open` operation. The question is why to perform the open operation on a file, and what this operation would be used for. We want to save the text, but we perform open operations. Here the answer is provided by a parameter called `FileAccess`. It is obviously an enumeration type providing all option that can be used. We see that we have several options here. I chose the write operation because I want to write to this file. Well, this operation is fundamental to the use of files that we will use later, because it causes the file that is being created or opened, if it exists, to become a critical section. What does it mean? This means that no other process can operate on this file once we have opened it. So if this file were to be used or shared by multiple applications, a lock placed by the operating system will prevent this and only allow one process to write to the file. This can have crucial consequences in a situation where for example we use a file in a hospital in which patient data is saved and is used in various places by doctors. To gain access to data at the reception, where further names are added. After someone opens the file for writing - as in this example - no one else can use the file.

So what's important to emphasize here is that the `File` class does not represent a file. The class represents the file system. It contains operations that we can perform on any file that is available to the computer.

The `Open` operation available in the `File` class creates an object (instance) of the `Stream` class, as follows:

``` CSharp
      using (Stream _stream = File.Open(name, FileMode.OpenOrCreate, FileAccess.Write))
      {
        FileContent = String.Format(CultureInfo.InvariantCulture, "Today is {0}", DateTime.Now);
        byte[] _content = Encoding.ASCII.GetBytes(FileContent);
        _stream.Write(_content, 0, _content.Length);
      }

```

The F12 key takes us back to the definition and in this case, we see that it is an abstract class. What does it mean? This means that it can represent not only files but can also represent other resources. It is an abstract class and thanks to its various implementations we can ensure the polymorphic behavior of various objects it represents. In simpler terms, if this class represents a file in the file system, these operations will be performed by the operating system on behalf of a file system, if this class represents, for example, a computer network and operations related to a computer network, then again we will have to deal with the operations that are performed, but this time not on resources related to the file system but on resources related to the computer network. If this class represents an object that is in memory, its behavior will also be completely different than the two previously mentioned ones. We will come back to this topic by discussing various examples in which the `Stream` class functionality has been overwritten, and inherited by classes that represent different behaviors, i.e. polymorphic behaviors of various resources that we can use to store and manage data.

The next line does not add much to the considerations regarding the use of files to store data processed by the program. This line is where the final formatting of the string of characters to be saved takes place. The only interesting point is the possibility of choosing the syntax that will be used to write the date text form. This syntax varies for different natural languages. I chose a variant that is independent of the natural language selection by the environment in which the program is executed.

In the next lines of the program, we write to the file. The file, as I have already said, is represented by the `Stream` type, and to write data to it first, we must prepare it.

#### 3.2.2. Stream class

We must be aware of how the data can be prepared, let's look at the definition. Analyzing the possibilities of writing to the stream we see that all `Write' operations operate on a sequence of bytes. So in this case, and also in all other cases where we will use a stream to represent other data media, the data will always be organized in such a way that they are simply streams of bytes, which means a stream of bits.

Since a stream of characters must be specially prepared in some way to be saved in a file, there must be a relationship between the stream of characters, i.e. text, and the binary content of the file. Let me remind you that at the very beginning, we said that a program is also a text. Let's look at this example, which starts with these two characters. If we open this file in a program that allows us to analyze the content at the binary level, we will see that this file does not start with..., these first two characters appear only in some position, and this file does not start with these characters. This, among other things, indicates that there is some kind of ambiguity between the text that is displayed on the computer screen, i.e. here the first two characters, and the content of the file, the binary file. We say that this relationship between the text and the bitstream is `Encoding`. We have different standards for converting bits to characters and characters to bits. One of them is the ASCII standard. A widely known standard that contains definitions - a table that tells how to represent binary characters. The table is finished, therefore the number of characters is strictly defined.

Since a stream of characters must be prepared in some way to be saved in a file, there must be a relationship between the string of characters, i.e. text, and the binary content of the file. Let me remind you that at the very beginning, we said that a program is also a text. Let's look at this example, which starts with these two characters. If we open this file in a program that allows us to analyze the content at the binary level, we will see that this file does not start with `...`, these first two characters appear only in some position, and this file does not start with these characters. This, among other things, indicates that there is some kind of ambiguity between the text that is displayed on the computer screen, i.e. here the first two characters, and the content of the file, the binary file. It can be stated that this relationship between the text and the bitstream is defined by `Encoding`. We have different standards for converting bits to characters and characters to bits. One of them is the ASCII standard. A widely known standard that contains definitions - a table that tells how to represent binary characters. The table is finished, therefore the number of characters is strictly defined.

The last thing remains to be explained, namely the close operation, which we perform on the stream, since the open operation appeared at the beginning, naturally the close operation must appear at the end. It is again fundamentally important because it closes the file, which means that it closes the critical section at this point. So from now on, others will also be able to use this file - they will be able to open this file. Therefore, it should appear as quickly as possible, i.e. it should appear immediately when we stop working with this file. It means that we will not be going to perform further operations on this file within the program. The question is what will happen when, for example, an exception occurs in the program between opening a file and closing it. The `Close` operation will virtually never be executed. We will never reach this line. So this file will be closed by the environment at some point. However, this will not happen immediately. Therefore, we should use different operations here, a different approach, and take advantage of the fact that `Stream`, let's go F12 again to the definition, implements the IDisposable interface, which allows the use of the `using` instruction. The final form of the example would look something like this, in which we have the operation, statement `using`, which causes the dispose operation to be executed against the `stream` variable last. If the string or block of statements that is part of the using operation is interrupted, the `Dispose` operation will also be executed. Thanks to this, we can ensure that the file will actually be closed immediately when the next program statements will no longer have access to the `stream` variable due to the fact that it goes out of visibility range.

### 3.3. XML-based Presentation

Using bitstreams (file content) we must face a problem with how to make bitstreams human readable. First answer we know from the examples above, namely the bitstream must be compliant with a well-known application. Unfortunately, this answer is not always applicable. Therefore we should consider another answer, namely human-readable representation should be close to natural language. Of course, we have no measure here and therefore it is difficult to say whether a bitstream is close enough to natural language to be comprehensible. The first requirement for humans to understand the stream is that it has to be formatted as text. To recognize bitstream as the text directly or indirectly an encoding must be associated. An example of how to associate directly an encoding with the bitstream is the following XML code snippet:

```xml
<?xml version="1.0" encoding="utf-8"?>
```

The next requirement, common for both humans and computers, is a bitstream association with the comprehensive syntax rules. To make the rules comprehensive for humans the bitstream should have been formatted as a text. Finally, semantic rules should be associated with the bitstream that allows to assigning of meaning to bitstreams.

The [ReadWRiteTest][ReadWRiteTest] sample code demonstrates how to save working data in a file containing an XML document, which next can be directly presented in other applications, like MS Word editor or Internet Explorer. In this concept, it is assumed that the bitstream formatted as XML is transformed using a stylesheet before being presented. An XML stylesheet is a set of rules or instructions for transforming the structure and presentation of XML documents. It defines how the data in an XML file should be formatted. It is the simplest way to detach a custom document content from its formatting to be presented as graphical data provided that the original document is compliant with the XML specification.

After implementation of the [IStylesheetNameProvider][IStylesheetNameProvider] interface by the [Catalog][Catalog] class we can convey information about the default stylesheet that may be used to create an output XML file. Thanks to the implementation of the mentioned interface information about the stylesheet (`XSLT` file) is added to the XML document and can be used by any generic application to open the file and translate the content, for example [catalog.example.xml][catalogexamplexml]:

``` XML
<?xml-stylesheet type="text/xsl" href="catalog.xslt"?>
```

This XML declaration defines an additional document that is a stylesheet document and it contains a detailed description that allows to convert the source XML document into other text-based document. If we open the source document by clicking on it, we will open a web browser and the source file will be displayed in a graphical form that can be much easier to understand by people who are not familiar with XML technology. If we look at the source of this document using the browser context menu, we can see that it is simply the earliest XML document. This document that we originally had just got transformed thanks to browser transformation. So browsers have a built-in mechanism to convert an XML file to any other text file, in this case, it is an HTML file based on a defined XML stylesheet document.

### 3.4. XML-based Validation

If we are talking about exchanging data between different applications or between an application and a human, the issue of bitstream correctness arises. This issue should be considered on two independent levels. The first one is the correctness of the bitstream as a certain stream of signs, i.e. when the syntax rules are met. The second one is determined by the possibility of assigning information to these sequences and therefore assigning meaning to a bitstream.

To better understand these issues, let's look at them in the context of an example [catalog.example.xml][catalogexamplexml]. The following discussion is scoped to the XML format but the presented approach should be recognized as a universal one.

The XML (Extensible Markup Language) is a language that defines syntax rules. For example, in the mentioned above XML text after replacing the closing name of the `CD` element (by `CD1` instead of `CD` for example) we get an XML syntax error. Syntax error means that the file is not compliant with the XML standard and should not be used anymore. But after replacing the name of the opening markup of the element with the same `CD1` name then this file is correct in the context of the XML syntax. However, it is difficult to imagine that two subsequent elements will have different names but will represent the same information. So at this point, we can say that this file is compliant with the XML standard, with the XML syntax. However, it does not represent the semantics we would expect.

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

### 3.5. XML-based Classes Generation

If we are talking about communication between different remote applications, we must consider a scenario in which these applications are written in different programming languages or by different people. In this case, the problem arises of how to create types in other development environments that will represent the same information. Since we recognized the schema as a good idea to validate XML documents, i.e. XML texts, and check whether the XML text is the XML document we expect, then maybe we should turn the issue upside down and generate types in selected programming language based on XML schema.

Let's try to see how this goal can be achieved using an example. To generate classes in CSharp, I have prepared a script [GoCS.cmd][GoCS] that uses the XSD command line application (this program is available in the Visual Studio environment). This program is used to generate the classes that we previously created manually. The classes are generated automatically based on the `Catalog.xsd` schema. We should get the result in the file created manually previously.

As the result of executing the mentioned above script [GoCS.cmd][GoCS] the [Catalog class][Catalog.cs] is generated. A consequence of generating a new program text is that all previous modifications are overwritten - a new text is generated without caring about what was there before. Hence, it is time to recall our considerations regarding partial definitions. This is an example where we could confirm that this concept is necessary when dealing with auto-generated code because it creates new content ignoring any modifications made to this file. That's why the following message at the top of the generated file warns not to change this file.

```txt
// <auto-generated>
//     This code was generated by a tool.
...
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
```

In conclusion, thanks to the application of the XML schema, XML documents can be verified against additional syntax rules, and appropriate definitions in various languages may be generated, ensuring data conversion between various technologies and different programming platforms.

## 4. Attributes

### 4.1. Profiling Development Environment

Let's start by creating a very simple [AttributedClass][AttributedClass] example used as a starting point for the discussion on attributes. It has only one method but its functionality is not important in the context of the discussion. The method creates an object and returns it. Imagine, that after some time, we conclude that this method is not perfectly correct anymore and we want to avoid referencing it. We know it is used in many places in the program, so to preserve backward compatibility we cannot simply remove it from the program text to avoid triggering a bunch of errors. Hence, we must keep in place this definition, but we should associate additional information with code in a declarative way. This additional information should prevent it from being used in the program any further. This way we try to fix an issue by preventing referencing of inadequate code instead of replacing it. In other words, there will be no further references to it in new programs.

We may use the `Obsolete` attribute for this purpose. To observe this attribute and the effects it causes, let's open a test window and add a test method. In the test method, we simply call the method that we previously marked with the `Obsolete` attribute and we see that the compiler now reports a warning. It is also available in the error list. Therefore, this is a clear signal that we should not use this method because it is no longer valid.

This warning should make us use some other alternative solutions. Of course, we could use a regular comment instead. Unfortunately, this will cause us to lose the warning to avoid using this method in newly created program fragments. Based on this, we can conclude that a comment is a very good tool for **communicating with the reader** of the program text - after all, any program is a text.  On the other hand, attributes are a concept for **communicating with the compiler**. And as we will see next, not only with the compiler.

The F12 key takes us to the definition and we see that the attribute is a class that is derived from the [Attribute][system.attribute] class. Now we can formulate a key question; whether we can define our attributes, which we may use to associate additional information with code in a declarative way to be used at run-time.

### 4.2. Attribute Definition

To create a custom attribute I have created an additional [CustomAttribute][CustomAttribute] class. As before, it inherits from the [System.Attribute][system.attribute] base class. The main goal of it is to provide additional information related to the program content. Therefore, to define it, we need to specify the following things:

- what additional information do we want to convey using it
- how the information is to be represented using types
- how to restrict the location of attribute usage

The first two tasks - related to the selection of information that is to be conveyed using an attribute can be achieved by choosing how this information is to be represented (data type selection) and adding appropriate properties (value holders) that will convey this data. In this example, it is the `Description` property, which is of the `string` type. This way some descriptions expressed in natural language may be added to the target construct. Notice that also a constructor is added here, which is responsible for initializing this description when the attribute is instantiated.

The next task of how to restrict attribute usage may be accomplished by associating an existing, dedicated attribute with a definition of a new attribute class. It is a message to the compiler. In other words, we use an existing attribute to define a new one. The [AttributeUsage][AttributeUsage] attribute is predefined by the built-in definitions of the C# programming language that allows expressing where adding a new attribute makes sense.

And here's a crucial note about terminology. I have used the term attribute for both

- to name a class that is derived from the [System.Attribute][system.attribute] base class
- as an identifier that is used elsewhere and surrounded between square brackets

Maybe it sounds puzzling but it is a typical recurring reference to the joint terms.

Let's examine the features of the newly created [CustomAttribute][CustomAttribute] class using the [CustomAttributeTest][CustomAttributeTest] test method. It just instantiates an object of this class traditionally using the `new` operator and then compares the value of the embedded property value with an expected one. This way we can prove that this class behaves like any other regular class.

Keeping in mind that the newly created attribute is a class, let's try to use it to add additional information to the previously defined [AttributedClass][AttributedClass] class. So a linguistic construct appears, where between square brackets we will have the name of the class and additional data that we want to be associated with this class. Since this is additional data, we call it metadata; in other words, data describing data. Since in this case, the data being described is a linguistic construct, there is the text of the program - the program becomes data. The question is how this metadata may be used throughout the processing process, hence at run-time. Let's see this with an example of a unit test where we try to recover the associated data.

From this example, we see that it can also be associated with actual parameters placed between round brackets. In other words, it looks like a method call, doesn't it? Moreover, because the name is the same as the class name it looks like a constructor call. Unfortunately, the detailed discussion of these linguistic constructs syntax is beyond the scope of the article. To possibly fill in a gap in this respect, I recommend the C# language user manual. To make the discursion generic, from now on, we will only focus on the semantics, i.e. on the meaning, of these entries.

### 4.3. Attribute Use Based Directly on Type Definition

So let's add a test method [AttributedClassTypeTest][AttributedClassTypeTest] in a test class, in which the code will refer to [AttributedClass][AttributedClass] that has been associated with an attribute. To refer to the type the [typeof][typeof] keyword is applied. As a result of using  [typeof][typeof] an object of the [Type][system.type]  type is instantiated for the selected type. An object created this way contains details of the source type definition. And here we encounter reflection for the first time. Reflection, which means that we can create objects in the program that represent selected linguistic constructs. In this case, `_objectType` is a variable of the [Type][system.type] type that will contain a reference to the object representing the [AttributedClass][AttributedClass] class definition. Notice that to avoid code cloning the main test functionality is gathered in the [GoTest][GoTest] method. Then, from this object, we can read all attributes related to the selected type using the `GetCustomAttributes` instance method. Additionally, in this case, it is specified that we are only interested in attributes of the selected type. We can then determine that there is returned an array with exactly one element in it. This element is of the [CustomAttribute][CustomAttribute] type, i.e. the type we associated with the class as a class attribute.

Therefore, we can return to the discussion about semantics, i.e. the meaning of the notation between square brackets. We see that the `GetCustomAttributes` method creates objects. Objects that are associated with selected language construct, in this case, [AttributedClass][AttributedClass]. It looks the same as if we used the `new` keyword to create an object of the [CustomAttribute][CustomAttribute] class. After creating the object it can be used as if it had been created using the `new` keyword.

So, once again, back to the nutshell of the topic. We can ask what role this linguistic construct plays - where the class name is placed between square brackets. This class has to be an attribute, i.e. a class identifier that is derived from the [System.Attribute][system.attribute] class. We see that the main purpose of this construct is to describe the instantiation of an object, and therefore answers the question of how to create an object and populate it with the state values. This way we can conclude that it is equivalent to the constructor call, which is typically placed after the `new` operator. Here it plays the same role except that it is not part of the expression in the assignment statement. Hence it has to provide all values for the constructor and initial parameter for the members of the attribute class.

The [AttributedClass][AttributedClass] class is preceded by the [CustomAttribute][CustomAttribute]. In the unit test, we have the [AttributedClassTypeTest][AttributedClassTypeTest] test method, which proves how to retrieve features of the definitions of this type by creating an instance of the [Type][system.type] type. The main testing stuff has been aggregated in the [GoTest][GoTest] method to reuse this functionality and avoid code cloning. This example shows that we can recover type features that are provided in the form of attributes. Additionally, we can perform operations on attributes (instances of classes derived from the [System.Attribute][system.attribute] base type) that are created as a result of the `GetCustomAttributes` operation. In this approach, the identifier of the type definition is directly used. In this code snippet, the [typeof][typeof] is an operator, which is used to instantiate an object that represents metadata of a type, utilizing the identifier of an attribute type definition. The argument to the [typeof][typeof] operator must be the name of a type definition.

### 4.4. Attribute Use Based Indirectly on Type Instance

In the above example [AttributedClassTypeTest][AttributedClassTypeTest] there is a weak point. Unfortunately, talking about serialization/deserialization we have to implement appropriate algorithms avoiding direct reference to the type definitions because we have to assume that the definition is invisible, hence we cannot use the keyword `typeof`. In general, we must assume that the type is defined later, and it doesn't matter if it is defined milliseconds, or years later. Let's try to imagine a scenario in which we have to deal at run-time with objects whose types we do not know.

To prepare an example that resembles the above scenario, I have added the [Siyova16][Siyova16] class with all identifiers created randomly by a password generator to stress that we should avoid using them as members of a type definition. The main idea of creating a random definition is to give the impression and stress that there is no need to refer directly to them while implementing the required functionality. To create a generic solution the reality is that we need to be prepared for a situation where referencing identifiers directly is impossible. The reflection can be applied to both cases, so we can investigate it using a simplified case.

To continue building an example in which we will show how to operate on objects of unknown types, I have defined the [ObjectFactory][ObjectFactory] class. The main task of this class is to create objects of pseudo-random type. Precisely, the objects are only of different types, but they have one thing in common, namely, they are preceded by the same [CustomAttribute][CustomAttribute] attribute. The [AttributedClassInstanceTest][AttributedClassInstanceTest] test shows that it is possible to detect this feature without referring to identifiers associated with the object type. For this purpose, it mimics the creation of objects of various types using the dedicated [ObjectFactory][ObjectFactory] class. Regardless of the object type, the same [GoTest][GoTest] test method is performed, which checks the presence of the selected attribute. For this purpose, an enumeration type is defined in this class, in which the values are also randomly generated. It is worth stressing that there is no direct relationship between the enum identifier and the identifier of the instantiated type.

The [ObjectFactory][ObjectFactory] method is responsible for creating objects of various types. Because it creates objects of different not related to each other types, the return value must be of the `object` type, which allows returning objects of any type. Therefore, after calling [ObjectFactory][ObjectFactory] we don't know the type of the returned instance. Hiding the type of the created objects is intended to mimic operation on unknown types. Of course, this is just a simulation for this particular example to make the example as simple as possible. I want to emphasize that the tests are solely used to demonstrate certain features and the possibility of using reflection for serialization/deserialization.

To show how to operate on objects without referring directly to their type definitions we have to recover the features of types from their instances. To follow up, check out the example from the [AttributedClassInstanceTest][AttributedClassInstanceTest] test method. Once again, the test method instantiates a variety of types having the same feature and executes a test against this feature.

How to recover the features of a type referring directly to this type we already know. This can be done by creating a [Type][system.type] instance for the selected type definition using the [typeof][typeof] keyword and an identifier of this definition. In the case of an object for which the type is not known for some reason, the `GetType` instance method inherited from the [Object][Object] type comes in handy. Let me remind you that this operation is inherited from the [Object][Object] base class. It is the ultimate base class of all .NET classes; it is the root of the type hierarchy. So in our case, reflection starts when an instance of [Type][system.type] is created using the `GetType` method. It should be emphasized here that based on this example, we can conclude that reflection is related even to the [Object][Object] base type.

### 4.5. Summary

To make a summary of the discussion above, regardless of whether we have a type definition visible or we need to bother with recovering the type description from an instance instead, the common point in the process of further processing and converting the state of objects to bitstreams form and vice versa is to create an instance of the [System.Type][system.type] abstract type, which holds a detailed description of the type in concern. Because it is abstract we cannot create this instance directly and have to use the [typeof][typeof] keyword or employ the `GetType` instance method. Going right to the point, since in both cases we can reach a common point, we can have the same test method [GoTest][GoTest] to avoid text cloning.

## 5. Objects Serialization

### 5.1. Introduction

To implement serialization/deserialization there is one more issue to discuss, namely how to manage the state of an object, i.e. reading and writing values to its selected members without directly referring to its type. The main problem is that if the concrete type is not visible we do have access to its members. We will analyze two approaches to implement this algorithm:

- **self controlled** - The type exposes functionality that enables reading from and assigning to properties constituting the state
- **attributes and reflection** - metadata added by attributes to select state contributors and reflection that enables reading from and assigning to properties constituting the state

### 5.2. Self-controlled

To illustrate this scenario, our task now is to implement a library class that enables reading from and assigning to properties defined as a member of a type that is a candidate to be serialized.

The [SelfControlSerialization][SelfControlSerialization] class contains three properties. One of which is named `AverageIncome`, and returns a calculated value, so it returns the result of an expression executed against values stored locally. This example shows that to recreate an object of this class, we only need to transform two values because the third one is always calculated, so there is no need to preserve it in the bitstream. The constructor of this class is responsible for recovering the initial values (state) of this class when the object is created.

To transform an instance of this class (to serialize it), first, an attribute has to be associated with it that indicates that it is intended for serialization. However, this does not solve the issue of selecting the values that contribute to the state of the object. The question is how to do it.

The first approach to selecting values contributing to the object state is to have built-in functionality in the target type allowing the selection of appropriate values. It means moving the responsibility of state selection to the target class. Unfortunately, it solves only partially the problem because this functionality must be implemented each time. Let's look at the serialization process using a unit test in this context. The test method [SelfControlSerializationTest][SelfControlSerializationTest] implements functionality well suited for this purpose.

In this test class, we create an object of the target class that is to be serialized. In the next step, we must have a library class that implements the serialization functionality. I have prepared a class called [CustomFormatter][CustomFormatter]. A bit later I will describe this class in more detail. After implementing the serialization functionality we can create a bitstream. Let's use a file stream with a given name for this purpose and serialize the object to it, i.e. write a bitstream to this file content. After that, the content contains the state of the serialized object according to the selection made by the object itself thanks to the implementation of the `ISerializable` interface.

After preparing the serialization result, in the next step, let's check that this file exists and that its length indicates that values that constitute the object's state have been written to it. Then let's read this file and save it locally to manually examine its content.

But now let's move on to the implementation of the [CustomFormatter][CustomFormatter] class. Our [CustomFormatter][CustomFormatter] inherits from the [Formatter][Formatter] class. This class is defined in the language library and it implements many operations to avoid cloning code and implementing the same functionality over and over. Using this type to implement serialization, it is assumed that the object to be serialized implements the `ISerializable` interface. The main aim is to avoid using reflection and, instead, use embedded functionality allowing to read values that contribute to the object state. Thanks to implementing `ISerializable`, we can retrieve them from this object using the `GetObjectData` operation.

Again, using this approach to implement serialization, it is assumed that the object type to be serialized implements the `ISerializable` interface. The main aim is to read values that contribute to the object state using typical programming means. By design, this functionality must be provided by the target type. An example is in the [SelfControlSerialization][SelfControlSerialization] class. Thanks to this, we can retrieve the vital values from the target object by using the `GetObjectData` method. As a result of this operation, we have access to all values even private ones, and we can, therefore, perform serialization operations for all values even invisible outside of the target object. So, we can repeat the writing of individual values thanks to the `WriteMember` method, which is implemented in the `Formatter` class. Next, there are operations related to creating an XML document and saving this document in a file.

It is worth emphasizing that in our example we only write `double` values and it is a reason that only the `WriteDouble` method has been implemented. It creates an instance of the `XElement` type passing the value and key to the constructor. It is also important here that the [CustomFormatter][CustomFormatter] class is implemented in the library.

To implement deserialization we must create an instance of the type and populate value holders to initialize the object state. To implement this functionality the dedicated [SelfControlSerialization][SelfControlSerializationConstructor] constructor must be provided.

The architecture of the solution shows that this class cannot have references (cannot use), and cannot refer to the definition of a target type that is subject to the serialization process. The object that is subject to the serialization process can be of any type but it must implement the `ISerializable` interface and therefore must provide an implementation of the `GetObjectData` operation method. Because the target type is invisible, it can be recognized as a typical scenario where the dependency injection design pattern is required.

```csharp
public interface ISerializable
```

### 5.3. Attributes and Reflection

To prepare this example, let's use a previously defined class [Siyova16][Siyova16] that has a random name and several properties defined. All the members names are also random. The main goal of using a random definition is to explain how to deal with invisible types.

In the test project, the `ReflectionUnitTest` test class includes the [AttachedPropertyTest][AttachedPropertyTest] test method, which contains a program fragment showing how to use such a mechanism for managing a property value of an object without having to refer to its type definition. However, it should be emphasized that to implement this functionality we need to know only the name of the property and its type. This requirement must be fulfilled because the language is strongly typed. The [AttachedProperty\<TypeParameter\>][AttachedProperty] class, which is the implementation holder of the reading and writing operations, is implemented in a separate library project. So obviously the library class won't be able to refer to this type because it doesn't know it - it is invisible for many reasons. We will analyze this class based on the example of the [AttachedProperty\<TypeParameter\>][AttachedProperty] class. The example class [Siyova16][Siyova16] serves as a simulation of any type.

In the [AttachedPropertyTest][AttachedPropertyTest] method I need to create a target object of type [Siyova16][Siyova16] that is to be controlled. It is worth emphasizing that creating the target object is redundant here because, in a real scenario, we should assume that the object is already created elsewhere. In the next step, a surrogate object as a wrapper of the target object is created. The surrogate object functionality is to enable reading and writing to the selected property from the target object without referring to the type of the target object. The expected behavior of the wrapper class is that the `Value` property can be assigned to and read from. These values are transferred transparently to and from the target object that is passed to it as an actual parameter of the constructor.

The functionality enabling the possibility to get access to a selected property of a target class has been implemented as a generic library class named [AttachedProperty\<TypeParameter\>][AttachedProperty]. To get more about the generic type concept check out the course or section titled [Programming in Practice - Information Computation; Udemy course, 2023][udemyPiPIC] . The library class uses a simple constructor which takes two parameters that are responsible for initializing the data members of the new object. The first parameter is used to pass references to the target object that is to be wrapped by this class. The second argument is used to pass the name of the property that is to be managed using an instance of this class. The first step of the constructor is to save the reference to the target object in the local variable. This reference will be used later. It is worth stressing that this way we cannot refer to the type of the target object. Because the target type of the object in concern is invisible reflection is engaged and the `GetType` method is used to recover the required features of the target object. The recovered description of the target object type is conveyed by a new instance of the [Type][system.type] type. Thanks to this object, in the next step we can obtain information about the property we want to write and read. This description is saved in the next local variable. The last step will be to create an intermediary property that, thanks to the previously obtained information about the target property, will allow transferring values to/from this property.

### 5.4. Reflection-base Object State

Examples collected in this section are dedicated to demonstrate how to deal with the presented above scenario. It defines a few helper functions, for serialization and deserialization located in the static [XmlFile][XmlFile] class.

The `ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation` folder contains classes that represent XML schema and are used by the program as an object model of the working data.

Thanks to presented example we showed how attributed programming and reflection can be used to ensure autonomy and synchronization of object-to-stream conversion processes and vice versa.

As an example of reflection based data values access is the [Catalog][Catalog] class, which is to contain an array of CD descriptions. So here we have property, which is an array containing CD descriptions complaint with the `CatalogCD` class defined in the same file.

Let me stress again that we have two issues that we need to resolve. The first one is which of these properties should be included in the resulting stream. The second one is how we can read the values for these selected properties without directly referencing the type definition. Additionally, in general, they don't have to be properties.

## 6. Bitstream Cybersecurity

- [In the file READMECryptography](..\READMECryptography.md)

## 7. See Also

- [XSL\(T\) Languages][XSLW3C]
- [Serialization in .NET][STLZTN]
- [XML Schema Definition Tool (Xsd.exe)][XSD]

[XSLW3C]: (https://www.w3schools.com/xml/xsl_languages.asp)
[XSD]: (http://msdn.microsoft.com/library/x6c1kb0s.aspx)
[STLZTN]: (http://msdn.microsoft.com/library/7ay27kt9.aspx)
[system.type]: https://learn.microsoft.com/dotnet/api/system.type
[system.attribute]: https://learn.microsoft.com/dotnet/api/system.attribute
[AttributeUsage]: https://learn.microsoft.com/dotnet/api/system.attributeusageattribute

[udemyPiPIC]: https://www.udemy.com/course/information-computation/?referralCode=9003E3EF42419C6E6B21
[FileExample]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams/FileAndStream/FileExample.cs#L19-L32

[AttachedProperty]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams/Reflection/AttachedProperty.cs#L17-L46

[AttributedClass]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams/Reflection/AttributedClass.cs#L17-L24
[CustomAttribute]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams/Reflection/AttributedClass.cs#L27

[AttributedClassInstanceTest]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L46-L55
[AttachedPropertyTest]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L57-L68
[ObjectFactory]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L81-L101
[AttributedClassTypeTest]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L39-L43
[Siyova16]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L73-L79
[typeof]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L41
[CustomAttributeTest]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L24-L29
[GoTest]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams.UnitTest/ReflectionUnitTest.cs#L103

[SelfControlSerializationTest]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams.UnitTest/SerializationUnitTest.cs#L26-L39

[CustomFormatter]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams/Serialization/CustomFormatter.cs#L21-L153
[Formatter]: https://learn.microsoft.com/dotnet/api/system.runtime.serialization.formatter
[SelfControlSerialization]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/SelfControlSerialization.cs#L22-L79
[Catalog]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/Catalog.xsd.cs#L21-L55
[Catalog.cs]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/Catalog.cs#L18-L120

[ReadWRiteTest]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams.UnitTest/SerializationUnitTest.cs#L42-L57
[IStylesheetNameProvider]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams/Serialization/IStylesheetNameProvider.cs#L17-L23
[XmlFile]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams/Serialization/XmlFile.cs#L22-L97

[GoCS]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/GoCS.cmd#L1-L2

[catalogexamplexml]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/catalog.example.xml#L1-L23

[Object]: https://learn.microsoft.com/dotnet/api/system.object
[SelfControlSerializationConstructor]: https://github.com/mpostol/TP/blob/a746ad26c7bf5c288efee7988eaffbb3810dfaec/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/SelfControlSerialization.cs#L61-L66
