# Partial Definitions

## Title Page

In this lesson, we continue the discussion of topics related to the representation of information as data processed by a computer.  We know that a basic term relevant for this discussion is type notion. The type could be defined explicitly by the developer. During the previous lesson, we talked about how the programming language supports us in data harmonization, where the variable type is inferred from the value type assigned when the variable is declared. It means implicit type declaration. It requires a special syntax of the text representing the assigned value. Using this approach the explicit type definition doesn't exist so we can't even specify a name for this type. Hence, we call this kind of type anonymous type. It is permanently assigned to the variable in which it was defined. A drawback of this approach is the impossibility to define custom behavior. Hence we are limited to using only operations associated with the anonymous type by the programming language definition.

During this lesson, I will pay special attention to issues related to the auto-generated data types creation based on the definitions of the external types. This time we will enter the domain of type conversion. To make the discussion generic I will skip details related to the conversion process itself. I will only try to rise up issues relevant to the design process and allow us to be prepared for the consequences of the conversion. Let me stress that in spite that a type is auto-generated the developer has full responsibility for the final processing results robustness. For this approach, we assume that the external data type is available in some form and you have to convert it using some programming tool to get the equivalent type in the programming language. This may sound puzzling, but I want to reassure you that we will only focus on the conversion engineering itself but not on mapping external types to internal data types.

## What is the problem?

Converting some external type defined in any form to a type definition expressed using a programming language, using any programming language, always produces text. Let me remind you that at the beginning the program is just a text that complies with the syntax and semantics of the selected programming language. Therefore, we enter the issues of text management, i.e. writing, modifying, and mixing text in various circumstances. We will be talking about text management engineering in the context of the type definition.

To be honest I must state that the linguistic constructs in question have a much wider application than just facilitating the conversion of types. In other words, types conversion is only an example of the applicability of the partial types and methods that allows a systematic discussion on this approach.

### Separation of Concerns

When working on the text of the program, we may encounter a need to separate selected parts of a definition to improve efficiency by spreading the development of the parts to different members of a team. It allows leveraging the separation of concern concept if, for example, the text is too long or contains separate subjects or logical threads. In such a situation, extracting a piece of text into separate text files is one of the options that comes first, as the most obvious.  It also allows for avoiding conflicts while the text is maintained in a remote repository. The problem is that a file is also a compilation unit for most development environments, so it must contain correct text in the context of the syntax and semantic rules of the programming language.

However, it must be remembered that an alternative to dividing the text into fragments is also possible after engaging the object-oriented programming and the use of the inheritance paradigm, thanks to which we can also meet this goal, i.e. divide the selected text into logical fragments. Both approaches have advantages and disadvantages therefore they are applicable depending on the conditions.

### Merging the Text

In addition to splitting development, sometimes we may encounter another need to merge modifications of program text that come from different sources. A typical example is auto-generated program text by a tool. It also could cause that conflicts will occur, namely simultaneous text modification in the same place by different sources.

There is one very important difference between both scenarios.
In case the conflict is caused by the simultaneous activity of many developers, the conflict can be recognized and a workaround can be applied by the remote repository managing the source program where the history of program text changes is tracked and appropriate solutions are used to merge the code to avoid or solve collisions. If the conflict is a result of engaging a tool to auto-generate code text the conflict has to be recognized and a workaround has to be applied only locally by the compiler that must be responsible to merge parts together before starting the build operation.

We must also consider a scenario where we have to use different programming languages ​​to define the same type. Additionally, when many programming languages are engaged to define a type, we basically have no choice but to divide the text into different files, each of which has to be recognized as a compilation unit written according to the rules of the selected language. In this case, also the merge operation of the program text provided by the remote repository doesn't offer any relief. The compiler must first translate one part to harmonize it with the other ones and after that, the text may be merged to make up a consistent definition. Everything must happen during the single build operation.

Anyway, if the compiler must be engaged in the code merge it could be supported by the dedicated syntax and semantics of the programming language definition.

### An Example of Auto-Generated Code

In further consideration, we will skip the issues of teamwork, or rather the consequences of teamwork, because here the solutions are already known and are not related to the syntax and semantics of the language. Instead, let's look at some examples related to type conversion by a tool and multi-language programming.

### Catalog.xsd

