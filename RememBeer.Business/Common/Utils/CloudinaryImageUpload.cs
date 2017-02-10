using System;
using System.IO;

using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

using RememBeer.Common.Configuration;

namespace RememBeer.Business.Common.Utils
{
    public class CloudinaryImageUpload : IImageUploadService
    {
        private readonly Cloudinary cloud;

        public CloudinaryImageUpload(IConfigurationProvider config)
        {
            var name = config.ImageUploadName;
            var key = config.ImageUploadApiKey;
            var secret = config.ImageUploadApiSecret;
            var dir = Directory.GetCurrentDirectory();
            var account = new CloudinaryDotNet.Account(name, key, secret);

            this.cloud = new Cloudinary(account);
        }

        public string UploadImageSync(byte[] image, int width, int height)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            Stream stream = new MemoryStream(image);
            var id = Guid.NewGuid().ToString();
            var para = new ImageUploadParams
                       {
                           File = new FileDescription(id, stream),
                           Transformation = new Transformation().Width(width).Height(height).Crop("fit")
                       };

            var result = this.cloud.Upload(para);

            return result.Uri.AbsoluteUri;
        }
    }
}
