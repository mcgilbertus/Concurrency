using System.Diagnostics;

const long MaxCount = 100_000_000;
const int NumProcesses = 4;


static long Count(long maxCount)
{
    var counter = 0;
    while (counter < maxCount)
    {
        counter++;
    }

    return counter;
}

Console.WriteLine("Starting threads, no pool");
var stopwatch = new Stopwatch();
stopwatch.Start();

// create new threads without a pool
var threads = new List<Thread>();
for (int i = 0; i < NumProcesses; i++)
{
    var proc = new Thread(() => Count(MaxCount));
    threads.Add(proc);
}

foreach (var proc in threads)
{
    proc.Start();
}

foreach (var proc in threads)
{
    proc.Join();
}

stopwatch.Stop();
Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}");

