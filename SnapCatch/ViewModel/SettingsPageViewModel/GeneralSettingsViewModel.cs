using System.Windows.Forms;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace SnapCatch.ViewModel.SettingsPageViewModel
{
    public class GeneralSettingsViewModel : ViewModelBase
    {

        public GeneralSettingsViewModel()
        {
            SetPathCommand = new RelayCommand(() =>
                {
                    var ofd = new FolderBrowserDialog();
                    var res = ofd.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        ScreenShotFolder = ofd.SelectedPath;
                    }
                }
            );
        }

        /// <summary>
        /// Выбрать папку с скриншотами по умолчанию.
        /// </summary>
        public ICommand SetPathCommand { get; set; }

        /// <summary>
        /// Путь к папке со скриншотами
        /// </summary>
        public string ScreenShotFolder
        {
            get { return Properties.Settings.Default.ScreenContentFolder; }
            set
            {
                Properties.Settings.Default.ScreenContentFolder = value;
                Properties.Settings.Default.Save();
                RaisePropertyChanged(() => ScreenShotFolder);
            }
        }

        public bool HideInTrayOnClose
        {
            get { return Properties.Settings.Default.HideInTrayOnClose; }
            set
            {
                Properties.Settings.Default.HideInTrayOnClose = value;
                Properties.Settings.Default.Save();
                RaisePropertyChanged(() => HideInTrayOnClose);
            }
        }

        /// <summary>
        /// Запускать программу на старте операционной системы
        /// </summary>
        public bool AutoStartUpProgram
        {
            get { return Properties.Settings.Default.AutoStartUp; }
            set
            {
                Properties.Settings.Default.AutoStartUp = value;
                Properties.Settings.Default.Save();
                RaisePropertyChanged(() => AutoStartUpProgram);
            }
        }
    }
}
