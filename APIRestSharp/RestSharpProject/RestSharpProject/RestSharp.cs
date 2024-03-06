using Newtonsoft.Json;
using RestSharp.Authenticators.OAuth2;
using RestSharp;
using HttpTracer;
using HttpTracer.Logger;
using Examples.Models;
using HttpTracer.Logger;
using Newtonsoft.Json;
using Examples;



namespace RestSharpProject;
public class RestSharp
{
    private string BASE_URL => "http://localhost:60715/";
    private static RestClient _restClient;

    [OneTimeSetUp]
    public void ClassSetup()
    {
        var options = new RestClientOptions(BASE_URL)
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
        _restClient = new RestClient(options);
    }

    [OneTimeTearDown]
    public void TestCleanup()
    {
        _restClient.Dispose();

    }

    //GET METHODS
  
    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbumsById()
    {
        var request = new RestRequest("api/Albums/10");
        var response = await _restClient.ExecuteAsync<Albums>(request);
        
        Assert.AreEqual(10, response.Data.AlbumId);
    }

    [Test]
    public async Task AssertContentContainsAudioSlave()
    {
        var request = new RestRequest("api/Albums/10",Method.Get);
        var response = await _restClient.ExecuteAsync<Albums>(request);

        response.AssertContentContains("Audioslave");
    }
    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbums()
    {
        var request = new RestRequest("api/Albums");
        var response = await _restClient.ExecuteAsync<List<Albums>>(request);

        Assert.AreEqual(544, response.Data.Count);
    }

    [Test]
    public async Task ContentPopulated_When_GetAlbums()
    {
        var request = new RestRequest("api/Albums", Method.Get);
        var response = await _restClient.ExecuteAsync(request);

        Assert.IsNotNull(response.Content);
    }

    //POST METHODS
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


    [Test]
    public async Task DataPopulatedAsGenres_When_NewAlbumInsertedViaPost()
    {
        var newAlbum = await CreateUniqueGenres();

        var request = new RestRequest("api/Genres", Method.Post);
        request.AddJsonBody(newAlbum);

        var response = await _restClient.ExecuteAsync<Genres>(request);

        Assert.AreEqual(newAlbum.Name, response.Data.Name);
    }

    //PUT REQUEST
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

    //DELETE REQUEST
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
}
