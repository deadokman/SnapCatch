using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using SnapCatch.AdditionalPages.SettingsPages;
using SnapCatch.AdditionalPages.SettingsPages.SettingsItems;
using SnapCatch.Resources;

namespace SnapCatch.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        private SettingsDisplayItem _selectedItem;
        private int _settingsDisplayPage;

        public SettingsViewModel()
        {
            DisplayItems = new List<SettingsDisplayItem>(new []
            {
                new SettingsDisplayItem((Canvas)IconResources.SharedDictionary["appbar_settings"], "ОБЩИЕ", new GeneralSettingsPage()),
                new SettingsDisplayItem((Canvas)IconResources.SharedDictionary["appbar_input_keyboard"], "КЛАВИШИ", new KeyBindingsPage()),
                new SettingsDisplayItem((Canvas)IconResources.SharedDictionary["appbar_camera"], "СНИМОК", new KeyBindingsPage()),
                new SettingsDisplayItem((Canvas)IconResources.SharedDictionary["appbar_laptop"], "ИНТЕРФЕЙС", new InterfaceSettingsPage()),

                

            });

            SelectedItem = DisplayItems[0];
        }

        public SettingsDisplayItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                var idx = DisplayItems.IndexOf(value);
                SelectedIndex = idx;
            }
        }



        public List<SettingsDisplayItem> DisplayItems { get; set; }

        /// <summary>
        /// Индекс выбранного таба
        /// </summary>
        public int SelectedIndex
        {
            get { return _settingsDisplayPage; }
            set
            {
                _settingsDisplayPage = value;
                RaisePropertyChanged(() => SelectedIndex);
            }
        }
    }
}
