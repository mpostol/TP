# Generic Types and Methods

## Preface

In this lesson, we focus on generic types and methods. They are especially important because they expand object-oriented programming somehow and consequently extend our possibilities of reusing the previous results and this, as we know, decreases the total costs of software development. As usual, let's start by defining the problem.

## What is the Problem?

## Introduction

- Type reusability
  - inheritance
  - template

### Type Reusability

We know that the possibility of reusing the results of previous programming work is extremely important. It improves economic efficiency but additionally it is beneficial for reliability and minimizes training costs. From the previous lessons, we also know that the type concept is extremely important for modern programming languages. Therefore, simplifying, we could define the problem as the reusability of the already defined types.

### Inheritance

Inheritance paradigm, that is, the ability to reuse a predefined type called a base type to create a derived type is the main reason for the wide leveraging of object-oriented programming concept, which was introduced as one of the pillars of this concept. In previous lessons, we learned that a type is a collection of values and operations on those values. Simply put, in the case of inheritance, a derived type takes over the characteristics of the base type and allows you to add new and modify the existing functionality. You can also extend the set of values, that is, the set of values of the derived type contains a set of values of the base type.

### Template

Using parametrized templates is an alternative to inheritance with the purpose to improve reusability. I remember a similar concept was applied to define subprograms ages ago. Procedures, functions, and methods known in modern programming languages may also be classified as templates with formal parameters. Unfortunately, all of that must also be classified as at least partially run-time solutions because the actual values of the arguments are determined while executing the program. Entirely design time solutions like inheritance allowing definition of parametrized templates is a macro concept. This concept also comes from the very beginning of the software engineering era. I am not expecting that you remember the subprogram or macro concepts because this lesson is not about the history of software engineering. It must be also stressed that mentioned terms describe very broad ideas. Anyway using templates to improve reusability is not something new. The main goal of this lesson is to prove that we can create programmable patterns with formal parameters. The actual values of these parameters may have an impact on the template behavior at run-time or the final definition created from a template at design time. During this lesson, we will investigate how this last option could be applied to create type templates. We will call these templates generic types. The generic word stresses the reusability of a template to define types.

### Conclusion

Before deep diving into generic types let me stress that it is a lexical construct. It means that before using it to create a concrete type definition all parameters must be resolved. To resolve in this context means that they must be replaced by actual ones at design time.

## Overview

### Introduction to Example

As a foundation to investigate the generic types I propose to consider a scenario in which we want to represent a sequence of values, a sequence of compatible values. The sequence is made up of many values and all the values must be of compatible types. The main reason is that we are going to reuse the sequence management functionality in spite of the type of collected values provided that all values collected are compliant with each other in this sequence. But before that, two questions must be addressed. The first question is:

- a sequence of values - what it is?

and the second question:

- compatible values - what it is?

#### Sequence of Values

Addressing the first question we can explain, that in general, the sequence is an ordered collection of entities in which each member knows the next one. In such a relationship, the last and the first must be distinguished because the first element is not pointed out by any item belonging to the collection, and the last element, in turn, does not point to any subsequent item. Let's try implementing this structure - I mean items relationship - in the program code.

#### Compatible Values

To answer the second question let me recall that CSharp is a strongly typed language. Every variable and constant has a type. The same applies to formal arguments of methods and the returned value if any. It is also worth stressing that every expression evaluates to a value of a well-defined type at compile time. The main reason for that is that the compiler uses type definition to ensure all operations performed in your code are type-safe. It protects against assigning to variable value that doesn't belong to a set of allowed values predefined by its type. When you declare a variable or constant in a program, you must specify its type or use the var keyword to let the compiler infer the type.  After you declare a variable, you can't redeclare it with a new type, and you can't assign a value not compatible with its declared type.  Concluding, after the creation of a sequence of values all nodes in the sequence must be a wrapper of a value compatible with the selected type. Additionally, it should be possible to select the type randomly.

