using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnsplashRoulette.Photos
{
    interface IPhotoService
    {
        Photo GetRandomPhoto(int width, int height);
    }
}
