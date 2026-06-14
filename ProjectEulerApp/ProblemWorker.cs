using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectEuler.Problems;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEulerApp;

internal sealed class ProblemWorker(ILogger<ProblemWorker> logger, IServiceScopeFactory serviceScopeFactory, IHostApplicationLifetime hostApplicationLifetime) : BackgroundService
{
    // worker services in .net => https://learn.microsoft.com/en-us/dotnet/core/extensions/workers

    private readonly IHostApplicationLifetime _hostApplicationLifetime = hostApplicationLifetime;
    private readonly ILogger<ProblemWorker> _logger = logger;
    private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var problemTypes = ProblemTypes();
        var stopwatch = new Stopwatch();
        _logger.LogInformation("{Timestamp:O} Starting problems", DateTime.Now);
        stopwatch.Start();
        foreach (var problemType in problemTypes)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var problem = (IProblem)ActivatorUtilities.CreateInstance(scope.ServiceProvider, problemType);
            problem.Answer();
        }
        stopwatch.Stop();
        _logger.LogInformation("{Timestamp:O} Completed problems in {TotalSeconds}s", DateTime.Now, stopwatch.Elapsed.TotalSeconds);

        _hostApplicationLifetime.StopApplication();

        await Task.CompletedTask;
    }

    private static List<Type> ProblemTypes()
    {
        // Discover every concrete IProblem in the ProjectEuler library, ordered by type name
        // so Problem001..ProblemNNN run in sequence. Adding a new problem requires no registration here.
        return typeof(IProblem).Assembly
            .GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && typeof(IProblem).IsAssignableFrom(type))
            .OrderBy(type => type.Name, StringComparer.Ordinal)
            .ToList();
    }
}
