using System;
using System.Threading;

namespace ThreadPoolExercises.Core
{
    public class ThreadingHelpers
    {
        // * Create a thread and execute there `action` given number of `repeats` - waiting for the execution!
        //   HINT: you may use `Join` to wait until created Thread finishes
        // * In a loop, check whether `token` is not cancelled
        // * If an `action` throws and exception (or token has been cancelled) - `errorAction` should be invoked (if provided)
        public static void ExecuteOnThread(Action action, int repeats, CancellationToken token = default, Action<Exception>? errorAction = null)
        {
            var thread = new Thread(() => ExecuteAction(action, repeats, token, errorAction));
            thread.Start();
            thread.Join();
        }

        // * Queue work item to a thread pool that executes `action` given number of `repeats` - waiting for the execution!
        //   HINT: you may use `AutoResetEvent` to wait until the queued work item finishes
        // * In a loop, check whether `token` is not cancelled
        // * If an `action` throws and exception (or token has been cancelled) - `errorAction` should be invoked (if provided)
        public static void ExecuteOnThreadPool(Action action, int repeats, CancellationToken token = default, Action<Exception>? errorAction = null)
        {
            var autoResetEvent = new AutoResetEvent(false);

            ThreadPool.QueueUserWorkItem(_ =>
            {
                ExecuteAction(action, repeats, token, errorAction);
                autoResetEvent.Set();
            });

            autoResetEvent.WaitOne();
        }

        private static void ExecuteAction(Action action, int repeats, CancellationToken token, Action<Exception>? errorAction)
        {
            for (int i = 0; i < repeats; i++)
            {
                try
                {
                    token.ThrowIfCancellationRequested();
                    action();
                }
                catch (Exception ex)
                {
                    errorAction?.Invoke(ex);
                    break;
                }
            }
        }
    }
}
