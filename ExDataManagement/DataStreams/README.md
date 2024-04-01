<!--
//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________
-->

# Data Streams

## Introduction

To use computers to automate information processing we have to deal with bitstreams as the information representation. By design, bitstream management involves the organization, storage, retrieval, communication, and manipulation to ensure accuracy, security, and accessibility. It encompasses data collection, storage architecture, integration, and maintenance to support efficient analysis and decision-making. To fulfill these requirements, the following concepts could be a real relief. It includes but is not limited to presentation, validation, standardization, serialization, and safeguarding of data.

This folder `ExDataManagement\DataStreams` contains examples related to information representation as a bitstream and is devoted to discussing selected programming issues related to their management.

## File and Stream Concepts Preface

If we write a program to automate information processing, we inevitably have to operate on data representing this process. Generally, we can distinguish operations related to reading input data, permanently preserving intermediate data, transferring data between individual applications, and saving the final data somewhere after completing the entire processing process. All these requirements can be accomplished using the concept of file. Even sending data between applications can be done using a file server, distributed file system, Google Drive, One Drive, and Pendrive to name only the most popular ones.

This is where the term file system came into play. Without going into details about the architecture of the computer and the operating system, we can enigmatically state that the file system is a resource available in virtually every modern computer. For us, its most important feature is the ability to manage files. First of all, the file is metadata, i.e. data describing data. So here we may have the first indication that we are talking about data that we are describing. One such description is an identifier that plays two roles. One is that it clearly distinguishes it from all other files. In this role, it could be recognized as a Uniform Resource Identifier(URI) - the text that is a unique identifier of a file among others. The second one indicates the location, namely where the file may be found by the file system engine. In this role, it is a Uniform Resource Locator (URL). We also have other metadata such as date of creation, author, length, and many others.

An important feature of a file concept is that it contains content in addition to metadata. Metadata is, of course, a very important component of any file but the most important thing is the content it includes, which is data representing information to take part in processing.

Hopefully, everything we've talked about so far seems quite obvious, but since some file features are fundamental for further discussion, let's look at them in detail.

Let's start with the fact that typically we utilize object-oriented programming. This means that at design-time we have to deal with reference types and at runtime, we must deal with objects located in a computer's working memory (RAM). Let me remind you that the RAM abbreviation stands for Random Access Memory. Here, random means that each word in memory has an address, i.e. a unique identifier, and this word can be independently read or written there. Let me stress we are talking about freedom but not probability. It means that again the RAM address plays the role of URL. Therefore, object data can be organized into structures and linked by references.

On the other hand, we have the streaming world where the data is organized in the form of bitstreams, where each bit of data has only information about the next one.

## Useful Concepts for Bitstreams Deployment

### Introduction

To use computers for automation of information processing we have to recognize bitstreams as the information representation. By design, bitstream management involves the organization, storage, retrieval, communication, and manipulation to ensure its accuracy, security, and accessibility. It encompasses data collection, storage architecture, integration, and maintenance to support efficient analysis and decision-making. To fulfill this functionality the following set of concepts could make a real relief. It includes but is not limited to presentation, validation, standardization, and serialization operations.

### Presentation

Bitstreams presentation is implemented by various ways of conveying information, including textual and tabular formats. Hence, first of all, we need to deal with data presentation, so as to enable the use of bitstreams also by a human computer user. In this context we must take into account the following terms: natural language, ergonomics, and graphical user interface.

A typical example that we can cite here is using the Internet. Using a web browser, a server-side application uses objects and then serializes the data that the user needs, sends it over the network, and then the browser displays it on the screen. And here it is important, that the browser always displays data in graphical form. This applies to all kinds of data used by humans. Data, even when reading a newspaper, is always formatted as a graphical presentation. Let me remind you that any character is also a small picture. This is one feature of data that is prepared for this. so that man can use them. The second feature is that this data must be written in a natural language that humans know. The concept of natural language is very broad. For example, XML text is said to be human-readable. But is this a piece of natural language?

