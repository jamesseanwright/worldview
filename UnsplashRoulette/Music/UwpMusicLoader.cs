using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace UnsplashRoulette.Music
{
    class UwpMusicLoader : MusicLoader
    {
        private const int NoTracks = 5; // TODO: read number of files in dir

        public override async Task<IRandomAccessStream> GetRandomTrackAsync()
        {
            int fileNumber = (int) Math.Round((double) new Random().Next() * NoTracks);
            Uri fileUri = new Uri(string.Format("ms-appx:///Music/Tracks/{0}.mp3", fileNumber));
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(fileUri);
            IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read);
            return stream;
        }
    }
}
