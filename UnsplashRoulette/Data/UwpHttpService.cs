using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http.Headers;
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
            this.httpClient = new Windows.Web.Http.HttpClient();
            this.headers = httpClient.DefaultRequestHeaders;
        }

        public async override Task<IInputStream> GetAsync(string url, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                AddHeaders(headers);
            }

            HttpResponseMessage response = await this.httpClient.GetAsync(new Uri(url));
            return await response.Content.ReadAsInputStreamAsync();
        }

        private void AddHeaders(Dictionary<string, string> headers)
        {
            foreach (KeyValuePair<string, string> header in headers)
            {
                this.headers.Add(header.Key, header.Value);
            }
        }
    }
}
