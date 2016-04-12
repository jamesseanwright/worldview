using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace WorldView.Music
{
    class UwpMusicLoader : MusicLoader
    {
        private int currentTrack;

        private const double NoTracks = 5; // TODO: read number of files in dir

        public override string GetRandomTrack()
        {
            int track = currentTrack;

            while (track == currentTrack)
            {
                track = (int)Math.Round(new Random().NextDouble() * NoTracks);
            }

            currentTrack = track;
            
            return string.Format("ms-appx:///Music/Tracks/{0}.mp3", track);
        }
    }
}