The first translation illustrating the problem of automatic code generation can be found in the project where examples for the next block of topics are located, namely for streaming data. It is an XSD file containing an XML schema document. Here it is already open. This file describes sample types in XML. So, in a language that is completely C# independent. These definitions, therefore, cannot be used directly in the program, because the XML notation has inconsistent syntax. As mentioned before, one way to solve this problem is to generate types or an equivalent type based on them, which will be written according to the rules of the selected language. And here we have another file, this time with the `cs` extension, a file which syntax and semantics are consistent with the selected language, and which has been automatically generated. This is evidenced by the inscriptions in the header of this file. This file is located in the same project as the file associated with the XSD file. To generate this file, I wrote a script that we can see on the screen now, using the XSD program. This program converts the file `Catalog.xsd` to a CSharp file with the same name but with a different extension. The type definitions are placed in the namespace that is defined here. To run this script and generate the file, you need the operating system command interpreter window that has been launched using the Visual Studio environment, and therefore which has initialized all system variables that allow the use of the tools of the Visual Studio environment. Let's see how this script will work now. Well, let's go back to the program that was previously generated and make any changes to that program. The most spectacular modification is, of course, the deletion of the whole content. Let's remember the changes. So the file is empty at the moment. And of course, if we run the script, the script ends after a while and Visual Studio asks me if I want to read the new content. I have agreed to this and we can see that again we have the content I did delete previously. This yellow line on the left indicates changes from the previous version. Since I saved an empty file previously, everything has been changed. It is possible that the previous content has been restored if the XSD file has not changed.

This example illustrates a problem, namely, if I make any changes in this text, of course, they will not be effective, i.e. any changes will be overwritten when the file is regenerated. The warning is written here in the header that any changes will not be effective after regenerating this file, i.e. after restarting the script.

### Catalog.cs

A similar example can be found in a project related to the topic of structured data. This file is also auto-generated not from the types that are defined in XML, but from the database schema. We will not discuss how to generate it now. We will come back to it when we discuss external data management in a separate course.

## PersonsDataContext

An example that illustrates the use of different programming languages can be found in the Graphical Data project. Here we have a file called `MainWindow`. It is written using the XAML. This language is based on XML. The important thing for us is that this file together with another file creates one class, and finally one type definition. Since it uses a different language, the text of the definition parts cannot be merged in one file. In this case, the type definition must be split into two files.

## Partial Class and Partial Interface

In this situation, as we have just talked about, the concept of the partial definition could be found very useful. Let's start with partial class and partial interface.

## PartialClass Part 1

Examples of a partial class are in the `Partials` folder. Here we have two files that have the extensions `p1` and `p2`, respectively, to mark them as part one and part two. They contain the definition of the same class. In other words, this definition is divided into two parts that form one definition - one whole. One part is located in the first file and the other one is in the second file. Of course, including the word `partial` also allows the class definition to be split but located in the same file. Here is an example of the third part of this class placed in the same file as part two. Let me emphasize that this possibility is only a side effect of a language definition in which the partial definition concept is not related to the files. This scenario will not work for auto-generated types, as the whole content will be overwritten during regeneration. This does not exclude the possibility that there are some scenarios in which splitting the definition into several parts placed in the same file makes some substantive sense. A typical example would be the use of a separation of concerns principle. As a result, you may consider breaking the definition of the same type into two logically coherent fragments and placing them in the same file. Remember, however, that instead, we can use inheritance, which additionally emphasizes the hierarchical dependency relationship between parts.

## IPartialInterface

Similarly, we can apply this concept of partial definitions to interfaces. Again in the folder `Partials`, there are two files `p1` and `p2`, which contain two parts of the same definition of an interface that was used to define the previously discussed class.

## PartialsUnitTest Part 1

Let us analyze the behavior of partial definitions with the use of unit tests. Here we have a unit test that was prepared for this very analysis. As we can see, in the first unit test we create an object of the class `PartialClass`. From the point of view of use, this class behaves like one definition, although partially defined in several parts.

For several parts to behave as one class, all parts must have the same name, so they must be defined in the same namespace and have the same identifier. Because the class identifier together with the namespace creates a unique name of a type. Although the type definition is partial, we only define one type. Again, only with this assumption, we will be able to treat these parts as a common definition. But since this is only one definition composed using several parts, we must consider how the text that creates them, and which is divided into parts, will behave. And here it is easy to see that this text will simply be merged by the compiler. So before a partial type is subject to build, the text from all parts will be merged and as a result, a single definition will be created with all the consequences of this fact. To merge the compiler may use syntax and semantics rules of the programming language. It is a very important observation because instead of learning all limitations with regard to the partial definitions it is enough to imagine what will be created as the result of the merge.

One significant consequence of this fact is that the source code in each part must be available to the compiler while the build process is running. This means that all files must be in the same project; in the same compilation unit.

## PartialsUnitTest Part 2

Let's go back to unit testing again. We use two instance methods of a partial class in this unit text. ALt F12 will lead us to the definition of the former. This method is defined in part one. And the other method - I'll use ALT F12 again to find it - is defined in part two. So they were placed in the same definition and are available in the same object that was created from the common definition. The definition itself, on the other hand, is a composition of fragments.

