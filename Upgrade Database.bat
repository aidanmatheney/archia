@ECHO OFF

TITLE Update Database

CD .\src\Archia.Data.Migrations
dotnet run ^
    --configuration Release

ECHO Press any key to exit...
PAUSE > NUL
