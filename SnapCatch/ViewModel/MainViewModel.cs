using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace SnapCatch.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private double _width;
        private double _height;

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

        public void ActivateEditor(ImageSource img)
        {
            App.Current.MainWindow.Show();
            App.Current.MainWindow.Activate();
        }

        /// <summary>
        /// Change work area size
        /// </summary>
        /// <param name="size"></param>
        public void SetWorkAreaSize(Size size)
        {
            Width = size.Width;
            Height = size.Height;
        }

        /// <summary>
        /// WorkArea width
        /// </summary>
        public double Width
        {
            get { return _width; }
            set
            {
                _width = value; 
                RaisePropertyChanged(() => Width);
            }
        }

        /// <summary>
        /// Work area Height
        /// </summary>
        public double Height
        {
            get { return _height; }
            set
            {
                _height = value; 
                RaisePropertyChanged(() => Height);
            }
        }

        /// <summary>
        /// Restore window, invokes after TrayIcon double click
        /// </summary>
        public ICommand RestoreWindowCommand { get; set; }

        /// <summary>
        /// Click on TrayIcon context menu settings
        /// </summary>
        public ICommand DisplaySettings { get; set; }

        /// <summary>
        /// Click on close app in context menu tray
        /// </summary>
        public ICommand CloseAppCommand { get; set; }
    }
}