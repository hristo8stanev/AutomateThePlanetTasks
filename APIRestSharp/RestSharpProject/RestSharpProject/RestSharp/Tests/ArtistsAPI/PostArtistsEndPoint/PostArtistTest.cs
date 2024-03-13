using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharpProject.AssertiExtensions;

namespace RestSharpProject.RestSharp.Tests.ArtistsAPI.PostArtistsEndPoint
{
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
        }

        //  [Test]
        //  public void TestValidArtistJsonSchema()
        //  {
        //      // Arrange
        //      var jsonData = @"{""artistId"":0,""name"":null,""albums"":[]}";
        //
        //      string jsonSchema = File.ReadAllText(@"C:\Users\xstan\IdeaProjects\AutomateThePlanetTasks\APIRestSharp\RestSharpProject\RestSharpProject\RestSharp\RequestArtistBodySchema.txt");
        //      JSchema jSchema = JSchema.Parse(jsonSchema);
        //
        //      // Act
        //      JToken jToken = JToken.Parse(jsonData);
        //      bool valid = jToken.IsValid(jSchema);
        //
        //      // Assert
        //      Assert.IsTrue(valid, "JSON data should conform to the JSON schema.");
        //  }
        //

        // [Test]
        // public async Task TestArtistJsonSchema()
        // {
        //     
        //     var jsonData = @"{""artistId"":0,""name"":null,""albums"":[]}";
        //
        //     
        //     var request = new RestRequest(_endpoints.ArtistEndPoint, Method.Post);
        //     request.AddJsonBody(jsonData);
        //
        //     
        //     var response = await _restClient.ExecuteAsync(request);
        //
        //    
        //     string jsonSchema = File.ReadAllText(@"C:\Users\xstan\IdeaProjects\AutomateThePlanetTasks\APIRestSharp\RestSharpProject\RestSharpProject\RestSharp\RequestArtistBodySchema.txt");
        //
        //    
        //     JSchema jSchema = JSchema.Parse(File.ReadAllText(@"C:\Users\xstan\IdeaProjects\AutomateThePlanetTasks\APIRestSharp\RestSharpProject\RestSharpProject\RestSharp\RequestArtistBodySchema.txt"));
        //
        //
        //     
        //     string schemaAsString = jSchema.ToString();
        //
        //     
        //     response.AssertSchema(jsonSchema);
        // }
    }
}