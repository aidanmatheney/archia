namespace Archia.WinForms
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Archia.Utils;

    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public sealed class ArchiaAppService : IHostedService
    {
        private readonly ArchiaServiceScope _serviceScope;
        private readonly IProgress<bool> _startStopProgress;

        public ArchiaAppService(ArchiaServiceProvider services)
        {
            ThrowIf.Null(services, nameof(services));

            _serviceScope = services.CreateScope();

            var signInForm = new SignInForm(_serviceScope.ServiceProvider);
            signInForm.FormClosed += (sender, e) => services.AppLifetime.StopApplication();

            _startStopProgress = new Progress<bool>(start =>
            {
                if (start)
                {
                    signInForm.Show();
                }
                else
                {
                    signInForm.Hide();
                }
            });
        }

        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            var dbSeeder = _serviceScope.ServiceProvider.DbSeeder;
            try
            {
                await dbSeeder.SeedAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _serviceScope.ServiceProvider.Logger<ArchiaAppService>().LogError(ex, "Failed to seed the database");
                throw;
            }

            _startStopProgress.Report(true);
        }

        public Task StopAsync(CancellationToken cancellationToken = default)
        {
            _startStopProgress.Report(false);
            return Task.CompletedTask;
        }
    }
}