using System;
using ObjCRuntime;

[assembly: LinkWith ("libDropboxSDK.a", LinkTarget.Simulator64 | LinkTarget.Arm64, ForceLoad = true, Frameworks = "Security QuartzCore")]