# Security Policy

## Supported Versions

Currently supported versions of Castle-Script:

| Version | Supported          |
| ------- | ------------------ |
| 0.9.x   | :white_check_mark: |
| < 0.9   | :x:                |

## Reporting a Vulnerability

We take security seriously. If you discover a security vulnerability in Castle-Script, please report it responsibly.

### How to Report

**Please DO NOT create a public GitHub issue for security vulnerabilities.**

Instead, report security issues via:

1. **Email**: Create an issue with label "security" and we'll contact you privately
2. **GitHub Security Advisory**: Use the "Security" tab → "Report a vulnerability"

### What to Include

When reporting a vulnerability, please include:

- Description of the vulnerability
- Steps to reproduce the issue
- Affected versions
- Potential impact
- Suggested fix (if you have one)

### Response Timeline

- **Initial Response**: Within 48 hours
- **Status Update**: Within 7 days
- **Fix Timeline**: Depends on severity
  - Critical: 1-7 days
  - High: 1-14 days
  - Medium: 1-30 days
  - Low: Best effort

### Security Best Practices

When using Castle-Script:

1. **Input Validation**: Always validate user input in your programs
2. **File Operations**: Be careful with file paths and permissions
3. **Execution**: Don't execute untrusted .cs files
4. **Dependencies**: Keep Python and system libraries updated

## Known Security Considerations

### File System Access

Castle-Script has file I/O functions (`baca_file`, `tulis_file`, etc.). Users should:

- Validate file paths before use
- Use absolute paths when possible
- Check permissions before file operations
- Sanitize user-provided file names

### Code Execution

Castle-Script executes code. When running .cs files:

- Only run trusted code
- Review code before execution
- Be aware of file system access in scripts
- Use sandboxing for untrusted code

### GUI Applications

GUI functions use Tkinter. Be aware:

- GUI apps can access system resources
- Input fields should be validated
- Don't trust user input without validation

## Security Updates

Security patches will be released as:

- Patch versions (e.g., 0.9.1 → 0.9.2) for minor issues
- Minor versions (e.g., 0.9.x → 0.10.x) for significant issues
- Announcements in GitHub Releases

## Scope

This security policy applies to:

- Castle-Script interpreter (`src/castlescript.py`)
- Built-in functions (all `src/castlescript_*.py` files)
- Official launchers (`cs`, `cs.bat`, etc.)

Out of scope:

- User-written .cs programs
- Third-party extensions
- Deployment environments

## Contact

For security concerns: Use GitHub issues with "security" label

For general questions: Use GitHub Discussions or regular issues

---

Thank you for helping keep Castle-Script and its users safe!
