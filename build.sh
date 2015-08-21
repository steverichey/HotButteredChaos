#!/bin/sh

# Create basic unity alias
alias unity="/Applications/Unity/Unity.app/Contents/MacOS/Unity"

# Create headless unity alias
alias unity-headless="unity -batchmode -nographics -silent-crashes -quit"

project="hot-buttered-chaos"

echo "Attempting to build $project for Windows 64"
unity-headless \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd) \
  -executeMethod AutoBuilder.PerformWin64Build

cat $(pwd)/unity.log

echo "Attempting to build $project for OS X"
unity-headless \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd) \
  -executeMethod AutoBuilder.PerformOSXUniversalBuild

cat $(pwd)/unity.log

echo "Attempting to build $project for Linux"
unity-headless \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd) \
  -executeMethod AutoBuilder.PerformLinuxUniversalBuild

cat $(pwd)/unity.log

echo "Complete"
