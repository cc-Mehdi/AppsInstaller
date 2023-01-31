using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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

        public Installation(string installLocation, bool createShortcut)
        {
            _installLocation = installLocation;
            _createShortcut = createShortcut;
            InitializeComponent();
        }

        public void StartInstalling(ref Button btnClose, ref Button btnFinish)
        {
            imgStartInstall.Visibility = System.Windows.Visibility.Visible;

            cmd.install("python");

            loadingAnimation("python");
        }

        private void EnableButtons(ref Button btnClose, ref Button btnFinish)
        {
            btnClose.IsEnabled = btnFinish.IsEnabled = true;
        }

        private void FinishInstalling()
        {
            cmd.installProcess("python", _installLocation, _createShortcut);
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
}