From the above, we can derive that the bitstream should be formatted to resemble a natural language. Of course, we have no measure here and therefore it is difficult to say whether something is close enough to natural language to be comprehensible.

### Validation

Applications save working data into bitstreams (for example content of files) to keep state information, provide processing outcomes, or both. Applications need robust storage, i.e. correctness of the stored data has to be validated every time an application reads it back from a bitstream. It must be carefully observed if the bitstreams are also modified by other applications or directly by users, because data corruption may occur.

If we are talking about exchanging data between different applications or between an application and a human, the issue of data correctness arises. This issue should be considered on two independent levels. The first one is the correctness of a stream of signs, i.e. validation if the selected syntax rules are met. The second one is the possibility of assigning information (meaning) to these correct sequences and therefore assigning meaning to a bitstream. For humans to understand the stream, it will be accomplished by defining semantics rules, i.e. rules that will allow us to associate meaning with bitstream. The issue of ergonomics is also important in how easy it is to absorb information represented by the bitstream. Of course, the closer we are to natural language, the easier it will be, but again in this matter, we do not have measures that will allow us to determine how good our solution is.

To better understand the above mentioned topics, let's look at them in the context of code examples explained in the section [XML-based Validation][xml-based-validation]. In this section, XML examples are only subject to more detailed examination but by design, it has no impact on the generality of the discussion.

### Standardization

When we talk about the syntax and semantics of a stream, the first thing to consider is the scope of data use. Data produced by one program instance can also be used by the same program instance. In such a case, if the process runs autonomously and is symmetric from a serialization and deserialization point of view, we should not expect any further problems.

If we are talking about interoperability between different applications, we must consider a situation in which these applications have been written using different programming languages. In this case, the problem arises of how to create types in other languages that will represent the same information. In the context of a text document, a kind of schema may be used.

The schema in this context refers to a bitstream structure or blueprint that defines the organization and format of the document. It outlines the arrangement of elements, their relationships, and any rules or constraints that govern the content of documents. Simplifying, schema allows the definition of additional syntax rules in a domain-specific language. Schemas help ensure consistency in the representation of information within the text document. It means schema definition could also be a foundation of semantics rules that assign meaning to the document text. As a result, we could recognize the schema as a good idea to validate text documents and check whether incoming text is a document we expect. Instead of using a schema to validate text-based bitstreams, we may use an equivalent set of classes.

Because the data may be used by different instances of a program, we also have to take into consideration that the applications may be in different versions or written using different languages. What is worse, the data representation also must be subject to versioning. In such a case, there is a problem of data compatibility between independent instances of the program. So the question arises whether the data serialized by one version of the program is used by another version of the program run as a different instance.

Another very popular applicability domain of streams may be the use of them to implement interoperability between instances of various programs that are created using different technologies and implemented on different platforms. Then there is also the issue of technological compatibility. Also in this case, it must be taken into consideration that classes (types) that were created in one technology cannot necessarily be directly used in another technology. In this case, we must take into account that in another technology the same information will be represented differently.

If schema definition is expressed in a widely accepted format it should be possible to generate types in selected programming language based on this schema. Of course, it is a chicken and egg problem namely, should we first create types in the selected programming language, or should we create these types in the schema and then create classes based on the schema definition? But let's try to see how this can be achieved using an example.

### Serialization

We need bitstreams to be handled using files to make sure that the data can be persisted. Let's recall the most important applications, such as entering input data or storing output data using file systems. We also use various types of streaming devices to archive data, i.e. to save data forever. The temporary and intermediate data repository is another example. Data transfer between applications is another use case. It requires that data must be transferable. For example interoperability of a web server and a web browser. There is a virtual wire between them. The virtual wire is not an abstract interconnection but means that only bitstream can be transferred between them. There are many more examples but let's limit the discussion to the mentioned only because they are enough to justify the importance of this topic.

