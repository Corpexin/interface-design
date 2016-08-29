/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WPFmvvm"
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
using System.Diagnostics.CodeAnalysis;

namespace WPFmvvm.ViewModel
{

    public class ViewModelLocator
    {
        //
        private static MainViewModel _main;
        private static NewViewModel _newView;


        public ViewModelLocator()
        {
            CreateMain();
        }


        //
        public static MainViewModel MainStatic
        {
            get
            {
                if (_main == null)
                {
                    CreateMain();
                }

                return _main;
            }
        }

        public static NewViewModel NewViewStatic
        {
            get
            {
                if (_newView == null)
                {
                    CreateNewView();
                }

                return _newView;
            }
        }




        //
        public static void CreateMain()
        {
            if (_main == null)
            {
                _main = new MainViewModel();
            }
        }

        public static void CreateNewView()
        {
            if (_newView == null)
            {
                _newView = new NewViewModel();
            }
        }




        //
        [SuppressMessage("Microsoft.Performance",
    "CA1822:MarkMembersAsStatic",
    Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return MainStatic;
            }
        }


        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public NewViewModel NewView
        {
            get
            {
                return NewViewStatic;
            }
        }




        public static void ClearMain()
        {
            _main.Cleanup();
            _main = null;
        }

        public static void ClearSettings()
        {
            _newView = null;
        }

        public static void Cleanup()
        {
            ClearMain();
        }


        


    }
}