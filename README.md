# Project Euler (C# and Python)
This is a simple project that includes solutions for the first 40 problems on [Project Euler](https://projecteuler.net). Additional problems may be added in the future, but per the site's request problem 100 and above will not be made publicly available. These are straightfoward and hopefully easy to understand solutions, not necessarily optimized.

## Installation
Included is a Visual Studio (2019) [solution](ProjectEuler.sln) containing 4 projects:

- [ProjectEulerPython](ProjectEulerPython/ProjectEulerPython.pyproj) Python (3.7) console application and code
- [ProjectEuler](ProjectEuler/ProjectEuler.csproj) Library containing the C# (Standard 2.0) code
- [ProjectEulerApp](ProjectEulerApp/ProjectEulerApp.csproj) C# (Core 3.1) console application wrapper for the library above
- [ProjectEulerTests](ProjectEulerTests/ProjectEulerTests.csproj) C# (Core 3.1) unit tests for the library above

It should be a simple as using the existing solution to compile for the desired operating system.

## Pertinent Files

- [project_euler.py](ProjectEulerPython/project_euler.py) and [Program.cs](ProjectEulerApp/Program.cs) demonstrate how to execute a given problem
- [ProjectEulerPython/problems](ProjectEulerPython/problems) and [ProjectEuler/Problems](ProjectEuler/Problems) are directories containing a file/class for each problem