In the already mentioned use cases, data must be in the form of bitstream. Now we are ready to return to discussing issues directly related to streaming data. Previously, we discussed the mechanisms of managing streams, especially in the context of files. We also realized the differences between bitstreams, text, and documents. Now let's answer the question of how to create streaming data and how to use it. First, let's try to define the purpose of our missions and the limitations we must deal with.

The first problem is related to the inevitable necessity of dealing with two concepts, namely object data with the data formatted as bitstreams. The transition process from the objects to the stream is called the serialization. Deserialization is the reverse process, which involves replacing the bitstream with interconnected objects located in the working memory of a computer. Hence, in the context of serialization, to save working data in a file we need a generic operation that could automate this transition process regardless of the types we used to create the graph of objects wrapping working data. There must be also a reverse operation creating objects from a file content - deserialization. To guarantee consistency, this operation has to verify the file content against the types used to instantiate objects.

Again, in the transition between the world of objects and the world of bitstreams, we need serialization, which is responsible for the transition of the state of a graph of objects to a bitstream. And deserialization, which is responsible for the reverse process, i.e. for transferring a bitstream into a graph of interconnected objects. We would like these operations to be implemented as generic, i.e. we would not have to program these operations every time, but only parameterize it.

Before we move to the next step, it is worth recognizing what we need to implement this functionality. Here, from the world of objects point of view, the list of requirements includes:

- access to the values wrapped by objects that will be the subject of the serialization - in other words, values that will constitute the state of the objects
- the relationships between these objects

Next, we need to implement an algorithm that will describe in detail this data transformation, which has to be mutually unambiguous. Here, the mutual unambiguity of this process does not mean that each time we perform serialization we will obtain an identical bitstream. The same we should state for deserialization. We will get back to this issue shortly.

So the first problem we have is how to implement serialization and deserialization to make the transition between the object world and the streaming world possible. The serialization and deserialization process must be mutually unambiguous operation. Moreover, it is not a simple process. Well, someone may say that this is a relative matter because we have no firm metrics of simplicity in this case. However cloning serialization and deserialization code snippets each time serialization is needed will consume and waste time, so it may be worth implementing this process as a generic library, without the need to create dedicated software each time. So the next problem we can define here is the possibility of transition between the streaming world and the object world using the library concept.

If we talk about repeatability by applying a library concept implementing serialization and deserialization functionalities, we need to offer a generic implementation. Namely, we must be able to define this process in advance, without prior knowledge of what will be serialized. Generic implementation of the serialization and deserialization functionality means that we have to implement it in advance and offer it as ready-to-use libraries.

Today on the market, we have many libraries that permit this process to be carried out automatically. So it is justified to ask the following question why do we need to learn about it? Why go into detail? Well, my point is that if someone wants to use a washing machine, let me refer to this example, they do not need to know how the controller, engine, or temperature sensor works. However, if someone wants to assemble a custom washing machine using available parts, knowledge or understanding of how the engine, controller, and temperature sensor work is essential in this case even if the mentioned parts are available. Similarly, we need detailed knowledge about how to manage bitstreams in case we are going to use streaming data, for example, the file system.

In summary, to simultaneously use data as objects and bitstreams, our goal must be to combine two worlds. First, in which the data is in object form. The second world contains data in the form of bitstreams. Let me stress now that in both cases we have the same information but different representations. The data conversion between these worlds is called serialization and deserialization. In the case of serialization, it is a process that involves converting the state of a graph of objects into a bitstream. Deserialization is the reverse process, i.e. converting a bitstream into a graph of objects that must be created in memory. Here the magical statement about the condition of the object appeared; what does object state mean? We will learn the answer to this question soon.

