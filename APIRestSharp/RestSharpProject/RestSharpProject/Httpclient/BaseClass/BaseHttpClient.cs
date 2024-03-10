using Newtonsoft.Json;
using RestSharpProject.RestSharp.EndPoints;
using System.Net.Http.Headers;
using System.Text;

namespace RestSharpProject.Httpclient.BaseClass;

[TestFixture]
public class BaseHttpClient
{

    protected int Wait = 2;
    protected Endpoints _endpoints;
   
    protected static HttpClient _httpClient;
    protected string BASE_URL => "https://localhost:60714/";

    [OneTimeSetUp]
    public void ClassInitialize()
    {
        _endpoints = new Endpoints();
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(BASE_URL);
        _httpClient.Timeout = TimeSpan.FromMinutes(Wait);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJiZWxsYXRyaXhVc2VyIiwianRpIjoiNjEyYjIzOTktNDUzMS00NmU0LTg5NjYtN2UxYmRhY2VmZTFlIiwibmJmIjoxNTE4NTI0NDg0LCJleHAiOjE1MjM3MDg0ODQsImlzcyI6ImF1dG9tYXRldGhlcGxhbmV0LmNvbSIsImF1ZCI6ImF1dG9tYXRldGhlcGxhbmV0LmNvbSJ9.Nq6OXqrK82KSmWNrpcokRIWYrXHanpinrqwbUlKT_cs");
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    [OneTimeTearDown]
    public void TestCleanup()
    { 
       _httpClient.Dispose();

    }
      protected async Task<Artists> CreateUniqueArtists()
  {
      var response = await _httpClient.GetAsync("api/Artists");
      var responseJsonResult = await response.Content.ReadAsStringAsync();
      var artists = JsonConvert.DeserializeObject<List<Artists>>(responseJsonResult);
      var newArtists = new Artists
      {
          Name = Guid.NewGuid().ToString(),
          ArtistId = artists.OrderBy(x => x.ArtistId).Last().ArtistId + 1,
      };
      return newArtists;
  }

  
    
    protected async Task<Genres> CreateUniqueGenres()
    {
        var response = await _httpClient.GetAsync("api/Genres");
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var allGenres = JsonConvert.DeserializeObject<List<Genres>>(responseJsonResult);
        var newGenre = new Genres
        {
            Name = Guid.NewGuid().ToString(),
            GenreId = allGenres.OrderBy(x => x.GenreId).Last().GenreId + 1,
        };
        return newGenre;
    }

}