using NUnit.Framework;
using UnityEditor;
using Unity.Build;
using Unity.Build.Classic.Private;
using Unity.Build.Classic.Private.MissingPipelines;

namespace Unity.Build.Linux.Classic.Tests
{
    class ClassicLinuxNonIncrementalPipelineTests
    {
        [Test]
        public void TestBuildPipelineSelectorForLinux()
        {
            var linuxPlatform = Platform.Linux;
            var missingPlatform = new MissingPlatform(linuxPlatform.Name);

            var selector = new BuildPipelineSelector();
            var pipeline = selector.SelectFor(linuxPlatform);
            Assert.AreEqual(pipeline.GetType(), typeof(LinuxClassicNonIncrementalPipeline));

            pipeline = selector.SelectFor(missingPlatform);
            Assert.AreEqual(pipeline, null);
        }
    }
}
