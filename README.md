# SoftNETProject
This is my Exam project for .NET

# Tanker ift til projektet (Danish)
Github Repo: https://github.com/kaar1498/SoftNETProject

Jeg opstillede først de 3 forskellige modeller og deres controllers, før jeg gik ind og gjorde brug af Interfaces. Interfacet er med til at sikre alle fremtidige modeller vil have et Id. Nogle af klassernes værdierne kan argumenteres at udvides til deres egne klasser, såsom adresse, enhed (unit) eller KontaktPerson (ContactPerson). For nu har jeg valgt at ikke gøre dette, da jeg mener det er et spørgsmål om at snakke med PO (REMA 1000) hvad der ønskes.
Til dokumentation af API’en har jeg gjort brug af Swagger. Swagger muliggør det for mig at hurtigt lave en dokumentation for API’en. Jeg kan samtidig også teste at mine endpoints virker korrekt.
Jeg har implementeret logging til mine controllers for at sikre bedre mod crashing og få at fremtidig gøre debugging mulige problemer nemmere. Meget af koden gå dog igen, og kunne simplificeres til et simplere tjek.
Til database valgte jeg SQLlite. SQLite integere godt med .NET applikationer og var til at. Det reducerer også ”overheadet” ved at køre i systemets process og har mulighed for caching. Til gengæld låses databasen, så kun en kan tilgå den af gangen. Dette ville kunne løses ved at separere databasens data til flere databaser.
Dog det er også muligt at blot bruge en anden database, og nemt at udskifte ved at ændre et enkelt stykke kode i Startup.cs
Jeg valgte at bruge EntityFrameworkCore da det hjælper til at give mig ORM (Object Relational Mapping) og gør mapping fra model til database effektivt. Det understøtter f.ekis. LINQ. Modellering og opstilling af Queries er således nemt.
Til fake data opstillingen brugte jeg Bogs, da jeg hurtigt kan opstille data og tjekke om min API virker. Jeg har sat seed’et for, så jeg er sikret det samme data hver gang, men hvis ønsket kunne jeg lade den være tilfældig hver gang.
