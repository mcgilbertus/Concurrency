
Console.WriteLine("Synchronous");
Console.WriteLine("-----------");
ReadAllBytes_Synchronous();
Console.WriteLine("Press enter to continue");
Console.ReadLine();

Console.WriteLine("Wait until completed");
Console.WriteLine("--------------------");
ReadAllBytes_WaitUntilCompleted();
Console.WriteLine("Press enter to continue");
Console.ReadLine();

Console.WriteLine("Continuation");
Console.WriteLine("------------");
ReadAllBytes_Continuation();
Console.WriteLine("Press enter to continue");
Console.ReadLine();

Console.WriteLine("async/await");
Console.WriteLine("-----------");
await ReadAllBytes_AsyncAwait();
Console.WriteLine("Press enter to continue");
Console.ReadLine();

return;

///////////////////////
void ReadAllBytes_Synchronous()
{
    Console.WriteLine($"Reading bytes...");
    byte[] data = File.ReadAllBytes("example.bin");
    Console.WriteLine($"Read {data.Length} bytes");
}

///////////////////////
async Task ReadAllBytes_AsyncAwait()
{
    Console.WriteLine($"Reading bytes...");
    byte[] data = await File.ReadAllBytesAsync("example.bin");
    Console.WriteLine($"Read {data.Length} bytes");
}

///////////////////////
void ReadAllBytes_Continuation()
{
    Console.WriteLine($"Reading bytes...");
    Task<byte[]> readCompleted = File.ReadAllBytesAsync("example.bin");
    readCompleted.ContinueWith(t =>
    {
        if (t.IsCompletedSuccessfully)
        {
            byte[] bytes = t.Result;
            Console.WriteLine($"Read {bytes.Length} bytes");
        }
    });
}

///////////////////////
void ReadAllBytes_WaitUntilCompleted()
{
    Console.WriteLine($"Reading bytes...");
    Task<byte[]> readCompleted = File.ReadAllBytesAsync("example.bin");
    while (!readCompleted.IsCompleted)
    {
        Console.WriteLine("Waiting for read to complete");
    }

    // this will not block because the task is already completed
    byte[] data = readCompleted.Result;
    Console.WriteLine($"Read {data.Length} bytes");
}