using System;
using System.IO;
using System.Threading.Tasks;
using WorldView.Device;
using WorldView.Framework;
using WorldView.Metadata;
using WorldView.Music;
using WorldView.Photos;

namespace WorldView.Main
{
    class MainViewModel : ViewModel
    {
        PhotoService photoService;
        Viewport viewport;
        MusicLoader musicLoader;

        // excludes image download times. Will fix!
        const int SlideDurationSeconds = 10;

        public MainViewModel(PhotoService photoService, Viewport viewport, MusicLoader musicLoader)
        {
            this.photoService = photoService;
            this.viewport = viewport;
            this.musicLoader = musicLoader;

            Metadata = new MetadataViewModel();
        }

        public async override void OnNavigatedTo()
        {
            SetTrack();
            await UpdatePhotoAsync();
        }

        private Stream image;
        public Stream Image
        {
            get
            {
                return this.image;
            }

            private set
            {
                this.image = value;
                RaisePropertyChanged();
            }
        }

        private string track;
        public string Track
        {
            get
            {
                return this.track;
            }

            private set
            {
                this.track = value;
                RaisePropertyChanged();
            }
        }

        private MetadataViewModel metadata;
        public MetadataViewModel Metadata
        {
            get
            {
                return this.metadata;
            }

            private set
            {
                this.metadata = value;
                RaisePropertyChanged();
            }
        }

        public void OnTrackEnded()
        {
            SetTrack();
        }

        private void SetTrack()
        {
            Track = this.musicLoader.GetRandomTrack();
        }

        private async Task UpdatePhotoAsync()
        {
            Size screenSize = this.viewport.GetNormalisedAppSize();
            Photo photo = await this.photoService.GetRandomPhotoAsync((int) screenSize.Width * 2, (int) screenSize.Height * 2);

            using (Stream photoData = await this.photoService.GetPhotoDataAsync(photo.Url))
            {
                Image = photoData;
                await Metadata.UpdateAsync(photo, this.photoService);
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
