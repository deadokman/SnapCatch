/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:SnapCatch"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using SnapCatch.Logic;
using SnapCatch.ViewModel.SettingsPageViewModel;

namespace SnapCatch.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {

        private ScreenCaptureInvocator _invocator;

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<InterfaceSettingsViewModel>();
            SimpleIoc.Default.Register<GeneralSettingsViewModel>();
            SimpleIoc.Default.Register<KeyBindingsViewModel>();

            _invocator = new ScreenCaptureInvocator();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public SettingsViewModel Settings
        {
            get { return ServiceLocator.Current.GetInstance<SettingsViewModel>(); }
        }

        public InterfaceSettingsViewModel InterfaceSettings
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InterfaceSettingsViewModel>();
            }
        }

        public KeyBindingsViewModel KeyBindingsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<KeyBindingsViewModel>();
            }
        }

        public GeneralSettingsViewModel GeneralSettingsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GeneralSettingsViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}