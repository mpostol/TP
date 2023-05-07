# Programming in Practice [![release](https://img.shields.io/github/release/mpostol/tp.svg?style=flat)](https://github.com/mpostol/TP/releases)

## Key words

software engineering, software design, education, training, code examples, csharp, csharp-examples, data-intensive-programming, data management, information processing, data processing, adaptive-programming, dependency injection, inversion of control, distributed programming.

## Major Milestones

|                        Release                        | Name                                    | Milestone                                                               |                                                                  DOI                                                                  |
| :---------------------------------------------------: | --------------------------------------- | ----------------------------------------------------------------------- | :-----------------------------------------------------------------------------------------------------------------------------------: |
|                          4.0                          | Distributed Programming 2020-10-05      | Distributed Programming                                                 | DOI: 10.5281/zenodo.4066609 [![DOI](https://zenodo.org/badge/DOI/10.5281/zenodo.4066609.svg)](https://doi.org/10.5281/zenodo.4066609) |
| [3.0](https://github.com/mpostol/TP/releases/tag/3.0) | ExDM  VideoBook Helion v1.0.            | [**C# in Practice - External Data-Intensive Programming** v1.0.][vdpnt] | DOI: 10.5281/zenodo.2578245 [![DOI](https://zenodo.org/badge/DOI/10.5281/zenodo.2578245.svg)](https://doi.org/10.5281/zenodo.2578245) |
|                          2.0                          | Adaptive Programming (AP) February 2019 | Adaptive Programming                                                    |                                                                  NA                                                                   |

>[**DOI**](https://www.doi.org/hb.html): Digital Object Identifiers (DOI) are the backbone of the academic reference and metrics system. It is aimed at researchers who want to cite GitHub repositories in academic literature. Use the [DOI](https://www.doi.org/) System to resolve a DOI name.

## Goal

Turning today's students into tomorrow's advanced software developers and architects.

## Content

### Executive Summary

Teaching of Programming (TP)
Main purpose of this repository is to provide code examples for education purpose. The code examples address the following application domains

- [**External Data-Intensive Programming (ExDM)**](ExDataManagement/README.md) : process data management, i.e. those that are input or output for the business logic of the program.
- [**Adaptive Programming (AP)**](AdaptiveProgramming/README.md): language constructs, patterns, and frameworks used at the development and deployment stage with the goal to increase the adaptability of the software.
- [**Distributed Programming (DP)**](DistributedProgramming/README.md): all about developing inter-operable applications interconnected over the network.
- [**Concurrent Programming (CW)**](ConcurrentProgramming/README.md): all about the programming pattern formally describing a program to execute operations as a result of nondeterministic events at run time.

The repository collects examples that can serve as a pattern with the broadest possible applicability addressing the applications in concern.  All topics are illustrated using the C# language and the MS Visual Studio design environment to ensure the practical context and provide solid examples. The source code is available in this repository. Hopefully, the samples are easily portable to other development environments.

#### External Data-Intensive Programming (ExDM)

Computer science in general, and especially programming activities, is a field of knowledge that deals with automation of information processing. Programs can be recognized as a driving force of that automated behavior. To achieve information processing goals programs have to implement algorithms required by the application concerned. In other words, the programs describe how to process data, which represent information relevant to the application. Data management - apart from the implementation of the algorithms – is, therefore, a key issue from the point of view of automation of the entire information processing and computer science in general.

The [ExDataManagement](ExDataManagement/README.md) folder collects examples that can serve as a certain pattern with the broadest possible applicability addressing the mentioned above application domain.

> **Note**: to open the code samples in the Visual studio double click the file `ExDataManagement.sln`.

#### Adaptive Programming (AP)

The adaptive programming is presented as a catalog of language constructs, patterns, and frameworks used at the development and deployment stage with the goal to increase the adaptability of the program against changing production environment in which it is executed.

The [AdaptiveProgramming](AdaptiveProgramming/README.md) folder collects examples that can serve as a certain pattern with the broadest possible applicability addressing the mentioned above application domain.

> **Note**: to open the code samples in the Visual studio double click the file `AdaptiveProgramming.sln`.

#### Concurrent Programming (CW)

It is a programming pattern that allows writing a program that formally describes at design-time the execution of operations as a result of nondeterministic events. Concurrency is when multiple sequences of instructions are run in overlapping periods of time. In other words, the instructions sequence execution is undetermined in advance. Concurrency may be implemented explicitly using dedicated types. The `Thread` is a type that may be used to represent a sequence of instructions in this scenario. Concurrency may also be implemented implicitly, for example using a concept like asynchronous programming atop of the `Task` type.

> **Note**: to open the code samples in the Visual studio double click the file `DistributedProgramming.sln`.

#### Distributed Programming (DP)

Information and Communication Technology has provided society with a vast diversity of distributed applications. By design, the deployment of this kind of application has to focus primarily on communication. Examples collected in this repository addresses the systematic approach to the designing of the meaningful Machine to Machine (M2M) communication targeting distributed mobile applications in the context of new emerging disciplines, namely Industry 4.0 and Internet of Things (IoT) atop of the M2M communication and composed as multi-vendor cyber-physicals systems.

The [DistributedProgramming](DistributedProgramming/README.md) folder collects examples that can serve as a certain pattern with the broadest possible applicability addressing the applications in concern.

> **Note**: to open the code samples in the Visual studio double click the file `DistributedProgramming.sln`.

## How to cite the software and associated documentation files

To be compliant with the license of the repository the below copyright notice shall be included in all copies or substantial portions of the software and associated documentation files (the "Software").

Copyright (c) 2022 Mariusz Postol

In this section, you will learn how to cite the "Software" using the DOI number. A DOI number is a unique identifying number for the Software version. Because this repository has a DOI, use the DOI in your citation for the article or any derived work, like this:

> Mariusz Postol, csharp (C#) in Practice: \[Target Part Name\], `https://github.com/mpostol/TP`, \[year\] DOI: [10.5281/zenodo.2578244](http://doi.org/10.5281/zenodo.2578244)

or

> Mariusz Postol, csharp (C#) in Practice: \[Target Part Name\], `https://github.com/mpostol/TP`, \[year\] DOI: [http://doi.org/10.5281/zenodo.2578244](http://doi.org/10.5281/zenodo.2578244).

Replace `year` with the current year and `Target Part Name` with the name (or names) of the files you are referring to.

## How to follow up?

GitHub offers `Discussions` as a space to connect with other members of the community. I hope that using the `Discussion` space you:

- ask questions you’re wondering about
- share ideas
- engage with other community members
- welcome others and are open-minded; remember that this is a community we build together

I have activated the [Discussion][Discussion] space for this repository. Follow the  [Discussion][Discussion] to be in touch.

To follow any activity in the repository, switch on the `Watch` functionality. If you find the project interesting, please star the repository. Starring a repository also shows appreciation to the repository maintainer for their work. You can star repositories and topics to keep track of projects you find interesting and discover related content in your news feed. Check out [Saving repositories with stars](https://docs.github.com/en/get-started/exploring-projects-on-github/saving-repositories-with-stars) to get more.

- [Join me on LinkedIn](https://pl.linkedin.com/in/mpostol)
- [Discussion][Discussion]

## See also

- [Programming in Practice - Executive Summary; Udemy course; 2021][udemyPiPES]; The course explains the role of this repository as the extended examples storage that is a foundation for the Programming in Practice paradigm. The course is for all serious about the improvement of the software development skills education methodology.
- [Programming in Practice; GitBook eBook](https://mpostol.gitbook.io/pip/) - The content of this eBook is auto-generated using the Markdown files collected in this repository. It is distributed online upon the open access rules.
- [Discussion panel][Discussion]
- [Programming Technologies 2021; Recorded lectures](https://youtube.com/playlist?list=PLC7zPvgw-YbyWXRTAe9m-ABP9YWmpLvUk)
- [Programming Technologies 2020; Recorded lectures](https://youtube.com/playlist?list=PLC7zPvgw-YbwOD3GaSPl6kzKhDRmmrA-9)
- [Object-Oriented Internet](https://youtube.com/playlist?list=PLC7zPvgw-YbyWss-0j_waddacgroLFTzi) This playlist on YouTube addresses research results on the systematic approach to the design of the meaningful Machine to Machine (M2M) communication targeting distributed mobile applications in the context of new emerging disciplines, i.e. Industry 4.0 and Internet of Things.
- [Postół. M, Język C# w praktyce. Kurs video. Przetwarzanie danych zewnętrznych](https://videopoint.pl/kurs/jezyk-c-w-praktyce-kurs-video-przetwarzanie-danych-zewnetrznych-mariusz-postol,vjcprv.htm#format/w); 2019, Helion (in polish).
- [Join me on LinkedIn](https://pl.linkedin.com/in/mpostol)
- [References](REFERENCES.md)

[![DOI](https://zenodo.org/badge/DOI/10.5281/zenodo.2578244.svg)](https://doi.org/10.5281/zenodo.2578244) - This DOI represents all versions, and will always resolve to the latest one.
[![Build Status](https://caseu.visualstudio.com/TP/_apis/build/status/mpostol.TP?branchName=master)](https://caseu.visualstudio.com/TP/_build/latest?definitionId=2&branchName=master) - Build Status

[udemyPiPES]: https://www.udemy.com/course/pipintroduction/?referralCode=E1B8E460A82ECB36A835
[Discussion]: https://github.com/mpostol/TP/discussions
[vdpnt]: https://videopoint.pl/kurs/jezyk-c-w-praktyce-kurs-video-przetwarzanie-danych-zewnetrznych-mariusz-postol,vjcprv.htm#format/w

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
