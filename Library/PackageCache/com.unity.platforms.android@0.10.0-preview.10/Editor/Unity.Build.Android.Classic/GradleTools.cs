using System;
using System.IO;

namespace Unity.Build.Android.Classic
{
    internal static class GradleTools
    {
        internal static string GetGradleTask(bool isDevelopmentPlayer, bool isAppBundle)
        {
            var prefix = isAppBundle ? "bundle" : "assemble";
            prefix += isDevelopmentPlayer ? "Debug" : "Release";
            return prefix;
        }

        internal static string GetGradleLauncherJar(string androidBuildTools)
        {
            string gradleDir = Path.Combine(androidBuildTools, "gradle");
            string libDir = Path.Combine(gradleDir, "lib");
            var launcherFiles = Directory.GetFiles(libDir, "gradle-launcher-*.jar");
            if (launcherFiles.Length != 1)
                throw new Exception("Failed to find gradle-launcher in " + libDir);
            return launcherFiles[0];
        }

        internal static string GetGradleOutputPath(bool isDevelopmentPlayer, bool isAppBundle)
        {
            var config = isDevelopmentPlayer ? "debug" : "release";
            if (isAppBundle)
                return Path.Combine("launcher", "build", "outputs", "bundle", config, $"launcher.aab");
            else
                return Path.Combine("launcher", "build", "outputs", "apk", config, $"launcher-{config}.apk");
        }
    }
}
