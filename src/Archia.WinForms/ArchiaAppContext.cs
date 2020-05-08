namespace Archia.WinForms
{
    using System;
    using System.Windows.Forms;

    using Microsoft.Extensions.DependencyInjection;

    public sealed class ArchiaAppContext : ApplicationContext
    {
        public ArchiaAppContext()
        {
            var services = CreateServiceProvider();

            var signedOutForm = new SignedOutForm(services);
            signedOutForm.FormClosed += HandleSignedOutFormClosed;

            signedOutForm.Show();
        }

        private void HandleSignedOutFormClosed(object sender, FormClosedEventArgs e)
        {
            ExitThread();
        }

        private static IServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();

            return services.BuildServiceProvider();
        }
    }
}