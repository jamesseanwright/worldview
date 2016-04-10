using System.Threading.Tasks;

namespace UnsplashRoulette.Photos
{
    abstract class PhotoService
    {
        public abstract Task<Photo> GetRandomPhotoAsync(int width, int height);
    }
}
