namespace FileHandling
{
    public static class FileReader
    {
        public static async Task<List<string>> ReadFile(string path)
        {
            var lines = await File.ReadAllLinesAsync(path);
            return lines.Select(i => i.Trim()).ToList();
        }

        public static async Task<List<int>> ReadFileAsInt(string path)
        {
            var lines = await ReadFile(path);
            
            return lines.Select(i => int.Parse(i))
                .ToList();
        }

    }
}