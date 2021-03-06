﻿
using System.IO;
using AppGet.HostSystem;
using FluentAssertions;
using NUnit.Framework;

namespace AppGet.Tests.HostSystem
{
    [TestFixture]
    public class EnvInfoFixture : TestBase<EnvInfo>
    {
        [Test]
        public void should_get_os_info()
        {
            Subject.Name.Should().Contain("Windows");
            Subject.WindowsVersion.Major.Should().BeGreaterThan(7);
            Subject.FullName.Should().Contain("Windows NT");
            Subject.FullName.Should().Contain(Subject.WindowsVersion.ToString());

            Subject.Is64BitOperatingSystem.Should().BeTrue();
            Subject.AppDir.Should().Contain(Path.DirectorySeparatorChar.ToString());
        }
    }
}