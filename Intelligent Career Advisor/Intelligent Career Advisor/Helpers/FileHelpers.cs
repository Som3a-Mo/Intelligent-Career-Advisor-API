namespace Intelligent_Career_Advisor.Helpers;

public class FileHelpers
{

    public static async Task<string?> SaveFileAsync(IFormFile file, string folderName, IHttpContextAccessor _httpContextAccessor, IWebHostEnvironment _env)
    {
        if (file == null)
            return null;
        var origin = _httpContextAccessor.HttpContext?.Request;
        var uploadsPath = Path.Combine(_env.WebRootPath, folderName);
        if (!Directory.Exists(uploadsPath))
            Directory.CreateDirectory(uploadsPath);
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(uploadsPath, fileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        var imageUrl = $"{origin.Scheme}://{origin.Host}/{folderName}/{fileName}";
        return imageUrl;
    }

    public static void DeleteFile(string fileUrl, string folderName, IWebHostEnvironment _env)
    {
        if (string.IsNullOrEmpty(fileUrl))
            return;
        var imageFileName = Path.GetFileName(new Uri(fileUrl).LocalPath);
        var filePath = Path.Combine(_env.WebRootPath, folderName, imageFileName);

        if (System.IO.File.Exists(filePath))
            System.IO.File.Delete(filePath);
        return;
    }
}
