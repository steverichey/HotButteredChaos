#!/bin/sh

# exit script on error
set -e

# see https://jonathan.porta.codes/2015/04/17/automatically-build-your-unity3d-project-in-the-cloud-using-travisci-for-free/

echo 'Downloading from http://netstorage.unity3d.com/unity/afd2369b692a/MacEditorInstaller/Unity-5.1.2f1.pkg: '
curl -o Unity.pkg http://netstorage.unity3d.com/unity/afd2369b692a/MacEditorInstaller/Unity-5.1.2f1.pkg

echo 'Installing Unity.pkg'
sudo installer -dumplog -package Unity.pkg -target /
