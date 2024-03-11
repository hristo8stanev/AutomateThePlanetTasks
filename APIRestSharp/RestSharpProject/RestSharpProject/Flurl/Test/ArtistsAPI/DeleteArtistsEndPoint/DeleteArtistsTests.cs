using Flurl.Http;
using RestSharpProject.Flurl.BaseClass;

namespace RestSharpProject.Flurl.Test.ArtistsAPI.DeleteArtistsEndPoint;
public class DeleteArtistsTests : BaseFlurlAPI
{

    [Test]
    public async Task ArtistsDeleted_When_PerformGenericDeleteRequest()
    {
        var newArtist = await CreateUniqueArtists();

        var response = await BASE_URL.AppendPathSegment(_flurlEndPoints.ArtistsEndPoint)
                                   .WithOAuthBearerToken(AUTH_TOKEN)
                                   .PostJsonAsync(newArtist);
        RegenerateUrl();

        var deleteResponse = await BASE_URL.AppendPathSegments("Artists", newArtist.ArtistId)
                                   .WithOAuthBearerToken(AUTH_TOKEN)
                                   .DeleteAsync();

        deleteResponse.ResponseMessage.EnsureSuccessStatusCode();
    }
}

