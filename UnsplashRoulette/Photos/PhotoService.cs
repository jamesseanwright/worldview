using System.IO;
using System.Threading.Tasks;

namespace WorldView.Photos
{
    abstract class PhotoService
    {
        public abstract Task<Photo> GetRandomPhotoAsync(int width, int height);
        public abstract Task<Stream> GetPhotoDataAsync(string url);
    }
}
