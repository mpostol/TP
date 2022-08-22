# 1. Program Layered Architecture

## 1.1. What is the problem ?

A computer program begins its life cycle as a text that follows the rules of a selected programming language, for example, CSharp. In order to improve the performance of the program development process, often the text of the program is organized into autonomous fragments hierarchically related to each other creating a layered model. In this architecture, each layer refers only to the layer below. Of course, there is no reference to the top layer. Similarly, the bottom layer doesn't refer to any layer.

It's just theory but from the practical point of view, we need to answer a few questions to follow up and apply this architecture.

First is what benefit we should expect compared with the program that is just messy. We are expecting measurable benefits. It could be even better if we can prove that this architecture is mandatory for some reasons.

The second question is how this architecture should be implemented to be rewarded by finally receiving the expected benefits.

For a typical architecture, we may distinguish the following layers:

- **Presentation** - responsible for managing the communication with the user using the graphical interface
- **Logic** - responsible for the implementation of a dedicated algorithm related to the processing process in concern
- **Data** - responsible for accessing data representing the process state and behavior information typically managed by the file system, computer network, custom communication interfaces, and databases to name only the most common.

This design pattern on the screen is clear and doesn't need any special education background or explanation to understand it but it is only an example. Hence, my proposal is to use it for further discussion but keeping in mind that it is only an example.

Concluding the discussion on "what is the problem", shortly, we should ask questions about why and how in relation to the not distributed layered program architecture.

## 1.2. Program architecture (theory, slideshow)

### 1.2.1. Information Processing

To deploy the automation of information processing - let me remind you that it is main goal of the software developer job - we have to engage a computer. To be helpful in solving our problem the computer needs to execute a program. Computation is the process of running a program. It is a run-time stage of the program development process. A computer program is a piece of software that is designed, developed, deployed, and maintained by us as a community or even team job responsibility.

### 1.2.2. Algorithm

The program development should be commenced by researching knowledge helpful to solve our problem or achieve the computation goal. This knowledge as one whole we call algorithm. A very useful concept while working on the algorithm is a separation of concerns. From sociology we know, that it improves our performance of thinking because thanks to the separation of concerns we may think about independent topics with minimal overlapping between them. So to improve our productivity at algorithm design time we must leverage separation. It is important because by improving productivity we are decreasing development costs and decreasing probability of the failure in the long run. Finały as a result we are reducing development costs.

### 1.2.3. Program

Unfortunately, usually designing an algorithm and its implementation are tightly coupled with each other and cannot be disjointed. It could even happen that after finishing the work on the program text the next step is to document the algorithm implemented by the program. It is not hard to imagine iteration in this respect. Anyway, at the end of the day, we must have a program executed by a computer for the information processing automation purpose. Simplifying we can recognize the program as a text compliant with selected programming language semantics and syntax rules. Additionally, before it may be used by a computer it must be converted to a binary executable form because each computer is a binary machine. Usually, this transformation and validation are accomplished thanks to a compiler that is responsible to build the outcome of our work and is aware of the programming language in concern. It is worth stressing that only errors free text could be recognized as a computer program. If the compiler complains about the correctness of text it is just a sequence of characters but not a program worth further analysis against its meaning, against semantic rules.

### 1.2.4. When and where

Unfortunately, this introduction doesn't explicitly answer the question of when and where we should deal with the separation of concerns - while thinking about the solution or while implementing it as a text. The only thing that is out of the discussion is that it is very beneficial to apply separation of concerns. What's more, shortly I will try to prove that it is also necessary for some reasons. To prove that something is necessary - or stressing this statement it is required - we need an easily verified condition. A typical condition in this respect should sound like this: without implementation of the separation of concerns concept it will be impossible to ......

### 1.2.5. Introduction to Layered architecture

