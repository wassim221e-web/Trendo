using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Trendo.Application.File.Interface;
using Trendo.Infrastructure;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _env;

    public FileService(IWebHostEnvironment env)
    {
        _env = env;
    }
    
    public async Task<string?> Upload(IFormFile file, string folderName)
    {
        if (file.Length is 0)
            return null;
        
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var folderPath = Path.Combine(_env.WebRootPath, folderName);
        Directory.CreateDirectory(folderPath); 
        
        var path = Path.Combine(folderPath, fileName);

        await using var fileStream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(fileStream);
        return path;
    }

    
    public bool DeleteFile(string path)
    {
        if (File.Exists(path) == false)
        {
            return false;
        }
        File.Delete(path);
        return true;
    }
}