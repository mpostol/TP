# Presenting working data outside the application

# Key words

File System, User Interface, XML, XSLT, HTML, XmlSerializer, Save file, Transformation, Saving text files, Local File Systems, Open and read file, XML Schema, Common File Format, Data Access, XML Serialization, XSL, Data Validation, XML Documentation, 

# Executive summary

This sample demonstrates how to save working data in a file containing xml document, which next can be directly presented for example in MS Word editor or Internet Explorer translated using a style sheet. It is simplest way to detach the document content from its presentation.

# Scenario

Applications save working data into the files to keep state information, to provide processing outcome or both. Applications need robust storage, i.e. correctness of the stored data has to be validated every time an application reads it back from the file. It must be carefully observed if the files are also modified by other applications or directly by users, because data corruption may occur. To address the validation requirement XML (Extensible Markup Language) as a text-based format for representing structured information and XML Schema as a language for expressing constraints about XML documents are very good candidates to be used by the save operation.

As the XML format is text based it can be directly read and displayed by the software user. However, it is not preferred format, because it does not contain any formatting information. Today we expect data presentation to meet user experience, i.e. to have appropriate layout and style. We can meet this requirement using any application that supports XSLT transformation of XML documents into other text documents or HTML documents. XSLT uses a template-driven approach to transformations: you write a template that shows what happens to any given input element. For example, if you were formatting a working data to produce HTML for the Web, you might have a template (*stylesheet file*) to match an underlined group of elements and make it come out as a table.

To get more about how to start with XSLT visit the W3C School:

[XSL\(T\) Languages](https://www.w3schools.com/xml/xsl_languages.asp)

Today applications use objects to process working data according to the Object Oriented Programming (OOP) paradigm. To save/read working data from XML files we need generic operations that could automate this process regardless of types we used to create the object containing working data. This process is called serialization. There must be also provided reverse operation creating objects from the XML content-deserialization. This operation additionally has to verify the content against the XML schema. Instead of XML schema to validate the XML file validation we can use equivalent set of classes.

To learn more about the serialization visit the MSDN:

[Serialization in .NET](http://msdn.microsoft.com/en-us/library/7ay27kt9.aspx)

You may use the XML Schema Definition [Xsd.exe](http://msdn.microsoft.com/en-us/library/x6c1kb0s(v=vs.110).aspx) tool, which generates XML schema or common language run-time classes from XDR, XML, and XSD files, or from classes in a run-time assembly.

# Solution

This example is dedicated to demonstrate how to deal with the presented above scenario. It defines a few helper functions, for serialization and deserialization located in the static class:

`Example.Xml.DocumentsFactory.XmlFile`

The `Example.Xml.CustomData` namespace contains classes that represent XML schema and are used by the program as an object model of the working data.

After implementation of the `Example.Xml.DocumentsFactory.IStylesheetNameProvider` by the root class of the object model we can convey information about default stylesheet that may be used to transform resultant XML file. Information about the stylesheet (xslt file) is added to the XML document and can be used by the application to open the file and translate the content.

An example of xslt file has been added to the CustomData and is copied during project build to destination folder. In the same folder an example of XML file (named Catalog.xml ) is created. You can open it using IE or MS Word using the instruction below.

Program class demonstrates how to use read/write operation.


