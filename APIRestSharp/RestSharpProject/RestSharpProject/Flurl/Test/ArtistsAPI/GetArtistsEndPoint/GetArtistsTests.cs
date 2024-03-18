using Flurl.Http;
using RestSharpProject.Flurl.BaseClass;

namespace RestSharpProject.Flurl.Test.ArtistsAPI.GetArtistsEndPoint;
public class GetArtistsTests : BaseFlurlAPI
{

    [Test]
    public async Task ContentPopulated_When_GetAllArtists()
    {
        var response = await BASE_URL
           .AppendPathSegment(_flurlEndPoints.ArtistsEndPoint)
           .WithOAuthBearerToken(AUTH_TOKEN)
           .GetAsync();

        response.ResponseMessage.EnsureSuccessStatusCode();

    }

    [Test]
    public async Task ContentPopulated_When_GetArtistById()
    {
        var newArtist = await CreateUniqueArtists();

        var response = await BASE_URL
            .AppendPathSegment(_flurlEndPoints.ArtistsEndPoint)
            .WithOAuthBearerToken(AUTH_TOKEN)
            .PostJsonAsync(newArtist);



        var responseJsonResult = await BASE_URL.AppendPathSegments(newArtist.ArtistId)
                                  .WithOAuthBearerToken(AUTH_TOKEN)
                                  .GetStringAsync();

        response.ResponseMessage.EnsureSuccessStatusCode();

    }
}

