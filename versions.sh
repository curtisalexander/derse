#!/usr/bin/env bash

# macOS
echo "macOS version:"
defaults read loginwindow SystemVersionStampAsString
echo

# .NET Core
echo "dotnet core version:"
dotnet --version
echo

# Argu
echo "Argu version:"
dotnet list Argu
echo
