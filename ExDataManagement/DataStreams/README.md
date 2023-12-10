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

### Useful Technologies

#### Validation

Applications save working data into the files to keep state information, provide processing outcomes, or both. Applications need robust storage, i.e. **correctness** of the stored data has to be validated every time an application reads it back from the file. It must be carefully observed if the files are also modified by other applications or directly by users, because data corruption may occur.

To address the validation requirement XML (Extensible Markup Language) as a text-based format for representing structured information and XML Schema as a language for expressing constraints about XML documents are very good candidates to be used by the file operation. Today applications use objects to process working data according to the Object Oriented Programming (OOP) paradigm. Therefore, instead of XML schema to validate XML files, we may use an equivalent set of classes.

You may use the [XML Schema Definition Tool (Xsd.exe)][XSD], which generates XML schema or language classes from XDR, XML, and XSD files, or from classes in a run-time assembly.

#### Visualization

One more requirement often arises here, namely that the bitstream resulting from the transition of objects to bitstreams should be human-readable. A typical example that we can cite here is using the Internet. Using a web browser, a server-side application uses objects and then serializes the data that the user needs, sends it over the network, and then the browser displays it on the screen. And here it is important, that the browser always displays data in graphical form. This applies to all kind of data used by humans, a person uses. The data, even when reading a newspaper, is always graphical data. Let me remind you that a letter is also a picture. This is one feature of data that is prepared for this. so that man can use them. The second feature is that this data must be written in a natural language that humans know. The concept of natural language is very broad. For example, XML text is said to be human-readable. But is this a piece of natural language?

As the XML format is text-based it can be directly read and displayed by a variety of software tools. However, it is not the preferred format, because it does not contain any formatting information. Today we expect data presentation to meet user experience, i.e. to have an appropriate layout and style. We can meet this requirement using any application that supports XSLT transformation of XML documents into other text documents, including but not limited to equivalent HTML documents. XSLT uses a template-driven approach to transformations: you write a template that shows what happens to any given input element. For example, if you were formatting working data to produce HTML for the Web, you might have a template (**stylesheet file**) to match an underlined group of elements and make it come out as a table.

> To get more about how to start with XSLT visit the W3C School: [XSL\(T\) Languages][XSLW3C].

#### Reflection

In this chapter, we will touch on the subject of reflection, i.e. we will enter a world in which definitions in the program become data and will be processed just like process data. In other words, reflection in software engineering refers to the ability of a program to examine and modify its structure and behavior during runtime. Due to the complexity of this topic, we have to limit the discussion to only selected topics useful in the context of serialization. The reflection is a good topic for an independent course. Hence, don't expect deep knowledge related to this topic.  Reflection is commonly used for tasks like dynamic instantiation, method invocation, and accessing metadata about types.

So, our task is to answer the question of how to automate this serialization and deserialization process. Because we have to do it in a way that allows avoiding repetitive work. This, however, means that the mentioned functionality must be implemented in advance when we do not know the types yet; these types are yet to appear. We want to offer a general library that will be used for various types, i.e. for custom types that the user will define these types according to personal needs. The only thing we can rely on are the types built into a selected programming language because they are immutable.

If we need to deal with custom types that we do not know, generally there are the following solutions that may be applied. First is dynamic programming when types are created during program execution and will reflect the needs related to the data processing algorithm. The next one is independent conversion based on built-in custom functionality in new types. Finally, we should consider applying reflection, where type definitions become data for the program.

Dynamic programming is not promising and should be avoided because it is an error-prone run-time approach. Independent conversion is the design-time approach and must be considered as a serialization/deserialization method however it still needs custom serialization/deserialization functionality to be embedded in new type definitions. More in this respect you can get by checking out appropriate examples described in the document [Implementation Examples](./DataStreams/README.md). Reflection allows to write the program in such a way that the type features are recoverable and become data for the program. Reflection allows for avoiding custom implementation of the serialization and deserialization functionality. Hence, it will be described in more detail.

