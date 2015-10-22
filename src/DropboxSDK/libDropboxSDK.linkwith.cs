using System;
using ObjCRuntime;

[assembly: LinkWith ("libDropboxSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.Arm64, ForceLoad = true, SmartLink=true, Frameworks = "Security QuartzCore")]