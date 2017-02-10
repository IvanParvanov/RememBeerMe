namespace RememBeer.Business.Common.Utils
{
    public interface IImageUploadService
    {
        string UploadImageSync(byte[] image, int width, int height);
    }
}
