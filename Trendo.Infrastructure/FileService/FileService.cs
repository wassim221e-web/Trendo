using Microsoft.AspNetCore.Http;
using Trendo.Application.File.Interface;

public class FileService : IFileService
{
    private readonly string _webRootPath;
    private readonly string _baseUrl;

    private readonly List<string> _allowedExtensions = [".jpg", ".jpeg", ".png", ".webp"];
    private const long _maxFileSize = 2 * 1024 * 1024; // 2MB

    public FileService(string webRootPath, string baseUrl)
    {
        _webRootPath = webRootPath;
        _baseUrl = baseUrl.TrimEnd('/');
    }

    public string SaveFile(IFormFile file, string folderName)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("الملف غير موجود.");

        if (file.Length > _maxFileSize)
            throw new ArgumentException("الملف أكبر من الحد المسموح به (2MB).");

        var extension = Path.GetExtension(file.FileName).ToLower();
        if (!_allowedExtensions.Contains(extension))
            throw new ArgumentException("نوع الملف غير مسموح. الملفات المدعومة: jpg, jpeg, png, webp.");

        var folderPath = Path.Combine(_webRootPath, folderName);
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        var fileName = Guid.NewGuid() + extension;
        var fullPath = Path.Combine(folderPath, fileName);

        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        var relativePath = Path.Combine(folderName, fileName).Replace("\\", "/");
        return $"{_baseUrl}/{relativePath}";
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