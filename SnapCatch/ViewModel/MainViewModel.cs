using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using SnapCatch.Logic.Drawing;
using SnapCatch.Logic.Tools;
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
        private ObservableCollection<ImageToolBase> _pointToolItems;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            _width = 300;
            _height = 300;
            SliderValue = 0;

            DrawingLayers = new ObservableCollection<DrawingLayer>();
            PointToolItems = new ObservableCollection<ImageToolBase>()
            {
                new PointTool(),
                new PointTool(),
                new PointTool()
            };



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
            Application.Current.MainWindow.Show();
            Application.Current.MainWindow.Activate();
            Width = img.Width;
            Height = img.Height;
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

        /// <summary>
        /// Change work area size
        /// </summary>
        /// <param name="size"></param>
        public void SetWorkAreaSize(Size size)
        {
            Width = size.Width;
            Height = size.Height;
        }

        public double ImageCenterX
        {
            get { return _imageCenterX; }
            private set
            {
                _imageCenterX = value;
                RaisePropertyChanged(() => ImageCenterX);
            }
        }

        public double ImageCenterY
        {
            get { return _imageCenterY; }
            private set
            {
                _imageCenterY = value;
                RaisePropertyChanged(() => ImageCenterY);
            }
        }

        public double SliderValue
        {
            get { return _value; }
            set
            {
                _value = value;
                WorkAreaScaleFactor = 1 + value / 1000;
            }
        }

        /// <summary>
        /// Work area scalling value
        /// </summary>
        public double WorkAreaScaleFactor
        {
            get { return _workAreaScaleFactor; }
            set
            {
                _workAreaScaleFactor = value;
                RaisePropertyChanged(() => WorkAreaScaleFactor);
            }
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
                ImageCenterX = _width / 2;
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
                ImageCenterY = Height / 2;
                RaisePropertyChanged(() => Height);
            }
        }

        public ObservableCollection<ImageToolBase> PointToolItems
        {
            get { return _pointToolItems; }
            set
            {
                _pointToolItems = value; 
                RaisePropertyChanged(() => PointToolItems);
            }
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