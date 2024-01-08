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

# Data Streams

- [Data Streams](#data-streams)
  - [Key words](#key-words)
  - [Introduction](#introduction)
  - [File and Stream Concepts](#file-and-stream-concepts)
    - [Introduction](#introduction-1)
    - [BitStream Format](#bitstream-format)
      - [XML Format](#xml-format)
      - [Introduction](#introduction-2)
      - [Catalog XML](#catalog-xml)
      - [Standardization of the output stream](#standardization-of-the-output-stream)
  - [Attributes](#attributes)
  - [BitStream Protection](#bitstream-protection)
  - [Serialization](#serialization)
    - [Fundamentals](#fundamentals)
    - [Useful Technologies](#useful-technologies)
      - [Validation](#validation)
      - [Visualization](#visualization)
      - [Reflection](#reflection)
      - [Attributes](#attributes-1)
    - [Main Technology Features](#main-technology-features)
    - [Access to Object State Values](#access-to-object-state-values)
      - [Self Controlled](#self-controlled)
      - [Reflection-based](#reflection-based)
    - [Graph of Objects Serialization](#graph-of-objects-serialization)
      - [Reflection-Based Serialization Example](#reflection-based-serialization-example)
      - [SerializationUnitTest](#serializationunittest)
  - [See Also](#see-also)

## Key words

Bitstream, File, File System, XML, XSLT, HTML, XmlSerializer, Save file, Transformation, Saving text files, Local File Systems, Open and read file, XML Schema, Common File Format, Data Access, XML Serialization, Data Validation, Data Visualization

## Introduction

This folder `ExDataManagement\DataStreams` directly or indirectly contains examples related to information representation as a bitstream and is devoted to discussing selected programming issues related to their management.

If we write a program to automate information processing, we inevitably have to operate on data representing this process. Generally, we can distinguish operations related to reading input data, permanently preserving intermediate data, transferring data between individual applications, and saving the final data somewhere after completing the entire processing process. All these requirements can be accomplished using the concept of file. Even sending data between applications can be done using a file server, distributed file system, Google Drive, One Drive, and finally a Pendrive.

## File and Stream Concepts

### Introduction

This is where the term file system came into play. Without going into details about the structure of the computer and the operating system, we can enigmatically state that it is a resource available in virtually every modern computer. For us, its most important feature is the ability to manage files. First of all, the file is metadata, i.e. data describing data. So here we may have the first indication that we are talking about data that we are describing. One such description is an identifier that plays two roles. One is that the file clearly distinguishes it from all other files. In this role it is Uniform Resource Identifier(URI), is a tekst that identifies the file. The second one indicates the location where the file can be found by the file system engine. In this role it is Uniform Resource Locators(URL). We also have other metadata such as date of creation, author, length, and many others.

An important feature of a file concept is that it contains content in addition to metadata. Metadata is, of course, a very important file part but the most important thing is the content it includes, which is data representing information to to take part in processing.

Hopefully, everything we've talked about so far seems quite obvious, but since some file features are fundamental for further discussion, let's look at them in detail.

Let's start with the fact that typically we utilize object-oriented programming. This means that at runtime we must deal with objects that are located in the working memory (RAM) of a computer. Let me remind you that the RAM abbreviation stands for Random Access Memory. Here, random means that each word in memory has an address, i.e. a unique identifier, and this word can be independently read or written there. Therefore, object data can be organized into structures and linked by references.

On the other hand, as we mentioned already, we have the streaming world where the data is organized in the form of bitstreams, where each self-contained element of data has information about the next element.

### BitStream Format

> DSL
> XML Format
> JSON Format
> YAML Format

#### XML Format

In the previous example, we used XML text, but there are still many open issues that we need to talk about. One such issue is the answer to the question of what is the difference between XML text and an XML document.

#### Introduction

An issue we haven't even mentioned is the visualization of data that has already been saved as a stream. Earlier, when discussing assumptions, we assumed that there may be a situation in which this data will also be intended for the user. One of the issues here is whether the fact that we use the XML standard to record data is enough to determine that this data is readable to a potential human user.

We also completely ignored the operation of graphs, i.e. a set of objects connected by references.

Let's first discuss the first two issues regarding automation and synchronization of the serialization process with the deserialization process. Let's discuss these issues using the example of a program.

#### Catalog XML

Let's go back to the XML file and the question of how to visualize data for a user, for a human. It was stated that an XML file is text, namely a bitstream for which the encoding is defined. It allows to employ of any text editor. Unfortunately, if a file is formatted this way and is seen by persons, who are not familiar with XML technology, it won't be easy to associate any information with the text.

To make it easier to visualize the data that is in the XML file, let's use a feature of XML files that allows a transfer of XML text to any other text by adding this additional line in the XML file [catalog.example.xml][catalog]:

``` XML
<?xml-stylesheet type="text/xsl" href="catalog.xslt"?>
```

This XML declaration defines an additional document [Catalog.xslt][catalogxslt]. The [Catalog.xslt][catalogxslt] is a stylesheet document and it contains a detailed description that allows to convert the source XML document into an HTML document. If we open the source document by clicking on it, we will open a web browser and the source file will be displayed in a graphical form that can be much easier to understand by people who are not familiar with XML technology. If we look at the source of this document using the browser context menu, we can see that it is simply the earliest XML document. This document that we originally had just got transformed thanks to browser transformation. So browsers have a built-in mechanism to convert an XML file to any other text file, in this case, it is an HTML file based on a defined XML stylesheet document

Finally, a few notes related to XML stylesheet transformation. Not only web browsers have a built-in mechanism ensuring transformation. This transformation can be defined in such a way that the target text that will be created has the features of a natural language. The final form may also cover ergonomic requirements, and in particular, it may be the user interface. Shortly, thanks to the transformation of XML files using stylesheet it is possible to add formatting to the data contained in the XML bitstream.

#### Standardization of the output stream

If we are talking about communication between different remote applications, we must consider a scenario in which these applications are written in different programming languages. In this case, the problem arises of how to create types in other languages that will represent the same information. Since we recognize the schema as a good idea to validate XML documents, i.e. XML texts, and check whether the XML text is the XML document we expect, then maybe we should turn the issue upside down and generate types in selected programming language based on XML schema. Of course, it is a chicken and egg problem namely, should we first create types in the selected programming language, or should we create these types in the XML schema and then create classes based on the XML schema? But let's try to see how this can be achieved using an example.

_________________________________

When we talk about the syntax and semantics of a stream, the first thing to consider is the scope of data use. Well, data produced by one instance of a program can also be used by the same instance of the program. In such a case, if the process runs autonomously and is symmetric from a serialization and deserialization point of view, we should not expect any further problems.

However, the same data can be used by the same program but not the same program instance, we also have to take into account that the programs may be in different versions. In such a case, there is a problem of data compatibility between different versions of the program. So the question arises whether if the data serialized by one version of the program is used by another version of the program run as a different instance, will it allow the creation of a graph equivalent to the original graph.

Another application of streams may be the use of them between various programs that are created in different technologies and implemented on different platforms. Then there is also the issue of technological compatibility. Also in this case, it must be taken into account that classes (types) that were created in one technology cannot necessarily be directly used in another technology. And in this case, we are already entering the issue of semantics, so we must take into account the fact that in another technology the same information will be represented in a different way.

## Attributes

## BitStream Protection

## Serialization

> Standardization
> Data Transfer Object

### Fundamentals

And here the first problem arises, namely the question of how to combine these two worlds. We will call the transition from the object world to the streaming world serialization. Deserialization is the reverse process, which involves replacing the bitstream with interconnected objects located in the working memory of a computer.

Again, to save/read working data from files we need generic operations that could automate this process regardless of the types we used to create the graph of objects containing working data. This process is called serialization. There must be also provided reverse operation creating objects from a file content - deserialization. This operation additionally has to verify the file content.

So the first problem we have is how to implement serialization and deserialization to make the transition between the object world and the streaming world possible. The serialization and deserialization process must be repeatable and mutually unambiguous. Moreover, it is not a simple process. Well, someone may say that this is a relative matter because we have no measure of simplicity in this case. However cloning serialization and deserialization code snippets each time serialization is needed will consume and waste time, so it may be worth implementing this process as a generic library, without the need to create dedicated software each time. So the next problem we can define here is the possibility of transition between the streaming world and the object world using the library concept.

If we talk about repeatability by applying a library concept implementing serialization and deserialization functionalities, we need to define one more problem. Namely, we must be able to define this process in advance, without prior knowledge of what will be serialized.

Generic implementation of the serialization and deserialization functionality means that we have to implement it in advance and offer it as ready-to-use libraries. We have many libraries that permit this process to be carried out automatically. So the question is why do we need to learn about it? Why go into detail? Well, my point is that if someone wants to use a washing machine, let me refer to this example, they do not need to know how the controller, engine, or temperature sensor works. However, if someone wants to design or build a custom washing machine, knowledge or understanding of how the engine, controller, and temperature sensor work is essential in this case. Similarly, we need detailed knowledge about serialization and deserialization in case we are going to use streaming data, for example, the file system.

In summary, to simultaneously use object-oriented programming and save data as a bitstream, our goal must be to combine two worlds. First, in which the data is in object form. The second world is data in the form of bitstreams. The data conversion between these worlds is serialization and deserialization. In the case of serialization, it is a process that involves converting the state of a graph of objects into a stream of bits. Deserialization is the reverse process, i.e. converting a bitstream into a graph of objects that must be created in memory. Here the magical statement about the condition of the object appeared; what does object state mean? We will know the answer to this question soon.

> To learn more about the serialization visit the document: [Serialization in .NET][STLZTN].

### Useful Technologies

#### Validation

If we are talking about exchanging data between different applications or between an application and a human, the issue of data correctness arises. This issue should be considered on two independent levels. The first one is the correctness of the stream as a certain stream of signs, i.e. when the syntax rules are met. The second one is correctness from the point of view of the possibility of assigning information to these correct sequences and therefore assigning meaning.

To better understand these issues, let's look at them in the context of code examples. 

~~Maybe we will also be able to determine solutions that may be useful in this regard.~~

_________________

Applications save working data into bitstreams (for example content of files) to keep state information, provide processing outcomes, or both. Applications need robust storage, i.e. correctness of the stored data has to be validated every time an application reads it back from a bitstream. It must be carefully observed if the bitstreams are also modified by other applications or directly by users, because data corruption may occur.

To address the validation requirement XML (Extensible Markup Language) as a text-based format for representing structured information and XML Schema as a language for expressing constraints about XML documents are very good candidates to be used by the file operation. Today applications use objects to process working data according to the Object Oriented Programming (OOP) paradigm. Therefore, instead of XML schema to validate XML files, we may use an equivalent set of classes.

You may use the [XML Schema Definition Tool (Xsd.exe)][XSD], which generates XML schema or language classes from XDR, XML, and XSD files, or from classes in a run-time assembly.

#### Visualization

First of all, we need to deal with data visualization, so as to enable the use of streams also by a human computer user. Let's start with data visualization, taking into account, firstly, natural language, ergonomics, and graphical user interface.

We also talked about the human use of streams. In this case, further requirements appear. Among other things, this representation should be close to natural language. Of course, we have no measure here and therefore it is difficult to say whether something is close enough to natural language to be comprehensible. In order for humans to understand the stream, it will also be necessary to define semantic rules, i.e. rules that will allow us to assign meaning and information to strings of bits. The issue of ergonomics is also important, i.e. the ease of absorbing information represented by the stream. Of course, the closer we are to natural language, the easier it will be, but again in this matter, we do not have measures that will allow us to clearly determine how good our solution is.

_________________

One more requirement often arises here, namely that the bitstream resulting from the transition of objects to bitstreams should be human-readable. A typical example that we can cite here is using the Internet. Using a web browser, a server-side application uses objects and then serializes the data that the user needs, sends it over the network, and then the browser displays it on the screen. And here it is important, that the browser always displays data in graphical form. This applies to all kinds of data used by humans, a person uses. The data, even when reading a newspaper, is always graphical data. Let me remind you that a letter is also a picture. This is one feature of data that is prepared for this. so that man can use them. The second feature is that this data must be written in a natural language that humans know. The concept of natural language is very broad. For example, XML text is said to be human-readable. But is this a piece of natural language?

As the XML format is text-based it can be directly read and displayed by a variety of software tools. However, it is not the preferred format, because it does not contain any formatting information. Today we expect data presentation to meet user experience, i.e. to have an appropriate layout and style. We can meet this requirement using any application that supports XSLT transformation of XML documents into other text documents, including but not limited to equivalent HTML documents. XSLT uses a template-driven approach to transformations: you write a template that shows what happens to any given input element. For example, if you were formatting working data to produce HTML for the Web, you might have a template (stylesheet file) to match an underlined group of elements and make it come out as a table.

> To get more about how to start with XSLT visit the W3C School: [XSL\(T\) Languages][XSLW3C].

#### Reflection

Reflection is the next very useful technology used to support serialization and deserialization. In this chapter, we will touch on the subject of reflection, i.e. we will enter a world in which definitions in the program become data and will be processed just like process data. In other words, reflection in software engineering refers to the ability of a program to examine and modify its structure and behavior during runtime. Due to the complexity of this topic, we have to limit the discussion to only selected topics useful in the context of serialization. The reflection is a good topic for an independent course. Hence, don't expect deep knowledge related to this topic.  Reflection is commonly used for tasks like dynamic instantiation, method invocation, and recovering metadata about types.

So, our task is to answer the question of how to automate this serialization and deserialization process. Because we have to do it in a way that allows us to avoid repetitive work. This, however, means that the mentioned functionality must be implemented in advance when we do not know the types yet; these types are yet to appear. We want to offer a general library that will be used for various types, i.e. for custom types that the user will define these types according to personal needs. The only thing we can rely on are the types built into a selected programming language because they are immutable.

If we need to deal with custom types that we do not know, generally there are the following solutions that may be applied. First is dynamic programming when types are created during program execution and will reflect the needs related to the data processing algorithm. The next one is independent conversion based on built-in custom functionality in new types. Finally, we should consider applying reflection, where type definitions become data for the program that can be the subject of recovery metadata and reading/assigning vital values.

Dynamic programming is not promising and should be avoided because it is an error-prone run-time approach. Independent conversion is the design-time approach and must be considered as a serialization/deserialization method however it still needs custom serialization/deserialization functionality to be embedded in new type definitions. More in this respect you can get by checking out appropriate examples described in the document [Implementation Examples][ie]. Reflection allows to write the program in such a way that the type features are recoverable and become data for the program. Reflection allows for avoiding custom implementation of the serialization and deserialization functionality. Hence, it will be described in more detail.

The language we have selected for education purposes is based on the concept of types. It is strictly typed. However, it is not the only one that uses type compatibility to check the correctness of the program at design time. However, the transition from the object-oriented world to the streaming world requires generic actions, consisting of creating generalized mechanisms for operating on data without referring to concrete type definitions. I mean the serialization/deserialization functionality must be implemented generically without referring to type definitions, because the types may be unknown at this time.

Let me remind you that our goal is to automate data transformation between object graphs and bitstreams. We want this process to be mutually unambiguous, repeatable, and automatic. Data transformation from object form to stream form, so the transformation of an object graph requires reading the state of these objects and the relationships between them. The reverse transformation, i.e. converting a bit stream into an object graph, requires creating an instance of the object and assigning values to the object's fields or properties to recover its state based on the data obtained during deserialization.

The state of objects is the minimum set of values that is necessary to recreate an equivalent object. In the case of conversion from a stream to an object form, first of all, we must be able to create objects. If the objects are instantiated, the values that have been saved as the object's state must be assigned to the internal members that are part of this object. This also applies to those variables that store information about relationships between objects, i.e. reference variables.

So much theory. It's time to move on to practical acquaintance with selected reflection mechanisms. To get more based on examples check out the document [Implementation Examples][ie]

It's time to summarize selected features of reflection. The examples discussed show how to represent type features as [Type Class][system.type] instances. These instances can be created based on the type definition using the `typeof` keyword and objects of unknown type using the `GetType` instance method. In both cases, an object-oriented type description is created. The examples discussed show how to use this description to read and write the values of a selected property. This ability is especially useful when implementing serialization and deserialization operations. Similarly, we can also read and write values from fields and call instance methods. Similarly, it is also possible to create new objects without referring to the `new` keyword. Discussing all the details of the reflection concept is far beyond the scope of the examples collected here.

#### Attributes

Attributes language constructs at design-time and reflection at run-time could help to solve some problems related to serialization/deserialization. Attribute is a concept used in various programming languages. They are used to add supplementary information to program text. Many languages may implement attributes in their own way, but the fundamental idea of associating extra information with code entities is common across many programming languages.

So the question is what are attributes? The general answer is that it is a programming language construct. Detailed explanations must be investigated in the context of program snippets prepared using the selected programming language that will be used to explain the attribute. A description of the code snippets is available in the document [Implementation Examples][ie].

Based on these examples presented in the mentioned above document the discussion may be summarized as follows. An attribute is any class that inherits from the [Attribute Class][Attribute] base class defined in the environment of the selected programming language. In addition, there also must be possible to associate attributes with other language constructs.  Finally, the language must provide means to instantiate the attributes in the context of associated constructs to which we want to associate additional data.  The definition of attributes and association attributes with other contracts must be compliant with the selected programming language syntax rules. The reflection mechanisms must be used to instantiate attributes at run-time.

The examples show that attributes have broader applicability than just serialization and deserialization. However, the attribute concept can be used also to implement the serialization/deserialization processes but examples will be a subject of further discussion.

### Main Technology Features

Now we are ready to return to discussing issues directly related to streaming data. Above we discussed the mechanisms of managing streams, especially in the context of files. We also learned the differences between bitstreams, text, and documents. We also learned a few technologies including reflection, which can be useful for us. Now let's answer the question of how to create streaming data and how to use it. First, let's try to define the purpose of our missions and the limitations we must deal with.

We've already talked a bit about why we need bitstreams handled using files. Let's recall the most important applications, such as entering input data or storing output data using file systems. We also use various types of streaming devices to archive data, i.e. to save data forever. Data transfer between applications is another use case. I would like also to remind you that we have already talked about an example where we have a web server and a web browser. There is a virtual wire between them. We can only send bitstreams over this wire. The temporary and intermediate data repository is another example.

These are just a few examples but let's limit ourselves to them because they are enough to justify the importance of this topic. Let me remind you that so far we have noted that in the transition between the object world and the world of bitstreams, we need serialization, which is responsible for transferring the state of an object graph to a bitstream. And deserialization, which is responsible for the reverse process, i.e. for transferring a bitstream into a graph of interconnected objects. We would like this operation to be implemented as generic, i.e. we would not have to program this operation every time, but only parameterize it.

Before we move to the next step, it is worth recognizing what we need. Here, the list of requirements includes:

- access to the data that will be the subject of the transformation process
- values that will constitute the state of the objects
- the relationships between these objects

Next, we need to implement an algorithm that will describe in detail this data transformation, in such a way that this transformation is mutually unambiguous. Here, the mutual unambiguity of this process does not mean that each time we perform serialization we will obtain an identical bitstream.

From the above, it could be derived that if an equivalent graph of objects can be reconstructed based on a bitstream it can be stated that the bitstream is correct for the purpose it has to serve. This reconstruction must be accomplished in compliance with the syntax, and semantics rules governing the bitstream. Again, this graph does not have to be identical to the original. It is enough for us that it is equivalent from the point of view of the information it represents. It could be added that in some cases, let's say in simpler cases, the bitstream identity can be ensured. This means that for a selected graph of objects, each time as a result of serialization we receive an identical stream of bits. Then this bitstream can be compared, for example, to check whether the process is the same as before. And this is where it must be stressed that equivalence has no measure in this respect. Due to the above, it is not possible to formally determine whether the resulting bit stream and the source object graph are equivalent. Therefore, equivalence must be decided by the software developer using custom measures. From that, we can derive that only the software developer is responsible for ensuring that serialization and deserialization are mutually unambiguous.

From the previous analysis, we know how to obtain appropriate values that constitute the state of objects and the relationships between these objects. Assuming that the data transformation algorithm has been implemented somehow, there is a need to determine the form of the target stream. So we need to determine how to combine bits into words, how to combine words into correct sequences of words, and how to assign meaning to these sequences of words. Shortly, alphabet, syntax, and semantics rules. For example, it could have an impact on the bitstream features, hence, the possibility of validating and visualizing content. Two additional notes regarding the target form of the bitstreams are vital for further consideration.

The list of applications that we mentioned previously as potential stream consumers includes the exchange of data between remote applications. It should be emphasized here that if these applications are created by different manufacturers, the standardization of this representation becomes extremely important. So, the fact that we combine words into correct sequences of words and give them meaning, that these syntax and semantics rules are standard in the sense that there are international documents that are published by organizations recognized as standardizing, that will allow us to recreate the graph of objects in an application that is created by another vendor.

We also said earlier that sometimes these bitstreams are also used to communicate with humans. Of course, standardization is also important here. A person must be able to read this sequence of bits, and therefore combine sequences of bits into words and words into correct sequences of words. Finally, these strings of words have to have meaning for him. First, it is important to be able to combine these bit strings into letters so that the bitstream becomes a text. Let me remind you that the text is a bitstream for which an encoding has been specified.

From the previous considerations regarding the transformation of object data into streaming data, we know that the basis of this process is to determine the state of the object. Let me remind you that the state of an object is a set of values that must be subject to a transformation process so that the reverse operation can be performed in the future, i.e., so that the object graph can be recreated and an equivalent object graph can be created.

In order not to enter into purely theoretical considerations, let us return to these topics in the context of sample programs. The examples are described in the document titled [Implementation Examples][ie]. The example discussed shows the mechanism of transformation of an object or more precisely an object state to a bitstream. In this process, the state of the object is determined by a software developer, which implements an appropriate mechanism responsible for selecting the values that constitute the object state. Since the determination of an object state is done manually by the program author, there must be measures allowing one to point out what has to be serialized.

### Access to Object State Values

In the previous two lessons, we talked about how to build universal libraries that will allow you to transfer object data to a stream and from a stream to object data. We also talked how to use attributes and reflection to ensure full autonomy of this process and harmonize the behavior of the process of converting objects to a stream and stream to objects. Autonomy in this context means that the reflection is used to prepare a library and as a result, the conversion process can be performed without dedicated custom code embedded in the type of objects to be serialized and deserialized. We also talked about stream semantics and syntax using the example of XML files. We showed how to use the XML schema concept to describe details of the syntax and indirectly semantics of a document and to create the source code of a program that will be used in the serialization and deserialization process.

_______;

From the previous considerations, we know that serialization is a data transformation process from an object to a stream form. Serialization should be implemented as a generic operation. It means that the serialization possibility doesn't depend on the type of the serialized object because it should be offered as a universal library solution and therefore used many times and applied to custom types. This process must start with recovering a set of selected values contributing to the state of the object. Let me stress that to provide a generic solution this mechanism must not depend on the object type.

#### Self Controlled

The first approach, compliant with the above scenario, is to locate this functionality internally of a custom type. An example of this approach is covered by the [SelfControlSerialization][SelfControlSerialization] class. It is based on internal reading and assigning operations of the values creating the object's state in compliance with the object type definition. This way, it is possible to avoid the need for employing the reflection by inheriting from the `ISerializable` interface. This interface acts as a contract between the target class to be serialized and the class that implements the serialization algorithm. We must be aware that the proposed solution is not perfect. There are still many issues that have been left unsaid. So let's start by systematizing the shortcomings of the previous proposals.

The first issue that we can recognize is full automation of the serialization and deserialization process. If we look at the code, we see that we must manually ensure that the appropriate values constituting the state of the target object are saved in the array, which will be passed on to be written to the stream. It means that partially this functionality must be implemented by the custom type in compliance with the `ISerializable` interface instead of being provided by a library.

The second issue is the necessity of harmonization of the custom operations carried out during the serialization with the operations carried out during deserialization. In the example discussed already, we see that we have two separate pieces of custom code that are responsible for this, and therefore any modification in one piece must be reflected in the other piece. This can lead to errors if this is not the case. The sample code could be slightly improved in this respect but it still does not solve this problem.

#### Reflection-based

There is one more issue to discuss, namely how to control the state of an object, i.e. reading and writing values to its members without referring to its type. The main problem is that if the type is not visible we do not have knowledge about its members.

Instead of using a self-controlled approach, the reflection may be employed to read and write values contributing to the object state. This way there is no custom code related to selecting, reading, and writing state values. To select only necessary values the following convention may be applied. It says that the state of the object is constituted by all the values that can be obtained by reading the public properties that have both getter and setter. So from which you can both read the current value and assign new ones. If this convention applies to the target object and all indirectly referenced ones we can state that the graph of objects is ready for serialization and deserialization using reflection. What is very important is to ensure symmetry between serialization and deserialization.

The rule that we will remember in the output stream all the values that we can read from public properties that have both getter and setter cannot be used uncritically. We also need to consider the case when such properties exist, but for some reason, we do not want to save their values in the output stream. The solution to this problem can be based on our knowledge of attributes. In practice, it means that properties of this type are preceded by a selected attribute. For example, it may be `XMLIgnore`, which will indicate that you must use all public properties that have a getter and setter, except those preceded by the indicated attribute. The question is whether in this solution we ensured the symmetry of the serialization and deserialization operations. The answer is yes because both reading data and writing data to newly created objects are in the same place, by using the same property. This means that using reflection there is no need to add any dedicated functionality to the target class related to serialization and deserialization.

The serialized classes were defined in the test class. Therefore, if we define a library that will be used to serialize these classes, this graph, then the serializing class cannot know the type of serialized classes, cannot have references to unit tests, and so it cannot know the types. This way it could be proved that the solution is generic, I mean it doesn't depend on the target type of serialized classes.

As we see in this example, we do not have to create custom code in the target type that is subject to serialization that is used to implement this operation. So we can say that in this case, the serialization process is strictly autonomous.

The main outcome of the example is that in the target type that is subject to serialization, there is no need to create dedicated code that is used to implement this operation. So we can say that reflection enables us to offer a strictly autonomous solution.

Reflection-based serialization is a technique in software engineering where the internal structure of an object is recovered and internal data is serialized or deserialized based on metadata available at run-time related to the type of object. This approach allows for dynamic transferring of object state to bitstream without explicit configuration.

To serialize objects of this class we use reflection and attributed programming. An example is described in the section



### Graph of Objects Serialization

Issues related to graphs are also on the list. Let us introduce two terms: hierarchical and non-hierarchical graph. Loops may occur in non-hierarchical ones.

__________________________;

Let's move on to the last issue related to the serialization of objects interconnected to each other forming graphs. So the objects have references between them and these references will determine the structure of the graph of objects. In this case, the main challenge is that all the objects must be considered as one whole.

Generally, we can distinguish two types of these structures. The first one is hierarchical interconnection, which resembles a tree. In this case, starting from any point of such a structure and following the directional references we will never return to the starting point. Thanks to this feature, in mathematics, this kind of graph is called acyclic. In the case when graphs are cyclic, then there are points in the graph that when we start from these points and follow the references, it is possible to return to these points. So such graphs have loops. Since graph serialization requires an iterative approach, it requires that we iteratively traverse a tree of objects, provided that it is a tree. If there are cyclic connections causing loops in the graph of objects, then there will be a problem with stopping the iteration and avoiding double serialization of the same object.

Previously a graph of objects was presented as interconnected objects in such a way that they create a tree, or at least a layered model, therefore in this model, we can distinguish objects that are at the top and objects that are beneath in the hierarchy. Therefore, data transformation operations may be performed starting from those objects that are at the top and ending with those objects that are at the bottom of the hierarchy of references between objects.

But it often happens that we must deal with more demanding cases, where these references create cycles. For example, in this example (fig. below), classes refer to each other creating a cycle.

![Fig. 1](.Media/Part3-N80-10-Diagram.png)

Assuming that instances of all classes are created (fig. below), the question arises which of the objects should be subject to the serialization process first. Therefore, in this case, we must not insist that the hierarchy between objects is dependent on the order of representation in the stream. Hence, here we must introduce the following term: equivalence of streams. If a stream contains a representation of all information including references, the order in which the data associated with each instance is placed in the stream is not relevant, provided that each object is serialized only once. Due to the above, it has to be considered that several different bitstreams contain equivalent states of individual objects and these object states will be placed in different orders but all of them are equivalent to each other. It means that on their basis it will be possible to reconstruct an equivalent graph of objects. Creating equivalent streams does not mean that they have to be identical and therefore, for example, they can be directly compared with each other.

![Fig. 1](.Media/Part3-N80-20-Rekurencja.png)

Another issue that should be addressed here is when the serialization process should be ended. For example, if we start with an instance of one class, let's say `ServiceA` (fig. above), next proceed to serialize the instance of the `ServiceB` class and consequently proceed to an instance of the `ServiceC` class, we must have an iteration stop condition to avoid cloning of the instance `ServiceA` because it has been already serialized, i.e. the transformation process has been performed for it. For the more complex graphs, it could be not so easy.

In case of cyclic graphs, there is no restriction on the number of paths between any pair of vertices, and cycles may be present. We may encounter two problems here. Firstly, we may encounter many-to-one references in this type of graph, when many objects will have references to one object. As a result, we can expect that serializing such a structure may cause the cloning of one object in the stream. During recovery, if all these objects are recreated, many redundant copies are instantiated, so the structure will be different comparing it with the original. In the case of cyclic graphs (contain cycles - closed loops) in the relationship structure, we must take into account the fact that the serialization mechanism (the graph-to-bitstream conversion mechanism) will have to deal with this problem and therefore will have to set a stop condition to avoid cloning objects in the output stream. Well, we have two options to solve this issue. The first option is to write a custom library but this is a complex process. The second approach to address this problem is to choose an appropriate but existing library. There are many such libraries on the market and when analyzing their applicability, you should pay attention to these issues.

#### Reflection-Based Serialization Example

This example explains how to serialize using reflection and attributed programming. The `Catalog` class is used for this purpose. The main aim of the [SerializationUnitTest.ReadWRiteTest][ReadWRiteTest] method is to test the serialization of the graph of objects `Catalog` class. To be tested, the instances must be populated with test data. This class is located in unit tests, so I can add an appropriate method that fills the instance of this class with test data. The only question is where to add it. Adding this method to auto-generated text, i.e., text obtained as a result of an external program, is not a good idea, because our work is overwritten after each modification and generation of a new text. Therefore, let's use the fact that this class is generated as a partial class, and to populate the instance of this class with test data, we have to expand its definition by adding a custom part, which will be its integral part. In this part of the definition, located in a separate file, we can safely add all the operations we want to perform for this purpose. For this method called `AddTestingData` I used attributed programming again by adding an attribute that indicates that this method will be subject to compilation only when we have an environment configuration named [BEBUG][Debug]. Coming back to the unit tests, we see that an object has been created, and this object has been populated with test data. To make sure, we check that the instance has been created and initialized. Then we define the path where we want to save the file and use the `WriteXMLFile` method. This is a generic method. In its first parameter, we pass a graph of objects to be serialized, the file name, and details related to the output file creation.

The [WriteXmlFile][WriteXmlFile] method has been defined in the library. We will not analyze it in detail but the only important thing is that we use the `XMLSerializer` library to perform the serialization operation. The serialization is implemented in this instruction:

``` csharp
  _xmlSerializer.Serialize(_writer, dataObject);
```

All other instructions generally are used to protect against wrong values of parameters and to improve the formatting of the output XML text.

For testing purposes, an operation is performed to read the same file and create an equivalent graph of objects, i.e. deserialization implemented in the following assignment instruction

``` csharp
  Catalog _recoveredCatalog = XmlFile.ReadXmlFile<Catalog>(_fileName);
```

We can now check whether the result is consistent with our expectation, i.e. whether the original graph of objects and the equivalent graph of objects have appropriate values that are part of the object's state.

There are two more things worth noting about the [ReadWRiteTest][ReadWRiteTest] method.  The first one is reading the stream and restoring an equivalent graph of objects. The second one is to check whether the graph of objects is equivalent compared with the original one. As we can see in this method, the same library called `XMLSerializer` is used. As previously the operation of restoring the graph of objects comes down to one instruction. From the example we can derive that testing if the recovered graph of objects is equivalent to the original one strongly depends on the custom type definitions and cannot be performed universally, therefore it must be the responsibility of developers.

#### SerializationUnitTest

Although we know that this is not a universal approach, let us return to the discussion of the topics related to checking the equivalence of the recovered graph compared to the original graph in this specific case. The primary graph was created by creating an object of the `Catalog` class and then filling it with test data using the `AddTestingData` method. After deserialization, we check that the `_recoveredCatalog` variable has references to the newly created object, so it is not `null`. Then we check how many elements the array has. Here and in the next two lines it is assumed that these are only two elements, but it would also be worth checking the actual length of the array. However, the most important thing here is to check whether two subsequent disc descriptions compatible with [CatalogCD][CatalogCD] are equivalent to each other. The equality symbol is used to compare them, although we expect that the elements are equivalent, not identical. This effect can be achieved by redefining the equality operator in the [CatalogCD][CatalogCD] class. For this purpose, the definition of the equality operator has been overwritten. As a result, the behavior of a new definition of this operator determines what equals means. The standard `Equals` method is used here. This operation compares strings, which have been generated by the overridden `ToString` method. It determines which elements will take part in this comparison and how they will be formatted. It is worth emphasizing here that the string formatting may depend on the current operating system language settings and, depending on different data types, the formatting of this string may not be clear; it may not be the same every time.

## See Also

- [XSL\(T\) Languages][XSLW3C]
- [Serialization in .NET][STLZTN]
- [XML Schema Definition Tool (Xsd.exe)][XSD]
- [Type Class][system.type]
- [Implementation Examples][ie]
- [Attribute Class][Attribute]

[ie]: ./DataStreams/README.md
[XSLW3C]: https://www.w3schools.com/xml/xsl_languages.asp
[XSD]: http://msdn.microsoft.com/library/x6c1kb0s.aspx
[STLZTN]: http://msdn.microsoft.com/library/7ay27kt9.aspx
[system.type]: https://learn.microsoft.com/dotnet/api/system.type
[Attribute]: https://learn.microsoft.com/dotnet/api/system.attribute
[CatalogCD]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/Catalog.xsd.cs#L56-L79
[catalog]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/catalog.example.xml#L1-L23
[catalogxslt]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/Catalog.xslt#L1-L30
[ReadWRiteTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/SerializationUnitTest.cs#L42-L58
[Debug]: https://learn.microsoft.com/visualstudio/debugger/how-to-set-debug-and-release-configurations
[WriteXmlFile]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams/Serialization/XmlFile.cs#L41-L62
[SelfControlSerialization]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/SelfControlSerialization.cs#L22-L80
