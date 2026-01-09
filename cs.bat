@echo off
REM CastleScript Launcher for Windows
REM Updated for src/ directory structure

set SCRIPT_DIR=%~dp0

REM Run with REPL launcher from src/
python "%SCRIPT_DIR%src\cs_repl.py" %*
