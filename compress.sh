#!/bin/sh

# exit script on error
set -e

zip Archives/linux.zip Builds/LinuxUniversal/*
zip Archives/osx.zip Builds/OSXUniversal/*
zip Archives/win32.zip Builds/Win32/*
zip Archives/win64.zip Builds/Win64/*
zip Archives/android.zip Builds/Android/*
zip Archives/ios.zip Builds/iOS/*