Concluding, implementing the separation of concerns concept in practice we must deal with a program, but not only with the design thinking. A computer program begins its life cycle as a text that follows the rules of a selected programming language, for example, CSharp. In order to improve the performance of the program development process as a result of applying the separation of concerns concept, often the text of the program is organized into autonomous fragments hierarchically related to each other creating a layered archetype. In this architecture, each layer refers only to the layer below. Of course, there is no reference to the top layer at all. Similarly, the bottom layer doesn't refer to any layer because there is npo layer below. The layered program design pattern is clear and doesn't need any special education background or explanation to understand it but it is only an example. Hence, my proposal is to use it for further discussion but keeping in mind that it is only an example how to deploy the separation of concerns in practice.

### 1.2.6. Layers relationship

To have layers we must be able to distinguish the vertical hierarchy, position of the layer in a stack. For example, top layer, bottom layer, middle layer, etc. Doesn't matter what the layer means. It could be books or carpets, or autonomous program fragments. Hence, in the layered arrangement, the most important thing is the unidirectional top-down relationship. In a layered architecture, layer relationships could be recognized as a directed association. The directed associations are a relationship between entities that are navigable in only one direction, from top to bottom. Transferring this concept to the program a directed association indicates that control flows from the upper layer to the layer directly below it. A most common form of a directed association is a solid line with an arrow that indicates the direction of navigation and the top-down relationship. Sometimes the top-down relationship is abstract, but always it exists. For the picture on the paper or on screen, it is obvious but for the program text, it could not be so clear.

### 1.2.7. Second Benefit - Simultaneous development

Because the implementation of the layers are independent we may consider simultaneous development of them to reduce design time and again make the development process chipper. Simultaneous layer development, following the more general concept called Simultaneous Product Development (SPD), is a design collaboration method in which team members work in parallel, synchronously, or asynchronously, to create and finalize product. Simultaneous means occurring, operating, or done at the same time. Finally we can reduce the time to market by reducing the time needed for development.

### 1.2.8. Abstract Layer Interface

To develop layers independently the development scope or responsibility of layers must be precisely defined to avoid implementation overlapping or gaps. More specifically at the end of the day the independently developed layers must fit each other to fulfill the correct control flow from the upper layer to the layer below. The second problem with simultaneous development we have is how to start the development of the upper layer without knowing how to pass the control to the layer below. There is no many ideas how to deal with that, namely we must have a sort of contract. It must be abstract because we don't have yet implementation. According to main assumption, we have to consider that the development of the layer below is underway or even has not yet started.

### 1.2.9. Application Layer Interface

This requirement provides a very good reason to apply object-oriented programming to accomplish it. The main ideas behind the Object-Oriented Programming concept are encapsulation, abstraction, inheritance, and polymorphism. Let me stress that the mentioned above abstraction is one of them. How to apply abstraction depends on the programming language, but in most languages, I know we may use constructs like interfaces and abstract classes that may be used to deliver abstract definitions. By design, we can recognize abstraction as hiding the implementation details. It suits very well to our simultaneous development scenario because having abstract definitions makes independent implementation possible. How to realize the abstract interface of a layer we will investigate shortly using the examples available in the associated repository.

### 1.2.10. Layer Testing

Unfortunately, it doesn't solve all our problems because being compliant with the abstract definition is not enough to prove that the layer implementation is compliant with the expectation usually expressed as requirements. This may be accomplished using testing. But for testing of the selected layer, first, we must remove dependency on the layer that is located below the tested one. More precisely, we must replace dependency on this layer implementation only. In other words, we must provide quite a new implementation for the testing purpose to replace the implementation developed for production purposes. It is a perfekt example of polymorphism.

### 1.2.11. Inheritance and polymorphism

There are two next very useful ideas behind the object-oriented programming that are necessary to successfully deploy the layers concept, namely inheritance, and polymorphism. Inheritance is a mechanism where you can derive a new definition from an existing one to share the basics features or implement abstract definitions. Polymorphism is a concept that refers to the ability of an implementation to take on multiple forms. In our case, the first form is for final, production purposes, and the second for testing purposes. The most important for us is that both forms, more specifically both implementations are derived from the same contract, or using object-oriented programming terminology inherit the same abstraction to share the same features.

