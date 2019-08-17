using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Bds.TechTest.Wpf.SearchService.Bds.TechTest;
using Newtonsoft.Json;

namespace Bds.TechTest.Wpf.SearchService.GNews
{
    /// <remarks>https://newsapi.org/docs/get-starteds</remarks>
    public class GNewsEngine : ISearchEngine
    {
        private readonly HttpClient httpClient;

        public GNewsEngine()
        {
            httpClient = new HttpClient();
        }

        public async Task<IEnumerable<SearchResult>> GetSearchResults(string phrase)
        {
            var url = GetUrl("https://newsapi.org/v2/everything", phrase);
            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                var response = await httpClient.SendAsync(request).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                    return new SearchResult[0];

                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var results = JsonConvert.DeserializeObject<GNewsResult>(json);
                return results.Articles.Select(r => new SearchResult());
            }
        }

        private static string GetUrl(string baseUrl, string phrase)
        {
            using (var apiToken = GetApiToken())
            {
                string password = new System.Net.NetworkCredential(string.Empty, apiToken).Password;
                return $"{baseUrl}?q={phrase}&sortBy=popularity&apiKey={password}";
            }
        }

        private static SecureString GetApiToken()
        {
            var x = "uwqRE+B/zldlj8ml/kIQdzgwTd3c8HUPVR6YV/Eg74BLGJJkqXvuwg==";
            var hash = "68cd6b8f2323421f9461012c6e112cd0";
            byte[] data = Convert.FromBase64String(x);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    var sec = new SecureString();
                    UTF8Encoding.UTF8.GetString(results).ToList().ForEach(sec.AppendChar);
                    return sec;
                }
            }
        }
    }
}