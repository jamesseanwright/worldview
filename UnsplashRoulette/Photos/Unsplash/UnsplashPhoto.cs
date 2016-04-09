using System.Runtime.Serialization;

namespace UnsplashRoulette.Photos.Unsplash
{
    [DataContract]
    class UnsplashPhoto
    {
        [DataMember(Name = "location")]
        public UnsplashLocation Location { get; set; }

        [DataMember(Name = "user")]
        public UnsplashUser User { get; set; }

        [DataMember(Name = "urls")]
        public UnsplashPhotoCollection PhotoCollection { get; set; }
    }
}