From the above, it could be derived that if an equivalent graph of objects can be reconstructed based on a bitstream it can be stated that the bitstream is correct for the purpose it has to serve. This reconstruction must be accomplished in compliance with the syntax, and semantics rules governing the bitstream. Again, this graph does not have to be identical to the original each time. It is enough for us that it is equivalent from the point of view of the information it represents. It could be added that in some cases, let's say in simpler cases, the bitstream identity can be ensured. This means that for a selected graph of objects, each time as a result of serialization we receive an identical bitstream. Then this bitstream can be compared, for example, to check whether the process is the same as before. It must be stressed that equivalence has no metrics measure that can be applied to evaluate equivalence conditions. Due to the above, it is not possible to formally determine whether the resulting bit stream and the source object graph are equivalent. Therefore, equivalence must be decided by the software developer using custom measures, for example, unit tests. From that, we can derive that only the software developer is responsible for ensuring that serialization and deserialization are mutually unambiguous.

Assuming that the data transformation algorithm has been implemented somehow, there is a need to determine the format of the target bitstream. So we need to determine how to concatenate bits into words, words into correct sequences of words, and how to assign meaning to these sequences of words. Shortly, a set of valid characters, syntax, and semantics rules are required. For example, it could have an impact on the bitstream features, like the possibility of validating and visualizing content using existing tools. Two additional notes regarding the target format of the bitstreams are vital for further consideration.

The list of applications - mentioned previously as potential bitstream consumers - includes the exchange of data between remote applications. It should be emphasized here that if these applications are created by different manufacturers, the standardization of this representation becomes extremely important. So, the fact that we combine words into correct sequences of words and assign to them meaning, that these syntax and semantics rules are standard in the sense that there are international documents that are published by organizations recognized as standardizing, that will allow us to recreate the graph of objects in applications that are created by other vendors.

We also said earlier that sometimes these bitstreams are also used to communicate with humans. Of course, standardization is also important for this kind of application. A bitstream user must be able to read this sequence of bits, and therefore combine sequences of bits into words and words into correct sequences of words. Finally, these strings of words have to have meaning for him. First, it is important to be able to apply encoding to create characters so that the bitstream becomes a text. Let me remind you that the text is a bitstream for which encoding is known in advance or discoverable somehow.

From the previous considerations regarding the transformation of object data into streaming data, we know that the basis of this process is to determine the state of the object. Let me remind you that the state of an object is a set of values that must be subject to a transformation process so that the reverse operation can be performed in the future, i.e., so that the object graph can be recreated and an equivalent object graph can be created.

In order not to enter into purely theoretical considerations, let us return to these topics in the context of sample programs. The examples are described in the document titled [Objects Serialization][objects-serialization]. The example discussed shows the mechanism of transformation of an object or more precisely an object state to a bitstream. In this process, the state of the object is determined by a software developer, which implements an appropriate mechanism responsible for selecting the values that constitute the object state. Since the determination of an object state is the responsibility of program authors, there must be measures allowing them to point out what has to be serialized.

To implement a serialization/deserialization engine, you need to define a data structure, choose a serialization format (like custom, JSON, XML, etc.), and use a serialization library to convert the data wrapped by a graph of objects into the selected format in both directions. The data structure is required to determine the state of objects that are subject to serialization. Apart from the data structure a guidelines allowing to select only values constituting the state of the object are necessary. To fulfill the mentioned requirements access to the value holders that constitute the state of the object is also required. Attributes as a language construct at design-time and reflection as a technology at run-time could help to solve some problems related to serialization/deserialization implementation.

> To learn more about the serialization in .NET, visit the document: [Serialization in .NET][STLZTN].

### Cybersecurity

#### Introduction

Cybersecurity describes the practice of protecting computer systems, networks, and data from cyber threats. In this section, cybersecurity related to bitstreams is considered. Now let's talk about securing streams using cryptography. Talking about cryptography in the context of streams may seem a little strange because usually cryptography is discussed in the context of data security and system security in general. Cryptography is a broad concept, but we will focus only on selected, very practical aspects related to the security of bitstreams.

We already know how to create bitstreams. We can also attach coding to them, i.e. the natural language set of characters. The next step is to assign syntax and semantics that allow the streams to be transformed into a coherent document, enabling a computer user to recover information from these documents. If this is not enough, we can also display these documents in graphical form.

