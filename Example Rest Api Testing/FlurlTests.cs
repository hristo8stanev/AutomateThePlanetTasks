using System.Net.Http;
using System.Threading.Tasks;
using Examples.Models;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;


namespace Examples.Models;

[TestFixture]
public class FlurlTests
{
    private  string URL => "https://localhost:60714/api/";
    private Url BASE_URL = new Url(URL);
    private const string AUTH_TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJiZWxsYXRyaXhVc2VyIiwianRpIjoiNjEyYjIzOTktNDUzMS00NmU0LTg5NjYtN2UxYmRhY2VmZTFlIiwibmJmIjoxNTE4NTI0NDg0LCJleHAiOjE1MjM3MDg0ODQsImlzcyI6ImF1dG9tYXRldGhlcGxhbmV0LmNvbSIsImF1ZCI6ImF1dG9tYXRldGhlcGxhbmV0LmNvbSJ9.Nq6OXqrK82KSmWNrpcokRIWYrXHanpinrqwbUlKT_cs";

    [OneTimeSetUp]
    public void ClassInitialize()
    {
        FlurlHttp.GlobalSettings.Timeout = TimeSpan.FromSeconds(30);
    }

    // Ivaylo add teardown to reset url
    [TearDown]
    public void TearDown()
    {
        RegenerateUrl();
    }

    // Ivaylo add ignore attribute to prevent execution
    [Test]
    [Ignore("Ignore until we implement head request for media store")]
    public async Task HeadRequestExample()
    {
        //var response = await  "https://localhost:60714/api/Albums".HeadAsync();
        var response = await BASE_URL
            .AppendPathSegment("Albums")
            .WithOAuthBearerToken(AUTH_TOKEN)
            .HeadAsync();
        response.ResponseMessage.EnsureSuccessStatusCode();

        Assert.IsNotNull(response.ResponseMessage.Content);
    }

    // Ivaylo add ignore attribute to prevent execution
    [Test]
    [Ignore("Media store Api does not support get request with following parameters")]
    public async Task UpdateUserAgent()
    {
        var response = await BASE_URL
            .AppendPathSegment("Albums")
            .WithHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36")
            .WithOAuthBearerToken(AUTH_TOKEN)
            .GetAsync();
        response.ResponseMessage.EnsureSuccessStatusCode();

        RegenerateUrl();
        // add query parameters

        // Ivalo GET albums does not support following query parameters
        response = await BASE_URL
            .AppendPathSegment("Albums")
            .SetQueryParam("id", "12556")
            .SetQueryParam("shouldRegister", "True")
            .SetQueryParam("redirectUrl", "automatetheplanet")
            .WithOAuthBearerToken(AUTH_TOKEN)
            .GetAsync();
        response.ResponseMessage.EnsureSuccessStatusCode();

        RegenerateUrl();

        // if send via form
        // POST requests are often sent via a post form. The type of the body of the request is indicated
        // by the Content-Type header. The FormUrlEncodedContent is a container for name/value tuples encoded
        // using application/x-www-form-urlencoded MIME type.

        response = await BASE_URL
            .AppendPathSegment("Albums")
            .WithOAuthBearerToken(AUTH_TOKEN)
            .PostMultipartAsync(mp => mp
                .AddUrlEncoded("id", "12556")
                .AddUrlEncoded("shouldRegister", "True")
                .AddUrlEncoded("redirectUrl", "automatetheplanet"));

        //{
        //  "args": {},
        //  "data": "",
        //  "files": {},
        //  "form": {
        //    "firstName": "Anton",
        //    "lastName": "Angelov"
        //    "company": "AutomateThePlanet"
        //  },
        //  "headers": {
        //    "Content-Length": "33",
        //    "Content-Type": "application/x-www-form-urlencoded",
        //    "Host": "localhost",
        //  },
        //  "json": null,
        //  ...
        //  "url": "http://localhost:60714/"
        //}
    }

    [Test]
    public async Task DownloadImage()
    {
        var url = "https://www.automatetheplanet.com/wp-content/uploads/2020/03/atp_logo.svg";
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        string downloadedFilePath = await url.DownloadFileAsync(documentsPath, "atp_logo.svg");
        string localFilename = "atp_logo.svg";
        string expectedDownloadedFilePath = Path.Combine(documentsPath, localFilename);

        Assert.AreEqual(expectedDownloadedFilePath, downloadedFilePath);
    }

    [Test]
    public async Task ContentPopulated_When_GetAlbums()
    {
        var response = await BASE_URL
            .AppendPathSegment("Albums")
            .WithOAuthBearerToken(AUTH_TOKEN)
            .GetAsync();

        response.ResponseMessage.EnsureSuccessStatusCode();
    }

    [Test]
    public async Task ContentPopulated_When_SendAsync()
    {
        var response = await BASE_URL
             .AppendPathSegment("Albums")
             .WithOAuthBearerToken(AUTH_TOKEN)
             .SendAsync(HttpMethod.Get);

        response.ResponseMessage.EnsureSuccessStatusCode();
    }

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

    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbums()
    {
        var albums = await BASE_URL
              .AppendPathSegment("Albums")
              .WithOAuthBearerToken(AUTH_TOKEN)
              .GetJsonAsync<List<Albums>>();

        Assert.AreEqual(347, albums.Count);
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

    [Test]
    public async Task ContentPopulated_When_NewAlbumInsertedViaPost()
    {
        var newGenre = await CreateUniqueGenres();

        var response = await BASE_URL.AppendPathSegment("Genres")
                                  .WithOAuthBearerToken(AUTH_TOKEN)
                                  .PostJsonAsync(newGenre);
        var responseText = await response.GetStringAsync();

        Assert.IsNotNull(responseText);
    }

    [Test]
    public async Task DataPopulatedAsGenres_When_NewAlbumInsertedViaPost()
    {
        var newGenre = await CreateUniqueGenres();

        var response = await BASE_URL.AppendPathSegment("Genres")
                                  .WithOAuthBearerToken(AUTH_TOKEN)
                                  .PostJsonAsync(newGenre);

        var createdGenre = await response.GetJsonAsync<Genres>();

        Assert.AreEqual(newGenre.Name, createdGenre.Name);
    }

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

    private void RegenerateUrl()
    {
        BASE_URL.Reset();
    }
}