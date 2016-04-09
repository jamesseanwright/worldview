using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace UnsplashRoulette.Http
{
    abstract class HttpService
    {
        public abstract Task<IInputStream> GetAsync(string url, Dictionary<string, string> headers);
    }
}
