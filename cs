#!/usr/bin/env bash
# CastleScript Launcher for macOS/Linux
# Updated for src/ directory structure

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

# Run with REPL launcher from src/
python3 "$SCRIPT_DIR/src/cs_repl.py" "$@"
