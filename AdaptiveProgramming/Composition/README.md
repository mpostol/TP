# Application composition

## `commonservicelocator`

### Assumptions

Using `commonservicelocator` the following assumptions are hold

- the library doesn't depend on a concrete container - it is only client-side
- the footprint is small
- lack of service locator is mitigated by the default implementation of the services
- it can be easily implemented for any kind of container.

### See also

- [Microsoft.Practices.ServiceLocation](https://github.com/unitycontainer/commonservicelocator)
  - solution in concern
  - don't require a concrete container
  - can be easily implemented  for any container
- [Martin Fowler; Inversion of Control Containers and the Dependency Injection pattern](https://martinfowler.com/articles/injection.html)
  - describes the `ServiceLocator` as an embedded part of the DI - I agree
- [Service Locator is an Anti-Pattern by Mark Seemann](https://blog.ploeh.dk/2010/02/03/ServiceLocatorisanAnti-Pattern/)
  - don't agree - there are a lot of errors and misunderstandings
- [Dependency injection in .NET Core console applications](https://gunnarpeipman.com/dotnet-core-dependency-injection/)
  - in not .NET API Browser
  - depends on `Microsoft.Extensions.DependencyInjection`
  - implements container `ServiceCollection`
