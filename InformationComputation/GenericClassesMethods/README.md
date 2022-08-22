# 1. Generic Types and methods

## 1.1. What is the problem?

In this lesson, we focus on generic types and methods. They are especially important because they expand object-oriented programming somehow and consequently extend our possibilities of reusing the previous results making them reusable. And this, as we know, decreases the total costs of software development.

As usual, let's start by defining the problem.

## 1.2. Inheritance

We know that the possibility of reusing the results of previous programming work is extremely important. Because in addition to improving economic efficiency, it is beneficial to reliability and minimizes training costs. This problem is one of the reasons for the wide leveraging of the concept of object-oriented programming, which introduced the inheritance paradigm, that is, the ability to reuse a predefined type called a base type to create a derived type. In previous lessons, we learned that a type is a collection of values and operations on those values. Simply put, in the case of inheritance, a derived type takes over the characteristics of the base type and allows you to add new and modify the existing functionality. You can also extend the set of values, that is, the set of values of the derived type contains a set of values of the base type.

## 1.3. Representing a Sequence of Compliant Values

Now I propose to consider a scenario in which we want to represent a sequence of values, a sequence of compatible values. In this case, inheritance is of little use because the inheritance can be applied to expand only a single type. The derived type is considered compatible with the base one but it is not a sequence. The sequence is made up of many values of different types. The only assumption is that all the values must be of compatible types. The main reason is that we can reuse the sequence management functionality. But before that, two questions arise. The first question is:

- what is a sequence of values?

and the second question:

- what are compatible values?

In general, the sequence is an ordered collection of entices in which each collection member knows the next one. In such a relationship, the last and the first must be distinguished because the first element is not pointed out by any item belonging to the set, and the last element, in turn, does not point to any subsequent item. Let's try implementing this structure - I mean items relationship - in the program code.

### 1.3.1. Introduction Node

Let the representation of a values collection - we talked about previously - be created using the class `Node`. In this class, the first thing we need to implement is a pointer to the next item in the built-up sequence. I propose to add a reference to the next item as the `Next` property. Another thing we need to implement is representation of the first item. Let's do this with the static `First` property. And the last thing we need to do here is an implementation of common for the whole sequence operations, for example adding new items to the sequence. Let's assume that we add elements at the beginning of the string and let's do it by engaging the class constructor, which will ensure that the newly created element will be inserted at the beginning of the series. The last question we have to resolve is how to represent the values ​​in the string. Every instance of the class `Node` in the sequence has to represent a compliant value. In other words, all values collected by the series of the `Node` class instances must be compliant with each other.

### 1.3.2. Wrapped Value

By answering this question, we can add a property to the previously defined class representing one item in the sequence that is responsible for representation of a single value added to the sequence. As the result, the value holder item, namely an instance of the `Node` class plays the role of a wrapper of an independent value. And here the first question arises, what type is this value to be.

### 1.3.3. Wrapped Value Type

And here the first question must be raised, what type is this value to be? Since we have made the assumption that ​​in the sequence must contain only compatible values with a certain selected type we may  select this type here. For the purposes of this lesson, I will simply define a new type, which I will consider the selected type. This allows me to represent only values ​​in this sequence that are compliant with it. In order words, for the created instance to represent the value of a selected type, the value compatible with the selected type should be added here with a parameter that will allow me to add this value when creating a new element. It leads to hardcoded the base type of values that can be added to the sequence. This approach has a disadvantage in that this definition cannot be reused for other types. Let me stress here. The sequence has contain compliant values but it is not required for independent sequences. In other words, while creating a next sequence the base type of the stored values is not required to be related to the type used for other sequences.

### 1.3.4. Wrapped Value Type Change

If we wanted to change the decision regarding the type or use this functionality again but for another not compliant type using this approach leads to rewriting or cloning this functionality, although it is so universal that we could basically use it to represent values ​​of any type. Rewriting means that we cannot add it to a sharable library. This can be solved of course by taking advantage of the fact that all types inherit from the object type and are therefore compatible with that type. So this way, we can ensure that the same type will be used for any type. Of course, then we do not have the option to choose the type really, because all types are compatible with the type object. So, again, the assumption that the types should be compatible is not met, because of course in this case we are only applying a workaround but not a universal solution. In other words, this approach makes the solution closely typed and finally postpones type checking up to the run time. Therefore, we must look for another approach that will allow us to ensure that the type definition is generic in terms of the possibility of using different types on the one hand, and on the other hand, so that we do not lose the possibility of checking the compatibility of types at design time. Sometimes this requirements may be called type safe approach.

