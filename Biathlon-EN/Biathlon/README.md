# Biathlon

Console application implementing the task of analysing points representing shots to the target at the shooting range.
It includes a module of calculation of the distance between objects of type `Point`.

## Main elements

### `Measurements/Point`

This class represents a point on the plane, with two coordinates `X` and `Y`.
This is the POCO type class ([Plain Old CLR Object](https://en.wikipedia.org/wiki/Plain_Old_CLR_Object)) or an object which:

* does not need dependencies and attributes from additional libraries
* is not involved in the inheritance relationships with classes from additional libraries
* does not contain business logic
* is unaware of the requirements of data persistence
* is used primarily for data representation

### `Measurements/PointsDistance`

This class was designed in the style of [adapter](https://en.wikipedia.org/wiki/Adapter_pattern) design pattern. It contains one main method:

`` `C #
double CalculateDistance(Point p1, Point p2)
`` `

Its aim is to match the `CalculateDistance(double [] a, double [] b)` method from interface `IDistanceMetric` to be able to perform calculations on different data type.
In this case, the method `CalculateDistance` operates on two objects of type `Point`, not like in the library **MetricsLib**, where classes' methods operate on two n-dimensional vectors.

`PointsDistance` class uses **[Dependency Injection](https://en.wikipedia.org/wiki/Dependency_injection)** technique to pass the object used in calculating distances. `IDistanceMetric` implementation is passed as a parameter to the constructor:

`` `C #
public PointsDistance(IDistanceMetric gauge)
`` `

This way defines _required dependency_ - you cannot create an object of a class `PointsDistance` without passing correct object, because without it you will not know how to calculate the distance.
