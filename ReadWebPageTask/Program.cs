async Task ReadWebPage(string url)
{
    using var tokenSource = new CancellationTokenSource();
    tokenSource.CancelAfter(10);

    try
    {
        using var client = new HttpClient();
        var html = await client.GetStringAsync(url, tokenSource.Token);
        Console.WriteLine(html);
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("The request was canceled");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception {ex.GetType()} occurred. Message: {ex.Message}");
    }
}

Console.WriteLine("Reading web page...");
ReadWebPage("https://www.linkedin.com/");
Console.WriteLine("Ready for user input");
Console.ReadLine();

