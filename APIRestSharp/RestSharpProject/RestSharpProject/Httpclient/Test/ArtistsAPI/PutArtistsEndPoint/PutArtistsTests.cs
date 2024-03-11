using Newtonsoft.Json;
using RestSharpProject.Httpclient.BaseClass;
using System.Text;

namespace RestSharpProject.Httpclient.Test.ArtistsAPI.PutAlbumsEndPoint;
public class PutArtistsTests : BaseHttpClient
    {

        [Test]
        public async Task ContentPopulated_When_PutModifiedContent()
        {
        var newArtist = await CreateUniqueArtists();
        var json = JsonConvert.SerializeObject(newArtist);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_endpoints.ArtistEndPoint, data);
        var responseJsonResult = await response.Content.ReadAsStringAsync();
        var insertedArtist = JsonConvert.DeserializeObject<Artists>(responseJsonResult);

        var updatedName = Guid.NewGuid().ToString();
        insertedArtist.Name = updatedName;
        json = JsonConvert.SerializeObject(insertedArtist);
        data = new StringContent(json, Encoding.UTF8, "application/json");

        await _httpClient.PutAsync($"{_endpoints.ArtistEndPoint}/{insertedArtist.ArtistId}", data);

        var getResponse = await _httpClient.GetAsync($"{_endpoints.ArtistEndPoint}/{insertedArtist.ArtistId}");
        var getResponseJsonResult = await getResponse.Content.ReadAsStringAsync();
        var actualUpdatedGenres = JsonConvert.DeserializeObject<Genres>(getResponseJsonResult);

        response.EnsureSuccessStatusCode();
        Assert.AreEqual(updatedName, actualUpdatedGenres.Name);

    }
}