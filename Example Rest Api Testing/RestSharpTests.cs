using System.Threading.Tasks;
using Examples.Models;
using HttpTracer;
using HttpTracer.Logger;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators.OAuth2;
using RestSharp.Serializers;
using RestSharp.Serializers.NewtonsoftJson;
namespace Examples;

[TestFixture]
public class UtilitiesTests
{
    private const string BASE_URL = "http://localhost:60715/";
    private static RestClient _restClient;

    [OneTimeSetUp]
    public void ClassSetup()
    {
        var options = new RestClientOptions("http://localhost:60715/")
        {
            ThrowOnAnyError = true,
            MaxTimeout = 1000,
            FollowRedirects = true,
            MaxRedirects = 10,
            ConfigureMessageHandler = handler => new HttpTracerHandler(handler, new ConsoleLogger(), HttpMessageParts.All)
        };
        options.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(
       "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJiZWxsYXRyaXhVc2VyIiwianRpIjoiNjEyYjIzOTktNDUzMS00NmU0LTg5NjYtN2UxYmRhY2VmZTFlIiwibmJmIjoxNTE4NTI0NDg0LCJleHAiOjE1MjM3MDg0ODQsImlzcyI6ImF1dG9tYXRldGhlcGxhbmV0LmNvbSIsImF1ZCI6ImF1dG9tYXRldGhlcGxhbmV0LmNvbSJ9.Nq6OXqrK82KSmWNrpcokRIWYrXHanpinrqwbUlKT_cs",
       "Bearer");
        var settings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
        _restClient = new RestClient(options, configureSerialization: s => s.UseNewtonsoftJson(settings));

        // TODO: install separate NuGet package
        // Newtonsoft.Json.JsonSerializationException : Self referencing loop detected for property 'task' with type 'System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1+AsyncStateMachineBox`1[BookOneExamples.Chapter18.Artists,BookOneExamples.Chapter18.MediaStoreApiTests+<CreateUniqueArtists>d__13]'. Path 'stateMachine.<>t__builder'.
      
        _restClient.AddDefaultHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

        // https://restsharp.dev/authenticators.html#oauth2
   
    }

    [OneTimeTearDown]
    public void TestCleanup()
    {
        _restClient.Dispose();

        // or using  var _restClient = new RestClient();
    }

    [Test]
    [Ignore("Ignore until we implement head request for media store")]
    public async Task HeadRequestExample()
    {
        var request = new RestRequest("api/Albums", Method.Head);
        var response = await _restClient.ExecuteAsync(request);

        Assert.IsTrue(response.IsSuccessful);
    }

    [Test]
    [Ignore("Media store Api does not support get request with following parameters")]
    public async Task UpdateUserAgent()
    {
        var request = new RestRequest("api/Albums");
        request.AddQueryParameter("id", 12556);
        request.AddQueryParameter("shouldRegister", "True");
        request.AddQueryParameter("redirectUrl", "automatetheplanet");
        var response = await _restClient.GetAsync(request);

        // if send via form
        // POST requests are often sent via a post form. The type of the body of the request is indicated
        // by the Content-Type header. The FormUrlEncodedContent is a container for name/value tuples encoded
        // using application/x-www-form-urlencoded MIME type.

        var request1 = new RestRequest("api/Albums");
        request1.AddParameter("firstName", "Anton");
        request1.AddParameter("lastName", "Angelov");
        request1.AddParameter("company", "Automate The Planet");

        var response1 = await _restClient.PostAsync(request1);

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
        //  "url": "http://localhost:60715/"
        //}
    }

    [Test]
    public async Task DownloadImage()
    {
        var request = new RestRequest("https://www.automatetheplanet.com/wp-content/uploads/2020/03/atp_logo.svg", Method.Get);
        byte[] imageBytes = await _restClient.DownloadDataAsync(request);
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        string localFilename = "atp_logo.svg";
        string localPath = Path.Combine(documentsPath, localFilename);
        File.WriteAllBytes(localPath, imageBytes);
    }

    [Test]
    public async Task ContentPopulated_When_GetAlbums()
    {
        var request = new RestRequest("api/Albums", Method.Get);
        var response = await _restClient.ExecuteAsync(request);

        Assert.IsNotNull(response.Content);
    }

    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbums()
    {
        var request = new RestRequest("api/Albums", Method.Get);

        var response = await _restClient.ExecuteAsync<List<Albums>>(request);

        Assert.AreEqual(347, response.Data.Count);
    }

    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbumsById()
    {
        var request = new RestRequest("api/Albums/10", Method.Get);

        var response = await _restClient.ExecuteAsync<Albums>(request);

        Assert.AreEqual(10, response.Data.AlbumId);
    }