### 1.3.5. Using Generic Type

This can be achieved by using a template with parameters - as here in this example - instead of the definition of a concrete type. This template may be then used again to define new concrete types provided that the formal parameters are replaced by concrete types identifiers. Again, the idea is to use parameterized type definition template instead of the concrete type definition. At this point between angle brackets, we can specify the parameter. I will investigate this approach in detail.

It is worth stressing now that it is a lexical approach called generic type.

Because all parameters defined between the angle brackets represent a type they can be used in all places where the type identifier can be used according to the language rules. For example, in the case of a function, we always return values ​​that are compatible with this type. Instead of the identifier of a concrete type, we also can specify a parameter for the return values.

This way we can ensure that a type definition was created and this definition is universal because we can use the same functionality for different types replacing the type parameters of the generic definition. In this example, the `ClassA` represents a type. In other words, it is only a placeholder for a specific type. To apply this template to create a type definition has to be replaced with an identifier of any known type.

To improve our understanding of the concept of the generic type let's dive into details of a slightly more complicated type definition example.

### 1.3.6. Defining Type Using Generic Definition

Let's repeat the question. If we did not create the type before, only some type template, or a blueprint, then when does the type definition comes into existence? To investigate it, I created a test class in which we will use a test method to create an instance of this generic type. So we have a test method, and we add the identifier of the class template, which is a generic type. And here's where we need to already declare, refer to an existing type. We cannot use generic types to instantiate them without defining a list of actual types. For the sake of this example, I will declare a class that does not exist. Here we have some variable name preceded by a generic type, and we are trying to instantiate that type to assign the instance references to the variable being declared. We can see that we have two issues. The first is due to the fact that there is no such class, and we must use an identifier for the existing type definition. Therefore, let's create such a class locally below in the same file.

### 1.3.7. Instantiating Generic Type

On the right, we have an error all the time, because a parameter is required for this constructor. This parameter is used to provide a value that is to be added to the sequence. In this case, it is an instance of the classA. Again let's create an object of this class, i.e. classA. Thanks to this, first of all, we showed that this is a place where a new type is emerging. Here we already have specific values and a specific set of operations that will be represented by classA. ClassA has been declared and has been defined. On the right, we have created an object that is attached to the sequence as the first item.

## 1.4. Instantiating new sequences

The proposed solution meets the requirements we discussed previously. However, it has one major disadvantage, namely, it does not allow creating another instance of the sequence in concern. In other words, it does not allow building two sequences at the same time. Answering this question is your homework. Try to modify the proposed definition to fulfill this requirement.

## 1.5. SelfDictionary

In the previously considered scenario, elements are added to a set engaging the dependencies between them based on a sequence. It, therefore, had the disadvantage that the items are not randomly available. We need to use browsing to implement sequential access. Now let's try to consider another scenario in which the nodes are arranged in such a way that they are randomly selectable. In this context, randomly does' t mean accidentally just freely. Again, the next item may be selected regardless of what the previous item was selected. In other words, this time addressing should be used instead of browsing. To do this, I define a new type and use the `Dictionary` type as the base type, so it uses inheritance here. The Dictionary type is already defined in the environment and has two type parameters. So it is a generic type. The first parameter specifies the type defining a set of values that are used as a unique key to select individual components. So it acts as an index on a one-dimensional array. The second type determines what values will be stored in this array.

Consider a case in which the value itself, i.e. the one we want to store, will be also the index. Therefore, there is only one parameter in the newly created generic type. Let's also add a method that adds a new value to the array. At the same time, this operation uses the same value as the index; as the value selector. Let's analyze how the implementation of this scenario will behave. For this purpose, let's create a unit test in which we will check the features of the proposed solution.

## 1.6. `DictionaryNotImplementedExceptionTestMethod`

