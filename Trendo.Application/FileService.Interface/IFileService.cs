using Microsoft.AspNetCore.Http;
namespace Trendo.Application.File.Interface;

public interface IFileService
{
    string SaveFile(IFormFile file, string folderName);
    bool DeleteFile(string fileName, string folderName);
}
