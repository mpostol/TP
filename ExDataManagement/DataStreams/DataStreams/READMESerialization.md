# Objects Serialization <!-- omit in toc -->

## Table of Content <!-- omit in toc -->

- [1. Attributes](#1-attributes)
- [2. Reflection](#2-reflection)
- [3. Access to Object State Values](#3-access-to-object-state-values)
  - [3.1. Introduction](#31-introduction)
  - [3.2. Self Controlled](#32-self-controlled)
  - [3.3. Attributes and Reflection](#33-attributes-and-reflection)
- [4. Graph of Objects Serialization](#4-graph-of-objects-serialization)
- [5. Conclusion](#5-conclusion)
- [6. To Be Merged](#6-to-be-merged)
  - [7. Reflection-Based Serialization Example](#7-reflection-based-serialization-example)
  - [8. SerializationUnitTest](#8-serializationunittest)

## 1. Attributes

Attribute or annotation is a concept used in various programming languages. It is used to add metadata, comments, and supplementary information to program text. It helps enhance code readability, and document functionality and provides details for tools or compilers. Many languages may implement attributes in their own way, but the fundamental idea of associating extra information with code entities is common across many programming languages - mainly the differences refer to syntax, hence the meaning expressed as the semantics rules are almost the same.

Apart from the definition of an attribute, it also must be possible to associate attributes with a selected language construct. This association usually is realized as a syntax constraint. For example, an attribute is added as a prefix or a decoration of a target construct.

So the question is what is an attribute? The general answer is that it is a language construct. A programming language construct refers to a syntactical element or feature within a programming language. The constructs provide the building blocks for implementing algorithms for various problems in software development.

To avoid meaningless explanations and get straight to the point, further explanations must be investigated in the context of program snippets prepared using the selected programming language that will be used to provide a comprehensive explanation of the syntax and semantics of the attribute definition and use. A description of the code snippets is available in the document [Implementation Examples][ie]. The examples show that attributes have broader applicability than just serialization and deserialization. However, the attribute concept is well suited to address selected issues related to the serialization/deserialization processes.

In the selected language any attribute definition is a class derived from the `System.Attribute` class. Hence, the programming language must also provide means to instantiate this class in the context of a selected construct to which additional data has been associated using attributes. By design, the reflection mechanisms must be used to instantiate attributes at run-time.

Depending on the development environment, attributes are crucial in controlling how objects are serialized and deserialized. They allow to provide instructions for the serialization process. The attributes help customize the serialization process to meet specific requirements. Often dedicated attributes are added to the serialization frameworks to allow the addition of expected by the specific implementation control information. Using this framework, the exposed attributes may be associated with custom definitions.

## 2. Reflection

Reflection is the next very useful approach that may be employed to support serialization and deserialization implementation. We can only touch on the subject of reflection, i.e. we just enter a world in which definitions in the source program become data and are processed like process data. In other words, reflection in software engineering refers to the ability of a program to examine and modify its structure and behavior during runtime. Due to the complexity of this topic, we have to limit the discussion to only selected topics useful in the context of serialization. Hence, don't expect deep knowledge related to this topic. Reflection is commonly used for tasks like recovery metadata about types, classes instantiation, method invocation, and recovering data wrapped by objects at run-time.

So, our task is to answer the question of how to make it autonomous and automate this serialization and deserialization process. Because we have to do it in a way that allows us to avoid repetitive work. It means the mentioned functionality must be implemented in advance when we do not know the types yet. We want to offer a generic library that will be used against various types, i.e. against custom types that the user will define according to requirements of the application in concern. The only thing we can rely on and reuse is the built-in types of a selected programming language because they are immutable.

If we need to deal with custom types, which we do not know in advance typically the following solutions may be applied. First is dynamic programming when types are created during program execution and will reflect the needs related to the data processing algorithm at run-time. The next one is the independent conversion of member values based on built-in custom functionality in new types defined at compile time. Finally, we may consider applying reflection, where type definitions created at compile time become data for the program that can be the subject of recovery metadata and reading/assigning objects state values at run-time.

Dynamic programming is not promising and should be avoided because it is an error-prone run-time approach. Independent conversion is a design-time approach and must be considered as a serialization/deserialization method. However, it still needs custom serialization/deserialization functionality to be embedded in new type definitions, and therefore cannot be recognized as an autonomous solution. More in this respect you can get by checking out appropriate examples described in the document [Implementation Examples][ie]. Reflection allows to write the program so that the type features are recoverable and become data for the program. Reflection allows for avoiding custom implementation of the serialization and deserialization functionality. Hence, it will be described in more detail.

The language we have selected is based on the concept of types. It is strongly typed. However, it is not the only one that uses type compatibility to check the correctness of the program at design time. However, the transition from the object-oriented world to the streaming world requires generic actions, consisting of creating generalized mechanisms for operating on data without referring to concrete type definitions. I mean the serialization/deserialization functionality must be generic without referring to type definitions, because the types may be unknown at this time.

We want the data transformation process between object graphs and bitstreams process to be mutually unambiguous, repeatable, and autonomous. Data transformation from graph of objects form to stream form requires reading the state of these objects and the relationships between them. The reverse transformation, i.e. converting a bitstream into an object graph, requires the installation of appropriate types contributing to the graph and populating them with recovered values obtained during deserialization from the bitstream.

The state of an object is the minimum set of values that is necessary to recreate an equivalent object. In the case of conversion from a stream to an object form, first of all, we must be able to create objects by instantiating types. If the types are instantiated, the values that have been saved as the object's state must be assigned to the internal members that are part of this object against its type. This also applies to those value holders that store information about relationships between objects, i.e. references.

## 3. Access to Object State Values

### 3.1. Introduction

From the previous considerations, we know that serialization/deserialization is a data transformation process from/to an object from/to a bitstream form. These operations should be implemented as generic ones. It means that they don't depend on the type of the serialized/deserialized object because they should be offered as a generic library solution to allow multi-time usage against custom types. This process must start with recovering a set of value-holder members constituting the state of an object. Let me stress that to provide a generic solution this mechanism must not depend on the object type.

Talking about serialization/deserialization we must answer the question of how to build universal and stand-alone libraries that will allow you to transfer data wrapped by an object to a stream and recover it from a stream to populate instantiated types. To accomplish this we can apply the following approaches:

- **Self Controlled** values access mechanism
- **Attributes + reflection** values access mechanism

### 3.2. Self Controlled

The first approach, compliant with the above scenario, is to implement access to object state values internally by a custom type. An example of this approach is described in the document [Implementation Examples][ie]. It is based on internal reading and assigning operations of the values creating the object's state in compliance with the object type definition. This way, it is possible to avoid the need for employing reflection.  Instead, the `ISerializable` interface has to be implemented. This interface acts as a contract between the target but custom class to be serialized and the class that implements the serialization algorithm and by design, implements this algorithm without detailed knowledge about the target type. Only this interface is in common. We must be aware that the proposed solution is not perfect. There are still many issues that have been left unsaid. So let's start by systematizing the shortcomings of this proposal.

The first issue that we must address is the full autonomy of the serialization and deserialization process. In this approach, we must manually ensure that the appropriate values constituting the state of the target object are saved in the dedicated array, which is passed on to be written to the bitstream. It means that partially this functionality must be implemented by the custom type in compliance with the `ISerializable` interface instead of being provided by a generic library.

The second issue related to the self-controlled approach to access values constituting the state of an object is the necessity of harmonization of the custom operations carried out during the serialization with the operations carried out during deserialization. From the mentioned examples we learn that two separate pieces of custom code are responsible for this, and therefore any modification in one piece must be mirrored in the other piece. This can lead to errors if this is not the case.

### 3.3. Attributes and Reflection

Using self-controlled management of the object state means splitting the functionality between the type to be subject to serialization/deserialization and library functionality, which serializes/deserializes the value of members independently. This solution requires that the type to be serialized must be prepared to read/write values from the members and create a table against an interface that is a contract between both parties responsible for implementing commonly the serialization/deserialization functionality. The main problem is that the type to be subject to serialization/deserialization must be prepared against the contract defined by the implemented interface.

Instead of using a self-controlled data access approach, the reflection may be employed to read and write values contributing to the object state. This way there is no custom code related to selecting, reading, and writing state values. To select only necessary values the following convention may be applied. It says that the state of the object is constituted by all the values that can be obtained by reading the public properties that have both getter and setter. So from this, you can both read the current value and assign new ones. If this convention applies to the target object and all indirectly referenced ones we can state that the graph of objects is ready for serialization and deserialization using reflection. What is very important is to ensure symmetry between serialization and deserialization. This means that using reflection there is no need to add any dedicated functionality to the target class related to serialization and deserialization.

The rule that in the output stream all the values must be saved, which can read from public properties, and which have both getter and setter cannot be used uncritically. We also need to consider the case when such properties exist, but for some reason, we do not want to save their values in the output stream - they don't constitute the object state. The solution to this problem can be based on our knowledge of attributes. In practice, it means that properties of this kind are preceded by a selected attribute. For example, it may be `XMLIgnore`, which will indicate that you must use all public properties that have a getter and setter, except those preceded by the indicated attribute. The question is whether in this solution we ensured the symmetry of the serialization and deserialization operations. The answer is yes because both reading data and writing data functionality are side by side in the same place, by using the same property.

Summarizing, from the above, we may learn how to use attributes and reflection to ensure full autonomy of the serialization process and harmonize the behavior of converting objects to a stream and stream to objects. Autonomy in this context means that the reflection is employed to implement a library and as a result, the conversion process can be performed without dedicated custom code embedded in the type of objects to be serialized and deserialized.

Examples illustrating serialization using reflection and attributed programming are described in the section [Implementation Examples][ie].

## 4. Graph of Objects Serialization

Let's move on to the last issue related to the serialization of objects interconnected to each other forming graphs. So the objects have references between them and these references will determine the structure of the graph of objects. In this case, the main challenge is that all the objects must be considered as one whole.

Generally, we can distinguish two types of these structures. The first one is created using hierarchical interconnections, which resembles a tree. In this case, starting from any point of such a structure and following the directional references we will never return to the starting point. Thanks to this feature, in mathematics this kind of graph is called acyclic. In the case when graphs are cyclic, then there are points in the graph that when we start from these points and follow the references, it is possible to return to the starting points. So such graphs have loops. Since graph serialization requires an iterative approach, it requires that we iteratively traverse a tree of objects, provided that it is a tree. If there are cyclic connections causing loops in the graph of objects, then there will be a problem with stopping the iteration and avoiding double serialization (cloning) of the same object.

If a graph of objects is created as interconnected objects in such a way that they create a tree, or at least a layered model. Assuming unidirectional interconnections between the objects, we can distinguish objects that are at the top of a hierarchy and objects that are beneath. Therefore, data transformation operations may be performed starting from those objects that are at the top and ending with those objects that are at the bottom of the hierarchy of references between objects.

Unfortunately, often happens that we must deal with more demanding structures, where these references create cycles. For example, in this example (fig. below), classes refer to each other creating a cycle.

![Fig. 1](../.Media/Part3-N80-10-Diagram.png)

Assuming that instances of all classes are created (fig. below), the question arises which of the objects should be subject to the serialization process first. Therefore, in this case, we must not insist that the hierarchy between objects is dependent on the order of representation in the stream. Hence, here we must introduce the following term: equivalence of streams. If a stream contains a representation of all information including references, the order in which the data associated with each instance is placed in the stream is not relevant, provided that each object is serialized only once. Due to the above, it has to be considered that several different bitstreams contain equivalent states of individual objects and these object states will be placed in different orders but all of them are equivalent to each other. It means that on their basis it will be possible to reconstruct an equivalent graph of objects. Creating equivalent streams does not mean that they have to be identical and therefore, for example, they can be directly compared with each other.

![Fig. 2](../.Media/Part3-N80-20-Rekurencja.png)

Another issue that should be addressed here is when the serialization process should be ended. For example, if we start with an instance of one class, let's say `ServiceA` (fig. above), next proceed to serialize the instance of the `ServiceB` class and consequently proceed to an instance of the `ServiceC` class, we must have an iteration stop condition to avoid cloning of the instance `ServiceA` because it has been already serialized, i.e. the transformation process has been performed for it. For the more complex graphs, it could be not so easy.

In case of cyclic graphs, there is no restriction on the number of paths between any pair of vertices, and cycles may be present. We may encounter two problems here. Firstly, we have to resolve many-to-one references in this type of graph, when many objects will have references to one object. As a result, we can expect that serializing such a structure may cause cloning of objects in the stream. During recovery, if all these objects are recreated, many redundant copies are instantiated, so the structure will be different comparing it with the original. In the case of cyclic graphs (contain cycles - closed loops) in the relationship structure, we must take into account the fact that the serialization mechanism (the graph-to-bitstream conversion mechanism) will have to deal with this problem and therefore will have to set a stop condition to avoid cloning objects in the output stream. Well, we have two options to solve this issue. The first option is to write a custom library but this is a complex process. The second approach to address this problem is to choose an appropriate but existing library. There are many such libraries on the market and when analyzing their applicability, you should pay attention to these issues.

## 5. Conclusion

So much theory. It's time to move on to practical acquaintance with selected reflection mechanisms. To get more based on examples in selected programming language check out the document [Implementation Examples][ie]. These examples show how to represent type features as the [Type][system.type] class instances. The instances can be created using the `typeof` keyword based on the type definition or the `GetType` instance method for objects of unknown type. In both cases, an object-oriented type description is created. The examples discussed show how to use this description to read and write the values of a selected property. This ability is especially useful when implementing serialization and deserialization operations. Similarly, we can also read and write values from fields and call instance methods. Similarly, it is also possible to create new objects without referring to the `new` keyword. Discussing all the details of the reflection concept is far beyond the scope of the examples collected here. We also talked about bitstream syntax and semantics using the example of XML files. We showed how to use the XML schema concept to describe details of the syntax and also the semantics of a document indirectly and to create the source code of a program that will be used in the serialization and deserialization process.

## 6. To Be Merged

The serialized classes were defined in the test class. Therefore, if we define a library that will be used to serialize these classes, this graph, then the serializing class cannot know the type of serialized classes, cannot have references to unit tests, and so it cannot know the types. This way it could be proved that the solution is generic, I mean it doesn't depend on the target type of serialized classes.

As we see in this example, we do not have to create custom code in the target type that is subject to serialization that is used to implement this operation. So we can say that in this case, the serialization process is strictly autonomous.

The main outcome of the example is that in the target type that is subject to serialization, there is no need to create dedicated code that is used to implement this operation. So we can say that reflection enables us to offer a strictly autonomous solution.

Reflection-based serialization is a technique in software engineering where the internal structure of an object is recovered and internal data is serialized or deserialized based on metadata available at run-time related to the type of object. This approach allows for dynamic transferring of object state to bitstream without explicit configuration.


### 7. Reflection-Based Serialization Example

This example explains how to serialize using reflection and attributed programming. The `Catalog` class is used for this purpose. The main aim of the [SerializationUnitTest.ReadWRiteTest][ReadWRiteTest] method is to test the serialization of the graph of objects `Catalog` class. To be tested, the instances must be populated with test data. This class is located in unit tests, so I can add an appropriate method that fills the instance of this class with test data. The only question is where to add it. Adding this method to auto-generated text, i.e., text obtained as a result of an external program, is not a good idea, because our work is overwritten after each modification and generation of a new text. Therefore, let's use the fact that this class is generated as a partial class, and to populate the instance of this class with test data, we have to expand its definition by adding a custom part, which will be its integral part. In this part of the definition, located in a separate file, we can safely add all the operations we want to perform for this purpose. For this method called `AddTestingData` I used attributed programming again by adding an attribute that indicates that this method will be subject to compilation only when we have an environment configuration named [DEBUG][Debug]. Coming back to the unit tests, we see that an object has been created, and this object has been populated with test data. To make sure, we check that the instance has been created and initialized. Then we define the path where we want to save the file and use the `WriteXMLFile` method. This is a generic method. In its first parameter, we pass a graph of objects to be serialized, the file name, and details related to the output file creation.

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

### 8. SerializationUnitTest

Although we know that this is not a universal approach, let us return to the discussion of the topics related to checking the equivalence of the recovered graph compared to the original graph in this specific case. The primary graph was created by creating an object of the `Catalog` class and then filling it with test data using the `AddTestingData` method. After deserialization, we check that the `_recoveredCatalog` variable has references to the newly created object, so it is not `null`. Then we check how many elements the array has. Here and in the next two lines it is assumed that these are only two elements, but it would also be worth checking the actual length of the array. However, the most important thing here is to check whether two subsequent disc descriptions compatible with [CatalogCD][CatalogCD] are equivalent to each other. The equality symbol is used to compare them, although we expect that the elements are equivalent, not identical. This effect can be achieved by redefining the equality operator in the [CatalogCD][CatalogCD] class. For this purpose, the definition of the equality operator has been overwritten. As a result, the behavior of a new definition of this operator determines what equals means. The standard `Equals` method is used here. This operation compares strings, which have been generated by the overridden `ToString` method. It determines which elements will take part in this comparison and how they will be formatted. It is worth emphasizing here that the string formatting may depend on the current operating system language settings and, depending on different data types, the formatting of this string may not be clear; it may not be the same every time.

[ie]: .\README.md
[system.type]: https://learn.microsoft.com/dotnet/api/system.type
[Debug]: https://learn.microsoft.com/visualstudio/debugger/how-to-set-debug-and-release-configurations
[ReadWRiteTest]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/SerializationUnitTest.cs#L42-L58
[WriteXmlFile]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams/Serialization/XmlFile.cs#L41-L62
[CatalogCD]: https://github.com/mpostol/TP/blob/19592185e96c273de49c3808b7bc1a3b3106aa2f/ExDataManagement/DataStreams/DataStreams.UnitTest/Instrumentation/Catalog.xsd.cs#L56-L79
