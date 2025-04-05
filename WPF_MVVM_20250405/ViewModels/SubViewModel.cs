using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_20250405.ViewModels
{
    public class SubViewModel:BaseViewModel
    {
        public SubViewModel()
        {
            
        }
        private double _SliderValue;

        public double SliderValue
        {
            get { return _SliderValue; }
            set { _SliderValue = value;
                OnPropertyChanged();
            }
        }

    }
}
