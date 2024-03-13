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
    }

    [Test]
    public async Task TestValidArtistJsonSchema()
    {
        var jsonData = @"{""artistId"":0,""name"":null,""albums"":[]}";

        var request = new RestRequest(_endpoints.ArtistEndPoint, Method.Post);
        request.AddJsonBody(jsonData);

        string jsonSchema = File.ReadAllText(@"C:\Users\UsernameT\Documents\GitHub\AutomateThePlanetTasks\APIRestSharp\RestSharpProject\RestSharpProject\RestSharp\RequestArtistBodySchema.txt");
        JSchema jSchema = JSchema.Parse(jsonSchema);

        JToken jToken = JToken.Parse(jsonData);

        AssertJsonSchema(jSchema,jToken);

       
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