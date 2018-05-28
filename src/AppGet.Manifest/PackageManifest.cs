﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using YamlDotNet.Serialization;

namespace AppGet.Manifest
{
    [DebuggerDisplay("{" + nameof(Id) + "} " + "{" + nameof(Version) + "}")]
    public class PackageManifest
    {
        public const string LATEST_TAG = "latest";
        
        public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }

        public string Home { get; set; }
        public string Repo { get; set; }
        public string License { get; set; }

        public string[] Exe { get; set; }

        public InstallMethodTypes InstallMethod { get; set; }
        public InstallArgs Args { get; set; }

        public List<Installer> Installers { get; set; }

        [YamlIgnore]
        public string Tag { get; set; }

        [YamlIgnore]
        public string Path { get; set; }

        public PackageManifest()
        {
            InstallMethod = InstallMethodTypes.Custom;
        }

        public override string ToString()
        {
            return $"{Id} {Version}".Trim();
        }


        public string GetFileName()
        {
            var tag = Tag?.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(tag) || tag == LATEST_TAG)
            {
                return $"{Id}";
            }

            return $"{Id}_{tag}";
        }
    }

    public class InstallArgs
    {
        public string Passive { get; set; }
        public string Silent { get; set; }
        public string Interactive { get; set; }
        public string Log { get; set; }
    }

    public class Installer
    {
        public string Location { get; set; }
        public string Sha256 { get; set; }
        public ArchitectureTypes Architecture { get; set; }

        public Version MinWindowsVersion { get; set; }
    }
}