### 1.2.12. Independent testing

There is one more good reason for leveraging layered architecture. Before shipping our implementation to the post-production processing you must assure the correctness of the proposed solution somehow. Sometimes as proof of correctness we can get a statement like "it just works". Unfortunately, in many cases it is just wishful thinking. However often it means that the outcome has been tested as proof of correctness. As a rule of thumb, you must keep in mind that to prove the implementation correctness testing may be only applied to discover errors but not to prove the correctness of this implementation. Be careful because according to a well-known paradigm there is always at least one more bug in each implementation in spite of intensive testing. Deep dive into testing is far beyond the course scope. During the course, I have limited usage of the testing scope to expose examples features, but not to prove the correctness of the code. Regardless of this, when the test result warns you about an error during testing, thanks to layered program arrangement you are sure that issue source is located inside your implementation of the layer or the testing implementation of the layer below. Let me stress that a bug if any is in your code where you should look for problems, not in the code of your teammate. For sure, testing only your stuff improves the performance of the debugging process.

### 1.2.13. Layers responsibility

Following this introduction to layers let's use the separation of concerns principle to separate the program text into units, with minimal overlapping between the responsibility of the individual units. There are a lot of patterns that could be helpful to implement this idea of separation. One of them I mentioned as an example to define what is the problem, namely layers. Again, we will extensively explore this arrangement of the program as a very important one but kip in mind that it is only an example. So, let's get back to software engineering. You know that usually talking about a layered program we may distinguish three layers: the presentation, logic, and data layers.

- **Presentation** - is responsible for managing the communication with the user using the graphical interface
- **Logic** - is responsible for the implementation of a dedicated algorithm related to the processing process in concern
- **Data** - is responsible for accessing data representing the process state and behavior information typically managed by the file system, computer network, custom communication interfaces, and databases.

### 1.2.14. Deployment stage

Talking about layers I am talking about responsibility but not about the functionality of the layer. The main reason is that the responsibility is just a commitment, it is a promise. It better suits the design process. Functionality may be recognized as a contribution to the behavior but it concerns run-time but not design time. Program creation as a result of the algorithm implementation process is design-time activity therefore I prefer to talk about design time. To be honest I don't think it has an impact on the program development methodology.

### 1.2.15. Presentation Layer

So, get back to a descriptions of the responsibility of layers. The presentation layer is responsible to provide interaction with the computer user. Usually today we are using a graphical user interface but not only. The computers may have many additional devices that we can use. For example, obviously, a screen to present any graphical information but also headphones to play music. There are many reasons why this layer should be separated as an independent unit, namely user interface flexibility, and technology dependence to name only the most important for now.

This layer is also responsible for providing data using a natural language. It is a reason to implement this layer as an independent one. Hence, in this case, it should allow a possibility to replace the communication with the user without any impact on the rest of the program. It makes also the solution more flexible against general user interface requirements, for example, symbols, colors, and screen arrangement. It is not an easy task to deal with the user requirements because the representation is not formal so could be subject to many changes during the life cycle.

### 1.2.16. Logic Layer

Next is the logic layer. Its responsibility is the provisioning of the main functionality of the algorithm related to the application scope. As I said previously, the algorithm is abstract knowledge, but we must implement it somehow. Here the main challenge we must face up is how to distinguish the main functionality from the rest. There is no general answer to this question but we have to have layers. Hence functionality is not a good term as a foundation of the program arrangement using layer. Let me stress here that I don't know any language that has a syntax construct that we can call functionality. We have instructions, statements, methods, procedures, classes, etc. Even in some languages, we are using the function term but not functionality. It is the next reason I am using the term responsibility instead of functionality. It is harder to make mistakes.

### 1.2.17. Data Layer

