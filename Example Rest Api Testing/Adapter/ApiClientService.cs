using System.Threading.Tasks;
using Polly;
using RestSharp.Authenticators;

namespace Examples.Adapter;
public class ApiClientService
{
    private readonly int _maxRetryAttempts;
    private readonly TimeSpan _pauseBetweenFailures;

    public ApiClientService(int maxRetryAttempts, int pauseBetweenFailuresMilliseconds = 500, IAuthenticator authenticator = null)
    {
        var options = new RestClientOptions();
        if (authenticator != null)
        {
            options.Authenticator = authenticator;
        }

        WrappedClient = new RestClient();

        _maxRetryAttempts = maxRetryAttempts;
        _pauseBetweenFailures = TimeSpan.FromMilliseconds(pauseBetweenFailuresMilliseconds);
    }

    public RestClient WrappedClient { get; set; }

    public async Task<MeasuredResponse> GetAsync(RestRequest request, CancellationTokenSource cancellationTokenSource = null)
    {
        return await ExecuteMeasuredRequestAsync(request, Method.Get, cancellationTokenSource);
    }

    public async Task<MeasuredResponse<TReturnType>> GetAsync<TReturnType>(RestRequest request, CancellationTokenSource cancellationTokenSource = null)
        where TReturnType : new()
    {
        return await ExecuteMeasuredRequestAsync<TReturnType>(request, Method.Get, cancellationTokenSource);
    }

    public async Task<MeasuredResponse> PutAsync(RestRequest request, CancellationTokenSource cancellationTokenSource = null)
    {
        return await ExecuteMeasuredRequestAsync(request, Method.Put, cancellationTokenSource);
    }

    public async Task<MeasuredResponse<TReturnType>> PutAsync<TReturnType>(RestRequest request, CancellationTokenSource cancellationTokenSource = null)
        where TReturnType : new()
    {
        return await ExecuteMeasuredRequestAsync<TReturnType>(request, Method.Put, cancellationTokenSource);
    }

    public async Task<MeasuredResponse> PostAsync(RestRequest request, CancellationTokenSource cancellationTokenSource = null)
    {
        return await ExecuteMeasuredRequestAsync(request, Method.Post, cancellationTokenSource);
    }

    public async Task<MeasuredResponse<TReturnType>> PostAsync<TReturnType>(RestRequest request, CancellationTokenSource cancellationTokenSource = null)
        where TReturnType : new()
    {
        return await ExecuteMeasuredRequestAsync<TReturnType>(request, Method.Post, cancellationTokenSource);
    }

    public async Task<MeasuredResponse> DeleteAsync(RestRequest request, CancellationTokenSource cancellationTokenSource = null)
    {
        return await ExecuteMeasuredRequestAsync(request, Method.Delete, cancellationTokenSource);
    }

    public async Task<MeasuredResponse<TReturnType>> DeleteAsync<TReturnType>(RestRequest request, CancellationTokenSource cancellationTokenSource = null)
        where TReturnType : new()
    {
        return await ExecuteMeasuredRequestAsync<TReturnType>(request, Method.Delete, cancellationTokenSource);
    }

    public async Task<MeasuredResponse> CopyAsync(RestRequest request, CancellationTokenSource cancellationTokenSource = null)
    {
        return await ExecuteMeasuredRequestAsync(request, Method.Copy, cancellationTokenSource);
    }

    public async Task<MeasuredResponse<TReturnType>> CopyAsync<TReturnType>(RestRequest request, CancellationTokenSource cancellationTokenSource = null)
        where TReturnType : new()
    {
        return await ExecuteMeasuredRequestAsync<TReturnType>(request, Method.Copy, cancellationTokenSource);
    }

    public async Task<MeasuredResponse> HeadAsync(RestRequest request, CancellationTokenSource cancellationTokenSource = null)
    {
        return await ExecuteMeasuredRequestAsync(request, Method.Head, cancellationTokenSource);
    }

    public async Task<MeasuredResponse<TReturnType>> HeadAsync<TReturnType>(RestRequest request, CancellationTokenSource cancellationTokenSource = null)
        where TReturnType : new()
    {
        return await ExecuteMeasuredRequestAsync<TReturnType>(request, Method.Head, cancellationTokenSource);
    }

    public async Task<MeasuredResponse> MergeAsync(RestRequest request, CancellationTokenSource cancellationTokenSource = null)
    {
        return await ExecuteMeasuredRequestAsync(request, Method.Merge, cancellationTokenSource);
    }

    public async Task<MeasuredResponse<TReturnType>> MergeAsync<TReturnType>(RestRequest request, CancellationTokenSource cancellationTokenSource = null)
        where TReturnType : new()
    {
        return await ExecuteMeasuredRequestAsync<TReturnType>(request, Method.Merge, cancellationTokenSource);
    }

    public async Task<MeasuredResponse> OptionsAsync(RestRequest request, CancellationTokenSource cancellationTokenSource = null)
    {
        return await ExecuteMeasuredRequestAsync(request, Method.Options, cancellationTokenSource);
    }

    public async Task<MeasuredResponse<TReturnType>> OptionsAsync<TReturnType>(RestRequest request, CancellationTokenSource cancellationTokenSource = null)
        where TReturnType : new()
    {
        return await ExecuteMeasuredRequestAsync<TReturnType>(request, Method.Options, cancellationTokenSource);
    }

    public async Task<MeasuredResponse> PatchAsync(RestRequest request, CancellationTokenSource cancellationTokenSource = null)
    {
        return await ExecuteMeasuredRequestAsync(request, Method.Patch, cancellationTokenSource);
    }

    public async Task<MeasuredResponse<TReturnType>> PatchAsync<TReturnType>(RestRequest request, CancellationTokenSource cancellationTokenSource = null)
        where TReturnType : new()
    {
        return await ExecuteMeasuredRequestAsync<TReturnType>(request, Method.Patch, cancellationTokenSource);
    }

    private async Task<MeasuredResponse<TReturnType>> ExecuteMeasuredRequestAsync<TReturnType>(RestRequest request, Method method, CancellationTokenSource cancellationTokenSource = null)
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
            var response = await WrappedClient.ExecuteAsync<TReturnType>(request, cancellationTokenSource.Token);

            watch.Stop();
            measuredResponse = new MeasuredResponse<TReturnType>(response, watch.Elapsed);

            if (!measuredResponse.IsSuccessful)
            {
                throw new NotSuccessfulRequestException();
            }

            return measuredResponse;
        });

        return response;
    }

    private async Task<MeasuredResponse> ExecuteMeasuredRequestAsync(RestRequest request, Method method, CancellationTokenSource cancellationTokenSource = null)
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

            var response = await WrappedClient.ExecuteAsync(request, cancellationTokenSource.Token);

            watch.Stop();
            var measuredResponse = new MeasuredResponse(response, watch.Elapsed);

            if (!measuredResponse.IsSuccessful)
            {
                throw new NotSuccessfulRequestException();
            }

            return measuredResponse;
        });

        return response;
    }
}