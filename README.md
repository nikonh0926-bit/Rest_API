Rest_API


Om prosjektet

Dette prosjektet er et REST API utviklet med ASP.NET Core Controllers og C#. API-et håndterer en oppgaveliste (To-do list), der brukeren kan opprette oppgaver og hente eksisterende oppgaver.

Prosjektet bruker Entity Framework Core for kommunikasjon med SQL Server, slik at oppgavene lagres permanent i en database.



Hovedfunksjoner

Hente alle oppgaver.

Hente én oppgave basert på ID.

Opprette nye oppgaver.

Lagre oppgaver i SQL Server ved hjelp av Entity Framework Core.

Dokumentere og teste API-et med Swagger.

Teste servicelogikk med xUnit.

Teknologier og NuGet-pakker

Prosjektet er utviklet med C# og ASP.NET Core.



Følgende NuGet-pakker brukes i prosjektet:

Microsoft.AspNetCore.OpenApi

Microsoft.EntityFrameworkCore.Design

Microsoft.EntityFrameworkCore.SqlServer

Swashbuckle.AspNetCore

Microsoft.EntityFrameworkCore.InMemory

xunit

Merk: Kontroller .csproj-filene for å sikre at listen samsvarer med pakkene som faktisk er installert. Ikke alle pakkene trenger å være direkte referert fra begge prosjektene.


Komme i gang

Forutsetninger

Før prosjektet kjøres, må følgende være installert:

.NET SDK som samsvarer med prosjektets målrammeverk.

SQL Server, for eksempel SQL Server Express eller en lokal Developer-installasjon.

SQL Server Management Studio (SSMS), anbefalt for administrasjon av databasen.


1. Konfigurer SQL Server

Opprett eller identifiser en lokal SQL Server-instans. Eksempler på servernavn er:

localhost

localhost\SQLEXPRESS

Det faktiske navnet avhenger av SQL Server-installasjonen.

Legg deretter til eller oppdater ConnectionStrings i appsettings.json:

"ConnectionStrings": {
    "DefaultConnection": "Server={server-name};Database=Rest_API;Trusted_Connection=True;TrustServerCertificate=True;"
  } 

Bytt ut {server-name} med navnet på din egen SQL Server-instans dersom det er nødvendig.

Denne tilkoblingsstrengen bruker Windows-integrert autentisering. TrustServerCertificate=True kan brukes i et lokalt utviklingsmiljø, men bør vurderes annerledes i produksjon.


2. Opprett eller oppdater databasen

Åpne terminalen i prosjektmappen som inneholder API-prosjektets .csproj-fil.

Hvis EF Core CLI ikke er installert, kan det installeres med:

dotnet tool install --global dotnet-ef

Hvis verktøyet allerede er installert, kan det oppdateres med:

dotnet tool update --global dotnet-ef


Kjør deretter migrasjonene:

dotnet ef database update

Dette oppretter databasen og tabellene som er definert gjennom prosjektets eksisterende migrasjoner.

Hvis prosjektet ikke har noen migrasjoner ennå, må en migrasjon opprettes først:

dotnet ef migrations add InitialCreate
dotnet ef database update

Hvis migrasjonene ligger i et annet prosjekt enn standardprosjektet, må du angi riktig prosjekt med --project og eventuelt --startup-project.



3. Start API-et

Fra mappen som inneholder API-prosjektets .csproj-fil, kjør:

dotnet restore
dotnet run

Bruk adressen som vises i terminalen. Dersom prosjektet er konfigurert til å bruke https://localhost:9001, åpnes Swagger UI normalt på:

https://localhost:9001/swagger

Hvis adressen eller porten er annerledes, bruk den som faktisk vises i terminalen.



API-endepunkter

HTTP-metode

Endepunkt

Beskrivelse

GET

/ToDoItem

Henter alle oppgaver.

GET

/ToDoItem/{id}

Henter en oppgave basert på ID.

POST

/ToDoItem

Oppretter en ny oppgave.

Eksempel: Opprette en oppgave

Send en POST-forespørsel til /ToDoItem med følgende JSON:

{
  "title": "Testoppgave",
  "description": "Dette er en testoppgave",
  "dueDate": null
}

Ved vellykket opprettelse bør API-et returnere 201 Created og informasjon om den nye oppgaven.



Testing med Swagger

Start API-et.

Åpne /swagger i nettleseren.

Velg et endepunkt.

Trykk Try it out.

Fyll inn eventuelle parametere eller JSON-data.

Trykk Execute for å sende forespørselen.

Kontroller HTTP-statuskoden og responsen.

Automatiserte tester

Testprosjektet heter Rest_API.Tests.

Kjør testene fra mappen som inneholder .sln-filen:

dotnet test

Testene verifiserer at servicelogikken oppfører seg som forventet.

Hvis testene bruker EF Core InMemory, trenger de normalt ikke tilgang til en kjørende SQL Server-instans.



Prosjektstruktur

Rest_API/
├── 1_Model/
├── 2_Controllers/
├── 3_DTO/
├── 4_Services/
├── Migrations/
├── Program.cs
├── appsettings.json
└── Rest_API.csproj

Rest_API.Tests/
└── 1_unit/
    └── TodoItemServiceTests.cs

Mappestrukturen over er illustrativ. Den bør tilpasses den faktiske strukturen i repository-et.

Lagring

Oppgavene lagres i SQL Server gjennom Entity Framework Core. Migrasjoner brukes til å opprette og oppdatere databasestrukturen.

Databasen ligger lokalt og opprettes ikke automatisk på en annen maskin før riktig tilkoblingsstreng og migrasjonene er konfigurert og kjørt.