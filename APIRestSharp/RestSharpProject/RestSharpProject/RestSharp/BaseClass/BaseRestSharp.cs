using Newtonsoft.Json;
using RestSharp.Authenticators.OAuth2;
using RestSharp;
using HttpTracer;
using HttpTracer.Logger;

namespace RestSharpProject.RestSharp.BaseClass;
public class BaseRestSharp
{
    protected string BASE_URL => "http://localhost:60715/";
    protected static RestClient _restClient;

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

    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbums()
    {
        var request = new RestRequest("api/Albums");
        var response = await _restClient.ExecuteAsync<List<Album>>(request);

        Assert.AreEqual(544, response.Data.Count);
    }

    //POST METHODS
    protected async Task<Artists> CreateUniqueArtists()
    {
        var artists = await _restClient.GetAsync<List<Artists>>(new RestRequest("api/Artists"));
        var newArtists = new Artists
        {
            Name = Guid.NewGuid().ToString(),
            ArtistId = artists.OrderBy(x => x.ArtistId).Last().ArtistId + 1,
        };
        return newArtists;
    }
    protected async Task<Genres> CreateUniqueGenres()
    {
        var genres = await _restClient.GetAsync<List<Genres>>(new RestRequest("api/Genres"));
        var newGenres = new Genres
        {
            Name = Guid.NewGuid().ToString(),
            GenreId = genres.OrderBy(x => x.GenreId).Last().GenreId + 1,
        };
        return newGenres;
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
}