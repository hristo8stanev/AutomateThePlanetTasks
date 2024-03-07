using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharpProject.Models;
using RestSharp;
using RestSharpProject.AssertiExtensions;
using System.Net;
using RestSharpProject.RestSharp.BaseClass;

namespace RestSharpProject.RestSharp.Tests.AlbumsAPI.GetAlbumsEndPoint;
public class RestSharpGetAllTests : BaseRestSharp
{
    private string AlbumsEndPoint => "api/Albums";

    [Test]
    public async Task ContentPopulated_When_GetAlbums()
    {
        var request = new RestRequest(AlbumsEndPoint, Method.Get);
        var response = await _restClient.ExecuteAsync(request);

        response.AssertStatusCode(HttpStatusCode.OK);
        Assert.IsNotNull(response.Content);

    }


    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbumsById()
    {
        var request = new RestRequest($"{AlbumsEndPoint}/10");
        var response = await _restClient.ExecuteAsync<Album>(request);

        response.AssertStatusCode(HttpStatusCode.OK);
        Assert.AreEqual(10, response.Data.AlbumId);
        Assert.AreEqual("Belle", response.Data.Title);

    }

    
}
