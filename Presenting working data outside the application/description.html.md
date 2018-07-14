# Presenting working data outside the application

<br>
Technologies C#, File System, .NET, Class Library, User Interface, XML, XSLT, .NET 3.0, Microsoft Office Word 2007, Microsoft Office Word, Word, Library, Microsoft Office Word 2010, C# Language, HTML, XmlSerializer, Word 2010, .NET Framework 4.5, C# 3.0, Save file, Microsoft .NET Framework 3.5 SP1, Visual C Sharp .NET, Word 2013, Transformation, Microsoft Office Word 2013, .NET Development, Saving text files, Local File Systems, Open and read file, XML Schema, Common File Format
Topics C#, File System, Serialization, XML, Data Access, XML Serialization, content serialization, File mapping, Data, XSL, client side object model, XmlSerializer, XSLT transformation, Data Validation, XML Documentation, Generic C# resuable code, file, File Systems, Files, C# Language Features, Save file, modeling, data and storage
Platforms Desktop, Data
Requirements Primary language en-US Updated 2/20/2014 License [MS-LPL](license.rtf) [View this sample online](http://code.msdn.microsoft.com/Presenting-working-data-2760d1c6)

#Executive summary

This sample demonstrates how to save working data in a file containing xml document, which next can be directly presented for example in MS Word editor or Internet Explorer translated using a style sheet. It is simplest way to detach the document content
 from its presentation.

# Scenario

Applications save working data into the files to keep state information, to provide processing outcome or both. Applications need robust storage, i.e. correctness of the stored data has to be validated every time an application reads it back from the file.
 It must be carefully observed if the files are also modified by other applications or directly by users, because data corruption may occur. To address the validation requirement XML (Extensible Markup Language) as a text-based format for representing structured
 information and XML Schema as a language for expressing constraints about XML documents are very good candidates to be used by the save operation.

As the XML format is text based it can be directly read and displayed by the software user. However, it is not preferred format, because it does not contain any formatting information. Today we expect data presentation to meet user experience, i.e. to have
 appropriate layout and style. We can meet this requirement using any application that supports XSLT transformation of XML documents into other text documents or HTML documents. XSLT uses a template-driven approach to transformations: you write a template that
 shows what happens to any given input element. For example, if you were formatting a working data to produce HTML for the Web, you might have a template (stylesheet file) to match an underlined group of elements and make it come out as a table.

To get more about how to start with XSLT visit the W3C School:

[http://www.w3schools.com/xsl/xsl_languages.asp](http://www.w3schools.com/xsl/xsl_languages.asp)

Today applications use objects to process working data according to the Object Oriented Programming (OOP) paradigm. To save/read working data from XML files we need generic operations that could automate this process regardless of types we used to create
 the object containing working data. This process is called serialization. There must be also provided reverse operation creating objects from the XML content-deserialization. This operation additionally has to verify the content against the XML schema. Instead
 of XML schema to validate the XML file validation we can use equivalent set of classes.

To learn more about the serialization visit the MSDN:

[http://msdn.microsoft.com/en-us/library/7ay27kt9(v=vs.110).aspx](http://msdn.microsoft.com/en-us/library/7ay27kt9(v=vs.110).aspx)

You may use the XML Schema Definition ([Xsd.exe](http://msdn.microsoft.com/en-us/library/x6c1kb0s(v=vs.110).aspx)) tool, which generates XML schema or common language runtime classes from XDR, XML, and XSD files, or from classes in a runtime assembly.

# Solution

This example is dedicated to demonstrate how to deal with the presented above scenario. It defines a few helper functions, for serialization and deserialization located in the static class:

Example.Xml.DocumentsFactory.XmlFile

The Example.Xml.CustomData namespace contains classes that represent XML schema and are used by the program as an object model of the working data.

After implementation of the Example.Xml.DocumentsFactory.IStylesheetNameProvider by the root class of the object model we can convey information about default stylesheet that may be used to transform resultant XML file. Information about the stylesheet (xslt
 file) is added to the XML document and can be used by the application to open the file and translate the content.

An example of xslt file has been added to the CustomData and is copied during project build to destination folder. In the same folder an example of XML file (named Catalog.xml ) is created. You can open it using IE or MS Word using the instruction below.

Program class demonstrates how to use read/write operation.

# How to use the example

This code is stand alone sample. Main goal of this example is to present how easy it is to create documents contained processed data using XML technology and detach presentation and data model development. This sample is provided so that you can incorporate
 it directly in your code. It consists of a standalone command line application project created in Microsoft Visual Studio 2012.

To open a solution:

1. Start Microsoft Visual Studio 2012.
2. On the File menu, click Open, and then click Project/Solution.
3. Navigate to the folder containing the .sln file, select it, and then click Open.

To run a solution:

1. In the solution files, read and follow the comments that describe how to set up your environment if necessary.
2. On the Build menu, click Build Solution.
3. using explorer navigate to the target folder and open the created document in MS Word – use "open using" right click menu entry.
4. Select the catalog.xslt in the XML data view pane. Tip: if the .xml and .xslt files are not in the same place use Brose ... button to navigate and select your stylesheet file.

Example.Xml.DocumentsFactory.XmlFile
