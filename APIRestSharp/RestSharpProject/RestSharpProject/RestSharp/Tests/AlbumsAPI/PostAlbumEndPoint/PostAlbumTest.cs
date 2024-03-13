using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using static RestSharpProject.RestSharp.Tests.AlbumsAPI.PostAlbumEndPoint.PostAlbumTest;

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
        string schemaJson = File.ReadAllText(@"C:\Users\xstan\IdeaProjects\AutomateThePlanetTasks\APIRestSharp\RestSharpProject\RestSharpProject\RestSharp\RequestAlbumBodySchema.txt");

        response.AssertSuccessStatusCode();
        Assert.AreEqual(response.Data.Title, newAlbum.Title);
        response.AssertSchema(schemaJson);
    }


    //SECOND WAY
    public static class JsonSchemas
    {
        public static string AlbumSchema { get; } = @"
        {
            ""$schema"": ""http://json-schema.org/draft-04/schema#"",
            ""type"": ""object"",
            ""properties"": {
                ""albumId"": { ""type"": ""integer"" },
                ""title"": { ""type"": ""string"" },
                ""artistId"": { ""type"": ""integer"" },
                ""artist"": { ""type"": ""null"" },
                ""tracks"": { ""type"": ""array"", ""items"": {} }
            },
            ""required"": [ ""albumId"", ""title"", ""artistId"", ""artist"", ""tracks"" ]
        }
    ";
    }
}