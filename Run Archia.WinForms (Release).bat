@ECHO OFF

TITLE Run Archia.WinForms (Release)

CD .\src\Archia.WinForms
dotnet run ^
    --configuration Release

ECHO Press any key to exit...
PAUSE > NUL
