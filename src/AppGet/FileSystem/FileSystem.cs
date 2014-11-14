﻿using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace AppGet.FileSystem
{
    public interface IFileSystem
    {
        bool FileExists(string source);
        string ReadAllText(string source);
        void WriteAllText(string path, string content);
        void CreateDirectory(string path);
        void DeleteDirectory(string path);
        void SetPermissions(string path, WellKnownSidType accountSid, FileSystemRights rights, AccessControlType controlType);
    }

    public class FileSystem : IFileSystem
    {
        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public void WriteAllText(string path, string content)
        {
            File.WriteAllText(path, content);
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public void DeleteDirectory(string path)
        {
            Directory.Delete(path, true);
        }
        
        public void SetPermissions(string path, WellKnownSidType accountSid, FileSystemRights rights, AccessControlType controlType)
        {
            var sid = new SecurityIdentifier(accountSid, null);
            var directoryInfo = new DirectoryInfo(path);
            var directorySecurity = directoryInfo.GetAccessControl();

            var accessRule = new FileSystemAccessRule(sid, rights,
                                                      InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                                                      PropagationFlags.None, controlType);

            directorySecurity.AddAccessRule(accessRule);
            directoryInfo.SetAccessControl(directorySecurity);
        }
    }
}