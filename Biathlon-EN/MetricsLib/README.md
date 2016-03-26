# MetricsLib

Library for distance calculation between n-dimensional vectors represented as arrays of n elements, which comprise the coordinates of these vectors.

## Main elements

### `IDistanceMetric`

The interface defines one method:
```C#
double CalculateDistance(double [] a, double [] b);
```

### `EuclideanDistance`

Class that implements the interface `IDistanceMetric`. The distance is calculated as the square root of the sum of squared distances (differences between respective coordinates) in each subsequent dimension.
See [Euclidean distance](https://en.wikipedia.org/wiki/Euclidean_distance#Definition)

### `TaxicabDistance`
Class that implements the interface `IDistanceMetric`. The distance is calculated as the sum of the absolute values ​​of distances (differences between respective coordinates) in each subsequent dimension.
See [Taxicab geometry](https://en.wikipedia.org/wiki/Taxicab_geometry#Formal_definition)
