using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using UnsplashRoulette.Data;
using UnsplashRoulette.Device;

namespace UnsplashRoulette.Photos.Unsplash
{
    class UnsplashService : PhotoService
    {
        const string ApiRoot = "https://api.unsplash.com";
        const string RandomPhotoEndpoint = "/photos/random";
        const string ClientId = "f043222b94ef01e497478ec1a0f025759a7ef31b552b7484831207268f49c6db";

        HttpService httpService;
        Deserialiser deserialiser;

        public UnsplashService(HttpService httpService, Deserialiser deserialiser)
        {
            this.httpService = httpService;
            this.deserialiser = deserialiser;
            AddHeaders();
        }

        public async override Task<Photo> GetRandomPhotoAsync(int width, int height)
        {
            string url = String.Format("{0}{1}?w={2}&h={3}", ApiRoot, RandomPhotoEndpoint, width, height);

            using (Stream data = await this.httpService.GetAsync(url))
            {
                UnsplashPhoto unsplashPhoto = this.deserialiser.DeserialiseTo<UnsplashPhoto>(data);
                return MapToPhoto(unsplashPhoto);
            }
        }

        public async override Task<Stream> GetPhotoDataAsync(string url)
        {
            Stream data = await this.httpService.GetAsync(url);
            return data;
        }

        private void AddHeaders()
        {
            this.httpService.AddHeaders(
                new Dictionary<string, string>
                {
                    ["Authorization"] = String.Format("Client-ID {0}", ClientId)
                }
            );
        }

        private Photo MapToPhoto(UnsplashPhoto unsplashPhoto)
        {
            return new Photo
            {
                Url = unsplashPhoto.PhotoCollection.Custom,

                User = new User
                {
                    Name = unsplashPhoto.User.Name,
                    Avatar = unsplashPhoto.User.AvatarCollection.Medium
                },

                Location = new Location
                {
                    City = unsplashPhoto.Location?.City,
                    Country = unsplashPhoto.Location?.Country
                }
            };
        }
    }
}
