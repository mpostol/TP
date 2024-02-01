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

# Data Streams <!-- omit in toc -->

- [Key words](#key-words)
- [Introduction](#introduction)
- [File and Stream Concepts Preface](#file-and-stream-concepts-preface)
- [Useful Technologies](#useful-technologies)
  - [Introduction](#introduction-1)
  - [Data Presentation](#data-presentation)
  - [Validation](#validation)
  - [Standardization](#standardization)
- [BitStream Format](#bitstream-format)
  - [Domain Specific Language (DSL)](#domain-specific-language-dsl)
  - [Extensible Markup Language (XML) Format](#extensible-markup-language-xml-format)
    - [Introduction](#introduction-2)
    - [Visualization](#visualization)
    - [Validation](#validation-1)
    - [Standardization](#standardization-1)
  - [JavaScript Object Notation (JSON)](#javascript-object-notation-json)
    - [Introduction](#introduction-3)
    - [Visualization](#visualization-1)
    - [Validation](#validation-2)
    - [Standardization](#standardization-2)
  - [Yet Another Markup Language (YAML)](#yet-another-markup-language-yaml)
    - [Introduction](#introduction-4)
    - [Visualization](#visualization-2)
    - [Validation](#validation-3)
- [BitStream Cybersecurity](#bitstream-cybersecurity)
  - [TBD](#tbd)
- [Serialization](#serialization)
  - [Fundamentals](#fundamentals)
  - [Implementation](#implementation)
    - [Preface](#preface)
    - [Attributes](#attributes)
    - [Reflection](#reflection)
  - [Access to Object State Values](#access-to-object-state-values)
    - [Introduction](#introduction-5)
    - [Self Controlled](#self-controlled)
    - [Attributes and Reflection](#attributes-and-reflection)
  - [Graph of Objects Serialization](#graph-of-objects-serialization)
  - [Conclusion](#conclusion)
- [See Also](#see-also)

## Key words

Bitstream, File, File System, XML, XSLT, HTML, XmlSerializer, Save file, Transformation, Saving text files, Local File Systems, Open and read file, XML Schema, Common File Format, Data Access, XML Serialization, Data Validation, Data Visualization

## Introduction

This folder `ExDataManagement\DataStreams` contains examples related to information representation as a bitstream and is devoted to discussing selected programming issues related to their management.

If we write a program to automate information processing, we inevitably have to operate on data representing this process. Generally, we can distinguish operations related to reading input data, permanently preserving intermediate data, transferring data between individual applications, and saving the final data somewhere after completing the entire processing process. All these requirements can be accomplished using the concept of file. Even sending data between applications can be done using a file server, distributed file system, Google Drive, One Drive, and Pendrive to name only the most popular ones.

## File and Stream Concepts Preface

This is where the term file system came into play. Without going into details about the structure of the computer and the operating system, we can enigmatically state that it is a resource available in virtually every modern computer. For us, its most important feature is the ability to manage files. First of all, the file is metadata, i.e. data describing data. So here we may have the first indication that we are talking about data that we are describing. One such description is an identifier that plays two roles. One is that the file clearly distinguishes it from all other files. In this role it is Uniform Resource Identifier(URI), is a tekst that identifies the file. The second one indicates the location where the file can be found by the file system engine. In this role it is Uniform Resource Locator (URL). We also have other metadata such as date of creation, author, length, and many others.

An important feature of a file concept is that it contains content in addition to metadata. Metadata is, of course, a very important file part but the most important thing is the content it includes, which is data representing information to take part in processing.

Hopefully, everything we've talked about so far seems quite obvious, but since some file features are fundamental for further discussion, let's look at them in detail.

Let's start with the fact that typically we utilize object-oriented programming. This means that at runtime we must deal with objects that are located in the working memory (RAM) of a computer. Let me remind you that the RAM abbreviation stands for Random Access Memory. Here, random means that each word in memory has an address, i.e. a unique identifier, and this word can be independently read or written there. Let me stress we are talking about freedom but not probability. It means that again the RAM address play the role of URL. Therefore, object data can be organized into structures and linked by references.

On the other hand, we have the streaming world where the data is organized in the form of bitstreams, where each self-contained element of data has information about the next element but not a correlated element.

## Useful Technologies

### Introduction

To use computers for automation of information processing we have to manage bitstreams as the information representation. Bitstream management involves the organization, storage, retrieval, communication, and manipulation to ensure its accuracy, security, and accessibility. It encompasses data collection, storage architecture, integration, and maintenance to support efficient analysis and decision-making. To fulfill this functionality a set of technologies could make a real relief, namely presentation, validation, and standardization.

### Data Presentation

Data presentation is implemented by various ways of conveying information, including textual and tabular formats. Hence, first of all, we need to deal with data presentation, so as to enable the use of bitstreams also by a human computer user. In this context we must take into account the following terms: natural language, ergonomics, and graphical user interface.

A typical example that we can cite here is using the Internet. Using a web browser, a server-side application uses objects and then serializes the data that the user needs, sends it over the network, and then the browser displays it on the screen. And here it is important, that the browser always displays data in graphical form. This applies to all kinds of data used by humans, a person uses. The data, even when reading a newspaper, is always graphical data. Let me remind you that a letter is also a picture. This is one feature of data that is prepared for this. so that man can use them. The second feature is that this data must be written in a natural language that humans know. The concept of natural language is very broad. For example, XML text is said to be human-readable. But is this a piece of natural language?

From the above we can derive that the bitstream should be formatted in a way to resemble a natural language. Of course, we have no measure here and therefore it is difficult to say whether something is close enough to natural language to be comprehensible.

### Validation

Applications save working data into bitstreams (for example content of files) to keep state information, provide processing outcomes, or both. Applications need robust storage, i.e. correctness of the stored data has to be validated every time an application reads it back from a bitstream. It must be carefully observed if the bitstreams are also modified by other applications or directly by users, because data corruption may occur.

If we are talking about exchanging data between different applications or between an application and a human, the issue of data correctness arises. This issue should be considered on two independent levels. The first one is the correctness of a stream of signs, i.e. validation if the selected syntax rules are met. The second one is the possibility of assigning information to these correct sequences and therefore assigning meaning to bitstream. For humans to understand the stream, it will be accomplished by defining semantics rules, i.e. rules that will allow us to associate meaning with bitstream. The issue of ergonomics is also important in how easy it is to absorb information represented by the bitstream. Of course, the closer we are to natural language, the easier it will be, but again in this matter, we do not have measures that will allow us to determine how good our solution is.

To better understand above mentioned topics, let's look at them in the context of code examples explained in the section [XML-based Validation][xml-based-validation]. In this section, XML examples are only subject to more detailed examination but by design, it has no impact on the generality of the discussion.

### Standardization

When we talk about the syntax and semantics of a stream, the first thing to consider is the scope of data use. Well, data produced by one instance of a program can also be used by the same instance of the program. In such a case, if the process runs autonomously and is symmetric from a serialization and deserialization point of view, we should not expect any further problems.

If we are talking about communication between different remote applications, we must consider a scenario in which these applications are written in different programming languages. In this case, the problem arises of how to create types in other languages that will represent the same information. In the context of a text document, a schema may be used. The schema in this context refers to the structure or blueprint that defines the organization and format of the document. It outlines the arrangement of elements, their relationships, and any rules or constraints that govern the content of documents. Simplifying, schema allows the definition of additional syntax rules in a domain-specific language. Schemas help ensure consistency and coherence in the representation of information within the text document. It means that schema definition could also be a foundation of semantics rules used to assign meaning to the document text. As a result, we could recognize the schema as a good idea to validate text documents and check whether incoming text is a document we expect. Instead of using a schema to validate text-based bitstreams, we may use an equivalent set of classes.

Because the data may be used by different instances of a program, we also have to take into account that the programs may be in different versions or written using different languages. What worse, the data also must be subject of versioning. In such a case, there is a problem of data compatibility between independent instances of the program. So the question arises whether if the data serialized by one version of the program is used by another version of the program run as a different instance, will it allows the creation of a graph equivalent to the original graph

Another application of streams may be the use of them between various programs that are created in different technologies and implemented on different platforms. Then there is also the issue of technological compatibility. Also in this case, it must be taken into account that classes (types) that were created in one technology cannot necessarily be directly used in another technology. And in this case, we are already entering the issue of semantics, so we must take into account the fact that in another technology the same information will be represented in a different way.

If schema definition is expressed in a widely accepted format it should be possible to generate types in selected programming language based on this schema. Of course, it is a chicken and egg problem namely, should we first create types in the selected programming language, or should we create these types in the schema and then create classes based on the schema definition? But let's try to see how this can be achieved using an example.

## BitStream Format

### Domain Specific Language (DSL)

Using bitstreams (file content) we must face a problem with how to make bitstreams human readable. The first answer is that it must be compliant and coupled with a well-known application. The application opens this bitstream as input data and exposes it to the user employing appropriate means to make the data comprehensible.

Unfortunately, this approach does not apply to custom data. Therefore we should consider another approach, namely human-readable representation should be close to natural language. The first requirement for humans to understand the stream is that it has to be formatted as text. To recognize bitstream as the text an encoding must be associated by default, directly or indirectly. The next requirement, common for both humans and computers, is that a bitstream must be associated with comprehensible syntax rules. Finally, semantics rules should be associated with the bitstream that allows to assigning of meaning to bitstreams. Shortly there have to be defined a text-based language. A domain-specific language (DSL) is a text-based language dedicated to expressing concepts and data within a specific area. Except for programming languages like Java, C#, and Python, examples of well-known and widely accepted domain-specific languages are XML, JSON, and YAML formats to name only the most crucial.

Using DSL to describe the bitstreams a Data Transfer Object (DTO) concept can be used as a foundation to encapsulate and transport data between applications. It may be a text document that contains fields to store data.

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

## BitStream Cybersecurity

### TBD

## Serialization

### Fundamentals

We need bitstreams to be handled using files to make sure that the data can be persisted. Let's recall the most important applications, such as entering input data or storing output data using file systems. We also use various types of streaming devices to archive data, i.e. to save data forever. The temporary and intermediate data repository is another example.

Data transfer between applications is another use case. It requires that data must be transferable. For example interoperability of a web server and a web browser. There is a virtual wire between them.

These are just a few examples but let's limit the discussion to them because they are enough to justify the importance of this topic.

In the already mentioned use cases data must be in a form of bitstream. Now we are ready to return to discussing issues directly related to streaming data. Above, we discussed the mechanisms of managing streams, especially in the context of files. We also realized the differences between bitstreams, text, and documents. Now let's answer the question of how to create streaming data and how to use it. First, let's try to define the purpose of our missions and the limitations we must deal with.

Here the first problem arises: combining reasoning about two concepts, namely data formatted as objects with the bitstreams. We will call the transition from the object world to the streaming world serialization. Deserialization is the reverse process, which involves replacing the bitstream with interconnected objects located in the working memory of a computer.

Hence, to save/read working data from files we need generic operations that could automate this transition process regardless of the types we used to create the graph of objects containing working data. This process is called serialization. There must be also provided a reverse operation creating objects from a file content - deserialization. This operation additionally has to verify the file content.

Let me remind you that so far we have noted that in the transition between the object world and the world of bitstreams, we need serialization, which is responsible for transferring the state of an object graph to a bitstream. And deserialization, which is responsible for the reverse process, i.e. for transferring a bitstream into a graph of interconnected objects. We would like this operation to be implemented as generic, i.e. we would not have to program this operation every time, but only parameterize it.

Before we move to the next step, it is worth recognizing what we need in this context. Here, from the object point of view, the list of requirements includes:

- access to the data that will be the subject of the serialization
- values that will constitute the state of the objects
- the relationships between these objects

Next, we need to implement an algorithm that will describe in detail this data transformation, in such a way that this transformation is mutually unambiguous. Here, the mutual unambiguity of this process does not mean that each time we perform serialization we will obtain an identical bitstream. The same we should state for deserialization. We will get back to this issue shortly.

So the first problem we have is how to implement serialization and deserialization to make the transition between the object world and the streaming world possible. The serialization and deserialization process must be repeatable and mutually unambiguous. Moreover, it is not a simple process. Well, someone may say that this is a relative matter because we have no metrics of simplicity in this case. However cloning serialization and deserialization code snippets each time serialization is needed will consume and waste time, so it may be worth implementing this process as a generic library, without the need to create dedicated software each time. So the next problem we can define here is the possibility of transition between the streaming world and the object world using the library concept.

If we talk about repeatability by applying a library concept implementing serialization and deserialization functionalities, we need to offer a generic implementation. Namely, we must be able to define this process in advance, without prior knowledge of what will be serialized. Generic implementation of the serialization and deserialization functionality means that we have to implement it in advance and offer it as ready-to-use libraries. We have many libraries that permit this process to be carried out automatically. So the question is why do we need to learn about it? Why go into detail? Well, my point is that if someone wants to use a washing machine, let me refer to this example, they do not need to know how the controller, engine, or temperature sensor works. However, if someone wants to assemble a custom washing machine using available parts, knowledge or understanding of how the engine, controller, and temperature sensor work is essential in this case even if the mentioned parts are available. Similarly, we need detailed knowledge about serialization and deserialization in case we are going to use streaming data, for example, the file system.

In summary, to simultaneously use data as objects and bitstreams, our goal must be to combine two worlds. First, in which the data is in object form. The second world contain data in the form of bitstreams. Let me stress now that in both cases we have the same information but different representations. The data conversion between these worlds is serialization and deserialization. In the case of serialization, it is a process that involves converting the state of a graph of objects into a stream of bits. Deserialization is the reverse process, i.e. converting a bitstream into a graph of objects that must be created in memory. Here the magical statement about the condition of the object appeared; what does object state mean? We will know the answer to this question soon.

From the above, it could be derived that if an equivalent graph of objects can be reconstructed based on a bitstream it can be stated that the bitstream is correct for the purpose it has to serve. This reconstruction must be accomplished in compliance with the syntax, and semantics rules governing the bitstream. Again, this graph does not have to be identical to the original. It is enough for us that it is equivalent from the point of view of the information it represents. It could be added that in some cases, let's say in simpler cases, the bitstream identity can be ensured. This means that for a selected graph of objects, each time as a result of serialization we receive an identical bitstream. Then this bitstream can be compared, for example, to check whether the process is the same as before. It must be stressed that equivalence has no generic measure that can be used to evaluate equivalence condition. Due to the above, it is not possible to formally determine whether the resulting bit stream and the source object graph are equivalent. Therefore, equivalence must be decided by the software developer using custom measures, for example unit tests. From that, we can derive that only the software developer is responsible for ensuring that serialization and deserialization are mutually unambiguous.

Assuming that the data transformation algorithm has been implemented somehow, there is a need to determine the form of the target bitstream. So we need to determine how to combine bits into words, words into correct sequences of words, and how to assign meaning to these sequences of words. Shortly, alphabet, syntax, and semantics rules are required. For example, it could have an impact on the bitstream features, like the possibility of validating and visualizing content. Two additional notes regarding the target form of the bitstreams are vital for further consideration.

The list of applications that we mentioned previously as potential bitstream consumers includes the exchange of data between remote applications. It should be emphasized here that if these applications are created by different manufacturers, the standardization of this representation becomes extremely important. So, the fact that we combine words into correct sequences of words and give them meaning, that these syntax and semantics rules are standard in the sense that there are international documents that are published by organizations recognized as standardizing, that will allow us to recreate the graph of objects in an application that is created by another vendor.

We also said earlier that sometimes these bitstreams are also used to communicate with humans. Of course, standardization is also important for this kind of applications. A bitstream user must be able to read this sequence of bits, and therefore combine sequences of bits into words and words into correct sequences of words. Finally, these strings of words have to have meaning for him. First, it is important to be able to apply encoding to create letters so that the bitstream becomes a text. Let me remind you that the text is a bitstream for which an encoding is known or discovered.

From the previous considerations regarding the transformation of object data into streaming data, we know that the basis of this process is to determine the state of the object. Let me remind you that the state of an object is a set of values that must be subject to a transformation process so that the reverse operation can be performed in the future, i.e., so that the object graph can be recreated and an equivalent object graph can be created.

In order not to enter into purely theoretical considerations, let us return to these topics in the context of sample programs. The examples are described in the document titled [Implementation Examples][ie]. The example discussed shows the mechanism of transformation of an object or more precisely an object state to a bitstream. In this process, the state of the object is determined by a software developer, which implements an appropriate mechanism responsible for selecting the values that constitute the object state. Since the determination of an object state is a responsibility of program authors, there must be measures allowing to point out what has to be serialized.

> To learn more about the serialization visit the document: [Serialization in .NET][STLZTN].

### Implementation

#### Preface

To implement a serialization/deserialization engine, you need to define a data structure, choose a serialization format (like JSON, XML, etc.), and use a serialization library to convert the data wrapped by a graph of objects into the selected format in both directions. The data structure is required to determine the state of objects that are subject to serialization. Apart from the data structure a guidelines allowing to select only values constituting the state of the object are necessary. To implement the mentioned functionality access to the value holders that constitute the state of the object is also required. Attributes as a language construct at design-time and reflection as a technology at run-time could help to solve some problems related to serialization/deserialization implementation.

#### Attributes

Attribute or annotation is a concept used in various programming languages. It is used to add metadata, comments, and supplementary information to program text. It helps enhance code readability, and document functionality and provides details for tools or compilers. Many languages may implement attributes in their own way, but the fundamental idea of associating extra information with code entities is common across many programming languages - mainly the differences refer to syntax, hence the meaning expressed as the semantics rules are almost the same.

Apart from the definition of an attribute, it also must be possible to associate attributes with a selected language construct. This association usually is realized as a syntax constraint. For example, an attribute is added as a prefix or a decoration of a target construct.

So the question is what is an attribute? The general answer is that it is a language construct. A programming language construct refers to a syntactical element or feature within a programming language. The constructs provide the building blocks for implementing algorithms for various problems in software development.

To avoid meaningless explanations and get straight to the point, further explanations must be investigated in the context of program snippets prepared using the selected programming language that will be used to provide a comprehensive explanation of the syntax and semantics of the attribute definition and use. A description of the code snippets is available in the document [Implementation Examples][ie]. The examples show that attributes have broader applicability than just serialization and deserialization. However, the attribute concept is well suited to address selected issues related to the serialization/deserialization processes.

In the selected language any attribute definition is a class derived from the `System.Attribute` class. Hence, the programming language must also provide means to instantiate this class in the context of a selected construct to which additional data has been associated using attributes. By design, the reflection mechanisms must be used to instantiate attributes at run-time.

Depending on the development environment, attributes are crucial in controlling how objects are serialized and deserialized. They allow to provide instructions for the serialization process. The attributes help customize the serialization process to meet specific requirements. Often dedicated attributes are added to the serialization frameworks to allow the addition of expected by the specific implementation control information. Using this framework, the exposed attributes may be associated with custom definitions.

#### Reflection

Reflection is the next very useful approach that may be employed to support serialization and deserialization implementation. We can only touch on the subject of reflection, i.e. we just enter a world in which definitions in the source program become data and are processed like process data. In other words, reflection in software engineering refers to the ability of a program to examine and modify its structure and behavior during runtime. Due to the complexity of this topic, we have to limit the discussion to only selected topics useful in the context of serialization. Hence, don't expect deep knowledge related to this topic. Reflection is commonly used for tasks like recovery metadata about types, classes instantiation, method invocation, and recovering data wrapped by objects at run-time.

So, our task is to answer the question of how to make it autonomous and automate this serialization and deserialization process. Because we have to do it in a way that allows us to avoid repetitive work. It means the mentioned functionality must be implemented in advance when we do not know the types yet. We want to offer a generic library that will be used against various types, i.e. against custom types that the user will define according to requirements of the application in concern. The only thing we can rely on and reuse is the built-in types of a selected programming language because they are immutable.

If we need to deal with custom types, which we do not know in advance typically the following solutions may be applied. First is dynamic programming when types are created during program execution and will reflect the needs related to the data processing algorithm at run-time. The next one is the independent conversion of member values based on built-in custom functionality in new types defined at compile time. Finally, we may consider applying reflection, where type definitions created at compile time become data for the program that can be the subject of recovery metadata and reading/assigning objects state values at run-time.

Dynamic programming is not promising and should be avoided because it is an error-prone run-time approach. Independent conversion is a design-time approach and must be considered as a serialization/deserialization method. However, it still needs custom serialization/deserialization functionality to be embedded in new type definitions, and therefore cannot be recognized as an autonomous solution. More in this respect you can get by checking out appropriate examples described in the document [Implementation Examples][ie]. Reflection allows to write the program so that the type features are recoverable and become data for the program. Reflection allows for avoiding custom implementation of the serialization and deserialization functionality. Hence, it will be described in more detail.

The language we have selected is based on the concept of types. It is strongly typed. However, it is not the only one that uses type compatibility to check the correctness of the program at design time. However, the transition from the object-oriented world to the streaming world requires generic actions, consisting of creating generalized mechanisms for operating on data without referring to concrete type definitions. I mean the serialization/deserialization functionality must be generic without referring to type definitions, because the types may be unknown at this time.

We want the data transformation process between object graphs and bitstreams process to be mutually unambiguous, repeatable, and autonomous. Data transformation from graph of objects form to stream form requires reading the state of these objects and the relationships between them. The reverse transformation, i.e. converting a bitstream into an object graph, requires the installation of appropriate types contributing to the graph and populating them with recovered values obtained during deserialization from the bitstream.

The state of an object is the minimum set of values that is necessary to recreate an equivalent object. In the case of conversion from a stream to an object form, first of all, we must be able to create objects by instantiating types. If the types are instantiated, the values that have been saved as the object's state must be assigned to the internal members that are part of this object against its type. This also applies to those value holders that store information about relationships between objects, i.e. references.

### Access to Object State Values

#### Introduction

From the previous considerations, we know that serialization/deserialization is a data transformation process from/to an object from/to a bitstream form. These operations should be implemented as generic ones. It means that they don't depend on the type of the serialized/deserialized object because they should be offered as a generic library solution to allow multi-time usage against custom types. This process must start with recovering a set of value-holder members constituting the state of an object. Let me stress that to provide a generic solution this mechanism must not depend on the object type.

Talking about serialization/deserialization we must answer the question of how to build universal and stand-alone libraries that will allow you to transfer data wrapped by an object to a stream and recover it from a stream to populate instantiated types. To accomplish this we can apply the following approaches:

- **Self Controlled** values access mechanism
- **Attributes + reflection** values access mechanism

#### Self Controlled

The first approach, compliant with the above scenario, is to implement access to object state values internally by a custom type. An example of this approach is described in the document [Implementation Examples][ie]. It is based on internal reading and assigning operations of the values creating the object's state in compliance with the object type definition. This way, it is possible to avoid the need for employing reflection.  Instead, the `ISerializable` interface has to be implemented. This interface acts as a contract between the target but custom class to be serialized and the class that implements the serialization algorithm and by design, implements this algorithm without detailed knowledge about the target type. Only this interface is in common. We must be aware that the proposed solution is not perfect. There are still many issues that have been left unsaid. So let's start by systematizing the shortcomings of this proposal.

The first issue that we must address is the full autonomy of the serialization and deserialization process. In this approach, we must manually ensure that the appropriate values constituting the state of the target object are saved in the dedicated array, which is passed on to be written to the bitstream. It means that partially this functionality must be implemented by the custom type in compliance with the `ISerializable` interface instead of being provided by a generic library.

The second issue related to the self-controlled approach to access values constituting the state of an object is the necessity of harmonization of the custom operations carried out during the serialization with the operations carried out during deserialization. From the mentioned examples we learn that two separate pieces of custom code are responsible for this, and therefore any modification in one piece must be mirrored in the other piece. This can lead to errors if this is not the case.

#### Attributes and Reflection

Using self-controlled management of the object state means splitting the functionality between the type to be subject to serialization/deserialization and library functionality, which serializes/deserializes the value of members independently. This solution requires that the type to be serialized must be prepared to read/write values from the members and create a table against an interface that is a contract between both parties responsible for implementing commonly the serialization/deserialization functionality. The main problem is that the type to be subject to serialization/deserialization must be prepared against the contract defined by the implemented interface.

Instead of using a self-controlled data access approach, the reflection may be employed to read and write values contributing to the object state. This way there is no custom code related to selecting, reading, and writing state values. To select only necessary values the following convention may be applied. It says that the state of the object is constituted by all the values that can be obtained by reading the public properties that have both getter and setter. So from this, you can both read the current value and assign new ones. If this convention applies to the target object and all indirectly referenced ones we can state that the graph of objects is ready for serialization and deserialization using reflection. What is very important is to ensure symmetry between serialization and deserialization. This means that using reflection there is no need to add any dedicated functionality to the target class related to serialization and deserialization.

The rule that in the output stream all the values must be saved, which can read from public properties, and which have both getter and setter cannot be used uncritically. We also need to consider the case when such properties exist, but for some reason, we do not want to save their values in the output stream - they don't constitute the object state. The solution to this problem can be based on our knowledge of attributes. In practice, it means that properties of this kind are preceded by a selected attribute. For example, it may be `XMLIgnore`, which will indicate that you must use all public properties that have a getter and setter, except those preceded by the indicated attribute. The question is whether in this solution we ensured the symmetry of the serialization and deserialization operations. The answer is yes because both reading data and writing data functionality are side by side in the same place, by using the same property.

Summarizing, from the above, we may learn how to use attributes and reflection to ensure full autonomy of the serialization process and harmonize the behavior of converting objects to a stream and stream to objects. Autonomy in this context means that the reflection is employed to implement a library and as a result, the conversion process can be performed without dedicated custom code embedded in the type of objects to be serialized and deserialized.

Examples illustrating serialization using reflection and attributed programming are described in the section [Implementation Examples][ie].

### Graph of Objects Serialization

Let's move on to the last issue related to the serialization of objects interconnected to each other forming graphs. So the objects have references between them and these references will determine the structure of the graph of objects. In this case, the main challenge is that all the objects must be considered as one whole.

Generally, we can distinguish two types of these structures. The first one is created using hierarchical interconnections, which resembles a tree. In this case, starting from any point of such a structure and following the directional references we will never return to the starting point. Thanks to this feature, in mathematics this kind of graph is called acyclic. In the case when graphs are cyclic, then there are points in the graph that when we start from these points and follow the references, it is possible to return to the starting points. So such graphs have loops. Since graph serialization requires an iterative approach, it requires that we iteratively traverse a tree of objects, provided that it is a tree. If there are cyclic connections causing loops in the graph of objects, then there will be a problem with stopping the iteration and avoiding double serialization (cloning) of the same object.

If a graph of objects is created as interconnected objects in such a way that they create a tree, or at least a layered model. Assuming unidirectional interconnections between the objects, we can distinguish objects that are at the top of a hierarchy and objects that are beneath. Therefore, data transformation operations may be performed starting from those objects that are at the top and ending with those objects that are at the bottom of the hierarchy of references between objects.

Unfortunately, often happens that we must deal with more demanding structures, where these references create cycles. For example, in this example (fig. below), classes refer to each other creating a cycle.

![Fig. 1](.Media/Part3-N80-10-Diagram.png)

Assuming that instances of all classes are created (fig. below), the question arises which of the objects should be subject to the serialization process first. Therefore, in this case, we must not insist that the hierarchy between objects is dependent on the order of representation in the stream. Hence, here we must introduce the following term: equivalence of streams. If a stream contains a representation of all information including references, the order in which the data associated with each instance is placed in the stream is not relevant, provided that each object is serialized only once. Due to the above, it has to be considered that several different bitstreams contain equivalent states of individual objects and these object states will be placed in different orders but all of them are equivalent to each other. It means that on their basis it will be possible to reconstruct an equivalent graph of objects. Creating equivalent streams does not mean that they have to be identical and therefore, for example, they can be directly compared with each other.

![Fig. 1](.Media/Part3-N80-20-Rekurencja.png)

Another issue that should be addressed here is when the serialization process should be ended. For example, if we start with an instance of one class, let's say `ServiceA` (fig. above), next proceed to serialize the instance of the `ServiceB` class and consequently proceed to an instance of the `ServiceC` class, we must have an iteration stop condition to avoid cloning of the instance `ServiceA` because it has been already serialized, i.e. the transformation process has been performed for it. For the more complex graphs, it could be not so easy.

In case of cyclic graphs, there is no restriction on the number of paths between any pair of vertices, and cycles may be present. We may encounter two problems here. Firstly, we have to resolve many-to-one references in this type of graph, when many objects will have references to one object. As a result, we can expect that serializing such a structure may cause cloning of objects in the stream. During recovery, if all these objects are recreated, many redundant copies are instantiated, so the structure will be different comparing it with the original. In the case of cyclic graphs (contain cycles - closed loops) in the relationship structure, we must take into account the fact that the serialization mechanism (the graph-to-bitstream conversion mechanism) will have to deal with this problem and therefore will have to set a stop condition to avoid cloning objects in the output stream. Well, we have two options to solve this issue. The first option is to write a custom library but this is a complex process. The second approach to address this problem is to choose an appropriate but existing library. There are many such libraries on the market and when analyzing their applicability, you should pay attention to these issues.

### Conclusion

So much theory. It's time to move on to practical acquaintance with selected reflection mechanisms. To get more based on examples in selected programming language check out the document [Implementation Examples][ie]. These examples show how to represent type features as the [Type][system.type] class instances. The instances can be created using the `typeof` keyword based on the type definition or the `GetType` instance method for objects of unknown type. In both cases, an object-oriented type description is created. The examples discussed show how to use this description to read and write the values of a selected property. This ability is especially useful when implementing serialization and deserialization operations. Similarly, we can also read and write values from fields and call instance methods. Similarly, it is also possible to create new objects without referring to the `new` keyword. Discussing all the details of the reflection concept is far beyond the scope of the examples collected here. We also talked about bitstream syntax and semantics using the example of XML files. We showed how to use the XML schema concept to describe details of the syntax and also the semantics of a document indirectly and to create the source code of a program that will be used in the serialization and deserialization process.

## See Also

- [XSL\(T\) Languages][XSLW3C]
- [Serialization in .NET][STLZTN]
- [XML Schema Definition Tool (Xsd.exe)][XSD]
- [Type Class][system.type]
- [Implementation Examples][ie]
- [ISO/IEC 21778; International Standard; Information technology — The JSON data interchange syntax][ISOJSON]
- [The JavaScript Object Notation (JSON) Data Interchange Format][RFCJSON]; Request for Comments:7159; 2020-01-21
- [JSON Schema][CommunityJSON]

[CommunityJSON]: https://json-schema.org/specification#specification
[ISOJSON]: https://www.iso.org/standard/71616.html
[RFCJSON]: https://datatracker.ietf.org/doc/rfc7159
[ie]: .\DataStreams\README.md
[xmlpresentation]: .\DataStreams\README.md#xml-based-presentation

[XSLW3C]: https://www.w3schools.com/xml/xsl_languages.asp
[XSD]: http://msdn.microsoft.com/library/x6c1kb0s.aspx
[STLZTN]: http://msdn.microsoft.com/library/7ay27kt9.aspx
[system.type]: https://learn.microsoft.com/dotnet/api/system.type
[xml-based-validation]: ./DataStreams/README.md#xml-based-validation
