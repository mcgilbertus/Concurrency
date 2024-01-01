using System.Diagnostics;

const long MaxCount = 100_000_000;
const int NumProcesses = 4;


static void Count(long maxCount)
{
    var counter = 0;
    while (counter < maxCount)
    {
        counter++;
    }
}

// using ThreadPool
Console.WriteLine("Starting threads using Task");

var stopwatch = new Stopwatch();
stopwatch.Start();

var tasks = new List<Task>();
for (int i = 0; i < NumProcesses; i++)
{
    tasks.Add(Task.Run(() => Count(MaxCount)));
}

Task.WaitAll(tasks.ToArray());

stopwatch.Stop();
Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}");