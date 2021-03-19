using NUnit.Framework;
using UnityEditor;
using Unity.Build.Classic.Private;
using Unity.Build.Classic.Private.MissingPipelines;

namespace Unity.Build.Windows.Classic.Tests
{
    class ClassicWindowsNonIncrementalPipelineTests
    {
        [Test]
        public void TestBuildPipelineSelectorForWin64()
        {
            var winPlatform = Platform.Windows;
            var missingWindowsPlatform = new MissingPlatform(winPlatform.Name);

            var selector = new BuildPipelineSelector();
            var pipeline = selector.SelectFor(winPlatform);
            Assert.AreEqual(pipeline.GetType(), typeof(WindowsClassicNonIncrementalPipeline));

            // Since Windows 64 pipeline is implemented in com.unity.platforms.windows
            // Selector will return null pipeline instead of MissingNonIncrementalPipeline
            pipeline = selector.SelectFor(missingWindowsPlatform);
            Assert.AreEqual(pipeline, null);
        }

        [Test]
        public void TestBuildPipelineSelectorForWin32()
        {
            var missingWindows32Platform = new MissingPlatform("Windows32");

            var selector = new BuildPipelineSelector();
            var pipeline = selector.SelectFor(missingWindows32Platform);
            // There's no pipeline implemented for Windows 32 bit, thus MissingNonIncrementalPipeline will be used
            Assert.AreEqual(pipeline.GetType(), typeof(MissingNonIncrementalPipeline));
        }
    }
}