It must be stressed again that in all occurrences this computation infrastructure is always binary, and we must consider that it may be sent over a network, archived, and processed by another computer.  Hence, it is required that the bitstreams are protected against malicious operations. For example, if a document contains a wire transfer order to our bank, the problem becomes real, material, and meaningful in this context.

In the context of the cybersecurity of bitstreams implementation, the following requirements must be encountered:

1. ensure that all users of a source bitstream can verify that the stream has not been modified while it was being archived or transmitted,
1. safeguard information from unauthorized access, ensuring confidentiality,
1. confirm authorship, so all users of a bitstream can determine who created it and who is responsible for its content. This requirement we call non-repudiation of the author.

A short description of methods used to protect a bitstream against malicious users may be found in the following chapters. Examples illustrating how to implement them are collected in a separate document [Bitstream Cybersecurity][READMECryptography].

#### Hash

If we are talking about archiving streams or transferring streams from one system to another, from one computer to another, the first thing we need to take care of is the integrity of such a stream. This means that from the moment it is produced until it is at its actual destination, where it will be processed, it is not modified. The best way to accomplish this is by using the hash function.

Thanks to the hash function, we can secure the integrity of the controlled bitstream, provided that we can transfer the hash function value to the destination in such a way that malicious users cannot modify it. Otherwise, modifying the source stream is not a problem because calculating a new hash function value that takes this modification into account is quite a trivial operation.

Bitstream integrity refers to the assurance that the bitstream remains intact during transmission or storage. It ensures that each bit in the data stream retains its original value without corruption or errors.

#### Encryption

It often happens that only authorized persons should have access to the information represented by a bitstream. To address this requirement, we may use the bidirectional transformation mechanism to replace a source bitstream with another bitstream to which we can no longer attach the encoding, syntax, and semantics rules. As a result, it makes it impossible to associate information with this bitstream. The bitstream is no longer meaningful data. The obtained from the transformation bitstream resembles white noise. However, any person who has the right to access the associated with the source bitstream information; should be able to recover the source bitstream and as a result associate back the encoding, syntax, and semantics rules. As a result, it allows recovering the information represented by the source bitstream. The process is similar to replacing music with noise but granting the possibility to recover music from that notice by the authorized user. Unauthorized users can hear only noise, but authorized users can transform the noise back to the original music. This reversible transformation function we will call encryption.

Hence, selective access is required to protect any bitstream including but not limited to hash value against unauthorized access. Selective access is the ability to access information that is associated with a bitstream only by people who are authorized to do so. We can accomplish this in two ways:

1. selective availability of the bitstream itself
1. selective availability of the bitstream meaning

The first approach is to share the bitstream, for example, as a file, only with people who have the right to get access to it. This can be achieved thanks to the authentication and authorization offered by most operating systems. Authorization in the context of an operating system refers to the process of granting or denying permissions to identity attempting to perform certain operations on a computer system. Thanks to this, each time an attempt is made to operate on a file, it is first checked whether the identity that requested the execution of an operation has the right to do so. Of course, if someone does not gain access to the bitstream (to the file content), he will necessarily not have access to the information that is associated with this bitstream. Unfortunately, this approach is possible only in case there is something trusted in the middle between the file and the user, for example, a well-configured operating system. This topic generally doesn't deal with operating systems implementation, so this approach is outside the scope of our interest. Hence, we have to deal with another security method.

The second option is to transform a bitstream (for example the file content, hash function value, etc.) into a form that an unauthorized user cannot associate any information with this bitstream. This method we call encryption. In other words, encryption involves transforming or scrambling bitstreams to make the underlying information unavailable to unauthorized users.

Bitstream encryption encompasses encrypting data at the bit level, which is often used in various scenarios. These scenarios employ encryption techniques to protect data integrity, confidentiality, and privacy against unauthorized access and interception. We can distinguish between symmetric and asymmetric encryption. Symmetric encryption uses the same key for encryption and decryption, while asymmetric encryption uses a pair of keys: a public and a private key.

