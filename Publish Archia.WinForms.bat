@ECHO OFF

TITLE Publish Archia.WinForms

CD .\src\Archia.WinForms
dotnet publish ^
    /p:PublishProfile=win-x64

ECHO.
ECHO Run "Run Archia.WinForms.bat (Publish)" or ".\bin\Archia.WinForms.exe" to run the published executable

ECHO.
ECHO Press any key to exit...
PAUSE > NUL
