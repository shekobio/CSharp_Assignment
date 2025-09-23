namespace Infrastructure.Interface;

public interface IFileService
{
    T? GetContentFromFile<T>();
    bool SaveContenToFile<T>(T content);
}