We have already learned about the hash function to protect bitstream integrity. However, there is still a problem with how to distribute its result so that in different places of the IT system, and different locations in the world this hash value can be used to check the integrity of a bitstream. In the case of symmetric encryption, in which we use identical keys for the encryption and decryption, inter-operating parties have the same problem of distributing these keys among the authorized users who have the right to access the information represented by this stream. There is another problem with the use of symmetric encryption, namely scalability. It consists of the fact that the number of keys that we need to manage for encryption and decryption increases rapidly, that is, it increases with the square of the number of parties that participate in the data sharing.

However, the main drawbacks of asymmetric encryption include:

1. **Computational Overhead** - asymmetric encryption algorithms are typically more computationally intensive compared to symmetric encryption, requiring more processing power and time for encryption and decryption operations
1. **Limited Performance for Large Data** - asymmetric encryption is less efficient for encrypting large amounts of data compared to symmetric encryption, making it less suitable for bulk data encryption.

Overall, while asymmetric encryption provides valuable security features such as key distribution and digital signatures, it also introduces complexity and performance limitations that must be carefully considered in design and implementation. A tradeoff is needed to deploy the cryptography. Usually, a temporary key is generated, and before use protected by asymmetric encryption. This way only a symmetric key is protected instead of the target bitstream.

#### Non-repudiation

When talking about documents such as a wire transfer order, there is no need to provide any special justification that the recipient of such a document will be vitally interested in being able to determine that the document has been issued by an authorized person, for example by the owner of the account for which the order was issued.

Because we use file systems and transfer bitstream data over computer networks non-repudiation of streaming data inherently must be the subject of our particular concern. Non-repudiation can be achieved by providing a way to verify that the sender of a bitstream is who claims to be and that the bitstream has not been altered during transmission. To achieve this protection a digital signature is applied. The digital signature is a cryptographic technique used to ensure the authenticity and integrity of a bitstream.

To implement a digital signature, the sender uses a private key to create a unique digital signature for the bitstream. This private key is known only to the sender and is kept confidential. The recipient, in turn, can verify the signature using the sender's public key. The public key is widely distributed and can be freely shared.

If the digital signature is valid, it confirms that the bitstream is indeed signed by the holder of the private key associated with the public key used for verification. The digital signature also ensures that the content of the bitstream has not been altered since the signature was created. Even a bit of change in the bitstream causes a completely different signature.

## BitStream Format

### Domain Specific Language (DSL)

Using bitstreams (file content) we must look out for a problem with how to make bitstreams human readable. The first answer is that it must be compliant and coupled with a well-known application. The application opens this bitstream as input data and exposes it to the user employing appropriate means to make the data comprehensible.

Unfortunately, this approach does not apply to custom data. Therefore we should consider another approach, namely human-readable representation should be close to natural language. The first requirement for humans to understand the stream is that it has to be formatted as text. To recognize bitstream as the text an encoding must be associated by default, directly or indirectly. The next requirement, common for both humans and computers, is that a bitstream must be associated with comprehensible syntax rules. Finally, semantics rules should be associated with the bitstream that allows to assigning of meaning to bitstreams. Shortly there have to be defined a text-based language. A domain-specific language (DSL) is a text-based language dedicated to expressing concepts and data within a specific area. Except for programming languages like Java, C#, and Python, examples of well-known and widely accepted domain-specific languages are XML, JSON, and YAML to name only the most crucial.

Using DSL to describe the bitstreams a Data Transfer Object (DTO) concept can be used as a foundation to encapsulate and transport data between computer programs. It may be a text document that contains fields to store data.

To use DTO in a multi-vendor environment to transfer data between instances of different programs the standardization of the syntax and semantics rules is vital. Additionally possibility to use well defined and widely accepted schema documents is a key feature to establish interoperability.

