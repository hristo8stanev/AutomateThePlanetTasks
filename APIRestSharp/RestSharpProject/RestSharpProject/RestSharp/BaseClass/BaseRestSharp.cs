using Newtonsoft.Json;
using RestSharp.Authenticators.OAuth2;
using HttpTracer;
using HttpTracer.Logger;
using RestSharpProject.RestSharp.EndPoints;
using System.Xml.Schema;

namespace RestSharpProject.RestSharp.BaseClass;
public class BaseRestSharp
{
    protected Endpoints _endpoints;
    public XmlSchemaSet _xmlSchemaSet;
    public JsonSchemas _jsonSchemas;
    protected string BASE_URL => "http://localhost:60715/";
    protected static RestClient _restClient;


    [OneTimeSetUp]
    public void ClassSetup()
    {
        _jsonSchemas = new JsonSchemas();
        _endpoints = new Endpoints();

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
        var artists = await _restClient.GetAsync<List<Artists>>(new RestRequest(_endpoints.ArtistEndPoint));
        var newArtists = new Artists
        {
            Name = Guid.NewGuid().ToString(),
            ArtistId = artists.OrderBy(x => x.ArtistId).Last().ArtistId + 1,
        };
        return newArtists;
    }

    protected async Task<Genres> CreateUniqueGenres()
    {
        var genres = await _restClient.GetAsync<List<Genres>>(new RestRequest(_endpoints.GenresEndPoint));
        var newGenres = new Genres
        {
            Name = Guid.NewGuid().ToString(),
            GenreId = genres.OrderBy(x => x.GenreId).Last().GenreId + 1,
        };
        return newGenres;
    }

    protected async Task<Album> CreateUniqueAlbum()
    {
        var albums = await _restClient.GetAsync<List<Album>>(new RestRequest(_endpoints.AlbumsEndPoint));

        var newAlbum = new Album
        {
            AlbumId = albums.OrderBy(x => x.AlbumId).Last().AlbumId + 1,
            Title = Guid.NewGuid() + "TitleName".ToString(),

        };

        return newAlbum;
    }

    protected async Task<Tracks> CreateUniqueTrack()
    {
        var tracks = await _restClient.GetAsync<List<Tracks>>(new RestRequest(_endpoints.TrackEndPoint));
        var newTrack = new Tracks
        {
            TrackId = tracks.OrderBy(x => x.TrackId).Last().TrackId + 1,
            Name = Guid.NewGuid() + "TrackName".ToString(),
            MediaTypeId = 1,
            Composer = Guid.NewGuid() + "ComposerName".ToString(),
            UnitPrice = Guid.NewGuid() + "88".ToString(),

        };

        return newTrack;
    }
}