

using BL.Contracts.GeneralService.CMS;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace BL.GeneralService.CMS
{
    public class FileHandlerService : IFileHandlerService
    {
        private readonly IWebHostEnvironment _env;

        public FileHandlerService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<byte[]> GetFileBytesAsync(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        public async Task<byte[]> GetFileBytesAsync(string base64String)
        {
            // Simulate async operation, if needed
            return await Task.Run(() => Convert.FromBase64String(base64String));
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Invalid file.");

            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return filePath;
        }

        public async Task<string> UploadFileAsync(byte[] fileBytes, string folderName)
        {
            // Create the uploads folder if it doesn't exist
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", folderName);
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            //   WebP  100%
            var imageProcessor = new ImageProcessingService();
            var processedImage = imageProcessor.ConvertToWebP(fileBytes, quality: 100);

            // Generate a new GUID and append the original file extension
            var uniqueFileName = $"{Guid.NewGuid()}.webp";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);
            int index = filePath.IndexOf("uploads");
            string relativePath = filePath.Substring(index);

            // Write the file bytes to the specified path
            await File.WriteAllBytesAsync(filePath, processedImage);

            return relativePath;
        }

        public bool IsValidFile(IFormFile file)
        {
            return ValidateFile(file).isValid;
        }

        public bool IsValidFile(string base64File, string fileName)
        {
            // Implementation for base64 string validation
            throw new NotImplementedException();
        }

        public (bool isValid, string errorMessage) ValidateFile(IFormFile file)
        {
            if (file == null)
                return (false, "File is null.");

            if (!file.ContentType.StartsWith("image/"))
                return (false, "Invalid file type. Only images are allowed.");

            return (true, string.Empty);
        }

        public (bool isValid, string errorMessage) ValidateFile(string base64String)
        {
            if (string.IsNullOrEmpty(base64String)) return (false, "File is null.");

            Span<byte> buffer = new Span<byte>(new byte[base64String.Length]);
            return (Convert.TryFromBase64String(base64String, buffer, out _), "File is not valid");
        }
    }
}
