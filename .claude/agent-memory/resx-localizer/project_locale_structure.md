---
name: project-locale-structure
description: Supported locales, resx file paths, entry ordering, and key naming conventions for this project's ApplicationStrings files
metadata:
  type: project
---

## Locale files (root of repo)

- `ApplicationStrings.resx` — base/English (includes XML declaration and xsd:schema block)
- `ApplicationStrings.es-es.resx` — Spanish (Spain); no XML declaration, no xsd:schema block

## Entry ordering

Entries are appended in insertion order, not alphabetically sorted. New entries should be added after the last `<data>` element before `</root>`.

## Key naming conventions observed

- `Hello` — plain PascalCase, no prefix (legacy)
- `HowAreYou` — plain PascalCase, no prefix (legacy)
- `Profile_WhereAreYouFrom` — first prefixed key, introduced 2026-06-22
- `Common_ImFineThankYou` — introduced 2026-06-22

New keys should use the `Prefix_PascalCaseSuffix` convention (e.g., `Profile_`, `Common_`, `Button_`, `Error_`).

## Indentation

4-space indentation for `<data>` blocks and nested `<value>` elements.
