using System.Threading.Tasks;

namespace UnsplashRoulette.Photos
{
    interface IPhotoService
    {
        Task<Photo> GetRandomPhotoAsync(int width, int height);
    }
}
