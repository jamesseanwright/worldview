using System.Runtime.Serialization;

namespace UnsplashRoulette.Photos.Unsplash
{
    [DataContract]
    class UnsplashPhotoCollection
    {
        [DataMember(Name = "custom")]
        public string Custom { get; set; }
    }
}
