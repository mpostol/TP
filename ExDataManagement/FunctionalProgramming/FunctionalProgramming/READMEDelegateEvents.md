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

# Delegate and Events

## Delegates

Delegates in C# do not explicitly contribute to functional programming, although they cannot be omitted in the context of anonymous functions language constructs. They are also vital for implementing inter-layer communication. Considering both arguments it is clear that delegated must be investigated in detail as a part of the introduction describing selected language constructs implicitly contributing to functional programming.

Delegates are similar to C++ function pointers, but delegates are fully object-oriented, and unlike C++ pointers to member functions, delegates encapsulate both an object instance and a method.

- Delegates allow methods to be passed as parameters.
- Delegates can be used to define callback methods.
- Delegates can be chained together; for example, multiple methods can be called on a single event.
- Methods don't have to match the delegate type exactly. For more information, see Using Variance in Delegates.
- Lambda expressions are a more concise way of writing inline code blocks. Lambda expressions (in certain contexts) are compiled to delegate types. For more information about lambda expressions, see the section [Anonymous Functions][AnonymousFunctions].

## Events

The definition of the event, i.e. `event`, can be found in this line. We see that we have the keyword `event` here, followed by an identifier and when we look at it, this identifier, as before, shows the delegation type. So this is a reference to the delegation type. Next, we have the identifier. In general, this entire definition is identical to the definition of the variable. So in this case we are also dealing with a delegation variable. The question is how the keyword `event` changes the variable's use. Namely, the word event limits the possibility of calling the methods pointed to, to which there are references in this variable, only to the inside of this class.

[AnonymousFunctions]: README.AnonymousFunctions.md
