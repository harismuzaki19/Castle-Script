@echo off
REM CastleScript Launcher for Windows with REPL support
REM Usage: 
REM   cs              - Interactive mode
REM   cs file.cs      - Run file
REM   cs --help       - Show help
REM   cs --version    - Show version

set SCRIPT_DIR=%~dp0

REM Run with REPL launcher
python "%SCRIPT_DIR%cs_repl.py" %*
