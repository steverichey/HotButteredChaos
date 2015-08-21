#!/bin/sh

zip Archives/linux.zip Builds/LinuxUniversal/*
zip Archives/osx.zip Builds/OSXUniversal/*
zip Archives/win32.zip Builds/Win32/*
zip Archives/win64.zip Builds/Win64/*

if [ -d "/Builds/Android" ]
then
  zip Archives/android.zip Builds/Android/*
fi

if [ -d "/Builds/iOS" ]
then
  zip Archives/ios.zip Builds/iOS/*
fi
