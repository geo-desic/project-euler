using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectEuler.Problems;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEulerApp
{
    internal sealed class ProblemWorker(ILogger<ProblemWorker> logger, IServiceScopeFactory serviceScopeFactory, IHostApplicationLifetime hostApplicationLifetime) : BackgroundService
    {
        // worker services in .net => https://learn.microsoft.com/en-us/dotnet/core/extensions/workers

        private readonly IHostApplicationLifetime _hostApplicationLifetime = hostApplicationLifetime;
        private readonly ILogger<ProblemWorker> _logger = logger;
        private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var problemTypes = ProblemTypes();
            var stopwatch = new Stopwatch();
            _logger.LogInformation("{timestamp:O} Starting problems", DateTime.Now);
            stopwatch.Start();
            foreach (var problemType in problemTypes)
            {
                var problem = ActivatorUtilities.CreateInstance(scope.ServiceProvider, problemType) as IProblem;
                problem.Answer();
            }
            stopwatch.Stop();
            _logger.LogInformation("{timestamp:O} Completed problems in {totalSeconds}s", DateTime.Now, stopwatch.Elapsed.TotalSeconds);

            _hostApplicationLifetime.StopApplication();

            await Task.CompletedTask;
        }

        private static List<Type> ProblemTypes()
        {
            return
            [
                typeof(Problem001),
                typeof(Problem002),
                typeof(Problem003),
                typeof(Problem004),
                typeof(Problem005),
                typeof(Problem006),
                typeof(Problem007),
                typeof(Problem008),
                typeof(Problem009),
                typeof(Problem010),
                typeof(Problem011),
                typeof(Problem012),
                typeof(Problem013),
                typeof(Problem014),
                typeof(Problem015),
                typeof(Problem016),
                typeof(Problem017),
                typeof(Problem018),
                typeof(Problem019),
                typeof(Problem020),
                typeof(Problem021),
                typeof(Problem022),
                typeof(Problem023),
                typeof(Problem024),
                typeof(Problem025),
                typeof(Problem026),
                typeof(Problem027),
                typeof(Problem028),
                typeof(Problem029),
                typeof(Problem030),
                typeof(Problem031),
                typeof(Problem032),
                typeof(Problem033),
                typeof(Problem034),
                typeof(Problem035),
                typeof(Problem036),
                typeof(Problem037),
                typeof(Problem038),
                typeof(Problem039),
                typeof(Problem040),
            ];
        }
    }
}