The language we have selected for education purposes is based on the concept of types. It is strictly typed. However, it is not the only one that uses type compatibility to check the correctness of the program at design time. However, the transition from the object-oriented world to the streaming world requires generic actions, consisting of creating generalized mechanisms for operating on data without referring to concrete type definitions. I mean the serialization/deserialization functionality must be implemented in a generic way without referring to type definitions, because the types may be unknown at this time.

Let me remind you that our goal is to automate data transformation between object graphs and bitstreams. We want this process to be mutually unambiguous, repeatable, and automatic. Data transformation from object form to stream form, so the transformation of an object graph requires reading the state of these objects and the relationships between them. The reverse transformation, i.e. converting a bit stream into an object graph, requires creating an instance of the object and assigning values to the object's fields or properties to recover its state based on the data obtained during deserialization.

The state of objects is the minimum set of values that is necessary to recreate an equivalent object. In the case of conversion from a stream to an object form, first of all, we must be able to create objects. If the objects are instantiated, the values that have been saved as the object's state must be assigned to the internal members that are part of this object. This also applies to those variables that store information about relationships between objects, i.e. reference variables.

So much theory. It's time to move on to practical acquaintance with selected reflection mechanisms. To get more based on examples check out the document [Implementation Examples](./DataStreams/README.md)

##### Conclusion

It's time to summarize selected features of reflection. The examples discussed show how to represent type features as [System.Type][system.type] instances. These instances can be created based on the type definition using the `typeof` keyword and objects of unknown type using the `GetType` method. In both cases, an object-oriented type description is created. The examples discussed also show how to use this description to read and write the values of a selected property. This ability is especially useful when implementing serialization and deserialization operations. Similarly, we can also read and write values from fields and call instance methods. Similarly, it is also possible to create new objects without referring to the `new` keyword. Discussing all the details of the reflection concept is far beyond the scope of the examples collected here.

[system.type]: https://learn.microsoft.com/dotnet/api/system.type

#### Attributes

Another topic is directly related to the issue of serialization/deserialization, namely attributes. Attribute is a concept used in various programming languages. They are used to add additional information to program text. Different languages may implement attributes in their own way, but the fundamental idea of associating extra information with code entities is common across many programming languages.

So the question is what are attributes? I propose to put this answer in the context of program snippets prepared using the selected programming language that will be used to explain the attribute linguistic construct. A description of the code snippets is available in the document [Implementation Examples](./DataStreams/README.md).

Based on these examples presented in the mentioned above document the discussion may be summarized as follows. An attribute is any class that inherits from the `Attribute` base class defined in the environment of the selected programming language. In addition, it also means a description of how to instantiate an object of this type, i.e. a language construct that we place before another language construct to which we want to associate additional data using an attribute. Objects that a programmer creates to implement an algorithm that is executed by the program. For this purpose, we use the mechanisms provided by reflection.

The examples show that attributes have broader applicability than just serialization and deserialization. However, the attribute concept can be used also to implement the serialization/deserialization processes but examples will be a subject of further discussion.

### Serialization Part 1

Now we are ready to return to discussing issues directly related to streaming data. During the previous episodes, we learned about the mechanisms of managing streams, especially in the context of files. We also learned the differences between bitstreams, text, and documents. We also learned about reflection, which can be useful for us. Now let's answer the question of how to create streaming data and how to use it.

First, let's try to define the purpose of our missions and the limitations we must deal with.

We've already talked a bit about why we need streams handled using files. Let's recall the most important applications, such as entering input data or storing output data using file systems. We also use various types of streaming devices to archive data, i.e. to save data forever. Data transfer between applications is another use case. I would like also to remind you that we have already talked about an example where we have a web server and a web browser. There is a virtual wire between them. We can only send bitstreams over this wire. The temporary and intermediate data repository is another example.

