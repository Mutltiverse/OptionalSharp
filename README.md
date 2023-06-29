# OptionalSharp
## Overview
OptionalSharp is a small, lightweight utility library in C#. It provides a way to represent optional values that may or may not exist. This Optional type aims to make your code more robust and clear, helping to eliminate NullReferenceExceptions and make it obvious when a value might be absent.

## Usage
To use OptionalSharp, simply wrap your variable with the Optional<T> class. Here's a quick example:

```csharp
Optional<int> optionalInt = Optional<int>.Of(5);
You can check if the optional contains a value:
```

```csharp
if (optionalInt.HasValue)
{
    Console.WriteLine(optionalInt.Value);
}
```

You can also create an empty Optional:

```csharp
Optional<int> empty = Optional<int>.None;
This can be useful when you want to represent the absence of a value, instead of using null.
```

Equals and GetHashCode
Optional<T> overrides the Equals and GetHashCode methods, so you can use them in collections and compare them directly:

```csharp
Optional<int> first = Optional<int>.Of(5);
Optional<int> second = Optional<int>.Of(5);

if (first.Equals(second))
{
    Console.WriteLine("They are equal!");
}
```
## Contributing
Contributions are welcome! Please submit a pull request or create an issue to get started.

## License
This project is licensed under the MIT License. See the LICENSE file for details.
