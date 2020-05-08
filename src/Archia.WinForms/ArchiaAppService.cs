namespace Archia.WinForms
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Archia.Utils;

    using Microsoft.Extensions.Hosting;

    public sealed class ArchiaAppService : IHostedService
    {
        private readonly IProgress<bool> _startStopProgress;

        public ArchiaAppService(IHostApplicationLifetime appLifetime, ArchiaServiceProvider services)
        {
            ThrowIf.Null(appLifetime, nameof(appLifetime));
            ThrowIf.Null(services, nameof(services));

            var signInForm = new SignInForm(services);
            signInForm.FormClosed += (sender, e) => appLifetime.StopApplication();

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

        public Task StartAsync(CancellationToken cancellationToken = default)
        {
            _startStopProgress.Report(true);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken = default)
        {
            _startStopProgress.Report(false);
            return Task.CompletedTask;
        }
    }
}