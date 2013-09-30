using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace TweetLittleBird.ApiProxy
{
    public interface IHttpClientWrapper
    {
        HttpResponseMessage Post(string uri, ObjectContent content);
        HttpResponseMessage Get(string uri, IDictionary<string, string> headers);
        TResult Post<T, TResult>(string uri, IDictionary<string, string> headers, T request);
        TResult Get<T, TResult>(string uri, IDictionary<string, string> headers, T request);
    }


    public class HttpClientWrapper : IHttpClientWrapper
    {
        public HttpResponseMessage Post(string uri, ObjectContent content)
        {
            return new HttpClient().PostAsync(uri, content).Result;
        }

        public HttpResponseMessage Get(string uri, IDictionary<string, string> headers)
        {
            var httpClient = new HttpClient();

            foreach (var header in headers)
            {
                httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            return httpClient.GetAsync(uri).Result;
        }

        public TResult Post<T, TResult>(string uri, IDictionary<string, string> headers, T request)
        {
            var content = new ObjectContent<T>(request, new JsonMediaTypeFormatter());

            foreach (var header in headers)
            {
                content.Headers.Add(header.Key, header.Value);
            }

            return
                new HttpClient().PostAsync(uri, content)
                                .ContinueWith(e => e.Result.Content.ReadAsAsync<TResult>().Result)
                                .Result;
        }

        public TResult Get<T, TResult>(string uri, IDictionary<string, string> headers, T request)
        {
            var queryString = request.ToQueryString();
            var httpClient = new HttpClient();

            foreach (var header in headers)
            {
                httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            return
                httpClient.GetAsync(string.Concat(uri, queryString))
                          .ContinueWith(e => e.Result.Content.ReadAsAsync<TResult>().Result)
                          .Result;
        }
    }
}