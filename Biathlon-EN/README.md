# Biathlon

The project presents issues:

- Division of the project into testable parts
- Unit tests
- Test Driven Development (test first, then the code)
- Dependency Injection

## Task

Develop an application that for a specified point (representing a shot to the target at the shooting range) will load from standard input pairs of coordinates of successive points. Encountering the first point distant by no more than the specified range is to end positively search: found item to be returned and interpreted as a hit. Encountering a point `(0, 0)` is to break the search negatively: to return an empty point (eg. `null`) that will be interpreted as a lack of hits.

## Solution

For this purpose, there will be prepared following projects:

### MetricsLib

Library for distance calculation between n-dimensional vectors represented as arrays of n elements, which comprise the coordinates of these vectors.

### MetricsLibTests

The collection of unit tests for project **MetricsLib**.

### Biathlon

Console application implementing the task of analysing points representing shots to the target at the shooting range.
It includes a module of calculation of the distance between objects of type `Point`.

### BiathlonTests

The collection of unit tests for project **Biathlon**.