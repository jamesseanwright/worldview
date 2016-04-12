using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace WorldView.Music
{
    abstract class MusicLoader
    {
        public abstract string GetRandomTrack();
    }
}
