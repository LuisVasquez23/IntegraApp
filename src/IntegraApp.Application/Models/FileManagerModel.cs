using Microsoft.AspNetCore.Http;

namespace IntegraApp.Application.Models
{
    public class FileManagerModel
    {
        public IFormFile? Archivo { get; set; }
        public string? fileName {  get; set; }
    }
}
