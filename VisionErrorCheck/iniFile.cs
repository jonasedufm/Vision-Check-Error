using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;

namespace VisionErrorCheck
{
    class iniFile
    {
        string Path;
        string fileName = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public iniFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? fileName + ".ini").FullName;
        }

        public string read(string key, string section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(section ?? fileName, key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public bool keyExist(string key, string section = null)
        {
            return read(key, section).Length > 0;
        }
    }
}
