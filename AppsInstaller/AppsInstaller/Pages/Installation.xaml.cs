using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AppsInstaller.Pages
{
    /// <summary>
    /// Interaction logic for Instalation.xaml
    /// </summary>
    public partial class Installation : Page
    {
        public bool isInstallFinished = false;
        public string _installLocation = "";
        public bool _createShortcut = false;
        private CommandPrompt cmd = new CommandPrompt();
        List<AppOptions> appsList = new List<AppOptions>();
        int appNumber = 0;

        public Installation(string installLocation, bool createShortcut)
        {
            _installLocation = installLocation;
            _createShortcut = createShortcut;
            InitializeComponent();
            using (StreamReader r = new StreamReader(System.Windows.Forms.Application.StartupPath + "/configs.json"))
            {
                string json = r.ReadToEnd();
                appsList = JsonSerializer.Deserialize<List<AppOptions>>(json);
            }
        }

        public void StartInstalling(ref Button btnClose, ref Button btnFinish)
        {
            imgStartInstall.Visibility = System.Windows.Visibility.Visible;

            cmd.install(appsList[appNumber].AppName);

            loadingAnimation(appsList[appNumber].AppName);
        }

        private void EnableButtons(ref Button btnClose, ref Button btnFinish)
        {
            btnClose.IsEnabled = btnFinish.IsEnabled = true;
        }

        private void FinishInstalling()
        {
            cmd.installProcess(appsList[appNumber].AppName, appsList[appNumber].AppLocation, _installLocation, _createShortcut);
            //Tell to MainWindows Page to close application when user click finish button
            isInstallFinished = true;
            imgStartInstall.Visibility = System.Windows.Visibility.Hidden;
            imgFinishInstall.Visibility = System.Windows.Visibility.Visible;
        }

        private void changeProgressValue(int min, int max)
        {
            while(min <= max)
            {
                progress.Value = min;
                progressNumber.Text = $"%{min}";
                min += new Random().Next(min, max);
                Thread.Sleep(300);
            }
            progress.Value = max;
            progressNumber.Text = $"%{max}";
        }

        //Show install process status.
        private async Task loadingAnimation(string appName)
        {
            Random rand = new Random();
            for (int i = 0; i <= 150; i += rand.Next(1, 15))
            {
                if (!cmd.isInstallComplete(appName))
                {
                    if (i < 85)
                    {
                        progressNumber.Text = i.ToString();
                        progress.Value = i;
                        await Task.Delay(1000);
                    }
                    else
                    {
                        progressNumber.Text = "99";
                        progress.Value = 99;
                        await Task.Delay(1000);
                        while (true)
                        {
                            await Task.Delay(2000);
                            if (cmd.isInstallComplete(appName))
                                break;
                        }
                    }
                }
                else
                {
                    progressNumber.Text = "100";
                    progress.Value = 100;
                    FinishInstalling();
                    break;

                }
                await Task.Delay(300);
            }
        }
    }

    internal class AppOptions
    {
        public string AppName { get; set; }
        public string AppLocation { get; set; }
    }
}
