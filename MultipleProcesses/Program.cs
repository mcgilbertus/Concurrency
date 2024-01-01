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


if (args.Length > 0)
{
    Count(MaxCount);
    return;
}

var stopwatch = new Stopwatch();
stopwatch.Start();

var exec = Process.GetCurrentProcess().MainModule.FileName;
var processes = new List<Process>();
for (int i = 0; i < NumProcesses; i++)
{
    
    var proc = new Process()
    {
        StartInfo = new ProcessStartInfo()
        {
            FileName = exec,
            WorkingDirectory = Path.GetDirectoryName(exec),
            ArgumentList = {"-a"},
            // UseShellExecute = true, // to make the window visible
            WindowStyle = ProcessWindowStyle.Normal
        }
    };
    processes.Add(proc);
}

;

foreach (var proc in processes)
{
    proc.Start();
}

foreach (var proc in processes)
{
    proc.WaitForExit();
}

stopwatch.Stop();
Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}");