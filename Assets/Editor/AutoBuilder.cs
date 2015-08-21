using UnityEngine;
using UnityEditor;
using System.Collections;

// see: http://wiki.unity3d.com/index.php?title=AutoBuilder

public static class AutoBuilder {
	static BuildTarget currentTarget;

	static readonly string BUILDPATH = "Builds/";

	[MenuItem("File/AutoBuilder/Windows/32-bit")]
	static void PerformWin32Build() {
		SetBuildTarget (BuildTarget.StandaloneWindows);
		BuildTo ("Win32");
	}

	[MenuItem("File/AutoBuilder/Windows/64-bit")]
	static void PerformWin64Build() {
		SetBuildTarget (BuildTarget.StandaloneWindows64);
		BuildTo ("Win64");
	}

	[MenuItem("File/AutoBuilder/OSX/32-bit")]
	static void PerformOSX32Build() {
		SetBuildTarget (BuildTarget.StandaloneOSXIntel);
		BuildTo ("OSX32");
	}

	[MenuItem("File/AutoBuilder/OSX/64-bit")]
	static void PerformOSX64Build() {
		SetBuildTarget (BuildTarget.StandaloneOSXIntel64);
		BuildTo ("OSX64");
	}

	[MenuItem("File/AutoBuilder/OSX/Universal")]
	static void PerformOSXUniversalBuild() {
		SetBuildTarget (BuildTarget.StandaloneOSXUniversal);
		BuildTo ("OSXUniversal");
	}

	[MenuItem("File/AutoBuilder/Linux/32-bit")]
	static void PerformLinux32Build() {
		SetBuildTarget (BuildTarget.StandaloneLinux);
		BuildTo ("Linux32");
	}

	[MenuItem("File/AutoBuilder/Linux/64-bit")]
	static void PerformLinux64Build() {
		SetBuildTarget (BuildTarget.StandaloneLinux);
		BuildTo ("Linux64");
	}

	[MenuItem("File/AutoBuilder/Linux/Universal")]
	static void PerformLinuxUniversalBuild() {
		SetBuildTarget (BuildTarget.StandaloneLinuxUniversal);
		BuildTo ("LinuxUniversal");
	}

	[MenuItem("File/AutoBuilder/iOS")]
	static void PerformIOSBuild() {
		SetBuildTarget (BuildTarget.iOS);
		BuildTo ("iOS");
	}

	[MenuItem("File/AutoBuilder/Android")]
	static void PerformAndroidBuild() {
		SetBuildTarget (BuildTarget.Android);
		BuildTo ("Android");
	}

	[MenuItem("File/AutoBuilder/Web/WebGL")]
	static void PerformWebGLBuild() {
		SetBuildTarget (BuildTarget.WebGL);
		BuildTo ("WebGL");
	}

	[MenuItem("File/AutoBuilder/Web/WebPlayer")]
	static void PerformWebPlayerBuild() {
		SetBuildTarget (BuildTarget.WebPlayer);
		BuildTo ("WebPlayer");
	}

	static void SetBuildTarget(BuildTarget target) {
		EditorUserBuildSettings.SwitchActiveBuildTarget (target);
		currentTarget = target;
	}

	static void BuildTo(string folder) {
		BuildPipeline.BuildPlayer (GetScenePaths (), BUILDPATH + folder + "/" + GetProjectName() + GetExtension(), currentTarget, BuildOptions.None);
	}

	static string GetProjectName() {
		string[] s = Application.dataPath.Split ('/');
		string suffix = "";

		if (currentTarget == BuildTarget.StandaloneOSXIntel64 || currentTarget == BuildTarget.StandaloneLinux64 || currentTarget == BuildTarget.StandaloneWindows64) {
			suffix = "64";
		}

		return s[s.Length - 2] + suffix;
	}

	static string GetExtension() {
		switch (currentTarget) {
			case BuildTarget.StandaloneWindows:
			case BuildTarget.StandaloneWindows64:
				return ".exe";
			case BuildTarget.StandaloneOSXIntel:
			case BuildTarget.StandaloneOSXIntel64:
			case BuildTarget.StandaloneOSXUniversal:
				return ".app";
			case BuildTarget.StandaloneLinux:
			case BuildTarget.StandaloneLinuxUniversal:
				return ".x86";
			case BuildTarget.StandaloneLinux64:
				return ".x86_64";
			default:
				return "";
		}
	}

	static string[] GetScenePaths() {
		string[] scenes = new string[EditorBuildSettings.scenes.Length];

		for (int i = 0; i < scenes.Length; i++) {
			scenes[i] = EditorBuildSettings.scenes[i].path;
		}

		return scenes;
	}
}