The data layer is the bottom one in this architecture. The name could change but by design, the responsibility is always the same. The data layer is responsible for allowing access to the data managed using available local or remote resources. For example files, networks, or databases. Remote resources could be determined as relevant equipment for the distributed systems. The outline of the distributed systems is out of this course scope, so we may safely remove remote resources from the discussion. The same is with the network. Fortunately thanks to the program execution environment usually we may employ remote resources as local ones.

### 1.2.18. Layers relationship explained (SPP)

To follow the layers pattern the presentation uses only logic. The relation is there must be a relationship between these two layers and this relationship| is only one direction. For example, it is incorrect to put another arrow here and say that the logic uses also presentation because in this case it is against the layered pattern. It is hard to say that the presentation is above of the logic. So let's erase this. It is the only allowed direction. So first talking about the layers we must prove that we have relationship between the layers. How to prove when we are talking about the program. I will try to help you answer this question shortly.  It's not enough we need more details about the text and how the text is organized. Because we need in this text constructs aggregation of this construct and relation between this construct. in this language so we must refer to the syntax of the language but it is required if you are talking about layers you need this relationship. It is also not allowed to provide this relation (presentation => data) because in this case we don't know if for the presentation the layer below is logic or alternatively data because both are on the same level. Therefore it is also not correct. The only possibility is that the upper layer refers to the layer below and only below. It is the only possibility of the relationship.

### 1.2.19. Accommodation of technology change

It is obvious that technology will change over and over. It is a continuous process. So very vital question is how to be prepared for technological change. Layered architecture could be a real relief because we can replace only the affected layer after the technology change. It is especially important for the presentation and for the data layers because additionally, we may distinguish many kinds of data. For example, archival data, input data, output data, and temporal data should bother within this program layer. Again, it is very vital to have any possibility to replace the data layer without impact on the functionality realized by the logic layer. Separation of concerns could help fulfill this requirement provided we know how to implement it.

### 1.2.20. Scalability

The next reason to apply the layered archetype is the possibility to make scalability deployment easier. I will get back to this topic later but now as an example, we could only mention the possibility to spread the layers execution to different computers.

## 1.3. 👉🏻 Deployment Layers (practice code)

### 1.3.1. Deployment stage run-time or design-time alternatively 👌

First I must remind you that the algorithm development is far beyond the course scope. The main goal is to apply the separation of concerns rules directly to the text development but as a result of the implementation of the solution derived from a research process, shortly algorithm. The second observation is that to make the course practical we must apply the layered architecture to the program text but not to the thinking process. I propose to do it in the context of the selected language semantics. In spite that we are using a concrete development environment, the main hope is that this approach is easily portable to at least all the strong typed languages. The examples has been added to the project that calls.

### 1.3.2. 👉🏻 What the layer is? ✍🏻

From the theoretical lecture, we know that layered program architecture is very beneficial and should be implemented based on a very general concept called separation of concerns. Simplifying, by design, the separation of concerns applies to the way of thinking, but as software developers, we need to implement it as an architecture of the program. Program is just a text compliant with a selected programming language. In our case it is CSharp. Hence the architecture including the relationship of layers must be expressed using terminology defined by the language itself. In other words, talking about functionality and responsibility is perfectly OK if we talk about the algorithm but not the program.

### 1.3.3. Layer implementation in context of programming language

Languages offering object-oriented programming usually use types as a construct that takes responsibility for provisioning required functionality. Because further discussion may depend on the selection of concrete programming language. Further discussion I will conduct using CSharp as the language and Visual Studio as the development environment. Check out the project to follow me in this respect.

### 1.3.4. layer as a set of custom types definitions

From these examples, it is easy to figure out that I propose the implementation of a layer as a set of custom types definitions. In Maths, sets are a collection of well-defined entities called members of a set. In the proposed case the well-defined entity is a custom type - a language construct. The set notion is derived from the mathematical theory and is well known from the background school, hence we may skip further dip dive into this theory. The only important thing is how to recognize the membership. There must be a boundary that we can use to distinguish if the type belongs to the selected set or not. To make the layer unambiguous it must be assumed that the type belongs only to one set. This way we can convert the discussion about mathematical stets to a discussion about types grouping. On the screen, you can see a few custom types definitions and now we must answer a question about how to recognize the membership of types to groups now called layers. In other words the fact of being a member of a selected group.

