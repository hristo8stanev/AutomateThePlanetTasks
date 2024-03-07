using System.Net.Http.Headers;
using Flurl.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using RestSharp.Authenticators;
using RestSharp;
using Polly;


//namespace Examples.Adapter.Flurl;
//public class ApiClientService
//{
//    private readonly int _maxRetryAttempts;
//    private readonly TimeSpan _pauseBetweenFailures;
//    private const string AUTH_TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJiZWxsYXRyaXhVc2VyIiwianRpIjoiNjEyYjIzOTktNDUzMS00NmU0LTg5NjYtN2UxYmRhY2VmZTFlIiwibmJmIjoxNTE4NTI0NDg0LCJleHAiOjE1MjM3MDg0ODQsImlzcyI6ImF1dG9tYXRldGhlcGxhbmV0LmNvbSIsImF1ZCI6ImF1dG9tYXRldGhlcGxhbmV0LmNvbSJ9.Nq6OXqrK82KSmWNrpcokRIWYrXHanpinrqwbUlKT_cs";
//
//
//    public ApiClientService(string baseUrl, int timeoutInSeconds, int maxRetryAttempts, int pauseBetweenFailuresMilliseconds = 500, IAuthenticator authenticator = null)
//    {
//
//        var client = new FlurlClient(baseUrl);
//        client.Settings.Timeout = TimeSpan.FromSeconds(timeoutInSeconds);
//        client.Settings.Redirects.Enabled = false;
//
//
//        _maxRetryAttempts = maxRetryAttempts;
//        _pauseBetweenFailures = TimeSpan.FromMilliseconds(pauseBetweenFailuresMilliseconds);
//    }
//
//    public ApiClientService(string baseUrl, int timeoutInSeconds, int maxRetryAttempts, int pauseBetweenFailuresMilliseconds, AuthenticationHeaderValue authenticationHeaderValue)
//    : this(baseUrl, timeoutInSeconds, maxRetryAttempts, pauseBetweenFailuresMilliseconds)
//    {
//        WrappedClient.HttpClient.DefaultRequestHeaders.Authorization= authenticationHeaderValue;
//    }
//
//    public FlurlClient WrappedClient { get; set; }
//    
//    public async Task<MeasuredResponse> GetAsync(FlurlRequest request, CancellationTokenSource cancellationTokenSource = null)
//    {
//        return await ExecuteMeasuredRequestAsync(request, HttpMethod.Get, cancellationTokenSource);
//    }
//
//    public async Task<MeasuredResponse<TReturnType>> GetAsync<TReturnType>(FlurlRequest request, CancellationTokenSource cancellationTokenSource = null)
//        where TReturnType : new()
//    {
//        return await ExecuteMeasuredRequestAsync<TReturnType>(request, HttpMethod.Get, cancellationTokenSource);
//    }
//
//    public async Task<MeasuredResponse> PutAsync(FlurlRequest request, CancellationTokenSource cancellationTokenSource = null)
//    {
//        return await ExecuteMeasuredRequestAsync(request, HttpMethod.Put, cancellationTokenSource);
//    }
//
//    public async Task<MeasuredResponse<TReturnType>> PutAsync<TReturnType>(FlurlRequest request, CancellationTokenSource cancellationTokenSource = null)
//        where TReturnType : new()
//    {
//        return await ExecuteMeasuredRequestAsync<TReturnType>(request, HttpMethod.Put, cancellationTokenSource);
//    }
//
//    public async Task<MeasuredResponse> PostAsync(FlurlRequest request, CancellationTokenSource cancellationTokenSource = null)
//    {
//        return await ExecuteMeasuredRequestAsync(request, HttpMethod.Post, cancellationTokenSource);
//    }
//
//    public async Task<MeasuredResponse<TReturnType>> PostAsync<TReturnType>(FlurlRequest request, CancellationTokenSource cancellationTokenSource = null)
//        where TReturnType : new()
//    {
//        return await ExecuteMeasuredRequestAsync<TReturnType>(request, HttpMethod.Post, cancellationTokenSource);
//    }
//
//    public async Task<MeasuredResponse> DeleteAsync(FlurlRequest request, CancellationTokenSource cancellationTokenSource = null)
//    {
//        return await ExecuteMeasuredRequestAsync(request, HttpMethod.Delete, cancellationTokenSource);
//    }
//
//    public async Task<MeasuredResponse<TReturnType>> DeleteAsync<TReturnType>(FlurlRequest request, CancellationTokenSource cancellationTokenSource = null)
//        where TReturnType : new()
//    {
//        return await ExecuteMeasuredRequestAsync<TReturnType>(request, HttpMethod.Delete, cancellationTokenSource);
//    }
//
//    public async Task<MeasuredResponse> HeadAsync(FlurlRequest request, CancellationTokenSource cancellationTokenSource = null)
//    {
//        return await ExecuteMeasuredRequestAsync(request, HttpMethod.Head, cancellationTokenSource);
//    }
//
//    public async Task<MeasuredResponse<TReturnType>> HeadAsync<TReturnType>(FlurlRequest request, CancellationTokenSource cancellationTokenSource = null)
//        where TReturnType : new()
//    {
//        return await ExecuteMeasuredRequestAsync<TReturnType>(request, HttpMethod.Head, cancellationTokenSource);
//    }
//
//    public async Task<MeasuredResponse<TReturnType>> OptionsAsync<TReturnType>(FlurlRequest request, CancellationTokenSource cancellationTokenSource = null)
//     where TReturnType : new()
//    {
//        return await ExecuteMeasuredRequestAsync<TReturnType>(request, HttpMethod.Options, cancellationTokenSource);
//    }
//
//    public async Task<MeasuredResponse<TReturnType>> PatchAsync<TReturnType>(FlurlRequest request, CancellationTokenSource cancellationTokenSource = null)
//     where TReturnType : new()
//    {
//        return await ExecuteMeasuredRequestAsync<TReturnType>(request, HttpMethod.Patch, cancellationTokenSource);
//    }
//
//    private async Task<MeasuredResponse<TReturnType>> ExecuteMeasuredRequestAsync<TReturnType>(FlurlRequest request, HttpMethod method, CancellationTokenSource cancellationTokenSource = null)
//    where TReturnType : new()
//    {
//        if (cancellationTokenSource == null)
//        {
//            cancellationTokenSource = new CancellationTokenSource();
//        }
//
//        var retryPolicy = Policy.Handle<NotSuccessfulRequestException>().WaitAndRetryAsync(_maxRetryAttempts, i => _pauseBetweenFailures);
//
//        var response = await retryPolicy.ExecuteAsync(async () =>
//        {
//            var watch = Stopwatch.StartNew();
//
//            request.Verb = method;
//            var measuredResponse = default(MeasuredResponse<TReturnType>);
//            var response = await WrappedClient.SendAsync(request, cancellationTokenSource.Token);
//
//            var jsonResult = await response.Content.ReadAsStringAsync();
//            var actualResult = JsonConvert.DeserializeObject<TReturnType>(jsonResult);
//
//            watch.Stop();
//            response = new MeasuredResponse<TReturnType>(response, actualResult, watch.Elapsed);
//
//            if (!measuredResponse.Response.IsSuccessStatusCode)
//            {
//                throw new NotSuccessfulRequestException();
//            }
//
//            return measuredResponse;
//        });
//
//        return response;
//    }
//
//    private async Task<MeasuredResponse>ExecuteMeasuredRequestAsync(FlurlRequest request, HttpMethod method, CancellationTokenSource cancellationTokenSource = null)
//    {
//        if (cancellationTokenSource == null)
//        {
//            cancellationTokenSource = new CancellationTokenSource();
//        }
//
//        var retryPolicy = Policy.Handle<NotSuccessfulRequestException>().WaitAndRetryAsync(_maxRetryAttempts, i => _pauseBetweenFailures);
//
//        var response = await retryPolicy.ExecuteAsync(async () =>
//        {
//            var watch = Stopwatch.StartNew();
//
//            request.Verb = method;
//
//            var response = await WrappedClient.SendAsync(request, cancellationTokenSource.Token);
//
//            watch.Stop();
//            var measuredResponse = new MeasuredResponse(response, watch.Elapsed);
//
//            if (!measuredResponse.Response.IsSuccessStatusCode)
//            {
//                throw new NotSuccessfulRequestException();
//            }
//
//            return measuredResponse;
//        });
//
//        return response;
//    }
//}