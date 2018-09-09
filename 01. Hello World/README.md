# Getting started

.NET Core SDK comes with convenient CLI tooling. 

## Create project
To create sample project run following commands:

```sh

mkdir "01. HelloWorld"
cd .\01. HelloWorld
dotnet new sln -n HelloWorld
dotnet new console -n HelloWorld.Core -o .\src\HelloWorld.Core
dotnet sln add .\src\HelloWorld.Core

```

## Run project

To run the project
```sh

dotnet build
dotnet sln add .\src\HelloWorld.Core

```
