namespace LandRover.Core.Utils
{
    public static class FileReader
    {
        public static string[] ReadFile(string path)
        {
            string[] lines = File.ReadAllLines(path);

            return lines;
        }
    }
}