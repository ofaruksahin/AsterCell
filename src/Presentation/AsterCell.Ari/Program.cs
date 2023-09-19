using AsterCell.Ari;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<AriWorker>();
    })
    .Build();

host.Run();
