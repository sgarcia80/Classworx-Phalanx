# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Common Commands
- **Build solution**: `msbuild Phalanx.sln /p:Configuration=Release` (or `dotnet msbuild` on .NET CLI)
- **Clean solution**: `msbuild Phalanx.sln /t:Clean`
- **Run a specific test executable** (e.g., TestWCF):
  ```bash
  dotnet run --project TestWCF/TestWCF.csproj
  ```
  *If the project targets .NET Framework, use the corresponding `TestWCF.exe` from `bin/Release`.
- **Run a single test case**: The test projects are Windows Forms applications that execute test logic on launch. To run a specific scenario, modify the `Main` method or pass arguments to the exe as needed.

## High‑Level Architecture
The solution is organized around several layers and shared libraries:

1. **Web Services Layer** – Projects in the *Web* folder expose ASMX web services (e.g., `WSInterfaceClaves`, `WSInterfaceConectores`). They are hosted by IIS/ASP.NET and serve external clients.
2. **Business Logic Layer (BL)** – The `PhalanxBL` project contains domain services that orchestrate operations across the data layer. BL classes depend on interfaces defined in `PhalanxCommon` and concrete repositories from the DAL.
3. **Data Access Layer (DAL)** – `PhalanxDAL` implements NHibernate‑based persistence. Mapping files (.hbm.xml) live in subfolders such as `NDCDAL/MappingFiles`. The DAL exposes factory classes that create entity instances used by BL.
4. **Common Utilities** – Projects like `PhalanxCommon`, `phxCryptMgr`, and `phxBlowfish` provide shared types, encryption helpers, and configuration handling.
5. **Administrative UI** – `PhalanxAdmin` hosts a WinForms console for managing users, passwords, audit logs, and other maintenance tasks.
6. **Testing Projects** – `TestWCF` and `TestWSInterfaceClaves` are lightweight applications that exercise the web services and BL components. They are not unit test suites but can be run manually to validate behavior.
7. **Supporting Libraries** – Projects such as `PhxPing`, `PhxSvcExpirationManager`, and `PhxADService` provide background services (ping, expiration handling, AD integration).

The overall flow is:
```
Client -> Web Service (ASMX) -> BL Services -> DAL (NHibernate) -> DB
```
Administrative tasks run in the *PhalanxAdmin* WinForms UI and directly use the same BL/DAL stack.

## Build & Test Tips
- Use **Release** configuration for deployment; Debug includes full symbols.
- After building, the output binaries are located under each project's `binelease` folder.
- To run a specific test scenario, edit the `Program.cs` in the test project to call the desired BL method and observe console output.

---
**Note:** This guide focuses on commands and architecture that are immediately useful for developers working within this repository. It intentionally omits generic best‑practice reminders or security policies that are already covered by separate documentation.
