using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AppsInstaller.Pages;

namespace AppsInstaller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Customize customizePage = new Customize();

        public MainWindow()
        {
            InitializeComponent();
            frame.NavigationService.Navigate(customizePage);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnNext_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (btnInstallAndFinish.Content.ToString() == "Install")
                {
                    if (customizePage.installLocation == "")
                        MessageBox.Show("Please select install location");
                    else if (customizePage.technologies.Count == 0)
                        MessageBox.Show("Select your technologies for install");
                    else
                    {
                        btnClose.IsEnabled = btnInstallAndFinish.IsEnabled = false;
                        btnInstallAndFinish.Content = "Finish";
                        Installation installationPage = new Installation(customizePage.installLocation, customizePage.createShortcut, customizePage.technologies, ref btnClose, ref btnInstallAndFinish);
                        frame.NavigationService.Navigate(installationPage);
                    }
                }
                else
                    this.Close();
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
