namespace testproject;

using System;
using System.Net.Http;
using System.Threading.Tasks;

public class ContentService
{
    private readonly HttpClient _httpClient;

    public ContentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> GetContentLengthAsync(string url)
    {
        if (string.IsNullOrEmpty(url))
            throw new ArgumentException("URL cannot be null or empty.", nameof(url));

        using (var httpClient = new HttpClient())
        {
            try
            {
                var content = await httpClient.GetStringAsync(url);
                return content.Length;
            }
            catch (HttpRequestException e)
            {
                throw new InvalidOperationException("Error retrieving content.", e);
            }
        }
    }
}