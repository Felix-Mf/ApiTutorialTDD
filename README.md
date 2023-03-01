# ApiTutorialTDD

Tutorial: https://www.freecodecamp.org/news/learn-tdd-with-integration-tests-in-net-5-0/

## Business Requirements

* A hospital has X ICU rooms, Y Premium rooms, and Z General rooms.
* ICU and Premium rooms can have a single patient at a time, while General rooms can have 2 patients. Each room has a room number.
* On admitting, the patient has to provide name, age, gender, and phone number.
* It is possible to search a patient via name or phone number.
* The same patient cannot be admitted to multiple beds while they are still checked in.
* A patient cannot be admitted if all the rooms are occupied.

## Setup

Open a terminal in your project folder.
For the setup you can use the following script:

```
dotnet new sln
dotnet new webapi --name TDD
dotnet new xunit --name TDD.Tests
cd TDD
dotnet add package Microsoft.EntityFrameworkCore --version 5.0.5
cd ../TDD.Tests
dotnet add reference ../TDD/TDD.csproj
dotnet add package Microsoft.EntityFrameworkCore --version 5.0.5
dotnet add package Microsoft.AspNetCore.Hosting --version 2.2.7
dotnet add package Microsoft.AspNetCore.Mvc.Testing --version 5.0.5
dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 5.0.5
cd ..
dotnet sln add TDD/TDD.csproj
dotnet sln add TDD.Tests/TDD.Tests.csproj
code .
```
