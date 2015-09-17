#!/bin/sh

# exit on error
set -e

# if these fail, we want the script to fail
zip $(pwd)/Archives/linux.zip $(pwd)/Builds/LinuxUniversal/*
zip $(pwd)/Archives/osx.zip $(pwd)/Builds/OSXUniversal/*
zip $(pwd)/Archives/win32.zip $(pwd)/Builds/Win32/*
zip $(pwd)/Archives/win64.zip $(pwd)/Builds/Win64/*

# these are a bit more wonky, so if they didn't build, it's ok
if [ -d "$(pwd)/Builds/Android" ]
then
  zip $(pwd)/Archives/android.zip Builds/Android/*
fi

if [ -d "$(pwd)/Builds/iOS" ]
then
  zip $(pwd)/Archives/ios.zip Builds/iOS/*
fi
