using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Web.Http.Headers;
using Windows.Web.Http.Filters;
using Windows.Web.Http;
using Windows.Storage.Streams;

namespace UnsplashRoulette.Data
{
    class UwpHttpService : HttpService
    {
        HttpClient httpClient;
        HttpRequestHeaderCollection headers;

        public UwpHttpService()
        {
            this.httpClient = new HttpClient(GetProtocolFilter());
            this.headers = httpClient.DefaultRequestHeaders;
        }

        private HttpBaseProtocolFilter GetProtocolFilter()
        {
            HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();
            filter.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;
            return filter;
        }

        public async override Task<Stream> GetAsync(string url)
        {
            HttpResponseMessage response = await this.httpClient.GetAsync(new Uri(url));
            IInputStream inputStream = await response.Content.ReadAsInputStreamAsync();
            return inputStream.AsStreamForRead();
        }

        public override void AddHeaders(Dictionary<string, string> headers)
        {
            foreach (KeyValuePair<string, string> header in headers)
            {
                this.headers.Add(header.Key, header.Value);
            }
        }
    }
}
