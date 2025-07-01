using Microsoft.AspNetCore.Http;
namespace Trendo.Application.File.Interface;

public interface IFileService
{
    Task<string?> Upload(IFormFile file,string folderName);
    bool DeleteFile(string path);
}