### Introduction (Node)

Let the representation of a values sequence - that we are talking about - be created using the class `Node`. In this class, the first thing we need to implement is a pointer to the next item in the built-up sequence. I propose to add a reference to the next item as the `Next` property.  The next thing we need to do here is an implementation of common sequence management operations, for example adding new items to the sequence. Let's assume that we add new nodes at the beginning of the sequence and let's do it by engaging the class constructor for this task, which will ensure that the newly created element will be inserted at the beginning of the sequence.

### Wrapped Value (Node)

The last question we have to address is how to represent the values ​​in the sequence. Every instance of the class `Node` in the sequence has to represent a value that is compatible with a selected type. In other words, all values collected by the series using the `Node` class instances must be compatible with each other. By answering this question, we can add a property to the previously defined class representing one item in the sequence that is responsible for the representation of a single value added to the sequence. As the result, the value holder item, namely an instance of the `Node` class plays the role of a wrapper of a single value in the sequence. And here the next question must be raised, what type is this value to be?

### Wrapped Value Type (Node)

The last question we have to address is how to represent the values ​​in the sequence. Every instance of the class `Node` in the sequence has to represent a value that is compatible with a selected type. In other words, all values collected by the series using the `Node` class instances must be compatible with each other. By answering this question, we can add a property to the previously defined class representing one item in the sequence that is responsible for the representation of a single value added to the sequence. As the result, the value holder item, namely an instance of the `Node` class plays the role of a wrapper of a single value in the sequence. And here the first question arises, what type is this value to be?

### Using Object Type (Node)

In case the type is hardcoded if we wanted to change the decision regarding the type or use this functionality again but for another, not compatible type this approach leads to rewriting or cloning this functionality, although it is so universal that we could basically use it to represent values ​​of any type. Rewriting means that we cannot add it to a sharable library. Of course, this obstacle we may overcome by taking advantage of the fact that all types inherit from the `object` type and all are therefore compatible with that type. So this way, we can ensure that the same type, I mean `object`, will be used for any other type while creating a new Node instance. It is not true while reading the saved value from the selected node. Of course, then we do not have the option to choose the type really, because all types are compatible with the type object while assigning a new value to the variable of the type `object`. So, again, the assumption that the types should be compatible is not met, because in this case, we are only applying a workaround that works while adding new values to the sequence but not a generic solution. In other words, this approach makes the solution weakly typed, and finally, it postpones type checking up to the run time. Therefore, we must look for another approach that will allow us to ensure that the type definition is generic in terms of the possibility of using different types on the one hand, and support the possibility to check the compatibility of types at design time on the other hand Sometimes this requirement may be called a type-safe approach.

### Introduction of Generic Type (`Node<TypeParameter>`)

We can achieve it by using a type template with parameters - as here in this example - instead of the definition of a concrete type, the template has a parameter. We may use the template to define new concrete types provided that the formal parameters of the template are replaced by names of concrete types. Again, the idea is to use a parameterized template of a type definition instead of the concrete type definition itself. At this point, angle brackets surround a list of parameter names separated by commas. It is worth stressing now that it is a lexical approach called generic type. Because by design all formal parameters defined between the angle brackets represent a type they can be used in all places where the type identifiers are expected according to the language rules. For example, in the case of a property, we always return a value ​​that is compatible with this type.

### Declaring Type Using Generic Definition (IntSequenceTest)

