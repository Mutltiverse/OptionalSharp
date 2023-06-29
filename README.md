# OptionalSharp

## Overview
OptionalSharp is a small, lightweight utility library in C#. It provides a way to represent optional values that may or may not exist. This `Optional` type aims to make your code more robust and clear, helping to eliminate `NullReferenceExceptions` and make it obvious when a value might be absent. This is aimed for the gamemode S&Box.

## Why use OptionalSharp?

`Optional<T>` is designed to represent a value that may or may not be present. It's a way of expressing that a function may not always return a meaningful result and allows the caller to handle this in a safe and predictable way.

When working with value types in C# (like `int`, `bool`, `struct`, etc.), they cannot be null. However, sometimes you might need to represent the lack of a value. The `Nullable<T>` or `T?` types are designed to handle this situation, but they are limited to value types only. They can't be used with reference types, which are nullable by default.

`Optional<T>` can be used with both value and reference types, making it more flexible than `Nullable<T>`. It provides a clear and consistent way to represent the absence of a value, regardless of whether you're working with value types or reference types.

Furthermore, using `Optional<T>` can help make your code more self-documenting. When a method returns `Optional<T>`, it's clear that it might not always return a value. When a method returns a nullable reference type (`T?`), it's not immediately clear whether null is a valid result or an indication of an error condition. This can make the code harder to understand and more error-prone.

Finally, `Optional<T>` can be enriched with utility methods like `Map`, `Filter`, `ValueOrElse`, and more, borrowed from functional programming concepts. This can lead to more expressive, robust, and safer code.

## Usage
To use OptionalSharp, simply wrap your variable with the `Optional<T>` class. Here's a quick example:

```csharp
Optional<int> optionalInt = Optional<int>.Of(5);

// Check if the optional contains a value
if (optionalInt.HasValue)
{
    // output: 5
    Log.Info(optionalInt.Value);
}
```

You can also create an empty Optional:
```csharp
Optional<int> empty = Optional<int>.None;
```

This can be useful when you want to represent the absence of a value instead of using null.

### Map
The Map method allows you to transform the value inside the Optional, returning a new Optional with the transformed value. Here's an example:

```csharp
Optional<int> optionalInt = Optional<int>.Of(5);

Optional<string> optionalString = optionalInt.Map(i => i.ToString());

if (optionalString.HasValue)
{
    // output: "5"
    Log.Info(optionalString.Value);
}
```

### Filter

The Filter method allows you to conditionally filter the value inside the Optional. If the value satisfies the provided predicate, the same Optional instance is returned; otherwise, an empty Optional is returned. Here's an example:

```csharp
Optional<int> optionalInt = Optional<int>.Of(5);

Optional<int> filtered = optionalInt.Filter(i => i > 0);

if (filtered.HasValue)
{
    // output: 5
    Log.Info(filtered.Value);
}
```

### ValueOrElse

The ValueOrElse method returns the value inside the Optional if it exists, or a default value if the Optional is empty. Here's an example:

```csharp
Optional<int> optionalInt = Optional<int>.None;

// output: defaultValue
int value = optionalInt.ValueOrElse(defaultValue);
```

# Contributing

Contributions are welcome! Please submit a pull request or create an issue to get started.

# License
This project is licensed under the MIT License. See the LICENSE file for details.