These are just a few examples, but let's limit ourselves to them because they are enough to justify the importance of this topic. Let me remind you that so far we have established that in the transition between the object world and the world of bitstreams, we need serialization, which is responsible for transferring the state of the object graph to a bitstream. And deserialization, which is responsible for the reverse process, i.e. for changing the bitstream into a graph of related objects. We would like this operation to be implemented as generic, i.e. we would not have to program this operation every time, but only parameterize it.

Before we take the next step, it is worth realizing what we need. Here, the list of requirements includes access to the data that will be the subject of the transition process, so we need values that will constitute the state of the objects and the relationships between these objects. The next thing we need is to implement an algorithm that will describe in detail this data transformation, in such a way that this transition is mutually unambiguous. And here, the mutual unambiguity of this process does not mean that each time we serialize we will obtain an identical bitstream.

It is enough for this bitstream to be correct, i.e. such that an equivalent graph of objects can be reconstructed based on the stream content. This reconstruction must be accomplished in compliance with the syntax, and semantics rules governing the stream content. Again, this graph does not have to be identical to the original. It is enough for us that it is equivalent from the point of view of the information it represents. It could be added that in some cases, let's say in simpler cases, the bitstream identity can be ensured. This means that for a selected graph of objects, each time as a result of serialization we will receive an identical stream of bits. Then this bitstream can be compared, for example, to check whether the process is the same as before. And this is where it must be stressed that equivalence has no measure in this respect. Due to the above, it is not possible to formally determine whether the resulting bit stream and the source object graph are equivalent. Therefore, equivalence must be decided by the programmer using custom measures. From that, we can derive that only the software developer is responsible for ensuring that serialization and deserialization are mutually unambiguous.

It is enough for this bitstream to be correct, i.e. such that an equivalent graph of objects can be reconstructed based on the stream content. This reconstruction must be accomplished in compliance with the syntax, and semantics rules governing the stream content. Again, this graph does not have to be identical to the original. It is enough for us that it is equivalent from the point of view of the information it represents. It could be added that in some cases, let's say in simpler cases, the bitstream identity can be ensured. This means that for a selected graph of objects, each time as a result of serialization we will receive an identical stream of bits. Then this bitstream can be compared, for example, to check whether the process is the same as before. And this is where it must be stressed that equivalence has no measure in this respect. Due to the above, it is not possible to formally determine whether the resulting bit stream and the source object graph are equivalent. Therefore, equivalence must be decided by the programmer using custom measures. From that, we can derive that only the software developer is responsible for ensuring that serialization and deserialization are mutually unambiguous.

Once we have data for transformation obtained from values that constitute the state of objects and the relationships between these objects. Once we have the implementation of the data transition algorithm, we now need to determine the form of the target stream. So we need to determine how to combine bits into words, how to combine words into correct sequences of words, and how to assign meaning to these sequences of words. Shortly, alphabet, syntax, and semantics rules.

Finally, two additional notes regarding the target form of the bitstreams. The list of applications that we mentioned previously includes the exchange of data between remote applications. It should be emphasized here that if these applications are created by different manufacturers, the standardization of this representation becomes extremely important. So, the fact that we combine words into correct sequences of words and give them meaning, that these semantic and syntactic rules are standard in the sense that there are international documents that are published by organizations recognized as standardizing, that will allow us to recreate the graph of objects in an application that is created by another manufacturer (by another developer). We also said earlier that sometimes these bitstreams are also used to communicate with humans. Of course, standardization is also important here. It is important that a person is able to read this sequence of bits, and therefore be able to combine sequences of bits into words and words into correct sequences of words. And that these strings of words had some meaning for him (had some semantic value). In the latter case, it is important to first be able to combine these bit strings into letters so that the record becomes a text record. Let me remind you that the text record is a binary crag for which an encoding has been specified.

From the previous considerations regarding the transformation of object data into streaming data, we know that the basis of this process is to determine the state of the object. Let me remind you that the state of an object is a set of values that must be subject to a transformation process so that the reverse operation can be performed in the future, i.e., so that the object graph can be recreated and, in fact, an equivalent object graph can be created.

