namespace DynaReport.Utilities
{
    public static class FileUtility
    {
        public static void CopyDllToBinFolder()
        {
            string dllFolder = Path.Combine(Directory.GetCurrentDirectory(), "dll");
            string dllFileName = "libwkhtmltox.dll";
            string targetFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

            if (!Directory.Exists(targetFolder))
            {
                Directory.CreateDirectory(targetFolder);
            }

            string sourcePath = Path.Combine(dllFolder, dllFileName);
            string targetPath = Path.Combine(targetFolder, dllFileName);

            if (File.Exists(sourcePath))
            {
                File.Copy(sourcePath, targetPath, true);
                Console.WriteLine($"Copied {dllFileName} to {targetFolder}");
            }
            else
            {
                Console.WriteLine($"DLL file not found in {dllFolder}");
            }
        }

        private static string GetBuildConfiguration()
        {
            #if DEBUG
            return "Debug";
            #else
            return "Release";
            #endif
        }
    }
}