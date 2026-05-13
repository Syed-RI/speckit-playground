# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

<!-- SPECKIT START -->
For additional context about technologies to be used, project structure,
shell commands, and other important information, read the current plan
<!-- SPECKIT END -->

## Project Overview

This is a **Spec Kit playground** — a .NET 10 C# console application used to develop and test the Spec Kit specification-driven development (SDD) workflow system. The application code itself is minimal; the primary substance of the repo is the Spec Kit tooling infrastructure.

## Build & Run Commands

```bash
dotnet build          # Build the project
dotnet run            # Run the console app
```

No test runner or linter is configured yet — these are set up as part of the constitution/spec workflow when a feature is defined.

## Spec Kit Workflow (SDD Cycle)

Features in this project follow a structured **Specification-Driven Development** cycle, enforced via Claude Code skills. Always use the appropriate skill rather than writing artifacts manually.

### Stage Order

1. `/speckit-constitution` — Define project principles and constraints (run once per project)
2. `/speckit-specify` — Create `spec.md` from a natural language feature description
3. `/speckit-clarify` — Resolve ambiguities in the spec (optional but recommended)
4. `/speckit-plan` — Generate `plan.md` with architecture, phases, and design decisions
5. `/speckit-tasks` — Generate `tasks.md` with dependency-ordered, independently-testable tasks
6. `/speckit-implement` — Execute tasks defined in `tasks.md`
7. `/speckit-analyze` — Cross-artifact consistency check across spec/plan/tasks
8. `/speckit-checklist` — Generate verification checklist
9. `/speckit-taskstoissues` — Sync tasks to GitHub issues

Shortcut: `/speckit` runs the full cycle (specify → plan → tasks → implement) with review gates.

### Git Hooks

Every stage has configured git hooks in `.specify/extensions.yml`. Two hooks are **mandatory** (non-optional):

- `before_constitution` → runs `speckit.git.initialize` (initializes the repo)
- `before_specify` → runs `speckit.git.feature` (creates a numbered feature branch)

All other hooks offer optional auto-commits before/after each stage.

### Branch Naming

Feature branches follow the convention `###-feature-name` (e.g., `001-user-authentication`). The git extension handles sequential numbering automatically via `/speckit-git-feature`.

## Artifact Locations

When a feature is active, the following files are produced on the feature branch:

| File | Produced by | Purpose |
|------|-------------|---------|
| `.specify/memory/constitution.md` | `/speckit-constitution` | Project principles & governance |
| `spec.md` | `/speckit-specify` | User stories, acceptance criteria |
| `plan.md` | `/speckit-plan` | Architecture, phases, design decisions |
| `tasks.md` | `/speckit-tasks` | Ordered implementation tasks |

Templates for all artifacts live in `.specify/templates/`.

## Architecture Notes

- **Integration**: Configured for Claude (`claude` is the `default_integration` in `.specify/integration.json`, version 0.8.9)
- **Skills**: All Spec Kit skills live in `.claude/skills/` and are invokable as slash commands
- **Git extension**: `.specify/extensions/` contains the git extension (v1.0.0) for branch management
- **Hooks config**: `.specify/extensions.yml` — controls which git commands fire at each workflow stage; `auto_execute_hooks: true`
- **VS Code**: `.vscode/` is configured to recommend Spec Kit prompt files from `.github/prompts/`
