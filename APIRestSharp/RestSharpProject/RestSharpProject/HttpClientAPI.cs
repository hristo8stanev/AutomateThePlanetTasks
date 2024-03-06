using System.Net.Http.Headers;
using System.Text;
using Examples.Models;
using Newtonsoft.Json;
using RestSharp;
namespace RestSharpProject;

public class HttpClientAPI
{

    private static HttpClient _httpClient;
    private const string BASE_URL = "https://localhost:60714/";

    [OneTimeSetUp]
    public void ClassInitialize()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(BASE_URL);
        _httpClient.Timeout = TimeSpan.FromMinutes(3);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJiZWxsYXRyaXhVc2VyIiwianRpIjoiNjEyYjIzOTktNDUzMS00NmU0LTg5NjYtN2UxYmRhY2VmZTFlIiwibmJmIjoxNTE4NTI0NDg0LCJleHAiOjE1MjM3MDg0ODQsImlzcyI6ImF1dG9tYXRldGhlcGxhbmV0LmNvbSIsImF1ZCI6ImF1dG9tYXRldGhlcGxhbmV0LmNvbSJ9.Nq6OXqrK82KSmWNrpcokRIWYrXHanpinrqwbUlKT_cs");
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    }

    [OneTimeTearDown]
    public void TestCleanup()
    {
        _httpClient.Dispose();

    }

    //DELETE REQUEST
    private async Task<Artists> CreateUniqueArtists()
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
   
    [Test]
    public async Task ArtistsDeleted_When_PerformDeleteRequest()
    {
        var newArtist = await CreateUniqueArtists();
        var json = JsonConvert.SerializeObject(newArtist);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("api/Artists", data);

        var deleteResponse = await _httpClient.DeleteAsync($"api/Artists/{newArtist.ArtistId}");

        Assert.IsTrue(deleteResponse.IsSuccessStatusCode);
    }

    //PUT REQUEST
    private async Task<Genres> CreateUniqueGenres()
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

    [Test]
    public async Task ContentPopulated_When_PutModifiedContent()
    {
        var newGenre = await CreateUniqueGenres();
        var json = JsonConvert.SerializeObject(newGenre);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("api/Genres", data);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var insertedGenres = JsonConvert.DeserializeObject<Genres>(responseJsonResult);

        string updatedName = Guid.NewGuid().ToString();
        insertedGenres.Name = updatedName;
        json = JsonConvert.SerializeObject(insertedGenres);
        data = new StringContent(json, Encoding.UTF8, "application/json");

        await _httpClient.PutAsync($"api/Genres/{insertedGenres.GenreId}", data);

        var getResponse = await _httpClient.GetAsync($"api/Genres/{insertedGenres.GenreId}");
        var getResponseJsonResult = await getResponse.Content.ReadAsStringAsync();
        var actualUpdatedGenres = JsonConvert.DeserializeObject<Genres>(getResponseJsonResult);

        Assert.AreEqual(updatedName, actualUpdatedGenres.Name);
    }

    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbums()
    {
        var response = await _httpClient.GetAsync("api/Albums");
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var albums = JsonConvert.DeserializeObject<List<Albums>>(responseJsonResult);

        Assert.AreEqual(544, albums.Count);
    }

    [Test]
    public async Task ContentPopulated_When_GetAlbums()
    {
        var response = await _httpClient.GetAsync("api/Albums");
      
        response.EnsureSuccessStatusCode();
    }

    [Test]
    public async Task ContentPopulated_When_SendAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "api/Albums");
        var response = await _httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();
    }

}