In order not to enter into purely theoretical considerations, let us return to these topics in the context of sample programs.

#### Conclusion

The example discussed shows the mechanism of transferring an object or more precisely the state of the object to a bitstream. In this process, the state of the object is determined by the programmer by implementing an appropriate mechanism for determining the values that contribute to the state of the object. Since determining the state of an object is done (implemented) manually by the programmer in this approach, it is difficult to call this mechanism fully automatic.

### Serialization Part 2

From the previous considerations, we know that serialization is the process of transferring data from object to stream form. This transfer process must start with a selection of values contributing to the state of objects. The previously analyzed SelfControlSerialization class is based on internal reading operations of the values constituting the state of the object contained in the object type definition. This way, it is possible to avoid the need for employing the reflection by inheriting from the `ISerializable` interface. This interface acts as a contract between the target class that must implement it to be serialized and the class that implements serialization to read relevant values to accomplish this operation. In conclusion, serialization is a data transfer process in which an important feature is automation, i.e. an implementation that does not depend on the type of the serialized object, so it can be offered as a library solution and therefore used many times.

We must be aware that the proposed solution is not perfect. Actually, there are still many issues that have been left unsaid. So let's start by systematizing the shortcomings of the previous proposals.

The first issue that we can put a question mark on is automation. If we look at the code, we see that we must manually ensure that the appropriate values constituting the state of the target object are saved in the array, which will be passed on to be written to the stream.

The second issue is the necessity of synchronization of the custom operations carried out during the serialization with the operations carried out during deserialization. In the example discussed already, we see that we have two separate pieces of custom code that are responsible for this, and therefore any modification in one piece must be reflected in the other piece. This can lead to errors if this is not the case. The sample code could be slightly improved in this respect, but it still does not solve the problems.

In the previous example, we used XML text, but there are still many open issues that we need to talk about. One such issue is the answer to the question of what is the difference between XML text and an XML document.

An issue we haven't even mentioned is the visualization of data that has already been saved as a stream. Earlier, when discussing assumptions, we assumed that there may be a situation in which this data will also be intended for the user. One of the issues here is whether the fact that we use the XML standard to record data is enough to determine that this data is readable to a potential human user.

We also completely ignored the operation of graphs, i.e. a set of objects connected by references.

Let's first discuss the first two issues regarding automation and synchronization of the serialization process with the deserialization process. Let's discuss these issues using the example of a program.

### Serialization Part 3

### Catalog XML

Let's go back to the XML file and the question of how to visualize data for a user, for a human. You stated that an XML file is text and it is a bitstream for which the encoding is defined. For these circumstances, you can use any text editor,  what I am doing now to display it to the user. If this type of file, formatted this way, is seen by a person who is not familiar with XML technology, it will be very difficult for him to read the information he needs from this document. We can imagine that this file will be very long, that there will be, for example, a hundred CDs. And then using such a document is difficult.

To make it easier to visualize the data that is in the XML file, let's use a feature of XML files that allows the transfer of XML text to any other text by adding this additional line in the XML file. Here I have defined an additional document that specifies how to convert an XML document to another text. I have prepared an example XML document here, which is a stylesheet document and it is constructed in such a way as to convert the source XML document into an HTML document. If we open the source document by clicking on it, we will open a web browser and the source file will be displayed in a graphical form that can be much easier to understand by people who are not familiar with XML technology. If we look at the source of this document, we can see that it is simply a source document. This document that we originally had just got transformed thanks to browser transformation. So browsers have a built-in mechanism to convert an XML file to any other text file, in this case it is an HTML file based on a defined XML stylesheet document.

### To be done

Finally, a few notes related to XML transformation. Not only web browsers have a built-in mechanism ensuring transformation. This transformation can be defined in such a way that the target text that will be created has the features of a natural language. The final form may also cover ergonomic requirements, and in particular, it may be the user interface.

