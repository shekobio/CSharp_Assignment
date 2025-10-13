using Infrastructure.Models;

namespace Infrastructure.Interface;

public interface IFileService
{
    string GetContentFromFile();

    bool SaveContentToFile(string content);
    T? GetContentFromFile<T>();
    bool SaveContentToFile<T>(T content);
}
