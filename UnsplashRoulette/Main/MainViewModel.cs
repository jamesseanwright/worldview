using System.Threading;
using System.Threading.Tasks;
using UnsplashRoulette.Framework;
using UnsplashRoulette.Photos;

namespace UnsplashRoulette.Main
{
    class MainViewModel : ViewModel
    {
        IPhotoService photoService;
        Timer slideshowTimer;


        public MainViewModel(IPhotoService photoService)
        {
            this.photoService = photoService;
        }

        public async override void OnNavigatedTo()
        {
            await UpdatePhotoAsync();
        }

        public override void OnNavigatedFrom()
        {
            base.OnNavigatedFrom();
            this.slideshowTimer.Dispose();
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
            Photo photo = await this.photoService.GetRandomPhotoAsync(1920, 1080);
            Image = photo.Url;
        }
    }
}
