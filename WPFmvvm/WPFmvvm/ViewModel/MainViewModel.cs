using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace WPFmvvm.ViewModel
{

    public class MainViewModel : ViewModelBase
    {


        public const string WelcomePropertyPropertyName = "Welcome";

        private string _welcome = "";


        public string Welcome
        {
            get
            {
                return _welcome;
            }

            set
            {
                if (_welcome == value)
                {
                    return;
                }

                _welcome = value;
                RaisePropertyChanged(WelcomePropertyPropertyName);
            }
        }


         
        public MainViewModel()
        {
            Messenger.Default.Register<string>(this, "Hello!", message =>
            {
                Welcome = message;
            });
        }
    }
}