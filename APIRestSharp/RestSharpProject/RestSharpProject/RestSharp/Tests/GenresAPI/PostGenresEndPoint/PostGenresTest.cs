using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharpProject.AssertiExtensions;
using RestSharpProject.RestSharp.BaseClass;
using RestSharpProject.AssertiExtensions;

namespace RestSharpProject.RestSharp.Tests.GenresAPI.PostGenresEndPoint;
public class PostGenresTest : BaseRestSharp
{

    [Test]
    public async Task DataPopulatedAsGenres_When_NewAlbumInsertedViaPost()
    {
        var newAlbum = await CreateUniqueGenres();

        var request = new RestRequest("api/Genres", Method.Post);
        request.AddJsonBody(newAlbum);

        var response = await _restClient.ExecuteAsync<Genres>(request);


        response.AssertSuccessStatusCode();
        Assert.AreEqual(newAlbum.Name, response.Data.Name);
    }
}
