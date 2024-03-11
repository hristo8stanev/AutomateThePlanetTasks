using Flurl;
using Flurl.Http;

namespace RestSharpProject.Flurl.BaseClass;
public class BaseFlurlAPI
{
    protected EndPointsFlurl _flurlEndPoints;
    protected const string URL = "https://localhost:60714/api/";
    protected Url BASE_URL = new Url(URL);
    protected string AUTH_TOKEN => "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJiZWxsYXRyaXhVc2VyIiwianRpIjoiNjEyYjIzOTktNDUzMS00NmU0LTg5NjYtN2UxYmRhY2VmZTFlIiwibmJmIjoxNTE4NTI0NDg0LCJleHAiOjE1MjM3MDg0ODQsImlzcyI6ImF1dG9tYXRldGhlcGxhbmV0LmNvbSIsImF1ZCI6ImF1dG9tYXRldGhlcGxhbmV0LmNvbSJ9.Nq6OXqrK82KSmWNrpcokRIWYrXHanpinrqwbUlKT_cs";
    

    [OneTimeSetUp]
    public void ClassInitialize()
    {
        _flurlEndPoints = new EndPointsFlurl();
        var client = new FlurlClient(BASE_URL);
        client.Settings.Timeout = TimeSpan.FromSeconds(600);
        client.Settings.Redirects.Enabled = false;

    }

    [TearDown]
    public void TearDown()
    {
        RegenerateUrl();
    }

    
    protected async Task<Genres> CreateUniqueGenres()
    {
        RegenerateUrl();
        var allGenres = await BASE_URL.AppendPathSegment(_flurlEndPoints.GenresEndPoint)
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

   

    protected async Task<Artists> CreateUniqueArtists()
    {
        RegenerateUrl();
        var artists = await BASE_URL.AppendPathSegment(_flurlEndPoints.ArtistsEndPoint)
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

    protected async Task<Album> CreateUniqueAlbum()
    {
        RegenerateUrl();
        var albums = await BASE_URL.AppendPathSegment(_flurlEndPoints.AlbumsEndPoint)
                                    .WithOAuthBearerToken(AUTH_TOKEN)
                                    .GetJsonAsync<List<Album>>();
        RegenerateUrl();

        var newAlbums = new Album
        {
            Title = Guid.NewGuid().ToString(),
            AlbumId = albums.OrderBy(x => x.AlbumId).Last().AlbumId + 1,
        };
        return newAlbums;

    }

    protected async Task<Tracks> CreateUniqueTracks()
    {
        RegenerateUrl();
        var tracks = await BASE_URL.AppendPathSegment(_flurlEndPoints.TracksEndPoint)
                                    .WithOAuthBearerToken(AUTH_TOKEN)
                                    .GetJsonAsync<List<Tracks>>();
        RegenerateUrl();

        var newTrack = new Tracks()
        {
            TrackId = tracks.OrderBy(x => x.TrackId).Last().TrackId + 1,
            Name = Guid.NewGuid() + "TrackName".ToString(),
            MediaTypeId = 1,
            Composer = Guid.NewGuid() + "ComposerName".ToString(),
            UnitPrice = Guid.NewGuid() + "88".ToString(),

        };
        return newTrack;
    }


        protected void RegenerateUrl()
    {
        BASE_URL.Reset();
    }
}

