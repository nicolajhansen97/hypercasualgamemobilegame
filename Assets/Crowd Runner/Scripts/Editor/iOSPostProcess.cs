#if UNITY_IOS
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using System.IO;

public class iOSPostProcess
{
    [PostProcessBuild]
    public static void OnPostProcessBuild(BuildTarget target, string path)
    {
        if (target != BuildTarget.iOS)
            return;

        string projPath = PBXProject.GetPBXProjectPath(path);
        PBXProject proj = new PBXProject();
        proj.ReadFromFile(projPath);

        string frameworkGuid = proj.GetUnityFrameworkTargetGuid();
        proj.SetBuildProperty(frameworkGuid, "CLANG_WARN_QUOTED_INCLUDE_IN_FRAMEWORK_HEADER", "NO");

        proj.WriteToFile(projPath);
    }
}
#endif
