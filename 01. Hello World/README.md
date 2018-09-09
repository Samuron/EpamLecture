# Getting started

.NET Core SDK comes with convenient CLI tooling. 

## Create project
To create sample project run following commands:

```sh

mkdir "01. HelloWorld"
cd ".\01. HelloWorld"
dotnet new sln -n HelloWorld
dotnet new console -n HelloWorld.Core -o .\src\HelloWorld.Core
dotnet new xunit -n HelloWorld.Tests -o .\test\HelloWorld.Tests
dotnet sln add .\src\HelloWorld.Core
dotnet sln add .\test\HelloWorld.Tests

dotnet add .\src\HelloWorld.Core\ package Microsoft.AspNetCore.Server.Kestrel
dotnet add .\src\HelloWorld.Core\ package Microsoft.AspNetCore.Hosting
dotnet add .\test\HelloWorld.Tests package Microsoft.AspNetCore.TestHost

dotnet add .\test\HelloWorld.Tests\ reference .\src\HelloWorld.Core\

```

## Run project

To run the project
```sh

dotnet build
dotnet run -p .\src\HelloWorld.Core

```

## Run tests

To run the tests
```sh

dotnet build
dotnet test

```
