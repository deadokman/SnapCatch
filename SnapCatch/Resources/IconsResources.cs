using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnapCatch.Resources
{
    public static class IconResources
    {
        internal static ResourceDictionary SharedDictionary
        {
            get
            {
                if (_sharedDictionary == null)
                {
                    try
                    {
                        System.Uri resourceLocater1 = new System.Uri(
                            string.Format("/{0};component/Resources/Icons.xaml", "SnapCatch"), System.UriKind.Relative);
                        ResourceDictionary resourceDictionary = new ResourceDictionary
                        {
                            Source = resourceLocater1
                        };
                        _sharedDictionary = resourceDictionary;
                    }
                    catch (Exception e)
                    {

                    }
                }

                return _sharedDictionary;
            }
        }

        private static ResourceDictionary _sharedDictionary;
    }
}