### 1.3.5. namespace construct as the set boundary

The namespace construct could be a relief to help answer this question. Namespaces are used to organize and provide a level of separation of code parts and to avoid name collisions. The namespace name could be used as a prefix of the definition identifier to make the definition name unique to the program scope. They can also be considered as a container that consists of definitions.  This concept perfectly fits the concept of definitions grouping or more formally enforcing set membership of types.

### 1.3.6. Relationship implementation

Collecting custom definitions using namespaces to implement layers as the program architecture is only the first part of the solution. We have to implement also unidirectional top-down relationship. In the case of treating customs definitions as members of a layer, it may be accomplished very easily because definitions are related to each other using bidirectional relationships. It is your responsibility to limit the freedom of direction of the relationships between definitions to follow the rules defined previously for layers.  Let me stress to implement this hierarchical and layered architecture the definitions belonging to one layer should refer only to definitions belonging to the layer directly below.

### 1.3.7. Selection of layer membership

So any discussion about the layers we must be conducted in the context of  definitions expressed as a text according to the selected programming language.  For example, the presentation layer must contain part of the program text responsible for the implementation of the user interface but the question is which one? Which one part of the program should be aggregated by the presentation layer? Of course on the one hand it could be related to the main responsibility of this layer that at the end of the day it ensures required functionality at run-time. In the meantime, the responsibility must be implemented as a set of definitions organized and separated as one unit using namespaces. As we did prove previously it is very clear how to create layers using definitions grouped by namespaces. The real mystery of software development is aggregation and separation of definitions to precisely cover the layers of responsibility.  Therefore working on an algorithm and its implementation is usually a tightly coupled process with others and needs an iteration approach.  Because responsibility and functionality are abstract terms it is very difficult to prove that we have aggregated all the appropriate functionality as layers. In summarizing, talking about layers we are talking about a set of definitions grouped together and separated from other layers using a namespace concept. I believe that this approach is pretty universal and easily portable to other languages.

### 1.3.8. Layers Relationship implementation

According to the the layered pattern the presentation uses only logic. To illustrate the relationship we may put and arrow over here.  It is worth stressing that this relationship is unidirectional. For example, it is incorrect to put another arrow here in the opposite direction and say that the logic uses presentation layer because it is no compliant with the layered pattern  because having two arrows it is hard to say that the presentation is above the logic. Saying that the logic layer is above the presentation layer is also correct. So we must erase this arrow. Again, top-down It is the only allowed direction. Talking about the layers we must prove that we have a relationship between the layers. How to prove when we are talking about the program. I will try to help you answer this question shortly.  It's not enough we need more details about the text and how the text is organized. Because we need in this text constructs aggregation of this construct and relation between this construct. in this language so we must refer to the syntax of the language but it is required if you are talking about layers you need this relationship. It is also not allowed to provide this relation (presentation => data) because in this case, we don't know if for the presentation the layer below is logic or data because both are on the same level. Therefore it is also not correct. The only possibility is that the upper layer refers to the layer below and only below. It is the only possibility of a relationship.

### 1.3.9. Application Layer Interface (ALI) ✍🏻

### 1.3.10. Abstract (ALI)

### 1.3.11. Implementation for testing purpose

### 1.3.12. Removing the dependence on implementation od the layer below

## 1.4. That's all for now

That's all about the implementation of the algorithm using a layered program. To be honest, it could be done using the partial mesh approach but thanks to layers the following benefits may be accomplished

1. separation of concerns
2. simultaneous work on the development of the layers
3. scalability - it is easier to spread the functionality to different computers
4. independent testability
5. improves diagnostic
6. accommodation of technology change

All of them make development faster, more reliable, and finally cheaper. Thank you for your time.