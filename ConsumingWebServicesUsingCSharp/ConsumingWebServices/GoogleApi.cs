namespace ConsumingWebServices
{
    using System.Net;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    public static class GoogleApi
    {
        private const string BaseUrl = "http://www.google.com/";

        private const string BaseQyery = "?q=";

        public static ICollection<NewsDto> GetResults(string queryString, int count = 10)
        {
            var response = ParseJsonResponse(GetJson(GenerateUrl(queryString, count)));

            if (response == null)
            {
                return new List<NewsDto>();
            }

            return new List<NewsDto>(response);
        }

        private static string GetJson(string url)
        {
            string json = string.Empty;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(url);
            }

            return json;
        }

        private static IEnumerable<NewsDto> ParseJsonResponse(string json)
        {
            var response = JsonConvert.DeserializeObject<NewsDto>(json);

            return null;
        }

        private static string GenerateUrl(string question, int count)
        {
            var url = BaseUrl;

            if (!string.IsNullOrEmpty(question))
            {
                url += "?q=" + question.Replace(" ", "%20");
            }

            url += "&count=" + count;

            return url;
        }
    }
}
