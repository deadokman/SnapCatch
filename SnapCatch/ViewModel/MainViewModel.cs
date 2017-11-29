using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace SnapCatch.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            RestoreWindowCommand = new RelayCommand(() =>
                {
                    App.Current.MainWindow.Show();
                    App.Current.MainWindow.Activate();
                }
            );

            DisplaySettings = new RelayCommand(() =>
            {
                var sw = new SettingsWindow();
                sw.Show();
            });

            CloseAppCommand = new RelayCommand(() =>
            {
                App.Current.Shutdown();
            });
        }

        public ICommand RestoreWindowCommand { get; set; }

        public ICommand DisplaySettings { get; set; }

        public ICommand CloseAppCommand { get; set; }
    }
}