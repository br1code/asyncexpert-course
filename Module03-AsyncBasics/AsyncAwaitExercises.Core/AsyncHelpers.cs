using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitExercises.Core
{
    public class AsyncHelpers
    {
        // Create a method that will try to get a response from a given `url`, retrying `maxTries` number of times.
        // It should wait one second before the second try, and double the wait time before every successive retry
        // (so pauses before retries will be 1, 2, 4, 8, ... seconds).
        // * `maxTries` must be at least 2
        // * we retry if:
        //    * we get non-successful status code (outside of 200-299 range), or
        //    * HTTP call thrown an exception (like network connectivity or DNS issue)
        // * token should be able to cancel both HTTP call and the retry delay
        // * if all retries fails, the method should throw the exception of the last try
        // HINTS:
        // * `HttpClient.GetStringAsync` does not accept cancellation token (use `GetAsync` instead)
        // * you may use `EnsureSuccessStatusCode()` method

        public static Task<string> GetStringWithRetries(HttpClient client, string url, int maxTries = 3, CancellationToken token = default)
        {
            if (maxTries < 2)
                throw new ArgumentException($"{nameof(maxTries)} must be at least 2");

            return GetStringWithRetriesAsync(client, url, maxTries, token);
        }

        public static async Task<string> GetStringWithRetriesAsync(HttpClient client, string url, int maxTries = 3, CancellationToken token = default)
        {
            int tries = 0;
            int retryDelayInSeconds = 1;

            while (tries < maxTries)
            {
                ThrowIfCancellationRequested(token);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url, token);
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    TimeSpan delay = TimeSpan.FromSeconds(retryDelayInSeconds);
                    await Task.Delay(delay, token);

                    retryDelayInSeconds *= 2;
                    tries++;

                    if (tries == maxTries)
                    {
                        throw ex;
                    }
                }
            }

            return string.Empty;
        }

        private static void ThrowIfCancellationRequested(CancellationToken cancellation)
        {
            if (cancellation.IsCancellationRequested)
            {
                throw new TaskCanceledException();
            }
        }
    }
}
