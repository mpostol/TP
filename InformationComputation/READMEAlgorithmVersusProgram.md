# Algorithm Versus Program

## Preface

Let me recall that our challenge is to learn all about information computation. Information computation means a process employing a computer (a physical device) to process information as a series of actions or steps taken to achieve a particular result or help fulfill a task. The first challenge of this process is that information is abstract. In other words, it is a kind of knowledge that cannot be used directly to describe computer behavior. In this subsection, we will learn how to describe the actions or steps to achieve a particular result in compliance with the limitations of modern computers. I mean the computer is a physical device and cannot process any abstraction.

## What's the problem?

Explaining the title of the course, we concluded that we are talking about the automation of information processing. To be more practical and talk in the context of problem-solving we may recognize the information as a piece of knowledge about the state and behavior of a selected real-time set of activities - part of the natural realm. But to solve any problem using a computer we also need to know how to process the information to reach a goal. Again, additionally, we need information, a piece of knowledge describing how to solve the selected problem. How to control the activities to achieve the goal we are facing with. This kind of knowledge we call an algorithm. Let me stress it is also information that cannot be directly applied or used by any physical device including but not limited to computers. The main challenge of this subsection is to learn more about how to do it.

## Algorithm implementation

Computation means a set of actions that ensure the automation of information processing. To ensure automatic processing, we need to use technology, which means a programmable device. Today it is the binary computer for sure. Anyway, we must ensure that this processing engine behaves following an appropriate algorithm. The algorithm is again information because it is a piece of knowledge on how to solve the problem. Hence, it is an abstraction that will be useful in the computation process only if it can be represented in binary form - similar to the process information discussed earlier. And this is the next task of software developers, namely algorithms implementation, and the results of this work are computer programs. That is a recipe instructing the computer how to control the activities to achieve the chosen goal. From the previous subsection, we learned that information to be processed by a physical device must be represented by data first using the alphabet, syntax, and data semantics. That is a coding system. A similar approach can be applied to the algorithm, which is also a piece of information describing the computer behavior - shortly algorithm. The most promising solution is coupling together custom coding system design and algorithm implementation because both are tightly coupled.

## Computer Program is Text

Today, we do not need to implement the algorithm using a binary representation. Thanks to the compilation process, we can use alpha-numeric alphabets - just like the natural languages we use on a daily basis. Typically the alphabet is derived from the Latin alphabet. This leads to the statement that any program at the beginning of its life cycle is just a text, hence a sequence of characters. **Text becomes a computer program when it meets additional rules that will enable it to be compiled.**

## Programming Language

And so we come to the term programming language. To be used to control a computer it is a kind of contract between the software developer and compiler that both must comply with and use to finally implement information processing as the data computation. It must be a set of rules. The contract must be exhaustive. To fulfill this requirement the syntax and semantics must be defined and applied respectively to provide appropriate rules that can be used:

- syntax: to create the correct text by concatenating characters from the alphabet and
- semantics: to make the text meaningful.

CSharp is such a language that I use to explain software development issues with concrete examples.

## Binary machine needs binary alphabet

Using an alphanumeric instead of a binary alphabet and the requirement that the design of the process data coding system should be coupled together with the algorithm implementation leads to a need to replace the coding system with the type concept to design the information representation and computer behavior. Defining a programming language atop of alphanumeric alphabet allows us to better suit the definition to human needs finally we get high-level languages. The type concept is the main subject of the section titled `Information representation`.
