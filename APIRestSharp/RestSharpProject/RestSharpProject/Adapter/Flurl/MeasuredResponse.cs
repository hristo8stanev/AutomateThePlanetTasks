using System.Net.Http;

namespace Examples.Adapter.Flurl;
public class MeasuredResponse
{
    public MeasuredResponse(HttpResponseMessage response, TimeSpan executionTime)
    {
        Response = response;
        ExecutionTime = executionTime;
    }

    public TimeSpan ExecutionTime { get; set; }
    public HttpResponseMessage Response { get; set; }
}