### Extensible Markup Language (XML) Format

#### Introduction

Extensible Markup Language (XML) is a standard text-based format for representing structured data in machine-readable form. Because it is founded based on the text it could also be recognized as human-readable. Its simplicity and flexibility make it suitable for representing a wide range of data formats.

It consists of markup tags that define elements within a document. Each element can have attributes and contain nested elements, forming a hierarchical structure. The basic syntax involves opening and closing tags to encapsulate data. Attributes provide additional data in context of the opening tag.

XML is often used for data interchange between different applications.

Overall, XML is versatile and widely adopted in various domains for configuring settings and exchanging process data.

#### Visualization

As the XML format is text-based it can be directly read and displayed by a variety of software tools. However, it is not the preferred format, because it does not contain any formatting information. Today we expect data presentation to meet user experience, i.e. to have an appropriate layout and style. We can meet this requirement using any application that supports XSLT transformation of XML documents into other text documents, including but not limited to equivalent HTML documents. XSLT uses a template-driven approach to transformations: you write a template that shows what happens to any given input element. For example, if you were formatting working data to produce HTML for the Web, you might have a template (stylesheet file) to match an underlined group of elements and make it come out as a table.

Let's go back to the the question of how to visualize data for a user, for a human. It was stated that an XML file is text, namely a bitstream for which the encoding is defined. It allows to employ of any text editor. Unfortunately, if a file is formatted this way and is seen by persons, who are not familiar with XML technology, it won't be easy to associate any information with the text. In this context reading the document and understanding the document are not the same.

To make it easier to visualize the data that is in the XML file, let's use a feature of XML files that allows a transformation of XML text to any other text. Finally, a few notes related to XML stylesheet transformation. Not only web browsers have a built-in mechanism ensuring transformation. This transformation can be defined in such a way that the target text that will be created has the features of a natural language. The final form may also cover ergonomic requirements, and in particular, it may be the user interface. Shortly, thanks to the transformation of XML files using stylesheet it is possible to add formatting to the data contained in the XML bitstream.

> - To get more about how to start with XSLT visit the W3C School: [XSL(T) Languages][XSLW3C]
> - To check out an examples visit the section [XML-based Presentation][xmlpresentation]

#### Validation

To address the validation requirement XML (Extensible Markup Language) as a text-based format for representing structured information and XML Schema as a language for expressing constraints about XML documents are very good candidates to be used by the file operation. Today applications use objects to process working data according to the Object Oriented Programming (OOP) paradigm.

You may use the [XML Schema Definition Tool (Xsd.exe)][XSD], which generates XML schema or selected language classes from XDR, XML, and XSD documents, or from classes in a run-time assembly.

To better understand topics related to validation check out code examples described in the section [XML-based Validation][xml-based-validation].

#### Standardization

Extensible Markup Language (XML), is a standardized markup language designed to store and transport data. It provides a set of rules for encoding documents in a machine-readable format. XML standardization ensures consistency in data representation and interchange across different systems.

Visit the `See also` section to get more details.

### JavaScript Object Notation (JSON)

#### Introduction

JavaScript Object Notation (JSON), is a lightweight data interchange format. It is a text-based domain-specific language that is easy for humans to read and write, and for machines to parse and generate. JSON is often used to transmit data between a server and a web application, as well as for configuration files. It consists of key-value pairs and supports data types like strings, numbers, objects, arrays, booleans, and null.

#### Visualization

Yes, JSON can be transformed into other text formats using a variety of programming languages employing additional libraries for parsing and then converting to different formats like CSV, XML, or others as needed. Languages like JavaScript can be also used for transforming JSON documents to other text formats. JavaScript has built-in functions for JSON manipulation, and you can use libraries or frameworks to convert JSON to various formats as needed.

#### Validation

Thanks to schema definition it is possible to derive new domain-specific languages based on JSON.