    [Test]
    public async Task ContentPopulated_When_GetGenericAlbumsById()
    {
        var request = new RestRequest("api/Albums/10", Method.Get);

        var response = await _restClient.ExecuteAsync<Albums>(request);

        Assert.IsNotNull(response.Content);
    }

    [Test]
    public async Task DataPopulatedAsGenres_When_PutModifiedContent()
    {
        var newGenres = await CreateUniqueGenres();

        var request = new RestRequest("api/Genres", Method.Post);
        request.AddJsonBody(newGenres);

        var insertedGenres = await _restClient.ExecuteAsync<Genres>(request);

        var putRequest = new RestRequest($"api/Genres/{insertedGenres.Data.GenreId}", Method.Put);
        string updatedName = Guid.NewGuid().ToString();
        insertedGenres.Data.Name = updatedName;
        putRequest.AddJsonBody(insertedGenres.Data);

        await _restClient.ExecuteAsync<Genres>(putRequest);

        request = new RestRequest($"api/Genres/{insertedGenres.Data.GenreId}", Method.Get);

        var getUpdatedResponse = await _restClient.ExecuteAsync<Genres>(request);

        Assert.IsNotNull(getUpdatedResponse.Content);
    }

    [Test]
    public async Task ContentPopulated_When_PutModifiedContent()
    {
        var newGenres = await CreateUniqueGenres();

        var request = new RestRequest("api/Genres", Method.Post);
        request.AddJsonBody(newGenres);

        var insertedGenres = await _restClient.ExecuteAsync<Genres>(request);

        var putRequest = new RestRequest($"api/Genres/{insertedGenres.Data.GenreId}", Method.Put);
        string updatedName = Guid.NewGuid().ToString();
        insertedGenres.Data.Name = updatedName;
        putRequest.AddJsonBody(insertedGenres.Data);

        await _restClient.ExecuteAsync(putRequest);

        request = new RestRequest($"api/Genres/{insertedGenres.Data.GenreId}", Method.Get);

        var getUpdatedResponse = await _restClient.ExecuteAsync<Genres>(request);

        Assert.IsNotNull(getUpdatedResponse.Content);
    }

    [Test]
    public async Task ContentPopulated_When_NewAlbumInsertedViaPost()
    {
        var newAlbum = await CreateUniqueGenres();

        var request = new RestRequest("api/Genres");
        request.AddJsonBody(newAlbum);

        var response = await _restClient.PostAsync(request);

        Assert.IsTrue(response.IsSuccessful);
    }

    [Test]
    public async Task DataPopulatedAsGenres_When_NewAlbumInsertedViaPost()
    {
        var newAlbum = await CreateUniqueGenres();

        var request = new RestRequest("api/Genres", Method.Post);
        request.AddJsonBody(newAlbum);

        var response = await _restClient.ExecuteAsync<Genres>(request);

        Assert.AreEqual(newAlbum.Name, response.Data.Name);
    }

    [Test]
    public async Task ArtistsDeleted_When_PerformDeleteRequest()
    {
        var newArtist = await CreateUniqueArtists();
        var request = new RestRequest("api/Artists", Method.Post);
        request.AddJsonBody(newArtist);
        await _restClient.ExecuteAsync<Artists>(request);

        var deleteRequest = new RestRequest($"api/Artists/{newArtist.ArtistId}", Method.Delete);
        var response = await _restClient.ExecuteAsync(deleteRequest);

        Assert.IsTrue(response.IsSuccessful);
    }

    [Test]
    public async Task ArtistsDeleted_When_PerformGenericDeleteRequest()
    {
        var newArtist = await CreateUniqueArtists();
        var request = new RestRequest("api/Artists", Method.Post);
        request.AddJsonBody(newArtist);
        await _restClient.ExecuteAsync<Artists>(request);

        var deleteRequest = new RestRequest($"api/Artists/{newArtist.ArtistId}", Method.Delete);
        var response = await _restClient.ExecuteAsync<Artists>(deleteRequest);

        Assert.IsTrue(response.IsSuccessful);
    }

    private async Task<Artists> CreateUniqueArtists()
    {
        var artists = await _restClient.GetAsync<List<Artists>>(new RestRequest("api/Artists"));
        var newArtists = new Artists
        {
            Name = Guid.NewGuid().ToString(),
            ArtistId = artists.OrderBy(x => x.ArtistId).Last().ArtistId + 1,
        };
        return newArtists;
    }

    private async Task<Genres> CreateUniqueGenres()
    {
        var genres = await _restClient.GetAsync<List<Genres>>(new RestRequest("api/Genres"));
        var newGenres = new Genres
        {
            Name = Guid.NewGuid().ToString(),
            GenreId = genres.OrderBy(x => x.GenreId).Last().GenreId + 1,
        };
        return newGenres;
    }
}