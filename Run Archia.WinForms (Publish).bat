@ECHO OFF

TITLE Run Archia.WinForms (Publish)

IF NOT EXIST ".\bin\Archia.WinForms.exe" (
    ECHO ERROR: ".\bin\Archia.WinForms.exe" is not built 1>&2
    ECHO Run "Publish Archia.WinForms.bat" to publish 1>&2

    ECHO.
    ECHO Press any key to exit...
    PAUSE > NUL
    EXIT /B 1
)

CD .\bin
START Archia.WinForms.exe
