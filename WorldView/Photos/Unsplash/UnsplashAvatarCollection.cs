using System.Runtime.Serialization;

namespace WorldView.Photos.Unsplash
{
    [DataContract]
    class UnsplashAvatarCollection
    {
        [DataMember(Name = "medium")]
        public string Medium { get; set; }
    }
}
