using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace UnsplashRoulette.Data
{
    abstract class HttpService
    {
        public abstract Task<Stream> GetAsync(string url);
        public abstract void AddHeaders(Dictionary<string, string> headers);
    }
}
