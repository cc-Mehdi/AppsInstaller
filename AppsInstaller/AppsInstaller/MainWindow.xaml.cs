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
        Installation installationPage = null;
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
                if (customizePage.installLocation == "")
                    MessageBox.Show("لطفا محل نصب را انتخاب کنید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                else if(customizePage.chAgreeRules.IsChecked == false)
                    MessageBox.Show("اگر با قوانین موافق هستید گزینه موافق هستم را بزنید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    if (btnInstallAndFinish.Content.ToString() == "بعدی")
                    {
                        btnInstallAndFinish.Content = "نصب";
                        installationPage = new Installation(customizePage.installLocation, customizePage.createShortcut);
                        frame.NavigationService.Navigate(installationPage);
                    }
                    else if (btnInstallAndFinish.Content.ToString() == "نصب")
                    {
                        btnClose.IsEnabled = false;
                        btnInstallAndFinish.Content = "پایان";
                        installationPage.StartInstalling(ref btnClose, ref btnInstallAndFinish);
                    }
                    else
                        if(installationPage.isInstallFinished)
                            this.Close();

                }
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
