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

# Data Streams Preface

## Key words

Bitstream, File, File System, XML, XSLT, HTML, XmlSerializer, Save file, Transformation, Saving text files, Local File Systems, Open and read file, XML Schema, Common File Format, Data Access, XML Serialization, Data Validation, Data Visualization

## Introduction

This folder directly or indirectly is related to the topic of representing information as a stream of bits and is devoted to discussing selected programming issues related to their programmatic management.

If we write a program to automate a selected process of information processing, we inevitably have to operate on data that represent this process. Generally, we can distinguish operations related to read input data, permanently remember intermediate data, transfer data between individual applications, and save the final data somewhere after the completion of the entire processing process. All these requirements can be accomplished using the concept of file. Even sending data between applications can be done using solutions such as a file server, distributed file system, Google Drive, One Drive, and finally a Pendrive.

## File concept

This is where the term file system came into play. Without going into details about the structure of the computer and the operating system, we can enigmatically state that it is a resource available in virtually every modern computer. For us, its most important feature is the ability to manage files. First of all, the file is metadata, i.e. data describing data. So here we may have the first indication that we are talking about data that we are describing. One such description is an identifier that plays two roles. One is that the file clearly distinguishes it from all other files. The second one indicates the location where the file can be found by the file system engine. We also have other metadata such as date of creation, length, location on the medium, and others.

An important feature of a file is that it contains content in addition to metadata. Metadata is, of course, very important, but the most important thing is the content it includes, which is data representing information subject to processing.

Everything we've talked about so far seems quite obvious, but since some file features are fundamental for further discussion, let's look at them in detail.

## Serialization

### Fundamentals

Let's start with the fact that typically we utilize object-oriented programming. This means that at runtime we must deal with objects that are located in the working memory (RAM) of a computer. Let me remind you that the RAM abbreviation stands for Random Access Memory. Here, random  means that each word in memory has an address, i.e. a unique identifier, and this word can be independently read or written there. Therefore, object data can be organized into structures and linked by references.

On the other hand, as we mentioned already, we have the streaming world where the data is organized in the form of bitstreams, where each self-contained element of data has information about the next element.

And here the first problem arises, namely the question of how to combine these two worlds. We will call the transition from the object world to the streaming world serialization. Deserialization is the reverse process, which involves replacing the bitstream with interconnected objects located in the working memory of a computer.

Again, to save/read working data from files we need generic operations that could automate this process regardless of the types we used to create the graph of objects containing working data. This process is called serialization. There must be also provided reverse operation creating objects from a file content - deserialization. This operation additionally has to verify the file content.

So the first problem we have is how to implement serialization and deserialization to make the transition between the object world and the streaming world possible. The serialization and deserialization process must be repeatable and mutually unambiguous. Moreover, it is not a simple process. Well, someone may say that this is a relative matter because we have no measure of simplicity in this case. However it is obvious that cloning serialization and deserialization code snippets each time serialization is needed will consume and waste time, so it may be worth implementing this process as a generic library, without the need to create dedicated software each time. So the next problem we can define here is the possibility of transition between the streaming world and the object world using also the library concept.

If we talk about repeatability by applying a library concept implementing serialization and deserialization functionalities, we need to define one more problem. Namely, we must be able to define this process in advance, without prior knowledge of what will be serialized.

Generic implementation of the serialization and deserialization functionality means that we have to implement it in advance and offer it as ready-to-use libraries. We have many libraries that permit this process to be carried out automatically. So the question is why do we need to learn about it? Why go into detail? Well, my opinion is that if someone wants to use a washing machine, let me refer to this example, they do not need to know how the controller, engine, or temperature sensor works. However, if someone wants to design or build a custom washing machine, knowledge or understanding of how the engine, controller, and temperature sensor work is essential in this case.

So let's summarize this discussion. To simultaneously use object-oriented programming and save data as a bitstream, our programming goal must be to combine two worlds. First, in which the data is in object form. The second world is data in the form of bitstreams. The data conversion between these worlds is serialization and deserialization. In the case of serialization, it is a process that involves converting the state of an objects graph into a stream of bits. Deserialization is the reverse process, i.e. converting a bitstream into a graph of objects that must be created in memory. Here the magical statement about the condition of the object appeared; what does object state mean? We will know the answer to this question soon.

> To learn more about the serialization visit the MSDN: [Serialization in .NET][STLZTN].

## Useful Technologies

### Validation

Applications save working data into the files to keep state information, provide processing outcomes, or both. Applications need robust storage, i.e. **correctness** of the stored data has to be validated every time an application reads it back from the file. It must be carefully observed if the files are also modified by other applications or directly by users, because data corruption may occur.

To address the validation requirement XML (Extensible Markup Language) as a text-based format for representing structured information and XML Schema as a language for expressing constraints about XML documents are very good candidates to be used by the file operation. Today applications use objects to process working data according to the Object Oriented Programming (OOP) paradigm. Therefore, instead of XML schema to validate XML files, we may use an equivalent set of classes.

You may use the [XML Schema Definition Tool (Xsd.exe)][XSD], which generates XML schema or language classes from XDR, XML, and XSD files, or from classes in a run-time assembly.

### Visualization

One more requirement often arises here, namely that the bitstream resulting from the transition of objects to bitstreams should be human-readable. A typical example that we can cite here is using the Internet. Using a web browser, a server-side application uses objects and then serializes the data that the user needs, sends it over the network, and then the browser displays it on the screen. And here it is important, that the browser always displays data in graphical form. This applies to all kind of data used by humans, a person uses. The data, even when reading a newspaper, is always graphical data. Let me remind you that a letter is also a picture. This is one feature of data that is prepared for this. so that man can use them. The second feature is that this data must be written in a natural language that humans know. The concept of natural language is very broad. For example, XML text is said to be human-readable. But is this a piece of natural language?

