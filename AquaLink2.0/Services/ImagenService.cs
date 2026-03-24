using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;

namespace AquaLink2._0.Services
{
    public class ImagenService : IImagenService
    {
        private readonly Cloudinary _cloudinary;

        public ImagenService(IOptions<CloudinarySettings> config)
        {
            var acc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
                );
            _cloudinary = new Cloudinary(acc);
        }

        public async Task<ImageUploadResult> SubirImagenAsync(IFormFile archivo)
        {
            var uploadResult = new ImageUploadResult();

            if (archivo.Length > 0)
            {
                using var stream = archivo.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(archivo.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill")
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }
    }
}
