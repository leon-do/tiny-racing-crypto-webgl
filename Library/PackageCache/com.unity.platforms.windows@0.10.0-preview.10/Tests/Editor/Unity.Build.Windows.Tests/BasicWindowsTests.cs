using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Unity.Build;


namespace Unity.Build.Windows.Tests
{
    class BasicWindowsTests
    {
        [Test]
        public void TestWindowsPlatformEquality()
        {
            var winPlatform = Platform.Windows;
            // MissingPlatform for Windows is produced when we deserialize Class Build Profile with "Windows" but com.unity.platforms.windows is not included
            var missingWindowsPlatform = new MissingPlatform(winPlatform.Name);
            Assert.AreEqual(winPlatform, missingWindowsPlatform);
        }
    }
}
