using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace RestSharpProject.RestSharp.Tests.AlbumsAPI.PostAlbumEndPoint;

public class PostAlbumTest : BaseRestSharp
{


    [Test]
    public async Task DataPopulatedAsGenres_When_NewAlbumInsertedViaPost()
    {
        var newAlbum = await CreateUniqueAlbum();

        var request = new RestRequest(_endpoints.AlbumsEndPoint, Method.Post);
        request.AddJsonBody(newAlbum);

        var response = await _restClient.ExecuteAsync<Album>(request);

        response.AssertSuccessStatusCode();
        Assert.AreEqual(response.Data.Title, newAlbum.Title);
    }

    [Test]
    public async Task TestValidAlbumJsonSchema()
    {
        var jsonData = @"{""albumId"":0,""title"":""6a1b2a49-3070-4ab6-a402-6b1a39d0f1eb"",""artistId"":0,""artist"":null,""tracks"":[]}";

        var request = new RestRequest(_endpoints.AlbumsEndPoint, Method.Post);
        request.AddJsonBody(jsonData);

        string jsonSchema = File.ReadAllText(@"C:\Users\UsernameT\Documents\GitHub\AutomateThePlanetTasks\APIRestSharp\RestSharpProject\RestSharpProject\RestSharp\RequestAlbumBodySchema.txt");
        JSchema jSchema = JSchema.Parse(jsonSchema);

        JToken jToken = JToken.Parse(jsonData);

        AssertJsonSchema(jSchema, jToken);


    }

    public static void AssertJsonSchema(JSchema jSchema, JToken jToken)
    {
        bool valid = jToken.IsValid(jSchema);

        Console.WriteLine(valid);

        jToken.IsValid(jSchema, out IList<ValidationError> errors);

        foreach (ValidationError err in errors)
        {
            Console.WriteLine(err.Message);
        }
    }
}