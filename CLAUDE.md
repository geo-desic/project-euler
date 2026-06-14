# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Source control

Do not perform any source control commits (or other git write operations such as push, reset, or branch changes). The repository owner reviews all changes and commits them manually after approval.

## Overview

Solutions to the first 40 [Project Euler](https://projecteuler.net) problems, implemented twice — once in C# and once in Python. Solutions favor readability over optimization. Per the site's request, problems 100 and above are intentionally not published here.

## Build / Test / Run

The `.slnx` solution contains three C# projects plus a Python project.

```bash
# Build the whole solution
dotnet build ProjectEuler.slnx

# Run all unit tests
dotnet test

# Run a single test by name
dotnet test --filter "Name=Answer_Problem007_IsCorrect"
# or by partial match
dotnet test --filter "FullyQualifiedName~Problem007"

# Run the C# app (executes every registered problem in order, logs each answer + timing)
dotnet run --project ProjectEulerApp

# Run the Python app (executes whichever problem project_euler.py invokes at its bottom)
cd ProjectEulerPython && python project_euler.py
```

Logging verbosity for the C# app is controlled by `ProjectEulerApp/appsettings.json` — lower `Logging:LogLevel:Default` to `Debug` to see each problem's per-step `LogDebug` output.

## Architecture

### C# (the primary implementation)

Three projects with a deliberate framework split:

- **ProjectEuler** — the solution library, targets **netstandard2.0**. Contains all problem classes and math/string helpers. Keep this project netstandard2.0-compatible (no `net10.0`-only APIs).
- **ProjectEulerApp** — `net10.0` console host. Uses the .NET Generic Host + a `BackgroundService` (`ProblemWorker`) to run problems. `ProblemWorker` discovers problems by reflection over the library assembly (concrete `IProblem` types, ordered by type name).
- **ProjectEulerTests** — `net10.0`, NUnit. One test per problem asserting the known correct answer.

Problem pattern:
- `IProblem.Answer()` is the non-generic entry point.
- `Problem<T>` (abstract base) takes an `ILogger<Problem<T>>`, defines `abstract T CalculateAnswer()`, and `Answer()` which calls it and logs `Answer = {answer}`.
- Each `ProblemNNN : Problem<T>` implements only `CalculateAnswer()`. `T` is the answer's natural type (`int`, `long`, or `string`) — match the test's expected literal.
- Logging is injected via constructor DI. In the app, problems are instantiated through `ActivatorUtilities.CreateInstance` so the logger is resolved automatically. In tests, pass `NullLogger<ProblemNNN>.Instance`.
- Use `Logger.LogDebug(...)` for per-step diagnostic detail, `Logger.LogInformation(...)` for the answer.

Shared helpers live at the root of the **ProjectEuler** project (`MathHelpers`, `IntHelpers`, `CharHelpers`, `StringHelpers`, `PrimeFactorization`) — many are extension methods. Check these before writing new number-theory utilities (e.g. `IndexCompositeBySieve`, `IsPandigital`). Large problem input data (e.g. the names list in `Problem022`) is embedded inline in the problem class.

### Python (parallel implementation)

Mirrors the C# structure under `ProjectEulerPython/`: an abstract `Problem` base (`problems/problem.py`) with `calculate_answer()` / `answer()`, one `problem_NNN.py` per problem, and root-level `*_helpers.py` modules. Output detail is controlled by `console_output` / `detailed_output` constructor flags and `print_detail()` rather than a logger.

## Adding a new problem

C# side:
1. Create `ProjectEuler/Problems/ProblemNNN.cs` extending `Problem<T>`.
2. Add `Answer_ProblemNNN_IsCorrect` to `ProjectEulerTests/ProblemTests.cs`, matching the expected literal's type.

`ProjectEulerApp/ProblemWorker.cs` discovers all concrete `IProblem` types in the library via reflection and runs them ordered by type name — no manual registration is needed (name your class `ProblemNNN` so it sorts into sequence).

Python side:
1. Create `ProjectEulerPython/problems/problem_NNN.py`.
2. Add the import and update the invocation at the bottom of `project_euler.py`.

## Conventions

- Code style is enforced by `.editorconfig` (4-space indent for C#, `always_for_clarity` parentheses, System usings *not* sorted first). All text files use **LF** line endings, including on Windows (see `.gitattributes`).
