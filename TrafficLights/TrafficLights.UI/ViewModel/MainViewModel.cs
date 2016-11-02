using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLights.UI.ViewModel {


    public class MainViewModel : ViewModelBase {


        private string _test;

        public string Test {
            get { return _test; }
            set { Set(ref _test,value); }
        }
        public MainViewModel() {
            Test = "blabla";
        }
    }
}