To address the validation requirement JSON (JavaScript Object Notation) as a text-based format for representing structured information and JSON Schema as a language for expressing constraints about JSON documents are very good candidates to be used by the operation on bitstreams.

You may use a lot of available in the open access domain tools, which generates XML schema or selected language classes from different kinds of documents.

To better understand topics related to validation check out code examples related to XML described in the section [XML-based Validation][xml-based-validation]. XML is used to express a general disunion using concrete language.

#### Standardization

This language is recognized as an international standard. It is standardized by the International Organization for Standardization (ISO) as [ISO/IEC 21778:2017][ISOJSON]. The standardization ensures that JSON is consistent and widely accepted for data interchange between different systems and programming languages. There is also [Request for Comments:7159][RFCJSON] specification titled _The JavaScript Object Notation (JSON) Data Interchange Format_.

ISO/IEC 21778:2017 specifies the JSON data interchange format, its data model, and its various data types. JSON's simplicity, ease of use, and language-agnostic nature have contributed to its widespread adoption in various domains for representing and exchanging data. JSON is also supported by an open community maintaining schema specification [JSON Schema][CommunityJSON]

### Yet Another Markup Language (YAML)

#### Introduction

YAML, short for "YAML Ain't Markup Language" is a human-readable data serialization format. It is often used for configuration files and data exchange between development environments with different data structures. YAML uses indentation to represent hierarchy and relies on a straightforward syntax with key-value pairs. It aims to be easy to read and write, making it popular in various applications, including configuration files for software projects.

#### Visualization

YAML doesn't define any special language allowing automatic transformation of YAML document to other text-based documents that can be used to visualize associated information. To visualize the content of a YAML document, you can use various tools and editors that support YAML. Here are a few options:

- **Online YAML Editors**: Use online YAML editors like YAML Online Viewer or YAML Lint, where you can paste your YAML code and visualize the structure.
- **Integrated Development Environments (IDEs)**: Many modern IDEs, such as Visual Studio Code, Atom, and PyCharm, have built-in support for YAML. Open your YAML file in one of these IDEs to benefit from syntax highlighting and a structured view of your YAML document.
- **YAML Viewer Browser Extensions**: there are browser extensions available that can format and visualize YAML files directly in your browser. Check for extensions compatible with your preferred browser.
- **Command-Line Tools**: you can use command-line tools like `yq` or `jq` to format and view YAML content.
- **Online YAML Visualizers**: some websites offer online YAML visualizers that allow you to paste your YAML code and see a visual representation of the data structure. Search for "Online YAML Visualizer" to find such tools.

Choose the method that best suits your preferences and workflow.

#### Validation

While YAML itself is not designed to be extended or derived into new languages, it is possible to create domain-specific languages (DSLs) or configuration languages based on YAML syntax. Developers can define specific rules and conventions within the YAML structure to suit the requirements of their particular domain or application.

In essence, you can create a new language by establishing a set of guidelines for interpreting the YAML data in a specific way. This is often done in the context of configuration files or data representation for a particular software or system. Keep in mind that this is more about using YAML as a foundation and defining the semantics and rules for your specific language rather than formally deriving a new language from YAML.

## See Also

- [References](./../../REFERENCES.md#references)

[CommunityJSON]: https://json-schema.org/specification#specification
[ISOJSON]: https://www.iso.org/standard/71616.html
[RFCJSON]: https://datatracker.ietf.org/doc/rfc7159

[XSLW3C]: https://www.w3schools.com/xml/xsl_languages.asp
[XSD]: http://msdn.microsoft.com/library/x6c1kb0s.aspx
[STLZTN]: http://msdn.microsoft.com/library/7ay27kt9.aspx

[objects-serialization]: DataStreams/READMESerialization.md#objects-serialization
[READMECryptography]: DataStreams/READMECryptography.md#bitstream-cybersecurity
[xmlpresentation]: DataStreams/README.md#xml-based-presentation
[xml-based-validation]: DataStreams/README.md#xml-based-validation
