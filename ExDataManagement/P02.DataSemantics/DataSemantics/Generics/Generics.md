# Generics notes

Constraints are specified by using the where contextual keyword. The following table lists the seven types of constraints:

|Constraint	|Description|
|-|-|
|where T: struct| The type argument must be a value type. Any value type except Nullable can be specified. For more information, see Using Nullable Types.|
|where T : class| The type argument must be a reference type. This constraint applies also to any class, interface, delegate, or array type.|
|where T : unmanaged| The type argument must not be a reference type and must not contain any reference type members at any level of nesting.|
|where T : new()| The type argument must have a public parameterless constructor. When used together with other constraints, the new() constraint must be specified last.|
|where T : <base class name>| The type argument must be or derive from the specified base class.|
|where T : <interface name>|The type argument must be or implement the specified interface. Multiple interface constraints can be specified. The constraining interface can also be generic.|
|where T : U| The type argument supplied for T must be or derive from the argument supplied for U.|

Some of the constraints are mutually exclusive. All value types must have an accessible parameterless constructor. The struct constraint implies the new() constraint and the new() constraint cannot be combined with the struct constraint. The unmanaged constraint implies the struct constraint. The unmanaged constraint cannot be combined with either the struct or new() constraints.

# See also
[Constraints on type parameters](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters)