﻿
using AppGet.HostSystem;
using FluentAssertions;
using NUnit.Framework;

namespace AppGet.Tests.HostSystem
{
    [TestFixture]
    public class OsInfoFixture : TestBase<OsInfo>
    {
        [Test]
        public void should_get_os_info()
        {
            Subject.Name.Should().NotBeNullOrWhiteSpace();
            Subject.Version.Major.Should().BeGreaterThan(7);
            Subject.FullName.Should().NotBeNullOrWhiteSpace();
        }
    }
}