using Microsoft.AspNetCore.Http;

namespace BL.Contracts.GeneralService.CMS
{
    public interface IFileHandlerService
    {
        Task<byte[]> GetFileBytesAsync(IFormFile file);
        Task<string> UploadFileAsync(IFormFile file);
        bool IsValidFile(IFormFile file);
        (bool isValid, string errorMessage) ValidateFile(IFormFile file);
       
    }
}