As the XML format is text-based it can be directly read and displayed by a variety of software tools. However, it is not the preferred format, because it does not contain any formatting information. Today we expect data presentation to meet user experience, i.e. to have an appropriate layout and style. We can meet this requirement using any application that supports XSLT transformation of XML documents into other text documents, including but not limited to equivalent HTML documents. XSLT uses a template-driven approach to transformations: you write a template that shows what happens to any given input element. For example, if you were formatting working data to produce HTML for the Web, you might have a template (**stylesheet file**) to match an underlined group of elements and make it come out as a table.

> To get more about how to start with XSLT visit the W3C School: [XSL\(T\) Languages][XSLW3C].

### Reflection

In this chapter, we will touch on the subject of reflection, i.e. we will enter a world in which definitions in the program become data and will be processed just like process data. In other words, reflection in software engineering refers to the ability of a program to examine and modify its structure and behavior during runtime. Due to the complexity of this topic, we have to limit the discussion to only selected topics useful in the context of serialization. The reflection is a good topic for an independent course. Hence, don't expect deep knowledge related to this topic.  Reflection is commonly used for tasks like dynamic instantiation, method invocation, and accessing metadata about types.

So, our task is to answer the question of how to automate this serialization and deserialization process. Because we have to do it in a way that allows avoiding repetitive work. This, however, means that the mentioned functionality must be implemented in advance when we do not know the types yet; these types are yet to appear. We want to offer a general library that will be used for various types, i.e. for custom types that the user will define these types according to personal needs. The only thing we can rely on are the types built into a selected programming language because they are immutable.

If we need to deal with custom types that we do not know, generally there are the following solutions that may be applied. First is dynamic programming when types are created during program execution and will reflect the needs related to the data processing algorithm. The next one is independent conversion based on built-in custom functionality in new types. Finally, we should consider applying reflection, where type definitions become data for the program.

Dynamic programming is not promising and should be avoided because it is an error-prone run-time approach. Independent conversion is the design-time approach and must be considered as a serialization/deserialization method however it still needs custom serialization/deserialization functionality to be embedded in new type definitions. More in this respect you can get by checking out appropriate examples described in the document [Implementation Examples](./DataStreams/README.md). Reflection allows to write the program in such a way that the type features are recoverable and become data for the program. Reflection allows for avoiding custom implementation of the serialization and deserialization functionality. Hence, it will be described in more detail.

The language we have selected for education purposes is based on the concept of types. It is strictly typed. However, it is not the only one that uses type compatibility to check the correctness of the program at design time. However, the transition from the object-oriented world to the streaming world requires generic actions, consisting of creating generalized mechanisms for operating on data without referring to concrete type definitions. I mean the serialization/deserialization functionality must be implemented in a generic way without referring to type definitions, because the types may be unknown at this time.

Let me remind you that our goal is to automate data transformation between object graphs and bitstreams. We want this process to be mutually unambiguous, repeatable, and automatic. Data transformation from object form to stream form, so the transformation of an object graph requires reading the state of these objects and the relationships between them. The reverse transformation, i.e. converting a bit stream into an object graph, requires creating an instance of the object and assigning values to the object's fields or properties to recover its state based on the data obtained during deserialization.

The state of objects is the minimum set of values that is necessary to recreate an equivalent object. In the case of conversion from a stream to an object form, first of all, we must be able to create objects. If the objects are instantiated, the values that have been saved as the object's state must be assigned to the internal members that are part of this object. This also applies to those variables that store information about relationships between objects, i.e. reference variables.

So much theory. It's time to move on to practical acquaintance with selected reflection mechanisms. To get more based on examples check out the document [Implementation Examples](./DataStreams/README.md)

#### Conclusion

It's time to summarize selected features of reflection. The examples discussed show how to represent type features as [System.Type][system.type] instances. These instances can be created based on the type definition using the `typeof` keyword and objects of unknown type using the `GetType` method. In both cases, an object-oriented type description is created. The examples discussed also show how to use this description to read and write the values of a selected property. This ability is especially useful when implementing serialization and deserialization operations. Similarly, we can also read and write values from fields and call instance methods. Similarly, it is also possible to create new objects without referring to the `new` keyword. Discussing all the details of the reflection concept is far beyond the scope of the examples collected here.

[system.type]: https://learn.microsoft.com/dotnet/api/system.type

#### Attributes

Another topic is directly related to the issue of serialization/deserialization, namely attributes. Attribute is a concept used in various programming languages. They are used to add additional information to program text. Different languages may implement attributes in their own way, but the fundamental idea of associating extra information with code entities is common across many programming languages.

So the question is what are attributes? I propose to put this answer in the context of program snippets prepared using the selected programming language that will be used to explain the attribute linguistic construct. A description of the code snippets is available in the document [Implementation Examples](./DataStreams/README.md).

Based on these examples presented in the mentioned above document the discussion may be summarized as follows. An attribute is any class that inherits from the `Attribute` base class defined in the environment of the selected programming language. In addition, it also means a description of how to instantiate an object of this type, i.e. a language construct that we place before another language construct to which we want to associate additional data using an attribute. Objects that a programmer creates to implement an algorithm that is executed by the program. For this purpose, we use the mechanisms provided by reflection.

The examples show that attributes have broader applicability than just serialization and deserialization. However, the attribute concept can be used also to implement the serialization/deserialization processes but examples will be a subject of further discussion.

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
