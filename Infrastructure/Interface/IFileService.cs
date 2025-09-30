using Infrastructure.Models;

namespace Infrastructure.Interface;

public interface IFileService
{
  
    T? GetContentFromFile<T>();
    bool SaveContentToFile<T>(T content);
}
