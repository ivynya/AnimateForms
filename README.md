# AnimateForms

![Travis (.com)](https://img.shields.io/travis/com/SDBagel/AnimateForms.svg?style=flat-square) ![GitHub All Releases](https://img.shields.io/github/downloads/SDBagel/AnimateForms/total.svg?style=flat-square)

![Nuget](https://img.shields.io/nuget/v/AnimateForms.svg?style=flat-square)  ![Nuget](https://img.shields.io/nuget/dt/AnimateForms.svg?label=nuget%20downloads&style=flat-square)

AnimateForms is a lightweight, async library for Windows Forms that provides an easy to use API. This library is inspired by the JS library [anime.js](https://animejs.com), and aims to implement some basic features similar to or functionally equivalent to that library.

Due to general limitations with WinForms, not everything can be as cleanly ported over to this library as I would like, at least immediately. As such, syntax of using the library may change drastically over development in an attempt to make things as neat as possible.

# Installation

Install via NuGet Package Manager: `PM> Install-Package AnimateForms -Version 0.1.0-alpha`

Install using DLL:
- Download the latest library release ZIP files [here](https://github.com/SDBagel/AnimateForms/releases)
- Extract the ZIP and locate the DLL file inside
- In Visual Studio, right click your project's references, and click Add Reference
- Browse locally for the DLL and include

# Usage

Complete code documentation is available [here](https://sdbagel.github.io/AnimateForms/). It should be easy enough to figure out, but there is currently no direct "Hello World" example. Included in this repository are also two demo applications, AnimateForms (not AnimateForms.Core) and NuGetDemo, which uses the latest NuGet package of this library available.
