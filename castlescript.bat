@echo off
REM CastleScript Launcher for Windows
REM Usage: castlescript.bat <file.cs>

if "%~1"=="" (
    echo CastleScript - Bahasa Pemrograman Indonesia
    echo Penggunaan: castlescript.bat ^<file.cs^>
    exit /b 1
)

python "%~dp0castlescript.py" %*
