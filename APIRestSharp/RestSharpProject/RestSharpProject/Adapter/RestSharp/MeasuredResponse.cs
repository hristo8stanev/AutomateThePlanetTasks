using RestSharp;

namespace RestSharpProject.Adapter.RestSharp;
public class MeasuredResponse : RestResponse
{
    public MeasuredResponse(RestResponse restResponse, TimeSpan executionTime)
    {
        Response = restResponse;
        ExecutionTime = executionTime;
    }

    public TimeSpan ExecutionTime { get; set; }
    public RestResponse Response { get; set; }
}