We already know that a common definition is created by merging text from partial definitions. However, it is worth knowing here what are the rules of this text merging. The first rule is that the text is merged so as not to cause conflicts we know from using repositories to manage text for teamwork. Leaving aside the details of the compilation process, we can only remember that this operation uses language syntax rules. In other words, the text is mixed in the context of the syntax rules of the language. As a result, it is possible to avoid conflicts in the text of the program instead of bothering with them. However, conflicts must not be confused with errors in the content of the program. These, after all, can occur even if the definition is not made up of parts. To make it clear, we can distinguish here three parts of the class header that are relevant to this process. The first part is the attributes that come before the class header. Any modifiers that appear before the partial keyword. And the inheritance chain that follows the class name and the colon. And here these parts will be merged in such a way as to create a common header from partial headers based on the syntax of the programming language. So, first, all kinds of modifiers cannot contradict each other. They can be repeated or omitted, but not contradictory. For example, one part of a class definition cannot be public, and the other part, for example, private. Also, the inheritance chain must be consistent. All the identifiers that are in the inheritance list will be common to all parts when they are merged together. Let's go back to the previous definition, so let's withdraw this modification to make the definition correct.

## Partial Method

Now let's move on to the partial method definition, which is an integral part of the partial class definition.

## PartialClass Part 2

From the sample code, we can see that the partial method also uses the keyword partial. But the other feature of the partial method is that no block has been defined for that method. We call it not defined because a block in the partial method is not required. So it's a bit like declaring an abstract method as a member of an interface.  For example here where we do not have the word `partial`, but we also do not have a block that defines the functionality of the method. So this method is not fully defined. The difference between a declaration that is an abstract definition, as in the case of interfaces, and a method for which only the header is defined as a partial declaration, in a partial class is that in the case of an abstract method it must be implemented in order to be used. So we cannot create an instance of a class for which even one abstract method has not been implemented. This is the basic rule of object-oriented programming, in which all definition members must be unambiguously defined. The situation is different in the case of partial classes. In this case, the `PartialMethod` does not need to be implemented. I put it here in the second part of the definition of this method where it is implemented, but let's investigate the behavior of this partial method using unit tests.

### PartialMethodCallTest

There is a method in unit tests that is responsible to test a partial method call. Here we create an instance of the class in concern and then call the partial method. Please note that it is an indirect call. Again, ALT F12 will show that this partial method is called indirectly using an additional method that I put in the definition of this class. The question is why. Try to guess but I will answer this question shortly.

After triggering the test method - if the partial method is implemented - we can see that at the moment the test is being executed with a positive result, i.e. the not implemented exception exception is thrown as a result of calling the partial method.

Next, let's investigate what happens when a partial method is not implemented, namely when there is only its announcement, a declaration in the form of a header with the partial keyword prefix. I delete the part that implements it. For this purpose, I comment on the source code that provides the implementation part.  After calling once more the test - now when this implementation part is removed from the source code - we can observe that the test result is red this time. From the details of the result, we read that we expect a not implemented exception in the test, but no exception has been thrown at all. Let me stress there is no indication that this method has not been implemented. How to explain it? Well, let's go back to the code again.

If a partial method is not implemented all calls of this method are removed from the code. A partial method is considered not implemented if no one part of a definition provides a redefinition of this method that implements it.

Now let's return to the question of why I am calling this method indirectly. Well, I call it indirectly because all partial methods must be private. We can only access them from within this partial class definition, actually from any part of this definition, because the code is merged before compilation, we don't have access from the outside. The reason is that during the merging of the source code the compiler has to remove the call to a method if it is not implemented. To delete partial definitions in a text blend, it must have this call available locally. This would be impossible if the call were placed outside the definition. This can be guaranteed if we use the encapsulation paradigm and the declaration is private. So the compiler's activity would now have to be extended to other parts of the program, not just the partial definition.

## Homework Part 1

As usual, let's go on to homework definition. Well, as part of your homework I am asking you to expand the source code that we see here with a unit test that will confirm that the class definition will contain all the attributes regardless of which part of the class definition is preceded by the attribute.

## PartialClass Part 3

Maybe a few words of explanation about the homework. Here we have two definitions. Precisely, one definition in two parts of a partial class. The first part is shown at the top and this part contains the attribute. There is also an attribute decorating the second part but commented. Let me delete the comment to add this attribute to the definition. Unit tests check the number of attributes for the selected class. As a result of the test, we can show that the appearance of another attribute, before the next part of the attribute, caused the number of attributes to be not equal to one, but two. Anyway, we can examine the results of this test here. This method checks if the length of the array is equal to the number really the array length is 2. This is not surprising because the text has been merged, as I said before, and the attributes that are in front of all the parts will appear before the common definition created by the compiler. The same should be done when solving the homework, but this time additionally the task is to check which attributes are present before the common class definition.

## Homework Part 2

And two more questions. Will the test result depend on where the attributes were added? And; why a partial method cannot return a result and have out parameters?

## Thanks for your time

And that's all about partial definitions, which, as it turns out later, will be very useful for defining types for external data. We will come back to this language construct many times. Thanks for your attention and see you next lesson.
