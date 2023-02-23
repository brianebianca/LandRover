namespace LandRover.Core.Utils
{
    public static class FileReader
    {
        public static string[] ReadFile(string path)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);

                return lines;
            }catch (Exception)
            {
                throw new Exception($"Could not read file {path}");
            }
        }
    }
}