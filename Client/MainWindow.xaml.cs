using Library;
using Grpc.Core;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Windows;

namespace Client
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            clientFunctionality();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tbAdder.Clear();
            tbRemover.Clear();
        }

        void clientFunctionality()
        {
            string certs = GetRootCertificates();
            var channelCreds = new SslCredentials(certs);

            var channel = new Channel("localhost", 5001, channelCreds);
            var client = new Service.ServiceClient(channel);

            new Thread(() =>
            {
                while (true)
                {
                    bool shouldAdd = client.ShouldAddAsync(new WaterRequest()).ResponseAsync.Result.ShouldAdd;

                    Dispatcher.Invoke(new Action(() =>
                    {
                        tbAdder.Text += "Should add response : " + shouldAdd + "\n";
                        tbAdder.CaretIndex = tbAdder.Text.Length;
                        tbAdder.ScrollToEnd();
                    }));

                    if (shouldAdd)
                    {
                        double amount = Math.Round(new Random().NextDouble() * 5.0, 1);
                        var addResponse = client.AddAsync(new WaterAmountRequest { Amount = amount });

                        Dispatcher.Invoke(new Action(() =>
                        {
                            tbAdder.Text += $"Added {amount}L of water, now capacity is {addResponse.ResponseAsync.Result.WaterLevel}L\n";
                            tbAdder.CaretIndex = tbAdder.Text.Length;
                            tbAdder.ScrollToEnd();
                        }));
                    }

                    Thread.Sleep(1000);
                }
            })
            .Start();

            new Thread(() =>
            {
                while (true)
                {
                    bool shouldRemove = client.ShouldRemoveAsync(new WaterRequest()).ResponseAsync.Result.ShouldRemove;

                    Dispatcher.Invoke(new Action(() =>
                    {
                        tbRemover.Text += "Should remove response : " + shouldRemove + "\n";
                        tbRemover.CaretIndex = tbRemover.Text.Length;
                        tbRemover.ScrollToEnd();
                    }));

                    if (shouldRemove)
                    {
                        double amount = Math.Round(new Random().NextDouble() * 5.0, 1);
                        var removeResponse = client.RemoveAsync(new WaterAmountRequest { Amount = amount });

                        Dispatcher.Invoke(new Action(() =>
                        {
                            tbRemover.Text += $"Removed {amount}L of water, now capacity is {removeResponse.ResponseAsync.Result.WaterLevel}L\n";
                            tbRemover.CaretIndex = tbRemover.Text.Length;
                            tbRemover.ScrollToEnd();
                        }));
                    }

                    Thread.Sleep(1000);
                }
            })
            .Start();
        }

        //https://stackoverflow.com/a/60480334
        public static string GetRootCertificates()
        {
            StringBuilder builder = new StringBuilder();
            X509Store store = new X509Store(StoreName.Root);
            store.Open(OpenFlags.ReadOnly);
            foreach (X509Certificate2 mCert in store.Certificates)
            {
                builder.AppendLine(
                    "# Issuer: " + mCert.Issuer.ToString() + "\n" +
                    "# Subject: " + mCert.Subject.ToString() + "\n" +
                    "# Label: " + mCert.FriendlyName.ToString() + "\n" +
                    "# Serial: " + mCert.SerialNumber.ToString() + "\n" +
                    "# SHA1 Fingerprint: " + mCert.GetCertHashString().ToString() + "\n" +
                    ExportToPEM(mCert) + "\n");
            }
            return builder.ToString();
        }

        public static string ExportToPEM(X509Certificate cert)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("-----BEGIN CERTIFICATE-----");
            builder.AppendLine(Convert.ToBase64String(cert.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks));
            builder.AppendLine("-----END CERTIFICATE-----");

            return builder.ToString();
        }
    }
}
