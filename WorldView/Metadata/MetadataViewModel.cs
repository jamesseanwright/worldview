using System.IO;
using System.Threading.Tasks;
using WorldView.Framework;
using WorldView.Photos;

namespace WorldView.Metadata
{
    class MetadataViewModel : ViewModel
    {
        private const string LocationUnknown = "Location Unknown";

        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.name = value;
               RaisePropertyChanged();
            }
        }

        private string location;
        public string Location
        {
            get
            {
                return this.location;
            }

            private set
            {
                this.location = value;
               RaisePropertyChanged();
            }
        }

        private Stream avatar;
        public Stream Avatar
        {
            get
            {
                return this.avatar;
            }

            private set
            {
                this.avatar = value;
                RaisePropertyChanged();
            }
        }

        public async Task UpdateAsync(Photo photo, PhotoService photoService)
        {
            Avatar = await photoService.GetPhotoDataAsync(photo.User.Avatar);
            Name = photo.User.Name;
            Location location = photo.Location;
            bool isLocationValid = location.City != null && location.Country != null;
            Location = isLocationValid ? string.Format("{0}, {1}", location.City, location.Country) : LocationUnknown;
        }
    }
}
