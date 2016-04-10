using System;
using System.Threading;
using System.Threading.Tasks;
using UnsplashRoulette.Framework;
using UnsplashRoulette.Photos;

namespace UnsplashRoulette.Main
{
    class MainViewModel : ViewModel
    {
        PhotoService photoService;

        const int SlideDurationSeconds = 10;

        public MainViewModel(PhotoService photoService)
        {
            this.photoService = photoService;
        }

        public async override void OnNavigatedTo()
        {
            await UpdatePhotoAsync();
        }

        private string image;
        public string Image
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
            Photo photo = await this.photoService.GetRandomPhotoAsync(3840, 2160);
            Image = photo.Url;
            await EnqueueUpdate();
        }

        private async Task EnqueueUpdate()
        {
            await Task.Delay(TimeSpan.FromSeconds(SlideDurationSeconds));
            await UpdatePhotoAsync();
        }
    }
}
