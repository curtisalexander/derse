# derse

A terse summary of a directory (non-recursive).

## Background

This is a simple application experimenting with [.NET Core 3](https://dotnet.microsoft.com/download/dotnet-core/3.0), [F#](https://fsharp.org/), and [Argu](https://fsprojects.github.io/Argu/). In fact, the idea for the functionality is based on a suggested exercise working with [collections](https://livebook.manning.com/book/get-programming-with-f-sharp/chapter-16/) from [Get Programming with F#](https://www.manning.com/books/get-programming-with-f-sharp).

## Usage

From Argu.

```
USAGE: derse [--help] --directory <directory>

OPTIONS:

    --directory <directory>
                          Directory to create summary
    --help                display this list of options.
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

In addition, error checking to see if the `--directory` passed in exists and is truly a directory needs to be added. It is assumed that at least 1 directory and at least 1 file within a directory exists. May need to use other functions from the `Seq` module such as `Seq.choose` in order to work with [Option](https://msdn.microsoft.com/visualfsharpdocs/conceptual/core.option-module-%5bfsharp%5d) types.

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

Now because of [.NET Core 3], we can publish as a [single exe](https://devblogs.microsoft.com/dotnet/announcing-net-core-3-0-preview-5/).

```
dotnet publish -r osx-x64 -c Release /p:PublishSingleFile=true
```

To test.

```
bin/Release/netcoreapp3.0/osx-x64/publish/derse --help
```

How large is the file?

```
du -sh bin/Release/netcoreapp3.0/osx-x64/publish/derse
```

It is coming in at `80M`. Yikes!

## Tree shaking

Reduce the size of the exe. Edit the `derse.fsproj` file. Add the tags `<PublishTrimmed>`, `<PublishReadyToRun>`, `<PublishSingleFile>`, and `<RuntimeIdentifier>`.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.0</TargetFramework>
    <PublishTrimmed>true</PublishTrimmed>
    <PublishReadyToRun>true</PublishReadyToRun>
    <PublishSingleFile>true</PublishSingleFile>
    <RuntimeIdentifier>osx-x64</RuntimeIdentifier>
  </PropertyGroup>
  <ItemGroup>
    <Compile Include="Arguments.fs" />
    <Compile Include="Dir.fs" />
    <Compile Include="Program.fs" />
  </ItemGroup>
  <ItemGroup>
    <PackageReference Include="Argu" Version="5.5.0" />
  </ItemGroup>
</Project>
```

Test again.

```
bin/Release/netcoreapp3.0/osx-x64/publish/derse --help
```

Check the size again.

```
du -sh bin/Release/netcoreapp3.0/osx-x64/publish/derse
```

Better - at `61MB`.

# Future

## Warp

Can [Warp](https://github.com/dgiagio/warp) [reduce the size](https://www.hanselman.com/blog/BrainstormingCreatingASmallSingleSelfcontainedExecutableOutOfANETCoreApplication.aspx) of the exe?

First, add a [.NET Core global tool](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools).

```
dotnet tool install -g dotnet-warp
```

**Under construction.**
:construction:

## Paket

Figure out use of [paket](https://fsprojects.github.io/Paket/) while still utilizing `.NET Core SDK`.

## Azure DevOps

Push with a [git tag]() and then have DevOps build and cut a release on Github. Add instructions using `curl` to install to the README.