In the window below I added a test method in which we instantiate a new dictionary according to the previously defined type and add two elements to this dictionary. We can check that as a result of this operation there are indeed two elements in the dictionary and we have free access to these elements. The question is how to control how to select the individual items that are in the dictionary. In this case, it is completely dependent on the implementation that the environment provides. It is independent of us. The following example shows how to control this process. In other words, ho two make sure that a proper item is selected in the dictionary.

## 1.7. `DictionaryNotImplementedExceptionTestMethod`

A situation in which we have no control over the behavior of the newly created type is not promising and should not be acceptable to us because operation correctness is always our responsibility. If we don't have control the correctness always could be questioned. Therefore, let's try to take advantage of the fact that the `Dictionary` - that we used as the base type to define our new type - may use the `IEquatable` interface if it is implemented by the key type to compare, and therefore also to perform selection of a value from the dictionary. The implementation of this interface will allow us to restore full control over how elements in the dictionary are organized and how to access individual elements. As this method is not implemented at the moment, the unit test will fail. The test has finished and we can see that the result is actually negative because this method is not implemented and an exception occurs in it. Therefore, let us indicate in the test that we expect such an exception, and thanks to this, the next test result is marked as a success, and therefore we will be sure that the `Equals` method is actually used, it is called. It is used to organize elements in the dictionary.

## 1.8. The main goal of the unit test `DictionaryNotImplementedExceptionTestMethod`

One thing that must be emphasized here, is that the unit test I showed here was not used to check the correctness of the implemented algorithm, to check the correctness of the code. Its role is just to show that the tested code has certain features.

## 1.9. `DictionaryNotImplementedExceptionTestMethod`

Since in our solution we used a certain feature for the type that is the actual parameter for the generic type, the question arises as to how to force situations so that all types used as the actual argument actually have this feature. The `where` construct comes in handy here, which allows us to state that the actual parameter that substitutes a formal parameter for the type must inherit from the `IEquatable` interface. As a result, when our type does not meet this requirement, let's remove the inheritance from a specific type with the analyzed solution and we see that the program immediately shows compilation errors, which indicate that the features for the selected type are not present, i.e. our newly created type used as the current parameter does not meet the requirements, it does not have the features that are required in the definition of the generic type. Accordingly, the `where` clause in this application can be considered as a solution that allows specifying the type, which will then be used as a current parameter for the defined or defined formal type. On the other hand, the `where` clause restricts the applicability of actual types, so it is also often considered a constraint of actual types.

## 1.10. Constraints on type parameters

The language-defined constraints that we can use are described in detail in the manual available on msd. Ask Google "constraints on type parameters c# example" to get to link to the documentation. The URL to this manual can be found in the support material and is visible on the screen. Those that are required to understand other examples provided during the course we discussed while working with the code. Again, check out the documentation to get more.

## 1.11. Generic methods

Finally, let's mention the generic methods.

The syntax and semantics of generic method definitions are very similar to the semantics and syntax of a type definition. We also have here, as in the case of types, a list of formal type parameters, which we can then use in each place where we use the type identifier. Again, this parameter is a formal parameter and must be replaced in the calling operations by the identifier of the existing type. We also have a `where` construct, which allows us to specify what type can be the actual parameter.

## 1.12. Homework (19'38")

Finally, a few topics that I propose as a homework. First, I suggest modification of the `Node` class so that it is possible to create multiple strings at the same time. Another task is to implement an algorithm that will allow for centralized management so that the user of the class cannot decide about the order of the elements, change the order of the elements and, therefore, lead to a situation where the user cannot externally violate the rules that this algorithm implements. This condition is important from the point of view of unit tests because guarantees that the test result doesn't depend on the history of the user activity. Also, a more advanced topic is the possibility of inserting elements between elements that are currently in the string. I propose also to learn about generic methods in more detail. The best way to do it is to write unit tests for them. For both cases, both for classes and for methods, the detailed knowledge of the `where` construction will certainly be very useful in the application, where we specify the features of the type that can be used instead of the formal type, as a current parameter.

## 1.13. That's All for Now

And that's all for this episode, this lesson. Thank you for your time and I invite you to listen to the next lessons.