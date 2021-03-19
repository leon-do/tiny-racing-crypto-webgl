using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Unity.Build;


namespace Unity.Build.macOS.Tests
{
    class BasicMacOSTests
    {
        [Test]
        public void TestMacOSPlatformEquality()
        {
            var macosPlatform = Platform.macOS;
            // MissingPlatform for macOS is produced when we deserialize Class Build Profile with "OSX" but com.unity.platforms.macos is not included
            var missingWindowsPlatform = new MissingPlatform(macosPlatform.Name);
            Assert.AreEqual(macosPlatform, missingWindowsPlatform);
        }
    }
}
