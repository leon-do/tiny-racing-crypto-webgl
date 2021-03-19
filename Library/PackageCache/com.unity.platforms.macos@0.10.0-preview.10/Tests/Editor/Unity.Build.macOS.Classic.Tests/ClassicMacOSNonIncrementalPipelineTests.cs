using NUnit.Framework;
using UnityEditor;
using Unity.Build;
using Unity.Build.Classic.Private;
using Unity.Build.Classic.Private.MissingPipelines;

namespace Unity.Build.macOS.Classic.Tests
{
    class ClassicMacOSNonIncrementalPipelineTests
    {
        [Test]
        public void TestBuildPipelineSelectorForOSX()
        {
            var osxPlatform = Platform.macOS;
            var missingosxPlatform = new MissingPlatform(osxPlatform.Name);

            var selector = new BuildPipelineSelector();
            var pipeline = selector.SelectFor(osxPlatform);
            Assert.AreEqual(pipeline.GetType(), typeof(MacOSClassicNonIncrementalPipeline));

            // Since OSX pipeline is implemented in com.unity.platforms.OSX
            // Selector will return null pipeline instead of MissingNonIncrementalPipeline
            pipeline = selector.SelectFor(missingosxPlatform);
            Assert.AreEqual(pipeline, null);
        }
    }
}
