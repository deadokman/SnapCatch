using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using SnapCatch.Logic;
using SnapCatch.Logic.Tools;

namespace SnapCatch.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Image tool manager
        /// </summary>
        public ToolsManager ToolsManager { get; private set; }

        /// <summary>
        /// Controlls view port scale, offsets and translate viewporrt coordinates to image coordinates
        /// </summary>
        public ViewportManager ViewportManager { get; private set; }

        /// <summary>
        /// Manage layers on workarea
        /// </summary>
        public LayersManager LayersManager { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ViewportManager = new ViewportManager();
            LayersManager = new LayersManager(ViewportManager);
            ToolsManager = new ToolsManager(LayersManager, ViewportManager);
            if (!IsInDesignMode)
            {
                ToolsManager.InitInstance();
            }

            RestoreWindowCommand = new RelayCommand(SetWindowActive);

            DisplaySettings = new RelayCommand(() =>
            {
                var sw = new SettingsWindow();
                sw.Show();
            });

            CloseAppCommand = new RelayCommand(() =>
            {
                Application.Current.Shutdown();
            });
        }

        public void ScreenCaptured(ImageSource img)
        {
            SetWindowActive();
            ViewportManager.ImageChanged(img);
            LayersManager.AddNewLayer(img);
        }

        private void SetWindowActive()
        {
            // ReSharper disable once PossibleNullReferenceException
            Application.Current.MainWindow.Show();
            Application.Current.MainWindow.Activate();
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

        /// <summary>
        /// Start using tool command, apperars when left mouse button down
        /// </summary>
        public ICommand StartUsingTool { get; set; }
    }
}