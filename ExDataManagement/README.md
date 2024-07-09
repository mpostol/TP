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

# External Data Management (ExDM)

## Key words

software engineering, sequential programming education, learning, code examples,  information processing, external data: streaming data, structural data, graphical data

## Introduction

Computer science in general, and especially software engineering, is a field of knowledge that deals with the automation of information processing. Programs can be recognized as a driving force of that automated behavior. To achieve information processing goals programs have to implement algorithms required by applications. In other words, the programs describe how to process data, which represents information relevant to the applications in concern. Apart from the implementation of the algorithms, therefore, data management is a key issue from the point of view of automation of information processing in particular and computer science in general.

The main aim, of the collected code snippets in this section, is to extend knowledge and improve skills related to object-oriented programming focusing on interoperability between the computing process and data visualization, archiving, and networking resources. Particular emphasis is placed on the identification of solutions that can serve as a certain design pattern with the widest possible use in the long run.

Providing solutions valid for a long-term horizon is extremely difficult for such a dynamically developing field. Here, the experience of the author comes to the rescue.

To ensure a practical context of the discussion and provide sound examples, all topics are illustrated using the C\# programming language and the Visual Studio design environment. The source code used is available in the GitHub repository. Check it out from the See Also section. I believe that the proposed principles, design patterns, and scenarios are generic and may be seamlessly ported to other environments, including but not limited to different programming languages. The language and tools mentioned above have been used only to embed the discussion in a particular environment and to ensure that the examples are compliant with the programming in practice principles.

## External Data

### Preface

The external data is recognized as the data we must pull or push from outside of a boundary of the process hosting the computer program. In general, the external data may be grouped as follows:

- **streaming** - bitstreams managed using content of files, or network payload
- **structural** - data fetched/pushed from/to external database management systems using queries
- **graphical** - data rendered on Graphical User Interface (GUI)

### Data Management and Access

Data management involves the organization, storage, retrieval, communication, and manipulation of data to ensure its accuracy, security, and accessibility. It encompasses processes like data collection, storage architecture, data integration, and maintenance to support efficient analysis and decision-making.

Referring to previously mentioned data kinds we need examples related to:

- **streaming**: files management, bitstreams format, interoperability, cybersecurity of bitstreams, serialization
- **structural**: queries compositions, queries execution, database interoperability
- **graphical**: data rendering, data entering, events handling

**files management**: files management functionality involves the organization, manipulation, and control of files as entities of a distributed file system. It includes tasks such as creating, opening, closing, reading, writing, deleting, and organizing files using dedicated containers, for example, directories. Key aspects of file management functionality include content protection against malicious users and metadata maintenance.

**bitstreams format**: using bitstreams (file content) we must face a problem with how to make bitstreams human readable. The first answer is that it must be compliant and coupled with a well-known application. The application opens this bitstream as input data and exposes it to the user employing appropriate means to make the data comprehensible. Unfortunately, this approach does not apply to custom data. Therefore we should consider another approach, namely human-readable representation should be close to natural language.  The first requirement for humans to understand the stream is that it has to be formatted as text. To recognize bitstream as the text an encoding must be associated directly or indirectly. The next requirement, common for both humans and computers, is that a bitstream must be associated with comprehensible syntax rules. Finally, semantics rules should be associated with the bitstream that allows to assigning of meaning to bitstreams. Shortly there have to be defined a text-based language. A domain-specific language (DSL) is a text-based language dedicated to expressing concepts and data within a specific area. Except for programming languages like Java, C#, and Python, examples of well-known and widely accepted domain-specific languages are JSON, XML, and YAML formats to name only the most crucial.

**interoperability**: a Data Transfer Object (DTO) is a simple, lightweight data object that transfers data between software applications. DTOs are often employed to encapsulate and transport data between different system parts, such as between a client and a server to reduce network overhead.  Hence, DTO is just a bitstream formatted to make applications interoperable. They typically contain only data and no business logic implementation, making them straightforward for data exchange, and to be transferred over a network as a payload of the selected protocol stack.

**cybersecurity of bitstreams**: bitstream cybersecurity involves protecting the integrity, non-repudiation,  and confidentiality of bitstreams.  To ensure bitstream integrity all its users should be able to verify that the stream is not modified while it is being archived or transmitted. Non-repudiation refers to the ability to prove the origin or authorship of a bitstream. In turn, confidentiality refers to the protection of associated information from unauthorized access or disclosure. Bitstreams cybersecurity focuses on preventing unauthorized access, tampering, or reverse engineering of these bitstreams to safeguard the functionality and security of computer systems. From the programming in practice point of view, cybersecurity addresses the implementation of a hash function, digital signature, and encryption.

**Database queries**: are commands or requests made to a database management system (DBMS) to retrieve, manipulate, or manage data stored in a database. These queries are typically written in a domain-specific language,  such as SQL (Structured Query Language). The purpose of a database query is to interact with the database and perform operations like connecting, selecting specific data, updating records, inserting new data, or deleting information. A typical database query is a text that consists of statements that specify the conditions and criteria for the data retrieval or manipulation.

**graphical user interface (GUI)**: GUI is a type of user interface that allows users to interact with electronic devices or software applications through graphical elements such as icons, buttons, windows, and menus. To handle GUI functionality allowing data rendering,  data entering, and events handling is required. Data rendering refers to the process of converting raw data into a visual or presentable format for users to comprehend. Key aspects of GUI handling include converting raw data into a format suitable for further processing and adapting the presentation of data to different screen sizes or devices to ensure a consistent and effective user experience. GUIs provide a visual way for users to interact with a system, making it more intuitive and user-friendly compared to text-based interfaces.

## Conclusion

This section and subsections address examples of practical scenarios regarding various aspects of external data management. Referring to previously mentioned data kinds we need examples related to:

- **streaming**: files management, bitstreams format, interoperability, cybersecurity of bitstreams, serialization
- **structural**: queries compositions, queries execution, database interoperability
- **graphical**: data rendering, data entering, events handling

## See also

- [References](./../REFERENCES.md#references)
