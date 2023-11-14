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

After double-clicking on the selected file an image will appear. Here we may ask a question - what happened? Well, a program was launched. This program must have been written by some programmer. The program did open this file as input, so the programmer had to know the syntax and semantics that were used in this file. The data contained in the file made it possible to visualize them graphically. This is the first example of graphical representation, but we will return to this issue soon.

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
