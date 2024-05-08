using IntegraApp.Application.Models;


namespace IntegraApp.Application.Feature
{
    public class ImageFileManager : IFileManager
    {
        private readonly string _fotosDirectory = "/Fotos/";
        

        public async Task<string> SaveAsync(FileManagerModel model)
        {
            if (model.Archivo == null || model.Archivo!.Length == 0)
            {
                return _fotosDirectory;
            }

            try
            {
                string base_path = $"wwwroot{_fotosDirectory}";

                // Validar que exista el directorio 
                if (!Directory.Exists(base_path))
                {
                    Directory.CreateDirectory(base_path);
                }

                // Validar si existe el archivo
                if (model.fileName != null && model.Archivo != null)
                {
                    await this.DeleteAsync(model.fileName);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Archivo.FileName);
                var imagePath = "wwwroot" + _fotosDirectory + fileName;

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await model.Archivo.CopyToAsync(fileStream);
                }


                return Path.Combine(_fotosDirectory, fileName);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la imagen.", ex);
            }
        }

        public async Task DeleteAsync(string filePath)
        {
            try
            {
                string file = "wwwroot" + filePath;
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el archivo.", ex);
            }
        }

    }
}
