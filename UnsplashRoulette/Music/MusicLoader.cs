using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace UnsplashRoulette.Music
{
    abstract class MusicLoader
    {
        public abstract Task<IRandomAccessStream> GetRandomTrackAsync();
    }
}
