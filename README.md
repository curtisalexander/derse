# derse

A terse summary of a directory (non-recursive).

## Background

This is a simple application experimenting with [.NET Core 3](https://dotnet.microsoft.com/download/dotnet-core/3.0), [F#](https://fsharp.org/), and [Argu](https://fsprojects.github.io/Argu/). In fact, the idea for the functionality is based on a suggested exercise working with [collections](https://livebook.manning.com/book/get-programming-with-f-sharp/chapter-16/) from [Get Programming with F#](https://www.manning.com/books/get-programming-with-f-sharp).

## Usage

From Argu.

```
here it is
```

## Results

Prints the following information to the console.

- Directory
- Total File Size (not necessarily size on disk)
- Average File Size
- File Count
- File Extensions

## Limitations

The summary is not recursive at the moment. It is only prints one directory deep.

# Colophon

## Requirements

Download and install [.NET Core 3](https://dotnet.microsoft.com/download/dotnet-core/3.0). For this example, I am utilizing the following versions of software. Note that `Argu` is added within [Project Creation and Dependencies](#project-creation-and-dependencies).

```sh
macOS version:
10.14.6

dotnet core version:
3.0.100-preview9-014004

Argu version:
Project 'derse' has the following package references
   [netcoreapp3.0]:
   Top-level Package      Requested   Resolved
   > Argu                 5.5.0       5.5.0
   > FSharp.Core          4.7.0       4.7.0
```

This is produced from `versions.sh`.

## Project Creation and Dependencies

Create a console application.

```
dotnet new console -lang F#
```

Add Argu as a dependency.

```
dotnet add package Argu --version=5.5.0
```

## Code

Write the code.

## Build and Run

Build and then run to test.

```
dotnet build
```

Then to test.

```
dotnet run -- --directory "/some/random/dir"
```

## Turn into single exe

Now because of .NET Core 3], we can publish as a [single exe](https://devblogs.microsoft.com/dotnet/announcing-net-core-3-0-preview-5/).

```
dotnet publish -r osx-x64 /p:PublishSingleFile=true
```

To test.

```
bin/Debug/netcoreapp3.0/osx-x64/publish/derse --help
```

How large is the file?

```
du -sh bin/Debug/netcoreapp3.0/osx-x64/publish/derse
```

It is coming at `80M`. Yikes!

# Future

:construction:

## Paket

Figure out use of [paket](https://fsprojects.github.io/Paket/) while still utilizing `.NET Core SDK`.

## Azure DevOps

Push with a [git tag]() and then have DevOps build and cut a release on Github. Add instructions using `curl` to install to the README.
