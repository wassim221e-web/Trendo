using Microsoft.AspNetCore.Hosting; 
using Microsoft.AspNetCore.Http;
using System.IO;
using Trendo.Application.File.Interface;
public class FileService : IFileService
{
    private readonly string _webRootPath;

    public FileService(string webRootPath)
    {
        _webRootPath = webRootPath;
    }

    public string SaveFile(IFormFile file, string folderName)
    {
        var folderPath = Path.Combine(_webRootPath, folderName);
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var fullPath = Path.Combine(folderPath, fileName);

        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        // ترجع اسم الصورة أو الرابط حسب ما تفضّل
        return Path.Combine(folderName, fileName).Replace("\\", "/");
    }

    public bool DeleteFile(string fileName, string folderName)
    {
        var fullPath = Path.Combine(_webRootPath, folderName, fileName);
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
            return true;
        }
        return false;
    }
}
