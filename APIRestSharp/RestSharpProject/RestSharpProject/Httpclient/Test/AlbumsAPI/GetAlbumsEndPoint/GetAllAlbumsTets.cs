using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharpProject.Httpclient.BaseClass;
using RestSharpProject.Models;

namespace RestSharpProject.Httpclient.Test.AlbumsAPI.GetAlbumsEndPoint;
public class GetAllAlbumsTets : BaseHttpClient
{
    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbums()
    {
        var response = await _httpClient.GetAsync(_endpoints.AlbumsEndPoint);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var albums = JsonConvert.DeserializeObject<List<Album>>(responseJsonResult);

        Assert.AreEqual(570, albums.Count);
    }

    [Test]
    public async Task DataPopulatedAsList_When_GetGenericAlbumsById()
    {
        var response = await _httpClient.GetAsync($"{_endpoints.AlbumsEndPoint}/10");
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Album>(responseJsonResult);

        Assert.AreEqual(10, result.AlbumId);
    }
}
