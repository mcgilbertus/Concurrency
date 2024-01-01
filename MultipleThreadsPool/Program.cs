using System.Diagnostics;

const long MaxCount = 100_000_000;
const int NumProcesses = 4;


static void Count(long maxCount, ManualResetEvent resetEvent)
{
    var counter = 0;
    while (counter < maxCount)
    {
        counter++;
    }

    resetEvent.Set();
}

// using ThreadPool
Console.WriteLine("Starting threads using pool");

var stopwatch = new Stopwatch();
stopwatch.Start();

var events = new List<ManualResetEvent>();
for (int i = 0; i < NumProcesses; i++)
{
    var mre = new ManualResetEvent(false);
    ThreadPool.QueueUserWorkItem((object stateInfo) => Count(MaxCount, mre));
    events.Add(mre);
}

WaitHandle.WaitAll(events.ToArray());

stopwatch.Stop();
Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}");