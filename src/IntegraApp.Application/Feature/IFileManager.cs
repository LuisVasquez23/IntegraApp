using IntegraApp.Application.Models;
using Microsoft.AspNetCore.Http;

namespace IntegraApp.Application.Feature
{
    public interface IFileManager
    {
        Task<string> SaveAsync(FileManagerModel model);
        Task DeleteAsync(string filePath);
    }
}
