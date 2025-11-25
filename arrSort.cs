using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;

static Task<float[]> SleepSortAsync(float[] items, int accuracyAndDurationAmplifier = 1)
{
    var tcs = new TaskCompletionSource<float[]>();
    var result = new List<float>();
    object locker = new object();

    float max = float.MinValue;
    float maxNeg = 0;

    foreach (float item in items)
    {
        if (item > max) max = item;
        if (item < 0 && item < maxNeg) maxNeg = item;
    }

    foreach (float item in items)
    {
        double delay = (item < 0 ? -(maxNeg - item) : item + -maxNeg) * accuracyAndDurationAmplifier;

        if (delay < 1) delay = 1;

        System.Timers.Timer t = new System.Timers.Timer(delay);
        t.AutoReset = false;

        t.Elapsed += (s, e) =>
        {
            lock (locker)
            {
                result.Add(item);
                if (result.Count == items.Length)
                    tcs.SetResult(result.ToArray());
            }
            t.Dispose();
        };

        t.Start();
    }

    return tcs.Task;
}
