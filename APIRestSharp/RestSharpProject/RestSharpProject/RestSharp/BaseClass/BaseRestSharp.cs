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
}