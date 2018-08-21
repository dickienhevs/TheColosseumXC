using Colosseum.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Colosseum.Services
{
    public class ApiServices
    {
        private readonly string nowPlayingMoviesUrl = "http://colosseum.somee.com/api/NowPlayingMovies";
        private readonly string upComingMoviesUrl = "http://colosseum.somee.com/api/UpComingMovies";
        private readonly string orderApiUrl = "http://colosseum.somee.com/api/Orders";
        private readonly string latestMoviesUrl = "http://colosseum.somee.com/api/LatestMovies";

        public async Task<List<NowPlayingMovie>> GetNowPlayingMovies()
        {
            var client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, nowPlayingMoviesUrl);
            requestMessage.Headers.Add("ApiKey", "fd78d5db-fe18-43d6-b690-d582373b9a1c");
            var responseMessage = await client.SendAsync(requestMessage);
            var movieResponse = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<NowPlayingMovie>>(movieResponse);
        }

        public async Task<List<UpComingMovie>> GetUpComingMovies()
        {
            var client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, upComingMoviesUrl);
            requestMessage.Headers.Add("ApiKey", "fd78d5db-fe18-43d6-b690-d582373b9a1c");
            var responseMessage = await client.SendAsync(requestMessage);
            var movieResponse = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<UpComingMovie>>(movieResponse);
        }

        public async Task<bool> Order(BookTicket bookTicket)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(bookTicket);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.Add("ApiKey", "fd78d5db-fe18-43d6-b690-d582373b9a1c");
            var response = await client.PostAsync(orderApiUrl, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<LatestMovie>> GetLatestMovies()
        {
            var client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, latestMoviesUrl);
            requestMessage.Headers.Add("ApiKey", "fd78d5db-fe18-43d6-b690-d582373b9a1c");
            var responseMessage = await client.SendAsync(requestMessage);
            var movieResponse = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<LatestMovie>>(movieResponse);
        }
    }
}