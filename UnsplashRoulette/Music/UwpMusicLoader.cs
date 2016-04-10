using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace UnsplashRoulette.Music
{
    class UwpMusicLoader : MusicLoader
    {
        private const double NoTracks = 5; // TODO: read number of files in dir

        public override string GetRandomTrack()
        {
            int fileNumber = (int) Math.Round(new Random().NextDouble() * NoTracks);
            return string.Format("ms-appx:///Music/Tracks/{0}.mp3", fileNumber);
        }
    }
}
