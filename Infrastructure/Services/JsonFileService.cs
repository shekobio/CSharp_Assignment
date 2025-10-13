using Infrastructure.Interface;
using System.Text.Json;


namespace Infrastructure.Services;

public class JsonFileService(string filePath, JsonSerializerOptions? options = null) : IFileService
{

    private readonly string _filePath = filePath;
    private readonly JsonSerializerOptions _options = options ?? new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true
    };

    public string GetContentFromFile()
    {
        if (!File.Exists(_filePath))
            return string.Empty;
                          
        return File.ReadAllText(_filePath);
    }

    public bool SaveContentToFile(string content)
    {
        try
        {
            var directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);

            File.WriteAllText(_filePath, content);

            return true;

        }
        catch
        {
            return false;
        }
    }

    public bool SaveContentToFile<T>(T content)
    {
        try
        {
            var json = JsonSerializer.Serialize(content, _options);
            return SaveContentToFile(json);

                 
        }
        catch
        {
            return false;
        }

    }

    public T? GetContentFromFile<T>()
    {
        try
        {
            var content = GetContentFromFile();
            if (string.IsNullOrEmpty(content))
                return default;



            return JsonSerializer.Deserialize<T>(content);

        }
        catch
        {
            return default;
        }
    }
}