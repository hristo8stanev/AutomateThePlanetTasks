using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Polly;

namespace Examples.Adapter.httpClient;
public class ApiClientService
{
    private readonly int _maxRetryAttempts;
    private readonly TimeSpan _pauseBetweenFailures;

    public ApiClientService(string baseUrl, int timeoutInSeconds, int maxRetryAttempts, int pauseBetweenFailuresMilliseconds = 500)
    {
        WrappedClient = new HttpClient();
        WrappedClient.BaseAddress = new Uri(baseUrl);
        WrappedClient.Timeout = TimeSpan.FromSeconds(timeoutInSeconds);

        _maxRetryAttempts = maxRetryAttempts;
        _pauseBetweenFailures = TimeSpan.FromMilliseconds(pauseBetweenFailuresMilliseconds);
    }

    public ApiClientService(string baseUrl, int timeoutInSeconds, int maxRetryAttempts, int pauseBetweenFailuresMilliseconds, AuthenticationHeaderValue authenticationHeaderValue)
    : this(baseUrl, timeoutInSeconds, maxRetryAttempts, pauseBetweenFailuresMilliseconds)
    {
        WrappedClient.DefaultRequestHeaders.Authorization = authenticationHeaderValue;
    }

    public HttpClient WrappedClient { get; set; }

    public async Task<MeasuredResponse> GetAsync(HttpRequestMessage request, CancellationTokenSource cancellationTokenSource = null)
    {
        return await ExecuteMeasuredRequestAsync(request, HttpMethod.Get, cancellationTokenSource);
    }

    public async Task<MeasuredResponse<TReturnType>> GetAsync<TReturnType>(HttpRequestMessage request, CancellationTokenSource cancellationTokenSource = null)
        where TReturnType : new()
    {
        return await ExecuteMeasuredRequestAsync<TReturnType>(request, HttpMethod.Get, cancellationTokenSource);
    }

    public async Task<MeasuredResponse> PutAsync(HttpRequestMessage request, CancellationTokenSource cancellationTokenSource = null)
    {
        return await ExecuteMeasuredRequestAsync(request, HttpMethod.Put, cancellationTokenSource);
    }

    public async Task<MeasuredResponse<TReturnType>> PutAsync<TReturnType>(HttpRequestMessage request, CancellationTokenSource cancellationTokenSource = null)
        where TReturnType : new()
    {
        return await ExecuteMeasuredRequestAsync<TReturnType>(request, HttpMethod.Put, cancellationTokenSource);
    }

    public async Task<MeasuredResponse> PostAsync(HttpRequestMessage request, CancellationTokenSource cancellationTokenSource = null)
    {
        return await ExecuteMeasuredRequestAsync(request, HttpMethod.Post, cancellationTokenSource);
    }

    public async Task<MeasuredResponse<TReturnType>> PostAsync<TReturnType>(HttpRequestMessage request, CancellationTokenSource cancellationTokenSource = null)
        where TReturnType : new()
    {
        return await ExecuteMeasuredRequestAsync<TReturnType>(request, HttpMethod.Post, cancellationTokenSource);
    }

    public async Task<MeasuredResponse> DeleteAsync(HttpRequestMessage request, CancellationTokenSource cancellationTokenSource = null)
    {
        return await ExecuteMeasuredRequestAsync(request, HttpMethod.Delete, cancellationTokenSource);
    }

    public async Task<MeasuredResponse<TReturnType>> DeleteAsync<TReturnType>(HttpRequestMessage request, CancellationTokenSource cancellationTokenSource = null)
        where TReturnType : new()
    {
        return await ExecuteMeasuredRequestAsync<TReturnType>(request, HttpMethod.Delete, cancellationTokenSource);
    }

    public async Task<MeasuredResponse> HeadAsync(HttpRequestMessage request, CancellationTokenSource cancellationTokenSource = null)
    {
        return await ExecuteMeasuredRequestAsync(request, HttpMethod.Head, cancellationTokenSource);
    }

    public async Task<MeasuredResponse<TReturnType>> HeadAsync<TReturnType>(HttpRequestMessage request, CancellationTokenSource cancellationTokenSource = null)
        where TReturnType : new()
    {
        return await ExecuteMeasuredRequestAsync<TReturnType>(request, HttpMethod.Head, cancellationTokenSource);
    }

    public async Task<MeasuredResponse<TReturnType>> OptionsAsync<TReturnType>(HttpRequestMessage request, CancellationTokenSource cancellationTokenSource = null)
        where TReturnType : new()
    {
        return await ExecuteMeasuredRequestAsync<TReturnType>(request, HttpMethod.Options, cancellationTokenSource);
    }

    public async Task<MeasuredResponse<TReturnType>> PatchAsync<TReturnType>(HttpRequestMessage request, CancellationTokenSource cancellationTokenSource = null)
        where TReturnType : new()
    {
        return await ExecuteMeasuredRequestAsync<TReturnType>(request, HttpMethod.Patch, cancellationTokenSource);
    }

    private async Task<MeasuredResponse<TReturnType>> ExecuteMeasuredRequestAsync<TReturnType>(HttpRequestMessage request, HttpMethod method, CancellationTokenSource cancellationTokenSource = null)
      where TReturnType : new()
    {
        if (cancellationTokenSource == null)
        {
            cancellationTokenSource = new CancellationTokenSource();
        }

        var retryPolicy = Policy.Handle<NotSuccessfulRequestException>().WaitAndRetryAsync(_maxRetryAttempts, i => _pauseBetweenFailures);

        var response = await retryPolicy.ExecuteAsync(async () =>
        {
            var watch = Stopwatch.StartNew();

            request.Method = method;
            var measuredResponse = default(MeasuredResponse<TReturnType>);
            var response = await WrappedClient.SendAsync(request, cancellationTokenSource.Token);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var actualResult = JsonConvert.DeserializeObject<TReturnType>(jsonResult);

            watch.Stop();
            measuredResponse = new MeasuredResponse<TReturnType>(response, actualResult, watch.Elapsed);

            if (!measuredResponse.Response.IsSuccessStatusCode)
            {
                throw new NotSuccessfulRequestException();
            }

            return measuredResponse;
        });

        return response;
    }

    private async Task<MeasuredResponse> ExecuteMeasuredRequestAsync(HttpRequestMessage request, HttpMethod method, CancellationTokenSource cancellationTokenSource = null)
    {
        if (cancellationTokenSource == null)
        {
            cancellationTokenSource = new CancellationTokenSource();
        }

        var retryPolicy = Policy.Handle<NotSuccessfulRequestException>().WaitAndRetryAsync(_maxRetryAttempts, i => _pauseBetweenFailures);

        var response = await retryPolicy.ExecuteAsync(async () =>
        {
            var watch = Stopwatch.StartNew();

            request.Method = method;

            var response = await WrappedClient.SendAsync(request, cancellationTokenSource.Token);

            watch.Stop();
            var measuredResponse = new MeasuredResponse(response, watch.Elapsed);

            if (!measuredResponse.Response.IsSuccessStatusCode)
            {
                throw new NotSuccessfulRequestException();
            }

            return measuredResponse;
        });

        return response;
    }
}