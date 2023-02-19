# OGA.SharedKernel
Base Shared Libraries for various project types.

## Description
The intention of this library is to be the bottom layer of a process stack, providing the most common, base classes and interfaces for all layers above it (domain, infrastructure, API, and process).\
Specifically, this library was put together to be the exclusive reference for any Domain library, allowing the domain logic to be free of other assembly references.

This library includes the following classes and elements that can be consumed:
* Date Time Utility extension class for truncating timestamps as needed for compatibility across backends.
* Some attribute classes used to decorate entities and other classes.
* App Path class, for global acesss to app path data within a runtime.
* Build Data class, for global acesss to process build data within a runtime.
* A set of base exceptions and business exceptions that can be used by all project types.
* A logging base to make logging accessible at the lowest layer of a project, the domain entity layer.
* The App Data class was moved here, so that all layers of a process can access it.
* The Stacktrace class is here, which can be used to provide additional callsite metadata for logging diagnostic messages, when a PDB is not present with process binaries.
* The Pagination Filter class is here, which allows result pagination to occur at the domain layer.
* Service interfaces, are here, such as the URI service.
* Global constants class for exposing company and application metadata to the entire process stack.
* A Return Data class, that allows a method to return a result and a message without a REF or OUT argument.

## Installation
OGA.SharedKernel is available via NuGet:
* NuGet Official Releases: [![NuGet](https://img.shields.io/nuget/vpre/OGA.SharedKernel.svg?label=NuGet)](https://www.nuget.org/packages/OGA.SharedKernel)

## Dependencies
This library depends on:
* [NLog](https://github.com/NLog/NLog/)

## Building OGA.SharedKernel
This library is built with the new SDK-style projects.
It contains multiple projects, one for each of the following frameworks:
* NET Framework 4.5.2
* NET Framework 4.7
* NET 5
* NET 6

And, the output nuget package includes runtimes targets for:
* linux-64
* win-x64

## Framework and Runtime Support
Currently, the nuget package of this library supports the framework versions and runtimes of applications that I maintain (see above).
If someone needs others (older or newer), let me know, and I'll add them to the build script.

## Visual Studio
This library is currently built using Visual Studio 2019 17.1.

## License
Please see the [License](LICENSE).

## Opinionation Apology...
This library references NLog, directly, for now.\
I understand this may appear overly opinionated, at the bottom layer of a process stack. I agree... though, NLog works very well.\
Once I get a chance to circle back, and work through a more agnostic logging interface, I will update (removing the specific logger tie).

You're welcome to swap out and compile whatever logger you'd like, of course.\
If you have the need or feel inclined, send me feedback or a pull, so I know it helps someone, to make time and generalize the logging layer.
