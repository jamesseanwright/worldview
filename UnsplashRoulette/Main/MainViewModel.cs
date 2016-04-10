using System;
using System.IO;
using System.Threading.Tasks;
using UnsplashRoulette.Device;
using UnsplashRoulette.Framework;
using UnsplashRoulette.Music;
using UnsplashRoulette.Photos;
using Windows.Storage.Streams;

namespace UnsplashRoulette.Main
{
    class MainViewModel : ViewModel
    {
        PhotoService photoService;
        Viewport viewport;
        MusicLoader musicLoader

        const int SlideDurationSeconds = 10;

        public MainViewModel(PhotoService photoService, Viewport viewport, MusicLoader musicLoader)
        {
            this.photoService = photoService;
            this.viewport = viewport;
            this.musicLoader = musicLoader;
        }

        public async override void OnNavigatedTo()
        {
            await SetMusicAsync();
            await UpdatePhotoAsync();
        }

        private Stream image;
        public Stream Image
        {
            get
            {
                return this.image;
            }

            set
            {
                this.image = value;
                RaisePropertyChanged();
            }
        }

        private IRandomAccessStream music;
        public IRandomAccessStream Music
        {
            get
            {
                return this.music;
            }

            set
            {
                this.music = value;
                RaisePropertyChanged();
            }
        }

        private async Task SetMusicAsync()
        {
            IRandomAccessStream musicData = await this.musicLoader.GetRandomTrackAsync();
        }

        private async Task UpdatePhotoAsync()
        {
            Size screenSize = this.viewport.GetNormalisedAppSize();
            Photo photo = await this.photoService.GetRandomPhotoAsync((int) screenSize.Width * 2, (int) screenSize.Height * 2);

            using (Stream photoData = await this.photoService.GetPhotoDataAsync(photo.Url))
            {
                Image = photoData;
            }

            await EnqueueUpdate();
        }

        private async Task EnqueueUpdate()
        {
            await Task.Delay(TimeSpan.FromSeconds(SlideDurationSeconds));
            await UpdatePhotoAsync();
        }
    }
}