Let's repeat the question. If we haven't defined the type but only some type template, or a blueprint, then when does the type definition come into existence? To investigate it, I created the test class `NodeUnitTest` in which we will use a test method to create an instance of this generic type. We cannot use generic classes to instantiate them without defining a list of actual types. To reuse this template of a class and declare a new type we must replace the formal parameter of this generic type with an identifier of the existing type. In this case, it is int. The definition using the int type is created by the compiler for us and as a result, we can create the first node of the sequence and assign the reference to the created instance to the variable `firstNode`.  This variable is prefixed with the same type. The variable points to the first node in the sequence. The constructor requires two actual arguments. The arguments of the constructor play the same role as in the classic definition of a type. The first argument provides the reference to the next node in the sequence. In this example, we don't have yet created anyone. The created node is the first and the last one at the same time.  The second actual argument of the constructor is used to assign a value that is to be protected by the sequence.  The type of this argument is determined by the parameter of the generic type.  The actual parameter value and the formal parameter type must be compatible with each another at compile time.

### Using Generic Type (AnyClassSequenceTest)

For the sake of this example, I will try to declare a new type using the previous generic template here. In this example, the `AnyClass` represents a custom type of values to be managed using this sequence. On the left-hand of this statement, we have a variable that is to reference the first node as previously. This variable is prefixed by a generic type with the actual parameter called  `AnyClass`. On the right-hand of the assignment operator, we are trying to instantiate that type to assign the new instance reference to the variable being declared. We can see that we have some issues. The first is due to the fact that the actual parameter of the generic type is unknown. As I said we must use an identifier that identifies existing concrete type declaration. Therefore, let's create such a class locally below in the same file. This way we can ensure that a type definition is implicitly generated by the compiler from the template and this template is generic because we can use the same functionality for different types replacing the type parameters randomly. In other words, the template parameter is only a placeholder for a specific type. To apply this template to create a type definition it has to be replaced with an identifier of any known type. The next two line shows how to add the next node to the sequence and how to check that each node points to a different value.

## SelfDictionary (SelfDictionary)

To improve our understanding of the generic type concept let's dive into the details of a slightly more advanced type definition example. In the previously considered scenario, elements are added to a set engaging the dependencies between them based on a sequence. Therefore, it had the disadvantage that the items were not randomly available. I mean there is no indexer allowing to select freely elements in the set using a unique key. We need to use browsing to implement sequential access. Now let's try to consider another scenario in which the nodes are arranged in such a way that they are randomly selectable. Again, in this context, randomly does' t mean accidentally just freely. In other words, the next item may be selected regardless of which one was selected previously. It means that this time addressing should be used instead of browsing. To do this, I define a new type and use the `Dictionary` type as the base type, so it uses inheritance here. The Dictionary type is already defined in the existing .NET library and has two type parameters. So it is a generic type. The first parameter specifies the type that is used as a key to select individual components. So it acts as an index on a one-dimensional array. The second type determines what values will be stored in this array. Consider a case in which the value itself, i.e. the one we want to store, can also be used as the index. Therefore, there is only one parameter in the newly created generic type. Let's also add a method that adds a new value to the array. At the same time, this operation uses the same value as the index; as the value selector. Let's analyze how the implementation of this scenario will behave using a unit test.

## SelfDictionary Unit Test introduction (SelfDictionaryTest)

For this purpose, let's create a unit test in which we will check the features of the proposed solution. In the window below I added a test method in which we instantiate a new dictionary according to the previously defined type and add two elements to this dictionary. We can check that as a result of this operation there are indeed two elements in the dictionary and we have free access to these elements. The question is how to control, how to select the individual items that are in the dictionary. In this case, it is completely dependent on the implementation of the Dictionary class that the environment provides. It is independent of our needs. The following example shows how to control this process. In other words, how to make sure that a proper item is selected from the dictionary.

## Adding Equatable to improve indexer (SelfDictionaryTest)

A situation in which we have no control over the behavior of the newly created type is not promising and should not be acceptable to us because operation correctness is always our responsibility. If we don't have control the correctness could be questioned. Therefore, let's try to take advantage of the fact that the `Dictionary` - that we used as the base type to derive the new type - may use the `IEquatable` interface if it is implemented by the type of the key to comparing, and therefore also to perform a selection of a value from the dictionary. The implementation of this interface will allow us to restore full control over how elements in the dictionary are organized and how to select individual elements. As this method is not implemented at the moment, the unit test will fail. The test has finished and we can see that the result is actually negative because this method is not implemented and an exception occurs in it. Therefore, let us indicate in the test that we expect such an exception, and thanks to this, the next test result is marked as a success, and therefore we will be sure that the `Equals` method is actually used, it is called. This method is also used to organize elements in the dictionary.

