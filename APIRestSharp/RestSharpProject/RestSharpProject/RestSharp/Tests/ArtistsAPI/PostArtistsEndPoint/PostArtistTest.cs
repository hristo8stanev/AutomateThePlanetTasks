using System.Text;
using System.Xml.Schema;
using System.Xml;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharpProject.AssertiExtensions;
using System.Xml.Serialization;

namespace RestSharpProject.RestSharp.Tests.ArtistsAPI.PostArtistsEndPoint;

    public class PostArtistTest : BaseRestSharp
    {

    [Test]
    public async Task DataPopulatedAsArtists_When_NewArtistNameInsertedViaPost()
    {
        var newArtist = await CreateUniqueArtists();

        var request = new RestRequest(_endpoints.ArtistEndPoint, Method.Post);
        request.AddJsonBody(newArtist);

        var response = await _restClient.ExecuteAsync<Artists>(request);

        response.AssertSuccessStatusCode();
        Assert.AreEqual(newArtist.Name, response.Data.Name);

        //assert JSON schema
        response.AssertSchema(_jsonSchemas.ArtistsSchema);
    }
}

   