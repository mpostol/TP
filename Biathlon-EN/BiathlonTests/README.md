# BiathlonTests

The collection of unit tests for project **Biathlon**.

## PointsDistanceTests

### Dependency Injection

Each test composes `PointsDistance` instance by passing as its constructor's parameter one of `IDistanceMetric` implementations.

## ShootingRangeTests

Contains tests for basic shooting algorithm elements.

### Dependency Injection

For the time of testing additional method with attribute `TestInitialize` creates and composes the objects used in the testing methods:

```C#
[TestInitialize()]
public void Initialize()
```
