@echo off
REM CastleScript Launcher for Windows
REM Updated for src/ directory structure

if "%1"=="" (
    echo CastleScript - Bahasa Pemrograman Indonesia
    echo Penggunaan: castlescript file.cs
    exit /b 1
)

set SCRIPT_DIR=%~dp0

REM Run CastleScript from src/
python "%SCRIPT_DIR%src\castlescript.py" %*
