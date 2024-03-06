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

# Data Streams - Usage <!-- omit in toc -->

## Table of Content <!-- omit in toc -->

- [1. File and Stream Concepts](#1-file-and-stream-concepts)
  - [1.1. File Class](#11-file-class)
  - [1.2. Stream class](#12-stream-class)

## 1. File and Stream Concepts

### 1.1. File Class

Let's try this piece of program `FileExample` is checked by a unit test. As we can see, this unit test was successful. But let's try to replace this caption `Today is` with the polish translation `dziś jest` and let's do the test again. We already have the result. Unfortunately, the result is not positive and we see that the expected text is different from the text we received. So the behavior of our program is different from before because we introduced Polish letters. There is also a typo here, but it doesn't matter here. What matters is that one letter has been omitted, the letter s with a dash. Why? Because I chose an encoding that does not contain Polish letters. If we take an encoding that contains Polish letters and perform this test again, this time we see that the test is green. This means that the content of the file corresponds to the string of characters, the text that was saved to it, including the letters that are national letters.

I have files of different types here, which would indicate that they are data for different programs. But for example, if we click on this file twice, we will receive information from the operating system that it does not know what program it is associated with. What program can open this file? But I have a program here that can open any file. This program, like the previous one, opens this file, reads its contents, and displays its contents on the screen using hexadecimal code. This means that a file is actually a composite, a sequence of bytes. Since each byte is a sequence of bits, we can conclude that the content of each file is a sequence of bits.

Let us examine the behavior of files using a specific programming example. Here I have the `CreateTextFile` method that will save a text consisting of the words 'Today is' and the current date to a file. The word `File` appears at the very beginning. The F12 key will take us to the definition. Here we will notice that this class is a static class. So there are no instances of it, we cannot create objects of this class. So this class cannot represent an individual file. Can represent all files. It provides operations related to files, where I used one of them and this operation deletes the file whose name was given as a parameter as the current parameter. 

``` csharp
      File.Delete(name);
```

Another interesting thing in this example is the `Open` operation. The question is why to perform the open operation on a file, and what this operation would be used for. We want to save the text, but we perform open operations. Here the answer is provided by a parameter called `FileAccess`. It is obviously an enumeration type providing all option that can be used. We see that we have several options here. I chose the write operation because I want to write to this file. Well, this operation is fundamental to the use of files that we will use later, because it causes the file that is being created or opened, if it exists, to become a critical section. What does it mean? This means that no other process can operate on this file once we have opened it. So if this file were to be used or shared by multiple applications, a lock placed by the operating system will prevent this and only allow one process to write to the file. This can have crucial consequences in a situation where for example we use a file in a hospital in which patient data is saved and is used in various places by doctors. To gain access to data at the reception, where further names are added. After someone opens the file for writing - as in this example - no one else can use the file.

So what's important to emphasize here is that the `File` class does not represent a file. The class represents the file system. It contains operations that we can perform on any file that is available to the computer.

The `Open` operation available in the `File` class creates an object (instance) of the `Stream` class, as follows:

``` CSharp
      using (Stream _stream = File.Open(name, FileMode.OpenOrCreate, FileAccess.Write))
      {
        FileContent = String.Format(CultureInfo.InvariantCulture, "Today is {0}", DateTime.Now);
        byte[] _content = Encoding.ASCII.GetBytes(FileContent);
        _stream.Write(_content, 0, _content.Length);
      }

```

The F12 key takes us back to the definition and in this case, we see that it is an abstract class. What does it mean? This means that it can represent not only files but can also represent other resources. It is an abstract class and thanks to its various implementations we can ensure the polymorphic behavior of various objects it represents. In simpler terms, if this class represents a file in the file system, these operations will be performed by the operating system on behalf of a file system, if this class represents, for example, a computer network and operations related to a computer network, then again we will have to deal with the operations that are performed, but this time not on resources related to the file system but on resources related to the computer network. If this class represents an object that is in memory, its behavior will also be completely different than the two previously mentioned ones. We will come back to this topic by discussing various examples in which the `Stream` class functionality has been overwritten, and inherited by classes that represent different behaviors, i.e. polymorphic behaviors of various resources that we can use to store and manage data.

The next line does not add much to the considerations regarding the use of files to store data processed by the program. This line is where the final formatting of the string of characters to be saved takes place. The only interesting point is the possibility of choosing the syntax that will be used to write the date text form. This syntax varies for different natural languages. I chose a variant that is independent of the natural language selection by the environment in which the program is executed.

In the next lines of the program, we write to the file. The file, as I have already said, is represented by the `Stream` type, and to write data to it first, we must prepare it.

### 1.2. Stream class

We must be aware of how the data can be prepared, let's look at the definition. Analyzing the possibilities of writing to the stream we see that all `Write' operations operate on a sequence of bytes. So in this case, and also in all other cases where we will use a stream to represent other data media, the data will always be organized in such a way that they are simply streams of bytes, which means a stream of bits.

Since a stream of characters must be specially prepared in some way to be saved in a file, there must be a relationship between the stream of characters, i.e. text, and the binary content of the file. Let me remind you that at the very beginning, we said that a program is also a text. Let's look at this example, which starts with these two characters. If we open this file in a program that allows us to analyze the content at the binary level, we will see that this file does not start with..., these first two characters appear only in some position, and this file does not start with these characters. This, among other things, indicates that there is some kind of ambiguity between the text that is displayed on the computer screen, i.e. here the first two characters, and the content of the file, the binary file. We say that this relationship between the text and the bitstream is `Encoding`. We have different standards for converting bits to characters and characters to bits. One of them is the ASCII standard. A widely known standard that contains definitions - a table that tells how to represent binary characters. The table is finished, therefore the number of characters is strictly defined.

Since a stream of characters must be prepared in some way to be saved in a file, there must be a relationship between the string of characters, i.e. text, and the binary content of the file. Let me remind you that at the very beginning, we said that a program is also a text. Let's look at this example, which starts with these two characters. If we open this file in a program that allows us to analyze the content at the binary level, we will see that this file does not start with `...`, these first two characters appear only in some position, and this file does not start with these characters. This, among other things, indicates that there is some kind of ambiguity between the text that is displayed on the computer screen, i.e. here the first two characters, and the content of the file, the binary file. It can be stated that this relationship between the text and the bitstream is defined by `Encoding`. We have different standards for converting bits to characters and characters to bits. One of them is the ASCII standard. A widely known standard that contains definitions - a table that tells how to represent binary characters. The table is finished, therefore the number of characters is strictly defined.

The last thing remains to be explained, namely the close operation, which we perform on the stream, since the open operation appeared at the beginning, naturally the close operation must appear at the end. It is again fundamentally important because it closes the file, which means that it closes the critical section at this point. So from now on, others will also be able to use this file - they will be able to open this file. Therefore, it should appear as quickly as possible, i.e. it should appear immediately when we stop working with this file. It means that we will not be going to perform further operations on this file within the program. The question is what will happen when, for example, an exception occurs in the program between opening a file and closing it. The `Close` operation will virtually never be executed. We will never reach this line. So this file will be closed by the environment at some point. However, this will not happen immediately. Therefore, we should use different operations here, a different approach, and take advantage of the fact that `Stream`, let's go F12 again to the definition, implements the IDisposable interface, which allows the use of the `using` instruction. The final form of the example would look something like this, in which we have the operation, statement `using`, which causes the dispose operation to be executed against the `stream` variable last. If the string or block of statements that is part of the using operation is interrupted, the `Dispose` operation will also be executed. Thanks to this, we can ensure that the file will actually be closed immediately when the next program statements will no longer have access to the `stream` variable due to the fact that it goes out of visibility range.
