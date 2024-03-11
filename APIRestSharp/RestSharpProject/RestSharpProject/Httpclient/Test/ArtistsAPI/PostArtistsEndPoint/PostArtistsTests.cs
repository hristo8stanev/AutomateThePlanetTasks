using Newtonsoft.Json;
using System.Text;
using RestSharpProject.Httpclient.BaseClass;

namespace RestSharpProject.Httpclient.Test.ArtistsAPI.PostArtistsEndPoint;
public class PostArtistsTests : BaseHttpClient
{

    [Test]
    public async Task ContentPopulated_When_NewArtistsInsertedViaPost()
    {
        var newArtist = await CreateUniqueArtists();
        var json = JsonConvert.SerializeObject(newArtist);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_endpoints.ArtistEndPoint, data);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var createdArtist = JsonConvert.DeserializeObject<Artists>(responseJsonResult);

        response.EnsureSuccessStatusCode();
        Assert.AreEqual(newArtist.Name, createdArtist.Name);

    }
}
