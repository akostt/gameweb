﻿using Microsoft.Extensions.Hosting;

namespace GameWeb.infrastructure;

public class BackgroundService : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}