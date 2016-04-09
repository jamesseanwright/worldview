using System.Runtime.Serialization;

namespace UnsplashRoulette.Photos.Unsplash
{
    [DataContract]
    class UnsplashLocation
    {
        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "country")]
        public string Country { get; set; }
    }
}
