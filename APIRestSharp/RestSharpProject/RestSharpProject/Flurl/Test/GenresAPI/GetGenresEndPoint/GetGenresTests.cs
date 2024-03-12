using Flurl.Http;
using RestSharpProject.Flurl.BaseClass;
using System.Net;

namespace RestSharpProject.Flurl.Test.GenresAPI.GetGenresEndPoint;
    public class GetGenresTests : BaseFlurlAPI
{

    [Test]
    public async Task ContentPopulated_When_GetAllGenres()
    {
       

        var response = await BASE_URL
            .AppendPathSegment(_flurlEndPoints.GenresEndPoint)
            .WithOAuthBearerToken(AUTH_TOKEN)
            .GetAsync();

        response.ResponseMessage.EnsureSuccessStatusCode();
        Assert.NotNull(response.ResponseMessage);
    }

    [Test]
    public async Task ContentPopulated_When_GetGenresById()
    {

        var newGenre = await CreateUniqueGenres();

        var response = await BASE_URL
            .AppendPathSegment(_flurlEndPoints.GenresEndPoint)
            .WithOAuthBearerToken(AUTH_TOKEN)
            .PostJsonAsync(newGenre);

        var responseJsonResult = await BASE_URL.AppendPathSegments(newGenre.GenreId)
                                  .WithOAuthBearerToken(AUTH_TOKEN)
                                  .GetStringAsync();

   
        response.ResponseMessage.EnsureSuccessStatusCode();
        Assert.NotNull(response.ResponseMessage);
    }
}

