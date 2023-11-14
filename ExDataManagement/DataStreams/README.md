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

To save/read working data from files we need generic operations that could automate this process regardless of the types we used to create the object containing working data. This process is called serialization. There must be also provided reverse operation creating objects from a file  content -  deserialization. This operation additionally has to verify the file.

> To learn more about the serialization visit the MSDN: [Serialization in .NET][STLZTN].

## Useful Technologies

### Validation

Applications save working data into the files to keep state information, provide processing outcomes, or both. Applications need robust storage, i.e. **correctness** of the stored data has to be validated every time an application reads it back from the file. It must be carefully observed if the files are also modified by other applications or directly by users, because data corruption may occur.

To address the validation requirement XML (Extensible Markup Language) as a text-based format for representing structured information and XML Schema as a language for expressing constraints about XML documents are very good candidates to be used by the file operation. Today applications use objects to process working data according to the Object Oriented Programming (OOP) paradigm. Therefore, instead of XML schema to validate XML files, we may use an equivalent set of classes.

You may use the [XML Schema Definition Tool (Xsd.exe)][XSD], which generates XML schema or language classes from XDR, XML, and XSD files, or from classes in a run-time assembly.

### Visualization

As the XML format is text-based it can be directly read and displayed by a variety of software tools. However, it is not the preferred format, because it does not contain any formatting information. Today we expect data presentation to meet user experience, i.e. to have an appropriate layout and style. We can meet this requirement using any application that supports XSLT transformation of XML documents into other text documents, including but not limited to equivalent HTML documents. XSLT uses a template-driven approach to transformations: you write a template that shows what happens to any given input element. For example, if you were formatting working data to produce HTML for the Web, you might have a template (**stylesheet file**) to match an underlined group of elements and make it come out as a table.

> To get more about how to start with XSLT visit the W3C School: [XSL\(T\) Languages][XSLW3C].

### Reflection

#### Attributes

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
