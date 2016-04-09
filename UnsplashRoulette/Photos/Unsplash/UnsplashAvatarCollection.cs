using System.Runtime.Serialization;

namespace UnsplashRoulette.Photos.Unsplash
{
    [DataContract]
    class UnsplashAvatarCollection
    {
        [DataMember(Name = "medium")]
        public string Medium { get; set; }
    }
}
