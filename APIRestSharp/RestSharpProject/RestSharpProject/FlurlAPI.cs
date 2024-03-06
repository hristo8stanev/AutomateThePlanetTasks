using System.Net.Http;
using System.Threading.Tasks;
using Examples.Models;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;


namespace RestSharpProject;
public class FlurlAPI
{

    private const string URL = "https://localhost:60714/api/";
    private Url BASE_URL = new Url(URL);
    private const string AUTH_TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJiZWxsYXRyaXhVc2VyIiwianRpIjoiNjEyYjIzOTktNDUzMS00NmU0LTg5NjYtN2UxYmRhY2VmZTFlIiwibmJmIjoxNTE4NTI0NDg0LCJleHAiOjE1MjM3MDg0ODQsImlzcyI6ImF1dG9tYXRldGhlcGxhbmV0LmNvbSIsImF1ZCI6ImF1dG9tYXRldGhlcGxhbmV0LmNvbSJ9.Nq6OXqrK82KSmWNrpcokRIWYrXHanpinrqwbUlKT_cs";

    [OneTimeSetUp]
    public void ClassInitialize()
    {
        var client = new FlurlClient(BASE_URL);
        client.Settings.Timeout = TimeSpan.FromSeconds(600);
        client.Settings.Redirects.Enabled = false;

    }

    [TearDown]
    public void TearDown()
    {
        RegenerateUrl();
    }
  
    /// GET REQUESTS
    [Test]
    public async Task ContentPopulated_When_SendAsync()
    {
        var response = await BASE_URL
             .AppendPathSegment("Albums")
             .WithOAuthBearerToken(AUTH_TOKEN)
             .SendAsync(HttpMethod.Get);

        response.ResponseMessage.EnsureSuccessStatusCode();
    }
    //////////////////////////////////////////
    [Test]
    public async Task DownloadImage()
    {
        var url = "https://www.automatetheplanet.com/wp-content/uploads/2020/03/atp_logo.svg";
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        string downloadedFilePath = await url.DownloadFileAsync(documentsPath, "atp_logo.svg");
        string localFilename = "atp_logo.svg";
        string expectedDownloadedFilePath = Path.Combine(documentsPath, localFilename);

        Assert.AreEqual(expectedDownloadedFilePath, downloadedFilePath);
    }
    //////////////////////////////////////////
    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbumsById()
    {
        var responseJsonResult = await BASE_URL
             .AppendPathSegment("Albums")
             .AppendPathSegment(10)
             .WithOAuthBearerToken(AUTH_TOKEN)
             .GetStringAsync();
        var result = JsonConvert.DeserializeObject<Albums>(responseJsonResult);

        Assert.AreEqual(10, result.AlbumId);
    }
    //////////////////////////////////////////
    //PUT REQUESTS
    private async Task<Genres> CreateUniqueGenres()
    {
        RegenerateUrl();
        var allGenres = await BASE_URL.AppendPathSegment("Genres")
                              .WithOAuthBearerToken(AUTH_TOKEN)
                              .GetJsonAsync<List<Genres>>();
        RegenerateUrl();

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

        var response = await BASE_URL.AppendPathSegments("Genres")
                                     .WithOAuthBearerToken(AUTH_TOKEN)
                                     .PostJsonAsync(newGenre);
        RegenerateUrl();

        var createdGenre = await response.GetJsonAsync<Genres>();

        string updatedName = Guid.NewGuid().ToString();
        createdGenre.Name = updatedName;

        var putResponse = await BASE_URL.AppendPathSegment("Genres")
                                .AppendPathSegment(createdGenre.GenreId)
                                .WithOAuthBearerToken(AUTH_TOKEN)
                                .PutJsonAsync(createdGenre);
        RegenerateUrl();

        var actualUpdatedGenres = await BASE_URL.AppendPathSegments("Genres")
                               .AppendPathSegment(createdGenre.GenreId)
                               .WithOAuthBearerToken(AUTH_TOKEN)
                               .GetJsonAsync<Genres>();
        RegenerateUrl();

        Assert.AreEqual(updatedName, actualUpdatedGenres.Name);
    }
    //////////////////////////////////////////
    //DELETE REQUEST
    [Test]
    public async Task ArtistsDeleted_When_PerformGenericDeleteRequest()
    {
        var newArtist = await CreateUniqueArtists();

        var response = await BASE_URL.AppendPathSegment("Artists")
                                   .WithOAuthBearerToken(AUTH_TOKEN)
                                   .PostJsonAsync(newArtist);
        RegenerateUrl();

        var deleteResponse = await BASE_URL.AppendPathSegments("Artists", newArtist.ArtistId)
                                   .WithOAuthBearerToken(AUTH_TOKEN)
                                   .DeleteAsync();

        deleteResponse.ResponseMessage.EnsureSuccessStatusCode();
    }

    private async Task<Artists> CreateUniqueArtists()
    {
        RegenerateUrl();
        var artists = await BASE_URL.AppendPathSegment("Artists")
                                    .WithOAuthBearerToken(AUTH_TOKEN)
                                    .GetJsonAsync<List<Artists>>();
        RegenerateUrl();

        var newArtists = new Artists
        {
            Name = Guid.NewGuid().ToString(),
            ArtistId = artists.OrderBy(x => x.ArtistId).Last().ArtistId + 1,
        };
        return newArtists;
    }
    
    //////////////////////////////////////////
   

    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbums()
    {
        var albums = await BASE_URL
              .AppendPathSegment("Albums")
              .WithOAuthBearerToken(AUTH_TOKEN)
              .GetJsonAsync<List<Albums>>();

        Assert.AreEqual(544, albums.Count);
    }

    private void RegenerateUrl()
    {
        BASE_URL.Reset();
    }
}

