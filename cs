#!/usr/bin/env bash
# CastleScript Launcher for macOS/Linux with REPL support
# Usage:
#   cs              - Interactive mode  
#   cs file.cs      - Run file
#   cs --help       - Show help
#   cs --version    - Show version

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

# Run with REPL launcher
python3 "$SCRIPT_DIR/cs_repl.py" "$@"
