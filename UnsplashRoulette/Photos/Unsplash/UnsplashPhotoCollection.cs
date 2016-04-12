using System.Runtime.Serialization;

namespace WorldView.Photos.Unsplash
{
    [DataContract]
    class UnsplashPhotoCollection
    {
        [DataMember(Name = "custom")]
        public string Custom { get; set; }
    }
}
