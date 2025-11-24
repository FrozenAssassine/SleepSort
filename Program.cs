using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;


float[] test = {
            5, 9, 1, 20, 3, -1, -9, 12, 44, 7, 0, 18, -4, 23, 81, -12, 6, 55, 90, -33,
            17, 29, 4, -8, 39, 72, 11, -2, 8, 100, 63, 14, -17, 27, 32, -22, 19, 2,
            47, 76, -5, 31, 54, -6, 13, 99, 25, -15, 22, 16, -3, 40, 77, 1, -10, 33,
            21, 48, -7, 26, 66, 58, 42, -20, 34, 3, 7, 15, -11, 36, 62, 41, 28, -19,
            59, 50, 24, 10, -13, 64, 73, 52, 30, -14, 46, 71, 57, 35, -16, 60, 45,
            53, 38, -18, 67, 56, 43
        };
float[] sorted = await SleepSort(test, 100);

foreach (float item in sorted)
    Console.WriteLine(item);

static Task<float[]> SleepSort(float[] items, int accuracyAndDurationAmplifier = 1)
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
