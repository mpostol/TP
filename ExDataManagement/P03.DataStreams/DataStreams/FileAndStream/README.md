---
//____________________________________________________________________________
//
//  Copyright (C) 2018, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________
---

# Message

- Each file content is a stream of bytes, consequently, it is also a stream of bits.
- If for the bits stream an encoding (eg. ASCII, UTF-8, UTF-16, etc.)  is defined the stream is recognized as text.
- The text becomes C# , HTML, xml, JSON, etc. document if it follows syntax and semantic rules of a selected language (compiler don't complain).

# See also

## [File and Stream I/O](https://docs.microsoft.com/en-us/dotnet/standard/io/index)

File and stream I/O (input/output) refers to the transfer of data either to or from a storage medium. In the .NET Framework, the `System.IO` namespaces contain types that enable reading and writing, both synchronously and asynchronously, on data streams and files. These namespaces also contain types that perform compression and decompression on files, and types that enable communication through pipes and serial ports.

A file is an ordered and named collection of bytes that has persistent storage. When you work with files, you work with directory paths, disk storage, and file and directory names. In contrast, a stream is a sequence of bytes that you can use to read from and write to a backing store, which can be one of several storage mediums (for example, disks or memory). Just as there are several backing stores other than disks, there are several kinds of streams other than file streams, such as network, memory, and pipe streams.

## [File Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.file?view=netframework-4.7.2)

Provides static methods for the creation, copying, deletion, moving, and opening of a single file, and aids in the creation of [FileStream](https://docs.microsoft.com/en-us/dotnet/api/system.io.filestream?view=netframework-4.7.2) objects.

## [IDisposable Interface](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?view=netframework-4.7.2)

Provides a mechanism for releasing unmanaged resources.

## [FileAccess Enum](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileaccess?view=netframework-4.7.2)

Defines constants for read, write, or read/write access to a file.

## [Encoding Class](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=netframework-4.7.2)

Represents a character encoding.