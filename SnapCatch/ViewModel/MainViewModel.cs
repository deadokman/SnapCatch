using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using SnapCatch.Logic;
using SnapCatch.Logic.Drawing;
using SnapCatch.Logic.Tools;
using SnapCatch.Logic.Tools.ToolItems;
using Size = System.Drawing.Size;

namespace SnapCatch.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private double _width;
        private double _height;
        private double _imageCenterX;
        private double _imageCenterY;
        private double _workAreaScaleFactor;
        private double _value;

        /// <summary>
        /// Image tool manager
        /// </summary>
        public ToolsManager ToolManager { get; set; }

        /// <summary>
        /// Controlls view port scale, offsets and translate viewporrt coordinates to image coordinates
        /// </summary>
        public ViewportController ViewportController { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            _width = 300;
            _height = 300;
            ToolManager = new ToolsManager();
            if (!IsInDesignMode)
            {
                ToolManager.InitInstance();
            }

            DrawingLayers = new ObservableCollection<DrawingLayer>();
            RestoreWindowCommand = new RelayCommand(() =>
                {
                    Application.Current.MainWindow.Show();
                    Application.Current.MainWindow.Activate();
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
            Application.Current.MainWindow.Show();
            Application.Current.MainWindow.Activate();
            ViewportController.ImageChanged(img);
            var dl = new DrawingLayer();
            Canvas.SetTop(dl, 0);
            Canvas.SetLeft(dl, 0);
            dl.Width = img.Width;
            dl.Height = img.Height;
            var mt = new MovingImageThumb();
            mt.Source = img;
            mt.Width = img.Width;
            mt.Height = img.Height;
            Canvas.SetLeft(mt, 0);
            Canvas.SetTop(mt, 0);
            dl.AddItem(mt);
            DrawingLayers.Add(dl);
        }

    
        public ObservableCollection<DrawingLayer> DrawingLayers { get; set; }

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