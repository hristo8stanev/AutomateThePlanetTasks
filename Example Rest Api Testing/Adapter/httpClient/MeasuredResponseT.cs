using System.Net.Http;

namespace Examples.Adapter.httpClient;
public class MeasuredResponse<TReturnType>
        where TReturnType : new()
{
    public MeasuredResponse(HttpResponseMessage response, TReturnType data, TimeSpan executionTime)
    {
        Response = response;
        Data = data;
        ExecutionTime = executionTime;
    }

    public TimeSpan ExecutionTime { get; set; }
    public HttpResponseMessage Response { get; set; }
    public TReturnType Data { get; set; }
}