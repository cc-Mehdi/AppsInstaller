using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AppsInstaller.Pages
{
    /// <summary>
    /// Interaction logic for Instalation.xaml
    /// </summary>
    public partial class Installation : Page
    {
        public string _installLocation = "";
        public bool _createShortcut = false;
        public List<string> _technologies = new List<string>();
        private CommandPrompt cmd = new CommandPrompt();

        public Installation(string installLocation, bool createShortcut, List<string> technologies, ref Button btnClose, ref Button btnFinish)
        {
            _installLocation = installLocation;
            _createShortcut = createShortcut;
            _technologies = technologies;
            InitializeComponent();
            cmd.install(technologies[0]);
            loadingAnimation(technologies[0]);
            if(progress.Value == 100)
            {
                cmd.installProcess(technologies[0], installLocation, createShortcut);
                btnClose.IsEnabled = btnFinish.IsEnabled = true;
                imgStartInstall.Visibility = System.Windows.Visibility.Hidden;
                imgFinishInstall.Visibility = System.Windows.Visibility.Visible;
            }
        }

        //Show install process status.
        private void loadingAnimation(string appName)
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
                    }
                    else
                    {
                        progressNumber.Text = "99";
                        progress.Value = 99;
                        while (true)
                        {
                            Thread.Sleep(2000);
                            if (cmd.isInstallComplete(appName))
                                break;
                        }
                    }
                }
                else
                {
                    progressNumber.Text = "100";
                    progress.Value = 100;
                    break;
                }
                Thread.Sleep(300);
            }
        }
    }
}
