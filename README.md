# OptionalSharp

## Overview

OptionalSharp is a small, lightweight utility library in C#. It helps represent optional values, enhancing code robustness and clarity by eliminating NullReferenceExceptions. Particularly aimed for the S&Box gamemode, Optional<T> provides a more flexible alternative to Nullable<T>.

## Why use OptionalSharp?
Optional<T> clearly indicates when a function might not always return a meaningful result, allowing the caller to handle this in a safe and predictable way. It can be used with both value and reference types, and is enriched with utility methods like Map, Filter, ValueOrElse, borrowed from functional programming concepts.

```csharp
Optional<int> optionalInt = Optional<int>.Of(5);

if (optionalInt.HasValue)
{
    // output: 5
    Log.Info(optionalInt.Value);
}
```

For more details on using OptionalSharp, check out the [Usage Guide](https://github.com/SigmaPLC/OptionalSharp/wiki#how-to-use-optionalsharp) in the wiki.

## Contributing
Contributions are welcome! Please submit a pull request or create an issue to get started.

## License
This project is licensed under the MIT License. See the LICENSE file for details.