### Hierarchical and Non-hierarchical Serialization

Let's move on to the last issue related to the transfer of objects connected to each other and forming graphs. So the objects have references between them and these references will determine the structure of the objects. Generally, we can distinguish two types of these structures. The first one is hierarchical interconnection, which resembles a tree. In this case, starting from any point of such a structure and following the references we will never return to the starting point. In the case when graphs are non-hierarchical, then there are points in the graph that when we start from these points and follow along the references, it is possible to return to these points. So such graphs have loops. Since graph serialization requires an iterative approach, it requires that we iteratively traverse a tree of objects, provided that it is a tree. If there are cyclic connections causing loops in the graph of objects, then there will be a problem with stopping the iteration and avoiding double serialization of the same object. When to tell that an object has been serialized. For some objects, we have transferred them to a streaming form. But I propose to discuss this issue in detail.

### Cyclic references

Previously an object graph was presented as interconnected objects in such a way that they create a tree, or at least a layered model, therefore in this model, we can distinguish objects that are at the top and objects that are beneath in the hierarchy. Therefore, data transformation operations may be performed starting from those objects that are at the top and ending with those objects that are at the bottom of the hierarchy of references between objects. But it often happens that these references create cycles. For example, in this example  (fig. below), classes refer to each other creating a cycle.

![Fig. 1](.Media/Part3-N80-10-Diagram.png)

Assuming that instances of all classes are created, the question arises which of the objects should be subject to the transformation process first. Therefore, while in the previous case, we could insist that the hierarchy between objects is dependent on the order of representation of these objects in the stream, in the case when objects are connected recursively (they form a cycle), such an assumption cannot be made. Hence, here we enter the issue of equivalence of streams. If a stream contains a representation of all information including references, the order in which the data associated with each instance is placed in the stream is not relevant, provided that each object is serialized only once. Due to the above, it has to be considered that several different streams will contain equivalent states of individual objects and these object states will be placed in different orders will be equivalent to each other, which means that on their basis it will be possible to reconstruct an equivalent graph of objects. Creating equivalent streams does not mean that they have to be identical and therefore, for example, they can be compared with each other.

![Fig. 1](.Media/Part3-N80-20-Rekurencja.png)

Another issue that should be addressed here is when the transformation process should be ended. If we start with an instance of one class, let's say `ServiceA` (fig. above), next proceed to serialize the instance of the `ServiceB` class, and consequently proceed to an instance of the `ServiceC` class, we must have an iteration stop condition to avoid cloning of the instance `ServiceA` because it has been already serialized, i.e. the transformation process has been performed for it.

### ReadWRiteTest

The next topic is how to serialize the previously defined `Catalog` class, for which we have defined serialization rules. To serialize objects of this class we use reflection and attributed programming. The main aim of the [SerializationUnitTest.ReadWRiteTest][ReadWRiteTest] method is to test the serialization of the `Catalog` class instances. For this unit test, however, it must be populated with test data. This class is defined in unit tests, so I can add an appropriate method to this class that will fill the object of this class with test data. The only question is where to add it. Adding this method to auto-generated text, i.e. text obtained as a result of an external program, is not a good idea, because, after each modification and generation of a new text, our work is overwritten. Therefore, let's use the fact that this class is generated as a partial class, and to populate the instance of this class with test data, we have to expand its definition by adding a custom part, which will be its integral part. In this part of the definition, located in a separate file, we can safely add all the necessary operations that we want to perform for this purpose. For this method called `AddTestingData` I used attributed programming again by adding an attribute that indicates that this method will be subject to compilation only when we have an environment configuration named [BEBUG][Debug]. Coming back to the unit tests, we see that an object has been created and this object has been populated with test data. To make sure, we check that the instance has been created and initialized. Then we define the path where we want to save the file and use the `WriteXMLFile` method. This is a generalized, generic method. In its first parameter, we pass a graph of objects to be serialized, the file name, and details related to the creation of the file.

