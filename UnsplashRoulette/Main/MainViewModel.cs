using System;
using System.IO;
using System.Threading.Tasks;
using UnsplashRoulette.Device;
using UnsplashRoulette.Framework;
using UnsplashRoulette.Photos;

namespace UnsplashRoulette.Main
{
    class MainViewModel : ViewModel
    {
        PhotoService photoService;
        Viewport viewport;

        const int SlideDurationSeconds = 10;

        public MainViewModel(PhotoService photoService, Viewport viewport)
        {
            this.photoService = photoService;
            this.viewport = viewport;
        }

        public async override void OnNavigatedTo()
        {
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
