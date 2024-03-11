using Newtonsoft.Json;
using RestSharpProject.RestSharp.EndPoints;
using System.Net.Http.Headers;

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
      var response = await _httpClient.GetAsync(_endpoints.ArtistEndPoint);
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
        var response = await _httpClient.GetAsync(_endpoints.GenresEndPoint);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var allGenres = JsonConvert.DeserializeObject<List<Genres>>(responseJsonResult);

        var newGenre = new Genres
        {
            Name = Guid.NewGuid().ToString(),
            GenreId = allGenres.OrderBy(x => x.GenreId).Last().GenreId + 1,
        };
        return newGenre;
    }

    protected async Task<Album> CreateUniqueAlbum()
    {

        var response = await _httpClient.GetAsync(_endpoints.AlbumsEndPoint);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var allAlbums = JsonConvert.DeserializeObject<List<Album>>(responseJsonResult);


        var newAlbum = new Album()
        {
            AlbumId = allAlbums.OrderBy(x => x.AlbumId).Last().AlbumId + 1,
            Title = Guid.NewGuid().ToString(),
            ArtistId = 134,
            Artist = null

        };

        return newAlbum;
    }

    protected async Task<Tracks> CreateUniqueTrack()
    {

        var response = await _httpClient.GetAsync(_endpoints.TrackEndPoint);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var allTracks = JsonConvert.DeserializeObject<List<Tracks>>(responseJsonResult);

        var newTrack = new Tracks()
        {
            TrackId = allTracks.OrderBy(x => x.TrackId).Last().TrackId + 1,
            Name = Guid.NewGuid() + "TrackName".ToString(),
            MediaTypeId = 1,
            Composer = Guid.NewGuid() + "ComposerName".ToString(),
            UnitPrice = Guid.NewGuid() + "88".ToString(),

        };
        return newTrack;
    }
}