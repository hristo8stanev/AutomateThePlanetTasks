using Flurl.Http;
using RestSharpProject.Flurl.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        var response = await BASE_URL
           .AppendPathSegment(_flurlEndPoints.ArtistsEndPoint)
           .AppendPathSegment(10)
           .WithOAuthBearerToken(AUTH_TOKEN)
           .GetAsync();

        response.ResponseMessage.EnsureSuccessStatusCode();

    }
}