The [WriteXmlFile][WriteXmlFile] method has been defined in the library. We will not analyze it in detail but the only important thing is that we use the `XMLSerializer` library to perform the serialization operation. The serialization is implemented in this instruction:

``` csharp
  _xmlSerializer.Serialize(_writer, dataObject);
```

All other instructions generally are used to protect against wrong values of parameters and to improve the formatting of the output XML text.

Back to unit testing. For testing purposes, an operation is performed to read the same file and create equivalent objects, i.e. deserialization implemented in the following assignment instruction

``` csharp
  Catalog _recoveredCatalog = XmlFile.ReadXmlFile<Catalog>(_fileName);
```

We can now check whether the result is consistent with our expectation, i.e. whether the original object and the equivalent object have the same values that are part of the object's state.

There are two more things worth noting about the [ReadWRiteTest][ReadWRiteTest] method.  The first one is reading the stream and restoring the object graph. The second one is to check whether the graph of objects is equivalent compared with the original one. As we can see in this method, the same library called `XMLSerializer` is used. As previously the operation of restoring the graph of objects comes down to one instruction. From the example we can derive that testing if the recovered graph is equivalent to the original one strongly depends on the type definitions and cannot be performed universally, therefore it must be the developer responsibility.

### SerializationUnitTest

Although we know that this is not a universal approach, let us return to the discussion of the topics related to checking the equivalence of the recovered graph compared to the original graph in this specific case. The primary graph was created by creating an object of the `Catalog` class and then filling it with test data using the `AddTestingData` method. After deserialization, we check that the `_recoveredCatalog` variable has references to the newly created object, so it is not `null`. Then we check how many elements the array has. Here and in the next two lines it is assumed that these are only two elements, but it would also be worth checking the actual length of the array. However, the most important thing here is to check whether two subsequent disc descriptions compatible with [CatalogCD][CatalogCD] are equivalent to each other. The symbol of identity is used to compare them, although we expect that the elements are equivalent, not identical. This effect can be achieved by redefining the identity check operation in the [CatalogCD][CatalogCD] class. For this purpose, the definition of the equals operator has been overwritten. As a result, the behavior of a new definition of this operator determines what equals means. The standard `Equals` method is used here. This operation compares strings according to the type `string`. These strings are generated by the overridden `ToString` method. It determines which elements will take part in this comparison and how they will be formatted. It is worth emphasizing here that it may happen that the string formatting depends on the current operating system language settings and, depending on different data types, the formatting of this string may not be clear; it may not be the same every time.

### Non-Tree Graph

At the end of our considerations, let's go back to non-tree graphs. In such graphs, there is no restriction on the number of paths between any pair of vertices, and cycles may be present.. We may encounter two problems here. Firstly, we may encounter many-to-one references in this type of graph, when many objects will have references to one object. As a result, we can expect that serializing such a structure may cause the cloning of one object in the stream. During recovery, if all these objects are recreated, many redundant copies are instantiated, so the structure will be different comparing it with the original. In the case of cyclic graphs (contain cycles - closed loops) in the relationship structure, we must take into account the fact that the serialization mechanism (the graph-to-stream conversion mechanism) will have to deal with this problem and therefore will have to set a stop condition to avoid cloning objects in the output stream. Well, we have two options to solve this issue. The first option is to write a custom library but this is a complex process,. The second approach to address this problem is to choose an appropriate but existing library. There are many such libraries on the market and when analyzing applicability of them, you should pay attention to these issues.

[CatalogCD]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/Catalog.xsd.cs#L56-L79
[ReadWRiteTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/SerializationUnitTest.cs#L42-L58
[Debug]: https://learn.microsoft.com/visualstudio/debugger/how-to-set-debug-and-release-configurations
[WriteXmlFile]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams/Serialization/XmlFile.cs#L41-L62

## Cryptography

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
