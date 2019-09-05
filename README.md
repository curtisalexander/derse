# derse

A terse summary of a directory (non-recursive).

## Background
This is a simple application experimenting with [dotnet Core 3](https://dotnet.microsoft.com/download/dotnet-core/3.0), [F#](https://fsharp.org/), and [Argu](https://fsprojects.github.io/Argu/).  In fact, the idea for the functionality is based on a suggested exercise working with [collections](https://livebook.manning.com/book/get-programming-with-f-sharp/chapter-16/) from [Get Programming with F#](https://www.manning.com/books/get-programming-with-f-sharp).

## Usage

From Argu.

```
here it is
```

## Results
Prints the following information to the console.

* Directory
* Total File Size (not necessarily size on disk)
* Average File Size
* File Count
* File Extensions

## Limitations
The summary is not recursive at the moment.  It is only prints one directory deep.