## Main Goal of Unit Test (SelfDictionaryTest)

Now I must stress that the main intent of the presented unit tests is an explanation but not a validation of algorithm implementation. Its role is just to show that the tested code has certain features.

## Where Construct Introduction (SelfDictionaryTest)

Since in the solution, we used particular capabilities of the type that is the parameter for the generic type, a question arises as to how to force situations so that all types used as the actual generic type parameter have this capability. The `where` construct comes in handy here, which allows us to state that the actual parameter that substitutes a formal parameter for the type must inherit from the `IEquatable` interface. As a result, when our type does not meet this requirement, let's remove the inheritance from a specific type. We see that immediately there is a compilation error, which indicates that the required capabilities for the selected type are not present, i.e. our newly created type used as the current parameter does not meet the expectation of the designer, it does not have the capabilities that are required in the definition of the generic type. Accordingly, the `where` clause in this application can be considered as a solution that allows specifying the required capabilities of the type parameters, which can be utilized inside the template. On the other hand, the `where` clause restricts the applicability of existing types if the type doesn't have the required capabilities, so it is also often considered a constraint of actual types.

## Constraints on Type Parameters

- constraints on type parameters c# example
- [Generic classes and methods](https://docs.microsoft.com/dotnet/csharp/programming-guide/generics)

The language-defined constraints that we can use are described in detail in the manual available on MSDN. Ask Google "constraints on type parameters c# example" to get a link to the documentation. The URL to this manual can be found in the support material and is visible on the screen. Below I have added a table summing the where construct semantics. Again, check out the language documentation to get more.

## Generic Methods

Finally, let's mention the generic methods. The syntax and semantics of generic method definitions are very similar to the syntax and semantics of the type definition. An example is the Assert class extensively used in the unit test examples. We also have here, as in the case of types, a list of formal type parameters, which we can then use in each place where we use the type identifier. Again, this parameter is a formal parameter and must be replaced in the calling operations by an identifier of an existing type. We also have a `where` construct, which allows us to specify what type can be the actual parameter.

## Constraints on Type Parameters Syntax

Constraints are specified by using the `where` contextual keyword. The following table lists the seven types of constraints:

| Constraint | Description |
| -----------| ----------- |
| where T: `struct` | The type argument must be a value type. Any value type except Nullable can be specified. For more information, see Using Nullable Types. |
| where T : class | The type argument must be a reference type. This constraint applies also to any class, interface, delegate, or array type.|
| where T : unmanaged | The type argument must not be a reference type and must not contain any reference type members at any level of nesting.|
| where T : `new()` | The type argument must have a public parameterless constructor. When used together with other constraints, the new() constraint must be specified last.|
| where T : \<base class name\> | The type argument must be or derive from the specified base class.|
| where T : \<interface name\> | The type argument must be or implement the specified interface. Multiple interface constraints can be specified. The constraining interface can also be generic.|
| where T : U | The type argument supplied for T must be or derive from the argument supplied for U.|

Some of the constraints are mutually exclusive. All value types must have an accessible parameterless constructor. The `struct` constraint implies the new() constraint and the new() constraint cannot be combined with the `struct` constraint. The unmanaged constraint implies the `struct` constraint. The unmanaged constraint cannot be combined with either the `struct` or new() constraints.

## See also

- [Generic classes and methods](https://docs.microsoft.com/dotnet/csharp/programming-guide/generics)
- [Constraints on type parameters](https://docs.microsoft.com/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters)
