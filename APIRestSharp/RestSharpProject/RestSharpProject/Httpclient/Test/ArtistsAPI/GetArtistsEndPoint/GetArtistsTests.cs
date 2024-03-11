using System.Text;
using Newtonsoft.Json;
using RestSharpProject.Httpclient.BaseClass;

namespace RestSharpProject.Httpclient.Test.ArtistsAPI.GetArtistsEndPoint;
public class GetArtistsTests : BaseHttpClient
{

    [Test]
    public async Task DataPopulatedAsList_When_GetAllArtist()
    {
        var response = await _httpClient.GetAsync(_endpoints.ArtistEndPoint);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var albums = JsonConvert.DeserializeObject<List<Artists>>(responseJsonResult);

        Assert.IsNotNull(albums);
        response.EnsureSuccessStatusCode();
    }

    [Test]
    public async Task ContentPopulated_When_GetGenericArtistsById()
    {
        var newArtist = await CreateUniqueArtists();
        var json = JsonConvert.SerializeObject(newArtist);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var insertedArtist = await _httpClient.PostAsync(_endpoints.ArtistEndPoint, data);

        var response = await _httpClient.GetAsync($"{_endpoints.ArtistEndPoint}/{newArtist.ArtistId}");
        var respnseJsonResult = await response.Content.ReadAsStringAsync();
        var albums = JsonConvert.DeserializeObject<Artists>(respnseJsonResult);

        response.EnsureSuccessStatusCode();
        Assert.AreEqual(newArtist.ArtistId, albums.ArtistId);
        Assert.AreEqual(newArtist.Name, albums.Name);

    }
}
