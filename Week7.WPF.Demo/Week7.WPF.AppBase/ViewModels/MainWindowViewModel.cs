using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.WPF.AppBase.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _myProperty = "Testo di prova";

        public string MyProperty
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Get");
                return _myProperty;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine("Set");
                _myProperty = value;
                NotifyPropertyChanged();
            }
        }

        private int _myProperty2;
        public int MyProperty2
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Get");
                return _myProperty2;
            }
            set {
                System.Diagnostics.Debug.WriteLine("Set");
                _myProperty2 = value;
            }
        }

        private bool isChecked = true;

        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; NotifyPropertyChanged();}
        }
    }
}
