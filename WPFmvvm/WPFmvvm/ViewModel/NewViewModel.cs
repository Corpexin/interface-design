using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFmvvm.ViewModel
{
    public class NewViewModel : ViewModelBase
    {


        public const string MyTextPropertyPropertyName = "MyText";

        private string _myText = "";

        public string MyText
        {
            get
            {
                return _myText;
            }

            set
            {
                if (_myText == value)
                {
                    return;
                }

                _myText = value;
                RaisePropertyChanged(MyTextPropertyPropertyName);

                Messenger.Default.Send(MyText , "Hello!");
            }
        }

        public NewViewModel()
        {


        }
    }
}
